using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksPizza.Models
{
    public class ingredienten
    {
        public ulong id { get; set; }
        public int unit { get; set; }
        public string naam_ingr { get; set; }
        public decimal prijs_ingr { get; set; }
        
    }
}
