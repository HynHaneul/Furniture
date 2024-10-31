using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Furniture.Models.Context
{
    [Table("_Product")]
    public  class C_Product
    {
        public C_Product()
        {
            this.Order_Details = new HashSet<Order_Details>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int C_Product_ID { get; set; }
        public int Product_Category_ID { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Alias { get; set; }
        [StringLength(50)]
        public string ProductCode { get; set; }
        public string C_Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        [StringLength(250)]
        public string C_Image { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public int Quantity { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }
        public bool IsSale { get; set; }
        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(500)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Order_Details> Order_Details { get; set; }
        public virtual Product_Category Product_Category { get; set; }
    }

}