using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
	public abstract class PrintBase
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x000091BC File Offset: 0x000073BC
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x000091D0 File Offset: 0x000073D0
		public Family Fml { get; set; }

		// Token: 0x060001C5 RID: 453 RVA: 0x000091E4 File Offset: 0x000073E4
		public PrintBase()
		{
 		}

 		public global::System.Drawing.Printing.PrinterSettings.PaperSizeCollection GetPaperSizes()
		{
			return this.printdoc.PrinterSettings.PaperSizes;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000926C File Offset: 0x0000746C
		public global::System.Drawing.Printing.PrintDocument PrintDoc()
		{
			return this.printdoc;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00009280 File Offset: 0x00007480
		public void ChangePaperSize(global::System.Drawing.Printing.PaperSize ps)
		{
			this.printdoc.DefaultPageSettings.PaperSize = ps;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000092A0 File Offset: 0x000074A0
		public void PrinterSettings(global::System.Drawing.Printing.PrinterSettings ps)
		{
			this.printdoc.PrinterSettings = ps;
		}

		// Token: 0x060001CA RID: 458
		protected abstract int GetPaperHeight();

		// Token: 0x060001CB RID: 459
		protected abstract int GetPaperWidth();

		// Token: 0x060001CC RID: 460 RVA: 0x000092BC File Offset: 0x000074BC
		public void Print()
		{
			if (this.printdoc.DefaultPageSettings.PaperSize.Height != this.GetPaperWidth() || this.printdoc.DefaultPageSettings.PaperSize.Width != this.GetPaperHeight())
			{
				global::System.Windows.Forms.MessageBox.Show(string.Concat(new string[]
				{
					"In sẽ có thể bị lỗi, Xin hãy làm",
					global::System.Environment.NewLine,
					"1: Hãy kiểm tra lại thiết lập khổ giấy và máy in",
					global::System.Environment.NewLine,
					"2: Hoặc gọi hỗ trợ 098 2116 022"
				}), Util.domain, global::System.Windows.Forms.MessageBoxButtons.OK, global::System.Windows.Forms.MessageBoxIcon.Hand);
			}
			this.printdoc.Print();
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00009354 File Offset: 0x00007554
		private void DrawA3(object A_1, global::System.Drawing.Printing.PrintPageEventArgs A_2)
		{
			this.Draw(A_2.Graphics, true);
		}

		// Token: 0x060001CE RID: 462
		public abstract void Draw(global::System.Drawing.Graphics g, bool isPrint = false);

		// Token: 0x060001CF RID: 463
		public abstract global::System.Drawing.Bitmap PreView();

		// Token: 0x060001D0 RID: 464 RVA: 0x00009370 File Offset: 0x00007570
		public global::System.Drawing.RectangleF RangeSelected(global::System.Collections.Generic.List<CellData> cld)
		{
			global::System.Drawing.RectangleF rectangleF = default(global::System.Drawing.RectangleF);
			if (cld.Count == 1)
			{
				rectangleF = cld[0].Rct;
			}
			else
			{
				foreach (CellData cellData in cld)
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

		// Token: 0x060001D1 RID: 465 RVA: 0x00009400 File Offset: 0x00007600
		public void DrawRangeSelected(global::System.Windows.Forms.PictureBox pcB, global::System.Collections.Generic.List<CellData> recL)
		{
			if (recL != null && pcB != null && recL.Count != 0)
			{
				global::System.Drawing.Bitmap image = new global::System.Drawing.Bitmap(pcB.Image);
				global::System.Drawing.RectangleF value = this.RangeSelected(recL);
				this.RFID467(ref image, global::System.Drawing.Rectangle.Round(value));
				pcB.Image = image;
				return;
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00009448 File Offset: 0x00007648
		public void DrawRangeSelected(global::System.Windows.Forms.PictureBox pcB, global::System.Drawing.RectangleF rec)
		{
			if (!(rec == default(global::System.Drawing.RectangleF)) && pcB != null)
			{
				global::System.Drawing.Bitmap image = new global::System.Drawing.Bitmap(pcB.Image);
				this.RFID467(ref image, global::System.Drawing.Rectangle.Round(rec));
				pcB.Image = image;
				return;
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000948C File Offset: 0x0000768C
		private void RFID467(ref global::System.Drawing.Bitmap A_1, global::System.Drawing.Rectangle A_2)
		{
			if (A_2.Width <= 0)
			{
				return;
			}
			if (A_2.Height <= 0)
			{
				return;
			}
			for (int i = A_2.Top - 1; i <= A_2.Top + 1; i++)
			{
				if (0 < i & i < A_1.Height)
				{
					int j = A_2.Left + 2;
					while (j <= A_2.Right + 1 && j < A_1.Width)
					{
						global::System.Drawing.Color color = A_1.GetPixel(j, i);
						color = this.FUNA2(color);
						A_1.SetPixel(j, i, color);
						j++;
					}
				}
			}
			for (int i = A_2.Bottom - 1; i <= A_2.Bottom + 1; i++)
			{
				if (i < A_1.Height)
				{
					int j = A_2.Left + 2;
					while (j <= A_2.Right - 4 && j < A_1.Width)
					{
						global::System.Drawing.Color color = A_1.GetPixel(j, i);
						color = this.FUNA2(color);
						A_1.SetPixel(j, i, color);
						j++;
					}
				}
			}
			if (A_2.Height >= 3)
			{
				int i;
				int j;
				for (j = A_2.Left - 1; j <= A_2.Left + 1; j++)
				{
					if (0 < j & j < A_1.Width)
					{
						for (i = A_2.Top - 1; i <= A_2.Bottom + 1; i++)
						{
							if (0 < i)
							{
								if (i >= A_1.Height)
								{
									break;
								}
								global::System.Drawing.Color color = A_1.GetPixel(j, i);
								color = this.FUNA2(color);
								A_1.SetPixel(j, i, color);
							}
						}
					}
				}
				j = A_2.Right - 1;
				while (j <= A_2.Right + 1 && j < A_1.Width)
				{
					i = A_2.Top + 2;
					while (i <= A_2.Bottom + 2 && i < A_1.Height)
					{
						global::System.Drawing.Color color = A_1.GetPixel(j, i);
						color = this.FUNA2(color);
						A_1.SetPixel(j, i, color);
						i++;
					}
					j++;
				}
				i = A_2.Bottom - 3;
				if (i < A_1.Height && A_2.Right - 2 < A_1.Width)
				{
					for (j = A_2.Right - 1; j <= A_2.Right + 1; j++)
					{
						if (j < A_1.Width)
						{
							global::System.Drawing.Color color = A_1.GetPixel(j, i);
							color = this.FUNA2(color);
							A_1.SetPixel(j, i, color);
						}
					}
				}
				j = A_2.Right - 2;
				if (j < A_1.Width && A_2.Bottom - 2 < A_1.Height)
				{
					i = A_2.Bottom - 2;
					while (i <= A_2.Bottom + 2 && i < A_1.Height)
					{
						global::System.Drawing.Color color = A_1.GetPixel(j, i);
						color = this.FUNA2(color);
						A_1.SetPixel(j, i, color);
						i++;
					}
				}
				j = A_2.Right + 2;
				if (j < A_1.Width && A_2.Bottom - 2 < A_1.Height)
				{
					i = A_2.Bottom - 2;
					while (i <= A_2.Bottom + 2 && i < A_1.Height)
					{
						global::System.Drawing.Color color = A_1.GetPixel(j, i);
						color = this.FUNA2(color);
						A_1.SetPixel(j, i, color);
						i++;
					}
				}
				return;
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x000097A8 File Offset: 0x000079A8
		public  Color FUNA2(global::System.Drawing.Color A_1)
		{
			if (A_1.B == 0xF5)
			{
				return global::System.Drawing.Color.WhiteSmoke;
			}
			return global::System.Drawing.Color.FromArgb(A_1.ToArgb() ^ 0xFFFFFF);
		}

		// Token: 0x0400006D RID: 109
		private global::System.Drawing.Printing.PrintDocument printdoc = new global::System.Drawing.Printing.PrintDocument();

		// Token: 0x0400006E RID: 110
		public float scaleFactor = 1f;

		// Token: 0x0400006F RID: 111
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private  Family ffamily;
	}
}
