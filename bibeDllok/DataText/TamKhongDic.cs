using System;
using DataModel;

namespace DataText
{
	// Token: 0x02000013 RID: 19
	public abstract class TamKhongDic : global::DataText.BaseBO
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00006D88 File Offset: 0x00004F88
		private static string password
		{
			get
			{
				return "TamKhong.Com@gmail.com";
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00006E10 File Offset: 0x00005010
		private static string dbName
		{
			get
			{
				return global::DataModel.Util.getDataPath + "TamKhongDic.com";
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00006E2C File Offset: 0x0000502C
		protected static global::DataText.DbExecute dbex
		{
			get
			{
				if (global::DataText.TamKhongDic.dbExecute_0 == null)
				{
					global::DataText.TamKhongDic.dbExecute_0 = new global::DataText.DbExecute(string.Format("Data Source={0};Version={1};Password={2}", global::DataText.TamKhongDic.dbName, 3, global::DataText.TamKhongDic.password));
					return global::DataText.TamKhongDic.dbExecute_0;
				}
				return global::DataText.TamKhongDic.dbExecute_0;
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00006DFC File Offset: 0x00004FFC
		protected TamKhongDic()
		{
		}

		// Token: 0x04000043 RID: 67
		private static global::DataText.DbExecute dbExecute_0;
	}
}
