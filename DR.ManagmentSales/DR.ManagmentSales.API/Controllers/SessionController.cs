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
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly StatusCodeBuilder _statusCodeBuilder;
        private readonly TokenService _tokenService;
        private readonly CryptoService _cryptoService;

        public SessionController(UsuarioService usuarioService, 
                                 StatusCodeBuilder statusCodeBuilder,
                                 TokenService tokenService, 
                                 CryptoService cryptoService)
        {
            _usuarioService = usuarioService;
            _statusCodeBuilder = statusCodeBuilder;
            _tokenService = tokenService;
            _cryptoService = cryptoService;
        }

        [HttpPost("SignIn")]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn(LoginModel model ) {

            string passwordDesencriptado = _cryptoService.DesencriptarString(model.Password);

            StateExecution<Usuario> state =await  _usuarioService.VerifySignIn(model.Login , passwordDesencriptado);

            if (!state.Status)
            {
                return _statusCodeBuilder.ConstruirAPartirDeEstado(state);

            }

            UserFront userFront = _tokenService.GenerateUserFront(state.Data);


            return _statusCodeBuilder.ConstruirAPartirDeEstado(new StateExecution<UserFront> { Status = true , StateType = State.Ok , Data = userFront , MessageState = state.MessageState.Copy()});


        }


    }
}
