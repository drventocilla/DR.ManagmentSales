using System.Diagnostics;
using System.Net.Http;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace DR.ManagmentSales.API.Helpers
{
    public class ErrorResponseFactory
    {
        private readonly ApiBehaviorOptions _options;
        private readonly Action<ProblemDetailsContext>? _configure;
        private readonly HttpContext _httpContext;

        public ErrorResponseFactory(

             IOptions<ApiBehaviorOptions> options,
             IHttpContextAccessor httpContextAccessor,
             IOptions<ProblemDetailsOptions>? problemDetailsOptions = null)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _configure = problemDetailsOptions?.Value?.CustomizeProblemDetails;
            _httpContext = httpContextAccessor.HttpContext;
            
        }

              

       public ValidationProblemDetails CreateErrorResponse(StateExecution stateExecution)
        {
            var errorDictionary = new Dictionary<string, string[]>();
            errorDictionary.Add( "details" , stateExecution.Details.ToArray());

            var problemDetails = new ValidationProblemDetails(errorDictionary)
            {
                Status = StatusCode.GetStatusCode(stateExecution.StateType),
                Title = stateExecution.MessageState.Description,
                Detail = stateExecution.MessageState.Detail,
               
            };


            ApplyProblemDetailsDefaults(_httpContext, problemDetails, StatusCode.GetStatusCode(stateExecution.StateType));

            return problemDetails;
        }


        public ValidationProblemDetails CreateErrorResponse<T>(StateExecution<T> stateExecution) where T : class
        {
            var errorDictionary = new Dictionary<string, string[]>();
            errorDictionary.Add("details", stateExecution.Details.ToArray());

            var problemDetails = new ValidationProblemDetails(errorDictionary)
            {
                Status = StatusCode.GetStatusCode(stateExecution.StateType),
                Title = stateExecution.MessageState.Description,
                Detail = stateExecution.MessageState.Detail,

            };


            ApplyProblemDetailsDefaults(_httpContext, problemDetails, StatusCode.GetStatusCode(stateExecution.StateType));

            return problemDetails;
        }


        public  ProblemDetails CreateProblemDetails(
                HttpContext httpContext,
                int? statusCode = null,
                string? title = null,
                string? type = null,
                string? detail = null,
                string? instance = null)
               
        {
                        statusCode ??= 500;

                        var problemDetails = new ProblemDetails
                        {
                            Status = statusCode,
                            Title = title,
                            Type = type,
                            Detail = detail,
                            Instance = instance,
                        };

                        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

                        return problemDetails;
        }


        private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
        {
            problemDetails.Status ??= statusCode;

            if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Link;
            }

            var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
            if (traceId != null)
            {
                problemDetails.Extensions["traceId"] = traceId;
            }

            _configure?.Invoke(new() { HttpContext = httpContext!, ProblemDetails = problemDetails });
        }

    }
}
