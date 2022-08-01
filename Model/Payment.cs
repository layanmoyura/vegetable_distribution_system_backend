using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string Bank { get; set; }
        public string Farmers_acc_no { get; set; }
        public string Card_no { get; set; }
        public string Card_type { get; set; }
        public DateTime Date { get; set; }


        public Order Order { get; set; }

       
        public Customer Customer { get; set; }

       
        public Farmer Farmer { get; set; }

        

    }
}
