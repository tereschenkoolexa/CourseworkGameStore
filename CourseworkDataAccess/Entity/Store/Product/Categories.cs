using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseworkDataAccess.Entity.Store.Product
{
    [Table("tblCategories")]
    public class Categories
    {

        public bool Shooter { get;set;}
        public bool Fighting { get;set;}
        public bool Strategy { get;set;}
        public bool Simulator { get;set;}
        public bool Sports { get;set;}
        public bool Racing { get;set;}
        public bool RolePlaying {get;set;}
        public bool Action { get;set;}
        public bool Adventure { get;set;}
        public bool RPG { get;set;}
        public bool Stealth { get;set;}
        public bool Horror { get; set; }
        public bool Sandbox { get; set; }
        public bool Survival { get; set; }
        public bool Platformer { get; set; }

        [Key, ForeignKey("ProductOf")]
        public int ProdctId { get; set; }
        public virtual Product ProductOf { get; set; }
    }
}
