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
    public partial class frmSugget : Form
    {
        string _key;
        public frmSugget(string key = null, string t = null)
        {
            key = key.Replace("@", "");
            _key = key;
            InitializeComponent();
         }

        private void frmSugget_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            var data = new DataTable();
            if (_key == "thang" || _key == "mua")
            {

                data = CNDictionary.databaseNguCanh.Select("nguCanh = '" + _key + "'").CopyToDataTable();
                data.Columns.Remove("nguCanh");

            }
            if (_key == "thang")
            {
                data = getMonth();
            } 
            
            if (_key == "ngay")
            {
                data = getngay();
            }
            if (_key == "nam")
            {
                data = getYear();
            }

            var dt = new DataTable();
            dt.Columns.Add("vn");

            foreach (DataRow item in data.Rows)
            {
                var vn = item["vn"];
                var row = dt.NewRow();
                row["vn"] = vn;
                dt.Rows.Add(row);

            }
            dataGridView1.DataSource = dt;

        }

        public DataTable getMonth()
        {
            var dt = new DataTable();
            dt.Columns.Add("vn");

            for (int i = 1; i <= 12; i++)
            {
                 var it = dt.NewRow();
                it["vn"] = i;
                dt.Rows.Add(it);
            }
            return dt;
        }    public DataTable getngay()
        {
            var dt = new DataTable();
            dt.Columns.Add("vn");

            for (int i = 1; i < 32; i++)
            {
                //var xx = CNDictionary.getChuNomDD(i.ToString());
                var it = dt.NewRow();
                it["vn"] = i;
                dt.Rows.Add(it);
            }
            return dt;
        }

        public DataTable getYear()
        {
            var dt = new DataTable();
            dt.Columns.Add("vn");
            //  dt.Columns.Add("chinese");
            //  dt.Columns.Add("used");
            for (var i = DateTime.Now.AddYears(-1); i <= DateTime.Now.AddYears(1); i = i.AddYears(1))
            {

                //  var CanChi = Util.getCanChiVN(i.Year);
                //  var cn = CNDictionary.getCN(CanChi);
                var it = dt.NewRow();
                it["vn"] = i.Year.ToString();
                //   it["used"] = i.Year.ToString();
                //   it["chinese"] = cn;
                dt.Rows.Add(it);
            }
            //dt.DefaultView.Sort = "used DESC";
            //dt = dt.DefaultView.ToTable();
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var vn = dataGridView1.CurrentRow.Cells["vn"].Value + "";
                var xx = CNDictionary.getChuNomDD(vn);
                if (xx==vn)
                {
                    int.TryParse(vn, out int  year);
                    if (year!=0)
                    {
                        xx = Util.getCanChiVN(year);

                    }
                }

                if (!string.IsNullOrEmpty(xx))
                {
                    vn = xx;
                }else
                {

                }
                var chinese = CNDictionary.getCN(vn);
                Util.strDataSugget = chinese + "_" + vn;

            }
            catch
            {


            }
            this.Hide(); 
            this.Visible = false;
        }

        private void frmSugget_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
