using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseworkDataAccess.Entity.Store.Product
{
    [Table("tblLanguages")]
    public class Languages
    {
        [Required]
        public bool English { get; set; }
        public bool French { get; set; }
        public bool Italian { get; set; }
        public bool German { get; set; }
        public bool Spanish { get; set; }
        public bool Arabic { get; set; }
        public bool Czech { get; set; }
        public bool Japanese { get; set; }
        public bool Korean { get; set; }
        public bool Polish { get; set; }
        public bool Portuguese { get; set; }
        public bool Russian { get; set; }
        public bool Turkish { get; set; }
        public bool Chinese { get; set; }
        public bool Ukrainian { get; set; }

        [Key, ForeignKey("ProductOf")]
        public int ProdctId { get; set; }
        public virtual Product ProductOf { get; set; }
    }
}
