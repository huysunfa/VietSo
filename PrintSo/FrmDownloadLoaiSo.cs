using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel;
using DataModel.Entities;
using DataText;

namespace PrintSo
{
	// Token: 0x0200000E RID: 14
	public partial class FrmDownloadLoaiSo : Form
	{
		// Token: 0x06000070 RID: 112 RVA: 0x00008F83 File Offset: 0x00007183
		public FrmDownloadLoaiSo(List<LongSo> lSL, string error)
		{
			this.InitializeComponent();
			this.error = error;
			this.lSL = lSL;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00008FAC File Offset: 0x000071AC
		private void FrmDownloadLoaiSo_Load(object sender, EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				if (this.lSL == null)
				{
					this.lSL = new List<LongSo>();
					this.Text = this.error;
				}
				this.bgWorker.DoWork += this.bgWorker_DoWork;
				this.bgWorker.RunWorkerCompleted += this.bgWorker_RunWorkerCompleted;
				this.bgWorker.RunWorkerAsync();
				this.lastFindIndex = 0;
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000903C File Offset: 0x0000723C
		private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				foreach (string path in (from file in Directory.EnumerateFiles(Util.getDataPath)
				where file.ToLower().EndsWith("bibe") || file.ToLower().EndsWith("cus")
				select file).ToList<string>())
				{
					string fn = Path.GetFileNameWithoutExtension(path);
					if (!this.lSL.Any((LongSo l) => l.FileName == fn))
					{
						LongSoData longSo = LePhat.getLongSo(fn);
						LongSo longSo2 = new LongSo();
						longSo2.LoaiSo = longSo.LoaiSo;
						longSo2.TenSo = (string.IsNullOrWhiteSpace(longSo.TenSo) ? fn : longSo.TenSo);
						longSo2.ChuGiai = longSo.ChuGiai;
						longSo2.FileName = fn;
						this.lSL.Add(longSo2);
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00009164 File Offset: 0x00007364
		private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				string text = "";
				foreach (LongSo longSo in this.lSL)
				{
					if (string.IsNullOrEmpty(longSo.LoaiSo))
					{
						longSo.LoaiSo = "Khác";
					}
					if (!text.Equals(longSo.LoaiSo, StringComparison.OrdinalIgnoreCase))
					{
						text = longSo.LoaiSo;
						int index = this.dgvParent.Rows.Add();
						this.dgvParent.Rows[index].Cells["LoaiSo"].Value = text;
					}
					int index2 = this.dgvLongSo.Rows.Add();
					DataGridViewRow dataGridViewRow = this.dgvLongSo.Rows[index2];
					dataGridViewRow.Cells["ID"].Value = longSo.ID;
					dataGridViewRow.Cells["LoaiSo1"].Value = longSo.LoaiSo;
					dataGridViewRow.Cells["TenSo"].Value = longSo.TenSo;
					dataGridViewRow.Cells["ChuGiai"].Value = longSo.ChuGiai;
					dataGridViewRow.Cells["FileName"].Value = longSo.FileName;
					if (File.Exists(Util.getDataPath + longSo.FileName + ".bibe"))
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
			catch (Exception ex)
			{
				LogError.show(ex);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000093AC File Offset: 0x000075AC
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
						foreach (object obj in ((IEnumerable)this.dgvLongSo.Rows))
						{
							DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
							string text2 = text;
							object value2 = dataGridViewRow.Cells["LoaiSo1"].Value;
							if (text2.Equals(((value2 != null) ? value2.ToString() : null) ?? "", StringComparison.OrdinalIgnoreCase))
							{
								this.dgvLongSo.FirstDisplayedScrollingRowIndex = dataGridViewRow.Index;
								this.dgvLongSo.ClearSelection();
								dataGridViewRow.Selected = true;
								break;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
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
				LogError.show(ex);
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000094EC File Offset: 0x000076EC
		private void btnFind_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.txt.Text.Trim().ToLower();
				if (!string.IsNullOrWhiteSpace(text))
				{
					bool flag = false;
					text = Util.NonUnicode(text);
					for (int i = this.lastFindIndex; i < this.dgvLongSo.Rows.Count; i++)
					{
						DataGridViewRow dataGridViewRow = this.dgvLongSo.Rows[i];
						if (Util.NonUnicode(dataGridViewRow.Cells["TenSo"].Value.ToString().ToLower()).Contains(text))
						{
							this.dgvLongSo.FirstDisplayedScrollingRowIndex = dataGridViewRow.Index;
							this.dgvLongSo.ClearSelection();
							dataGridViewRow.Selected = true;
							this.lastFindIndex = dataGridViewRow.Index + 1;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						this.lastFindIndex = 0;
						if (!this.lblSuggestInfo.Visible)
						{
							new Task(delegate(object obj)
							{
								Thread.Sleep(6789);
								if (this.lblSuggestInfo.InvokeRequired)
								{
									this.lblSuggestInfo.Invoke(new MethodInvoker(delegate()
									{
										this.lblSuggestInfo.Visible = false;
									}));
								}
							}, "SuggestInfo").Start();
						}
						this.lblSuggestInfo.Visible = true;
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00009620 File Offset: 0x00007820
		private void btnClose_Click(object sender, EventArgs e)
		{
			if (0 < this.dgvLongSo.SelectedRows.Count)
			{
				DataGridViewRow dataGridViewRow = this.dgvLongSo.SelectedRows[0];
				object value = dataGridViewRow.Cells["FileName"].Value;
				this.FName = (((value != null) ? value.ToString() : null) ?? "");
				if (File.Exists(Util.getDataPath + this.FName + ".bibe") || File.Exists(Util.getDataPath + this.FName + ".cus"))
				{
					base.DialogResult = DialogResult.OK;
					return;
				}
				if (MessageBox.Show("Lòng sớ Thầy chọn chưa có sẵn trên máy, Thầy có muốn tải về từ internet không?", "Xác nhận tải", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					if (ExchangeLongSo.downloadFile(this.FName))
					{
						object value2 = dataGridViewRow.Cells["TenSo"].Value;
						this.updateTenSo(((value2 != null) ? value2.ToString() : null) ?? "");
						base.DialogResult = DialogResult.OK;
						return;
					}
					MessageBox.Show("Tải file thất bại. Xin hãy kiểm tra kết nối internet, hoặc liên hệ với Bibe.vn", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
			}
			else
			{
				MessageBox.Show("Xin hãy click chọn lòng sớ", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
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
						MessageBox.Show("File này chỉ có ở máy của Thầy, không có trên mạng nên không cần tải về!", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						object value = dataGridViewRow.Cells["FileName"].Value;
						this.FName = (((value != null) ? value.ToString() : null) ?? "");
						if (ExchangeLongSo.downloadFile(this.FName))
						{
							object value2 = dataGridViewRow.Cells["TenSo"].Value;
							this.updateTenSo(((value2 != null) ? value2.ToString() : null) ?? "");
							MessageBox.Show("Tải file thành công", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							MessageBox.Show("Tải file thất bại. Xin hãy kiểm tra kết nối internet, hoặc liên hệ với Bibe.vn", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00009898 File Offset: 0x00007A98
		private void dgvLongSo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.btnClose_Click(null, null);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000098A4 File Offset: 0x00007AA4
		private void updateTenSo(string tenSo)
		{
			LePhat.ClearLgSo();
			LongSoData longSo = LePhat.getLongSo(this.FName);
			if (longSo != null)
			{
				longSo.TenSo = tenSo;
			}
			LePhat.saveLongSo(longSo, Util.getDataPath + this.FName + ".bibe");
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000098E7 File Offset: 0x00007AE7
		private static int compareByName(ComboboxItem cbi, ComboboxItem cbi1)
		{
			return string.Compare(cbi.Text, cbi1.Text);
		}

		// Token: 0x04000067 RID: 103
		private int lastFindIndex;

		// Token: 0x04000068 RID: 104
		public string FName;

		// Token: 0x04000069 RID: 105
		private List<LongSo> lSL;

		// Token: 0x0400006A RID: 106
		private string error;

		// Token: 0x0400006B RID: 107
		private BackgroundWorker bgWorker = new BackgroundWorker();
	}
}
