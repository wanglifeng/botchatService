using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    public class SHA1Algorithm
    {
        public static String Enctypt(String str)
        {
            SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider();
            byte[] hashBytes = provider.ComputeHash(UTF8Encoding.ASCII.GetBytes(str.ToCharArray()));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
                sb.AppendFormat("{0:x}", hashBytes[i]);
            return sb.ToString();
        }
    }
}
