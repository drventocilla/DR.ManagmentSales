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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AsesorController : Controller
    {
        private readonly AsesorService _asesorService;
        private readonly ResponseFactory _responseFactory;


        public AsesorController(AsesorService asesorService,
                                ResponseFactory responseFactory)
        {
            _asesorService = asesorService;
            _responseFactory = responseFactory;
            
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(SucessResponse<IEnumerable<Asesor>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(CancellationToken token) {

            
            StateExecution<IEnumerable<Asesor>> state =await _asesorService.GetAsync(token);

           return _responseFactory.CreateReponse(state);

        }

        [HttpGet("Find")]
        [ProducesResponseType(typeof(SucessResponse<Asesor>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Find([FromQuery(Name ="id")] string id  , CancellationToken token)
        {


            StateExecution<Asesor> state = await _asesorService.FindAsync(id , token);

            return _responseFactory.CreateReponse(state);

        }


        [HttpPost("Save")]
        [ProducesResponseType(typeof(SucessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save(AsesorModel entidad, CancellationToken token)
        {
            Asesor asesor = new Asesor(entidad.id , entidad.nombres , entidad.celular , entidad.email);

            StateExecution state = await _asesorService.UpsertAsync(asesor, token);

            return _responseFactory.CreateReponse(state);

        }


        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(SucessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromQuery(Name = "id")] string id, CancellationToken token)
        {

            StateExecution state = await _asesorService.DeleteAsync(id, token);

            return _responseFactory.CreateReponse(state);

        }


    }
}
