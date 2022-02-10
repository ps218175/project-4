using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksPizza.Models
{
    public class pizza : ingredienten
    {
        public ulong id { get; set; }

        public string naam { get; set; }
        public string beschrijving { get; set; }
        public decimal prijs { get; set; }
    }
}
