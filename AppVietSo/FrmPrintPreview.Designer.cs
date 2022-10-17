
namespace AppVietSo
{
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.PictureBox();
            this.btnZoomOut = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLastPage = new System.Windows.Forms.PictureBox();
            this.btnFirstPage = new System.Windows.Forms.PictureBox();
            this.nmrPageTo = new System.Windows.Forms.NumericUpDown();
            this.nmrPageFrom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnCurPage = new System.Windows.Forms.RadioButton();
            this.rbtnPage = new System.Windows.Forms.RadioButton();
            this.rbtnAllPage = new System.Windows.Forms.RadioButton();
            this.nmrPage = new System.Windows.Forms.NumericUpDown();
            this.totalPage = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnLandscape = new System.Windows.Forms.RadioButton();
            this.rbtnPortrait = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPaperSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPrinter = new System.Windows.Forms.ComboBox();
            this.cbxZoom = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nmrLeft = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nmrRight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nmrBottom = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nmrTop = new System.Windows.Forms.NumericUpDown();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnZoomIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnZoomOut)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLastPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFirstPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPageTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPageFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrTop)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.printPreviewControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1362, 892);
            this.splitContainer1.SplitterDistance = 302;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::AppVietSo.Properties.Resources.leftArrow;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(11, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 38);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Quay lại";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackgroundImage = global::AppVietSo.Properties.Resources.zoomin24;
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomIn.Location = new System.Drawing.Point(254, 132);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(30, 30);
            this.btnZoomIn.TabIndex = 46;
            this.btnZoomIn.TabStop = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackgroundImage = global::AppVietSo.Properties.Resources.zoomout24;
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomOut.Location = new System.Drawing.Point(127, 132);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(30, 30);
            this.btnZoomOut.TabIndex = 45;
            this.btnZoomOut.TabStop = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // groupBox3
            // 
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
            this.groupBox3.Location = new System.Drawing.Point(11, 663);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 217);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trang in";
            // 
            // btnLastPage
            // 
            this.btnLastPage.BackgroundImage = global::AppVietSo.Properties.Resources.end24;
            this.btnLastPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLastPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLastPage.Location = new System.Drawing.Point(185, 170);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(30, 30);
            this.btnLastPage.TabIndex = 50;
            this.btnLastPage.TabStop = false;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.BackgroundImage = global::AppVietSo.Properties.Resources.home24;
            this.btnFirstPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFirstPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirstPage.Location = new System.Drawing.Point(18, 170);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(30, 30);
            this.btnFirstPage.TabIndex = 47;
            this.btnFirstPage.TabStop = false;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // nmrPageTo
            // 
            this.nmrPageTo.Enabled = false;
            this.nmrPageTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrPageTo.Location = new System.Drawing.Point(214, 72);
            this.nmrPageTo.Margin = new System.Windows.Forms.Padding(5);
            this.nmrPageTo.Name = "nmrPageTo";
            this.nmrPageTo.Size = new System.Drawing.Size(50, 28);
            this.nmrPageTo.TabIndex = 49;
            this.nmrPageTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrPageTo.ValueChanged += new System.EventHandler(this.nmrPageTo_ValueChanged);
            // 
            // nmrPageFrom
            // 
            this.nmrPageFrom.Enabled = false;
            this.nmrPageFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrPageFrom.Location = new System.Drawing.Point(124, 72);
            this.nmrPageFrom.Margin = new System.Windows.Forms.Padding(5);
            this.nmrPageFrom.Name = "nmrPageFrom";
            this.nmrPageFrom.Size = new System.Drawing.Size(50, 28);
            this.nmrPageFrom.TabIndex = 48;
            this.nmrPageFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrPageFrom.ValueChanged += new System.EventHandler(this.nmrPageFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "đến";
            // 
            // rbtnCurPage
            // 
            this.rbtnCurPage.AutoSize = true;
            this.rbtnCurPage.Location = new System.Drawing.Point(15, 118);
            this.rbtnCurPage.Name = "rbtnCurPage";
            this.rbtnCurPage.Size = new System.Drawing.Size(132, 24);
            this.rbtnCurPage.TabIndex = 46;
            this.rbtnCurPage.TabStop = true;
            this.rbtnCurPage.Text = "Trang hiện tại";
            this.rbtnCurPage.UseVisualStyleBackColor = true;
            // 
            // rbtnPage
            // 
            this.rbtnPage.AutoSize = true;
            this.rbtnPage.Location = new System.Drawing.Point(15, 73);
            this.rbtnPage.Name = "rbtnPage";
            this.rbtnPage.Size = new System.Drawing.Size(92, 24);
            this.rbtnPage.TabIndex = 1;
            this.rbtnPage.TabStop = true;
            this.rbtnPage.Text = "Từ trang";
            this.rbtnPage.UseVisualStyleBackColor = true;
            this.rbtnPage.CheckedChanged += new System.EventHandler(this.rbtnPage_CheckedChanged);
            // 
            // rbtnAllPage
            // 
            this.rbtnAllPage.AutoSize = true;
            this.rbtnAllPage.Checked = true;
            this.rbtnAllPage.Location = new System.Drawing.Point(18, 33);
            this.rbtnAllPage.Name = "rbtnAllPage";
            this.rbtnAllPage.Size = new System.Drawing.Size(152, 24);
            this.rbtnAllPage.TabIndex = 0;
            this.rbtnAllPage.TabStop = true;
            this.rbtnAllPage.Text = "Tất cả các trang";
            this.rbtnAllPage.UseVisualStyleBackColor = true;
            // 
            // nmrPage
            // 
            this.nmrPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrPage.Location = new System.Drawing.Point(56, 169);
            this.nmrPage.Margin = new System.Windows.Forms.Padding(5);
            this.nmrPage.Name = "nmrPage";
            this.nmrPage.Size = new System.Drawing.Size(50, 28);
            this.nmrPage.TabIndex = 32;
            this.nmrPage.ValueChanged += new System.EventHandler(this.nmrPage_ValueChanged);
            // 
            // totalPage
            // 
            this.totalPage.AutoSize = true;
            this.totalPage.Location = new System.Drawing.Point(106, 173);
            this.totalPage.Name = "totalPage";
            this.totalPage.Size = new System.Drawing.Size(66, 20);
            this.totalPage.TabIndex = 35;
            this.totalPage.Text = "/1 trang";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnLandscape);
            this.groupBox1.Controls.Add(this.rbtnPortrait);
            this.groupBox1.Location = new System.Drawing.Point(11, 507);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 60);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hướng giấy";
            // 
            // rbtnLandscape
            // 
            this.rbtnLandscape.AutoSize = true;
            this.rbtnLandscape.Location = new System.Drawing.Point(184, 26);
            this.rbtnLandscape.Name = "rbtnLandscape";
            this.rbtnLandscape.Size = new System.Drawing.Size(78, 24);
            this.rbtnLandscape.TabIndex = 1;
            this.rbtnLandscape.TabStop = true;
            this.rbtnLandscape.Text = "Ngang";
            this.rbtnLandscape.UseVisualStyleBackColor = true;
            this.rbtnLandscape.CheckedChanged += new System.EventHandler(this.rbtnPortrait_CheckedChanged);
            // 
            // rbtnPortrait
            // 
            this.rbtnPortrait.AutoSize = true;
            this.rbtnPortrait.Location = new System.Drawing.Point(95, 26);
            this.rbtnPortrait.Name = "rbtnPortrait";
            this.rbtnPortrait.Size = new System.Drawing.Size(61, 24);
            this.rbtnPortrait.TabIndex = 0;
            this.rbtnPortrait.TabStop = true;
            this.rbtnPortrait.Text = "Dọc";
            this.rbtnPortrait.UseVisualStyleBackColor = true;
            this.rbtnPortrait.CheckedChanged += new System.EventHandler(this.rbtnPortrait_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(12, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Cỡ giấy";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbxPaperSize
            // 
            this.cbxPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPaperSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPaperSize.FormattingEnabled = true;
            this.cbxPaperSize.Items.AddRange(new object[] {
            "60%",
            "70%",
            "80%",
            "90%",
            "100%",
            "110%",
            "120%",
            "130%",
            "140%",
            "150%"});
            this.cbxPaperSize.Location = new System.Drawing.Point(11, 267);
            this.cbxPaperSize.Name = "cbxPaperSize";
            this.cbxPaperSize.Size = new System.Drawing.Size(273, 30);
            this.cbxPaperSize.TabIndex = 41;
            this.cbxPaperSize.SelectedIndexChanged += new System.EventHandler(this.cbxPaperSize_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(12, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Máy in";
            // 
            // cbxPrinter
            // 
            this.cbxPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPrinter.FormattingEnabled = true;
            this.cbxPrinter.Location = new System.Drawing.Point(11, 198);
            this.cbxPrinter.Name = "cbxPrinter";
            this.cbxPrinter.Size = new System.Drawing.Size(273, 30);
            this.cbxPrinter.TabIndex = 39;
            this.cbxPrinter.SelectedIndexChanged += new System.EventHandler(this.cbxPrinter_SelectedIndexChanged);
            // 
            // cbxZoom
            // 
            this.cbxZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxZoom.FormattingEnabled = true;
            this.cbxZoom.Items.AddRange(new object[] {
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
            "150%"});
            this.cbxZoom.Location = new System.Drawing.Point(163, 130);
            this.cbxZoom.Name = "cbxZoom";
            this.cbxZoom.Size = new System.Drawing.Size(85, 30);
            this.cbxZoom.TabIndex = 33;
            this.cbxZoom.SelectedIndexChanged += new System.EventHandler(this.cbxZoom_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nmrLeft);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nmrRight);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.nmrBottom);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nmrTop);
            this.groupBox2.Location = new System.Drawing.Point(11, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 163);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khoảng cách lề giấy (mm)";
            // 
            // nmrLeft
            // 
            this.nmrLeft.Location = new System.Drawing.Point(57, 77);
            this.nmrLeft.Margin = new System.Windows.Forms.Padding(5);
            this.nmrLeft.Name = "nmrLeft";
            this.nmrLeft.Size = new System.Drawing.Size(50, 26);
            this.nmrLeft.TabIndex = 5;
            this.nmrLeft.ValueChanged += new System.EventHandler(this.nmrTop_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Trên";
            // 
            // nmrRight
            // 
            this.nmrRight.Location = new System.Drawing.Point(206, 77);
            this.nmrRight.Margin = new System.Windows.Forms.Padding(5);
            this.nmrRight.Name = "nmrRight";
            this.nmrRight.Size = new System.Drawing.Size(50, 26);
            this.nmrRight.TabIndex = 6;
            this.nmrRight.ValueChanged += new System.EventHandler(this.nmrTop_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dưới";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Trái";
            // 
            // nmrBottom
            // 
            this.nmrBottom.Location = new System.Drawing.Point(122, 126);
            this.nmrBottom.Margin = new System.Windows.Forms.Padding(5);
            this.nmrBottom.Name = "nmrBottom";
            this.nmrBottom.Size = new System.Drawing.Size(50, 26);
            this.nmrBottom.TabIndex = 4;
            this.nmrBottom.ValueChanged += new System.EventHandler(this.nmrTop_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Phải";
            // 
            // nmrTop
            // 
            this.nmrTop.Location = new System.Drawing.Point(122, 31);
            this.nmrTop.Margin = new System.Windows.Forms.Padding(5);
            this.nmrTop.Name = "nmrTop";
            this.nmrTop.Size = new System.Drawing.Size(50, 26);
            this.nmrTop.TabIndex = 3;
            this.nmrTop.ValueChanged += new System.EventHandler(this.nmrTop_ValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::AppVietSo.Properties.Resources.print;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(196, 22);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 76);
            this.btnPrint.TabIndex = 30;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(1056, 892);
            this.printPreviewControl1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 76);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 24);
            this.checkBox1.TabIndex = 48;
            this.checkBox1.Text = "Khoa cúng";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Location = new System.Drawing.Point(11, 586);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(273, 60);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Số bản In";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(18, 26);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(5);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(134, 26);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 892);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "FrmPrintPreview";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "In ấn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrintPreview_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrintPreview_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnZoomIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnZoomOut)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLastPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFirstPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPageTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPageFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrTop)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x04000046 RID: 70
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.SplitContainer splitContainer1;

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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
