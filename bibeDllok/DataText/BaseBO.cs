using System;
using System.Collections.Generic;
using System.Data;

namespace DataText
{
	// Token: 0x02000014 RID: 20
	public abstract class BaseBO
	{
		// Token: 0x0600013A RID: 314 RVA: 0x00006E70 File Offset: 0x00005070
		public static global::System.Collections.Generic.List<T> GetObject<T>(global::System.Data.DataTable dtValues) where T : new()
		{
			global::System.Collections.Generic.List<T> result;
			try
			{
				if (dtValues != null && dtValues.Rows != null && dtValues.Rows.Count != 0)
				{
					result = dtValues.ToList<T>();
				}
				else
				{
					result = null;
				}
			}
			catch (global::System.Exception ex)
			{
				global::DataText.ELogger.LogMessage(ex, "");
				result = null;
			}
			return result;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00006EC4 File Offset: 0x000050C4
		protected static string GetString(object cellValue)
		{
			if (cellValue == null)
			{
				return string.Empty;
			}
			return cellValue.ToString().Trim();
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00006EE8 File Offset: 0x000050E8
		protected static int GetInt(object cellValue)
		{
			int result = 0;
			string @string = global::DataText.BaseBO.GetString(cellValue);
			if (!string.IsNullOrEmpty(@string))
			{
				int.TryParse(@string.Trim(), out result);
				return result;
			}
			return 0;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00006F18 File Offset: 0x00005118
		protected static bool GetBool(object cellValue)
		{
			bool result = false;
			string @string = global::DataText.BaseBO.GetString(cellValue);
			if (!string.IsNullOrEmpty(@string))
			{
				bool.TryParse(@string.Trim(), out result);
				return result;
			}
			return result;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00006F48 File Offset: 0x00005148
		protected static global::System.DateTime GetDateTime(object cellValue)
		{
			if (cellValue == null)
			{
				return default(global::System.DateTime);
			}
			global::System.DateTime result = default(global::System.DateTime);
			global::System.DateTime.TryParse(cellValue.ToString(), out result);
			return result;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00004254 File Offset: 0x00002454
		protected BaseBO()
		{
		}
	}
}
