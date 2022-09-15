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
    public partial class frmSugget : Form
    {
        string _key;
        public frmSugget(string key = null, string t = null)
        {
            key = key.Replace("@", "");
            _key = key;
             InitializeComponent();
            label1.Text = "Thêm " + t;
        }

        private void frmSugget_Load(object sender, EventArgs e)
        {
            var data = new DataTable();
            if (_key == "thang" || _key == "mua")
            {
           
               data = CNDictionary.databaseNguCanh.Select("nguCanh = '" + _key + "'"  ).CopyToDataTable();
                data.Columns.Remove("nguCanh");

            }
            if (_key == "ngay")
            {
                data = getMonth();
            }    
            if (_key == "nam")
            {
                data = getYear();
            }

            data.Columns.Add("Chk", typeof(bool));
             dataGridView1.DataSource = data;

        }

        public DataTable getMonth()
        {
            var dt = new DataTable();
            dt.Columns.Add("vn");
            dt.Columns.Add("chinese");
            dt.Columns.Add("used");
            for (int i = 1; i < 32; i++)
            {
                var xx = CNDictionary.getChuNomDD(i.ToString());
                var cn = CNDictionary.getCN(xx);
                var it = dt.NewRow();
                it["vn"] = xx;
                it["used"] = i;
                it["chinese"] = cn;
                dt.Rows.Add(it);
            }
            return dt;
        }
        
        public DataTable getYear()
        {
            var dt = new DataTable();
            dt.Columns.Add("vn");
            dt.Columns.Add("chinese");
            dt.Columns.Add("used");
            for (var i = DateTime.Now.AddYears(-100); i < DateTime.Now.AddYears(5); i=i.AddYears(1))
            {
             
                var CanChi = Util.getCanChiVN(i.Year);
                var cn = CNDictionary.getCN(CanChi);
                var it = dt.NewRow();
                it["vn"] = CanChi;
                it["used"] = i.Year.ToString();
                it["chinese"] = cn;
                dt.Rows.Add(it);
            }
            dt.DefaultView.Sort = "used DESC";
            dt = dt.DefaultView.ToTable();
            return dt;
        }
      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Chk")
            {
                try
                {
                    Util.strDataSugget = dataGridView1.CurrentRow.Cells["chinese"].Value + "";

                }
                catch
                {


                }
                this.Visible = false;
            }
        }
    }
}
