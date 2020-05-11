using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseworkDataAccess.Entity
{
    [Table("tblMoreInfo")]
    public class UserMoreInfo
    {

        [Key]
        public string id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }

        public virtual User User { get; set; }

    }
}
