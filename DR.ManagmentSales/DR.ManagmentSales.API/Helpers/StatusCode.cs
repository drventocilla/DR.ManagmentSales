using Core;

namespace DR.ManagmentSales.API.Helpers
{
    public class StatusCode
    {
        public static int  GetStatusCode(State type)
        {


            if (type == State.ErrorValidation)
            {
                return 400;
            }
            if (type == State.ErrorNotContent)
            {
                return 404;
            }
            else if (type == State.Ok)
            {
                return 200;
            }
            else if (type == State.OkNotContent)
            {
                return 203;
            }
            else
            {
                return 200;
            }


        }
    }
}
