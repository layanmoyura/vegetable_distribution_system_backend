using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
namespace Online_platform_for_vegetables.Model
{
    public class Role: IdentityUser
    {
        [Key]
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { set; get; }
        public string Living_City { get; set; }
        public string NIC_No { get; set; }
        public string Profile_Photo { get; set; }
        public string Rolename { get; set; }
    }
}
