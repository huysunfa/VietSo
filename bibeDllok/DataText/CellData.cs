using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace DataText
{
	// Token: 0x0200000D RID: 13
	public class CellData
	{
		// Token: 0x06000062 RID: 98 RVA: 0x00004254 File Offset: 0x00002454
		public CellData()
		{
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00005108 File Offset: 0x00003308
		public global::DataText.CellData Clone()
		{
			return new global::DataText.CellData
			{
				Value = this.Value,
				TextVN = this.TextVN,
				TextCN = this.TextCN,
				TextVNBMK = this.TextVNBMK,
				TextCNBMK = this.TextCNBMK,
				Rct = this.Rct,
				fnameCN = this.fnameCN,
				fsizeCN = this.fsizeCN,
				fstyleCN = this.fstyleCN,
				fnameVN = this.fnameVN,
				fsizeVN = this.fsizeVN,
				fstyleVN = this.fstyleVN,
				alignVN = this.alignVN,
				RowNo = this.RowNo,
				ColNo = this.ColNo,
				RowNoOrg = this.RowNoOrg,
				ColNoOrg = this.ColNoOrg
			};
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000051E8 File Offset: 0x000033E8
		public string Text(bool isVN)
		{
			if (isVN)
			{
				if (!string.IsNullOrEmpty(this.TextVNBMK))
				{
					return this.TextVNBMK;
				}
				return this.TextVN;
			}
			else
			{
				if (!string.IsNullOrEmpty(this.TextCNBMK))
				{
					return this.TextCNBMK;
				}
				if (!string.IsNullOrEmpty(this.TextCN))
				{
					return this.TextCN;
				}
				if (string.IsNullOrEmpty(this.TextVNBMK))
				{
					string textVN = this.TextVN;
					object value = this.Value;
					string nguCanh;
					if (value != null)
					{
						if ((nguCanh = value.ToString()) != null)
						{
							goto IL_6D;
						}
					}
					nguCanh = "";
					IL_6D:
					return global::DataText.LePhat.getCN(textVN, nguCanh);
				}
				string textVNBMK = this.TextVNBMK;
				object value2 = this.Value;
				string nguCanh2;
				if (value2 != null)
				{
					if ((nguCanh2 = value2.ToString()) != null)
					{
						goto IL_94;
					}
				}
				nguCanh2 = "";
				IL_94:
				return global::DataText.LePhat.getCN(textVNBMK, nguCanh2);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00005298 File Offset: 0x00003498
		// (set) Token: 0x06000066 RID: 102 RVA: 0x000052AC File Offset: 0x000034AC
		public object Value
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.object_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.object_0 = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000067 RID: 103 RVA: 0x000052C0 File Offset: 0x000034C0
		// (set) Token: 0x06000068 RID: 104 RVA: 0x000052D4 File Offset: 0x000034D4
		public string TextVN
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

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000069 RID: 105 RVA: 0x000052E8 File Offset: 0x000034E8
		// (set) Token: 0x0600006A RID: 106 RVA: 0x000052FC File Offset: 0x000034FC
		public string TextCN
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

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00005310 File Offset: 0x00003510
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00005324 File Offset: 0x00003524
		public string TextVNBMK
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_2;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_2 = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00005338 File Offset: 0x00003538
		// (set) Token: 0x0600006E RID: 110 RVA: 0x0000534C File Offset: 0x0000354C
		public string TextCNBMK
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_3;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_3 = value;
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00005360 File Offset: 0x00003560
		public int X()
		{
			return (int)this.Rct.X;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000537C File Offset: 0x0000357C
		public int Y()
		{
			return (int)this.Rct.Y;
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00005398 File Offset: 0x00003598
		// (set) Token: 0x06000072 RID: 114 RVA: 0x000053AC File Offset: 0x000035AC
		public string fnameCN
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_4;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_4 = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000053C0 File Offset: 0x000035C0
		// (set) Token: 0x06000074 RID: 116 RVA: 0x000053D4 File Offset: 0x000035D4
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

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000075 RID: 117 RVA: 0x000053E8 File Offset: 0x000035E8
		// (set) Token: 0x06000076 RID: 118 RVA: 0x000053FC File Offset: 0x000035FC
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

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00005410 File Offset: 0x00003610
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00005424 File Offset: 0x00003624
		public string fnameVN
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_5;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_5 = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00005438 File Offset: 0x00003638
		// (set) Token: 0x0600007A RID: 122 RVA: 0x0000544C File Offset: 0x0000364C
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

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00005460 File Offset: 0x00003660
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00005474 File Offset: 0x00003674
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

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00005488 File Offset: 0x00003688
		// (set) Token: 0x0600007E RID: 126 RVA: 0x0000549C File Offset: 0x0000369C
		public string alignVN
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_6;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_6 = value;
			}
		}

		// Token: 0x0400002E RID: 46
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private object object_0;

		// Token: 0x0400002F RID: 47
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_0;

		// Token: 0x04000030 RID: 48
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_1;

		// Token: 0x04000031 RID: 49
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_2;

		// Token: 0x04000032 RID: 50
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_3;

		// Token: 0x04000033 RID: 51
		[global::System.NonSerialized]
		public global::System.Drawing.RectangleF Rct;

		// Token: 0x04000034 RID: 52
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_4;

		// Token: 0x04000035 RID: 53
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private float float_0;

		// Token: 0x04000036 RID: 54
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int int_0;

		// Token: 0x04000037 RID: 55
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_5;

		// Token: 0x04000038 RID: 56
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private float float_1;

		// Token: 0x04000039 RID: 57
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int int_1;

		// Token: 0x0400003A RID: 58
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_6;

		// Token: 0x0400003B RID: 59
		[global::System.NonSerialized]
		public int RowNoOrg;

		// Token: 0x0400003C RID: 60
		[global::System.NonSerialized]
		public int ColNoOrg;

		// Token: 0x0400003D RID: 61
		[global::System.NonSerialized]
		public int RowNo;

		// Token: 0x0400003E RID: 62
		[global::System.NonSerialized]
		public int ColNo;
	}
}
