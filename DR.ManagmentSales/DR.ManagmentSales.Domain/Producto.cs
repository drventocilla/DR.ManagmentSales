using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Domain
{
    public class Producto
    {
        [Key]
        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public double Precio { get; private set; }

        public Producto(string id , string nombre , double precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }

        public Producto(string id)
        {
            Id = id;
          
        }

        public Producto()
        {

        }

    }
}
