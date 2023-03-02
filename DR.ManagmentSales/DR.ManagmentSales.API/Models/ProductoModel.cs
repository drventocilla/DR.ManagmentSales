namespace DR.ManagmentSales.API.Models
{
    public class ProductoModel
    {

        public string id { get;  set; }
        public string nombre { get;  set; }
        public double precio { get;  set; }

        public ProductoModel()
        {
            this.id = "";
            this.nombre = "";
            this.precio= 0;
        }

    }
}
