using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        /*
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        */
        public int UserID { get; set; }


        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }

       
        [Required]
        public string Username { get; set; }


        [Required]
        public string EmailAddress { get; set; }

        
        [Required]
        public string Password { get; set; }


        [Required]
        public string PrimaryPhoneNumber { get; set; }

        public string OtherPhoneNumber { get; set; }

        [Required]
        public bool Active { get; set; } = true;


    }
}
