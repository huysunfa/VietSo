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
	public partial class FrmEditChua : Form
	{
		// Token: 0x06000080 RID: 128 RVA: 0x0000A625 File Offset: 0x00008825
		public FrmEditChua(string keySoft)
		{
			this.keySoft = keySoft;
			this.InitializeComponent();
			this.dgvPagoda.AutoGenerateColumns = false;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000A648 File Offset: 0x00008848
		private void FrmEditChua_Load(object sender, EventArgs e)
		{
			try
			{
				DataTable all = PagodaBO.getAll();
				bool flag = false;
				foreach (object obj in all.Rows)
				{
					object obj2 = ((DataRow)obj)["Name"];
					if (string.IsNullOrWhiteSpace(((obj2 != null) ? obj2.ToString() : null) ?? ""))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					PagodaBO.set(new Pagoda
					{
						ID = (all.Rows.Count + 1).ToString() + this.keySoft,
						KeySoft = this.keySoft
					});
				}
				this.dgvPagoda.DataSource = PagodaBO.getAll();
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000A730 File Offset: 0x00008930
		private void dgvPagoda_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			this.oldvalue = this.dgvPagoda[e.ColumnIndex, e.RowIndex].Value;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000A754 File Offset: 0x00008954
		private void dgvPagoda_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (!this.dgvPagoda[e.ColumnIndex, e.RowIndex].Value.Equals(this.oldvalue))
				{
					DataGridViewRow owningRow = this.dgvPagoda[e.ColumnIndex, e.RowIndex].OwningRow;
					Pagoda pagoda = new Pagoda();
					pagoda.ID = owningRow.Cells["ID"].Value.ToString();
					pagoda.Name = owningRow.Cells["FullName"].Value.ToString().Trim();
					if (string.IsNullOrEmpty(pagoda.Name))
					{
						MessageBox.Show("Tên Chùa / Điện không được để trống", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						pagoda.Leader = owningRow.Cells["Leader"].Value.ToString();
						pagoda.Address = owningRow.Cells["Address"].Value.ToString();
						pagoda.Status = "Changed";
						pagoda.UpdateDT = DateTime.Now;
						PagodaBO.update(pagoda);
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000A89C File Offset: 0x00008A9C
		private void FrmEditChua_FormClosing(object sender, FormClosingEventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x0400007D RID: 125
		private string keySoft;

		// Token: 0x0400007E RID: 126
		private object oldvalue;
	}
}
