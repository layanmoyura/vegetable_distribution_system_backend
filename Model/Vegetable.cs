using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class Vegetable
    {
        [Key]
        public int VegetablesId { get; set; }
        [Required]
        public string Vegtable_image { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public double Max_control_price_country { get; set; }
        [Required]
        
        public int AdminId { get; set; }

        [Required]

        public  string Last_Updated_Time { get; set; }





    }
}
