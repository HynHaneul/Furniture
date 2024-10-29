using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Furniture.Models.Context
{
    [Table("News")]
    public class News
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int News_ID { get; set; }
        [Required(ErrorMessage ="Bạn không được để trống tên Tin Tức")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public int Category_ID { get; set; }
        public string C_Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string C_Image { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }
    }
}
