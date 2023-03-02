
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using DR.ManagmentSales.API.Models;
using DR.ManagmentSales.Domain;

namespace DR.ManagmentSales.API.Helpers
{
    public class TokenService
    {

        private IConfiguration _configuration;
        private JwtSettings _jwtSettings;

        public TokenService(IConfiguration configuration, JwtSettings jwtSettings)
        {
            _configuration = configuration;
            _jwtSettings = jwtSettings;
        }




        public UserFront GenerateUserFront(Usuario usuario)
        {
            // Instanciamos el JwtSecurityTokenHandler poder crearlo, es ta clase nos provee de una serie de metodos para la creacion, lectura escritura, etc de tokens
            // para escribir el token en un string o leerlo desde un string con sus dos metodos:
            // tokenHandler.WriteToken(token); tokenHandler.Re0000adToken(strToken);
            var tokenHandler = new JwtSecurityTokenHandler();
            // Obtenemos la clave secreta guardada en JwtSettings:SecretKey
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            // el token descriptor nos ayudara a establecer los valores que tendra el payload de nuestro token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id),
                    //new Claim(ClaimTypes.UserData, rucEmpresa),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString()) //TODO: implementar permisos con esa cadena de 0 y 1
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            UserFront user = new UserFront(usuario.Id , usuario.Nombre , usuario.TipoUsuario , tokenHandler.WriteToken(token));


            return user;

        
        }

        public string GenerarToken(string rucEmpresa, Usuario usuario)
        {
            // Instanciamos el JwtSecurityTokenHandler poder crearlo, esta clase nos provee de una serie de metodos para la creacion, lectura escritura, etc de tokens
            // para escribir el token en un string o leerlo desde un string con sus dos metodos:
            // tokenHandler.WriteToken(token); tokenHandler.Re0000adToken(strToken);
            var tokenHandler = new JwtSecurityTokenHandler();
            // Obtenemos la clave secreta guardada en JwtSettings:SecretKey
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            // el token descriptor nos ayudara a establecer los valores que tendra el payload de nuestro token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id),
                    new Claim(ClaimTypes.UserData, rucEmpresa),
                    new Claim(ClaimTypes.Role, "Administrador") //TODO: implementar permisos con esa cadena de 0 y 1
                }),

                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

    }
}
