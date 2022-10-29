using AppVietSo.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVietSo
{
    // Token: 0x0200000E RID: 14
    public partial class FrmDownloadLoaiSo : Form
    {
        // Token: 0x06000070 RID: 112 RVA: 0x00008F83 File Offset: 0x00007183
        List<LongSo> data;

        public FrmDownloadLoaiSo()
        {
            data = LongSo.GetLongSos();

            var listfilelocal = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/FileUpload", "*" + ConstData.ExtentionsFile).ToList();
            foreach (var item in listfilelocal)
            {
                var json = System.IO.File.ReadAllText(item);
                json = Security.Decrypt(json);
                json = json.Replace("$", "@");
                var result = JsonConvert.DeserializeObject<LongSoData>(json);
                if (result.LSo != null && !string.IsNullOrEmpty(result.LSo.LoaiSo))
                {
                    data.Add(result.LSo);
                }
            }
            this.InitializeComponent();

        }

        // Token: 0x06000071 RID: 113 RVA: 0x00008FAC File Offset: 0x000071AC
        private void FrmDownloadLoaiSo_Load(object sender, EventArgs e)
        {
            foreach (var item in data.Select(z => z.LoaiSo).Distinct().ToArray().OrderBy(z => z))
            {
                dgvParent.Rows.Add(item);

                
            }
             dgvParent.Rows.Add(LabelText.Get("SoCuaThay").ToUpper());

        }
        public void setDatagrid(List<LongSo> newdata = null, string text = "")
        {
            dgvLongSo.ClearSelection();
            dgvLongSo.Rows.Clear();
            foreach (LongSo longSo in newdata)
            {
                if (string.IsNullOrEmpty(longSo.LoaiSo))
                {
                    longSo.LoaiSo = "Khác";
                }

                int index2 = this.dgvLongSo.Rows.Add();
                DataGridViewRow dataGridViewRow = this.dgvLongSo.Rows[index2];
                dataGridViewRow.Cells["ID"].Value = longSo.SoID;
                dataGridViewRow.Cells["LoaiSo1"].Value = longSo.LoaiSo;
                dataGridViewRow.Cells["TenSo"].Value = longSo.TenSo;
                dataGridViewRow.Cells["ChuGiai"].Value = longSo.ChuGiai;
                dataGridViewRow.Cells["FileName"].Value = longSo.FileName;
                if (File.Exists(Util.getDataPath + longSo.FileName))
                {
                    dataGridViewRow.Cells["btnAction"].Value = "Tải lại";
                }
                else if (File.Exists(Util.getDataPath + longSo.FileName + ".cus"))
                {
                    dataGridViewRow.Cells["btnAction"].Value = null;
                }
                else
                {
                    dataGridViewRow.Cells["btnAction"].Value = "Tải về";
                }
            }
        }


        private void dgvParent_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewTextBoxCell dataGridViewTextBoxCell = (DataGridViewTextBoxCell)this.dgvParent.CurrentCell;
                if (dataGridViewTextBoxCell != null)
                {
                    object value = dataGridViewTextBoxCell.Value;
                    string text = ((value != null) ? value.ToString() : null) ?? "";
                    if (!string.IsNullOrWhiteSpace(text))
                    {

                        if (text == "SỚ CỦA THẦY")
                        {

                            var listfilelocal = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/FileUpload", "*" + ConstData.ExtentionsFile).Select(z => new FileInfo(z).Name.Split('.').FirstOrDefault()).ToList();
                            var newdata = listfilelocal.Select(v => new LongSo
                            {
                                TenSo = LongSo.GetTenSoByFileName(v).TenSo,
                                ChuGiai = text,
                                FileName = "/FileUpload/" + v + ConstData.ExtentionsFile,
                                LoaiSo = text
                            }).ToList();

                            setDatagrid(newdata, text);
                        }
                        else
                        {
                            var newdata = data.Where(z => z.LoaiSo == text).ToList();
                            setDatagrid(newdata, text);
                        }

                        //dgvLongSo.DataSource = newdata;

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        // Token: 0x06000075 RID: 117 RVA: 0x000094B4 File Offset: 0x000076B4
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    this.btnFind_Click(null, null);
                }
            }
            catch (Exception ex)
            {
            }
        }

        // Token: 0x06000076 RID: 118 RVA: 0x000094EC File Offset: 0x000076EC
        private void btnFind_Click(object sender, EventArgs e)
        {

            string text = this.txt.Text.Trim().ToLower();
            var newdata = data.ToList();
            var output = new List<LongSo>();
            foreach (var item in newdata)
            {
                var name = item.TenSo.ToLower();
                int check = name.IndexOf(text);
                if (check >= 0)
                {

                    output.Add(item);
                }
            }
            setDatagrid(output, text);
        }

        // Token: 0x06000077 RID: 119 RVA: 0x00009620 File Offset: 0x00007820
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (0 < this.dgvLongSo.SelectedRows.Count)
            {
                DataGridViewRow dataGridViewRow = this.dgvLongSo.SelectedRows[0];
                string FName = dataGridViewRow.Cells["FileName"].Value.ToString();
                //  FName = CovertFileName(FName);
                string TenSo = dataGridViewRow.Cells["TenSo"].Value.ToString();

                var LSo = new LongSo();
                LSo.FileName = FName;
                LSo.TenSo = TenSo;
                if (File.Exists(Util.getDataPath + FName))
                {
                    Util.LongSoHienTai = null;
                    Util.NameLongSoHienTai = FName;
                    base.DialogResult = DialogResult.OK;
                    return;
                }
                if (MessageBox.Show(LabelText.Get("LongSoKhongCoTrenMay"), "Xác nhận tải", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    if (ExchangeLongSo.downloadFile(FName))
                    {
                        //object value2 = dataGridViewRow.Cells["TenSo"].Value;
                        //this.updateTenSo(((value2 != null) ? value2.ToString() : null) ?? "");
                        base.DialogResult = DialogResult.OK;
                          Util.LongSoHienTai = null;
                        Util.NameLongSoHienTai = FName;
                        return;
                    }
                    MessageBox.Show(LabelText.Get("TaiFileThatBai") + Util.sdtSupport, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Xin hãy click chọn lòng sớ", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private string CovertFileName(string input)
        {
            input = input.Split('@').LastOrDefault().Split('.').FirstOrDefault();
            return input;
        }
        // Token: 0x06000078 RID: 120 RVA: 0x00009748 File Offset: 0x00007948
        private void dgvLongSo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = sender as DataGridView;
                if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dataGridView.Columns[e.ColumnIndex].Name == "btnAction")
                {
                    DataGridViewRow dataGridViewRow = dataGridView.Rows[e.RowIndex];
                    if (dataGridViewRow.Cells["btnAction"].Value == null)
                    {
                        //MessageBox.Show("File này chỉ có ở máy của Thầy, không có trên mạng nên không cần tải về!", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        var value = dataGridViewRow.Cells["FileName"].Value.ToString();
                        var ChuGiai = dataGridViewRow.Cells["ChuGiai"].Value+"";
                        if (ChuGiai== "SỚ CỦA THẦY")
                        {
                            MessageBox.Show(LabelText.Get("Sớ đã nằm trong máy của thầy, không cần phải tải về nữa ạ!"));
                            return;
                        }
                        value = value.Replace("\\","/");
                        if (ExchangeLongSo.downloadFile(value))
                        {
                            object value2 = dataGridViewRow.Cells["TenSo"].Value;
                            string FName = dataGridViewRow.Cells["FileName"].Value.ToString();
                            //    FName = CovertFileName(FName);
                            string TenSo = dataGridViewRow.Cells["TenSo"].Value.ToString();

                            var LSo = new LongSo();
                            LSo.FileName = value;
                            LSo.TenSo = TenSo;
                            Util.LongSoHienTai = null;
                            Util.NameLongSoHienTai = FName;

                            MessageBox.Show("Tải file thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show(LabelText.Get("TaiFileThatBai") + Util.sdtSupport, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                         }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        // Token: 0x06000079 RID: 121 RVA: 0x00009898 File Offset: 0x00007A98
        private void dgvLongSo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.btnClose_Click(null, null);
        }

        private void dgvParent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
