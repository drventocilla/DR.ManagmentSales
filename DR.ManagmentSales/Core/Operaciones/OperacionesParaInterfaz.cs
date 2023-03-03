using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using System.Windows.Forms;
//CORE INTERFACE WINFORMS

namespace Core.Operaciones
{
    public class OperacionesParaInterfaz
    {
        //    public static bool ValidarControlesConContenidoDeDatos(Control controlContenedor)
        //    {
        //        bool resultado = true;
        //        if (controlContenedor.Enabled)
        //        {
        //            foreach (Control item in controlContenedor.Controls)
        //            {
        //                if (item is ControlesPersonalisados.TextBoxEx)
        //                {
        //                    if (((ControlesPersonalisados.TextBoxEx)item).PuedeSerVacio == false)
        //                    {
        //                        if (((ControlesPersonalisados.TextBoxEx)item).Text.Trim().Length == 0)
        //                        {
        //                            //pinta
        //                            resultado = false;
        //                            ControlesPersonalisados.TextBoxEx textbox = (ControlesPersonalisados.TextBoxEx)item;
        //                            Graphics graphics = controlContenedor.CreateGraphics();
        //                            graphics.FillRectangle(new SolidBrush(textbox.ColorDeBordeSiEsRequerido), textbox.Location.X - 1, textbox.Location.Y - 1, textbox.ClientSize.Width + 2, textbox.ClientSize.Height + 2);
        //                        }
        //                        else
        //                        {
        //                            //despinta
        //                            Graphics graphics4 = controlContenedor.CreateGraphics();
        //                            graphics4.FillRectangle(new SolidBrush(Color.White), ((ControlesPersonalisados.TextBoxEx)item).Location.X - 1, ((ControlesPersonalisados.TextBoxEx)item).Location.Y - 1, ((ControlesPersonalisados.TextBoxEx)item).ClientSize.Width + 2, ((ControlesPersonalisados.TextBoxEx)item).ClientSize.Height + 2);

        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (((ControlesPersonalisados.TextBoxEx)item).Text.Trim().Length == 0)
        //                        {
        //                            Graphics graphics5 = controlContenedor.CreateGraphics();
        //                            graphics5.FillRectangle(new SolidBrush(Color.White), ((ControlesPersonalisados.TextBoxEx)item).Location.X - 1, ((ControlesPersonalisados.TextBoxEx)item).Location.Y - 1, ((ControlesPersonalisados.TextBoxEx)item).ClientSize.Width + 2, ((ControlesPersonalisados.TextBoxEx)item).ClientSize.Height + 2);
        //                        }
        //                    }
        //                }
        //                else if (item is ControlesPersonalisados.ComboBoxEx)
        //                {
        //                    if (((ControlesPersonalisados.ComboBoxEx)item).PuedeSerVacio == false)
        //                    {
        //                        if (((ControlesPersonalisados.ComboBoxEx)item).Text.Trim().Length == 0)
        //                        {
        //                            // pinta
        //                            resultado = false;
        //                            ControlesPersonalisados.ComboBoxEx textbox = (ControlesPersonalisados.ComboBoxEx)item;
        //                            Graphics graphics = controlContenedor.CreateGraphics();
        //                            graphics.FillRectangle(new SolidBrush(textbox.ColorDeBordeSiEsRequerido), textbox.Location.X - 1, textbox.Location.Y - 1, textbox.ClientSize.Width + 2, textbox.ClientSize.Height + 2);


        //                        }
        //                        else
        //                        {
        //                            //despinta
        //                            Graphics graphics4 = controlContenedor.CreateGraphics();
        //                            graphics4.FillRectangle(new SolidBrush(Color.White), ((ControlesPersonalisados.ComboBoxEx)item).Location.X - 1, ((ControlesPersonalisados.ComboBoxEx)item).Location.Y - 1, ((ControlesPersonalisados.ComboBoxEx)item).ClientSize.Width + 2, ((ControlesPersonalisados.ComboBoxEx)item).ClientSize.Height + 2);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (((ControlesPersonalisados.ComboBoxEx)item).Text.Trim().Length == 0)
        //                        {
        //                            Graphics graphics5 = controlContenedor.CreateGraphics();
        //                            graphics5.FillRectangle(new SolidBrush(Color.White), ((ControlesPersonalisados.ComboBoxEx)item).Location.X - 1, ((ControlesPersonalisados.ComboBoxEx)item).Location.Y - 1, ((ControlesPersonalisados.ComboBoxEx)item).ClientSize.Width + 2, ((ControlesPersonalisados.ComboBoxEx)item).ClientSize.Height + 2);
        //                        }
        //                    }
        //                }
        //                else if (item is ControlesPersonalisados.MaskedTextBoxEx)
        //                {
        //                    if (((ControlesPersonalisados.MaskedTextBoxEx)item).PuedeSerVacio == false)
        //                    {
        //                        if (((MaskedTextBox)item).Text.Trim() == "/  /")
        //                        {
        //                            resultado = false;
        //                            MaskedTextBox textbox = (MaskedTextBox)item;
        //                            Graphics graphics = controlContenedor.CreateGraphics();
        //                            graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 128, 128)), textbox.Location.X - 1, textbox.Location.Y - 1, textbox.ClientSize.Width + 2, textbox.ClientSize.Height + 2);
        //                        }
        //                        else
        //                        {
        //                            Graphics graphics4 = controlContenedor.CreateGraphics();
        //                            graphics4.FillRectangle(new SolidBrush(Color.White), ((MaskedTextBox)item).Location.X - 1, ((MaskedTextBox)item).Location.Y - 1, ((MaskedTextBox)item).ClientSize.Width + 2, ((MaskedTextBox)item).ClientSize.Height + 2);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (((MaskedTextBox)item).Text.Trim().Length == 0)
        //                        {
        //                            Graphics graphics5 = controlContenedor.CreateGraphics();
        //                            graphics5.FillRectangle(new SolidBrush(Color.White), ((MaskedTextBox)item).Location.X - 1, ((MaskedTextBox)item).Location.Y - 1, ((MaskedTextBox)item).ClientSize.Width + 2, ((MaskedTextBox)item).ClientSize.Height + 2);
        //                        }
        //                    }
        //                }
        //            }

        //        }
        //        return resultado;
        //    }

        //    public static bool ValidarControlesConContenidoDeDatos(List<Control> listaPanelesContenedor)
        //    {
        //        bool resultado = true;
        //        foreach (Control controlContenedor in listaPanelesContenedor)
        //        {
        //            if (controlContenedor.Enabled)
        //            {
        //                foreach (Control item in controlContenedor.Controls)
        //                {
        //                    if (item is ControlesPersonalisados.TextBoxEx)
        //                    {
        //                        if (((ControlesPersonalisados.TextBoxEx)item).PuedeSerVacio == false)
        //                        {
        //                            if (((ControlesPersonalisados.TextBoxEx)item).Text.Trim().Length == 0)
        //                            {
        //                                //pinta
        //                                resultado = false;
        //                                ControlesPersonalisados.TextBoxEx textbox = (ControlesPersonalisados.TextBoxEx)item;
        //                                Graphics graphics = controlContenedor.CreateGraphics();
        //                                graphics.FillRectangle(new SolidBrush(textbox.ColorDeBordeSiEsRequerido), textbox.Location.X - 1, textbox.Location.Y - 1, textbox.ClientSize.Width + 2, textbox.ClientSize.Height + 2);


        //                            }
        //                            else
        //                            {
        //                                //despinta
        //                                Graphics graphics4 = controlContenedor.CreateGraphics();
        //                                graphics4.FillRectangle(new SolidBrush(Color.White), ((ControlesPersonalisados.TextBoxEx)item).Location.X - 1, ((ControlesPersonalisados.TextBoxEx)item).Location.Y - 1, ((ControlesPersonalisados.TextBoxEx)item).ClientSize.Width + 2, ((ControlesPersonalisados.TextBoxEx)item).ClientSize.Height + 2);

        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (((ControlesPersonalisados.TextBoxEx)item).Text.Trim().Length == 0)
        //                            {
        //                                Graphics graphics5 = controlContenedor.CreateGraphics();
        //                                graphics5.FillRectangle(new SolidBrush(Color.White), ((ControlesPersonalisados.TextBoxEx)item).Location.X - 1, ((ControlesPersonalisados.TextBoxEx)item).Location.Y - 1, ((ControlesPersonalisados.TextBoxEx)item).ClientSize.Width + 2, ((ControlesPersonalisados.TextBoxEx)item).ClientSize.Height + 2);
        //                            }
        //                        }
        //                    }
        //                    else if (item is ControlesPersonalisados.ComboBoxEx)
        //                    {
        //                        if (((ControlesPersonalisados.ComboBoxEx)item).PuedeSerVacio == false)
        //                        {
        //                            if (((ControlesPersonalisados.ComboBoxEx)item).Text.Trim().Length == 0)
        //                            {
        //                                // pinta
        //                                resultado = false;
        //                                ControlesPersonalisados.ComboBoxEx textbox = (ControlesPersonalisados.ComboBoxEx)item;
        //                                Graphics graphics = controlContenedor.CreateGraphics();
        //                                graphics.FillRectangle(new SolidBrush(textbox.ColorDeBordeSiEsRequerido), textbox.Location.X - 1, textbox.Location.Y - 1, textbox.ClientSize.Width + 2, textbox.ClientSize.Height + 2);


        //                            }
        //                            else
        //                            {
        //                                //despinta
        //                                Graphics graphics4 = controlContenedor.CreateGraphics();
        //                                graphics4.FillRectangle(new SolidBrush(Color.White), ((ControlesPersonalisados.ComboBoxEx)item).Location.X - 1, ((ControlesPersonalisados.ComboBoxEx)item).Location.Y - 1, ((ControlesPersonalisados.ComboBoxEx)item).ClientSize.Width + 2, ((ControlesPersonalisados.ComboBoxEx)item).ClientSize.Height + 2);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (((ControlesPersonalisados.ComboBoxEx)item).Text.Trim().Length == 0)
        //                            {
        //                                Graphics graphics5 = controlContenedor.CreateGraphics();
        //                                graphics5.FillRectangle(new SolidBrush(Color.White), ((ControlesPersonalisados.ComboBoxEx)item).Location.X - 1, ((ControlesPersonalisados.ComboBoxEx)item).Location.Y - 1, ((ControlesPersonalisados.ComboBoxEx)item).ClientSize.Width + 2, ((ControlesPersonalisados.ComboBoxEx)item).ClientSize.Height + 2);
        //                            }
        //                        }
        //                    }
        //                    else if (item is ControlesPersonalisados.MaskedTextBoxEx)
        //                    {
        //                        if (((ControlesPersonalisados.MaskedTextBoxEx)item).PuedeSerVacio == false)
        //                        {
        //                            if (((MaskedTextBox)item).Text.Trim() == "/  /")
        //                            {
        //                                resultado = false;
        //                                MaskedTextBox textbox = (MaskedTextBox)item;
        //                                Graphics graphics = controlContenedor.CreateGraphics();
        //                                graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 128, 128)), textbox.Location.X - 1, textbox.Location.Y - 1, textbox.ClientSize.Width + 2, textbox.ClientSize.Height + 2);
        //                            }
        //                            else
        //                            {
        //                                Graphics graphics4 = controlContenedor.CreateGraphics();
        //                                graphics4.FillRectangle(new SolidBrush(Color.White), ((MaskedTextBox)item).Location.X - 1, ((MaskedTextBox)item).Location.Y - 1, ((MaskedTextBox)item).ClientSize.Width + 2, ((MaskedTextBox)item).ClientSize.Height + 2);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (((MaskedTextBox)item).Text.Trim().Length == 0)
        //                            {
        //                                Graphics graphics5 = controlContenedor.CreateGraphics();
        //                                graphics5.FillRectangle(new SolidBrush(Color.White), ((MaskedTextBox)item).Location.X - 1, ((MaskedTextBox)item).Location.Y - 1, ((MaskedTextBox)item).ClientSize.Width + 2, ((MaskedTextBox)item).ClientSize.Height + 2);
        //                            }
        //                        }
        //                        ////if (true)
        //                        ////{
        //                        //    if (((MaskedTextBox)item).Text.Trim() == "/  /")
        //                        //    {
        //                        //        resultado = false;
        //                        //        MaskedTextBox textbox = (MaskedTextBox)item;
        //                        //        Graphics graphics = controlContenedor.CreateGraphics();
        //                        //        graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 128, 128)), textbox.Location.X - 1, textbox.Location.Y - 1, textbox.ClientSize.Width + 2, textbox.ClientSize.Height + 2);
        //                        //    }
        //                        //    else
        //                        //    {
        //                        //        Graphics graphics4 = controlContenedor.CreateGraphics();
        //                        //        graphics4.FillRectangle(new SolidBrush(Color.White), ((MaskedTextBox)item).Location.X - 1, ((MaskedTextBox)item).Location.Y - 1, ((MaskedTextBox)item).ClientSize.Width + 2, ((MaskedTextBox)item).ClientSize.Height + 2);
        //                        //    }
        //                        ////}
        //                        ////else
        //                        ////{
        //                        ////    if (((MaskedTextBox)item).Text.Trim().Length == 0)
        //                        ////    {
        //                        ////        Graphics graphics5 = controlContenedor.CreateGraphics();
        //                        ////        graphics5.FillRectangle(new SolidBrush(Color.White), ((MaskedTextBox)item).Location.X - 1, ((MaskedTextBox)item).Location.Y - 1, ((MaskedTextBox)item).ClientSize.Width + 2, ((MaskedTextBox)item).ClientSize.Height + 2);
        //                        ////    }
        //                        ////}
        //                    }
        //                }

        //            }

        //        }
        //        return resultado;
        //    }

        //    public static void PosicionarFoco(Control controlContenedor)
        //    {
        //        int flagTabIndex = 999999;
        //        foreach (Control item in controlContenedor.Controls)
        //        {
        //            if (item is ControlesPersonalisados.TextBoxEx)
        //            {
        //                if (((ControlesPersonalisados.TextBoxEx)item).PuedeSerVacio == false)
        //                {
        //                    if (((ControlesPersonalisados.TextBoxEx)item).Text.Trim().Length == 0)
        //                    {
        //                        ControlesPersonalisados.TextBoxEx textboxAPosicionar = (ControlesPersonalisados.TextBoxEx)item;
        //                        if (textboxAPosicionar.TabStop == true)
        //                        {
        //                            if (flagTabIndex > textboxAPosicionar.TabIndex)
        //                            {
        //                                textboxAPosicionar.Focus();
        //                                flagTabIndex = textboxAPosicionar.TabIndex;
        //                            }
        //                        }

        //                    }
        //                }
        //            }
        //            else if (item is ControlesPersonalisados.ComboBoxEx)
        //            {

        //                if (((ControlesPersonalisados.ComboBoxEx)item).PuedeSerVacio == false)
        //                {
        //                    if (((ControlesPersonalisados.ComboBoxEx)item).Text.Trim().Length == 0)
        //                    {
        //                        ControlesPersonalisados.ComboBoxEx comboBoxAPosicionarFoco = (ControlesPersonalisados.ComboBoxEx)item;
        //                        if (flagTabIndex > comboBoxAPosicionarFoco.TabIndex)
        //                        {
        //                            comboBoxAPosicionarFoco.Focus();
        //                            flagTabIndex = comboBoxAPosicionarFoco.TabIndex;
        //                        }

        //                    }

        //                }

        //            }
        //            else if (item is ControlesPersonalisados.MaskedTextBoxEx)
        //            {
        //                if (((ControlesPersonalisados.MaskedTextBoxEx)item).PuedeSerVacio == false)
        //                {
        //                    if (((MaskedTextBox)item).Text.Trim() == "/  /")
        //                    {
        //                        MaskedTextBox maskedTextBoxAPosicionarFoco = (MaskedTextBox)item;
        //                        if (flagTabIndex > maskedTextBoxAPosicionarFoco.TabIndex)
        //                        {
        //                            maskedTextBoxAPosicionarFoco.Focus();
        //                            flagTabIndex = maskedTextBoxAPosicionarFoco.TabIndex;
        //                        }

        //                    }
        //                }
        //            }
        //        }
        //    }

        //    public static void PosicionarFoco(List<Control> listaPanelesContenedor)
        //    {
        //        int flagTabIndex = 999999;
        //        foreach (Control controlContenedor in listaPanelesContenedor)
        //        {
        //            foreach (Control item in controlContenedor.Controls)
        //            {
        //                if (item is ControlesPersonalisados.TextBoxEx)
        //                {
        //                    if (((ControlesPersonalisados.TextBoxEx)item).PuedeSerVacio == false)
        //                    {
        //                        if (((ControlesPersonalisados.TextBoxEx)item).Text.Trim().Length == 0)
        //                        {
        //                            ControlesPersonalisados.TextBoxEx textboxAPosicionar = (ControlesPersonalisados.TextBoxEx)item;
        //                            if (textboxAPosicionar.TabStop == true)
        //                            {
        //                                if (flagTabIndex > textboxAPosicionar.TabIndex)
        //                                {
        //                                    textboxAPosicionar.Focus();
        //                                    flagTabIndex = textboxAPosicionar.TabIndex;
        //                                }
        //                            }

        //                        }
        //                    }
        //                }
        //                else if (item is ControlesPersonalisados.ComboBoxEx)
        //                {

        //                    if (((ControlesPersonalisados.ComboBoxEx)item).PuedeSerVacio == false)
        //                    {
        //                        if (((ControlesPersonalisados.ComboBoxEx)item).Text.Trim().Length == 0)
        //                        {
        //                            ControlesPersonalisados.ComboBoxEx comboBoxAPosicionarFoco = (ControlesPersonalisados.ComboBoxEx)item;
        //                            if (flagTabIndex > comboBoxAPosicionarFoco.TabIndex)
        //                            {
        //                                comboBoxAPosicionarFoco.Focus();
        //                                flagTabIndex = comboBoxAPosicionarFoco.TabIndex;
        //                            }

        //                        }

        //                    }

        //                }
        //                else if (item is ControlesPersonalisados.MaskedTextBoxEx)
        //                {
        //                    if (((MaskedTextBox)item).Text.Trim() == "/  /")
        //                    {
        //                        MaskedTextBox maskedTextBoxAPosicionarFoco = (MaskedTextBox)item;
        //                        if (flagTabIndex > maskedTextBoxAPosicionarFoco.TabIndex)
        //                        {
        //                            maskedTextBoxAPosicionarFoco.Focus();
        //                            flagTabIndex = maskedTextBoxAPosicionarFoco.TabIndex;
        //                        }

        //                    }
        //                }
        //            }
        //        }

        //    }

        //    public static void MostarMensajeConErrorProvider(ErrorProvider errorProvider, Control control, int posicion, string mensajeGenerado)
        //    {
        //        errorProvider.SetIconPadding(control, posicion);
        //        errorProvider.SetError(control, mensajeGenerado);
        //        errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
        //    }

        //    public static string DevolverCadena_RedondeadaExactaADecimal(double numero)
        //    {
        //        string stringResultado = "";
        //        string[] Partes = numero.ToString().Split('.');
        //        if (Partes.Count() == 1)
        //        {
        //            stringResultado = numero.ToString("0.00");
        //        }
        //        else
        //        {
        //            if (Partes[1].Count() < 6)
        //            {
        //                stringResultado = Math.Round(numero, Partes[1].Count()).ToString();
        //            }
        //            else
        //            {
        //                stringResultado = Math.Round(numero, 6).ToString();
        //            }


        //        }

        //        return stringResultado;
        //    }



        //    public static string QuitarCaracteresEspeciales(string cadenaAEditar)
        //    {
        //        Regex pattern = new Regex("[;,\t\r\"\'\n\\ ]");
        //        cadenaAEditar = pattern.Replace(cadenaAEditar, " ");

        //        return cadenaAEditar;
        //    }

        //    public static void CambiarVentanaActivoNoActivo(System.Windows.Forms.Panel pnlTitulo, bool ventanaActiva)
        //    {
        //        if (ventanaActiva)
        //        {
        //            pnlTitulo.BackColor = Color.FromArgb(29, 29, 29);
        //        }
        //        else
        //        {
        //            pnlTitulo.BackColor = Color.Gray;
        //        }

        //    }

        //    public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)

        //    {


        //        using (Bitmap imagenBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
        //        {
        //            imagenBitmap.SetResolution(Convert.ToInt32(srcImage.HorizontalResolution), Convert.ToInt32(srcImage.HorizontalResolution));

        //            using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
        //            {
        //                imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
        //                imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //                imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //                imagenGraphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
        //                MemoryStream imagenMemoryStream = new MemoryStream();
        //                imagenBitmap.Save(imagenMemoryStream, ImageFormat.Png);
        //                srcImage = Image.FromStream(imagenMemoryStream);
        //            }
        //        }
        //        return srcImage;
        //    }

        //    public static Image Resize(System.Drawing.Image image, System.Drawing.Size size, bool preserveAspectRatio)
        //    {
        //        int newWidth;
        //        int newHeight;
        //        if (preserveAspectRatio)
        //        {
        //            int originalWidth = image.Width;
        //            int originalHeight = image.Height;
        //            float percentWidth = (float)size.Width / (float)originalWidth;
        //            float percentHeight = (float)size.Height / (float)originalHeight;
        //            float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
        //            newWidth = (int)(originalWidth * percent);
        //            newHeight = (int)(originalHeight * percent);
        //        }
        //        else
        //        {
        //            newWidth = size.Width;
        //            newHeight = size.Height;
        //        }
        //        System.Drawing.Image newImage = new System.Drawing.Bitmap(newWidth, newHeight);
        //        using (System.Drawing.Graphics graphicsHandle = System.Drawing.Graphics.FromImage(newImage))
        //        {
        //            graphicsHandle.CompositingQuality = CompositingQuality.HighQuality;
        //            graphicsHandle.Clear(Color.Transparent);
        //            Graphic.CompositingMode = CompositingMode.SourceCopy;
        //            graphicsHandle.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        //            graphicsHandle.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
        //        }
        //        return newImage;
        //    }

        //    public static DataTable ObtenerdtDeTipoEnumerado(Enum tipoEnumerado)
        //    {
        //        DataTable dtResultadoDelMetodo = new DataTable();
        //        dtResultadoDelMetodo.Columns.Add("Código");
        //        dtResultadoDelMetodo.Columns.Add("Descripción");
        //        foreach (Enum valor in Enum.GetValues(tipoEnumerado.GetType()))
        //        {
        //            dtResultadoDelMetodo.Rows.Add(valor.ToString(), valor.ToString());
        //        }
        //        return dtResultadoDelMetodo;
        //    }

        //    public static string ConvertirFuenteACadena(Font fuente)
        //    {
        //        string cadenaDevuelta = "";
        //        try
        //        {
        //            var convertidorDeFuente = new FontConverter();
        //            cadenaDevuelta = convertidorDeFuente.ConvertToString(fuente);
        //        }
        //        catch
        //        {
        //            cadenaDevuelta = "";
        //        }
        //        return cadenaDevuelta;
        //    }

        //    public static Font ConvertirCadenaAFuente(string fuenteComoCadena)
        //    {
        //        var convertidorDeFuente = new FontConverter();
        //        Font fuenteADevolver;
        //        try
        //        {
        //             fuenteADevolver = convertidorDeFuente.ConvertFromString(fuenteComoCadena) as Font;
        //        }
        //        catch 
        //        {
        //            fuenteADevolver = convertidorDeFuente.ConvertFromString("Microsoft Sans Serif, 8.25pt, style=Bold") as Font;
        //        }

        //        return fuenteADevolver;
        //    }

        public static string PasarRBGACadena(Color color)
        {

            //string r = btnColor.BackColor.R.ToString();
            string strColor = color.R.ToString() + "x" + color.G.ToString() + "x" + color.B.ToString();// +"x" + btnColor.BackColor.A.ToString();
            return strColor; ;
        }

        public static Color PasarCadenaARBG(string cadena)
        {
            string[] cadenaApasar = cadena.Split('x');

            foreach (string RBGObtenido in cadenaApasar)
            {
                Console.WriteLine(RBGObtenido);
            }
            int R = Convert.ToInt32(cadenaApasar[0]);
            int G = Convert.ToInt32(cadenaApasar[1]);
            int B = Convert.ToInt32(cadenaApasar[2]);
            //int A = Convert.ToInt32(cadenaApasar[3]);

            Color color = Color.FromArgb(R, G, B);

            return color;
        }

        public static string ObtenerValorDeColumna_dt(DataTable dt, string valorDeBusqueda, string nombreColumna_DondeBuscar, string nombreDeLaColumna_Obtener)
        {
            string resultado = "";
            try
            {
                for (int indiceDeFila = 0; indiceDeFila < dt.Rows.Count; indiceDeFila++)
                {
                    if (dt.Rows[indiceDeFila][nombreColumna_DondeBuscar].ToString() == valorDeBusqueda)
                    {
                        resultado = dt.Rows[indiceDeFila][nombreDeLaColumna_Obtener].ToString();
                        break;
                    }
                }
            }
            catch
            {
                resultado = "";

            }
            return resultado;
        }

        public static string ObtnerValorDeDatable(DataTable dtProcesar, string filtro, string nombreDeColumnaADevolverValor)
        {
            string valor = "";
            try
            {
                DataRow[] RowAuxiliarEquivalente = dtProcesar.Select(filtro);
                if (RowAuxiliarEquivalente != null)
                {
                    if (RowAuxiliarEquivalente.Count() == 1)
                    {
                        valor = RowAuxiliarEquivalente[0][nombreDeColumnaADevolverValor].ToString();
                    }
                }
            }
            catch
            {
                valor = "";
            }
            return valor;
        }

        //    public static int BuscarTextoEnDataGridVIew_YDevolverIndiceDeFilaEncontrada(string textoABuscar, string nombreDeColumna, DataGridView grid)
        //    {
        //        int indiceDeFilaDondeSeENcontroElTexto = -1;
        //        if (textoABuscar == string.Empty) return -1;
        //        //if (grid.RowCount == 0) return -1;
        //        grid.ClearSelection();
        //        if (nombreDeColumna == string.Empty)
        //        {
        //            return -1;
        //            //foreach (DataGridViewRow row in grid.Rows)
        //            //{
        //            //    foreach (DataGridViewCell cell in row.Cells)
        //            //        if (cell.Value == textoABuscar)
        //            //        {
        //            //            row.Selected = true;
        //            //            return true;
        //            //        }
        //            //}
        //        }
        //        else
        //        {
        //            foreach (DataGridViewRow row in grid.Rows)
        //            {
        //                if (Cadena.ConvertirNullAString(row.Cells[nombreDeColumna].Value) == textoABuscar)
        //                {
        //                    indiceDeFilaDondeSeENcontroElTexto = row.Index;
        //                    row.Selected = true;
        //                    return indiceDeFilaDondeSeENcontroElTexto;
        //                }
        //            }
        //        }
        //        return indiceDeFilaDondeSeENcontroElTexto;
        //    }

    }
}
