using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class Courier: IdentityUser
    {
        [Key]
        public int VehiclId { get; set; }

        public string Vehicle_Photo { get; set; }
        public string Vehicle_reg_no { get; set; }

       


    }
}
