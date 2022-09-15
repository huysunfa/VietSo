using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class frmKeyInfo : Form
    {
        public frmKeyInfo()
        {
            InitializeComponent();
        }

        private void frmKeyInfo_Load(object sender, EventArgs e)
        {
            var key = CheckKey.LocalKey();
            var data = CheckKey.FullinfoKey(key);
            var HoTen = data.Rows[0]["HoTen"] + "";
            var SDT = data.Rows[0]["SDT"] + "";
            var DiaChi = data.Rows[0]["DiaChi"] + "";

            lbLicence.Text = key;
            txtHoTen.Text = HoTen;
            txtSDT.Text = SDT;
            txtDiaChi.Text = DiaChi;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var key = CheckKey.LocalKey();

            var HoTen = txtHoTen.Text;
            var SDT = txtSDT.Text;
            var DiaChi = txtDiaChi.Text;

            CheckKey.UpdateKeyInfoOnline(key, HoTen, DiaChi, SDT);
            this.Close(); 

        }
    }
}
