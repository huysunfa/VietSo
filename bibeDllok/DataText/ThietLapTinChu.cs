using System;

namespace DataText
{
	// Token: 0x02000024 RID: 36
	public class ThietLapTinChu
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000272 RID: 626 RVA: 0x0000B700 File Offset: 0x00009900
		// (set) Token: 0x06000273 RID: 627 RVA: 0x0000B714 File Offset: 0x00009914
		public string MoreText
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000274 RID: 628 RVA: 0x0000B728 File Offset: 0x00009928
		// (set) Token: 0x06000275 RID: 629 RVA: 0x0000B754 File Offset: 0x00009954
		public string FormText
		{
			get
			{
				if (string.IsNullOrEmpty(this.string_1))
				{
					this.string_1 = "$ten Sinh ư $canchi Niên Hành Canh $tuoi Tuế Sao $sao Tinh Quân";
				}
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00004254 File Offset: 0x00002454
		public ThietLapTinChu()
		{
		}

		// Token: 0x04000080 RID: 128
		private string string_0;

		// Token: 0x04000081 RID: 129
		private string string_1;
	}
}
