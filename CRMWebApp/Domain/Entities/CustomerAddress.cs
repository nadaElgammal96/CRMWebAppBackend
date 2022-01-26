using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CustomerAddress
    {
        public int ID { get; set; }

       
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        
        [Required]
        public string AddressLine1 { get; set; }
        
        [Required]
        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }
        
        [Required]
        public string PostalCode{ get; set; }
        
        [Required]
        public string Country{ get; set; }
        
        [Required]
        public bool ShippingAddress{ get; set; }
        
        [Required]
        public bool BillingAddress{ get; set; }

        
        [InverseProperty("ShippingAddress")]
        public virtual ICollection<OrderHeader> SalesShippingOrders { get; set; }

        
        [InverseProperty("BillingAddress")]
        public virtual ICollection<OrderHeader> SalesBillingOrders { get; set; }

    }
}
