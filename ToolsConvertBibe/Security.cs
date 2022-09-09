using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToolsConvertBibe
{
    public class Security
    {
        public static string MaHoa(string A_0)
        {
            string password = "aBc1@3";
            byte[] bytes = Encoding.Unicode.GetBytes(A_0);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[]
                {
                    73,
                    118,
                    97,
                    110,
                    32,
                    77,
                    101,
                    100,
                    118,
                    101,
                    100,
                    101,
                    118
                });
                aes.Key = rfc2898DeriveBytes.GetBytes(32);
                aes.IV = rfc2898DeriveBytes.GetBytes(16);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                        cryptoStream.Close();
                    }
                    A_0 = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return A_0;
        }

        public static string GiaiMa(string A_0)
        {
            string password = "aBc1@3";
            A_0 = A_0.Replace(" ", "+");
            byte[] array = Convert.FromBase64String(A_0);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[]
                {
                    73,
                    118,
                    97,
                    110,
                    32,
                    77,
                    101,
                    100,
                    118,
                    101,
                    100,
                    101,
                    118
                });
                aes.Key = rfc2898DeriveBytes.GetBytes(32);
                aes.IV = rfc2898DeriveBytes.GetBytes(16);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(array, 0, array.Length);
                        cryptoStream.Close();
                    }
                    A_0 = Encoding.Unicode.GetString(memoryStream.ToArray());
                }
            }
            return A_0;
        }

    }
}
