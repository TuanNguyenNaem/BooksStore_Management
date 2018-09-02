using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Heppers
{
    public class MaHoaMD5
    {
        public static string MaHoa(string value)
        {
            //var data = System.Text.Encoding.ASCII.GetBytes(value);
            //data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            //return Convert.ToBase64String(data);
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(value);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
