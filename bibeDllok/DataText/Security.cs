using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CommonModel;

namespace DataText
{
	// Token: 0x02000020 RID: 32
	public class Security
	{
		// Token: 0x060001F8 RID: 504 RVA: 0x0000A554 File Offset: 0x00008754
		public static T readFile<T>(string pnf)
		{
			if (global::System.IO.File.Exists(pnf))
			{
				return global::CommonModel.UtilModel.ConvertJSON2Obj<T>(global::DataText.Security.smethod_1(global::System.IO.File.ReadAllBytes(pnf)));
			}
			return default(T);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000A584 File Offset: 0x00008784
		public static void writeFile(object longSo, string pnf)
		{
			byte[] bytes = global::DataText.Security.smethod_0(global::CommonModel.UtilModel.Convert2JSON(longSo));
			global::System.IO.File.WriteAllBytes(pnf, bytes);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000A5A4 File Offset: 0x000087A4
		private static byte[] smethod_0(string string_0)
		{
			return global::System.Text.Encoding.UTF8.GetBytes(global::DataText.Security.smethod_2(string_0));
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000A5C4 File Offset: 0x000087C4
		private static string smethod_1(byte[] byte_0)
		{
			return global::DataText.Security.smethod_3(global::System.Text.Encoding.UTF8.GetString(byte_0));
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000A5E4 File Offset: 0x000087E4
		private static string smethod_2(string string_0)
		{
			string password = "aBc1@3";
			byte[] bytes = global::System.Text.Encoding.Unicode.GetBytes(string_0);
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
					using (global::System.Security.Cryptography.CryptoStream cryptoStream = new global::System.Security.Cryptography.CryptoStream(memoryStream, aes.CreateEncryptor(), global::System.Security.Cryptography.CryptoStreamMode.Write))
					{
						cryptoStream.Write(bytes, 0, bytes.Length);
						cryptoStream.Close();
					}
					string_0 = global::System.Convert.ToBase64String(memoryStream.ToArray());
				}
			}
			return string_0;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000A6C8 File Offset: 0x000088C8
		private static string smethod_3(string string_0)
		{
			string password = "aBc1@3";
			string_0 = string_0.Replace(" ", "+");
			byte[] array = global::System.Convert.FromBase64String(string_0);
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
					string_0 = global::System.Text.Encoding.Unicode.GetString(memoryStream.ToArray());
				}
			}
			return string_0;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00004254 File Offset: 0x00002454
		public Security()
		{
		}
	}
}
