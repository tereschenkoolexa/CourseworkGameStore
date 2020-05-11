using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseworkDataAccess.Entity.Store.Product.Communication
{
    [Table("tblProductLanguages")]
    public class ProductLanguages
    {
        [Key, ForeignKey("ProductOf"), Column(Order = 0)]
        public int ProdctId { get; set; }
        public virtual Product ProductOf { get; set; }


        [Key, ForeignKey("LanguageOf"), Column(Order = 1)]
        public int LanguageId { get; set; }
        public virtual Language LanguageOf { get; set; }

    }
}
