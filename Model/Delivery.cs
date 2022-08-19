using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class Delivery
    {   
        [Key]
        public int DeliveryId { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public bool delivered_or_not { get; set; }
       

        public int AdminId { get; set; }
       

        public int  CourierVehiclId { get; set; }
     
        public int OrderId { get; set; }


    }
}
