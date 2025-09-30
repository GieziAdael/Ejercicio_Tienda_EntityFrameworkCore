using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_EFC.Data
{
    public class Tienda
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Type { get; set; }

        public Tienda(string name, decimal price, int type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }
    }
}
