using System;
using System.IO;

namespace DataText
{
	// Token: 0x02000015 RID: 21
	public static class ELogger
	{
		// Token: 0x06000145 RID: 325 RVA: 0x00006F7C File Offset: 0x0000517C
		public static void LogMessage(global::System.Exception ex, string more = "")
		{
			global::DataText.ELogger.smethod_0(ex.Message, ex.StackTrace, more);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00006F9C File Offset: 0x0000519C
		private static void smethod_0(string string_0, string string_1 = "", string string_2 = "")
		{
			global::System.IO.StreamWriter streamWriter = global::System.IO.File.AppendText(global::System.Environment.CurrentDirectory + "\\ErorLog_" + global::System.DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
			try
			{
				string value = string.Format("{0:G}: {1}. <==> {2}, {3}", new object[]
				{
					global::System.DateTime.Now,
					string_0,
					string_1,
					string_2
				});
				streamWriter.WriteLine(value);
			}
			finally
			{
				streamWriter.Close();
			}
		}
	}
}
