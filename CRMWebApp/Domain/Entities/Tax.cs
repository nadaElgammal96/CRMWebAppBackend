using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tax
    {
        public int TaxID { get; set; }

        [Required]
        public string Name { get; set; }
        public double rate { get; set; }

        [InverseProperty("Tax")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [InverseProperty("Tax")]
        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}
