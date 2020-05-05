using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CourseworkAPIAngular.Helper;
using CourseworkDataAccess;
using CourseworkDataAccess.Entity;
using CourseworkDomain.Interfaces;
using CourseworkDTO.Models;
using CourseworkDTO.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CourseworkAPIAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly EFContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTTokenService _jWTTokenService;
        private readonly IConfiguration _iConfiguration;

        public AccountController(
            EFContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJWTTokenService jWTTokenService,
            IConfiguration iConfiguration
        )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _jWTTokenService = jWTTokenService;
            _iConfiguration = iConfiguration;
        }

        [HttpPost("register")]
        public async Task<ResultDTO> Register([FromBody] UserRegisterDTO model)
        {
            if(!ModelState.IsValid)
            {
                return new ResultDTO
                {
                    Status = 500,
                    Message = "Error",
                    Errors = Validation.GetErrorsByModel(ModelState)
                };
            }
            else
            {
                var user = new User()
                {
                    Email = model.email,
                    PhoneNumber = model.phoneNumber,
                    UserName = model.email
                };

                var userMoreInfo = new UserMoreInfo()
                {
                    id = user.Id,
                    FullName = model.fullName,
                    Address = model.address,
                    Age = model.age
                };

                var result = await _userManager.CreateAsync(user, model.password);

                if(!result.Succeeded)
                {
                    return new ResultDTO
                    {
                        Status = 400,
                        Errors = Validation.GetErrorsByIdentityResult(result)
                    };
                }
                else if (result.Succeeded)
                {
                    result = _userManager.AddToRoleAsync(user, "User").Result;
                    _context.UserMoreInfos.Add(userMoreInfo);
                    _context.SaveChanges();
                }

                return new ResultDTO
                {
                    Status = 200
                };
        
            }
        }

        [HttpPost("login")]
        public async Task<ResultDTO> Login([FromBody] UserLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultDTO
                {
                    Status = 400,
                    Message = "error",
                    Errors = Validation.GetErrorsByModel(ModelState)
                };
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(model.email, model.password, false, false);
                if(!result.Succeeded)
                {
                    List<string> error = new List<string>();
                    error.Add("User is not found? password or email isn`t correct!");
                    return new ResultDTO
                    {
                        Status = 400,
                        Message = "User is not found!"
                    };
                }
                else
                {
                    var user = await _userManager.FindByEmailAsync(model.email);
                    await _signInManager.SignInAsync(user, false);
                    return new ResultDTO
                    {
                        Status = 200,
                        Message = "OK",
                        Token = _jWTTokenService.CreateToken(user)
                    };
                }
            }
        }

    }
}