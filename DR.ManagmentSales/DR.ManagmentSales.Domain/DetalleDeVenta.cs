using Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Domain
{
    public class DetalleDeVenta
    {
        [Key]
        public string Id { get; private set; }
        public string ProductoId { get; private set; }
        
        public double Cantidad { get; private set; }
        public string Descripcion { get; private set; }
        public string VentaId { get; private set; }
        [JsonIgnore]
        public Venta Venta { get; private set; }

        public double PrecioUnitario { get; private set; }
        public double PrecioTotal { get => Cantidad* PrecioUnitario; }

        public DetalleDeVenta(string id , string productoId , string productoNombre , double precioUnitario ,  double cantidad , string ventaId)
        {
                
            this.Id = id;
            this.Cantidad= cantidad;
            this.PrecioUnitario = precioUnitario;
            this.Cantidad = cantidad;
            this.Descripcion = productoNombre;
            this.VentaId = ventaId;
            this.ProductoId = productoId;

        }

        public DetalleDeVenta()
        {

        }
        
    }
}
