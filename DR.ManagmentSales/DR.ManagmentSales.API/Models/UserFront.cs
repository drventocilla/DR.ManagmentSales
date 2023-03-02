using DR.ManagmentSales.Domain;
using System.ComponentModel.DataAnnotations;

namespace DR.ManagmentSales.API.Models
{
    public class UserFront
    {

        public string Id { get; set; }
        public string Nombre { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Token { get; set; }
        

        public UserFront(string id , string nombre , TipoUsuario tipoUsuario ,string  token )
        {
            Id = id;
            Nombre = nombre;
            TipoUsuario = tipoUsuario;
            Token = token;

        }
    }
}
