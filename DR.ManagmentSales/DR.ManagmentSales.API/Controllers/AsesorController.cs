using Core;
using Core.Extensions;
using DR.ManagmentSales.API.Helpers;
using DR.ManagmentSales.API.Models;
using DR.ManagmentSales.Application;
using DR.ManagmentSales.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DR.ManagmentSales.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AsesorController : Controller
    {
        private readonly AsesorService _asesorService;
        private readonly StatusCodeBuilder _statusCodeBuilder;


        public AsesorController(AsesorService asesorService, 
                                 StatusCodeBuilder statusCodeBuilder)
        {
            _asesorService = asesorService;
            _statusCodeBuilder = statusCodeBuilder;
            
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<Asesor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(CancellationToken token) {

            
            StateExecution<IEnumerable<Asesor>> state =await _asesorService.GetAsync(token);

            return _statusCodeBuilder.ConstruirAPartirDeEstado(state);

        }

        [HttpGet("Find")]
        [ProducesResponseType(typeof(APIResponse<Asesor>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Find([FromQuery(Name ="id")] string id  , CancellationToken token)
        {


            StateExecution<Asesor> state = await _asesorService.FindAsync(id , token);

            return _statusCodeBuilder.ConstruirAPartirDeEstado(state);

        }


        [HttpPost("Save")]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save(AsesorModel entidad, CancellationToken token)
        {
            Asesor asesor = new Asesor(entidad.id , entidad.nombres , entidad.celular , entidad.email);

            StateExecution state = await _asesorService.UpsertAsync(asesor, token);
            return _statusCodeBuilder.ConstruirAPartirDeEstado(state);

        }


        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromQuery(Name = "id")] string id, CancellationToken token)
        {

            StateExecution state = await _asesorService.DeleteAsync(id, token);
            return _statusCodeBuilder.ConstruirAPartirDeEstado(state);

        }


    }
}
