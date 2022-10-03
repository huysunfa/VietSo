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
    public partial class frmThemMatChu : Form
    {
        static string chuViet = null;
        public frmThemMatChu(string _chuViet)
        {
            chuViet = _chuViet;
            InitializeComponent();
        }

        private void frmThemMatChu_Load(object sender, EventArgs e)
        {
            textBox1.Text = chuViet;
            richTextBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();

        }

        private void frmThemMatChu_FormClosed(object sender, FormClosedEventArgs e)
        {
          
            var chuhan = richTextBox1.Text+"";
            chuhan = chuhan.Replace("\n","");
            chuhan = chuhan.Replace("\r", "");
            chuhan = chuhan.Replace("\t", "");
            chuhan = chuhan.Trim();

            if ( string.IsNullOrEmpty(chuhan))
            {
                return;
            }
            if (!CNDictionary.database.ContainsKey(chuViet))
            {
                CNDictionary.database.Add(chuViet, new List<string>());
            }
            CNDictionary.database[chuViet].Add(chuhan);
            ActiveData.Update(chuViet, chuhan);

        }
    }
}
