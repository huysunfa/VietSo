using System;
using DataModel;

namespace DataText
{
	// Token: 0x02000012 RID: 18
	public abstract class TamKhong : global::DataText.BaseBO
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00006D88 File Offset: 0x00004F88
		private static string password
		{
			get
			{
				return "TamKhong.Com@gmail.com";
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00006D9C File Offset: 0x00004F9C
		private static string dbName
		{
			get
			{
				return global::DataModel.Util.getDataPath + "TamKhong.com";
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00006DB8 File Offset: 0x00004FB8
		protected static global::DataText.DbExecute dbex
		{
			get
			{
				if (global::DataText.TamKhong.dbExecute_0 == null)
				{
					global::DataText.TamKhong.dbExecute_0 = new global::DataText.DbExecute(string.Format("Data Source={0};Version={1};Password={2}", global::DataText.TamKhong.dbName, 3, global::DataText.TamKhong.password));
					return global::DataText.TamKhong.dbExecute_0;
				}
				return global::DataText.TamKhong.dbExecute_0;
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00006DFC File Offset: 0x00004FFC
		protected TamKhong()
		{
		}

		// Token: 0x04000042 RID: 66
		private static global::DataText.DbExecute dbExecute_0;
	}
}
