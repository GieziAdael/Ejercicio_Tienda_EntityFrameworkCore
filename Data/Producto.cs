using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_EFC.Data
{
    public class Producto
    {
        public int Id { get; set; }
        public DateTime Expiration { get; set; }

        public int FKId { get; set; }

        public Producto(DateTime expiration, int fKId)
        {
            this.Expiration = expiration;
            this.FKId = fKId;
        }
    }
}
