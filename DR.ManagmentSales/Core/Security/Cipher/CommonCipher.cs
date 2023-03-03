using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Core.Seguridad.Cifrado
{
   public  class CommonCipher

    {

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

        public static string Encrypt(string text, string key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            MD5CryptoServiceProvider cryptoServiceProvider1 = new MD5CryptoServiceProvider();
            byte[] hash = cryptoServiceProvider1.ComputeHash(Encoding.UTF8.GetBytes(key));
            cryptoServiceProvider1.Clear();
            TripleDESCryptoServiceProvider cryptoServiceProvider2 = new TripleDESCryptoServiceProvider();
            cryptoServiceProvider2.Key = hash;
            cryptoServiceProvider2.Mode = CipherMode.ECB;
            cryptoServiceProvider2.Padding = PaddingMode.PKCS7;
            byte[] inArray = cryptoServiceProvider2.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            cryptoServiceProvider2.Clear();
            return Convert.ToBase64String(inArray, 0, inArray.Length);
        }

        public static string Decrypt(string textEncrypt, string key)
        {
            byte[] inputBuffer = Convert.FromBase64String(textEncrypt);
            MD5CryptoServiceProvider cryptoServiceProvider1 = new MD5CryptoServiceProvider();
            byte[] hash = cryptoServiceProvider1.ComputeHash(Encoding.UTF8.GetBytes(key));
            cryptoServiceProvider1.Clear();
            TripleDESCryptoServiceProvider cryptoServiceProvider2 = new TripleDESCryptoServiceProvider();
            cryptoServiceProvider2.Key = hash;
            cryptoServiceProvider2.Mode = CipherMode.ECB;
            cryptoServiceProvider2.Padding = PaddingMode.PKCS7;
            byte[] bytes = cryptoServiceProvider2.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            cryptoServiceProvider2.Clear();
            return Encoding.UTF8.GetString(bytes);
        }

        #endregion

    }
}
