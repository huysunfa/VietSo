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
    public partial class frmConfirmDownload : Form
    {
        List<LongSo> ListPrintDownload = new List<LongSo>();
        public frmConfirmDownload(List<LongSo> _ListPrintDownload)
        {
            ListPrintDownload = _ListPrintDownload;
            InitializeComponent();
        }

        private void frmConfirmDownload_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Có " + ListPrintDownload.Count + " chưa được Thầy/Cô tải về, Thầy/Cô có muốn tải các sớ này về máy không ?";
            foreach (var item in ListPrintDownload)
            {
                dgvParent.Rows.Add("", item.TenSo, item.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {

                foreach (DataGridViewRow item in dgvParent.Rows)
                {
                    ExchangeLongSo.downloadFile(item.Cells["FileName"].Value + "");
                    this.Invoke(new Action(() =>
                    {
                        item.Cells["Download"].Value = "OK";
                    }));
                }
                this.Invoke(new Action(() =>
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }));

            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
