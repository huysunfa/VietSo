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
                dgvParent.Rows.Add(item.TenSo, item.FileName);
            }
            loadTinchu();
            LoadPageSize();
            loadListFont();
            cbCanChuViet.SelectedItem = "PHẢI";
            cbfnameCN.SelectedItem = "CN-Khai";
            cbfnameVN.SelectedItem = "Times New Roman";

            cbfsizeCN.SelectedItem = 12+"";
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
            foreach (PaperSize paperSize in settings.PaperSizes)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng đang update ...........");
        }
    }
}
