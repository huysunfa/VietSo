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


namespace AppVietSo.Models
{
    public class Security
    {

        public static string key = "InSo!@#";

        public static string Decrypt(string cipher)
        {
            try
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    using (var tdes = new TripleDESCryptoServiceProvider())
                    {
                        tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                        tdes.Mode = CipherMode.ECB;
                        tdes.Padding = PaddingMode.PKCS7;

                        using (var transform = tdes.CreateDecryptor())
                        {
                            byte[] cipherBytes = Convert.FromBase64String(cipher);
                            byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                            return UTF8Encoding.UTF8.GetString(bytes);
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public static string Encrypt(string strEnCrypt)
        {
            try
            {
                byte[] keyArr;
                byte[] EnCryptArr = Encoding.UTF8.GetBytes(strEnCrypt);
                MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(Encoding.UTF8.GetBytes(key));
                TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = CipherMode.ECB;
                tripDes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripDes.CreateEncryptor();
                byte[] arrResult = transform.TransformFinalBlock(EnCryptArr, 0, EnCryptArr.Length);
                return Convert.ToBase64String(arrResult, 0, arrResult.Length);
            }
            catch (Exception) { }
            return "";
        }

        public static T readFile<T>(string pnf)
        {
            if (global::System.IO.File.Exists(pnf))
            {
                return UtilModel.ConvertJSON2Obj<T>(Security.tmp1(global::System.IO.File.ReadAllBytes(pnf)));
            }
            return default(T);
        }

        private static string tmp1(byte[] A_0)
		{
			return Security.GM(global::System.Text.Encoding.UTF8.GetString(A_0));
		}

        private static string GM(string A_0)
		{
			string password = "aBc1@3";
        A_0 = A_0.Replace(" ", "+");
			byte[] array = global::System.Convert.FromBase64String(A_0);
			using (global::System.Security.Cryptography.Aes aes = global::System.Security.Cryptography.Aes.Create())
			{
				global::System.Security.Cryptography.Rfc2898DeriveBytes rfc2898DeriveBytes = new global::System.Security.Cryptography.Rfc2898DeriveBytes(password, new byte[]
                {
                    0x49,
                    0x76,
                    0x61,
                    0x6E,
                    0x20,
                    0x4D,
                    0x65,
                    0x64,
                    0x76,
                    0x65,
                    0x64,
                    0x65,
                    0x76
                });
    aes.Key = rfc2898DeriveBytes.GetBytes(0x20);
				aes.IV = rfc2898DeriveBytes.GetBytes(0x10);
				using (global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream())
				{
					using (global::System.Security.Cryptography.CryptoStream cryptoStream = new global::System.Security.Cryptography.CryptoStream(memoryStream, aes.CreateDecryptor(), global::System.Security.Cryptography.CryptoStreamMode.Write))
					{
						cryptoStream.Write(array, 0, array.Length);
						cryptoStream.Close();
					}
A_0 = global::System.Text.Encoding.Unicode.GetString(memoryStream.ToArray());
				}
			}
			return A_0;
		}
}
}
