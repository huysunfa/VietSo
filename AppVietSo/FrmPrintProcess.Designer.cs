
namespace AppVietSo
{
	public partial class FrmPrintProcess : global::System.Windows.Forms.Form
	{
		// Token: 0x0600011F RID: 287 RVA: 0x00016A08 File Offset: 0x00014C08
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00016A28 File Offset: 0x00014C28
		private void InitializeComponent()
		{
			this.lblStatus = new global::System.Windows.Forms.Label();
			this.btnStop = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblStatus.Location = new global::System.Drawing.Point(0xC, 9);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new global::System.Drawing.Size(0x32, 0x12);
			this.lblStatus.TabIndex = 0;
			this.lblStatus.Text = "Status";
			this.btnStop.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnStop.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnStop.Location = new global::System.Drawing.Point(0x99, 0x49);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new global::System.Drawing.Size(0x8D, 0x23);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "Dừng in";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new global::System.EventHandler(this.btnStop_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(0x132, 0x78);
			base.ControlBox = false;
			base.Controls.Add(this.btnStop);
			base.Controls.Add(this.lblStatus);
			base.Name = "FrmPrintProcess";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Trạng thái in";
			base.Load += new global::System.EventHandler(this.FrmPrintProcess_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000116 RID: 278
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000117 RID: 279
		private global::System.Windows.Forms.Label lblStatus;

		// Token: 0x04000118 RID: 280
		private global::System.Windows.Forms.Button btnStop;
	}
}
