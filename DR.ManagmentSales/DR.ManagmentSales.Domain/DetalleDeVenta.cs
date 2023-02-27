using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Domain
{
    public class DetalleDeVenta
    {
        [Key]
        public string Id { get; set; }
        public Producto Producto { get; set; }
        public double Cantidad { get; set; }
        public string Descripcion { get; set; }

        public DetalleDeVenta()
        {

        }
        
    }
}
