namespace PrintDoc
{
	// Token: 0x0200000D RID: 13
	public partial class FrmHeaderFooter : global::System.Windows.Forms.Form
	{
		// Token: 0x06000071 RID: 113 RVA: 0x00004D4C File Offset: 0x00002F4C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004D78 File Offset: 0x00002F78
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.txtLeft = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.txtCenter = new global::System.Windows.Forms.TextBox();
			this.txtRight = new global::System.Windows.Forms.TextBox();
			this.rbtnHeader = new global::System.Windows.Forms.RadioButton();
			this.rbtnFooter = new global::System.Windows.Forms.RadioButton();
			this.label4 = new global::System.Windows.Forms.Label();
			this.btnInsertPage = new global::System.Windows.Forms.Button();
			this.btnInsertPages = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(0x228, 0x8C);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(0x2A, 0x14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Phải";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(0x65, 0x8C);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(0x26, 0x14);
			this.label2.TabIndex = 1;
			this.label2.Text = "Trái";
			this.txtLeft.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtLeft.Location = new global::System.Drawing.Point(0xF, 0xA0);
			this.txtLeft.Multiline = true;
			this.txtLeft.Name = "txtLeft";
			this.txtLeft.Size = new global::System.Drawing.Size(0xCD, 0xA5);
			this.txtLeft.TabIndex = 3;
			this.txtLeft.Leave += new global::System.EventHandler(this.txtRight_Leave);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(0x144, 0x8C);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(0x2C, 0x14);
			this.label3.TabIndex = 4;
			this.label3.Text = "Giữa";
			this.txtCenter.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtCenter.Location = new global::System.Drawing.Point(0xE9, 0xA0);
			this.txtCenter.Multiline = true;
			this.txtCenter.Name = "txtCenter";
			this.txtCenter.Size = new global::System.Drawing.Size(0xCD, 0xA5);
			this.txtCenter.TabIndex = 5;
			this.txtCenter.Text = "Trang &[Page]/ Tổng &[Pages]";
			this.txtCenter.Leave += new global::System.EventHandler(this.txtRight_Leave);
			this.txtRight.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtRight.Location = new global::System.Drawing.Point(0x1C3, 0xA0);
			this.txtRight.Multiline = true;
			this.txtRight.Name = "txtRight";
			this.txtRight.Size = new global::System.Drawing.Size(0xCD, 0xA5);
			this.txtRight.TabIndex = 6;
			this.txtRight.Leave += new global::System.EventHandler(this.txtRight_Leave);
			this.rbtnHeader.AutoSize = true;
			this.rbtnHeader.Location = new global::System.Drawing.Point(0x1E, 0xC);
			this.rbtnHeader.Name = "rbtnHeader";
			this.rbtnHeader.Size = new global::System.Drawing.Size(0x67, 0x18);
			this.rbtnHeader.TabIndex = 7;
			this.rbtnHeader.TabStop = true;
			this.rbtnHeader.Text = "Đầu trang";
			this.rbtnHeader.UseVisualStyleBackColor = true;
			this.rbtnFooter.AutoSize = true;
			this.rbtnFooter.Location = new global::System.Drawing.Point(0xB3, 0xC);
			this.rbtnFooter.Name = "rbtnFooter";
			this.rbtnFooter.Size = new global::System.Drawing.Size(0x70, 0x18);
			this.rbtnFooter.TabIndex = 8;
			this.rbtnFooter.TabStop = true;
			this.rbtnFooter.Text = "Chân trang";
			this.rbtnFooter.UseVisualStyleBackColor = true;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DarkRed;
			this.label4.Location = new global::System.Drawing.Point(0xC, 0x3B);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(0x28C, 0x18);
			this.label4.TabIndex = 9;
			this.label4.Text = "Muốn có chữ ở phần nào (Trái, giữa hoặc phải) thì gõ chữ ở phần đó";
			this.btnInsertPage.Location = new global::System.Drawing.Point(0x81, 0x60);
			this.btnInsertPage.Name = "btnInsertPage";
			this.btnInsertPage.Size = new global::System.Drawing.Size(0x78, 0x1F);
			this.btnInsertPage.TabIndex = 0xA;
			this.btnInsertPage.Text = "Chèn số trang";
			this.btnInsertPage.UseVisualStyleBackColor = true;
			this.btnInsertPage.Click += new global::System.EventHandler(this.btnInsertPage_Click);
			this.btnInsertPages.Location = new global::System.Drawing.Point(0x110, 0x60);
			this.btnInsertPages.Name = "btnInsertPages";
			this.btnInsertPages.Size = new global::System.Drawing.Size(0x93, 0x1F);
			this.btnInsertPages.TabIndex = 0xB;
			this.btnInsertPages.Text = "Chèn tổng số trang";
			this.btnInsertPages.UseVisualStyleBackColor = true;
			this.btnInsertPages.Click += new global::System.EventHandler(this.btnInsertPages_Click);
			this.btnOK.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnOK.Location = new global::System.Drawing.Point(0x18B, 0x157);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(0x7B, 0x2A);
			this.btnOK.TabIndex = 0xC;
			this.btnOK.Text = "Đồng ý";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancel.Location = new global::System.Drawing.Point(0x21E, 0x157);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(0x72, 0x2A);
			this.btnCancel.TabIndex = 0xD;
			this.btnCancel.Text = "Hủy bỏ";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(10f, 20f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(0x29C, 0x18D);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.btnInsertPages);
			base.Controls.Add(this.btnInsertPage);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.rbtnFooter);
			base.Controls.Add(this.rbtnHeader);
			base.Controls.Add(this.txtRight);
			base.Controls.Add(this.txtCenter);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.txtLeft);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MinimizeBox = false;
			base.Name = "FrmHeaderFooter";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đầu trang - Chân trang";
			base.Load += new global::System.EventHandler(this.FrmHeaderFooter_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000033 RID: 51
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.TextBox txtLeft;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.TextBox txtCenter;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.TextBox txtRight;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.RadioButton rbtnHeader;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.RadioButton rbtnFooter;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.Button btnInsertPage;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.Button btnInsertPages;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.Button btnCancel;
	}
}
