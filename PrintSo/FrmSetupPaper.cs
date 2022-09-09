using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using PrintHelper;

namespace PrintSo
{
	// Token: 0x02000015 RID: 21
	public partial class FrmSetupPaper : Form
	{
		// Token: 0x06000121 RID: 289 RVA: 0x00016C0F File Offset: 0x00014E0F
		public FrmSetupPaper(PrDocument prD, RefreshPbx parentMethod)
		{
			this.prD = prD;
			this.parentMethod = parentMethod;
			this.InitializeComponent();
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00016C2C File Offset: 0x00014E2C
		private void FrmSetupPaper_Load(object sender, EventArgs e)
		{
			try
			{
				this.isLoading = true;
				this.nmrWidth.Value = this.toMM(this.prD.LoaiSoData.PageWidth);
				this.nmrHeight.Value = this.toMM(this.prD.LoaiSoData.PageHeight);
				this.nmrTop.Value = this.prD.LoaiSoData.PagePaddingTop;
				this.nmrBottom.Value = this.prD.LoaiSoData.PagePaddingBottom;
				this.nmrLeft.Value = this.prD.LoaiSoData.PagePaddingLeft;
				this.nmrRight.Value = this.prD.LoaiSoData.PagePaddingRight;
				foreach (object obj in this.prD.GetPaperSizes())
				{
					PaperSize paperSize = (PaperSize)obj;
					ComboboxItem comboboxItem = new ComboboxItem(paperSize.PaperName, paperSize);
					this.cbxPaperSize.Items.Add(comboboxItem);
					if (paperSize.Height == this.prD.LoaiSoData.PageWidth && paperSize.Width == this.prD.LoaiSoData.PageHeight)
					{
						this.cbxPaperSize.SelectedItem = comboboxItem;
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
			finally
			{
				this.isLoading = false;
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00016DE0 File Offset: 0x00014FE0
		private int toPaperSize(decimal d)
		{
			return (int)Math.Round(d / 25.4m * 100m, 0);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00016E0D File Offset: 0x0001500D
		private decimal toMM(int i)
		{
			return (decimal)Math.Round((double)i / 100.0 * 25.4, 0);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00016E30 File Offset: 0x00015030
		private void nmr_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (!this.isLoading)
				{
					this.prD.LoaiSoData.PageWidth = this.toPaperSize(this.nmrWidth.Value);
					this.prD.LoaiSoData.PageHeight = this.toPaperSize(this.nmrHeight.Value);
					this.prD.LoaiSoData.PagePaddingTop = this.nmrTop.Value;
					this.prD.LoaiSoData.PagePaddingBottom = this.nmrBottom.Value;
					this.prD.LoaiSoData.PagePaddingLeft = this.nmrLeft.Value;
					this.prD.LoaiSoData.PagePaddingRight = this.nmrRight.Value;
					this.parentMethod();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00016F1C File Offset: 0x0001511C
		private void setSize(decimal width, decimal height)
		{
			try
			{
				this.nmrWidth.Value = width;
				this.nmrHeight.Value = height;
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00016F5C File Offset: 0x0001515C
		private void btnPrintSetting_Click(object sender, EventArgs e)
		{
			try
			{
				PrintDialog printDialog = new PrintDialog();
				if (printDialog.ShowDialog() == DialogResult.OK)
				{
					int height = printDialog.PrinterSettings.DefaultPageSettings.PaperSize.Height;
					int width = printDialog.PrinterSettings.DefaultPageSettings.PaperSize.Width;
					this.prD.PrinterSettings(printDialog.PrinterSettings);
					foreach (object obj in this.cbxPaperSize.Items)
					{
						ComboboxItem comboboxItem = (ComboboxItem)obj;
						if (comboboxItem.Text == this.prD.PrintDoc().DefaultPageSettings.PaperSize.PaperName)
						{
							this.cbxPaperSize.SelectedItem = comboboxItem;
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0001704C File Offset: 0x0001524C
		private void cbxPaperSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.cbxPaperSize.SelectedItem != null)
				{
					PaperSize paperSize = (this.cbxPaperSize.SelectedItem as ComboboxItem).Value as PaperSize;
					int height = paperSize.Height;
					int width = paperSize.Width;
					this.setSize(this.toMM(height), this.toMM(width));
					this.prD.ChangePaperSize(paperSize);
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x04000119 RID: 281
		private bool isLoading;

		// Token: 0x0400011A RID: 282
		private RefreshPbx parentMethod;

		// Token: 0x0400011B RID: 283
		private PrDocument prD;
	}
}
