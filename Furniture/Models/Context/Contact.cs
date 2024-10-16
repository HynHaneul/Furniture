using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Furniture.Models.Context
{
    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Contact_ID { get; set; }
        [Required(ErrorMessage ="Tên không được để trống")]
        [StringLength(150, ErrorMessage ="Không được vuot7t5 quá 150 ký tự")]
        public string C_Name { get; set; }
        public string Website { get; set; }
        [StringLength(150, ErrorMessage = "Không được vuot7t5 quá 150 ký tự")]
        public string Email { get; set; }
        [StringLength(4000)]
        public string C_Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
