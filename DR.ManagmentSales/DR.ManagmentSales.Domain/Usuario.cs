using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Domain
{
    public class Usuario
    {
        [Key]
        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public string Password { get; private set; } 
        public string Login { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }

        public Usuario(string id ,string nombre , string password ,string login , TipoUsuario  tipoUsuario )
        {
            Id = id;
            Nombre = nombre;
            Password = password;
            Login = login;
            TipoUsuario = tipoUsuario;
        }
        public Usuario(string id)
        {
            Id = id;
        }
        public Usuario()
        {

        }
    }

    public enum TipoUsuario {
    
        Asesor,
        Gerente,
        Administrador

    }
}
