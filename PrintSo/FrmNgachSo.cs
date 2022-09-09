using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DataModel;
using DataText;

namespace PrintSo
{
	// Token: 0x02000005 RID: 5
	public partial class FrmNgachSo : Form
	{
		// Token: 0x06000027 RID: 39 RVA: 0x00004178 File Offset: 0x00002378
		private void FrmNgachSo_Load(object sender, EventArgs e)
		{
			try
			{
				DataTable dataTable;
				if (File.Exists(Util.getDataPath + "ngachso.ngs"))
				{
					dataTable = Security.readFile<DataTable>(Util.getDataPath + "ngachso.ngs");
				}
				else
				{
					dataTable = new DataTable();
					dataTable.Columns.Add("NgSChecked");
					dataTable.Columns.Add("NgSName");
					dataTable.Columns.Add("NgSContent");
				}
				this.dgvNgS.DataSource = dataTable;
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002E18 File Offset: 0x00001018
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00004210 File Offset: 0x00002410
		public FrmNgachSo()
		{
			this.InitializeComponent();
			this.dgvNgS.AutoGenerateColumns = false;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000422C File Offset: 0x0000242C
		private void FrmNgachSo_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.dgvNgS.EndEdit();
				DataTable dataTable = this.dgvNgS.DataSource as DataTable;
				if (!dataTable.Columns.Contains("NgSChecked"))
				{
					dataTable.Columns.Add("NgSChecked");
				}
				if (!dataTable.Columns.Contains("NgSName"))
				{
					dataTable.Columns.Add("NgSName");
				}
				if (!dataTable.Columns.Contains("NgSContent"))
				{
					dataTable.Columns.Add("NgSContent");
				}
				Security.writeFile(dataTable, Util.getDataPath + "ngachso.ngs");
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000042F0 File Offset: 0x000024F0
		private void dgvNgS_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if ((sender as DataGridView).Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
				{
					for (int i = 0; i < this.dgvNgS.RowCount; i++)
					{
						if (e.RowIndex != i && !(this.dgvNgS.Rows[i].Cells["NgSChecked"].Value is DBNull) && Convert.ToBoolean(this.dgvNgS.Rows[i].Cells["NgSChecked"].Value))
						{
							this.dgvNgS.Rows[i].Cells["NgSChecked"].Value = false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}
	}
}
