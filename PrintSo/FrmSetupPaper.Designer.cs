namespace PrintSo
{
	// Token: 0x02000015 RID: 21
	public partial class FrmSetupPaper : global::System.Windows.Forms.Form
	{
		// Token: 0x06000129 RID: 297 RVA: 0x000170CC File Offset: 0x000152CC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000170EC File Offset: 0x000152EC
		private void InitializeComponent()
		{
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.nmrHeight = new global::System.Windows.Forms.NumericUpDown();
			this.nmrWidth = new global::System.Windows.Forms.NumericUpDown();
			this.nmrTop = new global::System.Windows.Forms.NumericUpDown();
			this.nmrBottom = new global::System.Windows.Forms.NumericUpDown();
			this.nmrLeft = new global::System.Windows.Forms.NumericUpDown();
			this.nmrRight = new global::System.Windows.Forms.NumericUpDown();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.cbxPaperSize = new global::System.Windows.Forms.ComboBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.btnPrintSetting = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.nmrHeight).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrWidth).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrTop).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrBottom).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrLeft).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrRight).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(19, 30);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(29, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Dài";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(6, 62);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(42, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "Rộng";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(72, 128);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(37, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "Dưới";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(73, 36);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(38, 17);
			this.label5.TabIndex = 6;
			this.label5.Text = "Trên";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(173, 82);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(36, 17);
			this.label7.TabIndex = 12;
			this.label7.Text = "Phải";
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(11, 79);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(33, 17);
			this.label8.TabIndex = 10;
			this.label8.Text = "Trái";
			this.nmrHeight.Location = new global::System.Drawing.Point(62, 60);
			this.nmrHeight.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.nmrHeight;
			int[] array = new int[4];
			array[0] = 300;
			//numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.nmrHeight;
			int[] array2 = new int[4];
			array2[0] = 210;
			//numericUpDown2.Minimum = new decimal(array2);
			this.nmrHeight.Name = "nmrHeight";
			this.nmrHeight.Size = new global::System.Drawing.Size(101, 23);
			this.nmrHeight.TabIndex = 2;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.nmrHeight;
			int[] array3 = new int[4];
			array3[0] = 210;
			//numericUpDown3.Value = new decimal(array3);
			this.nmrHeight.ValueChanged += new global::System.EventHandler(this.nmr_ValueChanged);
			this.nmrWidth.Location = new global::System.Drawing.Point(62, 28);
			this.nmrWidth.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.nmrWidth;
			int[] array4 = new int[4];
			array4[0] = 1000;
			//numericUpDown4.Maximum = new decimal(array4);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.nmrWidth;
			int[] array5 = new int[4];
			array5[0] = 210;
			//numericUpDown5.Minimum = new decimal(array5);
			this.nmrWidth.Name = "nmrWidth";
			this.nmrWidth.Size = new global::System.Drawing.Size(101, 23);
			this.nmrWidth.TabIndex = 1;
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.nmrWidth;
			int[] array6 = new int[4];
			array6[0] = 210;
			//numericUpDown6.Value = new decimal(array6);
			this.nmrWidth.ValueChanged += new global::System.EventHandler(this.nmr_ValueChanged);
			this.nmrTop.Location = new global::System.Drawing.Point(122, 31);
			this.nmrTop.Margin = new global::System.Windows.Forms.Padding(5);
			this.nmrTop.Name = "nmrTop";
			this.nmrTop.Size = new global::System.Drawing.Size(50, 23);
			this.nmrTop.TabIndex = 3;
			this.nmrTop.ValueChanged += new global::System.EventHandler(this.nmr_ValueChanged);
			this.nmrBottom.Location = new global::System.Drawing.Point(122, 126);
			this.nmrBottom.Margin = new global::System.Windows.Forms.Padding(5);
			this.nmrBottom.Name = "nmrBottom";
			this.nmrBottom.Size = new global::System.Drawing.Size(50, 23);
			this.nmrBottom.TabIndex = 4;
			this.nmrBottom.ValueChanged += new global::System.EventHandler(this.nmr_ValueChanged);
			this.nmrLeft.Location = new global::System.Drawing.Point(57, 77);
			this.nmrLeft.Margin = new global::System.Windows.Forms.Padding(5);
			this.nmrLeft.Name = "nmrLeft";
			this.nmrLeft.Size = new global::System.Drawing.Size(50, 23);
			this.nmrLeft.TabIndex = 5;
			this.nmrLeft.ValueChanged += new global::System.EventHandler(this.nmr_ValueChanged);
			this.nmrRight.Location = new global::System.Drawing.Point(223, 77);
			this.nmrRight.Margin = new global::System.Windows.Forms.Padding(5);
			this.nmrRight.Name = "nmrRight";
			this.nmrRight.Size = new global::System.Drawing.Size(50, 23);
			this.nmrRight.TabIndex = 6;
			this.nmrRight.ValueChanged += new global::System.EventHandler(this.nmr_ValueChanged);
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(171, 30);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(30, 17);
			this.label9.TabIndex = 13;
			this.label9.Text = "mm";
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(171, 62);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(30, 17);
			this.label10.TabIndex = 14;
			this.label10.Text = "mm";
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.cbxPaperSize);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.nmrHeight);
			this.groupBox1.Controls.Add(this.nmrWidth);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(397, 100);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Khổ giấy";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(220, 30);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(98, 17);
			this.label6.TabIndex = 17;
			this.label6.Text = "Chọn khổ giấy";
			this.cbxPaperSize.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxPaperSize.FormattingEnabled = true;
			this.cbxPaperSize.Location = new global::System.Drawing.Point(223, 59);
			this.cbxPaperSize.Name = "cbxPaperSize";
			this.cbxPaperSize.Size = new global::System.Drawing.Size(156, 24);
			this.cbxPaperSize.TabIndex = 16;
			this.cbxPaperSize.SelectedIndexChanged += new global::System.EventHandler(this.cbxPaperSize_SelectedIndexChanged);
			this.groupBox2.Controls.Add(this.nmrLeft);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.nmrRight);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.nmrBottom);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.nmrTop);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 149);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(287, 163);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Khoảng cách mép giấy";
			this.btnPrintSetting.Location = new global::System.Drawing.Point(338, 149);
			this.btnPrintSetting.Name = "btnPrintSetting";
			this.btnPrintSetting.Size = new global::System.Drawing.Size(164, 28);
			this.btnPrintSetting.TabIndex = 16;
			this.btnPrintSetting.Text = "Cài đặt máy in";
			this.btnPrintSetting.UseVisualStyleBackColor = true;
			this.btnPrintSetting.Click += new global::System.EventHandler(this.btnPrintSetting_Click);
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.Red;
			this.label1.Location = new global::System.Drawing.Point(9, 6);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(230, 17);
			this.label1.TabIndex = 17;
			this.label1.Text = "Khổ giấy nên để là A3s (470 x 297)";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(514, 343);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnPrintSetting);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmSetupPaper";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cài đặt khổ giấy";
			base.Load += new global::System.EventHandler(this.FrmSetupPaper_Load);
			((global::System.ComponentModel.ISupportInitialize)this.nmrHeight).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrWidth).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrTop).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrBottom).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrLeft).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrRight).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400011C RID: 284
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.NumericUpDown nmrHeight;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.NumericUpDown nmrWidth;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.NumericUpDown nmrTop;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.NumericUpDown nmrBottom;

		// Token: 0x04000127 RID: 295
		private global::System.Windows.Forms.NumericUpDown nmrLeft;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.NumericUpDown nmrRight;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.Button btnPrintSetting;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.ComboBox cbxPaperSize;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.Label label6;
	}
}
