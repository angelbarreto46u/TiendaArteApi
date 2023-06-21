using Microsoft.EntityFrameworkCore;
using TiendaArteApi.Models;

namespace TiendaArteApi.Datos
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options)
        {

        }
        public DbSet<Inventario> Productos { get; set; }
        public DbSet<Ventas> RegistroVentas { get; set; }
        public DbSet<Comisiones> RegistroComision { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventario>().HasData(
                new Inventario()
                {
                    ProductCode = "PROD-1",
                    ProductName = "Sticker de pepapig",
                    ProductDescription = "",
                    ProductUnit = 5,
                    ProductPrice = 2500
                });

            modelBuilder.Entity<Ventas>().HasData(
                new Ventas()
                {
                    VentasCode = 1,
                    ClienteName = "Juanito",
                    Solicitud = "Librox3",
                    PrecioVenta = 300,
                    Direccion = "Mi casa",
                    FechaEntrega = DateTime.Now
                });

        }
        
    }
}
