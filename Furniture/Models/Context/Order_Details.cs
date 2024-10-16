using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Furniture.Models.Context
{
    [Table("Order_Details")]
    public partial class Order_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_Details_ID { get; set; }
        public int C_Order_ID { get; set; }
        public int C_Product_ID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual C_Order C_Order { get; set; }
        public virtual C_Product C_Product { get; set; }
    }
}
