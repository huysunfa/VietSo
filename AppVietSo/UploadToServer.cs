using AppVietSo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVietSo
{
    public partial class UploadToServer : Form
    {
        public UploadToServer()
        {
            InitializeComponent();
        }
        public class ListLongSo_ChoDuyet
        {
            public string TrangThai { get; set; }
            public Nullable<System.DateTime> Created { get; set; }
            public int SoID { get; set; }
            public string LoaiSo { get; set; }
            public string TenSo { get; set; }
            public string ChuGiai { get; set; }
            public string FileName { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
            public Nullable<System.DateTime> Updated { get; set; }
        }
        private void UploadToServer_Load(object sender, EventArgs e)
        {
            var MAC = CheckKey.getMac();
            checkBox1.Text = Util.LongSoHienTai.LSo.TenSo;
            var json = CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/GetListLongSo_ChoDuyet?TenSo=" + Util.LongSoHienTai.LSo.TenSo
                + "&CreatedBy="+ MAC);
            if (json.Length > 10)
            {
                var data = JsonConvert.DeserializeObject<List<ListLongSo_ChoDuyet>>(json);
                dataGridView1.DataSource = data;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var val = dataGridView1.Rows[i].Cells["TrangThai"].Value + "";
                    if (string.IsNullOrEmpty(val))
                    {
                        dataGridView1.Rows[i].Cells["TrangThai"].Value = "CHỜ DUYỆT";
                    }
                    if (val == "ĐÃ DUYỆT")
                    {
                        dataGridView1.Rows[i].Cells["TrangThai"].Style.BackColor = Color.Green;
                    }
                    else
                    if (val == "TỪ CHỐI")
                    {
                        dataGridView1.Rows[i].Cells["TrangThai"].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["TrangThai"].Style.BackColor = Color.Orange;

                    }
                }

            }
        }
        private string UploadFile(string fileName)
        {
            var client = new WebClient();
            var uri = new Uri(Util.mainURL + "/AppSync/UploadFileData");
            {
                var path = Util.getDataPath + "FileUpload/" + System.IO.Path.GetFileName(fileName);
                client.Headers.Add("file", path);
                var ouput = client.UploadFile(uri, path);
                string s = client.Encoding.GetString(ouput);
                return s;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            var ls = Util.LongSoHienTai.LSo;
            var MAC = CheckKey.getMac();
            string filename = UploadFile(ls.FileName);
            filename = filename.Replace("/", "\\");
            filename = string.IsNullOrEmpty(filename) ? ls.FileName : filename;
            CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/AddItemListLongSo?TenSo=" + ls.TenSo
                + "&LoaiSo=" + ls.LoaiSo
                + "&ChuGiai=" + ls.ChuGiai
                + "&FileName=" + filename
                + "&SoID=" + ls.SoID
                + "&CreatedBy=" + MAC
                );

            UploadToServer_Load(sender, e);
            MessageBox.Show("Gửi duyệt thành công, xin lui lòng đợi kết quả");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void xemSơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = dataGridView1.SelectedRows;
            if (item!=null)
            {
                var file = item[0].Cells["FileName"].Value + "";
                ExchangeLongSo.downloadFileBibe(file);
                Util.NameLongSoHienTai = null;
                var frm = new Form1();
                frm.ShowDialog();
            }
         
        }
    }
}
