using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_EFC.Data
{
    public class Suscripcion
    {
        public int Id { get; set; }
        public int DurationMonths { get; set; }

        public int FKId { get; set; }

        public Suscripcion(int durationMonths, int fKId)
        {
            this.DurationMonths = durationMonths;
            this.FKId = fKId;
        }
    }
}
