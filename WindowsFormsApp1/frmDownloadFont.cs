using Newtonsoft.Json;
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
    public partial class frmDownloadFont : Form
    {
        public frmDownloadFont()
        {
            InitializeComponent();
        }

        private void frmDownloadFont_Load(object sender, EventArgs e)
        {
            
            string[] fileEntries = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/fontCN").Select(v => v.Split('\\').LastOrDefault().ToUpper()).ToArray();
            var json = CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/GetListFont");
            var data = JsonConvert.DeserializeObject<List<string>>(json);
            var dt = new DataTable();
            dt.Columns.Add("TinhTrang");
            dt.Columns.Add("FontName");
            dt.Columns.Add("FileName");

            foreach (var item in data)
            {
                var FontName = item.Split('\\').LastOrDefault().ToUpper();
                var row = dt.NewRow();
                row["FontName"] = FontName;
                row["FileName"] = item;
                if (fileEntries.Contains(FontName))
                {
                    row["TinhTrang"] = "Đã tải về";
                }
                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
            var buttonColumn = new DataGridViewButtonColumn()
            {
                Name = "btnAction",
                HeaderText = "",
                UseColumnTextForButtonValue = false,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    NullValue = "Tải về"
                }
            };
            this.dataGridView1.Columns.Insert(0, buttonColumn);


            //string[] fileEntries = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/fontCN").Select(v => v.Split('\\').LastOrDefault().ToUpper()).ToArray();
            //foreach (var item in data)
            //{
            //    var name = item;
            //    name = name.Replace("\\", "/");
            //    name = name.Split('/').LastOrDefault().ToUpper();
            //    if (!fileEntries.Contains(name))
            //    {
            //        var urldownload = "/FILEUPLOAD/FONTCN/" + name;
            //        ExchangeLongSo.downloadFileFont(urldownload);
            //    }
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dataGridView.Columns[e.ColumnIndex].Name == "btnAction")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn tải font này về ?", "Xác nhận tải", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {


                    DataGridViewRow dataGridViewRow = dataGridView.Rows[e.RowIndex];
                    if (dataGridViewRow.Cells["FileName"].Value == null)
                    {
                        //MessageBox.Show("File này chỉ có ở máy của Thầy, không có trên mạng nên không cần tải về!", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        var value = dataGridViewRow.Cells["FontName"].Value.ToString();
                        var urldownload = "/FILEUPLOAD/FONTCN/" + value;

                        if (ExchangeLongSo.downloadFileFont(urldownload))
                        {
                            dataGridViewRow.Cells["TinhTrang"].Value = "Đã tải về";

                            MessageBox.Show("Tải file thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Tải file thất bại. Xin hãy kiểm tra kết nối internet, hoặc liên hệ với Bibe.vn", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
        }
    }
}
