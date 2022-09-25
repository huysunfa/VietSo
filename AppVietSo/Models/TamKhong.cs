using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
	public abstract class TamKhong : BaseBO
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00006E44 File Offset: 0x00005044
		private static string password
		{
			get
			{
				return "TamKhong.Com@gmail.com";
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00006E58 File Offset: 0x00005058
		private static string dbName
		{
			get
			{
				return  Util.getDataPath + "TamKhong.com";
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00006E78 File Offset: 0x00005078
  

		// Token: 0x0600012F RID: 303 RVA: 0x00006EBC File Offset: 0x000050BC
		protected TamKhong()
		{
		}

		// Token: 0x04000042 RID: 66
 	}
}
