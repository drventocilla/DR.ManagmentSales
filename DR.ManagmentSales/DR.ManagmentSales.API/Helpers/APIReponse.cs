using Core.GestionDeExcepciones;

namespace DR.ManagmentSales.API.Helpers
{


    public class APIResponse
    {
        public List<string> Errors { get; set; }
        public bool Status { get; set; }
        public Message Message { get; set; }
        public int Code { get; set; }
        public object Data { get; set; }
        public APIResponse()
        {

            this.Errors = new List<string>();
            this.Data = null;
            this.Status = false;
            this.Code = 0;
            this.Message = new Message();
        }
    }


    public class APIResponse<T> where T : class
    {
        public List<string> Errors { get; set; }
        public Message Message { get; set; }
        public bool Status { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }

        public APIResponse()
        {

            this.Errors = new List<string>();
            this.Data = default;
            this.Status = false;
            this.Message = new Message();
            this.Code = 0;
        }
    }

}
