using Core.GestionDeExcepciones;
using Core.Operaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Validators
{
    public class ValidatorResult
    {
        public List<string> errors { get;  set; }
        public bool result { get { return !errors.Any(); } }

        public ValidatorResult()
        {
            errors = new List<string>();
        }


        public string GetStringError() {

            string errorCadena = "";
            foreach (string error in errors)
            {
                if (!Cadena.EsLaCadenaVacia(errorCadena))
                {
                    errorCadena = $"{errorCadena}  {Environment.NewLine} {error}";
                }
                else
                {
                    errorCadena = $"{error}";
                }
               
            }
            return errorCadena;
        }

        public string GetLastMessageError()
        {
            if (errors.Count==0)
            {
                return "";
            }
            

            return errors[errors.Count-1];
        }

        public string GetFirstMessageError()
        {
            if (errors.Count == 0)
            {
                return "";
            }
                      
            return errors[0];
        }

    }
}
