using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksPizza.Models
{
    public class medewerker
    {


        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string personal_email { get; set; }
        public DateTime birth_date { get; set; }
        public string burger_service_nummer { get; set; }
        
    }
}
