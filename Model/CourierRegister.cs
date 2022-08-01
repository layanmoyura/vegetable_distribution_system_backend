using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class CourierRegister
    {
        public string Vehicle_reg_no { get; set; }
        public string Vehicle_Photo { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password must same")]
        public string ConfirmPassword { get; set; }
    }
}

  