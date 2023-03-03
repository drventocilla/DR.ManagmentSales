using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Core.Seguridad.Cifrado
{
    public class Hash_IIT
    {


        public static string Encrypt(string text, string key, string iterations)
        {
            string textEncrypt = "";
            try
            {
                PasswordDeriveBytes _objPdb = new PasswordDeriveBytes(text, System.Text.Encoding.UTF8.GetBytes(key), "SHA256", Convert.ToInt32(iterations));
                textEncrypt = Convert.ToBase64String(_objPdb.GetBytes(32));

            }
            catch
            {
                textEncrypt = "";
            }
            return textEncrypt;            
        }

        private static byte[] Encrypt(string text, string key, int iterations)
        {
            string _strPasswordSalt = text + key;
            SHA256Managed _objSha256 = new SHA256Managed();
            byte[] _objTemporal = null;
            try
            {
                _objTemporal = System.Text.Encoding.UTF8.GetBytes(_strPasswordSalt);
                for (int i = 0; i <= iterations - 1; i++)
                    _objTemporal = _objSha256.ComputeHash(_objTemporal);
            }
            finally { _objSha256.Clear(); }

            return _objTemporal;
        }

        public static bool CompareHash(string hashInit, string hashFinal)
        { 
            byte[] _objhashFinal = Convert.FromBase64String(hashFinal);
            byte[] _objHashInicial = Convert.FromBase64String(hashInit);
            return CompareByteArray(_objHashInicial, _objhashFinal);
        } 

        private static bool CompareByteArray(Byte[] arrayA, Byte[] arrayB)
        {
            if (arrayA.Length != arrayB.Length)
                return false;
            for (int i = 0; i <= arrayA.Length - 1; i++)
                if (!arrayA[i].Equals(arrayB[i]))
                    return false;
            return true;
        }

        public static string Decrypt(string textEncrypt, string key)
        {
            try
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
            catch (Exception)
            {

                return "";
            }
        }

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
    }
}
