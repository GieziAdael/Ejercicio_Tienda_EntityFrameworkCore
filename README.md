# Tienda_EFC

Proyecto de práctica con **Entity Framework Core** usando .NET 8.0.  
Aplicación de consola que implementa un CRUD básico con entidades relacionadas (`Tienda`, `Producto`, `Servicio`, `Suscripcion`).

## 🚀 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- [SQLite](https://www.sqlite.org/download.html) (opcional, si deseas inspeccionar la base de datos creada)

## 📂 Estructura del proyecto

- `Data/` → Contiene las entidades y el `DbContext` (`Context.cs`).  
- `Services/` → Servicios para CRUD y lógica de negocio (`SimpleCrud`, `LabelTienda`).  
- `Migrations/` → Migraciones generadas con EF Core.  
- `Program.cs` → Punto de entrada de la aplicación.  

## ⚙️ Configuración inicial

Migracion DB:
dotnet ef migrations add PrimeraCreacion
dotnet ef database update
