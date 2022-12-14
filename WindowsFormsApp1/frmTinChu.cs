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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class frmTinChu : Form
    {
        public frmTinChu()
        {
            InitializeComponent();
        }
        public static List<string> keys = new List<string>() {
                "@noicung",
        "@diachiyvu",
        "@giachu",
        "@tinchu",
        "@hlinhten",
        "@hlinhsinh",
        "@hlinhmat",
        "@hlinhtho"
    };
        private void frmTinChu_Load(object sender, EventArgs e)
        {
            var dt = CsvExtentions.ConvertCSVtoDataTable(Util.getTinChuPath);
            if (dt.Columns.Count == 0)
            {

                dt.Columns.Add("DanhXung");
                dt.Columns.Add("NamSinh");
                dt.Columns.Add("NgayMat");
                dt.Columns.Add("GioiTinh");
                foreach (var item in keys)
                {
                    dt.Columns.Add(item);
                }
            }

            dataGridView1.DataSource = dt;
            var dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dataGridView1.Columns.Insert(0, dgvCmb);
            dataGridView1.Columns["DanhXung"].HeaderText = "Danh xưng";
            dataGridView1.Columns["@tinchu"].HeaderText = "Họ tên";
            dataGridView1.Columns["NamSinh"].HeaderText = "Năm sinh";
            dataGridView1.Columns["NgayMat"].HeaderText = "Năm mất";
            dataGridView1.Columns["GioiTinh"].HeaderText = "Giới tính";
            dataGridView1.Columns["@diachiyvu"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["@noicung"].HeaderText = "Nơi cúng";
            dataGridView1.Columns["@giachu"].HeaderText = "Gia chủ";
            dataGridView1.Columns["@hlinhten"].HeaderText = "Tên Hương Linh";

            dataGridView1.Columns["@hlinhsinh"].HeaderText = "Hương linh năm sinh";
            dataGridView1.Columns["@hlinhsinh"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns["@hlinhsinh"].ReadOnly = true;

            dataGridView1.Columns["@hlinhmat"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns["@hlinhmat"].ReadOnly = true;
            dataGridView1.Columns["@hlinhmat"].HeaderText = "Hương linh năm mất";

            dataGridView1.Columns["@hlinhtho"].HeaderText = "Hương linh hưởng thọ";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView1.DataSource;
            if (dt.Rows.Count == 1)
            {
                var item = dataGridView1.Rows[0];
                foreach (var it in keys)
                {
                    SaveCellValue(item, it);
                }

            }
            CsvExtentions.ToCSV(dt, Util.getTinChuPath);
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Chk")
            {
                var item = dataGridView1.Rows[e.RowIndex];
                foreach (var it in keys)
                {
                    SaveCellValue(item, it);
                }


                DataTable dt = new DataTable();
                dt = (DataTable)dataGridView1.DataSource;
                CsvExtentions.ToCSV(dt, Util.getTinChuPath);
                this.Visible = false;
            }
        }
        void SaveCellValue(DataGridViewRow item, string key)
        {
            var val = item.Cells[key].Value+"";
            val = CNDictionary.getCN(val);
            ActiveData.Update(key, val + "");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "NamSinh")
            {
                var value = dataGridView1.Rows[e.RowIndex].Cells["NamSinh"].Value + "";
                int.TryParse(value, out int years);
                if (years == 0)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["NamSinh"].Value = "";
                    MessageBox.Show("Vui lòng nhập năm sinh dạng số (ví dụ 1991)");
                    return;
                }
                dataGridView1.Rows[e.RowIndex].Cells["@hlinhsinh"].Value = Util.getSaoVN(years, false);



                DataTable dt = new DataTable();
                dt = (DataTable)dataGridView1.DataSource;
                CsvExtentions.ToCSV(dt, Util.getTinChuPath);
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "NgayMat")
            {
                var value = dataGridView1.Rows[e.RowIndex].Cells["NgayMat"].Value + "";
                int.TryParse(value, out int years);
                if (years == 0)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["NamSinh"].Value = "";
                    MessageBox.Show("Vui lòng nhập năm mất dạng số (ví dụ 1991)");
                    return;
                }
                dataGridView1.Rows[e.RowIndex].Cells["@hlinhmat"].Value = Util.getSaoVN(years, false);



                DataTable dt = new DataTable();
                dt = (DataTable)dataGridView1.DataSource;
                CsvExtentions.ToCSV(dt, Util.getTinChuPath);
            }
        }
    }
}
