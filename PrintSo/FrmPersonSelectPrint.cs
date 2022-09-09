using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataText;
using PrintSo.Properties;

namespace PrintSo
{
	// Token: 0x02000008 RID: 8
	public partial class FrmPersonSelectPrint : Form
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000049C8 File Offset: 0x00002BC8
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

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000036 RID: 54 RVA: 0x000049F8 File Offset: 0x00002BF8
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

		// Token: 0x06000037 RID: 55 RVA: 0x00004A51 File Offset: 0x00002C51
		public FrmPersonSelectPrint()
		{
			this.InitializeComponent();
			this.dgvPerson.AutoGenerateColumns = false;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00004A78 File Offset: 0x00002C78
		private void FrmPersonSelectPrint_Load(object sender, EventArgs e)
		{
			try
			{
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
				if (this.toolCbxChua.ComboBox.SelectedIndex == 0)
				{
					this.toolCbxChua_SelectedIndexChanged(null, null);
				}
				this.lastFindIndex = 0;
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00004C14 File Offset: 0x00002E14
		private void toolCbxChua_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.toolCbxChua.ComboBox.SelectedValue != null)
			{
				this.loadPerson();
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004C30 File Offset: 0x00002E30
		private void loadPerson()
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				this.dgvPerson.DataSource = null;
				this.toolTxtSearch.Text = "";
				DataTable listChuSo = PersonBO.getListChuSo(this.GetPagodaID, "SoNo");
				this.dgvPerson.DataSource = listChuSo;
				this.dgvPerson.Update();
				this.dgvPerson.Refresh();
				this.lblTongLaSo.Text = "Tổng lá sớ: " + listChuSo.Rows.Count.ToString();
				foreach (object obj in ((IEnumerable)this.dgvPerson.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (dataGridViewRow.Cells["NamSinh"].Value.ToString() == "0")
					{
						listChuSo.Rows[dataGridViewRow.Index]["NamSinh"] = DBNull.Value;
					}
				}
				foreach (object obj2 in ((IEnumerable)this.dgvPerson.Rows))
				{
					DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
					if (!string.IsNullOrEmpty(dataGridViewRow2.Cells["NgayMat"].Value.ToString()))
					{
						dataGridViewRow2.DefaultCellStyle.Font = new Font(this.dgvPerson.Font.FontFamily, 12.5f, FontStyle.Italic | FontStyle.Underline);
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004E40 File Offset: 0x00003040
		private void refreshCbxChua()
		{
			this.toolCbxChua.ComboBox.DataSource = null;
			this.toolCbxChua.ComboBox.DataSource = PagodaBO.getAll();
			this.toolCbxChua.ComboBox.DisplayMember = "Name";
			this.toolCbxChua.ComboBox.ValueMember = "ID";
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00004EA0 File Offset: 0x000030A0
		private void toolTxtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.toolBtnSearch.PerformClick();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004EDC File Offset: 0x000030DC
		private void toolBtnSearch_Click(object sender, EventArgs e)
		{
			try
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
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005010 File Offset: 0x00003210
		private void show_checkBox()
		{
			CheckBox checkBox = new CheckBox();
			Rectangle cellDisplayRectangle = this.dgvPerson.GetCellDisplayRectangle(1, -1, true);
			cellDisplayRectangle.X += cellDisplayRectangle.Width / 2 - 8;
			cellDisplayRectangle.Y = cellDisplayRectangle.Height - 17;
			checkBox.BackColor = Color.Transparent;
			checkBox.Name = "checkboxHeader";
			checkBox.Size = new Size(17, 17);
			checkBox.Location = cellDisplayRectangle.Location;
			checkBox.CheckedChanged += this.checkboxHeader_CheckedChanged;
			this.dgvPerson.Controls.Add(checkBox);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000050B4 File Offset: 0x000032B4
		private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)this.dgvPerson.Controls.Find("checkboxHeader", true)[0];
			foreach (object obj in ((IEnumerable)this.dgvPerson.Rows))
			{
				((DataGridViewRow)obj).Cells[1].Value = checkBox.Checked;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005144 File Offset: 0x00003344
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
					if (value != null)
					{
						value.ToString();
					}
					if (!this.SelectedSoNos.ContainsKey(num))
					{
						this.SelectedSoNos.Add(num, new Family
						{
							SoNo = num
						});
					}
				}
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005238 File Offset: 0x00003438
		private void toolBtnPrint_Click(object sender, EventArgs e)
		{
			try
			{
				this.GetSoNos();
				base.Close();
				base.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005274 File Offset: 0x00003474
		private void FrmPersonSelectPrint_SizeChanged(object sender, EventArgs e)
		{
			this.label2.MaximumSize = new Size(this.splitContainer1.Panel1.Width, 0);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005297 File Offset: 0x00003497
		private void nUpDFrom_ValueChanged(object sender, EventArgs e)
		{
			this.setSelected(sender, e);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005297 File Offset: 0x00003497
		private void nUpDTo_ValueChanged(object sender, EventArgs e)
		{
			this.setSelected(sender, e);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000052A4 File Offset: 0x000034A4
		private void setSelected(object sender, EventArgs e)
		{
			try
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
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x0400002D RID: 45
		public Dictionary<int, Family> SelectedSoNos = new Dictionary<int, Family>();

		// Token: 0x0400002E RID: 46
		private int lastFindIndex;
	}
}
