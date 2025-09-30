
using System;
using System.Security.Cryptography;
using Tienda_EFC.Data;
using Tienda_EFC.Services;

class Program
{
    public static void Main(string[] args)
    {
        

        bool appActivo = true;
        char key = 'I';
        int idKey = 0;
        int n;
        while (appActivo)
        {
            
            Interfaz(ref key, ref appActivo, ref idKey);
        }
    }

    static void Interfaz(ref char key, ref bool appActivo, ref int idKey)
    {
        using var appContext = new Context();
        var crud = new SimpleCrud(appContext);
        switch (key)
        {
            case 'I':
                Console.Clear();
                Console.WriteLine($"==========\nTIENDA\n==========\nA) Agregar\n==========");
                var tiendita = crud.GetTiendas();
                foreach (var t in tiendita)
                {
                    Console.WriteLine($"{t.Id}) {t.Name}: {t.Price:C} MXN");
                }
                Console.WriteLine($"S) Salir\n[Respuesta] ");
                key = Convert.ToChar(Console.ReadLine() ?? "I");
                break;
            case 'A':
                Console.Clear();
                Console.WriteLine("Selecciona el tipo:\n1)Producto\n2) Suscripcion\n3) Servicio\n[Respuesta] ");
                int selection = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nombre: ");
                var nombre = Console.ReadLine();
                Console.WriteLine("Precio");
                var price = decimal.Parse(Console.ReadLine() ?? "");
                if(selection == 1)
                {
                    Console.WriteLine("Caducidad yyyy/mm/dd: ");
                    var date = Console.ReadLine();
                    crud.AddTienda(nombre, price, selection, date);
                }
                if (selection == 2)
                {
                    Console.WriteLine("Duracion (en meses): ");
                    var durationM = Console.ReadLine();
                    crud.AddTienda(nombre, price, selection, durationM);
                }
                if (selection == 3)
                {
                    Console.WriteLine("Duracion (en dias): ");
                    var durationD = Console.ReadLine();
                    crud.AddTienda(nombre, price, selection, durationD);
                }
                key = 'I';
                break;
            case 'N':
                Console.Clear();
                Console.WriteLine("Escribe el nuevo nombre: ");
                string name = Console.ReadLine()??"N/A";
                crud.ActualizarTiendita(idKey, 'N',name, 0);
                key = 'I';
                break;
            case 'P':
                Console.Clear();
                Console.WriteLine("Escribe el nuevo precio: ");
                decimal newprice = Convert.ToDecimal(Console.ReadLine());
                crud.ActualizarTiendita(idKey, 'P', "", newprice);
                key = 'I';
                break;
            case 'E':
                Console.Clear();
                Console.WriteLine("¿Estas seguro que quieres eliminar este objeto?\n[S\\n]");
                char desis = Convert.ToChar(Console.ReadLine() ?? "n");
                if (desis == 'S')
                {
                    crud.EliminarTiendita(idKey);
                    key = 'I';
                    break;
                }

                key = 'I';
                break;
            case 'S':
                Console.Clear();
                appActivo = false;
                break;
            default:
                Console.Clear();
                if (!char.IsDigit(key))
                {
                    Console.WriteLine("No se reconocio comando!");
                    Thread.Sleep(2500);
                    key = 'I';
                    break;
                }
                idKey = (int)char.GetNumericValue(key);
                bool existe = crud.ExisteId(idKey);
                if (existe)
                {
                    Detalle(ref idKey, ref crud, ref key);
                    break;
                }
                else
                {
                    Console.WriteLine("No se reconocio Id!");
                    Thread.Sleep(2500);
                    key = 'I';
                    break;
                }
                key = 'I';
                break;
        }

    }

    static void Detalle(ref int idKey, ref SimpleCrud crud, ref char key)
    {

        var tiendaGetDetalle = crud.ViewDetalleTienda(idKey);
        int tipo = 0;
        foreach (var t in tiendaGetDetalle)
        {
            tipo = t.Id;
        }
        if (tipo == 1)
        {
            foreach (var tD in tiendaGetDetalle)
            {
                Console.WriteLine($"==========\nPRODUCTO\n==========" +
                $"\nNombre: {tD.Name}\nPrecio: {tD.Price}");
            }
            var ProdGetDetalle = crud.ViewDetalleProducto(idKey);
            foreach(var p in ProdGetDetalle)
            {
                Console.WriteLine($"Caducidad: {p.Expiration}");
            }
        }
        if (tipo == 2)
        {
            foreach (var tD in tiendaGetDetalle)
            {
                Console.WriteLine($"==========\nSUSCRIPCION\n==========" +
                $"\nNombre: {tD.Name}\nPrecio: {tD.Price}");
            }
            var SuscGetDetalle = crud.ViewDetalleSuscripcion(idKey);
            foreach (var s in SuscGetDetalle)
            {
                Console.WriteLine($"Suscripcion: {s.DurationMonths} meses.");
            }

        }
        if (tipo == 3)
        {
            foreach (var tD in tiendaGetDetalle)
            {
                Console.WriteLine($"==========\nSERVICIO\n==========" +
                $"\nNombre: {tD.Name}\nPrecio: {tD.Price}");
            }
            var ServGetDetalle = crud.ViewDetalleServicio(idKey);
            foreach (var v in ServGetDetalle)
            {
                Console.WriteLine($"Duracion: {v.DurationDays} dias.");
            }
        }

        Console.WriteLine("\nN) Editar Nombre\nP) Editar Precio\nE) Eliminar Objecto\nI) Cancelar\n[Respuesta] ");
        key = Convert.ToChar(Console.ReadLine() ?? "I");
    }
}