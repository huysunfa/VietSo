namespace PrintSo
{
	// Token: 0x0200000A RID: 10
	public partial class FrmProgressOne : global::System.Windows.Forms.Form
	{
		// Token: 0x06000050 RID: 80 RVA: 0x0000697B File Offset: 0x00004B7B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000699C File Offset: 0x00004B9C
		private void InitializeComponent()
		{
			this.pBr = new global::System.Windows.Forms.ProgressBar();
			this.lbl = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.pBr.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pBr.Location = new global::System.Drawing.Point(0, 0);
			this.pBr.Name = "pBr";
			this.pBr.Size = new global::System.Drawing.Size(453, 30);
			this.pBr.TabIndex = 0;
			this.lbl.AutoSize = true;
			this.lbl.BackColor = global::System.Drawing.Color.Transparent;
			this.lbl.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lbl.Location = new global::System.Drawing.Point(8, 8);
			this.lbl.Name = "lbl";
			this.lbl.Size = new global::System.Drawing.Size(60, 24);
			this.lbl.TabIndex = 1;
			this.lbl.Text = "label1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(10f, 20f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(453, 39);
			base.Controls.Add(this.lbl);
			base.Controls.Add(this.pBr);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmProgressOne";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bibe.vn - Xin chờ trong giây lát";
			base.Load += new global::System.EventHandler(this.FrmProgressOne_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400004E RID: 78
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.ProgressBar pBr;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Label lbl;
	}
}
