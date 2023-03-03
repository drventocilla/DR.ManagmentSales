using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Operaciones
{
    public class MensajeDeError
    {
        public static void GuardarInformacionDeError(string mensaje)
        {
            try
            {
                string nombreDeLaCarpeta = System.IO.Directory.GetCurrentDirectory() + @"\InformacionDeErrores";
                if (!System.IO.Directory.Exists(nombreDeLaCarpeta))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(nombreDeLaCarpeta);
                    }
                    catch
                    {
                    }
                }
                string nombreDelArchivo = nombreDeLaCarpeta + @"\Informacion.txt";
                if (!System.IO.File.Exists(nombreDelArchivo))
                {
                    try
                    {
                        System.IO.File.Create(nombreDelArchivo).Close();
                    }
                    catch
                    {
                    }
                }

                System.IO.File.AppendAllText(nombreDelArchivo, (DateTime.Now.ToString() + "||" + mensaje) + Environment.NewLine);
            }
            catch
            {


            }

        }


        public static void MostrarNotificacionEnComputadora(string mensaje1 ,string mensaje2)
        {
            //for (int i = 0; i < 3; i++)
            //{
            //    if (Cadena.EsLaCadenaVacia(mensaje1) == false)
            //    {
            //        var notification1 = new System.Windows.Forms.NotifyIcon()
            //        {
            //            Visible = true,
            //            Icon = System.Drawing.SystemIcons.Information,
            //            BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning,
            //            BalloonTipTitle = "CIBERCONT – FACTURACIÓN ELECTRÓNICA",
            //            BalloonTipText = mensaje1,
            //        };

            //        notification1.ShowBalloonTip(20000);
            //        System.Threading.Thread.Sleep(20000);
            //        notification1.Dispose();
            //    }
            //    if (Cadena.EsLaCadenaVacia(mensaje2) == false)
            //    {
            //        var notification2 = new System.Windows.Forms.NotifyIcon()
            //        {
                        
            //            Visible = true,
            //            Icon = System.Drawing.SystemIcons.Information,
            //            BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning,
            //            BalloonTipTitle = "CIBERCONT – FACTURACIÓN ELECTRÓNICA",
            //            BalloonTipText = mensaje2,
            //        };

            //        notification2.ShowBalloonTip(20000);
            //        System.Threading.Thread.Sleep(20000);
            //        notification2.Dispose();
            //    }


            //    System.Threading.Thread.Sleep(1000*60*1);
            //}
       



        }


    }
}
