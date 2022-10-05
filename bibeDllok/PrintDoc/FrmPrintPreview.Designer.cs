namespace PrintDoc
{
	// Token: 0x0200000E RID: 14
	public partial class FrmPrintPreview : global::System.Windows.Forms.Form
	{
		// Token: 0x0600009E RID: 158 RVA: 0x0000618C File Offset: 0x0000438C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000061B8 File Offset: 0x000043B8
		private void InitializeComponent()
		{
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.btnZoomIn = new global::System.Windows.Forms.PictureBox();
			this.btnZoomOut = new global::System.Windows.Forms.PictureBox();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.btnCustomTitle = new global::System.Windows.Forms.Button();
			this.btnLastPage = new global::System.Windows.Forms.PictureBox();
			this.btnFirstPage = new global::System.Windows.Forms.PictureBox();
			this.nmrPageTo = new global::System.Windows.Forms.NumericUpDown();
			this.nmrPageFrom = new global::System.Windows.Forms.NumericUpDown();
			this.label1 = new global::System.Windows.Forms.Label();
			this.rbtnCurPage = new global::System.Windows.Forms.RadioButton();
			this.rbtnPage = new global::System.Windows.Forms.RadioButton();
			this.rbtnAllPage = new global::System.Windows.Forms.RadioButton();
			this.nmrPage = new global::System.Windows.Forms.NumericUpDown();
			this.totalPage = new global::System.Windows.Forms.Label();
			this.cbxPageNumber = new global::System.Windows.Forms.CheckBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.rbtnLandscape = new global::System.Windows.Forms.RadioButton();
			this.rbtnPortrait = new global::System.Windows.Forms.RadioButton();
			this.label3 = new global::System.Windows.Forms.Label();
			this.cbxPaperSize = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.cbxPrinter = new global::System.Windows.Forms.ComboBox();
			this.cbxZoom = new global::System.Windows.Forms.ComboBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.nmrLeft = new global::System.Windows.Forms.NumericUpDown();
			this.label5 = new global::System.Windows.Forms.Label();
			this.nmrRight = new global::System.Windows.Forms.NumericUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.nmrBottom = new global::System.Windows.Forms.NumericUpDown();
			this.label7 = new global::System.Windows.Forms.Label();
			this.nmrTop = new global::System.Windows.Forms.NumericUpDown();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.printPreviewControl1 = new global::System.Windows.Forms.PrintPreviewControl();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnZoomIn).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnZoomOut).BeginInit();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnLastPage).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnFirstPage).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrPageTo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrPageFrom).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrPage).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nmrLeft).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrRight).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrBottom).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrTop).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel1.Controls.Add(this.btnClose);
			this.splitContainer1.Panel1.Controls.Add(this.btnZoomIn);
			this.splitContainer1.Panel1.Controls.Add(this.btnZoomOut);
			this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.cbxPaperSize);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.cbxPrinter);
			this.splitContainer1.Panel1.Controls.Add(this.cbxZoom);
			this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
			this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
			this.splitContainer1.Panel2.Controls.Add(this.printPreviewControl1);
			this.splitContainer1.Size = new global::System.Drawing.Size(0x552, 0x37C);
			this.splitContainer1.SplitterDistance = 0x12E;
			this.splitContainer1.TabIndex = 1;
			this.btnClose.Image = global::Class7.Bitmap_4;
			this.btnClose.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new global::System.Drawing.Point(0xB, 0x16);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(0x7B, 0x26);
			this.btnClose.TabIndex = 0x2F;
			this.btnClose.Text = "Quay lại";
			this.btnClose.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.btnZoomIn.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnZoomIn.Image = global::Class7.Bitmap_6;
			this.btnZoomIn.Location = new global::System.Drawing.Point(0xFE, 0x84);
			this.btnZoomIn.Name = "btnZoomIn";
			this.btnZoomIn.Size = new global::System.Drawing.Size(0x1E, 0x1E);
			this.btnZoomIn.TabIndex = 0x2E;
			this.btnZoomIn.TabStop = false;
			this.btnZoomIn.Click += new global::System.EventHandler(this.btnZoomIn_Click);
			this.btnZoomOut.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnZoomOut.Image = global::Class7.Bitmap_8;
			this.btnZoomOut.Location = new global::System.Drawing.Point(0x7F, 0x84);
			this.btnZoomOut.Name = "btnZoomOut";
			this.btnZoomOut.Size = new global::System.Drawing.Size(0x1E, 0x1E);
			this.btnZoomOut.TabIndex = 0x2D;
			this.btnZoomOut.TabStop = false;
			this.btnZoomOut.Click += new global::System.EventHandler(this.btnZoomOut_Click);
			this.groupBox3.Controls.Add(this.btnCustomTitle);
			this.groupBox3.Controls.Add(this.btnLastPage);
			this.groupBox3.Controls.Add(this.btnFirstPage);
			this.groupBox3.Controls.Add(this.nmrPageTo);
			this.groupBox3.Controls.Add(this.nmrPageFrom);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.rbtnCurPage);
			this.groupBox3.Controls.Add(this.rbtnPage);
			this.groupBox3.Controls.Add(this.rbtnAllPage);
			this.groupBox3.Controls.Add(this.nmrPage);
			this.groupBox3.Controls.Add(this.totalPage);
			this.groupBox3.Controls.Add(this.cbxPageNumber);
			this.groupBox3.Location = new global::System.Drawing.Point(0xB, 0x249);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(0x111, 0x11D);
			this.groupBox3.TabIndex = 0x2C;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Trang in";
			this.btnCustomTitle.Location = new global::System.Drawing.Point(0xAA, 0xE8);
			this.btnCustomTitle.Name = "btnCustomTitle";
			this.btnCustomTitle.Size = new global::System.Drawing.Size(0x61, 0x1F);
			this.btnCustomTitle.TabIndex = 0x33;
			this.btnCustomTitle.Text = "Thay đổi";
			this.btnCustomTitle.UseVisualStyleBackColor = true;
			this.btnCustomTitle.Click += new global::System.EventHandler(this.btnCustomTitle_Click);
			this.btnLastPage.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnLastPage.Image = global::Class7.Bitmap_0;
			this.btnLastPage.Location = new global::System.Drawing.Point(0xB9, 0xAA);
			this.btnLastPage.Name = "btnLastPage";
			this.btnLastPage.Size = new global::System.Drawing.Size(0x1E, 0x1E);
			this.btnLastPage.TabIndex = 0x32;
			this.btnLastPage.TabStop = false;
			this.btnLastPage.Click += new global::System.EventHandler(this.btnLastPage_Click);
			this.btnFirstPage.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnFirstPage.Image = global::Class7.Bitmap_2;
			this.btnFirstPage.Location = new global::System.Drawing.Point(0x12, 0xAA);
			this.btnFirstPage.Name = "btnFirstPage";
			this.btnFirstPage.Size = new global::System.Drawing.Size(0x1E, 0x1E);
			this.btnFirstPage.TabIndex = 0x2F;
			this.btnFirstPage.TabStop = false;
			this.btnFirstPage.Click += new global::System.EventHandler(this.btnFirstPage_Click);
			this.nmrPageTo.Enabled = false;
			this.nmrPageTo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nmrPageTo.Location = new global::System.Drawing.Point(0xD6, 0x48);
			this.nmrPageTo.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.nmrPageTo;
			int[] array = new int[4];
			array[0] = 1;
			numericUpDown.Minimum = new decimal(array);
			this.nmrPageTo.Name = "nmrPageTo";
			this.nmrPageTo.Size = new global::System.Drawing.Size(0x32, 0x18);
			this.nmrPageTo.TabIndex = 0x31;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.nmrPageTo;
			int[] array2 = new int[4];
			array2[0] = 1;
			numericUpDown2.Value = new decimal(array2);
			this.nmrPageTo.ValueChanged += new global::System.EventHandler(this.nmrPageTo_ValueChanged);
			this.nmrPageFrom.Enabled = false;
			this.nmrPageFrom.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nmrPageFrom.Location = new global::System.Drawing.Point(0x7C, 0x48);
			this.nmrPageFrom.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.nmrPageFrom;
			int[] array3 = new int[4];
			array3[0] = 1;
			numericUpDown3.Minimum = new decimal(array3);
			this.nmrPageFrom.Name = "nmrPageFrom";
			this.nmrPageFrom.Size = new global::System.Drawing.Size(0x32, 0x18);
			this.nmrPageFrom.TabIndex = 0x30;
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.nmrPageFrom;
			int[] array4 = new int[4];
			array4[0] = 1;
			numericUpDown4.Value = new decimal(array4);
			this.nmrPageFrom.ValueChanged += new global::System.EventHandler(this.nmrPageFrom_ValueChanged);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(0xB1, 0x4C);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(0x20, 0x11);
			this.label1.TabIndex = 0x2F;
			this.label1.Text = "đến";
			this.rbtnCurPage.AutoSize = true;
			this.rbtnCurPage.Location = new global::System.Drawing.Point(0xF, 0x76);
			this.rbtnCurPage.Name = "rbtnCurPage";
			this.rbtnCurPage.Size = new global::System.Drawing.Size(0x72, 0x15);
			this.rbtnCurPage.TabIndex = 0x2E;
			this.rbtnCurPage.TabStop = true;
			this.rbtnCurPage.Text = "Trang hiện tại";
			this.rbtnCurPage.UseVisualStyleBackColor = true;
			this.rbtnPage.AutoSize = true;
			this.rbtnPage.Location = new global::System.Drawing.Point(0xF, 0x49);
			this.rbtnPage.Name = "rbtnPage";
			this.rbtnPage.Size = new global::System.Drawing.Size(0x50, 0x15);
			this.rbtnPage.TabIndex = 1;
			this.rbtnPage.TabStop = true;
			this.rbtnPage.Text = "Từ trang";
			this.rbtnPage.UseVisualStyleBackColor = true;
			this.rbtnPage.CheckedChanged += new global::System.EventHandler(this.rbtnPage_CheckedChanged);
			this.rbtnAllPage.AutoSize = true;
			this.rbtnAllPage.Checked = true;
			this.rbtnAllPage.Location = new global::System.Drawing.Point(0x12, 0x21);
			this.rbtnAllPage.Name = "rbtnAllPage";
			this.rbtnAllPage.Size = new global::System.Drawing.Size(0x81, 0x15);
			this.rbtnAllPage.TabIndex = 0;
			this.rbtnAllPage.TabStop = true;
			this.rbtnAllPage.Text = "Tất cả các trang";
			this.rbtnAllPage.UseVisualStyleBackColor = true;
			this.nmrPage.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nmrPage.Location = new global::System.Drawing.Point(0x38, 0xA9);
			this.nmrPage.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.nmrPage;
			int[] array5 = new int[4];
			array5[0] = 1;
			numericUpDown5.Minimum = new decimal(array5);
			this.nmrPage.Name = "nmrPage";
			this.nmrPage.Size = new global::System.Drawing.Size(0x32, 0x18);
			this.nmrPage.TabIndex = 0x20;
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.nmrPage;
			int[] array6 = new int[4];
			array6[0] = 1;
			numericUpDown6.Value = new decimal(array6);
			this.nmrPage.ValueChanged += new global::System.EventHandler(this.nmrPage_ValueChanged);
			this.totalPage.AutoSize = true;
			this.totalPage.Location = new global::System.Drawing.Point(0x6A, 0xAD);
			this.totalPage.Name = "totalPage";
			this.totalPage.Size = new global::System.Drawing.Size(0x39, 0x11);
			this.totalPage.TabIndex = 0x23;
			this.totalPage.Text = "/1 trang";
			this.cbxPageNumber.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.cbxPageNumber.AutoSize = true;
			this.cbxPageNumber.Location = new global::System.Drawing.Point(0x10, 0xED);
			this.cbxPageNumber.Name = "cbxPageNumber";
			this.cbxPageNumber.Size = new global::System.Drawing.Size(0x7B, 0x15);
			this.cbxPageNumber.TabIndex = 0x24;
			this.cbxPageNumber.Text = "Header/ Footer";
			this.cbxPageNumber.UseVisualStyleBackColor = true;
			this.cbxPageNumber.CheckedChanged += new global::System.EventHandler(this.cbxPageNumber_CheckedChanged);
			this.groupBox1.Controls.Add(this.rbtnLandscape);
			this.groupBox1.Controls.Add(this.rbtnPortrait);
			this.groupBox1.Location = new global::System.Drawing.Point(0xB, 0x1FB);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(0x111, 0x3C);
			this.groupBox1.TabIndex = 0x2B;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Hướng giấy";
			this.rbtnLandscape.AutoSize = true;
			this.rbtnLandscape.Location = new global::System.Drawing.Point(0xB8, 0x1A);
			this.rbtnLandscape.Name = "rbtnLandscape";
			this.rbtnLandscape.Size = new global::System.Drawing.Size(0x44, 0x15);
			this.rbtnLandscape.TabIndex = 1;
			this.rbtnLandscape.TabStop = true;
			this.rbtnLandscape.Text = "Ngang";
			this.rbtnLandscape.UseVisualStyleBackColor = true;
			this.rbtnLandscape.CheckedChanged += new global::System.EventHandler(this.rbtnPortrait_CheckedChanged);
			this.rbtnPortrait.AutoSize = true;
			this.rbtnPortrait.Location = new global::System.Drawing.Point(0x5F, 0x1A);
			this.rbtnPortrait.Name = "rbtnPortrait";
			this.rbtnPortrait.Size = new global::System.Drawing.Size(0x33, 0x15);
			this.rbtnPortrait.TabIndex = 0;
			this.rbtnPortrait.TabStop = true;
			this.rbtnPortrait.Text = "Dọc";
			this.rbtnPortrait.UseVisualStyleBackColor = true;
			this.rbtnPortrait.CheckedChanged += new global::System.EventHandler(this.rbtnPortrait_CheckedChanged);
			this.label3.AutoSize = true;
			this.label3.ForeColor = global::System.Drawing.SystemColors.HotTrack;
			this.label3.Location = new global::System.Drawing.Point(0xC, 0xF1);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(0x37, 0x11);
			this.label3.TabIndex = 0x2A;
			this.label3.Text = "Cỡ giấy";
			this.cbxPaperSize.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxPaperSize.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbxPaperSize.FormattingEnabled = true;
			this.cbxPaperSize.Items.AddRange(new object[]
			{
				"60%",
				"70%",
				"80%",
				"90%",
				"100%",
				"110%",
				"120%",
				"130%",
				"140%",
				"150%"
			});
			this.cbxPaperSize.Location = new global::System.Drawing.Point(0xB, 0x10B);
			this.cbxPaperSize.Name = "cbxPaperSize";
			this.cbxPaperSize.Size = new global::System.Drawing.Size(0x111, 0x1A);
			this.cbxPaperSize.TabIndex = 0x29;
			this.cbxPaperSize.SelectedIndexChanged += new global::System.EventHandler(this.cbxPaperSize_SelectedIndexChanged);
			this.label2.AutoSize = true;
			this.label2.ForeColor = global::System.Drawing.SystemColors.HotTrack;
			this.label2.Location = new global::System.Drawing.Point(0xC, 0xAC);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(0x31, 0x11);
			this.label2.TabIndex = 0x28;
			this.label2.Text = "Máy in";
			this.cbxPrinter.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxPrinter.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbxPrinter.FormattingEnabled = true;
			this.cbxPrinter.Location = new global::System.Drawing.Point(0xB, 0xC6);
			this.cbxPrinter.Name = "cbxPrinter";
			this.cbxPrinter.Size = new global::System.Drawing.Size(0x111, 0x1A);
			this.cbxPrinter.TabIndex = 0x27;
			this.cbxPrinter.SelectedIndexChanged += new global::System.EventHandler(this.cbxPrinter_SelectedIndexChanged);
			this.cbxZoom.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxZoom.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbxZoom.FormattingEnabled = true;
			this.cbxZoom.Items.AddRange(new object[]
			{
				"50%",
				"60%",
				"70%",
				"80%",
				"90%",
				"100%",
				"110%",
				"120%",
				"130%",
				"140%",
				"150%"
			});
			this.cbxZoom.Location = new global::System.Drawing.Point(0xA3, 0x82);
			this.cbxZoom.Name = "cbxZoom";
			this.cbxZoom.Size = new global::System.Drawing.Size(0x55, 0x1A);
			this.cbxZoom.TabIndex = 0x21;
			this.cbxZoom.SelectedIndexChanged += new global::System.EventHandler(this.cbxZoom_SelectedIndexChanged);
			this.groupBox2.Controls.Add(this.nmrLeft);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.nmrRight);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.nmrBottom);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.nmrTop);
			this.groupBox2.Location = new global::System.Drawing.Point(0xB, 0x144);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(0x111, 0xA3);
			this.groupBox2.TabIndex = 0x1F;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Khoảng cách lề giấy (mm)";
			this.nmrLeft.Location = new global::System.Drawing.Point(0x39, 0x4D);
			this.nmrLeft.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.nmrLeft;
			int[] array7 = new int[4];
			array7[0] = 0x46;
			numericUpDown7.Maximum = new decimal(array7);
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.nmrLeft;
			int[] array8 = new int[4];
			array8[0] = 7;
			numericUpDown8.Minimum = new decimal(array8);
			this.nmrLeft.Name = "nmrLeft";
			this.nmrLeft.Size = new global::System.Drawing.Size(0x32, 0x17);
			this.nmrLeft.TabIndex = 5;
			global::System.Windows.Forms.NumericUpDown numericUpDown9 = this.nmrLeft;
			int[] array9 = new int[4];
			array9[0] = 7;
			numericUpDown9.Value = new decimal(array9);
			this.nmrLeft.ValueChanged += new global::System.EventHandler(this.nmrTop_ValueChanged);
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(0x49, 0x24);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(0x26, 0x11);
			this.label5.TabIndex = 6;
			this.label5.Text = "Trên";
			this.nmrRight.Location = new global::System.Drawing.Point(0xCE, 0x4D);
			this.nmrRight.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown10 = this.nmrRight;
			int[] array10 = new int[4];
			array10[0] = 0x46;
			numericUpDown10.Maximum = new decimal(array10);
			global::System.Windows.Forms.NumericUpDown numericUpDown11 = this.nmrRight;
			int[] array11 = new int[4];
			array11[0] = 7;
			numericUpDown11.Minimum = new decimal(array11);
			this.nmrRight.Name = "nmrRight";
			this.nmrRight.Size = new global::System.Drawing.Size(0x32, 0x17);
			this.nmrRight.TabIndex = 6;
			global::System.Windows.Forms.NumericUpDown numericUpDown12 = this.nmrRight;
			int[] array12 = new int[4];
			array12[0] = 7;
			numericUpDown12.Value = new decimal(array12);
			this.nmrRight.ValueChanged += new global::System.EventHandler(this.nmrTop_ValueChanged);
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(0x48, 0x80);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(0x25, 0x11);
			this.label4.TabIndex = 8;
			this.label4.Text = "Dưới";
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(0xB, 0x4F);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(0x21, 0x11);
			this.label8.TabIndex = 0xA;
			this.label8.Text = "Trái";
			this.nmrBottom.Location = new global::System.Drawing.Point(0x7A, 0x7E);
			this.nmrBottom.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown13 = this.nmrBottom;
			int[] array13 = new int[4];
			array13[0] = 0x46;
			numericUpDown13.Maximum = new decimal(array13);
			global::System.Windows.Forms.NumericUpDown numericUpDown14 = this.nmrBottom;
			int[] array14 = new int[4];
			array14[0] = 7;
			numericUpDown14.Minimum = new decimal(array14);
			this.nmrBottom.Name = "nmrBottom";
			this.nmrBottom.Size = new global::System.Drawing.Size(0x32, 0x17);
			this.nmrBottom.TabIndex = 4;
			global::System.Windows.Forms.NumericUpDown numericUpDown15 = this.nmrBottom;
			int[] array15 = new int[4];
			array15[0] = 7;
			numericUpDown15.Value = new decimal(array15);
			this.nmrBottom.ValueChanged += new global::System.EventHandler(this.nmrTop_ValueChanged);
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(0x9C, 0x52);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(0x24, 0x11);
			this.label7.TabIndex = 0xC;
			this.label7.Text = "Phải";
			this.nmrTop.Location = new global::System.Drawing.Point(0x7A, 0x1F);
			this.nmrTop.Margin = new global::System.Windows.Forms.Padding(5);
			global::System.Windows.Forms.NumericUpDown numericUpDown16 = this.nmrTop;
			int[] array16 = new int[4];
			array16[0] = 0x46;
			numericUpDown16.Maximum = new decimal(array16);
			global::System.Windows.Forms.NumericUpDown numericUpDown17 = this.nmrTop;
			int[] array17 = new int[4];
			array17[0] = 7;
			numericUpDown17.Minimum = new decimal(array17);
			this.nmrTop.Name = "nmrTop";
			this.nmrTop.Size = new global::System.Drawing.Size(0x32, 0x17);
			this.nmrTop.TabIndex = 3;
			global::System.Windows.Forms.NumericUpDown numericUpDown18 = this.nmrTop;
			int[] array18 = new int[4];
			array18[0] = 7;
			numericUpDown18.Value = new decimal(array18);
			this.nmrTop.ValueChanged += new global::System.EventHandler(this.nmrTop_ValueChanged);
			this.btnPrint.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnPrint.Image = global::Class7.Bitmap_5;
			this.btnPrint.ImageAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.btnPrint.Location = new global::System.Drawing.Point(0xC4, 0x16);
			this.btnPrint.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(0x58, 0x4C);
			this.btnPrint.TabIndex = 0x1E;
			this.btnPrint.Text = "Print";
			this.btnPrint.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			this.printPreviewControl1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.printPreviewControl1.Location = new global::System.Drawing.Point(0, 0);
			this.printPreviewControl1.Name = "printPreviewControl1";
			this.printPreviewControl1.Size = new global::System.Drawing.Size(0x420, 0x37C);
			this.printPreviewControl1.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(0x552, 0x37C);
			base.Controls.Add(this.splitContainer1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MinimizeBox = false;
			base.Name = "FrmPrintPreview";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "In ấn";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FrmPrintPreview_FormClosing);
			base.Load += new global::System.EventHandler(this.FrmPrintPreview_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.btnZoomIn).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnZoomOut).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.btnLastPage).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.btnFirstPage).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrPageTo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrPageFrom).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrPage).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nmrLeft).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrRight).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrBottom).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nmrTop).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000046 RID: 70
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.CheckBox cbxPageNumber;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.Label totalPage;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.ComboBox cbxZoom;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.NumericUpDown nmrPage;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.NumericUpDown nmrLeft;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.NumericUpDown nmrRight;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.NumericUpDown nmrBottom;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.NumericUpDown nmrTop;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.Button btnPrint;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.PrintPreviewControl printPreviewControl1;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.RadioButton rbtnLandscape;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.RadioButton rbtnPortrait;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.ComboBox cbxPaperSize;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.ComboBox cbxPrinter;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.RadioButton rbtnCurPage;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.RadioButton rbtnPage;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.RadioButton rbtnAllPage;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.NumericUpDown nmrPageTo;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.NumericUpDown nmrPageFrom;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.PictureBox btnZoomOut;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.PictureBox btnZoomIn;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.PictureBox btnFirstPage;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.PictureBox btnLastPage;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.Button btnCustomTitle;
	}
}
