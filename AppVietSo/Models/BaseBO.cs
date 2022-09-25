using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
	// Token: 0x02000014 RID: 20
	public abstract class BaseBO
	{
		// Token: 0x0600013A RID: 314 RVA: 0x00006F34 File Offset: 0x00005134
		public static global::System.Collections.Generic.List<T> GetObject<T>(DataTable dtValues) where T : new()
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
 				result = null;
			}
			return result;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00006F88 File Offset: 0x00005188
		protected static string GetString(object cellValue)
		{
			if (cellValue == null)
			{
				return string.Empty;
			}
			return cellValue.ToString().Trim();
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00006FAC File Offset: 0x000051AC
		protected static int GetInt(object cellValue)
		{
			int result = 0;
			string @string = BaseBO.GetString(cellValue);
			if (!string.IsNullOrEmpty(@string))
			{
				int.TryParse(@string.Trim(), out result);
				return result;
			}
			return 0;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00006FDC File Offset: 0x000051DC
		protected static bool GetBool(object cellValue)
		{
			bool result = false;
			string @string = BaseBO.GetString(cellValue);
			if (!string.IsNullOrEmpty(@string))
			{
				bool.TryParse(@string.Trim(), out result);
				return result;
			}
			return result;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000700C File Offset: 0x0000520C
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

		// Token: 0x0600013F RID: 319 RVA: 0x00004258 File Offset: 0x00002458
		protected BaseBO()
		{
		}
	}
}
