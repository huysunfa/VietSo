using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVietSo
{
    public partial class frmWellCome : Form
    {
        public frmWellCome()
        {
            InitializeComponent();
        }

        private void frmWellCome_Load(object sender, EventArgs e)
        {
            
                SplashScreen.CloseForm();
                this.Activate();
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent; //color you want it to be background on hover


            var ImgBG = LabelText.Get("BackgroundImage");
            ImgBG = ImgBG.Replace(@"\",@"/");
            var filename = ImgBG.Split('/').LastOrDefault();
            var path = "Data/" + filename;
            if (!File.Exists(path))
            {
                using (WebClient c = new WebClient())
                {
                    c.DownloadFile(ImgBG, path);
                }
            }
        
            this.BackgroundImage = Image.FromFile(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            this.Hide();
            var form2 = new Form1();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
