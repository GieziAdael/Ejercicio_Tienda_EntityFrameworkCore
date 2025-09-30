using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_EFC.Data
{
    public class Context : DbContext
    {
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Suscripcion> Suscripciones { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        //Configuraciones
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Conexion DB
            optionsBuilder.UseSqlServer
            //Modificar 'TUSERVER'
            (@"Server=TUSERVER;Database=TiendaSimpleDB;Trusted_Connection=True;TrustServerCertificate=True;");

            //Despues abrir terminal (sin ejecutar) y escribir
            /*
            dotnet ef migrations add PrimeraCreacion
            dotnet ef database update
             */
        }
    }
}
