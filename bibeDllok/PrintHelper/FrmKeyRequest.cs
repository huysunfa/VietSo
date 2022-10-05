using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DataModel;
using DataText;

namespace PrintHelper
{
	// Token: 0x02000012 RID: 18
	public partial class FrmKeyRequest : Form
	{
		// Token: 0x06000109 RID: 265 RVA: 0x00005E3C File Offset: 0x0000403C
		public FrmKeyRequest(CustomerKey customerKey_1)
		{
			this.customerKey_0 = customerKey_1;
			this.InitializeComponent();
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00005E5C File Offset: 0x0000405C
		private void FrmKeyRequest_Load(object sender, EventArgs e)
		{
			try
			{
				if (this.customerKey_0 == null)
				{
					this.lblMBQ.Visible = false;
					this.lblSoftKey.Text = "";
				}
				else
				{
					this.txtFullName.Text = this.customerKey_0.Name;
					this.txtPhone.Text = this.customerKey_0.Phone;
					this.txtNote.Text = this.customerKey_0.Note;
					this.lblMBQ.Visible = !string.IsNullOrEmpty(this.customerKey_0.CusKey);
					this.lblSoftKey.Text = this.customerKey_0.CusKey;
				}
				this.lblSoftKey.Visible = this.lblMBQ.Visible;
				this.lblNote.Visible = !this.lblSoftKey.Visible;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00005F70 File Offset: 0x00004170
		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.txtFullName.Text.Trim();
				string text2 = this.txtPhone.Text.Trim();
				string note = this.txtNote.Text.Trim();
				if (string.IsNullOrEmpty(text))
				{
					MessageBox.Show("Xin hãy nhập Họ tên", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (string.IsNullOrEmpty(text2))
				{
					MessageBox.Show("Xin hãy nhập Điện thoại", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (!string.IsNullOrEmpty(this.lblSoftKey.Text))
				{
					string text3 = ExchangeData.ChangeInfo(Util.GetComputerIMEI(), this.lblSoftKey.Text, text, text2, note);
					if (!(text3 == "OK"))
					{
						MessageBox.Show(text3);
					}
					else
					{
						ExchangeData.RegisterKeyOnline(Util.GetComputerIMEI(), this.lblSoftKey.Text, "", "", "");
						MessageBox.Show("Lưu thành công");
						base.DialogResult = DialogResult.OK;
						base.Close();
					}
				}
				else
				{
					string text4 = ExchangeData.RegisterKeyOnline(Util.GetComputerIMEI(), this.lblSoftKey.Text, text, text2, note);
					if (text4 == "OK")
					{
						MessageBox.Show("Cảm ơn quý Thầy");
						base.DialogResult = DialogResult.OK;
						base.Close();
					}
					else
					{
						MessageBox.Show(text4);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000059C8 File Offset: 0x00003BC8
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x0400004F RID: 79
		private CustomerKey customerKey_0;
	}
}
