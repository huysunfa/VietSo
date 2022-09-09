namespace PrintSo
{
	// Token: 0x0200000B RID: 11
	public partial class FrmDanhSachTinChu : global::System.Windows.Forms.Form
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00007FD4 File Offset: 0x000061D4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00007FF4 File Offset: 0x000061F4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::PrintSo.FrmDanhSachTinChu));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.nUpDTo = new global::System.Windows.Forms.NumericUpDown();
			this.label3 = new global::System.Windows.Forms.Label();
			this.nUpDFrom = new global::System.Windows.Forms.NumericUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			this.ckxSpaceFamily = new global::System.Windows.Forms.CheckBox();
			this.numUpDownFontSize = new global::System.Windows.Forms.NumericUpDown();
			this.cbxFontName = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.btnPrintPreview = new global::System.Windows.Forms.Button();
			this.reoGridControl1 = new global::unvell.ReoGrid.ReoGridControl();
			this.contextMenuStripCol = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.TlStrpMnItmHideCol = new global::System.Windows.Forms.ToolStripMenuItem();
			this.TlStrpMnItmShowCol = new global::System.Windows.Forms.ToolStripMenuItem();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nUpDTo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nUpDFrom).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numUpDownFontSize).BeginInit();
			this.contextMenuStripCol.SuspendLayout();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new global::System.Windows.Forms.Padding(4);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.nUpDTo);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.nUpDFrom);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.ckxSpaceFamily);
			this.splitContainer1.Panel1.Controls.Add(this.numUpDownFontSize);
			this.splitContainer1.Panel1.Controls.Add(this.cbxFontName);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.btnClose);
			this.splitContainer1.Panel1.Controls.Add(this.btnPrintPreview);
			this.splitContainer1.Panel2.Controls.Add(this.reoGridControl1);
			this.splitContainer1.Size = new global::System.Drawing.Size(972, 456);
			this.splitContainer1.SplitterDistance = 220;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			this.nUpDTo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nUpDTo.Location = new global::System.Drawing.Point(112, 382);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.nUpDTo;
			int[] array = new int[4];
			array[0] = 100000;
		//	numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.nUpDTo;
			int[] array2 = new int[4];
			array2[0] = 2;
//			numericUpDown2.Minimum = new decimal(array2);
			this.nUpDTo.Name = "nUpDTo";
			this.nUpDTo.Size = new global::System.Drawing.Size(65, 30);
			this.nUpDTo.TabIndex = 62;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.nUpDTo;
			int[] array3 = new int[4];
			array3[0] = 2;
//			numericUpDown3.Value = new decimal(array3);
			this.nUpDTo.ValueChanged += new global::System.EventHandler(this.nUpDTo_ValueChanged);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(28, 384);
			this.label3.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(77, 25);
			this.label3.TabIndex = 61;
			this.label3.Text = "đến mã";
			this.nUpDFrom.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nUpDFrom.Location = new global::System.Drawing.Point(112, 346);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.nUpDFrom;
			int[] array4 = new int[4];
			array4[0] = 10000;
//			numericUpDown4.Maximum = new decimal(array4);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.nUpDFrom;
			int[] array5 = new int[4];
			array5[0] = 1;
//			numericUpDown5.Minimum = new decimal(array5);
			this.nUpDFrom.Name = "nUpDFrom";
			this.nUpDFrom.Size = new global::System.Drawing.Size(65, 30);
			this.nUpDFrom.TabIndex = 60;
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.nUpDFrom;
			int[] array6 = new int[4];
			array6[0] = 1;
//			numericUpDown6.Value = new decimal(array6);
			this.nUpDFrom.ValueChanged += new global::System.EventHandler(this.nUpDFrom_ValueChanged);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(24, 348);
			this.label4.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(81, 25);
			this.label4.TabIndex = 59;
			this.label4.Text = "In từ mã";
			this.ckxSpaceFamily.AutoSize = true;
			this.ckxSpaceFamily.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ckxSpaceFamily.Location = new global::System.Drawing.Point(12, 202);
			this.ckxSpaceFamily.Name = "ckxSpaceFamily";
			this.ckxSpaceFamily.Size = new global::System.Drawing.Size(167, 52);
			this.ckxSpaceFamily.TabIndex = 58;
			this.ckxSpaceFamily.Text = "Dòng trống giữa\r\n      Gia đình";
			this.ckxSpaceFamily.UseVisualStyleBackColor = true;
			this.ckxSpaceFamily.CheckedChanged += new global::System.EventHandler(this.ckxSpaceFamily_CheckedChanged);
			this.numUpDownFontSize.DecimalPlaces = 1;
			this.numUpDownFontSize.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numUpDownFontSize.Increment = new decimal(new int[]
			{
				5,
				0,
				0,
				65536
			});
			this.numUpDownFontSize.Location = new global::System.Drawing.Point(12, 100);
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.numUpDownFontSize;
			int[] array7 = new int[4];
			array7[0] = 50;
//			numericUpDown7.Maximum = new decimal(array7);
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.numUpDownFontSize;
			int[] array8 = new int[4];
			array8[0] = 9;
//			numericUpDown8.Minimum = new decimal(array8);
			this.numUpDownFontSize.Name = "numUpDownFontSize";
			this.numUpDownFontSize.Size = new global::System.Drawing.Size(117, 30);
			this.numUpDownFontSize.TabIndex = 57;
			global::System.Windows.Forms.NumericUpDown numericUpDown9 = this.numUpDownFontSize;
			int[] array9 = new int[4];
			array9[0] = 9;
//			numericUpDown9.Value = new decimal(array9);
			this.numUpDownFontSize.ValueChanged += new global::System.EventHandler(this.numUpDownFontSize_ValueChanged);
			this.cbxFontName.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbxFontName.FormattingEnabled = true;
			this.cbxFontName.Location = new global::System.Drawing.Point(12, 156);
			this.cbxFontName.Name = "cbxFontName";
			this.cbxFontName.Size = new global::System.Drawing.Size(180, 33);
			this.cbxFontName.TabIndex = 56;
			this.cbxFontName.SelectedIndexChanged += new global::System.EventHandler(this.cbxFontName_SelectedIndexChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(9, 136);
			this.label2.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(74, 20);
			this.label2.TabIndex = 54;
			this.label2.Text = "Kiểu chữ";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(9, 80);
			this.label1.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(62, 20);
			this.label1.TabIndex = 53;
			this.label1.Text = "Cỡ chữ";
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
 			this.btnClose.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new global::System.Drawing.Point(4, 15);
			this.btnClose.Margin = new global::System.Windows.Forms.Padding(4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(125, 43);
			this.btnClose.TabIndex = 52;
			this.btnClose.Text = "Quay lại";
			this.btnClose.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.btnPrintPreview.AutoSize = true;
			this.btnPrintPreview.BackColor = global::System.Drawing.Color.Yellow;
			this.btnPrintPreview.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnPrintPreview.Location = new global::System.Drawing.Point(12, 283);
			this.btnPrintPreview.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnPrintPreview.Name = "btnPrintPreview";
			this.btnPrintPreview.Size = new global::System.Drawing.Size(173, 43);
			this.btnPrintPreview.TabIndex = 51;
			this.btnPrintPreview.Text = "Xem trước khi in";
			this.btnPrintPreview.UseVisualStyleBackColor = false;
			this.btnPrintPreview.Click += new global::System.EventHandler(this.btnPrintPreview_Click);
			this.reoGridControl1.BackColor = global::System.Drawing.Color.White;
			this.reoGridControl1.ColumnHeaderContextMenuStrip = this.contextMenuStripCol;
			this.reoGridControl1.ContextMenuStrip = this.contextMenuStripCol;
			this.reoGridControl1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.reoGridControl1.LeadHeaderContextMenuStrip = null;
			this.reoGridControl1.Location = new global::System.Drawing.Point(0, 0);
			this.reoGridControl1.Margin = new global::System.Windows.Forms.Padding(4);
			this.reoGridControl1.Name = "reoGridControl1";
			this.reoGridControl1.RowHeaderContextMenuStrip = null;
			this.reoGridControl1.Script = null;
			this.reoGridControl1.SheetTabContextMenuStrip = null;
			this.reoGridControl1.SheetTabNewButtonVisible = true;
			this.reoGridControl1.SheetTabVisible = true;
			this.reoGridControl1.SheetTabWidth = 80;
			this.reoGridControl1.ShowScrollEndSpacing = true;
			this.reoGridControl1.Size = new global::System.Drawing.Size(747, 456);
			this.reoGridControl1.TabIndex = 1;
			this.reoGridControl1.Text = "reoGridControl1";
			this.contextMenuStripCol.ImageScalingSize = new global::System.Drawing.Size(20, 20);
			this.contextMenuStripCol.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.TlStrpMnItmHideCol,
				this.TlStrpMnItmShowCol
			});
			this.contextMenuStripCol.Name = "contextMenuStripCol";
			this.contextMenuStripCol.Size = new global::System.Drawing.Size(246, 52);
			this.contextMenuStripCol.Opening += new global::System.ComponentModel.CancelEventHandler(this.contextMenuStripCol_Opening);
			this.TlStrpMnItmHideCol.Name = "TlStrpMnItmHideCol";
			this.TlStrpMnItmHideCol.Size = new global::System.Drawing.Size(245, 24);
			this.TlStrpMnItmHideCol.Text = "Ẩn cột";
			this.TlStrpMnItmHideCol.Click += new global::System.EventHandler(this.TlStrpMnItmHideCol_Click);
			this.TlStrpMnItmShowCol.Name = "TlStrpMnItmShowCol";
			this.TlStrpMnItmShowCol.Size = new global::System.Drawing.Size(245, 24);
			this.TlStrpMnItmShowCol.Text = "Hiện cột (chọn nhiều cột)";
			this.TlStrpMnItmShowCol.Click += new global::System.EventHandler(this.TlStrpMnItmShowCol_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(10f, 20f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(972, 456);
			base.Controls.Add(this.splitContainer1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
//			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MinimizeBox = false;
			base.Name = "FrmDanhSachTinChu";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Danh sách tín chủ";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FrmDanhSachTinChu_FormClosing);
			base.Load += new global::System.EventHandler(this.FrmDanhSachTinChu_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.nUpDTo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nUpDFrom).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numUpDownFontSize).EndInit();
			this.contextMenuStripCol.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000054 RID: 84
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000056 RID: 86
		private global::unvell.ReoGrid.ReoGridControl reoGridControl1;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.Button btnPrintPreview;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStripCol;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.ToolStripMenuItem TlStrpMnItmHideCol;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.ToolStripMenuItem TlStrpMnItmShowCol;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.NumericUpDown numUpDownFontSize;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.ComboBox cbxFontName;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.CheckBox ckxSpaceFamily;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.NumericUpDown nUpDTo;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.NumericUpDown nUpDFrom;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.Label label4;
	}
}
