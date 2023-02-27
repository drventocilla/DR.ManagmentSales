using Core.GestionDeExcepciones;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace DR.ManagmentSales.API.Helpers
{
    public class StatusCodeBuilder
    {

        public int GetStatusCode(Tipo tipoDeMensaje)
        {


            if (tipoDeMensaje == Tipo.Error)
            {
                return 500;
            }
            if (tipoDeMensaje == Tipo.ErrorValidacion)
            {
                return 401;
            }
            if (tipoDeMensaje == Tipo.ErrorDeRecursoNoEncontrado)
            {
                return 404;
            }
            else if (tipoDeMensaje == Tipo.Ok)
            {
                return 200;
            }
            else if (tipoDeMensaje == Tipo.Guia)
            {
                return 200;
            }
            else
            {
                return 200;
            }


        }


        public ObjectResult ConstruirAPartirDeEstado<T>(EstadoDeEjecucion<T> estadoDeConsulta) where T : class
        {


            APIResponse<T> response = new APIResponse<T>();
            response.Mensajes = estadoDeConsulta.Mensajes;
            response.ValorObjeto = estadoDeConsulta.ValorObjeto;
            response.Codigo = GetStatusCode(estadoDeConsulta.TipoEstado);

            var result = new ObjectResult(response);
            result.StatusCode = GetStatusCode(estadoDeConsulta.TipoEstado);

            return result;

        }

        public ObjectResult ConstruirAPartirDeEstado(EstadoDeEjecucion estadoDeConsulta)
        {


            APIResponse response = new APIResponse();
            response.Mensajes = estadoDeConsulta.Mensajes;
            response.ValorObjeto = null;
            response.Codigo = GetStatusCode(estadoDeConsulta.TipoEstado);

            var result = new ObjectResult(response);
            result.StatusCode = GetStatusCode(estadoDeConsulta.TipoEstado);

            return result;

        }
    }
}
