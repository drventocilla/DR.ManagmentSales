using Core;
using Core.Extensions;
using Core.Operaciones;
using DR.ManagmentSales.API.Helpers;
using DR.ManagmentSales.API.Models;
using DR.ManagmentSales.Application;
using DR.ManagmentSales.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DR.ManagmentSales.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        private readonly VentaService _ventaService;
        private readonly ResponseFactory _responseFactory;


        public VentaController(VentaService ventaService,
                               ResponseFactory responseFactory)
        {
            _ventaService = ventaService;
            _responseFactory = responseFactory;
            
        }

        [HttpGet("Report")]
        [ProducesResponseType(typeof(SucessResponse<ReportVenta>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Report( string fechaInicial , string fechaFinal ,   CancellationToken token) {

            var _fechaInicial = fechaInicial.Split('-');
            var _fechaFinal = fechaFinal.Split('-');

            DateTime dFechaInicial = new DateTime(Numero.ConvertirVacioAInt(_fechaInicial[2]), Numero.ConvertirVacioAInt(_fechaInicial[1]), Numero.ConvertirVacioAInt(_fechaInicial[0]));
            DateTime dFechaFinal = new DateTime(Numero.ConvertirVacioAInt(_fechaFinal[2]), Numero.ConvertirVacioAInt(_fechaFinal[1]), Numero.ConvertirVacioAInt(_fechaFinal[0]));

                       

            StateExecution <IEnumerable<Venta>> state = await _ventaService.ReportAsync(dFechaInicial , dFechaFinal , token);

            List<Venta> ventas =  state.Data.ToList();

            List<AsesorSummary> summary = ventas
                                            .GroupBy(l => l.AsesorId)
                                            .Select(cl => new AsesorSummary
                                            {
                                                Nombre = cl.First().Asesor.Nombres,
                                                Total = cl.Sum(c => c.Total),
                                            }).ToList();

            ReportVenta report = new ReportVenta();
            report.Detalle = ventas;
            report.Grupos = summary;




            return _responseFactory.CreateReponse(new StateExecution<ReportVenta>() { Status = state.Status , Data = report , MessageState = state.MessageState });

        }




    }
}
