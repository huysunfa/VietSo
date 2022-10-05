using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DataText
{
	// Token: 0x0200001E RID: 30
	public class LongSoData
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060001EA RID: 490 RVA: 0x0000A438 File Offset: 0x00008638
		// (set) Token: 0x060001EB RID: 491 RVA: 0x0000A44C File Offset: 0x0000864C
		public string fnameCN
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060001EC RID: 492 RVA: 0x0000A460 File Offset: 0x00008660
		// (set) Token: 0x060001ED RID: 493 RVA: 0x0000A474 File Offset: 0x00008674
		public float fsizeCN
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.float_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.float_0 = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060001EE RID: 494 RVA: 0x0000A488 File Offset: 0x00008688
		// (set) Token: 0x060001EF RID: 495 RVA: 0x0000A49C File Offset: 0x0000869C
		public int fstyleCN
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.int_0 = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x0000A4B0 File Offset: 0x000086B0
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x0000A4C4 File Offset: 0x000086C4
		public string fnameVN
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_1 = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x0000A4D8 File Offset: 0x000086D8
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x0000A4EC File Offset: 0x000086EC
		public float fsizeVN
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.float_1;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.float_1 = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x0000A500 File Offset: 0x00008700
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x0000A514 File Offset: 0x00008714
		public int fstyleVN
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.int_1;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.int_1 = value;
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00004254 File Offset: 0x00002454
		public LongSoData()
		{
		}

		// Token: 0x04000059 RID: 89
		public string LoaiSo;

		// Token: 0x0400005A RID: 90
		public string TenSo;

		// Token: 0x0400005B RID: 91
		public string ChuGiai;

		// Token: 0x0400005C RID: 92
		public string Language;

		// Token: 0x0400005D RID: 93
		public string SongNguAlign;

		// Token: 0x0400005E RID: 94
		public string VNAlign;

		// Token: 0x0400005F RID: 95
		public global::DataText.ThietLapTinChu TinChu;

		// Token: 0x04000060 RID: 96
		public int PageHeight;

		// Token: 0x04000061 RID: 97
		public int PageWidth;

		// Token: 0x04000062 RID: 98
		public decimal PagePaddingTop;

		// Token: 0x04000063 RID: 99
		public decimal PagePaddingBottom;

		// Token: 0x04000064 RID: 100
		public decimal PagePaddingLeft;

		// Token: 0x04000065 RID: 101
		public decimal PagePaddingRight;

		// Token: 0x04000066 RID: 102
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_0;

		// Token: 0x04000067 RID: 103
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private float float_0;

		// Token: 0x04000068 RID: 104
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int int_0;

		// Token: 0x04000069 RID: 105
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_1;

		// Token: 0x0400006A RID: 106
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private float float_1;

		// Token: 0x0400006B RID: 107
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int int_1;

		// Token: 0x0400006C RID: 108
		public global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> LgSo;
	}
}
