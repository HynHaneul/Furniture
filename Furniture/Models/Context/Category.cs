using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Furniture.Models.Context
{
    [Table("dbo.Category")]
    public class Category
    {
        public Category()
        {
            this.News = new HashSet<News>();
            this.Posts = new HashSet<Post>();
            this.Product_Category = new HashSet<Product_Category>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Category_ID { get; set; }
        [Required(ErrorMessage ="Tên Danh Mục không được để trống")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public string C_Description { get; set; }
        public int Position { get; set; }
        [StringLength(150)]
        public string SeoTitle { get; set; }
        [StringLength(250)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Product_Category> Product_Category { get; set; }
    }
}
