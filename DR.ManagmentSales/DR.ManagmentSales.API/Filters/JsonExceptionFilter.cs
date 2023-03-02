using Core.GestionDeExcepciones;
using Core;
using Microsoft.AspNetCore.Mvc.Filters;
using DR.ManagmentSales.API.Helpers;

namespace TarjetaPresentacion.API.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly StatusCodeBuilder _statusCodeBuilder;
        public JsonExceptionFilter(StatusCodeBuilder statusCodeBuilder)
        {
            this._statusCodeBuilder = statusCodeBuilder;
        }
        public void OnException(ExceptionContext eContext)
        {


            if (eContext.Exception is BusinessLogicException)
            {

                BusinessLogicException excepcion = (BusinessLogicException)eContext.Exception;

                StateExecution state = new StateExecution();
                state.Status = false;
                state.MessageState = excepcion.mensajeDeValidacion;
                var result = _statusCodeBuilder.ConstruirAPartirDeEstado(state);
                eContext.Result = result;

            }
            else if (eContext.Exception is ArgumentException)
            {
                StateExecution state = new StateExecution();
                state.Status = false;
                state.StateType = State.ErrorValidation;
              
                Message mensaje = new Message();
                mensaje.Description = "Validación de entidad.";
                mensaje.Detail = $"{eContext.Exception.Message}-{eContext.Exception.InnerException}";
                mensaje.Action = "Revise los valores ingresados.";

                state.MessageState = mensaje;

                var result = _statusCodeBuilder.ConstruirAPartirDeEstado(state);

                eContext.Result = result;

            }
            else
            {


                StateExecution state = new StateExecution();
                state.Status = false;
                state.StateType = State.Error;
                Message mensaje = new Message();
                mensaje.Description = "Error Interno de servidor";
                mensaje.Detail = $"{eContext.Exception.Message}-{eContext.Exception.InnerException}";
                mensaje.Action = "Comuníquese con soporte técnico.";

                state.MessageState = mensaje;

                var result = _statusCodeBuilder.ConstruirAPartirDeEstado(state);

                eContext.Result = result;

            }

        }
    }
}
