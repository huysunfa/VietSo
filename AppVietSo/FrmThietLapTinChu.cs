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
            var txtMore= ActiveData.Get("@thietLapTinChuMoreText");
            var txtForm = ActiveData.Get("@thietLapTinChuFormText");
            if (!string.IsNullOrEmpty(txtForm))
            {
                this.txtForm.Text = txtForm;
                this.txtMore.Text = txtMore;
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string More = this.txtMore.Text.Trim();
            if (!string.IsNullOrWhiteSpace(More))
            {
                More = Util.RemoveDoubleSpace(More);
            }
            string text2 = this.txtForm.Text.Trim();
            if (!string.IsNullOrWhiteSpace(text2))
            {
                text2 = Util.RemoveDoubleSpace(text2);
            }

            ActiveData.Update("@thietLapTinChuMoreText", More);
            ActiveData.Update("@thietLapTinChuFormText", text2);
            base.Close();
            base.DialogResult = DialogResult.OK;
        }
    }
}
