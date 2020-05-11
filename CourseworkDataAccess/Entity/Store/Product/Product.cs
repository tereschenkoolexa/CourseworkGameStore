using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseworkDataAccess.Entity.Store.Product
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public DateTime Data { get; set; }

        [Required]
        public SystemRequirements SystemRequirementProduct { get; set; }


    }

}
