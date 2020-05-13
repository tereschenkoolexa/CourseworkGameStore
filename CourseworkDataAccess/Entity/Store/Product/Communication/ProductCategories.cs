using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseworkDataAccess.Entity.Store.Product.Communication
{
    [Table("tblProductCategories")]
    public class ProductCategories
    {

        [Key, ForeignKey("ProductOf"), Column(Order = 1)]
        public int ProdctId { get; set; }
        public virtual Product ProductOf { get; set; }


        [Key, ForeignKey("CategoryOf"), Column(Order = 2)]
        public int CategoryId { get; set; }
        public virtual Category CategoryOf { get; set; }


    }
}
