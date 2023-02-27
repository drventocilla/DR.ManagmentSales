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
        public void OnException(ExceptionContext context)
        {


            if (context.Exception is BusinessLogicException)
            {

                BusinessLogicException excepcion = (BusinessLogicException)context.Exception;

                EstadoDeEjecucion estadoDeEjecucion = new EstadoDeEjecucion();
                estadoDeEjecucion.Status = false;
                estadoDeEjecucion.AgregarMensaje(excepcion.mensajeDeValidacion);

                var result = _statusCodeBuilder.ConstruirAPartirDeEstado(estadoDeEjecucion);

                context.Result = result;

            }
            else
            {


                EstadoDeEjecucion estadoDeEjecucion = new EstadoDeEjecucion();
                estadoDeEjecucion.Status = false;
                estadoDeEjecucion.TipoEstado = Tipo.Error;
                Mensaje mensaje = new Mensaje();
                mensaje.MensajeGenerado = "Error Interno de Servidor";
                mensaje.DetalleDelMensaje = $"{context.Exception.Message}-{context.Exception.InnerException}";
                mensaje.AccionARealizar = "Comuníquese con soporte técnico.";
               
                estadoDeEjecucion.AgregarMensaje(mensaje);

                var result = _statusCodeBuilder.ConstruirAPartirDeEstado(estadoDeEjecucion);

                context.Result = result;

            }

        }
    }
}
