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
            chuViet = chuViet + "";
            chuViet = chuViet.ToLower();
            richTextBox1.Focus();
            richTextBox1.Font = new Font("CN-Khai", 20);

            if (CNDictionary.database.ContainsKey(chuViet))
            {

                var cache = ActiveData.Get(chuViet);
                var input = CNDictionary.database[chuViet].Distinct().OrderByDescending(v => (v == cache ? 1 : 0));
                int stt = 0;
                foreach (var it in input)
                {

                    Button textBox1 = new Button();
                    textBox1.Location = new Point(10, 10);
                    textBox1.Text = it;
                    var size = it.Length * 50;
                    if (size < 70)
                    {
                        size = 70;
                    }
                    textBox1.Size = new Size(size, 40);
                    textBox1.Font = new Font("CN-Khai",20);
                    textBox1.Click += new EventHandler(DynamicButton_Click);

                    textBox1.BackColor = Color.LightYellow;
 
                    textBox1.Tag = chuViet;


                    flowLayoutPanel1.Controls.Add(textBox1);
                    stt++;


                }
               

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();

        }
        private void DynamicButton_Click(object sender, EventArgs e)
        {
           
            var name = (Button)sender;
            string TextVN = name.Tag.ToString();
            string TextCN = name.Text;
            richTextBox1.Text = TextCN;


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
