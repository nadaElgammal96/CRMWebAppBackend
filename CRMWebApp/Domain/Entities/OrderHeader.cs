using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderHeader
    { 
        public int OrderHeaderID { get; set; }


        [Required]
        public string OrderNumber { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        //not nullable by default
        public DateTime OrderDate { get; set; }


        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        
        public virtual Customer Customer { get; set; }

        
        [ForeignKey("Tax")]
        public int TaxID { get; set; } = 1;

        public virtual Tax Tax { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingAmount { get; set; }

        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Grandtotal { get; set; }


        [ForeignKey("ShippingAddress")]
        public int ShippingAddressID { get; set; }
        public virtual CustomerAddress ShippingAddress { get; set; }


        [ForeignKey("BillingAddress")]
        public int BillingAddressID { get; set; }
        public virtual CustomerAddress BillingAddress { get; set; }


        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
