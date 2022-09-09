namespace PrintSo
{
	// Token: 0x02000016 RID: 22
	public partial class FrmThietLapTinChu : global::System.Windows.Forms.Form
	{
		// Token: 0x0600012E RID: 302 RVA: 0x00017ED8 File Offset: 0x000160D8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00017EF8 File Offset: 0x000160F8
		private void InitializeComponent()
		{
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.txtForm = new global::System.Windows.Forms.TextBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.txtMore = new global::System.Windows.Forms.TextBox();
			//this.toolTipCustom1 = new global::PrintSo.ToolTipCustom();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
			this.splitContainer1.Panel1.Controls.Add(this.btnClose);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Size = new global::System.Drawing.Size(895, 429);
			this.splitContainer1.SplitterDistance = 221;
			this.splitContainer1.TabIndex = 0;
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(221, 333);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Ký hiệu dùng trong khuôn mẫu";
			this.textBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new global::System.Drawing.Point(3, 20);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(215, 310);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "$danh  (Danh xưng)\r\n$ten  (Họ Tên)\r\n$canchi  (Can, Chi)\r\n$tuoi   (Tuổi 'Chữ')\r\n$sotuoi  (Tuổi 'Số')\r\n$sao  (Tên Sao)\r\n$quantien  (Quan Tiền)\r\n";
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.btnClose.BackColor = global::System.Drawing.Color.FromArgb(255, 128, 0);
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.Location = new global::System.Drawing.Point(12, 384);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(102, 34);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Lưu";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.groupBox2.Controls.Add(this.txtForm);
			this.groupBox2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(670, 227);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Khuôn mẫu thể hiện 1 Tín chủ";
			this.txtForm.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.txtForm.Location = new global::System.Drawing.Point(3, 20);
			this.txtForm.Multiline = true;
			this.txtForm.Name = "txtForm";
			this.txtForm.Size = new global::System.Drawing.Size(664, 204);
			this.txtForm.TabIndex = 0;
			this.groupBox1.Controls.Add(this.txtMore);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new global::System.Drawing.Point(0, 250);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(670, 179);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thêm chữ sau phần tín chủ";
			this.txtMore.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.txtMore.Location = new global::System.Drawing.Point(3, 20);
			this.txtMore.Multiline = true;
			this.txtMore.Name = "txtMore";
			this.txtMore.Size = new global::System.Drawing.Size(664, 156);
			this.txtMore.TabIndex = 0;
			this.txtMore.Text = "Hợp đồng gia quyến đẳng cầu tài cầu lộc cầu bình an";
			//this.toolTipCustom1.OwnerDraw = true;
			//this.toolTipCustom1.ShowAlways = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 18f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(895, 429);
			base.Controls.Add(this.splitContainer1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(5, 4, 5, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmThietLapTinChu";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Thiết lập phần Tín chủ";
			base.Load += new global::System.EventHandler(this.FrmThemChuSauTinChu_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000132 RID: 306
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.TextBox txtMore;

		// Token: 0x04000136 RID: 310
		//private global::PrintSo.ToolTipCustom toolTipCustom1;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.TextBox txtForm;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.GroupBox groupBox3;
	}
}
