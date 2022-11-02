using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
       public void LoadPageSize()
        {
            txtPageSize.Text = Util.LongSoHienTai.paperSize.PaperName;
            nmrTop.Value= (decimal)Util.LongSoHienTai.PagePaddingTop;
            nmrBottom.Value = (decimal)Util.LongSoHienTai.PagePaddingBottom;
            nmrLeft.Value = (decimal)Util.LongSoHienTai.PagePaddingLeft;
            nmrRight.Value = (decimal)Util.LongSoHienTai.PagePaddingRight;
        }
    }
}
