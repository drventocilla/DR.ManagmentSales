using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Convertir
    {

        /// <summary>
        /// Convierte un string sea nulo o vacio a NullInt(Int?). Si la cadena tiene un numero entonces devuelve la cadena convertida a NullInt.
        /// </summary>
        /// <param name="cadena">Vacio o Null</param>
        /// <returns>NullInt(Int?)</returns>
        public static int? BlancoONuloA_NullInt(string cadena)
        {
            try
            {
                if (cadena.ToString().Trim() == "")
                {
                    return null;
                }
                return Convert.ToInt32(cadena);
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Devuelve 0 si cadena es vacia.
        /// </summary>
        /// <param name="cadena">Vacio o string</param>
        /// <returns></returns>""-->0 datos requeridos ; "12412" -->0
        public static int VacioA_Int(string cadena)
        {
            try
            {
                return Convert.ToInt32(cadena.Trim());
            }
            catch
            {
                return 0;
            }

        }
        /// <summary>
        /// Devuelve 0 si cadena es vacia o si la cadena no es un numero valido. Si la cadena es un numero valido devuelve el numero.
        /// </summary>
        /// <param name="cadena">Vacio o string</param>
        /// <returns></returns>
        public static double VacioA_Double(string cadena)
        {
            try
            {
                return Convert.ToDouble(cadena.Trim());
            }
            catch
            {
                return 0.00;
            }

        }
        public static double VacioA_Double(object cadena)
        {
            try
            {
                return Convert.ToDouble(cadena);
            }
            catch
            {
                return 0.00;
            }

        }

        public static double? BlancoONuloA_NullDouble(string cadena)
        {
            try
            {
                if (cadena.ToString().Trim() == "")
                {
                    return null;
                }
                return Convert.ToDouble(cadena);
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Convierte la propiedad Text del MaskedTextBox a una fecha. Si no logra convertir devuelve Fecha Actual.
        /// </summary>
        /// <param name="propiedadTextDeMaskedTextBox"></param>
        /// <returns></returns>
        public static DateTime TextoDeMskTxtA_Fecha(string propiedadTextDeMaskedTextBox)
        {
            DateTime fechaAuxiliar;
            try
            {
                fechaAuxiliar = new DateTime(Convert.ToInt32(propiedadTextDeMaskedTextBox.Substring(6).Trim()), Convert.ToInt32(propiedadTextDeMaskedTextBox.Substring(3, 2).Trim()), Convert.ToInt32(propiedadTextDeMaskedTextBox.Substring(0, 2).Trim()));
                return fechaAuxiliar;

            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Convierte la propiedad Text del MaskedTextBox a una fecha. Si no logra convertir devuelve NullDate.
        /// </summary>
        /// <param name="propiedadTextDeMaskedTextBox"></param>
        /// <returns></returns>
        public static DateTime? TextoDeMskTxtA_NullFecha(string propiedadTextDeMaskedTextBox)
        {
            DateTime fechaAuxiliar;
            try
            {
                fechaAuxiliar = new DateTime(Convert.ToInt32(propiedadTextDeMaskedTextBox.Substring(6).Trim()), Convert.ToInt32(propiedadTextDeMaskedTextBox.Substring(3, 2).Trim()), Convert.ToInt32(propiedadTextDeMaskedTextBox.Substring(0, 2).Trim()));
                return fechaAuxiliar;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string FechaA_PropiedadTextDeMaskedTextBox(DateTime fechaAConvertir)
        {
            string propiedadTexDevuelto = "";
            try
            {
                propiedadTexDevuelto = fechaAConvertir.ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {
                propiedadTexDevuelto = "";
            }
            return propiedadTexDevuelto;
        }
       
        public static string FechaA_PropiedadTextDeMaskedTextBox(DateTime? fechaAConvertir)
        {
            string propiedadTexDevuelto = "";
            try
            {
                if (fechaAConvertir != null)
                {
                    propiedadTexDevuelto = ((DateTime)fechaAConvertir).ToString("dd/MM/yyyy");
                }
            }
            catch (Exception)
            {
                propiedadTexDevuelto = "";
            }
            return propiedadTexDevuelto;
        }

        public static string NumeroALetras(string numeroEnString)
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
            else
            {
                dec = " CON " + "00/100";
            }

            res = NumeroALetras(Convert.ToDouble(entero)) + dec;
            return res;
        }
        private static string NumeroALetras(double numeroAConvertir)
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
            else if (numeroAConvertir < 20) Num2Text = "DIECI" + NumeroALetras(numeroAConvertir - 10);
            else if (numeroAConvertir == 20) Num2Text = "VEINTE";
            else if (numeroAConvertir < 30) Num2Text = "VEINTI" + NumeroALetras(numeroAConvertir - 20);
            else if (numeroAConvertir == 30) Num2Text = "TREINTA";
            else if (numeroAConvertir == 40) Num2Text = "CUARENTA";
            else if (numeroAConvertir == 50) Num2Text = "CINCUENTA";
            else if (numeroAConvertir == 60) Num2Text = "SESENTA";
            else if (numeroAConvertir == 70) Num2Text = "SETENTA";
            else if (numeroAConvertir == 80) Num2Text = "OCHENTA";
            else if (numeroAConvertir == 90) Num2Text = "NOVENTA";

            else if (numeroAConvertir < 100) Num2Text = NumeroALetras(Math.Truncate(numeroAConvertir / 10) * 10) + " Y " + NumeroALetras(numeroAConvertir % 10);
            else if (numeroAConvertir == 100) Num2Text = "CIEN";
            else if (numeroAConvertir < 200) Num2Text = "CIENTO " + NumeroALetras(numeroAConvertir - 100);
            else if ((numeroAConvertir == 200) || (numeroAConvertir == 300) || (numeroAConvertir == 400) || (numeroAConvertir == 600) || (numeroAConvertir == 800)) Num2Text = NumeroALetras(Math.Truncate(numeroAConvertir / 100)) + "CIENTOS";

            else if (numeroAConvertir == 500) Num2Text = "QUINIENTOS";
            else if (numeroAConvertir == 700) Num2Text = "SETECIENTOS";
            else if (numeroAConvertir == 900) Num2Text = "NOVECIENTOS";
            else if (numeroAConvertir < 1000) Num2Text = NumeroALetras(Math.Truncate(numeroAConvertir / 100) * 100) + " " + NumeroALetras(numeroAConvertir % 100);
            else if (numeroAConvertir == 1000) Num2Text = "MIL";
            else if (numeroAConvertir < 2000) Num2Text = "MIL " + NumeroALetras(numeroAConvertir % 1000);
            else if (numeroAConvertir < 1000000)
            {
                Num2Text = NumeroALetras(Math.Truncate(numeroAConvertir / 1000)) + " MIL";
                if ((numeroAConvertir % 1000) > 0) Num2Text = Num2Text + " " + NumeroALetras(numeroAConvertir % 1000);
            }

            else if (numeroAConvertir == 1000000) Num2Text = "UN MILLON";
            else if (numeroAConvertir < 2000000) Num2Text = "UN MILLON " + NumeroALetras(numeroAConvertir % 1000000);
            else if (numeroAConvertir < 1000000000000)
            {
                Num2Text = NumeroALetras(Math.Truncate(numeroAConvertir / 1000000)) + " MILLONES ";
                if ((numeroAConvertir - Math.Truncate(numeroAConvertir / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + NumeroALetras(numeroAConvertir - Math.Truncate(numeroAConvertir / 1000000) * 1000000);
            }
            else if (numeroAConvertir == 1000000000000) Num2Text = "UN BILLON";
            else if (numeroAConvertir < 2000000000000) Num2Text = "UN BILLON " + NumeroALetras(numeroAConvertir - Math.Truncate(numeroAConvertir / 1000000000000) * 1000000000000);
            else
            {
                Num2Text = NumeroALetras(Math.Truncate(numeroAConvertir / 1000000000000)) + " BILLONES";
                if ((numeroAConvertir - Math.Truncate(numeroAConvertir / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + NumeroALetras(numeroAConvertir - Math.Truncate(numeroAConvertir / 1000000000000) * 1000000000000);
            }

            return Num2Text;
        }

        public static string ValorA_String(Object valor, int cantidadDeDecimales)
        {
            try
            {
                if (valor.GetType() == typeof(double))
                {
                    if (valor == null)
                    {
                        return "";
                    }
                    else
                    {
                        if (cantidadDeDecimales == 0)
                        {
                            return ((double)valor).ToString("0");
                        }
                        else if (cantidadDeDecimales == 1)
                        {
                            return ((double)valor).ToString("0.0");
                        }
                        else if (cantidadDeDecimales == 2)
                        {
                            return ((double)valor).ToString("0.00");
                        }
                        else if (cantidadDeDecimales == 3)
                        {
                            return ((double)valor).ToString("0.000");
                        }
                        else if (cantidadDeDecimales == 4)
                        {
                            return ((double)valor).ToString("0.0000");
                        }
                        else if (cantidadDeDecimales == 5)
                        {
                            return ((double)valor).ToString("0.00000");
                        }
                        else if (cantidadDeDecimales == 6)
                        {
                            return ((double)valor).ToString("0.000000");
                        }
                        else if (cantidadDeDecimales == 7)
                        {
                            return ((double)valor).ToString("0.0000000");
                        }
                        else if (cantidadDeDecimales == 8)
                        {
                            return ((double)valor).ToString("0.00000000");
                        }
                        else if (cantidadDeDecimales == 9)
                        {
                            return ((double)valor).ToString("0.000000000");
                        }
                        else if (cantidadDeDecimales == 10)
                        {
                            return ((double)valor).ToString("0.0000000000");
                        }
                        else
                        {
                            return ((double)valor).ToString();
                        }
                    }
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

        public static DateTime? ConvertirObjetoANullFecha(object objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return null;
                }
                else
                {
                    return (DateTime?)objeto;
                }
            }
            catch
            {
                return null;
            }


        }
     
    }
}
