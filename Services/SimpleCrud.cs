using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda_EFC.Data;

namespace Tienda_EFC.Services
{
    public class SimpleCrud
    {
        private readonly Context _context;

        public SimpleCrud(Context context)
        {
            this._context = context;
        }

        //MOSTRAR TIENDA
        public List<Tienda> GetTiendas()
        {
            return _context.Tiendas.ToList();
        }

        //AGREGAR
        public string AddTienda(string name, decimal price, int type, string atributo)
        {
            var tienda = new Tienda(name, price, type);
            _context.Tiendas.Add(tienda);
            _context.SaveChanges();


            int id = tienda.Id;
            if (type == 1)
            {
                var date = Convert.ToDateTime(atributo);
                var produc = new Producto(date, id);

                
                _context.Productos.Add(produc);
                _context.SaveChanges();


                return "PRODUCTO GUARDADO!";
            }
            if (type ==2)
            {
                var durationMonths = Convert.ToInt32(atributo);

                var susc = new Suscripcion(durationMonths, id);
                _context.Suscripciones.Add(susc);
                _context.SaveChanges();
                return "SUSCRIPCION GUARDADO!";
            }

            var durationDays = Convert.ToInt32(atributo);

            var serv = new Servicio(durationDays, id);
            _context.Servicios.Add(serv);
            _context.SaveChanges();
            return "SERVICIO GUARDADO!";
        }

        //Existe ID?
        public bool ExisteId(int Id)
        {
            return _context.Tiendas.Any(t => t.Id == Id);
        }

        //Ver a DETALLE
        public List<Tienda> ViewDetalleTienda(int Id)
        {
            return _context.Tiendas.Where(p => p.Id == Id).ToList();
        }
        public List<Producto> ViewDetalleProducto(int Id)
        {
            return _context.Productos.Where(p=>p.Id == Id).ToList();
        }
        public List<Suscripcion> ViewDetalleSuscripcion(int Id)
        {
            return _context.Suscripciones.Where(p => p.FKId == Id).ToList();
        }
        public List<Servicio> ViewDetalleServicio(int Id)
        {
            return _context.Servicios.Where(p => p.FKId == Id).ToList();
        }

        //Editar
        public void ActualizarTiendita(int id, char caso, string name, decimal price)
        {
            Console.Clear();
            var tienda = _context.Tiendas.FirstOrDefault(t => t.Id == id);
            if (caso == 'N' && tienda != null)
            {
                
                if(tienda != null)
                {
                    tienda.Name = name;
                    _context.SaveChanges();
                    Console.WriteLine("Cambios Realizados!");
                }
            }
            if (caso == 'P' && tienda != null)
            {
                tienda.Price = price;
                _context.SaveChanges();
                Console.WriteLine("Cambios Realizados!");
            }
            Thread.Sleep(2500);
        }

        //Eliminar 
        public void EliminarTiendita(int id)
        {
            var objTien = _context.Tiendas.FirstOrDefault(f => f.Id == id);
            if (objTien != null)
            {
                var tipo = objTien.Type;
                if(tipo == 1)
                {
                    var objProd = _context.Productos.Where(f => f.FKId == id).ToList();
                    _context.Productos.RemoveRange(objProd);
                }
                if (tipo == 2)
                {
                    var objSusc = _context.Suscripciones.Where(f => f.FKId == id).ToList();
                    _context.Suscripciones.RemoveRange(objSusc);
                }
                if (tipo == 3)
                {
                    var objServ = _context.Servicios.Where(f => f.FKId == id).ToList();
                    _context.Servicios.RemoveRange(objServ);
                }
                _context.Tiendas.Remove(objTien);
                _context.SaveChanges();
            }
        }
    }
}
