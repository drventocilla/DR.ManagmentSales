using Core.Seguridad.Cifrado;
using DR.ManagmentSales.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;


namespace DR.ManagmentSales.Infrastructure
{
    public class ManagmentSalesContext : DbContext
    {

        public ManagmentSalesContext(DbContextOptions<ManagmentSalesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            base.OnConfiguring(optionsBuilder);
        }
      
        public DbSet<Asesor> Asesor =>  Set<Asesor>();
        public DbSet<Venta> Venta => Set<Venta>();  
        public DbSet<DetalleDeVenta> DetalleDeVenta => Set<DetalleDeVenta>();   
        public DbSet<Producto> Producto => Set<Producto>(); 
        public DbSet<Usuario> Usuario => Set<Usuario>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Usuario admin = new Usuario("1", "ADMINISTRADOR", Hash_IIT.Encrypt("123456789", "2") , "ADMIN",  TipoUsuario.Administrador);
            Usuario gerente = new Usuario("2", "GERENTE", Hash_IIT.Encrypt("123456789", "2"),  "GRNT",  TipoUsuario.Gerente);
            Usuario uasesor1 = new Usuario("3", "JOSE GOMEZ",  Hash_IIT.Encrypt("123456789", "2"), "JOSEGOMEZ", TipoUsuario.Asesor);
            Usuario uasesor2 = new Usuario("4", "CARLOS ALVAREZ", Hash_IIT.Encrypt("123456789", "2"),  "CARLOSALV",  TipoUsuario.Asesor);

            Asesor asesor1 = new Asesor("4", "JOSE GOMEZ", "", "");
            asesor1.AsignarUsuario(uasesor1.Id);
            Asesor asesor2 = new Asesor("2", "CARLOS ALVAREZ", "", "");
            asesor2.AsignarUsuario(uasesor2.Id);

            Producto productoN1 = new Producto("1", "AMD RYZEN 5600", 1500);
            Producto productoN2 = new Producto("2", "MEMORIA RAM KINGTON 16GB", 250);
            Producto productoN3 = new Producto("3", "SDD NVME KINGTON 2000GB", 350);
            Producto productoN4 = new Producto("4", "SDD NVME KINGTON 1000GB", 200);
            Producto productoN5 = new Producto("5", "MOTHERBOARD ASUS CHIPSET B550", 400);

            Venta venta1 = new Venta("1", "FACTURA ELECTRONICA", "F001", '1', new DateTime(2022, 10, 1), asesor1.Id);
            Venta venta2 = new Venta("2", "FACTURA ELECTRONICA", "F001", '2', new DateTime(2022, 10, 2), asesor2.Id);
            Venta venta3 = new Venta("5", "BOLETA ELECTRONICA", "B001", '1', new DateTime(2022, 10, 3), asesor2.Id);

            DetalleDeVenta detalleDeVenta1 = new DetalleDeVenta("1", productoN1.Id, productoN1.Nombre, 1500, 10, venta1.Id);
            DetalleDeVenta detalleDeVenta2 = new DetalleDeVenta("2", productoN2.Id, productoN2.Nombre, 250, 10, venta1.Id);
            DetalleDeVenta detalleDeVenta3 = new DetalleDeVenta("3", productoN3.Id, productoN3.Nombre, 350, 10, venta1.Id);
            DetalleDeVenta detalleDeVenta4 = new DetalleDeVenta("4", productoN4.Id, productoN4.Nombre, 200, 10, venta1.Id);
            DetalleDeVenta detalleDeVenta5 = new DetalleDeVenta("5", productoN5.Id, productoN5.Nombre, 400, 10, venta1.Id);
            DetalleDeVenta detalleDeVenta6 = new DetalleDeVenta("6", productoN2.Id, productoN2.Nombre, 250, 10 , venta2.Id);
            DetalleDeVenta detalleDeVenta7 = new DetalleDeVenta("7", productoN3.Id, productoN3.Nombre, 350, 10, venta2.Id);
            DetalleDeVenta detalleDeVenta8 = new DetalleDeVenta("8", productoN4.Id, productoN4.Nombre, 200, 10, venta3.Id);
            DetalleDeVenta detalleDeVenta9 = new DetalleDeVenta("9", productoN4.Id, productoN4.Nombre, 200, 10, venta3.Id);
         
            modelBuilder.Entity<Asesor>().HasOne<Usuario>().WithMany().HasForeignKey(s => s.UsuarioId);
            modelBuilder.Entity<Venta>().HasOne<Asesor>().WithMany().HasForeignKey(s => s.AsesorId);
            modelBuilder.Entity<DetalleDeVenta>().HasOne<Producto>().WithMany().HasForeignKey(s => s.ProductoId);
            modelBuilder.Entity<DetalleDeVenta>().HasOne(dv=> dv.Venta).WithMany().HasForeignKey(s => s.VentaId);


            modelBuilder.Entity<Usuario>().HasData(admin, gerente, uasesor1, uasesor2);
            modelBuilder.Entity<Asesor>().HasData(asesor1, asesor2);
            modelBuilder.Entity<Producto>().HasData(productoN1, productoN2, productoN3, productoN4, productoN5);
            modelBuilder.Entity<Venta>().HasData(venta1, venta2, venta3);
            modelBuilder.Entity<DetalleDeVenta>().HasData(detalleDeVenta1,
                                                 detalleDeVenta2,
                                                 detalleDeVenta3,
                                                 detalleDeVenta4,
                                                 detalleDeVenta5,
                                                 detalleDeVenta6,
                                                 detalleDeVenta7,
                                                 detalleDeVenta8,
                                                 detalleDeVenta9);

            base.OnModelCreating(modelBuilder);

           

        }

    }
}
