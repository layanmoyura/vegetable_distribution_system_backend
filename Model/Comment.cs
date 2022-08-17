using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Model
{
    public class Comment
    {
      
        public int CommentID { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}
