using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DataModel;
using DataText;

namespace PrintHelper
{
	// Token: 0x02000011 RID: 17
	public partial class FrmKeyInput : Form
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x000058C8 File Offset: 0x00003AC8
		public FrmKeyInput()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000058E4 File Offset: 0x00003AE4
		private void FrmKeyInput_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000058F4 File Offset: 0x00003AF4
		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(this.txtCusKey.Text))
				{
					MessageBox.Show("Xin hãy nhâp mã bản quyền", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.txtCusKey.Focus();
				}
				else
				{
					string text = ExchangeData.RegisterKeyOnline(Util.GetComputerIMEI(), this.txtCusKey.Text.Trim(), "", "", "");
					if (!(text == "OK"))
					{
						MessageBox.Show(text);
					}
					else
					{
						MessageBox.Show("Cảm ơn quý Thầy");
						base.DialogResult = DialogResult.OK;
						base.Close();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000059C8 File Offset: 0x00003BC8
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000059E4 File Offset: 0x00003BE4
		private void txtCusKey_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					this.btnOk_Click(null, null);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
