using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVietSo
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
        "@ten",
        "@hlinhten",
        "@hlinhsinh",
        "@hlinhmat",
        "@hlinhtho"
    };
        private void frmTinChu_Load(object sender, EventArgs e)
        {
            var dt = CsvExtentions.ConvertCSVtoDataTable(Util.getTinChuPath);

            dataGridView1.DataSource = null;

            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn() {Name= "Chk", HeaderText="Chọn" });
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn() {Name= "ChkGiaChu", HeaderText="Chọn gia chủ" });
             dataGridView1.Columns.Add("@danh", "Danh xưng");
            dataGridView1.Columns.Add("@ten", "Họ tên");
            dataGridView1.Columns.Add("NamSinh", "Năm sinh");
            dataGridView1.Columns.Add("@noicung", "Nơi cúng");
            dataGridView1.Columns.Add("NgayMat", "Ngày mất");
            dataGridView1.Columns.Add("@diachiyvu", "Địa chỉ");
            dataGridView1.Columns.Add("GioiTinh", "Giới tính");

            dataGridView1.Columns["Chk"].ValueType= typeof(bool);
            dataGridView1.Columns["NgayMat"].DefaultCellStyle.Format = "dd/MM/yyyy";


            dataGridView1.Columns.Add("@hlinhten", "Tên Hương Linh");
            dataGridView1.Columns.Add("@hlinhsinh", "Hương linh năm sinh");
            dataGridView1.Columns.Add("@hlinhmat", "Hương linh năm mất");
            dataGridView1.Columns.Add("@hlinhtho", "Hương linh hưởng thọ");
            dataGridView1.Columns.Add("@giachu", "@giachu");

            dataGridView1.Columns["@giachu"].Visible = false;
            dataGridView1.Columns["@hlinhsinh"].Visible = false;
            dataGridView1.Columns["@hlinhten"].Visible = false;
            dataGridView1.Columns["@hlinhtho"].Visible = false;
            dataGridView1.Columns["@hlinhmat"].Visible = false;

            if (dt==null)
            {
                return;
            }
            foreach (DataRow item in dt.Rows)
            {
                int rowId = dataGridView1.Rows.Add();

                // Grab the new row!
                DataGridViewRow row = dataGridView1.Rows[rowId];
 
                foreach (DataColumn it in dt.Columns)
                {
                    if (dataGridView1.Columns.Contains(it.ColumnName))
                    {
                        row.Cells[it.ColumnName].Value = item[it.ColumnName];
                    }

                }
             }



             ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView1.ToDataTable("New");
            var giachu = dt.Select(@"ChkGiaChu='True'").FirstOrDefault();
            if (giachu!= null)
            {
                var item = dataGridView1.Rows[0];
                foreach (var it in keys)
                {
                    SaveCellValue(giachu, it);
                }

            }
            CsvExtentions.ToCSV(dt, Util.getTinChuPath);
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ChkGiaChu")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[1] != dataGridView1.CurrentCell)
                    {
                        dataGridView1.Rows[i].Cells[1].Value = false;
                    }
                }
            }
        }
        void SaveCellValue(DataRow item, string key)
        {
            var VN = item[key] + "";
            var CN = CNDictionary.getCN(VN);
            ActiveData.Update(key, CN + "_" + VN);
        }
        void SaveCellValue(string Value, string key)
        {
            var VN = Value;
            var CN = CNDictionary.getCN(VN);
            ActiveData.Update(key, CN + "_" + VN);
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
                //  DateTime.TryParse(value, out DateTime years);
                DateTime.TryParseExact(value,
                       "dd/MM/yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out DateTime years);
                if (years.Year < 2000)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["NamSinh"].Value = "";
                    MessageBox.Show("Vui lòng nhập định dạng ngày tháng (ngày/tháng/năm)");
                    return;
                }
                dataGridView1.Rows[e.RowIndex].Cells["@hlinhmat"].Value = years.ToString("dd MM yyyy");



                DataTable dt = new DataTable();
                dt = (DataTable)dataGridView1.DataSource;
                CsvExtentions.ToCSV(dt, Util.getTinChuPath);
            }
        }

        private void toolBtnEditChua_Click(object sender, EventArgs e)
        {

        }

        private void toolTxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void toolBtnSearch_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((row.Cells["@ten"].Value + "").Contains(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1];
            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow;// = dataGridView1.Rows[dataGridView1.RowCount-1].Cells[1];
            dataGridView1.BeginEdit(true);
        }
    }
}
