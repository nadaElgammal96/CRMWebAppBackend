using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Index(nameof(Customer.Code), IsUnique = true)]
    public class Customer
    {
        public int CustomerID { get; set; }


        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }

        [Required]
        public string Code { get; set; }


        [Required]
        public string EmailAddress { get; set; }


        [Required]
        public string PrimaryPhoneNumber { get; set; }

        public string OtherPhoneNumber { get; set; }

        public bool Active { get; set; } = true;

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }


    }
}
