using Core.Seguridad.Cifrado;
using DR.ManagmentSales.Domain;
using DR.ManagmentSales.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Application
{
    public class InitService
    {
        private readonly ManagmentSalesContext _managmentContext;

        public InitService(ManagmentSalesContext managmentContext)
        {
            _managmentContext = managmentContext;
            InitDatabase();


        }

        private void InitDatabase() {

          

            //if (!_managmentContext.Database.EnsureCreated())
            //{

            //    Usuario admin = new Usuario("1", "ADMINISTRADOR", "ADMIN", Hash_IIT.Encrypt("123456789", "2"), TipoUsuario.Administrador);
            //    Usuario gerente = new Usuario("2", "GERENTE", "GRNT", Hash_IIT.Encrypt("123456789", "2"), TipoUsuario.Gerente);
            //    Usuario uasesor1 = new Usuario("3", "JOSE GOMEZ", "ASSR", Hash_IIT.Encrypt("123456789", "2"), TipoUsuario.Asesor);
            //    Usuario uasesor2 = new Usuario("4", "CARLOS ALVAREZ", "ASSR", Hash_IIT.Encrypt("123456789", "2"), TipoUsuario.Asesor);

            //    _managmentContext.Usuario.Add(admin);
            //    _managmentContext.Usuario.Add(gerente);
            //    _managmentContext.Usuario.Add(uasesor1);
            //    _managmentContext.Usuario.Add(uasesor2);


            //    Asesor asesor1 = new Asesor("4", "JOSE GOMEZ", "", "");
            //    asesor1.AsignarUsuario(uasesor1);
            //    _managmentContext.Asesor.Add(asesor1);

            //    Asesor asesor2 = new Asesor("2", "CARLOS ALVAREZ", "", "");

            //    asesor2.AsignarUsuario(uasesor2);
            //    _managmentContext.Asesor.Add(asesor2);


            //    Producto productoN1 = new Producto("1", "AMD RYZEN 5600", 1500);
            //    Producto productoN2 = new Producto("2", "MEMORIA RAM KINGTON 16GB", 250);
            //    Producto productoN3 = new Producto("3", "SDD NVME KINGTON 2000GB", 350);
            //    Producto productoN4 = new Producto("4", "SDD NVME KINGTON 1000GB", 200);
            //    Producto productoN5 = new Producto("5", "MOTHERBOARD ASUS CHIPSET B550", 400);

            //    _managmentContext.Producto.Add(productoN1);
            //    _managmentContext.Producto.Add(productoN2);
            //    _managmentContext.Producto.Add(productoN3);
            //    _managmentContext.Producto.Add(productoN4);
            //    _managmentContext.Producto.Add(productoN5);


            //    Venta venta1 = new Venta("1", "FACTURA ELECTRONICA", "F001", '1', new DateTime(2022, 10, 1), asesor1);
            //    DetalleDeVenta detalleDeVenta1 = new DetalleDeVenta("1", productoN1, 1500, 10);
            //    DetalleDeVenta detalleDeVenta2 = new DetalleDeVenta("2", productoN2, 250, 10);
            //    DetalleDeVenta detalleDeVenta3 = new DetalleDeVenta("3", productoN3, 350, 10);
            //    DetalleDeVenta detalleDeVenta4 = new DetalleDeVenta("4", productoN4, 200, 10);
            //    DetalleDeVenta detalleDeVenta5 = new DetalleDeVenta("5", productoN5, 400, 10);

            //    venta1.AgregarItem(detalleDeVenta1);
            //    venta1.AgregarItem(detalleDeVenta2);
            //    venta1.AgregarItem(detalleDeVenta3);
            //    venta1.AgregarItem(detalleDeVenta4);
            //    venta1.AgregarItem(detalleDeVenta5);

            //    Venta venta2 = new Venta("2", "FACTURA ELECTRONICA", "F001", '2', new DateTime(2022, 10, 2), asesor2);
            //    DetalleDeVenta detalleDeVenta6 = new DetalleDeVenta("6", productoN2, 250, 10);
            //    DetalleDeVenta detalleDeVenta7 = new DetalleDeVenta("7", productoN3, 350, 10);

            //    venta2.AgregarItem(detalleDeVenta6);
            //    venta2.AgregarItem(detalleDeVenta7);


            //    Venta venta3 = new Venta("5", "BOLETA ELECTRONICA", "B001", '1', new DateTime(2022, 10, 3), asesor2);
            //    DetalleDeVenta detalleDeVenta8 = new DetalleDeVenta("8", productoN4, 200, 10);
            //    DetalleDeVenta detalleDeVenta9 = new DetalleDeVenta("9", productoN4, 200, 10);

            //    venta3.AgregarItem(detalleDeVenta8);
            //    venta3.AgregarItem(detalleDeVenta9);


            //    List<Venta> listaVenta = new List<Venta>();
            //    listaVenta.Add(venta1);
            //    listaVenta.Add(venta2);
            //    listaVenta.Add(venta3);

            //    _managmentContext.Venta.AddRange(listaVenta);

            //    _managmentContext.SaveChanges();

            //}
           
        }

    }
}
