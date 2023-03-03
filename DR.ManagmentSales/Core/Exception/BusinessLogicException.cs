using System;
using System.Collections.Generic;
using System.Text;

namespace Core.GestionDeExcepciones
{
   public class BusinessLogicException : Exception
    {

        public Message mensajeDeValidacion = new Message();

        public BusinessLogicException(Message mensaje)
        {
            this.mensajeDeValidacion = mensaje;
        }

        
    }
}
