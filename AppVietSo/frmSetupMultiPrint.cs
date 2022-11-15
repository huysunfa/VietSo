using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unvell.ReoGrid;
using unvell.ReoGrid.Print;

namespace AppVietSo
{
    public partial class frmSetupMultiPrint : Form
    {
        List<LongSo> ListPrint = new List<LongSo>();

        public frmSetupMultiPrint(List<LongSo> _ListPrint)
        {
            ListPrint = _ListPrint;
            InitializeComponent();
        }

        private void frmSetupMultiPrint_Load(object sender, EventArgs e)
        {
            foreach (var item in ListPrint)
            {
                dgvParent.Rows.Add(item.TenSo, item.FileName, "Xem");
            }
            loadTinchu();
            LoadPageSize();
            loadListFont();
            cbCanChuViet.SelectedItem = "PHẢI";
            cbfnameCN.SelectedItem = "CN-Khai";
            cbfnameVN.SelectedItem = "Times New Roman";

            cbfsizeCN.SelectedItem = 12 + "";
            cbfsizeVN.SelectedItem = 12 + "";

            cbfstyleCN.SelectedItem = "Đậm";
            cbfstyleVN.SelectedItem = "Đậm";

        }
        public void loadListFont()
        {

            var lastVN = cbfnameVN.Text;
            var lastCN = cbfnameCN.Text;

            cbfnameCN.Items.Clear();
            cbfnameVN.Items.Clear();

            foreach (var item in loadFont.loadListFontCN())
            {
                cbfnameCN.Items.Add(item);
            }
            foreach (var item in loadFont.loadListFontVN())
            {
                cbfnameVN.Items.Add(item);
            }
            cbfnameVN.Text = lastVN;
            cbfnameCN.Text = lastCN;
        }
        public void LoadPageSize()
        {
            PrinterSettings settings = new PrinterSettings();
            this.cbxPaperSize.Items.Clear();
            foreach (System.Drawing.Printing.PaperSize paperSize in settings.PaperSizes)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = paperSize.PaperName;
                item.Value = paperSize;
                this.cbxPaperSize.Items.Add(item);
            }
            label12.Text = "Máy in: " + settings.PrinterName;
            cbxPaperSize.Text = settings.DefaultPageSettings.PaperSize.PaperName;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmTinChu();
            frm.ShowDialog();
            loadTinchu();
        }
        void loadTinchu()
        {
            var SelectedSoNos = ActiveData.Get("@SelectedSoNos").Split(',');

            var dataTable = PersonBO.getList().Where(v => SelectedSoNos.Contains(v.ID)).ToList();
            dgvPerson.Rows.Clear();
            dgvPerson.Refresh();
            foreach (var item in dataTable)
            {
                dgvPerson.Rows.Add(item.DanhXung, item.FullName, item.NamSinh, item.NgayMat, item.GioiTinhDisplay);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSetupPaper fm = new FrmSetupPaper();
            fm.ShowDialog();
        }
        public static class MyPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);


        }

        private void btnPrintSetting_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {

                    MyPrinters.SetDefaultPrinter(printDialog.PrinterSettings.PrinterName);
                    LoadPageSize();

                }
            }
            catch (Exception ex)
            {
            }
        }
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
        private decimal toMM(int i)
        {
            return (decimal)Math.Round((double)i / 100.0 * 25.4, 0);
        }
        private void cbxPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbxPaperSize.SelectedItem != null)
                {
                    System.Drawing.Printing.PaperSize paperSize = (this.cbxPaperSize.SelectedItem as ComboboxItem).Value as System.Drawing.Printing.PaperSize;
                    int height = paperSize.Height;
                    int width = paperSize.Width;
                    this.setSize(this.toMM(height), this.toMM(width));
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow cur in dgvParent.Rows)
            {
                var FileName = cur.Cells["FileName"].Value + "";
                var TenSo = cur.Cells["LoaiSo"].Value + "";
                var item = new LongSo() { FileName = FileName, TenSo = TenSo, };
                {
                    Util.NameLongSoHienTai = "FileUpload/" + item.NameFileOnly;
                    Models.LongSo.loadDataLongSo();

                    System.Drawing.Printing.PaperSize paperSize = (this.cbxPaperSize.SelectedItem as ComboboxItem).Value as System.Drawing.Printing.PaperSize;
                    Util.LongSoHienTai.paperSize = paperSize;
                    Util.LongSoHienTai.PageWidth = paperSize.Height;
                    Util.LongSoHienTai.PageHeight = paperSize.Width;
                    Util.LongSoHienTai.PagePaddingBottom = (float)nmrBottom.Value;
                    Util.LongSoHienTai.PagePaddingTop = (float)nmrTop.Value;
                    Util.LongSoHienTai.PagePaddingLeft = (float)nmrLeft.Value;
                    Util.LongSoHienTai.PagePaddingRight = (float)nmrRight.Value;


                    var reogrid = new unvell.ReoGrid.ReoGridControl();
                    reogrid.CreateWorksheet("AXX");
                    ReoGridExtentions.ReLoad(reogrid, rbSongNgu.Checked, cbCanChuViet.Text,
                        InMaSo.Checked,
                             false,
                  rbChuViet.Checked,
                  rbChuHan.Checked,
                   false,
                    false,
                    cbfnameCN.Text,
                  cbfstyleCN.Text,
                  cbfsizeCN.Text,
                  cbfnameVN.Text,
                  cbfstyleVN.Text,
                  cbfsizeVN.Text
                        );

                    reogrid.CurrentWorksheet.SetRangeStyles(reogrid.CurrentWorksheet.UsedRange, new WorksheetRangeStyle
                    {
                        // style item flag
                        Flag = PlainStyleFlag.BackColor,
                        // style item
                        BackColor = Color.White,
                    });
                    var worksheet_0 = reogrid.CurrentWorksheet;

                    var top = Util.LongSoHienTai.PagePaddingTop;
                    var bottom = Util.LongSoHienTai.PagePaddingBottom;
                    var left = Util.LongSoHienTai.PagePaddingLeft;
                    var right = Util.LongSoHienTai.PagePaddingRight;

                    top = top / 25.4f;
                    bottom = bottom / 25.4f;
                    left = left / 25.4f;
                    right = right / 25.4f;
                    worksheet_0.SetColumnsWidth(0, 1, 0);
                    worksheet_0.SetColumnsWidth(worksheet_0.UsedRange.Cols, 1, 0);
                    worksheet_0.SetRowsHeight(0, 1, 0);
                    worksheet_0.SetRowsHeight(worksheet_0.UsedRange.Rows, 1, 0);
                    worksheet_0.PrintSettings.Margins = new PageMargins(top, bottom, left, right);
                  //  worksheet_0.SetWidthHeight(worksheet_0.UsedRange.Rows, worksheet_0.UsedRange.Cols, false);
                    PageSettings pageSettings = reogrid.CurrentWorksheet.PrintSettings.CreateSystemPageSettings();
                    pageSettings.PaperSize = paperSize;

                    pageSettings.Landscape = true;
                //    LongSo.saveToFile();
                    worksheet_0.PrintSettings.ApplySystemPageSettings(pageSettings);



                 var printsetting = ActiveData.Get("@SuDungCauHinhMayInMacDinh").ToBool();
                    var session = reogrid.CurrentWorksheet.CreatePrintSession(printsetting);
                    session.PrintDocument.DocumentName = item.TenSo;
                    session.PrintDocument.DefaultPageSettings.PaperSize = pageSettings.PaperSize;
                    session.PrintDocument.DefaultPageSettings.Landscape = pageSettings.Landscape;
                    session.PrintDocument.DefaultPageSettings.Margins = pageSettings.Margins;
                    
                    session.PrintDocument.PrinterSettings.DefaultPageSettings.PaperSize = pageSettings.PaperSize;
                    session.PrintDocument.PrinterSettings.DefaultPageSettings.Landscape = pageSettings.Landscape;
                    session.PrintDocument.PrinterSettings.DefaultPageSettings.Margins = pageSettings.Margins;
                    ReoGridExtentions.SetOnePage2(worksheet_0);

                    session.Print();
                   
                    //PrintPreviewDialog frmlog = new PrintPreviewDialog();
                    //frmlog.Document = session.PrintDocument;
                    //frmlog.Bounds = Screen.PrimaryScreen.Bounds;
                    //frmlog.ShowDialog();
                }
            }
        }

        private void xemTrướcBảnINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cur = dgvParent.CurrentRow;

            var FileName = cur.Cells["FileName"].Value + "";
            var TenSo = cur.Cells["LoaiSo"].Value + "";
            var item = new LongSo() { FileName = FileName, TenSo = TenSo, };
            {
                Util.NameLongSoHienTai = "FileUpload/" + item.NameFileOnly;
                Models.LongSo.loadDataLongSo();

                System.Drawing.Printing.PaperSize paperSize = (this.cbxPaperSize.SelectedItem as ComboboxItem).Value as System.Drawing.Printing.PaperSize;
                Util.LongSoHienTai.paperSize = paperSize;
                Util.LongSoHienTai.PageWidth = paperSize.Height;
                Util.LongSoHienTai.PageHeight = paperSize.Width;
                Util.LongSoHienTai.PagePaddingBottom = (float)nmrBottom.Value;
                Util.LongSoHienTai.PagePaddingTop = (float)nmrTop.Value;
                Util.LongSoHienTai.PagePaddingLeft = (float)nmrLeft.Value;
                Util.LongSoHienTai.PagePaddingRight = (float)nmrRight.Value;


                var reogrid = new unvell.ReoGrid.ReoGridControl();
                reogrid.CreateWorksheet("AXX");
                ReoGridExtentions.ReLoad(reogrid, rbSongNgu.Checked, cbCanChuViet.Text,
                    InMaSo.Checked,
                         false,
              rbChuViet.Checked,
              rbChuHan.Checked,
               false,
                false,
                cbfnameCN.Text,
              cbfstyleCN.Text,
              cbfsizeCN.Text,
              cbfnameVN.Text,
              cbfstyleVN.Text,
              cbfsizeVN.Text
                    );

                reogrid.CurrentWorksheet.SetRangeStyles(reogrid.CurrentWorksheet.UsedRange, new WorksheetRangeStyle
                {
                    // style item flag
                    Flag = PlainStyleFlag.BackColor,
                    // style item
                    BackColor = Color.White,
                });
                FrmPrintPreview frmPrintPreview = new FrmPrintPreview(reogrid.CurrentWorksheet, false);
                frmPrintPreview.ShowDialog(this);

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dgvParent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            xemTrướcBảnINToolStripMenuItem_Click(sender, e);
        }
    }
}
