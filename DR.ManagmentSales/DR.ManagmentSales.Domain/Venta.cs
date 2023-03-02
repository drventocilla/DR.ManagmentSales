using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Domain
{
    public enum Estado { Valido, Anulado }
    public class Venta 
    {

        [Key]
        public string Id { get; private set; }
        public string TipoDeDocumento { get; private set; }
        public string Serie { get; private set; }
        public int Numero { get; private set; }
        public string AsesorId { get; private set; }
        public List<DetalleDeVenta> Detalles { get; private set; }
        public Estado EstadoActual { get; private set;  }
        public double Total { get; private set; }
        public DateTime FechaCreacion { get; set; }

        public Venta(string id , 
                     string tipoDeDocumento , 
                     string serie , 
                     int numero,
                     DateTime fechaCreacion , string asesorId
                   )
        {
            Id= id;
            TipoDeDocumento = tipoDeDocumento;
            Serie = serie;
            Numero = numero;
            Numero= numero;
            Detalles = new  List<DetalleDeVenta>();
            EstadoActual = Estado.Valido;
            FechaCreacion = fechaCreacion;
            AsesorId = asesorId;



        }
        public Venta()
        {

        }

        public void AgregarItem(DetalleDeVenta detalleDeVenta) {
            
            
            Detalles.Add(detalleDeVenta);
            CalculateTotal();


        }

        private void CalculateTotal() {

            this.Total = 0;
            this.Detalles.ForEach(x => { Total += x.PrecioTotal; }); 


        }
    }
  

}
