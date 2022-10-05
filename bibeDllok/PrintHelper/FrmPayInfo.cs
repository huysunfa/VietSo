using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonModel;
using DataModel;

namespace PrintHelper
{
	// Token: 0x02000013 RID: 19
	public partial class FrmPayInfo : Form
	{
		// Token: 0x06000130 RID: 304 RVA: 0x00006A00 File Offset: 0x00004C00
		public FrmPayInfo()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00006A1C File Offset: 0x00004C1C
		private void FrmPayInfo_Load(object sender, EventArgs e)
		{
			try
			{
				this.webBrowser1.Navigate(new Uri(Util.mainURL + "PayInfo.html"));
			}
			catch (Exception ex)
			{
				LogError.log(ex, null, new object[0]);
			}
		}
	}
}
