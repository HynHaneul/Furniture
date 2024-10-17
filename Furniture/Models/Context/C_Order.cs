using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Furniture.Models.Context
{
    [Table("_Order")]
    public class C_Order
    {
        public C_Order()
        {
            this.Order_Details = new HashSet<Order_Details>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int C_Order_ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string C_Address { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<Order_Details> Order_Details { get; set; }
    }
}