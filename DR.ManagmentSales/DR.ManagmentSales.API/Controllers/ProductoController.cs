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
        private readonly StatusCodeBuilder _statusCodeBuilder;


        public ProductoController(ProductoService productoService, 
                                 StatusCodeBuilder statusCodeBuilder)
        {
            _productoService = productoService;
            _statusCodeBuilder = statusCodeBuilder;
            
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<Producto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(CancellationToken token) {

            
            StateExecution<IEnumerable<Producto>> state =await _productoService.GetAsync(token);

            return _statusCodeBuilder.ConstruirAPartirDeEstado(state);

        }

        [HttpGet("Find")]
        [ProducesResponseType(typeof(APIResponse<Producto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Find([FromQuery(Name ="id")] string id  , CancellationToken token)
        {


            StateExecution<Producto> state = await _productoService.FindAsync(id , token);

            return _statusCodeBuilder.ConstruirAPartirDeEstado(state);

        }


        [HttpPost("Save")]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save(ProductoModel entidad, CancellationToken token)
        {
            Producto producto = new Producto(entidad.id , entidad.nombre , entidad.precio);


            StateExecution state = await _productoService.UpsertAsync(producto, token);
            return _statusCodeBuilder.ConstruirAPartirDeEstado(state);

        }


        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromQuery(Name = "id")] string id, CancellationToken token)
        {

            StateExecution state = await _productoService.DeleteAsync(id, token);
            return _statusCodeBuilder.ConstruirAPartirDeEstado(state);

        }


    }
}
