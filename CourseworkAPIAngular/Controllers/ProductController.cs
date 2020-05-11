using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseworkAPIAngular.Helper;
using CourseworkDataAccess;
using CourseworkDataAccess.Entity.Store.Product;
using CourseworkDTO.Models.Product;
using CourseworkDTO.Models.Product.Categories;
using CourseworkDTO.Models.Product.Languages;
using CourseworkDTO.Models.Product.SystemRequirements;
using CourseworkDTO.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkAPIAngular.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly EFContext _context;


        public ProductController(EFContext context)
        {
            _context = context;

        }

        [HttpPost("addProduct")]
        public async Task<ResultDTO> AddProduct([FromBody] ProductAddDTO model/*, [FromBody] SystemRequirementsAddDTO modelSystemRequirements*/)
        {
            if (!ModelState.IsValid)
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
                var product = new Product()
                {
                    Name = model.Name,
                    CompanyName = model.CompanyName,
                    Price = model.Price,
                    Description = model.Description,
                    Image = model.Image,
                    Data = model.Data,
                };
                _context.Products.Add(product);

                //var systemrequirements = new SystemRequirements()
                //{

                //    OS = modelSystemRequirements.OS,
                //    Processor = modelSystemRequirements.Processor,
                //    Graphics = modelSystemRequirements.Graphics,
                //    Memory = modelSystemRequirements.Memory,
                //    Storege = modelSystemRequirements.Storege,
                //    ProdctId = product.Id
                //};
                //_context.SystemRequirementsProduct.Add(systemrequirements);
         
                _context.SaveChanges();
                

                return new ResultDTO
                {
                    Status = 200
                };

            }
        }

        //[HttpGet("SysReqProduct/{Pid}")]
        //public IEnumerable<SystemRequirementsItemDTo> getSystemRequirementsProduct(int id)
        //{

        //    SystemRequirementsItemDTo data = new SystemRequirementsItemDTo();
        //    var dataFormDB = _context.Products.ToList();
        //    foreach (var item in dataFormDB)
        //    {

        //        ProductItemDTO temp = new ProductItemDTO();

        //        temp.CompanyName = item.CompanyName;
        //        temp.Data = item.Data;
        //        temp.Id = item.Id;
        //        temp.Image = item.Image;
        //        temp.Name = item.Name;
        //        temp.Price = item.Price;

        //        data.Add(temp);

        //    }
        //    return data;
        //}

        [HttpGet]
        public IEnumerable<ProductItemDTO> getProducts()
        {

            List<ProductItemDTO> data = new List<ProductItemDTO>();
            var dataFormDB = _context.Products.ToList();
            foreach (var item in dataFormDB)
            {

                ProductItemDTO temp = new ProductItemDTO();

                temp.CompanyName = item.CompanyName;
                temp.Data = item.Data;
                temp.Id = item.Id;
                temp.Image = item.Image;
                temp.Name = item.Name;
                temp.Price = item.Price;

                data.Add(temp);

            }
            return data;
        }

        [HttpPost("RemoveProduct/{id}")]
        public ResultDTO RemoveProduct([FromRoute]int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(t => t.Id == id);
                var systemRequirementsProduct = _context.SystemRequirementsProduct.FirstOrDefault(t => t.ProdctId == id);
                _context.Products.Remove(product);
                if (systemRequirementsProduct != null)
                {
                    _context.SystemRequirementsProduct.Remove(systemRequirementsProduct);

                    _context.SaveChanges();
                }
                return new ResultDTO
                {
                    Status = 200,
                    Message = "OK"
                };

            }
            catch (Exception e)
            {
                List<string> temp = new List<string>();
                temp.Add(e.Message);
                return new ResultDTO
                {
                    Status = 500,
                    Message = "ERROR",
                    Errors = temp
                };
            }
        }
    }
}