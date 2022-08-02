using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class VegetableStock
    {
        [Key]
        public int VegetableStocksId { get; set; }

        [Required]

        public double Amount { get; set; }



        [Required]
        public string Updated_Time { get; set; }


        [Required]
        public double Farmers_price_per_kg { get; set; }


        [Required]
        
        public string Discription { get; set; }

        [Required]

        public string Manu_date { get; set; }


        [Required]

        public int VegetablesId { get; set; }


        [Required]
        public int FarmerId { get; set; }

        [Required]
        public string Stock_image { get; set; }


        

    }
}
