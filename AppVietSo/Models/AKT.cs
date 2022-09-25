using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
	// Token: 0x02000014 RID: 20
	[global::System.Serializable]
	public abstract class AKT :  IKT
	{
		// Token: 0x0600009D RID: 157
		public abstract object getId();

		// Token: 0x0600009E RID: 158 RVA: 0x000054AC File Offset: 0x000036AC
		public string getLimitScript()
		{
			return this.limit;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000054C0 File Offset: 0x000036C0
		public void setLimitScript(string s)
		{
			this.limit = s;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000054D4 File Offset: 0x000036D4
		public string getMoreScript()
		{
			return this.moreScript;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000054E8 File Offset: 0x000036E8
		public void setMoreScript(string s)
		{
			this.moreScript = s;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000054FC File Offset: 0x000036FC
		public bool getAutoGenerateScript()
		{
			return this.autoGenerateScript;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00005510 File Offset: 0x00003710
		public void setAutoGenerateScript(bool b)
		{
			this.autoGenerateScript = b;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00005524 File Offset: 0x00003724
		protected AKT()
		{
		}

		// Token: 0x0400002F RID: 47
		private string limit = string.Empty;

		// Token: 0x04000030 RID: 48
		private string moreScript;

		// Token: 0x04000031 RID: 49
		private bool autoGenerateScript = true;
	}
}
