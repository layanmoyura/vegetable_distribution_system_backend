using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class Farmer: IdentityUser
    {

        [Key]
        public int FarmerId { get; set; }
        public string Name { get; set; }
        public string Living_city { get; set; }
        public string Bank { get; set; }
        public string Account_no { get; set; }
        public string NIC_No { get; set; }
        public string Profile_Photo { get; set; }

       
    }
}
