using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseworkDataAccess.Entity.Store.Product
{
    [Table("tblSystemRequirements")]
    public class SystemRequirements
    {

        [Required]
        public string OS { get; set; }
        [Required]
        public string Processor { get; set; }
        [Required]
        public string Memory { get; set; }
        [Required]
        public string Graphics { get; set; }
        [Required]
        public string Storege { get; set; }

        [Key, ForeignKey("ProductOf")]
        public int ProdctId { get; set; }
        public virtual Product ProductOf { get; set; }

    }
}
