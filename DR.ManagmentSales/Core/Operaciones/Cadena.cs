using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Core.Operaciones
{
    public class Cadena
    {
        #region Tipos Enumerados
        #endregion

        #region Atributos Privados
        #endregion

        #region Atributos Publicos
        #endregion

        #region Propiedades
        #endregion

        #region Constructores
        #endregion

        #region Metodos Privados
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Devulve true: si la cadena es "null" o tiene "longitud 0"
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool EsLaCadenaVacia(string cadena)
        {
            bool resultado = false;
            try
            {
                if (cadena==null)
                {
                    resultado = true;
                }
                else
                {
                    if (cadena.Trim().Length > 0)
                    {
                        resultado = false;
                    }
                    else
                    {
                        resultado = true;
                    }
                }                
            }
            catch
            {
            }
            return resultado;
        }

        /// <summary>
        /// Devulve true: si la cadena del MaskedText es "null" o tiene "longitud 0"
        /// </summary>
        /// <param name="cadenaMaskedText"></param>
        /// <returns></returns>
        public static bool EsLaCadenaMaskedTextVacia(string cadenaMaskedText)
        {
            bool resultado = false;
            try
            {
                if (cadenaMaskedText == null)
                {
                    resultado = true;
                }
                else
                {
                    if (cadenaMaskedText.Trim() == "/  /")
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }
                }
            }
            catch
            {
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// Devulve true: si el entero es "null","0" o genera un error
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static bool EsLaCadenaVacia(int? numero)
        {
            bool resultado = false;
            try
            {
                if (numero == null)
                {
                    resultado = true;
                }
                else
                {
                    if (numero.ToString().Trim().Length > 0)
                    {
                        resultado = false;
                    }
                    else
                    {
                        resultado = true;
                    }
                }
            }
            catch
            {
            }
            return resultado;
        }

        public static string QuitarPrimerSaltoDeLinea(string cadena)
        {
            string cadenaDevuelta = cadena;
            try
            {
                if (cadena.Substring(0,1)=="\n")
                {
                    cadenaDevuelta = cadena.Substring(1, cadena.Length - 1);
                }
            }
            catch
            {
                cadenaDevuelta = cadena;
            }
            return cadenaDevuelta;
        }

        public static double ConvertirADouble(string cadena)
        {
            double valor = 0;
            try
            {
                valor = Convert.ToDouble(cadena);
            }
            catch (Exception)
            {
            }
            return valor;
        }
        /// <summary>
        /// Devuelve null si la cadena esta en blanco.
        /// Devueve la misma cadena si NO esta en blanco
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string ConvertirBlancoAnulo(string cadena)
        {
            try
            {
                if (cadena.Trim() == "")
                {
                    return null;
                }
                return cadena;
            }
            catch
            {
                return null;
            }
            
        }

        public static string ConvertirNullIntAString(int? cadena)
        {
            try
            {
                if (cadena == null)
                {
                    return "";
                }
                return cadena.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static string ConvertirNullDoubleAString(double? cadena)
        {
            try
            {
                if (cadena == null)
                {
                    return "";
                }
                return ((double)cadena).ToString("0,0.000");
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Convierte un Valor "null" a un string en Blanco
        /// Si no es "null" devuelve el valor.ToString()
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string ConvertirNullAString(Object valor)
        {
            try
            {
                if (valor == null)
                {
                    return "";
                }
                else
                {
                    return valor.ToString();
                }
            }
            catch
            {
                return "";
            }
        }
        public static string ConvertirNullADouble(Object valor)
        {
            try
            {
                if (valor == null)
                {
                    return "";
                }
                return ((double)valor).ToString("00.000");
            }
            catch
            {
                return "";
            }
        }


        public static bool EsNumerico(String cadena)
        {
            Regex patronNumerico = new Regex("[^0-9]");
            return !patronNumerico.IsMatch(cadena);
        }

        public static bool EsAlfabetico(String cadena)
        {
            Regex patronAlfabetico = new Regex("[^a-zA-Z]");
            return !patronAlfabetico.IsMatch(cadena);
        }

        public static bool EsAlfanumerico(String cadena)
        {
            Regex patronAlfanumerico = new Regex("[^a-zA-Z0-9]");
            return !patronAlfanumerico.IsMatch(cadena);
        }

        public static string ConvertirNumeroALetras(string numeroEnString)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(numeroEnString);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));

            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = ConvertirNumeroALetras(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private static string ConvertirNumeroALetras(double numeroAConvertir)
        {
            string Num2Text = "";
            numeroAConvertir = Math.Truncate(numeroAConvertir);

            if (numeroAConvertir == 0) Num2Text = "CERO";
            else if (numeroAConvertir == 1) Num2Text = "UNO";
            else if (numeroAConvertir == 2) Num2Text = "DOS";
            else if (numeroAConvertir == 3) Num2Text = "TRES";
            else if (numeroAConvertir == 4) Num2Text = "CUATRO";
            else if (numeroAConvertir == 5) Num2Text = "CINCO";
            else if (numeroAConvertir == 6) Num2Text = "SEIS";
            else if (numeroAConvertir == 7) Num2Text = "SIETE";
            else if (numeroAConvertir == 8) Num2Text = "OCHO";
            else if (numeroAConvertir == 9) Num2Text = "NUEVE";
            else if (numeroAConvertir == 10) Num2Text = "DIEZ";
            else if (numeroAConvertir == 11) Num2Text = "ONCE";
            else if (numeroAConvertir == 12) Num2Text = "DOCE";
            else if (numeroAConvertir == 13) Num2Text = "TRECE";
            else if (numeroAConvertir == 14) Num2Text = "CATORCE";
            else if (numeroAConvertir == 15) Num2Text = "QUINCE";
            else if (numeroAConvertir < 20) Num2Text = "DIECI" + ConvertirNumeroALetras(numeroAConvertir - 10);
            else if (numeroAConvertir == 20) Num2Text = "VEINTE";
            else if (numeroAConvertir < 30) Num2Text = "VEINTI" + ConvertirNumeroALetras(numeroAConvertir - 20);
            else if (numeroAConvertir == 30) Num2Text = "TREINTA";
            else if (numeroAConvertir == 40) Num2Text = "CUARENTA";
            else if (numeroAConvertir == 50) Num2Text = "CINCUENTA";
            else if (numeroAConvertir == 60) Num2Text = "SESENTA";
            else if (numeroAConvertir == 70) Num2Text = "SETENTA";
            else if (numeroAConvertir == 80) Num2Text = "OCHENTA";
            else if (numeroAConvertir == 90) Num2Text = "NOVENTA";

            else if (numeroAConvertir < 100) Num2Text = ConvertirNumeroALetras(Math.Truncate(numeroAConvertir / 10) * 10) + " Y " + ConvertirNumeroALetras(numeroAConvertir % 10);
            else if (numeroAConvertir == 100) Num2Text = "CIEN";
            else if (numeroAConvertir < 200) Num2Text = "CIENTO " + ConvertirNumeroALetras(numeroAConvertir - 100);
            else if ((numeroAConvertir == 200) || (numeroAConvertir == 300) || (numeroAConvertir == 400) || (numeroAConvertir == 600) || (numeroAConvertir == 800)) Num2Text = ConvertirNumeroALetras(Math.Truncate(numeroAConvertir / 100)) + "CIENTOS";

            else if (numeroAConvertir == 500) Num2Text = "QUINIENTOS";
            else if (numeroAConvertir == 700) Num2Text = "SETECIENTOS";
            else if (numeroAConvertir == 900) Num2Text = "NOVECIENTOS";
            else if (numeroAConvertir < 1000) Num2Text = ConvertirNumeroALetras(Math.Truncate(numeroAConvertir / 100) * 100) + " " + ConvertirNumeroALetras(numeroAConvertir % 100);
            else if (numeroAConvertir == 1000) Num2Text = "MIL";
            else if (numeroAConvertir < 2000) Num2Text = "MIL " + ConvertirNumeroALetras(numeroAConvertir % 1000);
            else if (numeroAConvertir < 1000000)
            {
                Num2Text = ConvertirNumeroALetras(Math.Truncate(numeroAConvertir / 1000)) + " MIL";
                if ((numeroAConvertir % 1000) > 0) Num2Text = Num2Text + " " + ConvertirNumeroALetras(numeroAConvertir % 1000);
            }

            else if (numeroAConvertir == 1000000) Num2Text = "UN MILLON";
            else if (numeroAConvertir < 2000000) Num2Text = "UN MILLON " + ConvertirNumeroALetras(numeroAConvertir % 1000000);
            else if (numeroAConvertir < 1000000000000)
            {
                Num2Text = ConvertirNumeroALetras(Math.Truncate(numeroAConvertir / 1000000)) + " MILLONES ";
                if ((numeroAConvertir - Math.Truncate(numeroAConvertir / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + ConvertirNumeroALetras(numeroAConvertir - Math.Truncate(numeroAConvertir / 1000000) * 1000000);
            }
            else if (numeroAConvertir == 1000000000000) Num2Text = "UN BILLON";
            else if (numeroAConvertir < 2000000000000) Num2Text = "UN BILLON " + ConvertirNumeroALetras(numeroAConvertir - Math.Truncate(numeroAConvertir / 1000000000000) * 1000000000000);
            else
            {
                Num2Text = ConvertirNumeroALetras(Math.Truncate(numeroAConvertir / 1000000000000)) + " BILLONES";
                if ((numeroAConvertir - Math.Truncate(numeroAConvertir / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + ConvertirNumeroALetras(numeroAConvertir - Math.Truncate(numeroAConvertir / 1000000000000) * 1000000000000);
            }

            return Num2Text;
        }



        public static bool ValidarCorreo(string correoAValidar)
        {
            bool resultadoDeValidacion = false;
            try
            {
                String expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(correoAValidar, expresion))
                {
                    resultadoDeValidacion = true;
                }
                else
                {
                    resultadoDeValidacion = false;
                }
            }
            catch
            {

            }
            return resultadoDeValidacion;
        }
        #endregion



    }
}
