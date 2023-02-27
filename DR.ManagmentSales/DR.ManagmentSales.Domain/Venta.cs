using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Domain
{
    public enum Estado { Valido, Anulado }
    public class Venta : Auditoria
    {
        [Key]
        public string Id { get; set; }
        public string TipoDeDocumento { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public Asesor Asesor { get; set; }
        public IEnumerable<DetalleDeVenta> Detalles { get; }
        public Estado EstadoActual { get; set;  }
       
        public Venta()
        {


        }



    }
  

}
