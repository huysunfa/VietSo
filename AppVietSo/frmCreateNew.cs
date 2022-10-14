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
        public frmCreateNew()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = new LongSoData();
            item.LSo = new LongSo();
            item.LSo.TenSo = textBox1.Text;
            item.LSo.FileName = "/FileUpload/" + textBox1.Text + ConstData.ExtentionsFile;
            item.PageWidth = ShareFun.toPaperSize(470);
            item.PageHeight = ShareFun.toPaperSize(297);

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
                item.fsizeCN = 35;
                item.fsizeVN = 35;
            }
            else
            {
                item.fsizeCN = 12;
                item.fsizeVN = 12;
            }
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
    }
}
