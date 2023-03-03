using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class UniqueCode
    {

        private static Random random = new Random();

        public static string Guid()
        {
            return $"{DateTime.Now.ToString("yyyyMMddHHmmss")}{RandomString(6)}";
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
