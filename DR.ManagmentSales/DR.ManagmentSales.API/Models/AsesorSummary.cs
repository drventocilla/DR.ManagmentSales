using DR.ManagmentSales.Domain;

namespace DR.ManagmentSales.API.Models
{
    public class AsesorSummary
    {

        public string Nombre { get; set; }
        public double Total { get; set; }


        public AsesorSummary() {

            this.Nombre = "";
            this.Total = 0;
        }
    }
}
