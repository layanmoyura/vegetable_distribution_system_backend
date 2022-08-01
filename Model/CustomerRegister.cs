using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class CustomerRegister
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { set; get; }
        [Required]
        public string Living_City { get; set; }
        [Required]
        public string NIC_No { get; set; }
        public string Profile_Photo { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password must same")]
        public string ConfirmPassword { get; set; }
    }
}
