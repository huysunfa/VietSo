using System;
using System.Collections.Generic;

namespace DataText
{
	// Token: 0x02000026 RID: 38
	public class UserSettingPrint
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600027F RID: 639 RVA: 0x0000B96C File Offset: 0x00009B6C
		// (set) Token: 0x06000280 RID: 640 RVA: 0x0000B980 File Offset: 0x00009B80
		public int ZoomIndex
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000281 RID: 641 RVA: 0x0000B994 File Offset: 0x00009B94
		// (set) Token: 0x06000282 RID: 642 RVA: 0x0000B9C0 File Offset: 0x00009BC0
		public float MarginT
		{
			get
			{
				if (this.float_0 == 0f)
				{
					this.float_0 = 0.4f;
				}
				return this.float_0;
			}
			set
			{
				this.float_0 = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000283 RID: 643 RVA: 0x0000B9D4 File Offset: 0x00009BD4
		// (set) Token: 0x06000284 RID: 644 RVA: 0x0000BA00 File Offset: 0x00009C00
		public float MarginB
		{
			get
			{
				if (this.float_1 == 0f)
				{
					this.float_1 = 0.35f;
				}
				return this.float_1;
			}
			set
			{
				this.float_1 = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000285 RID: 645 RVA: 0x0000BA14 File Offset: 0x00009C14
		// (set) Token: 0x06000286 RID: 646 RVA: 0x0000BA40 File Offset: 0x00009C40
		public float MarginL
		{
			get
			{
				if (this.float_2 == 0f)
				{
					this.float_2 = 0.6f;
				}
				return this.float_2;
			}
			set
			{
				this.float_2 = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000287 RID: 647 RVA: 0x0000BA54 File Offset: 0x00009C54
		// (set) Token: 0x06000288 RID: 648 RVA: 0x0000BA80 File Offset: 0x00009C80
		public float MarginR
		{
			get
			{
				if (this.float_3 == 0f)
				{
					this.float_3 = 0.5f;
				}
				return this.float_3;
			}
			set
			{
				this.float_3 = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000289 RID: 649 RVA: 0x0000BA94 File Offset: 0x00009C94
		// (set) Token: 0x0600028A RID: 650 RVA: 0x0000BAA8 File Offset: 0x00009CA8
		public bool PageIsShowPageNo
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600028B RID: 651 RVA: 0x0000BABC File Offset: 0x00009CBC
		// (set) Token: 0x0600028C RID: 652 RVA: 0x0000BAD0 File Offset: 0x00009CD0
		public bool PageIsFooter
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0000BAE4 File Offset: 0x00009CE4
		// (set) Token: 0x0600028E RID: 654 RVA: 0x0000BAF8 File Offset: 0x00009CF8
		public string PageTitleLeft
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

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0000BB0C File Offset: 0x00009D0C
		// (set) Token: 0x06000290 RID: 656 RVA: 0x0000BB20 File Offset: 0x00009D20
		public string PageTitleCenter
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000BB34 File Offset: 0x00009D34
		// (set) Token: 0x06000292 RID: 658 RVA: 0x0000BB48 File Offset: 0x00009D48
		public string PageTitleRight
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000293 RID: 659 RVA: 0x0000BB5C File Offset: 0x00009D5C
		// (set) Token: 0x06000294 RID: 660 RVA: 0x0000BB70 File Offset: 0x00009D70
		public string PaperName
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000BB84 File Offset: 0x00009D84
		// (set) Token: 0x06000296 RID: 662 RVA: 0x0000BB98 File Offset: 0x00009D98
		public int Rows
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000BBAC File Offset: 0x00009DAC
		// (set) Token: 0x06000298 RID: 664 RVA: 0x0000BBC0 File Offset: 0x00009DC0
		public int Cols
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0000BBD4 File Offset: 0x00009DD4
		// (set) Token: 0x0600029A RID: 666 RVA: 0x0000BBE8 File Offset: 0x00009DE8
		public decimal FontSize
		{
			get
			{
				return this.decimal_0;
			}
			set
			{
				this.decimal_0 = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600029B RID: 667 RVA: 0x0000BBFC File Offset: 0x00009DFC
		// (set) Token: 0x0600029C RID: 668 RVA: 0x0000BC10 File Offset: 0x00009E10
		public string FontName
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600029D RID: 669 RVA: 0x0000BC24 File Offset: 0x00009E24
		// (set) Token: 0x0600029E RID: 670 RVA: 0x0000BC38 File Offset: 0x00009E38
		public bool SpaceFamily
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600029F RID: 671 RVA: 0x0000BC4C File Offset: 0x00009E4C
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x0000BC74 File Offset: 0x00009E74
		public global::System.Collections.Generic.List<int> ColHiden
		{
			get
			{
				if (this.list_0 == null)
				{
					this.list_0 = new global::System.Collections.Generic.List<int>();
				}
				return this.list_0;
			}
			set
			{
				this.list_0 = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x0000BC88 File Offset: 0x00009E88
		// (set) Token: 0x060002A2 RID: 674 RVA: 0x0000BCB0 File Offset: 0x00009EB0
		public global::System.Collections.Generic.Dictionary<int, ushort> ColWidth
		{
			get
			{
				if (this.dictionary_0 == null)
				{
					this.dictionary_0 = new global::System.Collections.Generic.Dictionary<int, ushort>();
				}
				return this.dictionary_0;
			}
			set
			{
				this.dictionary_0 = value;
			}
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000BCC4 File Offset: 0x00009EC4
		public UserSettingPrint()
		{
		}

		// Token: 0x04000084 RID: 132
		private int int_0;

		// Token: 0x04000085 RID: 133
		private float float_0;

		// Token: 0x04000086 RID: 134
		private float float_1;

		// Token: 0x04000087 RID: 135
		private float float_2;

		// Token: 0x04000088 RID: 136
		private float float_3;

		// Token: 0x04000089 RID: 137
		private bool bool_0 = true;

		// Token: 0x0400008A RID: 138
		private bool bool_1;

		// Token: 0x0400008B RID: 139
		private bool bool_2;

		// Token: 0x0400008C RID: 140
		private string string_0;

		// Token: 0x0400008D RID: 141
		private string string_1;

		// Token: 0x0400008E RID: 142
		private string string_2;

		// Token: 0x0400008F RID: 143
		private string string_3;

		// Token: 0x04000090 RID: 144
		private int int_1;

		// Token: 0x04000091 RID: 145
		private int int_2;

		// Token: 0x04000092 RID: 146
		private decimal decimal_0;

		// Token: 0x04000093 RID: 147
		private string string_4;

		// Token: 0x04000094 RID: 148
		private global::System.Collections.Generic.List<int> list_0;

		// Token: 0x04000095 RID: 149
		private global::System.Collections.Generic.Dictionary<int, ushort> dictionary_0;
	}
}
