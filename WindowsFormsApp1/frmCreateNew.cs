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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
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
            item.LSo.FileName = "/FileUpload/" + textBox1.Text+ConstData.ExtentionsFile;
             item.PageWidth = ShareFun.toPaperSize(470);  
            item.PageHeight = ShareFun.toPaperSize(297);  
 
            item.LgSo = new Dictionary<int, Dictionary<int, CellData>>();
            for (int i = 0; i < 30; i++)
            {
                item.LgSo.Add(i, new Dictionary<int, CellData>());
                for (int j = 0; j < 30; j++)
                {
                    item.LgSo[i].Add(j, new CellData());

                }
            }
            LongSoData.save(item);
            Util.NameLongSoHienTai = item.LSo.FileName;
            this.Visible = false;
        }
    }
}
