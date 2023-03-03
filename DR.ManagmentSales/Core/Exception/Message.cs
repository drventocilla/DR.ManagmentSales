using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Core.GestionDeExcepciones
{
    public class Message
    {
        #region Tipos Enumerados
       
      
        

        #endregion

        #region Atributos Privados
        #endregion

        #region Atributos Publicos
        #endregion

        #region Propiedades
        public string Description  { get; set; }
        public string Detail { get; set; }
        public string Action { get; set; }
        
        #endregion

        #region Constructores

        public Message()
        {
            
            this.Description = "";
            this.Detail = "";
            this.Action = "";
            
        }
        public Message(string description, string detail ,string action )
        {
            this.Description = description;
            this.Detail = detail;
            this.Action = action;
        }
       
        public void LimpiarMensaje()
        {
            this.Description = "";
            this.Detail = "";
            this.Action = "";
        }

        #endregion

        #region Metodos Privados
        #endregion

        #region Metodos Publicos

        #endregion
    }
}
