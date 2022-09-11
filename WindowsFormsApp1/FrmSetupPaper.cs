using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Controls;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    // Token: 0x02000015 RID: 21
    public partial class FrmSetupPaper : Form
    {
        // Token: 0x06000121 RID: 289 RVA: 0x00016C0F File Offset: 0x00014E0F
        public FrmSetupPaper()
        {
            isLoading = true;
            this.InitializeComponent();
        }


        // Token: 0x06000122 RID: 290 RVA: 0x00016C2C File Offset: 0x00014E2C
        private void FrmSetupPaper_Load(object sender, EventArgs e)
        {
            label12.Text = Util.LongSoHienTai.PrinterName;
            PrinterSettings settings = new PrinterSettings();
            foreach (PaperSize paperSize in settings.PaperSizes)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = paperSize.PaperName.ToUpper().Trim();
                item.Value = paperSize;
                this.cbxPaperSize.Items.Add(item);
            }


            this.nmrWidth.Value = this.toMM(Util.LongSoHienTai.PageWidth);
            this.nmrHeight.Value = this.toMM(Util.LongSoHienTai.PageHeight);
            this.nmrTop.Value = this.toMM((int)Util.LongSoHienTai.PagePaddingTop);
            this.nmrBottom.Value = this.toMM((int)Util.LongSoHienTai.PagePaddingBottom);
            this.nmrLeft.Value = this.toMM((int)Util.LongSoHienTai.PagePaddingLeft);
            this.nmrRight.Value = this.toMM((int)Util.LongSoHienTai.PagePaddingRight);
            foreach (PaperSize paperSize in settings.PaperSizes)
            {

                if (paperSize.Height == Util.LongSoHienTai.PageWidth && paperSize.Width == Util.LongSoHienTai.PageHeight)
                {
                    this.cbxPaperSize.Text = paperSize.PaperName.ToUpper().Trim();
                    break;
                }
            }
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedItem = "DỌC";

            if (Util.LongSoHienTai.PageHeight > Util.LongSoHienTai.PageWidth)
            {
                comboBox1.SelectedItem = "NGANG";
            }
            isLoading = false;

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
                    Util.LongSoHienTai.PageWidth = this.toPaperSize(this.nmrWidth.Value);
                    Util.LongSoHienTai.PageHeight = this.toPaperSize(this.nmrHeight.Value);
                    Util.LongSoHienTai.PagePaddingTop = this.toPaperSize(this.nmrTop.Value);  
                    Util.LongSoHienTai.PagePaddingBottom = this.toPaperSize(this.nmrBottom.Value);  
                    Util.LongSoHienTai.PagePaddingLeft = this.toPaperSize(this.nmrLeft.Value); 
                    Util.LongSoHienTai.PagePaddingRight = this.toPaperSize(this.nmrRight.Value);  
                    LongSoData.save(Util.LongSoHienTai);
                }
            }
            catch (Exception ex)
            {
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
            }
        }

        // Token: 0x06000127 RID: 295 RVA: 0x00016F5C File Offset: 0x0001515C
        private void btnPrintSetting_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    int height = printDialog.PrinterSettings.DefaultPageSettings.PaperSize.Height;
                    int width = printDialog.PrinterSettings.DefaultPageSettings.PaperSize.Width;
                    Util.LongSoHienTai.PrinterName = printDialog.PrinterSettings.PrinterName;
                    label12.Text = Util.LongSoHienTai.PrinterName;
                    LongSoData.save(Util.LongSoHienTai);
                }
            }
            catch (Exception ex)
            {
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
                }
            }
            catch (Exception ex)
            {
            }
        }

        // Token: 0x04000119 RID: 281
        private bool isLoading;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isLoading)
            {
                Util.LongSoHienTai.PageLandscape = false;

                if (Util.LongSoHienTai.PageHeight >= Util.LongSoHienTai.PageWidth)
                {
                    var tmp = Util.LongSoHienTai.PageHeight;
                    Util.LongSoHienTai.PageHeight = Util.LongSoHienTai.PageWidth;
                    Util.LongSoHienTai.PageWidth = tmp;
                }

                if (comboBox1.SelectedItem.ToString() == "NGANG")
                {
                    var tmp = Util.LongSoHienTai.PageHeight;
                    Util.LongSoHienTai.PageHeight = Util.LongSoHienTai.PageWidth;
                    Util.LongSoHienTai.PageWidth = tmp;
                }

                LongSoData.save(Util.LongSoHienTai);

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
