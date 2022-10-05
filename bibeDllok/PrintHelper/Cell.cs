using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace PrintHelper
{
	// Token: 0x0200000E RID: 14
	public class Cell
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000052E8 File Offset: 0x000034E8
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x000052FC File Offset: 0x000034FC
		public bool IsReadOnly
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00005310 File Offset: 0x00003510
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00005324 File Offset: 0x00003524
		public object ValType
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

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00005338 File Offset: 0x00003538
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x0000534C File Offset: 0x0000354C
		public object Value
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.object_1;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.object_1 = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00005360 File Offset: 0x00003560
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x00005374 File Offset: 0x00003574
		public string Formula
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
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00005388 File Offset: 0x00003588
		// (set) Token: 0x060000AA RID: 170 RVA: 0x0000539C File Offset: 0x0000359C
		public string FontName
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
		// (get) Token: 0x060000AB RID: 171 RVA: 0x000053B0 File Offset: 0x000035B0
		// (set) Token: 0x060000AC RID: 172 RVA: 0x000053C4 File Offset: 0x000035C4
		public float FontSize
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

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000AD RID: 173 RVA: 0x000053D8 File Offset: 0x000035D8
		// (set) Token: 0x060000AE RID: 174 RVA: 0x000053EC File Offset: 0x000035EC
		public bool FontBold
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.bool_1;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.bool_1 = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00005400 File Offset: 0x00003600
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x00005414 File Offset: 0x00003614
		public bool FontItalic
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.bool_2;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.bool_2 = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00005428 File Offset: 0x00003628
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x0000543C File Offset: 0x0000363C
		public string FColor
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

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00005450 File Offset: 0x00003650
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00005464 File Offset: 0x00003664
		public string BColor
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

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00005478 File Offset: 0x00003678
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x000054A4 File Offset: 0x000036A4
		public global::System.Drawing.Color ForeColor
		{
			get
			{
				if (string.IsNullOrEmpty(this.FColor))
				{
					return global::System.Drawing.Color.Black;
				}
				return global::System.Drawing.ColorTranslator.FromHtml(this.FColor);
			}
			set
			{
				this.FColor = global::System.Drawing.ColorTranslator.ToHtml(value);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000054C0 File Offset: 0x000036C0
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x000054EC File Offset: 0x000036EC
		public global::System.Drawing.Color BackColor
		{
			get
			{
				if (string.IsNullOrEmpty(this.BColor))
				{
					return global::System.Drawing.Color.White;
				}
				return global::System.Drawing.ColorTranslator.FromHtml(this.BColor);
			}
			set
			{
				this.BColor = global::System.Drawing.ColorTranslator.ToHtml(value);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00005508 File Offset: 0x00003708
		// (set) Token: 0x060000BA RID: 186 RVA: 0x0000551C File Offset: 0x0000371C
		public int HAlignment
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

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00005530 File Offset: 0x00003730
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00005544 File Offset: 0x00003744
		public int VAlignment
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

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00005558 File Offset: 0x00003758
		// (set) Token: 0x060000BE RID: 190 RVA: 0x0000556C File Offset: 0x0000376C
		public string MergeRange
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

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00005580 File Offset: 0x00003780
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x00005594 File Offset: 0x00003794
		public int ColSpan
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.int_2;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.int_2 = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x000055A8 File Offset: 0x000037A8
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x000055BC File Offset: 0x000037BC
		public int RowSpan
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.int_3;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.int_3 = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x000055D0 File Offset: 0x000037D0
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x000055E4 File Offset: 0x000037E4
		public global::PrintHelper.CellBorder BdrTop
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.cellBorder_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.cellBorder_0 = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x000055F8 File Offset: 0x000037F8
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x0000560C File Offset: 0x0000380C
		public global::PrintHelper.CellBorder BdrLeft
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.cellBorder_1;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.cellBorder_1 = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00005620 File Offset: 0x00003820
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00005634 File Offset: 0x00003834
		public global::PrintHelper.CellBorder BdrBottom
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.cellBorder_2;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.cellBorder_2 = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00005648 File Offset: 0x00003848
		// (set) Token: 0x060000CA RID: 202 RVA: 0x0000565C File Offset: 0x0000385C
		public global::PrintHelper.CellBorder BdrRight
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.cellBorder_3;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.cellBorder_3 = value;
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003D54 File Offset: 0x00001F54
		public Cell()
		{
		}

		// Token: 0x0400002C RID: 44
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool bool_0;

		// Token: 0x0400002D RID: 45
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private object object_0;

		// Token: 0x0400002E RID: 46
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private object object_1;

		// Token: 0x0400002F RID: 47
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_0;

		// Token: 0x04000030 RID: 48
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_1;

		// Token: 0x04000031 RID: 49
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private float float_0;

		// Token: 0x04000032 RID: 50
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool bool_1;

		// Token: 0x04000033 RID: 51
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool bool_2;

		// Token: 0x04000034 RID: 52
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_2;

		// Token: 0x04000035 RID: 53
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_3;

		// Token: 0x04000036 RID: 54
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int int_0;

		// Token: 0x04000037 RID: 55
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int int_1;

		// Token: 0x04000038 RID: 56
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_4;

		// Token: 0x04000039 RID: 57
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int int_2;

		// Token: 0x0400003A RID: 58
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int int_3;

		// Token: 0x0400003B RID: 59
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::PrintHelper.CellBorder cellBorder_0;

		// Token: 0x0400003C RID: 60
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::PrintHelper.CellBorder cellBorder_1;

		// Token: 0x0400003D RID: 61
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::PrintHelper.CellBorder cellBorder_2;

		// Token: 0x0400003E RID: 62
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::PrintHelper.CellBorder cellBorder_3;
	}
}
