using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsConvertBibe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles("input");
            foreach (var item in files)
            {
                var txt = File.ReadAllText(item);
                var giaima = Security.GiaiMa(txt);
                var mahoa = CryptoServiceProvider.EncryptPassword(giaima);
                File.WriteAllText("output/" + item.Split('\\').LastOrDefault().Split('.').FirstOrDefault()+".hc", mahoa);
            }

            MessageBox.Show("convert ok "+files.Length +" FILE");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var txt = richTextBox1.Text;
            var giaima = Security.GiaiMa(txt);
            richTextBox1.Text = giaima;
        }
    }
}
