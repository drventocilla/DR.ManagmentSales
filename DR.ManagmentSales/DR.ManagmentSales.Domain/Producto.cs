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
        public string Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto()
        {
                
        }
    }
}
