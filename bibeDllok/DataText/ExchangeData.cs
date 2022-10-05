using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using CommonModel;
using DataModel;

namespace DataText
{
	// Token: 0x02000016 RID: 22
	public class ExchangeData
	{
		// Token: 0x0600014A RID: 330 RVA: 0x00007020 File Offset: 0x00005220
		public static string RegisterKeyOnline(string comID, string cusKey, string name, string phone, string note)
		{
			return global::DataText.ExchangeData.smethod_0(comID, cusKey, name, phone, note, default(global::System.DateTime));
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00007044 File Offset: 0x00005244
		public static string CheckKeyOnline(string comID, ref global::CustomerKey ck)
		{
			string text = global::DataModel.Util.ReadKeyFile();
			if (string.IsNullOrEmpty(text))
			{
				return "";
			}
			text = global::DataModel.Util.UnZIP(text);
			ck = global::CommonModel.UtilModel.ConvertJSON2Obj<global::CustomerKey>(text);
			if (ck == null)
			{
				return "";
			}
			if (!(ck.EndDtime.Date != default(global::System.DateTime)) || !(ck.EndDtime.Date < ck.CheckDtime.Date))
			{
				global::DataText.ExchangeData.smethod_2(comID, ck.CusKey, ck.CheckDtime);
				return "";
			}
			string text2 = global::DataText.ExchangeData.smethod_0(comID, ck.CusKey, "", "", "", ck.CheckDtime);
			if (!(text2 == "OK"))
			{
				return text2;
			}
			return "Hết hạn sử dụng";
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000711C File Offset: 0x0000531C
		private static string smethod_0(string string_0, string string_1, string string_2, string string_3, string string_4, global::System.DateTime dateTime_0 = default(global::System.DateTime))
		{
			string text = global::DataText.ExchangeData.smethod_1(string_0, string_1, string_2, string_3, string_4);
			if (string.IsNullOrEmpty(text))
			{
				if (!(dateTime_0 != default(global::System.DateTime)))
				{
					return "Xin hãy kết nối internet" + global::System.Environment.NewLine + " Hoặc xin gọi tới số 098 2116 022 - 098 306 2116";
				}
				if (dateTime_0.AddDays(90.0) < global::System.DateTime.Now)
				{
					return "Xin hãy kết nối internet!";
				}
			}
			else
			{
				if (text.Contains("error:"))
				{
					if (global::System.IO.File.Exists(global::DataModel.Util.getKeyFile))
					{
						global::System.IO.File.Delete(global::DataModel.Util.getKeyFile);
					}
					return text.Substring("error: ".Length).Replace(".", global::System.Environment.NewLine);
				}
				global::System.IO.File.WriteAllText(global::DataModel.Util.getKeyFile, text);
			}
			return "OK";
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000071DC File Offset: 0x000053DC
		private static string smethod_1(string string_0, string string_1, string string_2, string string_3, string string_4)
		{
			string result;
			try
			{
				string text = string.Concat(new string[]
				{
					"comID=",
					string_0,
					"&cusKey=",
					string_1,
					"&fullName=",
					global::System.Web.HttpUtility.UrlEncode(string_2),
					"&phone=",
					global::System.Web.HttpUtility.UrlEncode(string_3),
					"&note=",
					global::System.Web.HttpUtility.UrlEncode(string_4)
				});
				result = global::DataModel.Util.queryServer("AppSync/RegisterKey/", text);
			}
			catch
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000726C File Offset: 0x0000546C
		private static void smethod_2(string string_0, string string_1, global::System.DateTime dateTime_0)
		{
			global::DataText.ExchangeData.Class6 @class = new global::DataText.ExchangeData.Class6();
			@class.string_0 = string_0;
			@class.string_1 = string_1;
			@class.dateTime_0 = dateTime_0;
			new global::System.Threading.Thread(new global::System.Threading.ThreadStart(@class.method_0)).Start();
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000072A8 File Offset: 0x000054A8
		private static void smethod_3(string string_0, string string_1, global::System.DateTime dateTime_0)
		{
			try
			{
				global::DataText.ExchangeData.smethod_0(string_0, string_1, "", "", "", dateTime_0);
			}
			catch (global::System.Exception ex)
			{
				global::DataText.ELogger.LogMessage(ex, "");
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000072EC File Offset: 0x000054EC
		public static string ChangeInfo(string comID, string cusKey, string name, string phone, string note)
		{
			string result;
			try
			{
				string text = string.Concat(new string[]
				{
					"comID=",
					comID,
					"&cusKey=",
					cusKey,
					"&fullName=",
					global::System.Web.HttpUtility.UrlEncode(name),
					"&phone=",
					global::System.Web.HttpUtility.UrlEncode(phone),
					"&note=",
					global::System.Web.HttpUtility.UrlEncode(note)
				});
				result = global::DataModel.Util.queryServer("AppSync/ChangeKeyInfo/", text);
			}
			catch (global::System.Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004254 File Offset: 0x00002454
		public ExchangeData()
		{
		}

		// Token: 0x02000017 RID: 23
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class Class6
		{
			// Token: 0x0600015C RID: 348 RVA: 0x00004254 File Offset: 0x00002454
			public Class6()
			{
			}

			// Token: 0x0600015D RID: 349 RVA: 0x0000737C File Offset: 0x0000557C
			internal void method_0()
			{
				global::DataText.ExchangeData.smethod_3(this.string_0, this.string_1, this.dateTime_0);
			}

			// Token: 0x04000044 RID: 68
			public string string_0;

			// Token: 0x04000045 RID: 69
			public string string_1;

			// Token: 0x04000046 RID: 70
			public global::System.DateTime dateTime_0;
		}
	}
}
