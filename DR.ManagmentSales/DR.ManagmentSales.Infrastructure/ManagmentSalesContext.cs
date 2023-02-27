using DR.ManagmentSales.Domain;
using Microsoft.EntityFrameworkCore;


namespace DR.ManagmentSales.Infrastructure
{
    public class ManagmentSalesContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseInMemoryDatabase(databaseName : "SalesDB");
        }
      
        public DbSet<Asesor> Asesor { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<DetalleDeVenta> DetalleDeVenta { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Asesor> Usuario { get; set; }

    }
}
