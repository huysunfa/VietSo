using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DataModel;
using DataText;

namespace PrintSo
{
	// Token: 0x02000016 RID: 22
	public partial class FrmThietLapTinChu : Form
	{
		// Token: 0x0600012B RID: 299 RVA: 0x00017DE2 File Offset: 0x00015FE2
		public FrmThietLapTinChu(ThietLapTinChu ttc)
		{
			this.ttc = ttc;
			this.InitializeComponent();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00017DF8 File Offset: 0x00015FF8
		private void FrmThemChuSauTinChu_Load(object sender, EventArgs e)
		{
			try
			{
				this.txtForm.Text = this.ttc.FormText;
				this.txtMore.Text = this.ttc.MoreText;
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00017E4C File Offset: 0x0001604C
		private void btnClose_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.txtMore.Text.Trim();
				if (!string.IsNullOrWhiteSpace(text))
				{
					text = Util.RemoveDoubleSpace(text);
				}
				string text2 = this.txtForm.Text.Trim();
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text2 = Util.RemoveDoubleSpace(text2);
				}
				this.ttc.MoreText = text;
				this.ttc.FormText = text2;
				base.Close();
				base.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x04000131 RID: 305
		private ThietLapTinChu ttc;
	}
}
