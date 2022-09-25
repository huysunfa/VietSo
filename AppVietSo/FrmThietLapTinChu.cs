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
    public partial class FrmThietLapTinChu : Form
    {
        public FrmThietLapTinChu()
        {
            InitializeComponent();
        }

        private void FrmThietLapTinChu_Load(object sender, EventArgs e)
        {
            var txtForm = ActiveData.Get("@thietLapTinChuMoreText");
            var txtMore = ActiveData.Get("@thietLapTinChuFormText");
            if (!string.IsNullOrEmpty(txtForm))
            {
                this.txtForm.Text = txtForm;
                this.txtMore.Text = txtMore;
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string text = this.txtMore.Text.Trim();
            if (!string.IsNullOrWhiteSpace(text))
            {
                text = Util.RemoveDoubleSpace(text);
            }
            string text2 = this.txtForm.Text.Trim();
            if (!string.IsNullOrWhiteSpace(text2))
            {
                text2 = Util.RemoveDoubleSpace(text2);
            }

            ActiveData.Update("@thietLapTinChuMoreText", text2);
            ActiveData.Update("@thietLapTinChuFormText", text);
            base.Close();
            base.DialogResult = DialogResult.OK;
        }
    }
}
