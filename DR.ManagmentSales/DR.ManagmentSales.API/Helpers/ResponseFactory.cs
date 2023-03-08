using Core.GestionDeExcepciones;
using Core;
using Microsoft.AspNetCore.Mvc;
using Core.Extensions;

namespace DR.ManagmentSales.API.Helpers
{
    public class ResponseFactory
    {
        private readonly ErrorResponseFactory _errorResponseFactory;
        private readonly SuccesResponseFactory _succesResponseFactory;
        public ResponseFactory( ErrorResponseFactory errorResponseFactory,
                                SuccesResponseFactory succesResponseFactory)
        {
            _errorResponseFactory  = errorResponseFactory;
            _succesResponseFactory = succesResponseFactory;
            
        }

        public ObjectResult CreateReponse(StateExecution state) 
        {

            if (state.Status)
            {
                var result = new ObjectResult(_succesResponseFactory.CreateResponse(state));
                result.StatusCode = StatusCode.GetStatusCode(state.StateType);
                return result;

            }
            else {


                var result = new ObjectResult(_errorResponseFactory.CreateErrorResponse(state));
                result.StatusCode = StatusCode.GetStatusCode(state.StateType);
                return result;

            }

            

        }

        public ObjectResult CreateReponse<T>(StateExecution<T> state) where T : class 
        {

            if (state.Status)
            {

                var result = new ObjectResult(_succesResponseFactory.CreateResponse<T>(state));
                result.StatusCode = StatusCode.GetStatusCode(state.StateType);
                return result;
            }
            else
            {

                var result = new ObjectResult(_errorResponseFactory.CreateErrorResponse<T>(state));
                result.StatusCode = StatusCode.GetStatusCode(state.StateType);
                return result;

            }


        }
    }
}
