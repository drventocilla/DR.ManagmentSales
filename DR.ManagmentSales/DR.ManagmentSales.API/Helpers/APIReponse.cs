using Core.GestionDeExcepciones;

namespace DR.ManagmentSales.API.Helpers
{
    public class APIResponse<T> where T : class
    {
        public List<Mensaje> Mensajes { get; set; }
        public bool Status { get; set; }
        public int Codigo { get; set; }
        public T ValorObjeto { get; set; }

        public APIResponse()
        {

            this.Mensajes = new List<Mensaje>();
            this.ValorObjeto = null;
            this.Status = false;
            this.Codigo = 0;
        }
    }


    public class APIResponse
    {
        public List<Mensaje> Mensajes { get; set; }
        public bool Status { get; set; }
        public int Codigo { get; set; }
        public object ValorObjeto { get; set; }

        public APIResponse()
        {

            this.Mensajes = new List<Mensaje>();
            this.ValorObjeto = null;
            this.Status = false;
            this.Codigo = 0;
        }
    }
}
