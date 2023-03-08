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
    public class ProductoController : Controller
    {
        private readonly ProductoService _productoService;
        private readonly ResponseFactory _responseFactory;


        public ProductoController(ProductoService productoService, 
                                 ResponseFactory responseFactory)
        {
            _productoService = productoService;
            _responseFactory = responseFactory;
            
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(SucessResponse<IEnumerable<Producto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(CancellationToken token) {

            
            StateExecution<IEnumerable<Producto>> state =await _productoService.GetAsync(token);

            return _responseFactory.CreateReponse(state);

        }

        [HttpGet("Find")]
        [ProducesResponseType(typeof(SucessResponse<Producto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Find([FromQuery(Name ="id")] string id  , CancellationToken token)
        {


            StateExecution<Producto> state = await _productoService.FindAsync(id , token);

            return _responseFactory.CreateReponse(state);

        }


        [HttpPost("Save")]
        [ProducesResponseType(typeof(SucessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save(ProductoModel entidad, CancellationToken token)
        {
            Producto producto = new Producto(entidad.id , entidad.nombre , entidad.precio);


            StateExecution state = await _productoService.UpsertAsync(producto, token);
            return _responseFactory.CreateReponse(state);

        }


        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(SucessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromQuery(Name = "id")] string id, CancellationToken token)
        {

            StateExecution state = await _productoService.DeleteAsync(id, token);
            return _responseFactory.CreateReponse(state);

        }


    }
}
