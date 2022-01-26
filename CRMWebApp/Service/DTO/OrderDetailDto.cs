using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class OrderDetailDto
    {
        public int OrderLineID { get; set; }
        
        public string OrderLineNumber { get; set; }

        public int Quantity { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Grandtotal { get; set; }


        public int OrderHeaderID { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }

        public int TaxID { get; set; }
        public Tax Tax { get; set; }
    }
}
