using DR.ManagmentSales.Domain;

namespace DR.ManagmentSales.API.Models
{
    public class ReportVenta
    {


        public List<Venta> Detalle { get; set; }
        public List<AsesorSummary> Grupos { get; set; }

        public ReportVenta()
        {
            Detalle = new List<Venta>();
            Grupos = new List<AsesorSummary>();

        }

    }
}
