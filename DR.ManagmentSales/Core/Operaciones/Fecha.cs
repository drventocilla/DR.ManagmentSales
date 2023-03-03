
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Core.Operaciones
{
    public class Fecha
    {
        /// <summary>
        /// Sirve para validar el dia de mes, por ejemplo si se ingresa dia:30 y mes:02(Febrero) dara false ya que no existe el dia 30 para el mes de Febrero.
        /// True: si valido con exito
        /// False: si el dia no es valido.
        /// </summary>
        /// <param name="numeroDeDia"></param>
        /// <param name="mes"></param>
        /// <param name="anho"></param>
        /// <returns>True: si valido con exito-False: si el dia no es valido.</returns>
        public static bool ValidarDiaDeMes(int numeroDeDia, int mes, int anho)
        {
            bool resultadoDeValidacion = false;
            try
            {
                string strFecha = numeroDeDia.ToString() + "/" + mes.ToString() + "/" + anho.ToString();
                DateTime fechaAuxiliar = Convert.ToDateTime(strFecha);
                resultadoDeValidacion = true;
            }
            catch (Exception)
            {
                resultadoDeValidacion = false;
            }
            return resultadoDeValidacion;
        }

        public static DateTime ConvertirAFechaAPartirDeDiaDeMes(int numeroDeDia, int mes, int anho)
        {
            DateTime fechaAuxiliar;
            try
            {
                string strFecha = numeroDeDia.ToString() + "/" + mes.ToString() + "/" + anho.ToString();
                fechaAuxiliar = Convert.ToDateTime(strFecha);
            }
            catch (Exception)
            {
                fechaAuxiliar = DateTime.Now;
            }
            return fechaAuxiliar;
        }


        public static int MesesDeDiferenciaEntre2Fechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            int mesesDeDiferencia = 0;
            try
            {
                mesesDeDiferencia = (fechaFinal.Year * 12 + fechaFinal.Month) - (fechaInicial.Year * 12 + fechaInicial.Month);
            }
            catch (Exception)
            {
                mesesDeDiferencia = 0;
            }
            return mesesDeDiferencia;
        }



        /// <summary>
        /// Convierte la propiedad Text del MaskedTextBox a una fecha. Si no logra convertir devuelve Fecha Actual.
        /// </summary>
        /// <param name="propiedadTextDeMaskedTextBox"></param>
        /// <returns></returns>
        public static DateTime ConvertirTextoDeMskTxtAFecha(string propiedadTextDeMaskedTextBox)
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
        public static DateTime? ConvertirTextoDeMskTxtANullFecha(string propiedadTextDeMaskedTextBox)
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

        /// <summary>
        /// Devuelve True: si la propiedad Text del MaskedTextBox genera una fecha valida o si la Fecha es Nula.
        /// </summary>
        /// <param name="propiedadTextDeMaskedTextBox"></param>
        /// <returns></returns>
        public static bool ValidarMasketTextBox(string propiedadTextDeMaskedTextBox)
        {
            bool resultadoDeValidacion = false;
            try
            {
                if (propiedadTextDeMaskedTextBox.Trim() == "/  /")
                {
                    resultadoDeValidacion = true;
                }
                else
                {
                    DateTime fechaAuxiliar = new DateTime(Convert.ToInt32(propiedadTextDeMaskedTextBox.Substring(6).Trim()), Convert.ToInt32(propiedadTextDeMaskedTextBox.Substring(3, 2).Trim()), Convert.ToInt32(propiedadTextDeMaskedTextBox.Substring(0, 2).Trim()));
                    if (fechaAuxiliar.Year > 1902)
                    {
                        resultadoDeValidacion = true;
                    }
                    else
                    {
                        resultadoDeValidacion = false;
                    }

                }
            }
            catch (Exception)
            {
                resultadoDeValidacion = false;
            }
            return resultadoDeValidacion;
        }

        public static string ConvertirFechaAPropiedadTextDeMaskedTextBox(DateTime fechaAConvertir)
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
        public static string ConvertirFechaAPropiedadTextDeMaskedTextBox(DateTime? fechaAConvertir)
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
        /// <summary>
        /// Convierte el lector["fechaDeVencimiento"] a NullDate
        /// </summary>
        /// <param name="lector">lector["fechaDeVencimiento"]</param>
        /// <returns>null O nullDate</returns>
        public static DateTime? ConvertirLectorANullDate(object lector)
        {
            if (lector is DBNull)
            {
                return null;
            }
            else
            {
                return (DateTime?)lector;
            }

        }



        /// <summary>
        /// Si el objeto es null o no compatible con una fecha entonces devuelve null, sino devuelve el objeto convertido en fecha
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
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

        public static bool EsNullDate(DateTime? datetime)
        {
            if (datetime == null)
            {
                return true;
            }
            return false;

        }

        public static bool EsFecha1_MayorA_Fecha2(DateTime date1, DateTime date2)
        {
            bool resultado = false;
            int resultadoDeCompararFechas = DateTime.Compare(date1, date2);
            //string relationship;

            if (resultadoDeCompararFechas < 0)
            {
                //relationship = "F1 es anterior a F2";
            }
            else if (resultadoDeCompararFechas == 0)
            {
                //relationship = "F1 es igual a F2";
            }
            else
            {
                //relationship = "F1 es posterior a F2";
                resultado = true;
            }
            return resultado;
        }
        public static string DevolverNombreMesAPartirNumero(int NumeroMEs)
        {
            string nombreMes = "";

            switch (NumeroMEs)
            {
                case 1: nombreMes = "ENERO";
                    break;

                case 2: nombreMes = "FEBRERO";
                    break;

                case 3: nombreMes = "MARZO";
                    break;

                case 4: nombreMes = "ABRIL";
                    break;

                case 5: nombreMes = "MAYO";
                    break;

                case 6: nombreMes = "JUNIO";
                    break;

                case 7: nombreMes = "JULIO";
                    break;

                case 8: nombreMes = "AGOSTO";
                    break;

                case 9: nombreMes = "SEPTIEMBRE";
                    break;

                case 10: nombreMes = "OCTUBRE";
                    break;

                case 11: nombreMes = "NOVIEMBRE";
                    break;

                case 12: nombreMes = "DICIEMBRE";
                    break;

                default: nombreMes = "";
                    break;



            }
            return nombreMes;
        }

        public static DateTime ObtenerFechaDesdeInternet()
        {
            try
            {
                //default Windows time server
                const string ntpServer = "time.windows.com";

                // NTP message size - 16 bytes of the digest (RFC 2030)
                var ntpData = new byte[48];

                //Setting the Leap Indicator, Version Number and Mode values
                ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

                var addresses = Dns.GetHostEntry(ntpServer).AddressList;

                //The UDP port number assigned to NTP is 123
                var ipEndPoint = new IPEndPoint(addresses[0], 123);
                //NTP uses UDP
                var socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);

                socket.Connect(ipEndPoint);

                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 3000;

                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();

                //Offset to get to the "Transmit Timestamp" field (time at which the reply 
                //departed the server for the client, in 64-bit timestamp format."
                const byte serverReplyTime = 40;

                //Get the seconds part
                ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

                //Get the seconds fraction
                ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

                //Convert From big-endian to little-endian
                intPart = SwapEndianness(intPart);
                fractPart = SwapEndianness(fractPart);

                var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

                //**UTC** time
                var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

                return networkDateTime.ToLocalTime();
            }
            catch (Exception)
            {

                return DateTime.Now;
            }

        }

        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        public static string ObtenerCadenaFechaActual()
        {
            DateTime fechaProcesar = DateTime.Now;
            return fechaProcesar.Year.ToString() + fechaProcesar.Month.ToString("00") + fechaProcesar.Day.ToString("00") + fechaProcesar.Hour.ToString("00") + fechaProcesar.Minute.ToString("00") + fechaProcesar.Second.ToString("00") + fechaProcesar.Millisecond.ToString("000");
        }

        public static DateTime FechaEnZonaHorariaPeru()
        {
           
            DateTime fechaActual = DateTime.Now;
            TimeZoneInfo zonaHorariaPeru;
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                 zonaHorariaPeru = TimeZoneInfo.FindSystemTimeZoneById("America/Bogota");
            }
            else
            {
                 zonaHorariaPeru = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            }
            TimeZoneInfo timeZoneInfoActual = TimeZoneInfo.Local;
            if (timeZoneInfoActual.DisplayName == zonaHorariaPeru.DisplayName)
            {
                return DateTime.Now;
            }
            else
            {
                return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(fechaActual, TimeZoneInfo.Local.Id, zonaHorariaPeru.Id);
            }
        }
    }
}
