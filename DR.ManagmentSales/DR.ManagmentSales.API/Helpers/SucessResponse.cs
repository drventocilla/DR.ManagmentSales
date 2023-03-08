namespace DR.ManagmentSales.API.Helpers
{
    public  class SucessResponse
    {


        public int Status { get; set; }
        
        public string Title { get; set; }
        public string Detail { get; set; }
        
        public SucessResponse(string title, string detail , int status)
        {
            Status = status;
            Title = title;
            Detail = detail;
        }

    }


    public class SucessResponse<T> where T : class
    {
        public int Status { get; set; }
        
        public string Title { get; set; }
        public string Detail { get; set; }
        
        public T Data { get; set; }

        public SucessResponse(string title, string detail , int status, T data = null)
        {
            Title = title;
            Detail = detail;
            Data = data;
            Status = status;
        }

    }
}
