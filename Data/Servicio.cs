using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_EFC.Data
{
    public class Servicio
    {
        public int Id { get; set; }
        public int DurationDays { get; set; }

        public int FKId { get; set; }

        public Servicio(int durationDays, int fKId)
        {
            this.DurationDays = durationDays;
            this.FKId = fKId;
        }
    }
}
