using MyWalletApp.WebAPI.Data.Initializer;
using MyWalletApp.WebAPI.Models;
using System.Data.Entity;

namespace MyWalletApp.WebAPI.Data.Contexts
{
    public class MyWalletContext : DbContext
    {
        public MyWalletContext() : base("MyWalletDBAzure")
        {
        }

        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Fuente> Fuentes { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
    }
}