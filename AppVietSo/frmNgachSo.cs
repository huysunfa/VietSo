using AppVietSo.Models;
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

namespace AppVietSo
{
    public partial class frmNgachSo : Form
    {
        public frmNgachSo()
        {
            InitializeComponent();
        }

        private void frmNgachSo_Load(object sender, EventArgs e)
        {
            var dt = CsvExtentions.ConvertCSVtoDataTable(Util.getNgachSoPath);
            var result = new DataTable();
            result.Columns.Add("Chk", typeof(bool));
            result.Columns.Add("Tên", typeof(string));
            result.Columns.Add("Nội dung", typeof(string));

            foreach (DataRow item in dt.Rows)
            {
                bool.TryParse(item[0].ToString(), out bool check);
                var it = result.NewRow();
                it[0] = check;
                it[2] = item[1];
                it[1] = item[2];
                result.Rows.Add(it);
            }


            dataGridView1.DataSource = result;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {


                //clean al rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["Chk"].Value = false;
                }

                //check select row
                dataGridView1.CurrentRow.Cells["Chk"].Value = true;

                button1_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView1.DataSource;
            foreach (DataRow item in dt.Rows)
            {
                if ((item[0] + "") == "True")
                {

                    string vn = item["Nội dung"] + "";
                    Util.strDataSugget = CNDictionary.getCN(vn) + "_" + vn;
                    ActiveData.Update("@ngachso", Util.strDataSugget);
                }
            }
            CsvExtentions.ToCSV(dt, Util.getNgachSoPath);
            this.Visible = false;
        }

    }
}
