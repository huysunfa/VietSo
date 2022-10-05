using AppVietSo.Models;
using AppVietSo.Properties;
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

        // Token: 0x1700000D RID: 13
        // (get) Token: 0x060000F8 RID: 248 RVA: 0x00012C70 File Offset: 0x00010E70
        public string GetPagodaID
        {
            get
            {
                if (this.toolCbxChua.ComboBox.SelectedValue == null)
                {
                    return "";
                }
                return this.toolCbxChua.ComboBox.SelectedValue.ToString();
            }
        }

        // Token: 0x1700000E RID: 14
        // (get) Token: 0x060000F9 RID: 249 RVA: 0x00012CA0 File Offset: 0x00010EA0
        public string GetPagodaName
        {
            get
            {
                if (this.toolCbxChua.ComboBox.SelectedItem == null)
                {
                    return "";
                }
                object obj = ((DataRowView)this.toolCbxChua.ComboBox.SelectedItem)["Name"];
                return ((obj != null) ? obj.ToString() : null) ?? "";
            }
        }

        // Token: 0x060000FA RID: 250 RVA: 0x00012CFC File Offset: 0x00010EFC
        public frmTinChu()
        {
            this.InitializeComponent();
            this.dgvPerson.AutoGenerateColumns = false;
            this.dgvOverPerson.AutoGenerateColumns = false;
            this.pnlOverPerson.Width = this.pnlOverPerson.Parent.Width;
        }

        // Token: 0x060000FB RID: 251 RVA: 0x00012D64 File Offset: 0x00010F64
        private void FrmPerson_Load(object sender, EventArgs e)
        {

            this.splitContainer1.SplitterDistance = this.pnlChooseMa.Width;
            this.isLoading = true;
            this.show_checkBox();
            Dictionary<bool, string> dictionary = new Dictionary<bool, string>();
            dictionary.Add(true, "Nam");
            dictionary.Add(false, "Nữ");
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)this.dgvPerson.Columns["GioiTinh"];
            dataGridViewComboBoxColumn.DataSource = dictionary.ToList<KeyValuePair<bool, string>>();
            dataGridViewComboBoxColumn.DisplayMember = "Value";
            dataGridViewComboBoxColumn.ValueMember = "Key";
            this.refreshCbxChua();
            this.toolCbxChua.SelectedIndexChanged += this.toolCbxChua_SelectedIndexChanged;
            if (string.IsNullOrEmpty(Program.Stg.Chua))
            {
                this.toolCbxChua.ComboBox.SelectedIndex = 0;
            }
            else
            {
                foreach (object obj in this.toolCbxChua.ComboBox.Items)
                {
                    DataRowView dataRowView = (DataRowView)obj;
                    if (Program.Stg.Chua.Equals(dataRowView["ID"]))
                    {
                        this.toolCbxChua.ComboBox.SelectedItem = dataRowView;
                        break;
                    }
                }
            }
            if (this.toolCbxChua.ComboBox.SelectedItem == null)
            {
                this.toolCbxChua.ComboBox.SelectedIndex = 0;
            }
            this.ckbChuSo.Checked = Program.Stg.IsGiaChu;
            this.lastFindIndex = 0;
            this.showPanelChooseMa();
            this.toolBtnAddPerson.Visible = !this.isSelectPrint;
            this.dgvPerson.AllowUserToDeleteRows = !this.isSelectPrint;
            this.isLoading = false;
            this.loadPerson();

            this.isLoading = false;

        }

        // Token: 0x060000FC RID: 252 RVA: 0x00012F74 File Offset: 0x00011174
        private void toolBtnAddPerson_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Mời quý Thầy click đúp vào dòng màu vàng để thêm tín chủ", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dgvPerson.CurrentCell = dgvPerson.Rows[dgvPerson.RowCount - 1].Cells[3];
                dgvPerson.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow;// = dataGridView1.Rows[dataGridView1.RowCount-1].Cells[1];
                dgvPerson.BeginEdit(true);
            }
            catch (Exception ex)
            {
                LogError.show(ex);
            }
        }

        // Token: 0x060000FD RID: 253 RVA: 0x00012FB0 File Offset: 0x000111B0
        private void ckbChuSo_CheckedChanged(object sender, EventArgs e)
        {
            this.lblTongNguoi.Visible = !this.ckbChuSo.Checked;
            this.showPanelChooseMa();
            this.loadPerson();
        }

        // Token: 0x060000FE RID: 254 RVA: 0x00012FD7 File Offset: 0x000111D7
        private void showPanelChooseMa()
        {
            this.pnlChooseMa.Visible = (this.isSelectPrint && this.ckbChuSo.Checked);
        }

        // Token: 0x060000FF RID: 255 RVA: 0x00012FFA File Offset: 0x000111FA
        private void toolCbxChua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.toolCbxChua.ComboBox.SelectedValue != null)
            {
                this.loadPerson();
            }
        }

        // Token: 0x06000100 RID: 256 RVA: 0x00013014 File Offset: 0x00011214
        private void loadPerson()
        {

            if (!this.isLoading)
            {
                Cursor.Current = Cursors.WaitCursor;
                this.dgvPerson.DataSource = null;
                this.toolTxtSearch.Text = "";
                DataTable dataTable;
                if (this.ckbChuSo.Checked)
                {
                    dataTable = PersonBO.getListChuSo(this.GetPagodaID, "SoNo");
                    this.Orders.Visible = false;
                    this.orderUp.Visible = false;
                    this.orderDown.Visible = false;
                }
                else
                {
                    dataTable = PersonBO.getList(this.GetPagodaID);
                    this.Orders.Visible = true;
                    this.orderUp.Visible = true;
                    this.orderDown.Visible = true;
                }
                var enumerable = from row in dataTable.AsEnumerable()
                                 group row by row.Field<Int64>("SoNo") into sales
                                 orderby sales.Key
                                 select new
                                 {
                                     Ma = sales.Key,
                                     CountOfClients = sales.Count<DataRow>()
                                 };
                DataTable dataTable2 = new DataTable();
                dataTable2.Columns.Add("MaSo");
                dataTable2.Columns.Add("TotalPerson");
                foreach (var f__AnonymousType in enumerable)
                {
                    if (f__AnonymousType.CountOfClients > 18)
                    {
                        dataTable2.Rows.Add(new object[]
                        {

                                f__AnonymousType.Ma,

                                f__AnonymousType.CountOfClients
                        });
                    }
                }
                if (0 < dataTable2.Rows.Count)
                {
                    this.pnlOverPerson.Visible = true;
                    this.dgvOverPerson.DataSource = null;
                    this.dgvOverPerson.DataSource = dataTable2;
                }
                else
                {
                    this.pnlOverPerson.Visible = false;
                }
                this.lblTongLaSo.Text = "Tổng lá sớ: " + enumerable.Count().ToString();
                this.lblTongNguoi.Text = "Tổng người: " + dataTable.Rows.Count.ToString();
                int num = 1;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i]["NamSinh"].ToString() == "0")
                    {
                        dataTable.Rows[i]["NamSinh"] = DBNull.Value;
                    }
                    if (!this.isSelectPrint && num.ToString() != dataTable.Rows[i]["SoNo"].ToString())
                    {
                        DataRow dataRow = dataTable.NewRow();
                        dataRow["SoNo"] = num;
                        dataRow["GioiTinh"] = 1;
                        dataRow["Orders"] = 0;
                        num = int.Parse(dataTable.Rows[i]["SoNo"].ToString());
                        dataTable.Rows.InsertAt(dataRow, i);
                    }
                }
                if (!this.isSelectPrint)
                {
                    DataRow dataRow2 = dataTable.NewRow();
                    dataRow2["SoNo"] = num;
                    dataRow2["GioiTinh"] = 1;
                    dataRow2["Orders"] = 0;
                    dataTable.Rows.Add(dataRow2);
                    dataTable.AcceptChanges();
                }
                this.dgvPerson.DataSource = dataTable;
                this.dgvPerson.Update();
                this.dgvPerson.Refresh();

                var listIDS = ActiveData.Get("@SelectedSoNos").Split(',').Where(v => !string.IsNullOrEmpty(v)).ToList();

                foreach (object obj in ((System.Collections.IEnumerable)this.dgvPerson.Rows))
                {
                    DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
                    var ID = dataGridViewRow.Cells["ID"].Value + "";
                    if (listIDS.Contains(ID))
                    {
                        dataGridViewRow.Cells["Checked"].Value = true;
                    }
                    if (!string.IsNullOrEmpty(dataGridViewRow.Cells["NgayMat"].Value.ToString()))
                    {
                        dataGridViewRow.DefaultCellStyle.Font = new Font(this.dgvPerson.Font.FontFamily, 12.5f, FontStyle.Italic | FontStyle.Underline);
                    }
                }
            }

            Cursor.Current = Cursors.Default;

        }

        // Token: 0x06000101 RID: 257 RVA: 0x000134D8 File Offset: 0x000116D8
        private void toolBtnEditChua_Click(object sender, EventArgs e)
        {

            if (new FrmEditChua(this.keySoft).ShowDialog() == DialogResult.OK)
            {
                this.refreshCbxChua();
            }

        }

        // Token: 0x06000102 RID: 258 RVA: 0x0001353C File Offset: 0x0001173C
        private void refreshCbxChua()
        {
            this.toolCbxChua.ComboBox.DataSource = null;
            this.toolCbxChua.ComboBox.DataSource = PagodaBO.getAll();
            this.toolCbxChua.ComboBox.DisplayMember = "Name";
            this.toolCbxChua.ComboBox.ValueMember = "ID";
        }

        // Token: 0x06000103 RID: 259 RVA: 0x0001359C File Offset: 0x0001179C
        private void toolTxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {
                this.toolBtnSearch_Click(null, null);
            }

        }

        // Token: 0x06000104 RID: 260 RVA: 0x000135D4 File Offset: 0x000117D4
        private void toolBtnSearch_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            string text = this.toolTxtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(text))
            {
                bool flag = false;
                for (int i = this.lastFindIndex; i < this.dgvPerson.Rows.Count; i++)
                {
                    DataGridViewRow dataGridViewRow = this.dgvPerson.Rows[i];
                    if (text.Equals(dataGridViewRow.Cells["SoNo"].Value.ToString().ToLower()) || dataGridViewRow.Cells["FullName"].Value.ToString().ToLower().Contains(text))
                    {
                        this.dgvPerson.FirstDisplayedScrollingRowIndex = dataGridViewRow.Index;
                        this.dgvPerson.ClearSelection();
                        dataGridViewRow.Selected = true;
                        this.lastFindIndex = dataGridViewRow.Index + 1;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    this.lastFindIndex = 0;
                }
            }

            Cursor.Current = Cursors.Default;

        }

        // Token: 0x06000105 RID: 261 RVA: 0x00013708 File Offset: 0x00011908
        private void dgvPerson_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.dgvPerson.Columns["action"].Index)
                {
                    DataGridViewRow owningRow = this.dgvPerson[e.ColumnIndex, e.RowIndex].OwningRow;
                    string str = "Xin hãy xác nhận muốn xóa ";
                    object value = owningRow.Cells["FullName"].Value;
                    if (MessageBox.Show(str + ((value != null) ? value.ToString() : null), "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PersonBO.delete(owningRow.Cells["ID"].Value.ToString());
                        this.dgvPerson.Rows.Remove(owningRow);
                    }
                }
            }
            else if (dataGridView.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
            {
                int num = 0;
                if (e.ColumnIndex == this.dgvPerson.Columns["orderUp"].Index)
                {
                    DataGridViewRow owningRow2 = this.dgvPerson[e.ColumnIndex, e.RowIndex].OwningRow;
                    num = Convert.ToInt32(owningRow2.Cells["SoNo"].Value);
                    int downUp = 1;
                    object value2 = owningRow2.Cells["ID"].Value;
                    string id = ((value2 != null) ? value2.ToString() : null) ?? "";
                    int soNo = num;
                    object value3 = owningRow2.Cells["PagodaID"].Value;
                    PersonBO.Order(downUp, id, soNo, ((value3 != null) ? value3.ToString() : null) ?? "");
                }
                else if (e.ColumnIndex == this.dgvPerson.Columns["orderDown"].Index)
                {
                    DataGridViewRow owningRow3 = this.dgvPerson[e.ColumnIndex, e.RowIndex].OwningRow;
                    num = Convert.ToInt32(owningRow3.Cells["SoNo"].Value);
                    int downUp2 = -1;
                    object value4 = owningRow3.Cells["ID"].Value;
                    string id2 = ((value4 != null) ? value4.ToString() : null) ?? "";
                    int soNo2 = num;
                    object value5 = owningRow3.Cells["PagodaID"].Value;
                    PersonBO.Order(downUp2, id2, soNo2, ((value5 != null) ? value5.ToString() : null) ?? "");
                }
                if (num != 0)
                {
                    this.loadPerson();
                    this.toolTxtSearch.Text = (num.ToString() ?? "");
                    this.lastFindIndex = 0;
                    this.toolBtnSearch_Click(null, null);
                }
            }

        }

        // Token: 0x06000106 RID: 262 RVA: 0x000139F4 File Offset: 0x00011BF4
        private void dgvPerson_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = e.Row;
            string str = "Xin hãy xác nhận muốn xóa ";
            object value = row.Cells["FullName"].Value;
            if (MessageBox.Show(str + ((value != null) ? value.ToString() : null), "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                PersonBO.delete(row.Cells["ID"].Value.ToString());
            }

        }

        // Token: 0x06000107 RID: 263 RVA: 0x00013A84 File Offset: 0x00011C84
        private void show_checkBox()
        {
            CheckBox checkBox = new CheckBox();
            Rectangle cellDisplayRectangle = this.dgvPerson.GetCellDisplayRectangle(1, -1, true);
            cellDisplayRectangle.X += cellDisplayRectangle.Width / 2 - 8;
            cellDisplayRectangle.Y = cellDisplayRectangle.Height - 0x11;
            checkBox.BackColor = Color.Transparent;
            checkBox.Name = "checkboxHeader";
            checkBox.Size = new Size(0x11, 0x11);
            checkBox.Location = cellDisplayRectangle.Location;
            checkBox.CheckedChanged += this.checkboxHeader_CheckedChanged;
            this.dgvPerson.Controls.Add(checkBox);
        }

        // Token: 0x06000108 RID: 264 RVA: 0x00013B28 File Offset: 0x00011D28
        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)this.dgvPerson.Controls.Find("checkboxHeader", true)[0];
            foreach (object obj in ((DataGridViewRowCollection)this.dgvPerson.Rows))
            {
                ((DataGridViewRow)obj).Cells[1].Value = checkBox.Checked;
            }
        }

        // Token: 0x06000109 RID: 265 RVA: 0x00013BB8 File Offset: 0x00011DB8
        private void dgvPerson_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.oldvalue = this.dgvPerson[e.ColumnIndex, e.RowIndex].Value;
        }

        // Token: 0x0600010A RID: 266 RVA: 0x00013BDC File Offset: 0x00011DDC
        private void dgvPerson_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (!(this.dgvPerson[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Checked"))
            {
                if (!this.dgvPerson[e.ColumnIndex, e.RowIndex].Value.Equals(this.oldvalue))
                {
                    DataGridViewRow owningRow = this.dgvPerson[e.ColumnIndex, e.RowIndex].OwningRow;
                    string text = owningRow.Cells["NamSinh"].Value.ToString();
                    if (0 < text.Length && text.Length != 4)
                    {
                        MessageBox.Show("Năm sinh phải gồm 4 số.", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int num;
                        int.TryParse(owningRow.Cells["SoNo"].Value.ToString(), out num);
                        bool flag = !this.isExistSoNo(ref num);
                        if (flag)
                        {
                            MessageBox.Show("Hệ thống nhận thấy mã sớ số " + num.ToString() + " chưa được sử dụng cho gia đình nào. Do đó sẽ dùng mã này cho gia đình mới", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        Person person = new Person();
                        person.SoNo = num;
                        string text2 = owningRow.Cells["DanhXung"].Value.ToString().Trim();
                        text2 = text2.Replace('>', ')').Replace('<', '(');
                        text2 = Util.RemoveDoubleSpace(text2);
                        person.DanhXung = text2;
                        string text3 = owningRow.Cells["FullName"].Value.ToString().Trim();
                        text3 = text3.Replace('>', ')').Replace('<', '(');
                        text3 = Util.RemoveDoubleSpace(text3);
                        person.FullName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text3.ToLower());
                        int namSinh = 0;
                        if (int.TryParse(text, out namSinh))
                        {
                            person.NamSinh = namSinh;
                        }
                        person.NgayMat = owningRow.Cells["NgayMat"].Value.ToString();
                        person.GioiTinh = (bool)owningRow.Cells["GioiTinh"].Value;
                        person.Address = Util.RemoveDoubleSpace(owningRow.Cells["Address"].Value.ToString());
                        person.Orders = int.Parse(owningRow.Cells["Orders"].Value.ToString());
                        person.UpdateDT = DateTime.Now;
                        if (owningRow.Cells["ID"].Value is DBNull)
                        {
                            person.PagodaID = this.GetPagodaID;
                            person.Status = "New";
                            int num2 = PersonBO.setGetID(person);
                            owningRow.Cells["ID"].Value = num2;
                            if (flag)
                            {
                                owningRow.Cells["SoNo"].Value = num;
                            }
                            DataTable dataTable = (DataTable)this.dgvPerson.DataSource;
                            DataRow dataRow = dataTable.NewRow();
                            dataRow["SoNo"] = num;
                            dataRow["GioiTinh"] = 1;
                            dataRow["Orders"] = 0;
                            dataTable.Rows.InsertAt(dataRow, owningRow.Index + 1);
                            dataTable.AcceptChanges();
                        }
                        else
                        {
                            if (flag)
                            {
                                owningRow.Cells["SoNo"].Value = num;
                            }
                            person.ID = owningRow.Cells["ID"].Value.ToString();
                            person.Status = "Changed";
                            PersonBO.update(person);
                        }
                    }
                }
            }

        }

        // Token: 0x0600010B RID: 267 RVA: 0x00013FC4 File Offset: 0x000121C4
        private bool isExistSoNo(ref int soNo)
        {
            List<int> listSoNo = PersonBO.getListSoNo(this.GetPagodaID);
            if (listSoNo.Contains(soNo))
            {
                return true;
            }
            int newSoNo = PersonBO.getNewSoNo(this.GetPagodaID);
            int num = 0;
            for (int i = 1; i < newSoNo; i++)
            {
                if (!listSoNo.Contains(i))
                {
                    num = i;
                    break;
                }
            }
            if (num == 0)
            {
                num = newSoNo;
            }
            if (soNo == num)
            {
                return true;
            }
            soNo = num;
            return false;
        }

        // Token: 0x0600010C RID: 268 RVA: 0x00014020 File Offset: 0x00012220
        private void dgvPerson_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            this.dgvPerson.Rows[e.RowIndex].ErrorText = "";
            if (e.ColumnIndex == this.dgvPerson.Columns["NamSinh"].Index || e.ColumnIndex == this.dgvPerson.Columns["SoNo"].Index)
            {
                if (this.dgvPerson.Rows[e.RowIndex].IsNewRow)
                {
                    return;
                }
                if (e.ColumnIndex == this.dgvPerson.Columns["NamSinh"].Index && string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    return;
                }
                int num;
                if (!int.TryParse(e.FormattedValue.ToString(), out num) || num < 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("Giá trị phải là kiểu số", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dgvPerson.Rows[e.RowIndex].ErrorText = "Giá trị phải là kiểu số";
                    return;
                }
            }
            if (e.ColumnIndex == this.dgvPerson.Columns["FullName"].Index && string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                object value = this.dgvPerson.Rows[e.RowIndex].Cells["ID"].Value;
                if (!string.IsNullOrWhiteSpace(((value != null) ? value.ToString() : null) ?? ""))
                {
                    MessageBox.Show("Họ Tên không được để trống.", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dgvPerson.Rows[e.RowIndex].ErrorText = "Họ Tên không được để trống";
                }
            }

        }

        // Token: 0x0600010D RID: 269 RVA: 0x0001421C File Offset: 0x0001241C
        private void dgvPerson_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object value = this.dgvPerson.Rows[e.RowIndex].Cells["FullName"].Value;
            if (string.IsNullOrWhiteSpace(((value != null) ? value.ToString() : null) ?? ""))
            {
                this.dgvPerson.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        // Token: 0x0600010E RID: 270 RVA: 0x00014294 File Offset: 0x00012494
        private void dgvPerson_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow dataGridViewRow = this.dgvPerson.Rows[e.RowIndex];
                object value = dataGridViewRow.Cells["FullName"].Value;
                if (string.IsNullOrWhiteSpace(((value != null) ? value.ToString() : null) ?? ""))
                {
                    string str = "Click đúp để nhập thêm người cho nhà số ";
                    object value2 = dataGridViewRow.Cells["SoNo"].Value;
                    e.ToolTipText = str + ((value2 != null) ? value2.ToString() : null);
                }
            }
        }

        // Token: 0x0600010F RID: 271 RVA: 0x00014324 File Offset: 0x00012524
        private void toolBtnOk_Click(object sender, EventArgs e)
        {


            base.Close();
            base.DialogResult = DialogResult.OK;

        }

        // Token: 0x06000110 RID: 272 RVA: 0x00002678 File Offset: 0x00000878
        private void btnOK_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000111 RID: 273 RVA: 0x00014358 File Offset: 0x00012558
        private void FrmPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.GetSoNos();
            if (this.SelectedSoNos.Count <= 0)
            {
                MessageBox.Show("Xin hãy chọn Tín chủ !", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Program.Stg.Chua = this.GetPagodaID;
            var chua = Models.PagodaBO.get(Program.Stg.Chua);
            ActiveData.Update("@noicung", chua.Name);
            int.TryParse(Program.Stg.Chua, out int NumChua);
            if (SelectedSoNos.ContainsKey(NumChua))
            {
                var item = SelectedSoNos[NumChua];

                var user = PersonBO.getHuonglinhs(Program.Stg.Chua, item);
                string hlinhten = "";
                string hlinhsinh = "";
                string hlinhmat = "";
                string hlinhtho = "";
                foreach (var it in user)
                {
                    hlinhten += it.FullName + " ";
                    hlinhsinh += it.Menh + " ";
                    hlinhmat += it.DaiHanY + " ";
                    hlinhtho += it.Tuoi + " ";
                }
                var gc = PersonBO.getChuSo(Program.Stg.Chua);
                ActiveData.Update("@chua", Program.Stg.Chua);
                ActiveData.Update("@hlinhten", hlinhten);
                ActiveData.Update("@hlinhsinh", hlinhsinh);
                ActiveData.Update("@hlinhmat", hlinhmat);
                ActiveData.Update("@hlinhtho", hlinhtho);
                ActiveData.Update("@giachu", (gc.FullName));
                ActiveData.Update("@tinchu", gc.FullName);
                ActiveData.Update("@canchi", CNDictionary.getCN(gc.Menh) + "_" + gc.Menh);
                ActiveData.Update("@sotuoi", gc.Tuoi);
                ActiveData.Update("@tuoi", CNDictionary.getCN(CNDictionary.getChuNomYYYY(gc.Tuoi)) + "_" + CNDictionary.getChuNomYYYY(gc.Tuoi));

                Program.Stg.IsGiaChu = this.ckbChuSo.Checked;

            }
            var IDS = SelectedSoNos.Select(z => z.Value.IDs).ToList();
            var listID = new List<string>();
            foreach (var item in IDS)
            {
                foreach (var it in item)
                {
                    listID.Add(it);

                }
            }
            ActiveData.Update("@SelectedSoNos", string.Join(",", listID));
            ActiveData.UpdateDataByID();
        }


        // Token: 0x06000112 RID: 274 RVA: 0x000143CC File Offset: 0x000125CC
        private void GetSoNos()
        {
            this.dgvPerson.EndEdit();
            this.SelectedSoNos = new Dictionary<int, Family>();
            for (int i = 0; i < this.dgvPerson.RowCount; i++)
            {
                if (Convert.ToBoolean(this.dgvPerson.Rows[i].Cells["Checked"].Value))
                {
                    int num = Convert.ToInt32(this.dgvPerson.Rows[i].Cells["SoNo"].Value);
                    object value = this.dgvPerson.Rows[i].Cells["ID"].Value;
                    string text = ((value != null) ? value.ToString() : null) ?? "";
                    if (!string.IsNullOrEmpty(text))
                    {
                        if (this.ckbChuSo.Checked)
                        {
                            if (!this.SelectedSoNos.ContainsKey(num))
                            {
                                this.SelectedSoNos.Add(num, new Family
                                {
                                    SoNo = num,
                                    IDs = new List<string>()
                                });
                            }
                        }
                        if (this.SelectedSoNos.ContainsKey(num))
                        {
                            this.SelectedSoNos[num].IDs.Add(text);
                        }
                        else
                        {
                            Family family = new Family
                            {
                                SoNo = num,
                                IDs = new List<string>()
                            };
                            family.IDs.Add(text);
                            this.SelectedSoNos.Add(family.SoNo, family);
                        }
                    }
                }
            }
        }

        // Token: 0x06000113 RID: 275 RVA: 0x00014534 File Offset: 0x00012734
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

            DataTable dataTable;
            if (this.ckbChuSo.Checked)
            {
                dataTable = PersonBO.getListChuSo(this.GetPagodaID, "FullName");
            }
            else
            {
                dataTable = PersonBO.getList(this.GetPagodaID);
            }
            if (dataTable != null && 0 < dataTable.Rows.Count)
            {
                new FrmDanhSachTinChu(dataTable).ShowDialog(this);
            }

        }

        // Token: 0x06000114 RID: 276 RVA: 0x000145A4 File Offset: 0x000127A4
        private void nUpDFrom_ValueChanged(object sender, EventArgs e)
        {
            this.setSelected(sender, e);
        }

        // Token: 0x06000115 RID: 277 RVA: 0x000145A4 File Offset: 0x000127A4
        private void nUpDTo_ValueChanged(object sender, EventArgs e)
        {
            this.setSelected(sender, e);
        }

        // Token: 0x06000116 RID: 278 RVA: 0x000145B0 File Offset: 0x000127B0
        private void setSelected(object sender, EventArgs e)
        {

            NumericUpDown numericUpDown = sender as NumericUpDown;
            for (int i = 0; i < this.dgvPerson.RowCount; i++)
            {
                this.dgvPerson.Rows[i].Cells["Checked"].Value = false;
            }
            decimal value = this.nUpDFrom.Value;
            decimal value2 = this.nUpDTo.Value;
            if (value < value2)
            {
                bool flag = false;
                for (int j = 0; j < this.dgvPerson.RowCount; j++)
                {
                    int value3 = Convert.ToInt32(this.dgvPerson.Rows[j].Cells["SoNo"].Value);
                    if (value <= value3 && value3 <= value2)
                    {
                        this.dgvPerson.Rows[j].Cells["Checked"].Value = true;
                        flag = true;
                    }
                }
                if (flag)
                {
                    int num = (int)value;
                    if (numericUpDown.Name == this.nUpDTo.Name)
                    {
                        num = (int)value2;
                    }
                    DataGridViewRow dataGridViewRow = this.dgvPerson.Rows[num - 1];
                    dataGridViewRow.Selected = true;
                    num -= 5;
                    if (num < 0)
                    {
                        num = 0;
                    }
                    dataGridViewRow = this.dgvPerson.Rows[num];
                    this.dgvPerson.FirstDisplayedScrollingRowIndex = dataGridViewRow.Index;
                }
            }
            else
            {
                this.nUpDTo.Value = value + 1m;
            }

        }

        // Token: 0x040000DF RID: 223
        public Dictionary<int, Family> SelectedSoNos = new Dictionary<int, Family>();

        // Token: 0x040000E0 RID: 224
        private string keySoft;

        // Token: 0x040000E1 RID: 225
        private int lastFindIndex;

        // Token: 0x040000E2 RID: 226
        private bool isLoading;

        // Token: 0x040000E3 RID: 227
        private bool isSelectPrint;

        // Token: 0x040000E4 RID: 228
        private object oldvalue;
    }
}
