namespace DR.ManagmentSales.API.Models
{
    public class AsesorModel
    {
        public string id { get;  set; }
        public string nombres { get;  set; }
        public string celular { get;  set; }
        public string email { get;  set; }

        public AsesorModel()
        {
            this.id = "";
            this.nombres = "";
            this.celular = "";
            this.email = "";
    }
    }
}
