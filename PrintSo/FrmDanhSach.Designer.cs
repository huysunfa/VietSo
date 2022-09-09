namespace PrintSo
{
	// Token: 0x02000004 RID: 4
	public partial class FrmDanhSach : global::System.Windows.Forms.Form
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00003012 File Offset: 0x00001212
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003034 File Offset: 0x00001234
		private void InitializeComponent()
		{
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.cbxFontStyle = new global::System.Windows.Forms.ComboBox();
			this.numUpDownFontSize = new global::System.Windows.Forms.NumericUpDown();
			this.cbxFontName = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnKhuonTinChu = new global::System.Windows.Forms.Button();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.cbxIsAddress = new global::System.Windows.Forms.CheckBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.lblPageTotal = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.nmrRows = new global::System.Windows.Forms.NumericUpDown();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.nmrCols = new global::System.Windows.Forms.NumericUpDown();
			this.btnPrintSetting = new global::System.Windows.Forms.Button();
			this.ckxPersonPerCol = new global::System.Windows.Forms.CheckBox();
			this.btnPrintPreview = new global::System.Windows.Forms.Button();
			this.btnTinChu = new global::System.Windows.Forms.Button();
			this.reoGridControl1 = new global::unvell.ReoGrid.ReoGridControl();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numUpDownFontSize).BeginInit();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nmrRows).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrCols).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.cbxFontStyle);
			this.splitContainer1.Panel1.Controls.Add(this.numUpDownFontSize);
			this.splitContainer1.Panel1.Controls.Add(this.cbxFontName);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.btnKhuonTinChu);
			this.splitContainer1.Panel1.Controls.Add(this.btnClose);
			this.splitContainer1.Panel1.Controls.Add(this.cbxIsAddress);
			this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
			this.splitContainer1.Panel1.Controls.Add(this.btnPrintSetting);
			this.splitContainer1.Panel1.Controls.Add(this.ckxPersonPerCol);
			this.splitContainer1.Panel1.Controls.Add(this.btnPrintPreview);
			this.splitContainer1.Panel1.Controls.Add(this.btnTinChu);
			this.splitContainer1.Panel2.Controls.Add(this.reoGridControl1);
			this.splitContainer1.Size = new global::System.Drawing.Size(1641, 785);
			this.splitContainer1.SplitterDistance = 241;
			this.splitContainer1.TabIndex = 1;
			this.cbxFontStyle.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxFontStyle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbxFontStyle.FormattingEnabled = true;
			this.cbxFontStyle.Items.AddRange(new object[]
			{
				"Đậm",
				"Thường",
				"Nghiêng"
			});
			this.cbxFontStyle.Location = new global::System.Drawing.Point(11, 472);
			this.cbxFontStyle.Name = "cbxFontStyle";
			this.cbxFontStyle.Size = new global::System.Drawing.Size(153, 33);
			this.cbxFontStyle.TabIndex = 62;
			this.cbxFontStyle.SelectedIndexChanged += new global::System.EventHandler(this.cbxFontStyle_SelectedIndexChanged);
			this.numUpDownFontSize.DecimalPlaces = 1;
			this.numUpDownFontSize.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numUpDownFontSize.Increment = new decimal(new int[]
			{
				5,
				0,
				0,
				65536
			});
			this.numUpDownFontSize.Location = new global::System.Drawing.Point(11, 440);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numUpDownFontSize;
			int[] array = new int[4];
			array[0] = 50;
//			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numUpDownFontSize;
			int[] array2 = new int[4];
			array2[0] = 9;
//			numericUpDown2.Minimum = new decimal(array2);
			this.numUpDownFontSize.Name = "numUpDownFontSize";
			this.numUpDownFontSize.Size = new global::System.Drawing.Size(113, 30);
			this.numUpDownFontSize.TabIndex = 61;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numUpDownFontSize;
			int[] array3 = new int[4];
			array3[0] = 9;
//			numericUpDown3.Value = new decimal(array3);
			this.numUpDownFontSize.ValueChanged += new global::System.EventHandler(this.numUpDownFontSize_ValueChanged);
			this.cbxFontName.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbxFontName.FormattingEnabled = true;
			this.cbxFontName.Location = new global::System.Drawing.Point(12, 527);
			this.cbxFontName.Name = "cbxFontName";
			this.cbxFontName.Size = new global::System.Drawing.Size(197, 33);
			this.cbxFontName.TabIndex = 60;
			this.cbxFontName.SelectedIndexChanged += new global::System.EventHandler(this.cbxFontName_SelectedIndexChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(9, 507);
			this.label2.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(74, 20);
			this.label2.TabIndex = 59;
			this.label2.Text = "Kiểu chữ";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(8, 420);
			this.label3.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(62, 20);
			this.label3.TabIndex = 58;
			this.label3.Text = "Cỡ chữ";
			this.btnKhuonTinChu.AutoSize = true;
			this.btnKhuonTinChu.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnKhuonTinChu.Location = new global::System.Drawing.Point(3, 160);
			this.btnKhuonTinChu.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnKhuonTinChu.Name = "btnKhuonTinChu";
			this.btnKhuonTinChu.Size = new global::System.Drawing.Size(161, 35);
			this.btnKhuonTinChu.TabIndex = 49;
			this.btnKhuonTinChu.Text = "Khuôn mẫu tín chủ";
			this.btnKhuonTinChu.UseVisualStyleBackColor = true;
			this.btnKhuonTinChu.Click += new global::System.EventHandler(this.btnKhuonTinChu_Click);
			this.btnClose.AutoSize = true;
 			this.btnClose.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new global::System.Drawing.Point(3, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(121, 35);
			this.btnClose.TabIndex = 48;
			this.btnClose.Text = "   Quay lại";
			this.btnClose.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.cbxIsAddress.AutoSize = true;
			this.cbxIsAddress.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbxIsAddress.Location = new global::System.Drawing.Point(12, 84);
			this.cbxIsAddress.Name = "cbxIsAddress";
			this.cbxIsAddress.Size = new global::System.Drawing.Size(124, 24);
			this.cbxIsAddress.TabIndex = 33;
			this.cbxIsAddress.Text = "Có in địa chỉ";
			this.cbxIsAddress.UseVisualStyleBackColor = true;
			this.cbxIsAddress.CheckedChanged += new global::System.EventHandler(this.cbxIsAddress_CheckedChanged);
			this.groupBox2.Controls.Add(this.lblPageTotal);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.nmrRows);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.nmrCols);
			this.groupBox2.Location = new global::System.Drawing.Point(3, 249);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(205, 158);
			this.groupBox2.TabIndex = 32;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Giảm cột, dòng thì sẽ";
			this.lblPageTotal.AutoSize = true;
			this.lblPageTotal.Location = new global::System.Drawing.Point(9, 126);
			this.lblPageTotal.Name = "lblPageTotal";
			this.lblPageTotal.Size = new global::System.Drawing.Size(72, 20);
			this.lblPageTotal.TabIndex = 12;
			this.lblPageTotal.Text = "Số trang";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(9, 19);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(210, 20);
			this.label1.TabIndex = 11;
			this.label1.Text = "tăng khoảng trống giữa chữ";
			this.nmrRows.Location = new global::System.Drawing.Point(71, 88);
			this.nmrRows.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.nmrRows;
			int[] array4 = new int[4];
			array4[0] = 5;
//			numericUpDown4.Minimum = new decimal(array4);
			this.nmrRows.Name = "nmrRows";
			this.nmrRows.Size = new global::System.Drawing.Size(50, 26);
			this.nmrRows.TabIndex = 5;
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.nmrRows;
			int[] array5 = new int[4];
			array5[0] = 5;
//			numericUpDown5.Value = new decimal(array5);
			this.nmrRows.ValueChanged += new global::System.EventHandler(this.nmrRows_ValueChanged);
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(5, 53);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(57, 20);
			this.label5.TabIndex = 6;
			this.label5.Text = "Số cột";
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(2, 90);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(70, 20);
			this.label8.TabIndex = 10;
			this.label8.Text = "Số dòng";
			this.nmrCols.Location = new global::System.Drawing.Point(71, 51);
			this.nmrCols.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.nmrCols;
			int[] array6 = new int[4];
			array6[0] = 5;
//			numericUpDown6.Minimum = new decimal(array6);
			this.nmrCols.Name = "nmrCols";
			this.nmrCols.Size = new global::System.Drawing.Size(50, 26);
			this.nmrCols.TabIndex = 3;
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.nmrCols;
			int[] array7 = new int[4];
			array7[0] = 5;
//			numericUpDown7.Value = new decimal(array7);
			this.nmrCols.ValueChanged += new global::System.EventHandler(this.nmrCols_ValueChanged);
			this.btnPrintSetting.AutoSize = true;
			this.btnPrintSetting.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnPrintSetting.Location = new global::System.Drawing.Point(8, 668);
			this.btnPrintSetting.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnPrintSetting.Name = "btnPrintSetting";
			this.btnPrintSetting.Size = new global::System.Drawing.Size(161, 35);
			this.btnPrintSetting.TabIndex = 31;
			this.btnPrintSetting.Text = "Thiết lập khổ giấy";
			this.btnPrintSetting.UseVisualStyleBackColor = true;
			this.btnPrintSetting.Visible = false;
			this.btnPrintSetting.Click += new global::System.EventHandler(this.btnPrintSetting_Click);
			this.ckxPersonPerCol.AutoSize = true;
			this.ckxPersonPerCol.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ckxPersonPerCol.Location = new global::System.Drawing.Point(12, 57);
			this.ckxPersonPerCol.Name = "ckxPersonPerCol";
			this.ckxPersonPerCol.Size = new global::System.Drawing.Size(145, 24);
			this.ckxPersonPerCol.TabIndex = 30;
			this.ckxPersonPerCol.Text = "Mỗi người 1 cột";
			this.ckxPersonPerCol.UseVisualStyleBackColor = true;
			this.ckxPersonPerCol.CheckedChanged += new global::System.EventHandler(this.ckxPersonPerCol_CheckedChanged);
			this.btnPrintPreview.AutoSize = true;
			this.btnPrintPreview.BackColor = global::System.Drawing.Color.Yellow;
			this.btnPrintPreview.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnPrintPreview.Location = new global::System.Drawing.Point(3, 200);
			this.btnPrintPreview.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnPrintPreview.Name = "btnPrintPreview";
			this.btnPrintPreview.Size = new global::System.Drawing.Size(173, 35);
			this.btnPrintPreview.TabIndex = 29;
			this.btnPrintPreview.Text = "Xem trước khi in";
			this.btnPrintPreview.UseVisualStyleBackColor = false;
			this.btnPrintPreview.Click += new global::System.EventHandler(this.btnPrintPreview_Click);
			this.btnTinChu.AutoSize = true;
			this.btnTinChu.BackColor = global::System.Drawing.Color.DarkOrange;
			this.btnTinChu.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnTinChu.Location = new global::System.Drawing.Point(3, 121);
			this.btnTinChu.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnTinChu.Name = "btnTinChu";
			this.btnTinChu.Size = new global::System.Drawing.Size(114, 35);
			this.btnTinChu.TabIndex = 28;
			this.btnTinChu.Text = "  Tín chủ  ";
			this.btnTinChu.UseVisualStyleBackColor = false;
			this.btnTinChu.Click += new global::System.EventHandler(this.btnTinChu_Click);
			this.reoGridControl1.BackColor = global::System.Drawing.Color.White;
			this.reoGridControl1.ColumnHeaderContextMenuStrip = null;
			this.reoGridControl1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.reoGridControl1.LeadHeaderContextMenuStrip = null;
			this.reoGridControl1.Location = new global::System.Drawing.Point(0, 0);
			this.reoGridControl1.Name = "reoGridControl1";
			this.reoGridControl1.RowHeaderContextMenuStrip = null;
			this.reoGridControl1.Script = null;
			this.reoGridControl1.SheetTabContextMenuStrip = null;
			this.reoGridControl1.SheetTabNewButtonVisible = true;
			this.reoGridControl1.SheetTabVisible = true;
			this.reoGridControl1.SheetTabWidth = 60;
			this.reoGridControl1.ShowScrollEndSpacing = true;
			this.reoGridControl1.Size = new global::System.Drawing.Size(1396, 785);
			this.reoGridControl1.TabIndex = 0;
			this.reoGridControl1.Text = "reoGridControl1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(10f, 20f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1641, 785);
			base.Controls.Add(this.splitContainer1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MinimizeBox = false;
			base.Name = "FrmDanhSach";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Danh sách đoàn";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new global::System.EventHandler(this.FrmDanhSach_Load);
			base.SizeChanged += new global::System.EventHandler(this.FrmDanhSach_SizeChanged);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.numUpDownFontSize).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nmrRows).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrCols).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000009 RID: 9
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000A RID: 10
		private global::unvell.ReoGrid.ReoGridControl reoGridControl1;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Button btnTinChu;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Button btnPrintPreview;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.CheckBox ckxPersonPerCol;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Button btnPrintSetting;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.NumericUpDown nmrRows;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.NumericUpDown nmrCols;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Label lblPageTotal;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.CheckBox cbxIsAddress;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Button btnKhuonTinChu;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.NumericUpDown numUpDownFontSize;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.ComboBox cbxFontName;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.ComboBox cbxFontStyle;
	}
}
