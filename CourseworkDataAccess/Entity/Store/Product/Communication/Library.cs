using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseworkDataAccess.Entity.Store.Product.Communication
{
    [Table("tblLibrary")]
    public class Library
    {

        [Key, ForeignKey("ProductOf"), Column(Order = 1)]
        public int ProdctId { get; set; }
        public virtual Product ProductOf { get; set; }


        [Key, ForeignKey("UserOf"), Column(Order = 2)]
        public string UserId { get; set; }
        public virtual User UserOf { get; set; }

    }
}
