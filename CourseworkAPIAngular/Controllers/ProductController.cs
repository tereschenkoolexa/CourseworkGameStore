﻿using CourseworkAPIAngular.Helper;
using CourseworkDataAccess;
using CourseworkDataAccess.Entity.Store.Product;
using CourseworkDataAccess.Entity.Store.Product.Communication;
using CourseworkDTO.Models.Product;
using CourseworkDTO.Models.Product.Categories;
using CourseworkDTO.Models.Product.Communication.Library;
using CourseworkDTO.Models.Product.Communication.ProductCategories;
using CourseworkDTO.Models.Product.Communication.ProductLanguages;
using CourseworkDTO.Models.Product.Languages;
using CourseworkDTO.Models.Product.SystemRequirements;
using CourseworkDTO.Models.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace CourseworkAPIAngular.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly EFContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public ProductController(IWebHostEnvironment appEnvironment, EFContext context)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }


        [HttpPost("addProduct")]
        public async Task<ResultDTO> AddProduct([FromBody] ProductAddDTO model, [FromForm(Name = "file")] IFormFile uploadedImage)
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
                    Image = "",
                    Data = model.Data,
                };
                _context.Products.Add(product);
                _context.SaveChanges();
                int idProduct = (from v in _context.Products orderby v.Id descending select v).FirstOrDefault().Id;
                var systemrequirements = new SystemRequirements()
                {

                    OS = model.sysreqProduct.OS,
                    Processor = model.sysreqProduct.Processor,
                    Graphics = model.sysreqProduct.Graphics,
                    Memory = model.sysreqProduct.Memory,
                    Storege = model.sysreqProduct.Storege,
                    ProdctId = idProduct
                };

                _context.SystemRequirementsProduct.Add(systemrequirements);

                foreach (var item in model.listIdLang)
                {

                    ProductLanguages temp = new ProductLanguages();

                    temp.ProdctId = idProduct;
                    temp.LanguageId = item;

                    _context.ProductLanguages.Add(temp);
                }

                foreach (var item in model.listIdCateg)
                {

                    ProductCategories temp = new ProductCategories();

                    temp.ProdctId = idProduct;
                    temp.CategoryId = item;

                    _context.ProductCategories.Add(temp);
                }


                _context.SaveChanges();


                return new ResultDTO
                {
                    Status = 200
                };

            }
        }


        [HttpGet("LanguagesProduct/{id}")]
        public IEnumerable<LanguagesItemDTO> getLanguagesProduct(int id)
        {

            List<LanguagesItemDTO> data = new List<LanguagesItemDTO>();


            foreach (var item in _context.ProductLanguages)
            {
                if (item.ProdctId == id)
                {
                    Language temp = _context.Languages.FirstOrDefault(t => t.Id == item.LanguageId);

                    LanguagesItemDTO tempItem = new LanguagesItemDTO();

                    tempItem.idLanguage = temp.Id;
                    tempItem.nameLanguage = temp.Name;

                    data.Add(tempItem);
                }
            }
            return data;

        }

        [HttpGet("CategoriesProduct/{id}")]
        public IEnumerable<CategoriesItemDTO> getCategoriesProduct(int id)
        {

            List<CategoriesItemDTO> data = new List<CategoriesItemDTO>();


            foreach (var item in _context.ProductCategories)
            {
                if (item.ProdctId == id)
                {
                    Category temp = _context.Categories.FirstOrDefault(t => t.Id == item.CategoryId);

                    CategoriesItemDTO tempItem = new CategoriesItemDTO();

                    tempItem.idCategory = temp.Id;
                    tempItem.nameCategory = temp.Name;

                    data.Add(tempItem);
                }
            }
            return data;

        }

        [HttpGet("GetLanguages")]
        public IEnumerable<LanguagesItemDTO> GetLanguages()
        {


            List<LanguagesItemDTO> data = new List<LanguagesItemDTO>();
            var dataFormDB = _context.Languages.ToList();
            foreach (var item in dataFormDB)
            {

                LanguagesItemDTO temp = new LanguagesItemDTO();

                temp.idLanguage = item.Id;
                temp.nameLanguage = item.Name;

                data.Add(temp);

            }
            return data;

        }

        [HttpGet("GetCategories")]
        public IEnumerable<CategoriesItemDTO> GetCategories()
        {


            List<CategoriesItemDTO> data = new List<CategoriesItemDTO>();
            var dataFormDB = _context.Categories.ToList();
            foreach (var item in dataFormDB)
            {

                CategoriesItemDTO temp = new CategoriesItemDTO();

                temp.idCategory = item.Id;
                temp.nameCategory = item.Name;

                data.Add(temp);

            }
            return data;

        }

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
                foreach (var item in _context.ProductCategories)
                {
                    if (item.ProdctId == id)
                    {
                        _context.ProductCategories.Remove(item);
                    }
                }
                foreach (var item in _context.ProductLanguages)
                {
                    if (item.ProdctId == id)
                    {
                        _context.ProductLanguages.Remove(item);
                    }
                }
                if (systemRequirementsProduct != null)
                {
                    _context.SystemRequirementsProduct.Remove(systemRequirementsProduct);
                }
                _context.SaveChanges();
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


        [HttpGet("getProductStore/{id}")]
        public ProductItemDTO GetProduct([FromRoute]int id)
        {
            var data = _context.Products.FirstOrDefault(t => t.Id == id);
            ProductItemDTO prod = new ProductItemDTO();
            prod.Name = data.Name;
            prod.CompanyName = data.CompanyName;
            prod.Price = data.Price;
            prod.Description = data.Description;
            prod.Image = data.Image;
            prod.Data = data.Data;

            
            return prod;

        }

        [HttpGet("getSysReq/{id}")]
        public SystemRequirementsItemDTo GetSysReq([FromRoute]int id)
        {

            var data = _context.SystemRequirements.FirstOrDefault(t => t.ProdctId == id);

            SystemRequirementsItemDTo sysreqProduct = new SystemRequirementsItemDTo();

            sysreqProduct.OS = data.OS;
            sysreqProduct.Processor = data.Processor;
            sysreqProduct.Graphics = data.Graphics;
            sysreqProduct.Memory = data.Memory;
            sysreqProduct.Storege = data.Storege;

            return sysreqProduct;

        }

        [HttpGet("getListLangId")]
        public IEnumerable<string> getListLangId([FromRoute]int id){

            List<string> languages = new List<string>();

            List<int> idLang = new List<int>();

            foreach(var item in _context.ProductLanguages)
            {

                if(item.ProdctId == id)
                {
                    idLang.Add(item.LanguageId);
                }

            }

            foreach(var item in _context.Languages)
            {
                for(int i=0;i<idLang.Count();i++)
                {
                    if(item.Id == idLang[i])
                    {
                        languages.Add(item.Name);
                    }
                }
            }

            return languages;

        }

        [HttpGet("getListtCategId")]
        public IEnumerable<string> getListCategId([FromRoute]int id)
        {

            List<string> categories = new List<string>();

            List<int> idCateg = new List<int>();

            foreach (var item in _context.ProductCategories)
            {

                if (item.ProdctId == id)
                {
                    idCateg.Add(item.CategoryId);
                }

            }

            foreach (var item in _context.Categories)
            {
                for (int i = 0; i < idCateg.Count(); i++)
                {
                    if (item.Id == idCateg[i])
                    {
                        categories.Add(item.Name);
                    }
                }
            }

            return categories;

        }


        [HttpPost("editUser/{id}")]
        public ResultDTO EditUser([FromRoute]int id, [FromBody]ProductEditDTO model)
        {
            var product = _context.Products.FirstOrDefault(t => t.Id == id);

            product.Name = model.Name;
            product.CompanyName = model.CompanyName;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Image = model.Image;
            product.Data = model.Data;


            product.SystemRequirementProduct.OS = model.sysreqProduct.OS;
            product.SystemRequirementProduct.Processor = model.sysreqProduct.Processor;
            product.SystemRequirementProduct.Graphics = model.sysreqProduct.Graphics;
            product.SystemRequirementProduct.Memory = model.sysreqProduct.Memory;
            product.SystemRequirementProduct.Storege = model.sysreqProduct.Storege;

            foreach (var item in _context.ProductCategories)
            {
                if (item.ProdctId == id)
                {
                    _context.ProductCategories.Remove(item);
                }
            }
            foreach (var item in _context.ProductLanguages)
            {
                if (item.ProdctId == id)
                {
                    _context.ProductLanguages.Remove(item);
                }
            }

            foreach (var item in model.listIdLang)
            {

                ProductLanguages temp = new ProductLanguages();

                temp.ProdctId = id;
                temp.LanguageId = item;

                _context.ProductLanguages.Add(temp);
            }

            foreach (var item in model.listIdCateg)
            {

                ProductCategories temp = new ProductCategories();

                temp.ProdctId = id;
                temp.CategoryId = item;

                _context.ProductCategories.Add(temp);
            }

            _context.SaveChanges();



            return new ResultDTO
            {
                Status = 200,
                Message = "OK"
            };

        }



        [HttpPost("UploadImage")]
        public ResultDTO UploadImage([FromForm(Name = "file")] IFormFile uploadedImage)
        {
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string path = _appEnvironment.WebRootPath + @"\Images\" + fileName;
            if (uploadedImage == null)
                return new ResultDTO
                {
                    Status = 400,
                    Errors = new List<string> { "Не вдалося завантажити файл" }
                };
            if (uploadedImage.Length == 0)
                return new ResultDTO
                {
                    Status = 400,
                    Errors = new List<string> { "Файл порожній" }
                };
            try
            {
                using (Bitmap bmp = new Bitmap(uploadedImage.OpenReadStream()))
                {
                    var saveImage = ImageWorker.CreateImage(bmp, 400, 365);
                    int idProduct = (from v in _context.Products orderby v.Id descending select v).FirstOrDefault().Id;
                    if (saveImage != null)
                    {
                        saveImage.Save(path, ImageFormat.Jpeg);
                        var product = _context.Products.Find(idProduct);
                       
                        _context.Products.Find(idProduct).Image = fileName;
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultDTO
                {
                    Status = 400,
                    Errors = new List<string> { "Не вдалося завантажити файл" },
                    Message = ex.InnerException.Message
                };
            }
            return new ResultDTO
            {
                Status = 200
            };
        }




        [HttpPost("buyProduct")]
        public ResultDTO BuyProduct([FromBody]LibraryAddDTO model)
        {
            if (model.idUser == null)
            {
                return new ResultDTO
                {
                    Status = 500,
                    Message = "Error",
                    Errors = Validation.GetErrorsByModel(ModelState)
                };
            }
            else {
                Library libraryItem = new Library();
                libraryItem.ProdctId = model.idProduct;
                libraryItem.UserId = model.idUser;

                _context.Library.Add(libraryItem);

                _context.SaveChanges();
            return new ResultDTO
            {
                Status = 200,
                Message = "OK"
            };
            }
        }

        [HttpGet("getLibrary/{id}")]
        public IEnumerable<int> GetLibrary([FromRoute] string id)
        {

            List<int> lib = new List<int>();

            foreach(var item in _context.Library)
            {
                if (item.UserId == id)
                    lib.Add(item.ProdctId);
            }

            return lib;

        }

    }
}