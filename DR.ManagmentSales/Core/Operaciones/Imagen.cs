using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Core.Operaciones
{
    public class Imagen
    {
        /// <summary>
        /// Convierte una imagen a un array byte
        /// </summary>
        /// <param name="imagen"></param>
        /// <returns></returns>
        public static byte[] ConvertirImagenAByte(Image imagen)
        {
            byte[] imagenArrayAGuardar = null;
            if (imagen != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(imagen);
                    if (imagen.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                    {
                        bmp.Save(ms, ImageFormat.Jpeg);
                    }
                    else if (imagen.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                    {
                        bmp.Save(ms, ImageFormat.Png);
                    }
                    else if (imagen.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                    {
                        bmp.Save(ms, ImageFormat.Gif);
                    }
                    else
                    {
                        //formato por defecto
                        bmp.Save(ms, ImageFormat.Jpeg);
                    }


                    imagenArrayAGuardar = ms.ToArray();

                    return imagenArrayAGuardar;
                }
            }
            else
            {
                imagenArrayAGuardar = null;
            }
            return imagenArrayAGuardar;
        }
        /// <summary>
        /// Convierte un array de bytes a una imagen
        /// </summary>
        /// <param name="ArrayImagen"></param>
        /// <returns></returns>
        public static Image ConvertirByteAImagen(byte[] ArrayImagen)
        { //imagen del producto que buscamos

            Image imagenProductoACargar = null;
            // Bitmap bm =null;
            if (ArrayImagen != null)
            // asignamos el espacio de memoria
            {

                //MemoryStream mStream = new MemoryStream();
                //byte[] pData = ;
                //mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                //bm = new Bitmap(mStream);
                //mStream.Dispose();
                //return bm;
                try
                {
                    using (MemoryStream stream = new MemoryStream(ArrayImagen))
                    {
                        // convierte stream en imagen
                        imagenProductoACargar = Image.FromStream(stream);

                    }
                    return imagenProductoACargar;
                }
                catch (Exception e)
                {

                    string effxf = e.Message;
                }

            }
            else
            {
                imagenProductoACargar = null;
            }
            return imagenProductoACargar;
        }
        /// <summary>
        /// Redimenciona una imagen. según el tamaño requerido 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="size"></param>
        /// <param name="preserveAspectRatio"></param>
        /// <returns></returns>
        public static Image Resize(Image imagen, Size tamaño, bool preservarRelacion)
        {
            int newWidth;
            int newHeight;
            if (preservarRelacion)
            {
                int originalWidth = imagen.Width;
                int originalHeight = imagen.Height;
                float percentWidth = (float)tamaño.Width / (float)originalWidth;
                float percentHeight = (float)tamaño.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = tamaño.Width;
                newHeight = tamaño.Height;
            }
            System.Drawing.Image newImage = new System.Drawing.Bitmap(newWidth, newHeight);
            using (System.Drawing.Graphics graphicsHandle = System.Drawing.Graphics.FromImage(newImage))
            {

                graphicsHandle.Clear(Color.White);
                graphicsHandle.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphicsHandle.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(imagen, 0, 0, newWidth, newHeight);
            }

            return newImage;



        }
    }
}
