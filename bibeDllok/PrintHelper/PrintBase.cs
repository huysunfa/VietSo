using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataModel;
using DataText;

namespace PrintHelper
{
	// Token: 0x02000015 RID: 21
	public abstract class PrintBase
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00009114 File Offset: 0x00007314
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00009128 File Offset: 0x00007328
		public global::DataText.Family Fml
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.family_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.family_0 = value;
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000913C File Offset: 0x0000733C
		public PrintBase()
		{
			this.printDocument_0.DefaultPageSettings.Landscape = true;
			this.printDocument_0.PrintPage -= this.printDocument_0_PrintPage;
			this.printDocument_0.PrintPage += this.printDocument_0_PrintPage;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000091A4 File Offset: 0x000073A4
		public global::System.Drawing.Printing.PrinterSettings.PaperSizeCollection GetPaperSizes()
		{
			return this.printDocument_0.PrinterSettings.PaperSizes;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000091C4 File Offset: 0x000073C4
		public global::System.Drawing.Printing.PrintDocument PrintDoc()
		{
			return this.printDocument_0;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000091D8 File Offset: 0x000073D8
		public void ChangePaperSize(global::System.Drawing.Printing.PaperSize ps)
		{
			this.printDocument_0.DefaultPageSettings.PaperSize = ps;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000091F8 File Offset: 0x000073F8
		public void PrinterSettings(global::System.Drawing.Printing.PrinterSettings ps)
		{
			this.printDocument_0.PrinterSettings = ps;
		}

		// Token: 0x060001CA RID: 458
		protected abstract int GetPaperHeight();

		// Token: 0x060001CB RID: 459
		protected abstract int GetPaperWidth();

		// Token: 0x060001CC RID: 460 RVA: 0x00009214 File Offset: 0x00007414
		public void Print()
		{
			if (this.printDocument_0.DefaultPageSettings.PaperSize.Height != this.GetPaperWidth() || this.printDocument_0.DefaultPageSettings.PaperSize.Width != this.GetPaperHeight())
			{
				global::System.Windows.Forms.MessageBox.Show(string.Concat(new string[]
				{
					"In sẽ có thể bị lỗi, Xin hãy làm",
					global::System.Environment.NewLine,
					"1: Hãy kiểm tra lại thiết lập khổ giấy và máy in",
					global::System.Environment.NewLine,
					"2: Hoặc gọi hỗ trợ 098 2116 022"
				}), global::DataModel.Util.domain, global::System.Windows.Forms.MessageBoxButtons.OK, global::System.Windows.Forms.MessageBoxIcon.Hand);
			}
			this.printDocument_0.Print();
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000092A8 File Offset: 0x000074A8
		private void printDocument_0_PrintPage(object sender, global::System.Drawing.Printing.PrintPageEventArgs e)
		{
			this.Draw(e.Graphics, true);
		}

		// Token: 0x060001CE RID: 462
		public abstract void Draw(global::System.Drawing.Graphics g, bool isPrint = false);

		// Token: 0x060001CF RID: 463
		public abstract global::System.Drawing.Bitmap PreView();

		// Token: 0x060001D0 RID: 464 RVA: 0x000092C4 File Offset: 0x000074C4
		public global::System.Drawing.RectangleF RangeSelected(global::System.Collections.Generic.List<global::DataText.CellData> cld)
		{
			global::System.Drawing.RectangleF rectangleF = default(global::System.Drawing.RectangleF);
			if (cld.Count == 1)
			{
				rectangleF = cld[0].Rct;
			}
			else
			{
				foreach (global::DataText.CellData cellData in cld)
				{
					if (!(rectangleF == default(global::System.Drawing.RectangleF)))
					{
						rectangleF = global::System.Drawing.RectangleF.Union(rectangleF, cellData.Rct);
					}
					else
					{
						rectangleF = cellData.Rct;
					}
				}
			}
			return rectangleF;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00009354 File Offset: 0x00007554
		public void DrawRangeSelected(global::System.Windows.Forms.PictureBox pcB, global::System.Collections.Generic.List<global::DataText.CellData> recL)
		{
			if (recL != null && pcB != null && recL.Count != 0)
			{
				global::System.Drawing.Bitmap image = new global::System.Drawing.Bitmap(pcB.Image);
				global::System.Drawing.RectangleF value = this.RangeSelected(recL);
				this.method_0(ref image, global::System.Drawing.Rectangle.Round(value));
				pcB.Image = image;
				return;
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000939C File Offset: 0x0000759C
		public void DrawRangeSelected(global::System.Windows.Forms.PictureBox pcB, global::System.Drawing.RectangleF rec)
		{
			if (!(rec == default(global::System.Drawing.RectangleF)) && pcB != null)
			{
				global::System.Drawing.Bitmap image = new global::System.Drawing.Bitmap(pcB.Image);
				this.method_0(ref image, global::System.Drawing.Rectangle.Round(rec));
				pcB.Image = image;
				return;
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000093E0 File Offset: 0x000075E0
		private void method_0(ref global::System.Drawing.Bitmap bitmap_0, global::System.Drawing.Rectangle rectangle_0)
		{
			if (rectangle_0.Width <= 0)
			{
				return;
			}
			if (rectangle_0.Height <= 0)
			{
				return;
			}
			for (int i = rectangle_0.Top - 1; i <= rectangle_0.Top + 1; i++)
			{
				if (0 < i & i < bitmap_0.Height)
				{
					int j = rectangle_0.Left + 2;
					while (j <= rectangle_0.Right + 1 && j < bitmap_0.Width)
					{
						global::System.Drawing.Color color = bitmap_0.GetPixel(j, i);
						color = this.method_1(color);
						bitmap_0.SetPixel(j, i, color);
						j++;
					}
				}
			}
			for (int i = rectangle_0.Bottom - 1; i <= rectangle_0.Bottom + 1; i++)
			{
				if (i < bitmap_0.Height)
				{
					int j = rectangle_0.Left + 2;
					while (j <= rectangle_0.Right - 4 && j < bitmap_0.Width)
					{
						global::System.Drawing.Color color = bitmap_0.GetPixel(j, i);
						color = this.method_1(color);
						bitmap_0.SetPixel(j, i, color);
						j++;
					}
				}
			}
			if (rectangle_0.Height >= 3)
			{
				int i;
				int j;
				for (j = rectangle_0.Left - 1; j <= rectangle_0.Left + 1; j++)
				{
					if (0 < j & j < bitmap_0.Width)
					{
						for (i = rectangle_0.Top - 1; i <= rectangle_0.Bottom + 1; i++)
						{
							if (0 < i)
							{
								if (i >= bitmap_0.Height)
								{
									break;
								}
								global::System.Drawing.Color color = bitmap_0.GetPixel(j, i);
								color = this.method_1(color);
								bitmap_0.SetPixel(j, i, color);
							}
						}
					}
				}
				j = rectangle_0.Right - 1;
				while (j <= rectangle_0.Right + 1 && j < bitmap_0.Width)
				{
					i = rectangle_0.Top + 2;
					while (i <= rectangle_0.Bottom + 2 && i < bitmap_0.Height)
					{
						global::System.Drawing.Color color = bitmap_0.GetPixel(j, i);
						color = this.method_1(color);
						bitmap_0.SetPixel(j, i, color);
						i++;
					}
					j++;
				}
				i = rectangle_0.Bottom - 3;
				if (i < bitmap_0.Height && rectangle_0.Right - 2 < bitmap_0.Width)
				{
					for (j = rectangle_0.Right - 1; j <= rectangle_0.Right + 1; j++)
					{
						if (j < bitmap_0.Width)
						{
							global::System.Drawing.Color color = bitmap_0.GetPixel(j, i);
							color = this.method_1(color);
							bitmap_0.SetPixel(j, i, color);
						}
					}
				}
				j = rectangle_0.Right - 2;
				if (j < bitmap_0.Width && rectangle_0.Bottom - 2 < bitmap_0.Height)
				{
					i = rectangle_0.Bottom - 2;
					while (i <= rectangle_0.Bottom + 2 && i < bitmap_0.Height)
					{
						global::System.Drawing.Color color = bitmap_0.GetPixel(j, i);
						color = this.method_1(color);
						bitmap_0.SetPixel(j, i, color);
						i++;
					}
				}
				j = rectangle_0.Right + 2;
				if (j < bitmap_0.Width && rectangle_0.Bottom - 2 < bitmap_0.Height)
				{
					i = rectangle_0.Bottom - 2;
					while (i <= rectangle_0.Bottom + 2 && i < bitmap_0.Height)
					{
						global::System.Drawing.Color color = bitmap_0.GetPixel(j, i);
						color = this.method_1(color);
						bitmap_0.SetPixel(j, i, color);
						i++;
					}
				}
				return;
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x000096FC File Offset: 0x000078FC
		private global::System.Drawing.Color method_1(global::System.Drawing.Color color_0)
		{
			if (color_0.B == 0xF5)
			{
				return global::System.Drawing.Color.WhiteSmoke;
			}
			return global::System.Drawing.Color.FromArgb(color_0.ToArgb() ^ 0xFFFFFF);
		}

		// Token: 0x0400006D RID: 109
		private global::System.Drawing.Printing.PrintDocument printDocument_0 = new global::System.Drawing.Printing.PrintDocument();

		// Token: 0x0400006E RID: 110
		public float scaleFactor = 1f;

		// Token: 0x0400006F RID: 111
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::DataText.Family family_0;
	}
}
