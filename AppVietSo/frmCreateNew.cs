using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVietSo
{
    public partial class frmCreateNew : Form
    {
        bool _KhoaChung = false;
        public frmCreateNew(bool khoacung = false)
        {
            _KhoaChung = khoacung;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = new LongSoData();
            item.LSo = new LongSo();
            item.LSo.TenSo = textBox1.Text;
            item.LSo.FileName = "/FileUpload/" + textBox1.Text + ConstData.ExtentionsFile;
            item.LSo.LoaiSo = comboBox1.Text;
            item.LSo.ChuGiai = "SỚ CỦA THẦY";
            item.PageWidth = ShareFun.toPaperSize(470);
            item.PageHeight = ShareFun.toPaperSize(297);
            item.PageBreakRow = (int)numRow.Value;
            item.LgSo = new Dictionary<int, Dictionary<int, CellData>>();
            for (int i = 0; i < numCol.Value; i++)
            {
                item.LgSo.Add(i, new Dictionary<int, CellData>());
                for (int j = 0; j < numRow.Value; j++)
                {
                    item.LgSo[i].Add(j, new CellData());

                }
            }
            if (checkBox1.Checked)
            {
                item.KhoaCung = checkBox1.Checked;
                item.fsizeCN = 22;
                item.fsizeVN = 12;
            }
            else
            {
                item.fsizeCN = 12;
                item.fsizeVN = 12;
            }
            item.PagePaddingLeft = 10;
            item.PagePaddingRight = 10;
            item.PagePaddingTop = 10;
            item.PagePaddingBottom = 10;
            LongSoData.save(item);
            Util.NameLongSoHienTai = item.LSo.FileName;
            this.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numCol.Value = 8;
                numRow.Value = 8;
            }
            else
            {
                numCol.Value = 32;
                numRow.Value = 32;
            }
        }

        private void frmCreateNew_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = _KhoaChung;
            var data = LongSo.GetLongSos().Select(v => v.LoaiSo).Distinct().ToList();
            data.Add(LabelText.Get("SoCuaThay").ToUpper());
            comboBox1.DataSource = data;
            comboBox1.SelectedIndex = data.Count-1;
        }
    }
}
