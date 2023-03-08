using Core.GestionDeExcepciones;
using Core;
using Microsoft.AspNetCore.Mvc.Filters;
using DR.ManagmentSales.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace TarjetaPresentacion.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ErrorResponseFactory _errorResponseFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ExceptionFilter(ErrorResponseFactory errorResponseFactory, IHttpContextAccessor httpContextAccessor)
        {
            this._errorResponseFactory = errorResponseFactory;
            this._httpContextAccessor = httpContextAccessor;
        }
        public void OnException(ExceptionContext eContext)
        {
            ProblemDetails problem = _errorResponseFactory
                                        .CreateProblemDetails(this._httpContextAccessor.HttpContext, 500, "Error en realizar la operación." );

            var result = new ObjectResult(problem);



        }
    }
}
