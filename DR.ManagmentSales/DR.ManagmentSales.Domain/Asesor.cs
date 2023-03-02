
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Domain
{
    public class Asesor
    {
        [Key]
        public string Id { get; private set; }
        public string Nombres { get; private set; }
        public string Celular { get; private set; }
        public string Email { get; private set; }
        [JsonIgnore]
        public string UsuarioId { get; private set; }
        

        public Asesor(string id , string nombres , string celular , string email )
        {
            Id = id;
            Nombres = nombres;
            Celular = celular;
            Email = email;
          
        }
        public Asesor(string id)
        {
            Id = id;
          

        }

        public Asesor()
        {

        }

        public void AsignarUsuario(string usuarioId) 
        {

            UsuarioId = usuarioId;

        }

    }
}
