using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class AddressDto
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool ShippingAddress { get; set; }
        public bool BillingAddress { get; set; }
        public ICollection<OrderHeader> SalesShippingOrders { get; set; }
        public ICollection<OrderHeader> SalesBillingOrders { get; set; }
    }
}
