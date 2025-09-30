using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda_EFC.Data;

namespace Tienda_EFC.Services
{
    public class LabelTienda : Tienda
    {
        public LabelTienda(string name, decimal price, int type):base(name, price, type)
        {
            
        }
    }
}
