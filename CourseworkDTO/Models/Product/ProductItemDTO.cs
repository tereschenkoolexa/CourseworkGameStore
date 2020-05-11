using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseworkDTO.Models.Product
{
    public class ProductItemDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string CompanyName { get; set; }

        public string Image { get; set; }

        public DataType Data { get; set; }
    }
}
