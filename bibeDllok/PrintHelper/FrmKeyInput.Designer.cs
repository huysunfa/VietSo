namespace PrintHelper
{
	// Token: 0x02000011 RID: 17
	public partial class FrmKeyInput : global::System.Windows.Forms.Form
	{
		// Token: 0x060000EC RID: 236 RVA: 0x00005A3C File Offset: 0x00003C3C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00005A68 File Offset: 0x00003C68
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::PrintHelper.FrmKeyInput));
			this.txtCusKey = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOk = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.txtCusKey.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Upper;
			this.txtCusKey.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtCusKey.Location = new global::System.Drawing.Point(0x7A, 0xB);
			this.txtCusKey.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtCusKey.Name = "txtCusKey";
			this.txtCusKey.Size = new global::System.Drawing.Size(0xF0, 0x1D);
			this.txtCusKey.TabIndex = 0xC;
			this.txtCusKey.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.txtCusKey_KeyDown);
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(0xC, 0x10);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(0x68, 0x12);
			this.label6.TabIndex = 0xB;
			this.label6.Text = "Mã bản quyền:";
			this.btnCancel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancel.Location = new global::System.Drawing.Point(0xE3, 0x3A);
			this.btnCancel.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(0x87, 0x2C);
			this.btnCancel.TabIndex = 0xE;
			this.btnCancel.Text = "Đóng cửa sổ";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOk.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnOk.ForeColor = global::System.Drawing.Color.Firebrick;
			this.btnOk.Location = new global::System.Drawing.Point(0x41, 0x3A);
			this.btnOk.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new global::System.Drawing.Size(0x87, 0x2C);
			this.btnOk.TabIndex = 0xD;
			this.btnOk.Text = "Lưu Mã";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(0x178, 0x76);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.txtCusKey);
			base.Controls.Add(this.label6);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmKeyInput";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mã bản quyền";
			base.Load += new global::System.EventHandler(this.FrmKeyInput_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400004A RID: 74
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.TextBox txtCusKey;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Button btnOk;
	}
}
