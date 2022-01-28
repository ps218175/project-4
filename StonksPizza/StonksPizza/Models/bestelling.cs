using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksPizza.Models
{
   public class bestelling : statussen
    {
        public int id { get; set; }
        public int KlantId { get; set; }
        public int Bestel_Id { get; set; }
        public int Status_Id { get; set; }
        public string last_name { get; set; }
    }
}
