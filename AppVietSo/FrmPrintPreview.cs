using AppVietSo.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using unvell.ReoGrid;
using unvell.ReoGrid.Print;

namespace AppVietSo
{
    public partial class FrmPrintPreview : Form
    {
        bool _KhoaCung = false;
        int _PageNumber = 1;
        public FrmPrintPreview(Worksheet   _worksheet_0 , bool KhoaCung, int PageNumber = 1)
        {
            this.worksheet_0 = _worksheet_0.Clone();
            this.worksheet_0.PrintSettings = (PrintSettings)_worksheet_0.PrintSettings.Clone();
            this.worksheet_0 = _worksheet_0;
            _KhoaCung = KhoaCung;
            _PageNumber = PageNumber;
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

       

        // Token: 0x06000086 RID: 134 RVA: 0x000056C4 File Offset: 0x000038C4
        public void ChangeWidthSize(Worksheet sheet, bool check)
        {
            if (Util.LongSoHienTai.KhoaCung)
            {
                return;
            }
            for (int i = 1; i < sheet.RowCount; i++)
            {
                sheet.RowHeaders[i].IsAutoHeight = check;

            }
            for (int i = 1; i < sheet.ColumnCount; i++)
            {
                sheet.ColumnHeaders[i].IsAutoWidth = check;

            }
            if (check == false)
            {
                return;
            }
            sheet = this.worksheet_0;

            int TotalWidth = 0;
            for (int i = 1; i < sheet.ColumnCount; i++)
            {
                var oldW = sheet.GetColumnWidth(i);
                sheet.AutoFitColumnWidth(i, check);

                var newW = sheet.GetColumnWidth(i);

                if (newW < oldW)
                {
                    newW = oldW;
                    sheet.SetColumnsWidth(i, 1, oldW);

                }
                TotalWidth += newW;
            }
            //int TotalHeight = 0;
            //for (int i = 1; i < sheet.RowCount; i = i + 1)
            //{
            //    var oldW = sheet.GetRowHeight(i);
            //    sheet.AutoFitRowHeight(i, check);
            //    var newW = sheet.GetRowHeight(i);
            //    if (newW < oldW)
            //    {
            //        newW = oldW;
            //        sheet.SetRowsHeight(i, 1, oldW);

            //    }
            //    TotalHeight += newW;

            //}
            var tile = (float)TotalWidth / (float)Util.LongSoHienTai.PageWidth;
            var TotalHeight = (float)Util.LongSoHienTai.PageHeight * tile;
            int row = (sheet.UsedRange.EndRow - 2);
            var old = TotalHeight / row;
            sheet.SetRowsHeight(1, row, (ushort)old);

            var free = TotalHeight - (row * (int)old);
            var colend = (ushort)(sheet.GetRowHeight(row + 2) + free);
            sheet.SetRowsHeight(row + 1, 1, colend);

        }
        private void FrmPrintPreview_Load(object sender, EventArgs e)
        {

 
 

            this.bool_0 = true;
            this.splitContainer1.SplitterDistance = this.cbxPrinter.Width + this.cbxPrinter.Left * 2;
            this.method_0();
             this.nmrTop.Value = (decimal)Util.LongSoHienTai.PagePaddingTop;
            this.nmrBottom.Value = (decimal)Util.LongSoHienTai.PagePaddingBottom;
            this.nmrLeft.Value = (decimal)Util.LongSoHienTai.PagePaddingLeft;
            this.nmrRight.Value = (decimal)Util.LongSoHienTai.PagePaddingRight;


            this.printSession_0 = this.worksheet_0.CreatePrintSession();
            this.printPreviewControl1.Document = this.printSession_0.PrintDocument;
            this.rbtnLandscape.Checked = this.worksheet_0.PrintSettings.Landscape;
            this.rbtnPortrait.Checked = !this.rbtnLandscape.Checked;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                var name = PrinterSettings.InstalledPrinters[i];
                this.cbxPrinter.Items.Add(PrinterSettings.InstalledPrinters[i]);
                if (name == new PrinterSettings().PrinterName)
                {
                    this.cbxPrinter.SelectedItem = name;
                }
            }
            this.cbxPaperSize.DisplayMember = "PaperName";
            foreach (object obj in new PrinterSettings().PaperSizes)
            {
                System.Drawing.Printing.PaperSize paperSize = (System.Drawing.Printing.PaperSize)obj;
                this.cbxPaperSize.Items.Add(paperSize);
                if (this.worksheet_0.PrintSettings.PaperName == paperSize.PaperName)
                {
                    this.cbxPaperSize.SelectedItem = paperSize;
                }
            }


            this.bool_0 = false;
            checkBox1.Checked = _KhoaCung;
            nmrPage.Value = _PageNumber;
            this.printPreviewControl1.StartPage = (int)this.nmrPage.Value - 1;
            this.method_1();
 
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

            if (this.cbxPrinter.SelectedItem != null)
            {
                if (this.printPreviewControl1.Document.PrinterSettings.IsValid)
                {
                    if (this.rbtnAllPage.Checked)
                    {
                        //this.worksheet_0.PrintSettings.FromPage = 0;
                        //this.worksheet_0.PrintSettings.ToPage = 0;
                    }
                    else if (!this.rbtnPage.Checked)
                    {
                        if (this.rbtnCurPage.Checked)
                        {
                            //	this.worksheet_0.PrintSettings.FromPage = (int)this.nmrPage.Value;
                            //	this.worksheet_0.PrintSettings.ToPage = (int)this.nmrPage.Value;
                        }
                    }
                    else
                    {
                        //	this.worksheet_0.PrintSettings.FromPage = (int)this.nmrPageFrom.Value;
                        //	this.worksheet_0.PrintSettings.ToPage = (int)this.nmrPageTo.Value;
                    }
                    this.printSession_0.PrintDocument.PrinterSettings.Copies = (short)numericUpDown1.Value;
                    this.printSession_0.Print();
                }
                else
                {
                    MessageBox.Show("Máy in không hợp lệ, xin kiểm tra lại máy in.");
                }
            }

            {
                ////	this.worksheet_0.PrintSettings.FromPage = 0;
                //	this.worksheet_0.PrintSettings.ToPage = 0;
            }
        }

        // Token: 0x0600008A RID: 138 RVA: 0x00005B64 File Offset: 0x00003D64
        private void cbxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {

            double zoom = double.Parse(this.cbxZoom.Text.Replace("%", "")) / 100.0;
            this.printPreviewControl1.Zoom = zoom;

        }

        // Token: 0x0600008B RID: 139 RVA: 0x00005BC0 File Offset: 0x00003DC0
        private void btnZoomOut_Click(object sender, EventArgs e)
        {

            if (0 < this.cbxZoom.SelectedIndex)
            {
                this.cbxZoom.SelectedIndex = this.cbxZoom.SelectedIndex - 1;
            }

        }

        // Token: 0x0600008C RID: 140 RVA: 0x00005C0C File Offset: 0x00003E0C
        private void btnZoomIn_Click(object sender, EventArgs e)
        {

            if (this.cbxZoom.SelectedIndex < this.cbxZoom.Items.Count - 1)
            {
                this.cbxZoom.SelectedIndex = this.cbxZoom.SelectedIndex + 1;
            }

        }

        // Token: 0x0600008D RID: 141 RVA: 0x00005C6C File Offset: 0x00003E6C
        private void cbxPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.cbxPrinter.SelectedItem != null)
            {
                this.worksheet_0.PrintSettings.PrinterName = (string)this.cbxPrinter.SelectedItem;
                this.printPreviewControl1.Document.PrinterSettings.PrinterName = this.worksheet_0.PrintSettings.PrinterName;
                this.method_3();
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

            }
        }

        // Token: 0x06000091 RID: 145 RVA: 0x00005D60 File Offset: 0x00003F60
        private void method_1()
        {
            PageSettings pageSettings = this.worksheet_0.PrintSettings.CreateSystemPageSettings();
            if (this.cbxPaperSize.SelectedItem != null)
            {
                System.Drawing.Printing.PaperSize paperSize = this.cbxPaperSize.SelectedItem as System.Drawing.Printing.PaperSize;
                pageSettings.PaperSize = paperSize;
            }
            pageSettings.Landscape = this.rbtnLandscape.Checked;
            Util.LongSoHienTai.PagePaddingTop = (float)this.nmrTop.Value;
            Util.LongSoHienTai.PagePaddingBottom = (float)this.nmrBottom.Value;
            Util.LongSoHienTai.PagePaddingLeft = (float)this.nmrLeft.Value;
            Util.LongSoHienTai.PagePaddingRight = (float)this.nmrRight.Value;
            LongSo.saveToFile();
            this.worksheet_0.PrintSettings.ApplySystemPageSettings(pageSettings);
            this.method_2();
        }

        // Token: 0x06000092 RID: 146 RVA: 0x00005E44 File Offset: 0x00004044
        private void method_2()
        {

            worksheet_0.SetColumnsWidth(0, 1, 0);
            worksheet_0.SetColumnsWidth(worksheet_0.UsedRange.Cols, 1, 0);
            worksheet_0.SetRowsHeight(0, 1, 0);
            worksheet_0.SetRowsHeight(worksheet_0.UsedRange.Rows, 1, 0);
            var top = Util.LongSoHienTai.PagePaddingTop;
            var bottom = Util.LongSoHienTai.PagePaddingBottom;
            var left = Util.LongSoHienTai.PagePaddingLeft;
            var right = Util.LongSoHienTai.PagePaddingRight;

            top = top / 25.4f;
            bottom = bottom / 25.4f;
            left = left / 25.4f;
            right = right / 25.4f;

            worksheet_0.PrintSettings.Margins = new PageMargins(top, bottom, left, right);
            //this.worksheet_0.SetWidthHeight(worksheet_0.UsedRange.Rows, worksheet_0.UsedRange.Cols, false);



            //var hientai = this.worksheet_0.GetTotalWidth();
            //if (worksheet_0.PrintSettings.Landscape)
            //{
            //       var KhoGiay = Util.InchToPixel(this.worksheet_0.PrintSettings.PaperHeight, 100f)- ShareFun.toPaperSize((decimal)Util.LongSoHienTai.PagePaddingRight) - ShareFun.toPaperSize((decimal)Util.LongSoHienTai.PagePaddingLeft);

            //    var Scaling = KhoGiay / hientai;
            //    this.worksheet_0.PrintSettings.PageScaling = (float)Scaling;
            //}
            //else
            //{
            //    var KhoGiay = Util.InchToPixel(this.worksheet_0.PrintSettings.PaperWidth, 100f);

            //    var Scaling = Math.Round(KhoGiay / hientai, 1);
            //    if (Scaling > 1)
            //    {
            //        Scaling = 1;
            //    }
            //    this.worksheet_0.PrintSettings.PageScaling = (float)(Scaling - 0.05);
            //}
        ReoGridExtentions.SetOnePage2(worksheet_0);
            //var height = Util.LongSoHienTai.PageHeight / worksheet_0.UsedRange.Rows;
            //worksheet_0.SetRowsHeight(1, worksheet_0.UsedRange.Rows, (ushort)height);
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

            }
        }

        // Token: 0x06000097 RID: 151 RVA: 0x00005FA0 File Offset: 0x000041A0
        private void cbxPageNumber_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //this.worksheet_0.PrintSettings.ShowPageNo = this.cbxPageNumber.Checked;
                this.method_3();
            }
            catch (Exception exception_)
            {

            }
        }

        // Token: 0x06000098 RID: 152 RVA: 0x00005FE8 File Offset: 0x000041E8
        private void btnCustomTitle_Click(object sender, EventArgs e)
        {
            try
            {
                FrmHeaderFooter frmHeaderFooter = new FrmHeaderFooter();
                //frmHeaderFooter.PageTitleLeft = this.worksheet_0.PrintSettings.PageTitleLeft;
                //frmHeaderFooter.PageTitleCenter = this.worksheet_0.PrintSettings.PageTitleCenter;
                //frmHeaderFooter.PageTitleRight = this.worksheet_0.PrintSettings.PageTitleRight;
                //frmHeaderFooter.IsFooter = this.worksheet_0.PrintSettings.IsFooter;
                if (frmHeaderFooter.ShowDialog(this) == DialogResult.OK)
                {
                    //	this.worksheet_0.PrintSettings.PageTitleLeft = frmHeaderFooter.PageTitleLeft;
                    //	this.worksheet_0.PrintSettings.PageTitleCenter = frmHeaderFooter.PageTitleCenter;
                    //	this.worksheet_0.PrintSettings.PageTitleRight = frmHeaderFooter.PageTitleRight;
                    //	this.worksheet_0.PrintSettings.IsFooter = frmHeaderFooter.IsFooter;
                    this.method_3();
                }
            }
            catch (Exception exception_)
            {

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
                //this.worksheet_0.PrintSettings.FromPage = 0;
                //this.worksheet_0.PrintSettings.ToPage = 0;
            }
            catch (Exception exception_)
            {

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.method_3();

        }
    }
}
