using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PrintSo
{
	// Token: 0x0200000A RID: 10
	public partial class FrmProgressOne : Form
	{
		// Token: 0x0600004D RID: 77 RVA: 0x000068A8 File Offset: 0x00004AA8
		public FrmProgressOne()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000068B8 File Offset: 0x00004AB8
		private void FrmProgressOne_Load(object sender, EventArgs e)
		{
			this.lbl.Text = "";
			this.lbl.Parent = this.pBr;
			this.lbl.Location = new Point(5, 5);
			this.lbl.BackColor = Color.Transparent;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00006908 File Offset: 0x00004B08
		public void setInfo(string txt, int percent)
		{
			if (this.lbl.InvokeRequired)
			{
				MethodInvoker method = delegate()
				{
					this.setInfo(txt, percent);
				};
				base.Invoke(method);
				return;
			}
			this.pBr.Value = percent;
			this.lbl.Text = txt;
			this.Refresh();
		}
	}
}
