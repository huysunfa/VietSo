using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PrintSo
{
	// Token: 0x02000009 RID: 9
	public partial class FrmPrintNo : Form
	{
		// Token: 0x06000048 RID: 72 RVA: 0x00006561 File Offset: 0x00004761
		public FrmPrintNo()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002678 File Offset: 0x00000878
		private void FrmPrintNo_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00006570 File Offset: 0x00004770
		private void btnPrint_Click(object sender, EventArgs e)
		{
			try
			{
				this.no = (int)this.nUpDown.Value;
				base.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x04000049 RID: 73
		public int no;
	}
}
