using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Domain
{
    public class Usuario : Auditoria
    {
        [Key]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

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
