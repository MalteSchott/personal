using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOne.Utils
{
    static class CryptographyUtilities
    {
        private static readonly Encoding encoder = Encoding.UTF8; //decoding is done with encoder.GetString
        public static string Hash(string clearText, string salt)
        {
            byte[] data = SHA512.Create().ComputeHash(encoder.GetBytes(clearText + salt));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i<data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
