namespace PrintHelper
{
	// Token: 0x02000012 RID: 18
	public partial class FrmKeyRequest : global::System.Windows.Forms.Form
	{
		// Token: 0x0600010D RID: 269 RVA: 0x00006108 File Offset: 0x00004308
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00006134 File Offset: 0x00004334
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::PrintHelper.FrmKeyRequest));
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtFullName = new global::System.Windows.Forms.TextBox();
			this.btnOk = new global::System.Windows.Forms.Button();
			this.lblNote = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.txtPhone = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.txtNote = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.lblSoftKey = new global::System.Windows.Forms.Label();
			this.lblMBQ = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(0xF, 0x3E);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(0x36, 0x11);
			this.label1.TabIndex = 0;
			this.label1.Text = "Họ tên:";
			this.txtFullName.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtFullName.Location = new global::System.Drawing.Point(0x82, 0x35);
			this.txtFullName.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFullName.Name = "txtFullName";
			this.txtFullName.Size = new global::System.Drawing.Size(0x1E6, 0x1A);
			this.txtFullName.TabIndex = 1;
			this.btnOk.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnOk.Location = new global::System.Drawing.Point(0xD6, 0x109);
			this.btnOk.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new global::System.Drawing.Size(0xAE, 0x2C);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "Lưu thông tin";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.lblNote.AutoSize = true;
			this.lblNote.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblNote.ForeColor = global::System.Drawing.Color.Red;
			this.lblNote.Location = new global::System.Drawing.Point(0xF, 0x11);
			this.lblNote.Name = "lblNote";
			this.lblNote.Size = new global::System.Drawing.Size(0x1C3, 0x14);
			this.lblNote.TabIndex = 3;
			this.lblNote.Text = "Quý Thầy hoan hỷ điền đầy đủ thông tin để được hỗ trợ tốt nhất";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(0xF, 0x6A);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(0x4C, 0x11);
			this.label3.TabIndex = 4;
			this.label3.Text = "Điện thoại:";
			this.txtPhone.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtPhone.Location = new global::System.Drawing.Point(0x82, 0x62);
			this.txtPhone.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new global::System.Drawing.Size(0x1E6, 0x1A);
			this.txtPhone.TabIndex = 2;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(0xF, 0xA3);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(0x37, 0x11);
			this.label4.TabIndex = 6;
			this.label4.Text = "Địa chỉ:";
			this.txtNote.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtNote.Location = new global::System.Drawing.Point(0x82, 0x9A);
			this.txtNote.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtNote.Multiline = true;
			this.txtNote.Name = "txtNote";
			this.txtNote.Size = new global::System.Drawing.Size(0x1E6, 0x5E);
			this.txtNote.TabIndex = 3;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label5.Location = new global::System.Drawing.Point(0x7F, 0x80);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(0x167, 0x11);
			this.label5.TabIndex = 8;
			this.label5.Text = "Vui lòng điền đúng số điện thoại để được hỗ trợ tốt nhất";
			this.btnCancel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancel.Location = new global::System.Drawing.Point(0x1BA, 0x109);
			this.btnCancel.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(0xAE, 0x2C);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Đóng cửa sổ";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.lblSoftKey.AutoSize = true;
			this.lblSoftKey.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 13f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblSoftKey.ForeColor = global::System.Drawing.Color.OrangeRed;
			this.lblSoftKey.Location = new global::System.Drawing.Point(0xAF, 0x10);
			this.lblSoftKey.Name = "lblSoftKey";
			this.lblSoftKey.Size = new global::System.Drawing.Size(0x24, 0x16);
			this.lblSoftKey.TabIndex = 0xA;
			this.lblSoftKey.Text = "Mã";
			this.lblMBQ.AutoSize = true;
			this.lblMBQ.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMBQ.Location = new global::System.Drawing.Point(0x10, 0x12);
			this.lblMBQ.Name = "lblMBQ";
			this.lblMBQ.Size = new global::System.Drawing.Size(0x68, 0x12);
			this.lblMBQ.TabIndex = 9;
			this.lblMBQ.Text = "Mã bản quyền:";
			this.lblMBQ.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(0x27C, 0x14B);
			base.Controls.Add(this.lblSoftKey);
			base.Controls.Add(this.lblMBQ);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.txtNote);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.txtPhone);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lblNote);
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.txtFullName);
			base.Controls.Add(this.label1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmKeyRequest";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Thông tin người dùng phần mềm";
			base.Load += new global::System.EventHandler(this.FrmKeyRequest_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000050 RID: 80
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.TextBox txtFullName;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.Label lblNote;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.TextBox txtPhone;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.TextBox txtNote;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.Label lblSoftKey;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Label lblMBQ;
	}
}
