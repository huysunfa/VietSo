namespace PrintHelper
{
	// Token: 0x02000013 RID: 19
	public partial class FrmPayInfo : global::System.Windows.Forms.Form
	{
		// Token: 0x06000132 RID: 306 RVA: 0x00006A68 File Offset: 0x00004C68
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00006A94 File Offset: 0x00004C94
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::PrintHelper.FrmPayInfo));
			this.webBrowser1 = new global::System.Windows.Forms.WebBrowser();
			base.SuspendLayout();
			this.webBrowser1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new global::System.Drawing.Point(0, 0);
			this.webBrowser1.Margin = new global::System.Windows.Forms.Padding(4);
			this.webBrowser1.MinimumSize = new global::System.Drawing.Size(0x1B, 0x19);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new global::System.Drawing.Size(0x3A7, 0x217);
			this.webBrowser1.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(0x3A7, 0x217);
			base.Controls.Add(this.webBrowser1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MinimizeBox = false;
			base.Name = "FrmPayInfo";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thông tin giá bản quyền";
			base.Load += new global::System.EventHandler(this.FrmPayInfo_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x0400005D RID: 93
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.WebBrowser webBrowser1;
	}
}
