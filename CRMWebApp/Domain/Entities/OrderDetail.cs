using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderLineID { get; set; }


        [Required]
        public string OrderLineNumber { get; set; }

        public int Quantity { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Grandtotal { get; set; }


        [ForeignKey("OrderHeader")]
        public int OrderHeaderID { get; set; }

        public virtual OrderHeader OrderHeader { get; set; }


        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }


        [ForeignKey("Tax")]
        public int TaxID { get; set; }
        public virtual Tax Tax { get; set; }
    }
}
