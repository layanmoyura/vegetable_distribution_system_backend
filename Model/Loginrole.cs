using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class Loginrole
    {
        

        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email_or_phonenumber { get; set; }

        [Required]

        [DataType(DataType.Password)]
        public String Password { get; set; }
        
    }
}
