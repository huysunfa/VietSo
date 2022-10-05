using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using unvell.ReoGrid;
using unvell.ReoGrid.Print;

namespace PrintDoc
{
	// Token: 0x0200000E RID: 14
	public partial class FrmPrintPreview : Form
	{
		// Token: 0x06000082 RID: 130 RVA: 0x0000563C File Offset: 0x0000383C
		public FrmPrintPreview()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00005658 File Offset: 0x00003858
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00005670 File Offset: 0x00003870
		public int ZoomIndex
		{
			get
			{
				return this.cbxZoom.SelectedIndex;
			}
			set
			{
				if (0 <= value)
				{
					this.cbxZoom.SelectedIndex = value;
					return;
				}
				this.cbxZoom.SelectedIndex = 5;
			}
		}

		// Token: 0x17000008 RID: 8
		// (set) Token: 0x06000085 RID: 133 RVA: 0x0000569C File Offset: 0x0000389C
		public Worksheet Sheet
		{
			set
			{
				this.worksheet_0 = value;
				this.worksheet_0.PrintSettings.PageOrder = 1;
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000056C4 File Offset: 0x000038C4
		private void FrmPrintPreview_Load(object sender, EventArgs e)
		{
			try
			{
				this.bool_0 = true;
				this.splitContainer1.SplitterDistance = this.cbxPrinter.Width + this.cbxPrinter.Left * 2;
				this.method_0();
				this.cbxPageNumber.Checked = this.worksheet_0.PrintSettings.ShowPageNo;
				PageMargins margins = this.worksheet_0.PrintSettings.Margins;
				this.nmrTop.Value = (decimal)(margins.Top * 25.4f);
				this.nmrBottom.Value = (decimal)(margins.Bottom * 25.4f);
				this.nmrLeft.Value = (decimal)(margins.Left * 25.4f);
				this.nmrRight.Value = (decimal)(margins.Right * 25.4f);
				this.printSession_0 = this.worksheet_0.CreatePrintSession();
				this.printPreviewControl1.Document = this.printSession_0.PrintDocument;
				this.rbtnLandscape.Checked = this.worksheet_0.PrintSettings.Landscape;
				this.rbtnPortrait.Checked = !this.rbtnLandscape.Checked;
				for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
				{
					Class5 @class = new Class5(PrinterSettings.InstalledPrinters[i], i);
					this.cbxPrinter.Items.Add(@class);
					if (@class.String_0 == new PrinterSettings().PrinterName)
					{
						this.cbxPrinter.SelectedItem = @class;
					}
				}
				this.cbxPaperSize.DisplayMember = "PaperName";
				foreach (object obj in new PrinterSettings().PaperSizes)
				{
					PaperSize paperSize = (PaperSize)obj;
					this.cbxPaperSize.Items.Add(paperSize);
					if (this.worksheet_0.PrintSettings.PaperName == paperSize.PaperName)
					{
						this.cbxPaperSize.SelectedItem = paperSize;
					}
				}
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
			finally
			{
				this.bool_0 = false;
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005948 File Offset: 0x00003B48
		public void ChangeColPageBreak(int newColIndex)
		{
			this.int_0 = newColIndex;
			this.method_2();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005964 File Offset: 0x00003B64
		private void method_0()
		{
			this.nmrPage.Maximum = this.worksheet_0.PrintPageCounts;
			this.nmrPageFrom.Maximum = this.nmrPage.Maximum;
			this.nmrPageTo.Maximum = this.nmrPage.Maximum;
			this.totalPage.Text = string.Format("/{0} trang", this.nmrPage.Maximum);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000059E0 File Offset: 0x00003BE0
		private void btnPrint_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.cbxPrinter.SelectedItem != null)
				{
					if (this.printPreviewControl1.Document.PrinterSettings.IsValid)
					{
						if (this.rbtnAllPage.Checked)
						{
							this.worksheet_0.PrintSettings.FromPage = 0;
							this.worksheet_0.PrintSettings.ToPage = 0;
						}
						else if (!this.rbtnPage.Checked)
						{
							if (this.rbtnCurPage.Checked)
							{
								this.worksheet_0.PrintSettings.FromPage = (int)this.nmrPage.Value;
								this.worksheet_0.PrintSettings.ToPage = (int)this.nmrPage.Value;
							}
						}
						else
						{
							this.worksheet_0.PrintSettings.FromPage = (int)this.nmrPageFrom.Value;
							this.worksheet_0.PrintSettings.ToPage = (int)this.nmrPageTo.Value;
						}
						this.printSession_0.Print();
					}
					else
					{
						Class6.smethod_1("Máy in không hợp lệ, xin kiểm tra lại máy in.");
					}
				}
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
			finally
			{
				this.worksheet_0.PrintSettings.FromPage = 0;
				this.worksheet_0.PrintSettings.ToPage = 0;
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00005B64 File Offset: 0x00003D64
		private void cbxZoom_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				double zoom = double.Parse(this.cbxZoom.Text.Replace("%", "")) / 100.0;
				this.printPreviewControl1.Zoom = zoom;
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005BC0 File Offset: 0x00003DC0
		private void btnZoomOut_Click(object sender, EventArgs e)
		{
			try
			{
				if (0 < this.cbxZoom.SelectedIndex)
				{
					this.cbxZoom.SelectedIndex = this.cbxZoom.SelectedIndex - 1;
				}
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00005C0C File Offset: 0x00003E0C
		private void btnZoomIn_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.cbxZoom.SelectedIndex < this.cbxZoom.Items.Count - 1)
				{
					this.cbxZoom.SelectedIndex = this.cbxZoom.SelectedIndex + 1;
				}
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005C6C File Offset: 0x00003E6C
		private void cbxPrinter_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.cbxPrinter.SelectedItem != null)
				{
					this.worksheet_0.PrintSettings.PrinterName = ((Class5)this.cbxPrinter.SelectedItem).String_0;
					this.printPreviewControl1.Document.PrinterSettings.PrinterName = this.worksheet_0.PrintSettings.PrinterName;
					this.method_3();
				}
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00005CF0 File Offset: 0x00003EF0
		private void cbxPaperSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.method_1();
				this.method_3();
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00005CF0 File Offset: 0x00003EF0
		private void rbtnPortrait_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.method_1();
				this.method_3();
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00005D24 File Offset: 0x00003F24
		private void nmrTop_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (!this.bool_0)
				{
					this.method_1();
					this.method_3();
				}
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00005D60 File Offset: 0x00003F60
		private void method_1()
		{
			PageSettings pageSettings = this.worksheet_0.PrintSettings.CreateSystemPageSettings();
			if (this.cbxPaperSize.SelectedItem != null)
			{
				PaperSize paperSize = this.cbxPaperSize.SelectedItem as PaperSize;
				pageSettings.PaperSize = paperSize;
			}
			pageSettings.Landscape = this.rbtnLandscape.Checked;
			float num = (float)this.nmrTop.Value / 25.4f;
			float num2 = (float)this.nmrBottom.Value / 25.4f;
			float num3 = (float)this.nmrLeft.Value / 25.4f;
			float num4 = (float)this.nmrRight.Value / 25.4f;
			pageSettings.Margins = new PageMargins(num, num2, num3, num4);
			this.worksheet_0.PrintSettings.ApplySystemPageSettings(pageSettings);
			this.method_2();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00005E44 File Offset: 0x00004044
		private void method_2()
		{
			this.worksheet_0.PrintSettings.PageScaling = 1f;
			this.worksheet_0.AutoSplitPage();
			if (1 < this.int_0 && 1 < this.worksheet_0.ColumnPageBreaks.Count)
			{
				int num = this.worksheet_0.ColumnPageBreaks[1];
				if (num == this.int_0)
				{
					this.worksheet_0.AutoSetMaximumScaleForPages();
				}
				this.worksheet_0.ChangeColumnPageBreak(num, this.int_0, true);
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00005EC8 File Offset: 0x000040C8
		private void method_3()
		{
			this.method_0();
			this.printPreviewControl1.InvalidatePreview();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00005EE8 File Offset: 0x000040E8
		private void nmrPage_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				this.printPreviewControl1.StartPage = (int)this.nmrPage.Value - 1;
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00005F2C File Offset: 0x0000412C
		private void btnFirstPage_Click(object sender, EventArgs e)
		{
			try
			{
				this.nmrPage.Value = 1m;
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00005F64 File Offset: 0x00004164
		private void btnLastPage_Click(object sender, EventArgs e)
		{
			try
			{
				this.nmrPage.Value = this.nmrPage.Maximum;
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00005FA0 File Offset: 0x000041A0
		private void cbxPageNumber_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.worksheet_0.PrintSettings.ShowPageNo = this.cbxPageNumber.Checked;
				this.method_3();
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00005FE8 File Offset: 0x000041E8
		private void btnCustomTitle_Click(object sender, EventArgs e)
		{
			try
			{
				FrmHeaderFooter frmHeaderFooter = new FrmHeaderFooter();
				frmHeaderFooter.PageTitleLeft = this.worksheet_0.PrintSettings.PageTitleLeft;
				frmHeaderFooter.PageTitleCenter = this.worksheet_0.PrintSettings.PageTitleCenter;
				frmHeaderFooter.PageTitleRight = this.worksheet_0.PrintSettings.PageTitleRight;
				frmHeaderFooter.IsFooter = this.worksheet_0.PrintSettings.IsFooter;
				if (frmHeaderFooter.ShowDialog(this) == DialogResult.OK)
				{
					this.worksheet_0.PrintSettings.PageTitleLeft = frmHeaderFooter.PageTitleLeft;
					this.worksheet_0.PrintSettings.PageTitleCenter = frmHeaderFooter.PageTitleCenter;
					this.worksheet_0.PrintSettings.PageTitleRight = frmHeaderFooter.PageTitleRight;
					this.worksheet_0.PrintSettings.IsFooter = frmHeaderFooter.IsFooter;
					this.method_3();
				}
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000060D8 File Offset: 0x000042D8
		private void rbtnPage_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.nmrPageFrom.Enabled = this.rbtnPage.Checked;
				this.nmrPageTo.Enabled = this.rbtnPage.Checked;
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000612C File Offset: 0x0000432C
		private void nmrPageFrom_ValueChanged(object sender, EventArgs e)
		{
			this.rbtnPage_CheckedChanged(null, null);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000612C File Offset: 0x0000432C
		private void nmrPageTo_ValueChanged(object sender, EventArgs e)
		{
			this.rbtnPage_CheckedChanged(null, null);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004D1C File Offset: 0x00002F1C
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006144 File Offset: 0x00004344
		private void FrmPrintPreview_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.worksheet_0.PrintSettings.FromPage = 0;
				this.worksheet_0.PrintSettings.ToPage = 0;
			}
			catch (Exception exception_)
			{
				Class6.smethod_0(exception_);
			}
		}

		// Token: 0x04000041 RID: 65
		private Worksheet worksheet_0;

		// Token: 0x04000042 RID: 66
		private bool bool_0;

		// Token: 0x04000043 RID: 67
		private const float float_0 = 25.4f;

		// Token: 0x04000044 RID: 68
		private int int_0;

		// Token: 0x04000045 RID: 69
		private PrintSession printSession_0;
	}
}
