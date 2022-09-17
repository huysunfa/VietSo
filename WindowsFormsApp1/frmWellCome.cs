using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmWellCome : Form
    {
        public frmWellCome()
        {
            InitializeComponent();
        }
        public void OuputOK(String INPUT)
        {
            this.Invoke(new Action(() =>
            {
                label1.Text += "\n" + INPUT;
            }));
        }
        private void frmWellCome_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            Task.Run(() =>
            {
                OuputOK("1. Tải dữ liệu font chữ hán");

                loadFont.loadListFontCN();
                OuputOK("2.  Tải dữ liệu font chữ việt");
                loadFont.loadListFontVN();
                OuputOK("3.  Tải dữ liệu thư viện chữ hán");
                CNDictionary.loadDatabase();
                OuputOK("4.  Tải dữ liệu lòng sớ đang mở");
                Models.LongSo.GetLongSos();
                OuputOK("5.  DownloadFont");
                //loadFont.DownloadFont();
                //OuputOK("6. Mở phần mềm");
                this.Invoke(new Action(() =>
               {

                   var frm = new Form1();

                   // Thread.Sleep(500);
                   this.Hide();
                   frm.WindowState = FormWindowState.Maximized;
                   frm.ShowDialog();
                   this.Close();
               }));



            });
        }
        public void StartForm()
        {
            Application.Run(new Form1());
        }
    }
}
