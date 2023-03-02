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
        private readonly StatusCodeBuilder _statusCodeBuilder;


        public VentaController(VentaService ventaService, 
                               StatusCodeBuilder statusCodeBuilder)
        {
            _ventaService = ventaService;
            _statusCodeBuilder = statusCodeBuilder;
            
        }

        [HttpGet("Report")]
        [ProducesResponseType(typeof(APIResponse<ReportVenta>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
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




            return _statusCodeBuilder.ConstruirAPartirDeEstado(new StateExecution<ReportVenta>() { Status = state.Status , Data = report , MessageState = state.MessageState });

        }




    }
}
