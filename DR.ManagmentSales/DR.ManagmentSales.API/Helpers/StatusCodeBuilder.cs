using Core.GestionDeExcepciones;
using Core;
using Microsoft.AspNetCore.Mvc;
using Core.Extensions;

namespace DR.ManagmentSales.API.Helpers
{
    public class StatusCodeBuilder
    {

        public int GetStatusCode(State tipoDeMensaje)
        {


            if (tipoDeMensaje == State.Error)
            {
                return 500;
            }
            if (tipoDeMensaje == State.ErrorValidation)
            {
                return 401;
            }
            if (tipoDeMensaje == State.ErrorNotFound)
            {
                return 404;
            }
            else if (tipoDeMensaje == State.Ok)
            {
                return 200;
            }
            else if (tipoDeMensaje == State.Info)
            {
                return 200;
            }
            else
            {
                return 200;
            }


        }


        public ObjectResult ConstruirAPartirDeEstado<T>(StateExecution<T> state) where T : class
        {


            APIResponse<T> response = new APIResponse<T>();
            response.Message = state.MessageState.Copy();
            response.Data = state.Data.Copy();
            response.Code = GetStatusCode(state.StateType);

            var result = new ObjectResult(response);
            result.StatusCode = GetStatusCode(state.StateType);

            return result;

        }

        public ObjectResult ConstruirAPartirDeEstado(StateExecution state)
        {

            APIResponse response = new APIResponse();
            response.Message = state.MessageState.Copy();
            response.Code = GetStatusCode(state.StateType);
            
            var result = new ObjectResult(response);
            result.StatusCode = GetStatusCode(state.StateType);

            return result;


        }
    }
}
