using System;

namespace PrintHelper
{
	// Token: 0x02000010 RID: 16
	public class ExcelPerson
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x000056E8 File Offset: 0x000038E8
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00005710 File Offset: 0x00003910
		public global::PrintHelper.Cell MaCell
		{
			get
			{
				if (this.cell_0 == null)
				{
					this.cell_0 = new global::PrintHelper.Cell();
				}
				return this.cell_0;
			}
			set
			{
				this.cell_0 = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00005724 File Offset: 0x00003924
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x0000574C File Offset: 0x0000394C
		public global::PrintHelper.Cell NameCell
		{
			get
			{
				if (this.cell_1 == null)
				{
					this.cell_1 = new global::PrintHelper.Cell();
				}
				return this.cell_1;
			}
			set
			{
				this.cell_1 = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00005760 File Offset: 0x00003960
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00005788 File Offset: 0x00003988
		public global::PrintHelper.Cell YearCell
		{
			get
			{
				if (this.cell_2 == null)
				{
					this.cell_2 = new global::PrintHelper.Cell();
				}
				return this.cell_2;
			}
			set
			{
				this.cell_2 = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000DC RID: 220 RVA: 0x0000579C File Offset: 0x0000399C
		// (set) Token: 0x060000DD RID: 221 RVA: 0x000057C4 File Offset: 0x000039C4
		public global::PrintHelper.Cell GenderCell
		{
			get
			{
				if (this.cell_3 == null)
				{
					this.cell_3 = new global::PrintHelper.Cell();
				}
				return this.cell_3;
			}
			set
			{
				this.cell_3 = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000DE RID: 222 RVA: 0x000057D8 File Offset: 0x000039D8
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00005800 File Offset: 0x00003A00
		public global::PrintHelper.Cell MenhCell
		{
			get
			{
				if (this.cell_4 == null)
				{
					this.cell_4 = new global::PrintHelper.Cell();
				}
				return this.cell_4;
			}
			set
			{
				this.cell_4 = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00005814 File Offset: 0x00003A14
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x0000583C File Offset: 0x00003A3C
		public global::PrintHelper.Cell SaoCell
		{
			get
			{
				if (this.cell_5 == null)
				{
					this.cell_5 = new global::PrintHelper.Cell();
				}
				return this.cell_5;
			}
			set
			{
				this.cell_5 = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00005850 File Offset: 0x00003A50
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x00005878 File Offset: 0x00003A78
		public global::PrintHelper.Cell AddressCell
		{
			get
			{
				if (this.cell_6 == null)
				{
					this.cell_6 = new global::PrintHelper.Cell();
				}
				return this.cell_6;
			}
			set
			{
				this.cell_6 = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x0000588C File Offset: 0x00003A8C
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x000058B4 File Offset: 0x00003AB4
		public global::PrintHelper.Cell NoteCell
		{
			get
			{
				if (this.cell_7 == null)
				{
					this.cell_7 = new global::PrintHelper.Cell();
				}
				return this.cell_7;
			}
			set
			{
				this.cell_7 = value;
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003D54 File Offset: 0x00001F54
		public ExcelPerson()
		{
		}

		// Token: 0x04000042 RID: 66
		private global::PrintHelper.Cell cell_0;

		// Token: 0x04000043 RID: 67
		private global::PrintHelper.Cell cell_1;

		// Token: 0x04000044 RID: 68
		private global::PrintHelper.Cell cell_2;

		// Token: 0x04000045 RID: 69
		private global::PrintHelper.Cell cell_3;

		// Token: 0x04000046 RID: 70
		private global::PrintHelper.Cell cell_4;

		// Token: 0x04000047 RID: 71
		private global::PrintHelper.Cell cell_5;

		// Token: 0x04000048 RID: 72
		private global::PrintHelper.Cell cell_6;

		// Token: 0x04000049 RID: 73
		private global::PrintHelper.Cell cell_7;
	}
}
