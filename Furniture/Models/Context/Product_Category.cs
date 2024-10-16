using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Furniture.Models.Context
{
    [Table("Product_Category")]
    public class Product_Category
    {
        public Product_Category()
        {
            this.C_Product = new HashSet<C_Product>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Product_Category_ID { get; set; }
        public int Category_ID { get; set; }
        public string Title { get; set; }
        public string C_Description { get; set; }
        public string Icon { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<C_Product> C_Product { get; set; }
        public virtual Category Category { get; set; }
    }
}
