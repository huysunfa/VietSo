
namespace AppVietSo
{
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nUpDTo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nUpDFrom = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ckxSpaceFamily = new System.Windows.Forms.CheckBox();
            this.numUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.cbxFontName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.reoGridControl1 = new unvell.ReoGrid.ReoGridControl();
            this.contextMenuStripCol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TlStrpMnItmHideCol = new System.Windows.Forms.ToolStripMenuItem();
            this.TlStrpMnItmShowCol = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownFontSize)).BeginInit();
            this.contextMenuStripCol.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reoGridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(972, 456);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // nUpDTo
            // 
            this.nUpDTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUpDTo.Location = new System.Drawing.Point(112, 382);
            this.nUpDTo.Name = "nUpDTo";
            this.nUpDTo.Size = new System.Drawing.Size(65, 30);
            this.nUpDTo.TabIndex = 62;
            this.nUpDTo.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUpDTo.ValueChanged += new System.EventHandler(this.nUpDTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 384);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 61;
            this.label3.Text = "đến mã";
            // 
            // nUpDFrom
            // 
            this.nUpDFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUpDFrom.Location = new System.Drawing.Point(112, 346);
            this.nUpDFrom.Name = "nUpDFrom";
            this.nUpDFrom.Size = new System.Drawing.Size(65, 30);
            this.nUpDFrom.TabIndex = 60;
            this.nUpDFrom.ValueChanged += new System.EventHandler(this.nUpDFrom_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 348);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 59;
            this.label4.Text = "In từ mã";
            // 
            // ckxSpaceFamily
            // 
            this.ckxSpaceFamily.AutoSize = true;
            this.ckxSpaceFamily.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckxSpaceFamily.Location = new System.Drawing.Point(12, 202);
            this.ckxSpaceFamily.Name = "ckxSpaceFamily";
            this.ckxSpaceFamily.Size = new System.Drawing.Size(167, 52);
            this.ckxSpaceFamily.TabIndex = 58;
            this.ckxSpaceFamily.Text = "Dòng trống giữa\r\n      Gia đình";
            this.ckxSpaceFamily.UseVisualStyleBackColor = true;
            this.ckxSpaceFamily.CheckedChanged += new System.EventHandler(this.ckxSpaceFamily_CheckedChanged);
            // 
            // numUpDownFontSize
            // 
            this.numUpDownFontSize.DecimalPlaces = 1;
            this.numUpDownFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDownFontSize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numUpDownFontSize.Location = new System.Drawing.Point(12, 100);
            this.numUpDownFontSize.Name = "numUpDownFontSize";
            this.numUpDownFontSize.Size = new System.Drawing.Size(117, 30);
            this.numUpDownFontSize.TabIndex = 57;
            this.numUpDownFontSize.ValueChanged += new System.EventHandler(this.numUpDownFontSize_ValueChanged);
            // 
            // cbxFontName
            // 
            this.cbxFontName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFontName.FormattingEnabled = true;
            this.cbxFontName.Location = new System.Drawing.Point(12, 156);
            this.cbxFontName.Name = "cbxFontName";
            this.cbxFontName.Size = new System.Drawing.Size(180, 33);
            this.cbxFontName.TabIndex = 56;
            this.cbxFontName.SelectedIndexChanged += new System.EventHandler(this.cbxFontName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = "Kiểu chữ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Cỡ chữ";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::AppVietSo.Properties.Resources.leftArrow;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(4, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 43);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Quay lại";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.AutoSize = true;
            this.btnPrintPreview.BackColor = System.Drawing.Color.Yellow;
            this.btnPrintPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPreview.Location = new System.Drawing.Point(12, 283);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(173, 43);
            this.btnPrintPreview.TabIndex = 51;
            this.btnPrintPreview.Text = "Xem trước khi in";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // reoGridControl1
            // 
            this.reoGridControl1.BackColor = System.Drawing.Color.White;
            this.reoGridControl1.ColumnHeaderContextMenuStrip = this.contextMenuStripCol;
            this.reoGridControl1.ContextMenuStrip = this.contextMenuStripCol;
            this.reoGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reoGridControl1.LeadHeaderContextMenuStrip = null;
            this.reoGridControl1.Location = new System.Drawing.Point(0, 0);
            this.reoGridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.reoGridControl1.Name = "reoGridControl1";
            this.reoGridControl1.RowHeaderContextMenuStrip = null;
            this.reoGridControl1.Script = null;
            this.reoGridControl1.SheetTabContextMenuStrip = null;
            this.reoGridControl1.SheetTabNewButtonVisible = true;
            this.reoGridControl1.SheetTabVisible = true;
            this.reoGridControl1.SheetTabWidth = 80;
            this.reoGridControl1.ShowScrollEndSpacing = true;
            this.reoGridControl1.Size = new System.Drawing.Size(747, 456);
            this.reoGridControl1.TabIndex = 1;
            this.reoGridControl1.Text = "reoGridControl1";
            // 
            // contextMenuStripCol
            // 
            this.contextMenuStripCol.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripCol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TlStrpMnItmHideCol,
            this.TlStrpMnItmShowCol});
            this.contextMenuStripCol.Name = "contextMenuStripCol";
            this.contextMenuStripCol.Size = new System.Drawing.Size(246, 52);
            this.contextMenuStripCol.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripCol_Opening);
            // 
            // TlStrpMnItmHideCol
            // 
            this.TlStrpMnItmHideCol.Name = "TlStrpMnItmHideCol";
            this.TlStrpMnItmHideCol.Size = new System.Drawing.Size(245, 24);
            this.TlStrpMnItmHideCol.Text = "Ẩn cột";
            this.TlStrpMnItmHideCol.Click += new System.EventHandler(this.TlStrpMnItmHideCol_Click);
            // 
            // TlStrpMnItmShowCol
            // 
            this.TlStrpMnItmShowCol.Name = "TlStrpMnItmShowCol";
            this.TlStrpMnItmShowCol.Size = new System.Drawing.Size(245, 24);
            this.TlStrpMnItmShowCol.Text = "Hiện cột (chọn nhiều cột)";
            this.TlStrpMnItmShowCol.Click += new System.EventHandler(this.TlStrpMnItmShowCol_Click);
            // 
            // FrmDanhSachTinChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 456);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "FrmDanhSachTinChu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách tín chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDanhSachTinChu_FormClosing);
            this.Load += new System.EventHandler(this.FrmDanhSachTinChu_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUpDTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownFontSize)).EndInit();
            this.contextMenuStripCol.ResumeLayout(false);
            this.ResumeLayout(false);

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
