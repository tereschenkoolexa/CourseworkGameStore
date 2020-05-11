using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseworkDataAccess;
using CourseworkDataAccess.Entity;
using CourseworkDTO.Models;
using CourseworkDTO.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkAPIAngular.Controllers
{
    [Route("api/UserManager")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly UserManager<User> _userManager;

        public UserManagerController(EFContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
    
        [HttpGet]
        public IEnumerable<UserItemDTO> getUsers()
        {

            List<UserItemDTO> data = new List<UserItemDTO>();
            var dataFormDB = _context.Users.Where(t => t.Email != "admin@gmail.com").ToList();
            foreach(var item in dataFormDB)
            {

                UserItemDTO temp = new UserItemDTO();
                var moreInfo = _context.UserMoreInfos.FirstOrDefault(t => t.id == item.Id);

                temp.Email = item.Email;
                temp.Id = item.Id;
                temp.Phone = item.PhoneNumber;
                if (moreInfo != null)
                {
                    temp.fullName = moreInfo.FullName;
                    temp.Age = moreInfo.Age;
                    temp.Address = moreInfo.Address;
                }
                data.Add(temp);

            }
            return data;
        }

        [HttpPost("RemoveUser/{id}")]
        public ResultDTO RemoveUser([FromRoute]string id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(t => t.Id == id);
                var userMoreinfo = _context.UserMoreInfos.FirstOrDefault(t => t.id == id);

                _context.Users.Remove(user);
                if(userMoreinfo!=null)
                {
                    _context.UserMoreInfos.Remove(userMoreinfo);
                }
                _context.SaveChanges();

                return new ResultDTO
                {
                    Status = 200,
                    Message = "OK"
                };

            }
            catch(Exception e)
            {
                List<string> temp = new List<string>();
                temp.Add(e.Message);
                return new ResultDTO {
                    Status = 500,
                    Message = "ERROR",
                    Errors = temp
                };
            }
        }
    }


}