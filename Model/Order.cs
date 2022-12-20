using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public double required_amount_kg { get; set; }
       
        public string Deadline { get; set;  }

      
        public int progress { get; set; }

       
        public bool Supplied_or_not { get; set; }

       
       

        [Required]
        public int VegetableStocksId { get; set; }

        
      

        [Required]
        public int FarmerId { get; set; }

       
        

        [Required]

        public int CustomerId { get; set; }






    }
}
