using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseworkDTO.Models.Product
{
     public class ProductAddDTO
    {
        [Required(ErrorMessage = "Name is Rrequired!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is Rrequired!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Description is Rrequired!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "CompanyName is Rrequired!")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Image is Rrequired!")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Data is Rrequired!")]
        public DateTime Data { get; set; }
    }
}
