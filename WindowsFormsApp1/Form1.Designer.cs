
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reoGridControl1 = new unvell.ReoGrid.ReoGridControl();
            this.ctextMenuS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbCanChuViet = new System.Windows.Forms.Label();
            this.cbCanChuViet = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rbSongNgu = new System.Windows.Forms.RadioButton();
            this.rbChuViet = new System.Windows.Forms.RadioButton();
            this.rbChuHan = new System.Windows.Forms.RadioButton();
            this.cbHideGridLine = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txtLoaiSo = new System.Windows.Forms.ToolStripButton();
            this.labelCN = new System.Windows.Forms.ToolStripLabel();
            this.cbfnameCN = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cbfsizeCN = new System.Windows.Forms.ToolStripComboBox();
            this.cbfstyleCN = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.labelVN = new System.Windows.Forms.ToolStripLabel();
            this.cbfnameVN = new System.Windows.Forms.ToolStripComboBox();
            this.cbfsizeVN = new System.Windows.Forms.ToolStripComboBox();
            this.cbfstyleVN = new System.Windows.Forms.ToolStripComboBox();
            this.labelLicence = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // reoGridControl1
            // 
            this.reoGridControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.reoGridControl1.ColumnHeaderContextMenuStrip = null;
            this.reoGridControl1.ContextMenuStrip = this.ctextMenuS;
            this.reoGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reoGridControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reoGridControl1.LeadHeaderContextMenuStrip = null;
            this.reoGridControl1.Location = new System.Drawing.Point(0, 0);
            this.reoGridControl1.Margin = new System.Windows.Forms.Padding(150, 2, 2, 2);
            this.reoGridControl1.Name = "reoGridControl1";
            this.reoGridControl1.Padding = new System.Windows.Forms.Padding(150, 0, 0, 0);
            this.reoGridControl1.RowHeaderContextMenuStrip = null;
            this.reoGridControl1.Script = null;
            this.reoGridControl1.SheetTabContextMenuStrip = null;
            this.reoGridControl1.SheetTabNewButtonVisible = true;
            this.reoGridControl1.SheetTabVisible = true;
            this.reoGridControl1.SheetTabWidth = 60;
            this.reoGridControl1.ShowScrollEndSpacing = true;
            this.reoGridControl1.Size = new System.Drawing.Size(1031, 703);
            this.reoGridControl1.TabIndex = 2;
            this.reoGridControl1.Text = "reoGridControl1";
            this.reoGridControl1.TextChanged += new System.EventHandler(this.reoGridControl1_TextChanged);
            this.reoGridControl1.Click += new System.EventHandler(this.reoGridControl1_Click_1);
            this.reoGridControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.reoGridControl1_PreviewKeyDown);
            // 
            // ctextMenuS
            // 
            this.ctextMenuS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctextMenuS.Name = "contextMenuStrip1";
            this.ctextMenuS.Size = new System.Drawing.Size(61, 4);
            this.ctextMenuS.Opening += new System.ComponentModel.CancelEventHandler(this.ctextMenuS_Opening);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.button9);
            this.splitContainer1.Panel1.Controls.Add(this.button6);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button8);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.cbHideGridLine);
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button7);
            this.splitContainer1.Panel1.Controls.Add(this.button5);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.splitContainer1.Size = new System.Drawing.Size(1222, 711);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 3;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.BackColor = System.Drawing.Color.Teal;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.Transparent;
            this.button9.Location = new System.Drawing.Point(10, 516);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(152, 36);
            this.button9.TabIndex = 25;
            this.button9.Text = "Download font";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.Teal;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(10, 476);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(152, 36);
            this.button6.TabIndex = 24;
            this.button6.Text = "Update data";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Teal;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(10, 437);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 36);
            this.button3.TabIndex = 23;
            this.button3.Text = "Chia sẻ";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.BackColor = System.Drawing.Color.Teal;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.Location = new System.Drawing.Point(10, 397);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(152, 36);
            this.button8.TabIndex = 22;
            this.button8.Text = "Tạo lòng sớ mới";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click_2);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Controls.Add(this.lbCanChuViet);
            this.groupBox2.Controls.Add(this.cbCanChuViet);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.rbSongNgu);
            this.groupBox2.Controls.Add(this.rbChuViet);
            this.groupBox2.Controls.Add(this.rbChuHan);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(156, 174);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // lbCanChuViet
            // 
            this.lbCanChuViet.AutoSize = true;
            this.lbCanChuViet.Location = new System.Drawing.Point(3, 128);
            this.lbCanChuViet.Name = "lbCanChuViet";
            this.lbCanChuViet.Size = new System.Drawing.Size(67, 13);
            this.lbCanChuViet.TabIndex = 22;
            this.lbCanChuViet.Text = "Căn chữ việt";
            // 
            // cbCanChuViet
            // 
            this.cbCanChuViet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCanChuViet.FormattingEnabled = true;
            this.cbCanChuViet.Items.AddRange(new object[] {
            "TOP",
            "BOTTOM",
            "LEFT",
            "RIGHT"});
            this.cbCanChuViet.Location = new System.Drawing.Point(3, 148);
            this.cbCanChuViet.Name = "cbCanChuViet";
            this.cbCanChuViet.Size = new System.Drawing.Size(148, 21);
            this.cbCanChuViet.TabIndex = 21;
            this.cbCanChuViet.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 15);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Có in mã sớ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // rbSongNgu
            // 
            this.rbSongNgu.AutoSize = true;
            this.rbSongNgu.Location = new System.Drawing.Point(16, 88);
            this.rbSongNgu.Margin = new System.Windows.Forms.Padding(2);
            this.rbSongNgu.Name = "rbSongNgu";
            this.rbSongNgu.Size = new System.Drawing.Size(71, 17);
            this.rbSongNgu.TabIndex = 19;
            this.rbSongNgu.Tag = "";
            this.rbSongNgu.Text = "Song ngữ";
            this.rbSongNgu.UseVisualStyleBackColor = true;
            this.rbSongNgu.CheckedChanged += new System.EventHandler(this.button1_Click);
            // 
            // rbChuViet
            // 
            this.rbChuViet.AutoSize = true;
            this.rbChuViet.Location = new System.Drawing.Point(16, 37);
            this.rbChuViet.Margin = new System.Windows.Forms.Padding(2);
            this.rbChuViet.Name = "rbChuViet";
            this.rbChuViet.Size = new System.Drawing.Size(64, 17);
            this.rbChuViet.TabIndex = 17;
            this.rbChuViet.Text = "Chữ việt";
            this.rbChuViet.UseVisualStyleBackColor = true;
            this.rbChuViet.CheckedChanged += new System.EventHandler(this.button1_Click);
            // 
            // rbChuHan
            // 
            this.rbChuHan.AutoSize = true;
            this.rbChuHan.Location = new System.Drawing.Point(16, 63);
            this.rbChuHan.Margin = new System.Windows.Forms.Padding(2);
            this.rbChuHan.Name = "rbChuHan";
            this.rbChuHan.Size = new System.Drawing.Size(65, 17);
            this.rbChuHan.TabIndex = 18;
            this.rbChuHan.Text = "Chữ hán";
            this.rbChuHan.UseVisualStyleBackColor = true;
            this.rbChuHan.CheckedChanged += new System.EventHandler(this.button1_Click);
            // 
            // cbHideGridLine
            // 
            this.cbHideGridLine.AutoSize = true;
            this.cbHideGridLine.Location = new System.Drawing.Point(23, 187);
            this.cbHideGridLine.Margin = new System.Windows.Forms.Padding(2);
            this.cbHideGridLine.Name = "cbHideGridLine";
            this.cbHideGridLine.Size = new System.Drawing.Size(90, 17);
            this.cbHideGridLine.TabIndex = 17;
            this.cbHideGridLine.Text = "Hiện dòng kẻ";
            this.cbHideGridLine.UseVisualStyleBackColor = true;
            this.cbHideGridLine.CheckedChanged += new System.EventHandler(this.cbHideGridLine_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Teal;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(10, 356);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 36);
            this.button4.TabIndex = 16;
            this.button4.Text = "Xóa lòng sớ";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 636);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(10, 206);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 34);
            this.button1.TabIndex = 12;
            this.button1.Text = "Tín chủ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Teal;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(10, 245);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "Ngạch sớ";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(10, 322);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(152, 29);
            this.button7.TabIndex = 9;
            this.button7.Text = "Tải lại dữ liệu";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.Teal;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(10, 283);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(152, 34);
            this.button5.TabIndex = 7;
            this.button5.Text = "Cài đặt khổ giấy";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.reoGridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 703);
            this.panel1.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(0, 624);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1031, 79);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.txtLoaiSo,
            this.labelCN,
            this.cbfnameCN,
            this.toolStripSeparator1,
            this.cbfsizeCN,
            this.cbfstyleCN,
            this.toolStripSeparator3,
            this.labelVN,
            this.cbfnameVN,
            this.cbfsizeVN,
            this.cbfstyleVN,
            this.labelLicence});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(1222, 35);
            this.bindingNavigator1.Stretch = true;
            this.bindingNavigator1.TabIndex = 4;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::WindowsFormsApp1.Properties.Resources.print;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(56, 24);
            this.toolStripButton1.Text = "In sớ";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(45, 24);
            this.toolStripLabel3.Text = "Loại sớ";
            // 
            // txtLoaiSo
            // 
            this.txtLoaiSo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtLoaiSo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.txtLoaiSo.Image = ((System.Drawing.Image)(resources.GetObject("txtLoaiSo.Image")));
            this.txtLoaiSo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtLoaiSo.Name = "txtLoaiSo";
            this.txtLoaiSo.Size = new System.Drawing.Size(62, 24);
            this.txtLoaiSo.Text = ".................";
            this.txtLoaiSo.Click += new System.EventHandler(this.txtLoaiSo_Click);
            // 
            // labelCN
            // 
            this.labelCN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCN.Name = "labelCN";
            this.labelCN.Size = new System.Drawing.Size(80, 24);
            this.labelCN.Text = "Kiểu chữ nho";
            // 
            // cbfnameCN
            // 
            this.cbfnameCN.BackColor = System.Drawing.SystemColors.Info;
            this.cbfnameCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfnameCN.Name = "cbfnameCN";
            this.cbfnameCN.Size = new System.Drawing.Size(137, 27);
            this.cbfnameCN.DropDownClosed += new System.EventHandler(this.RenderFontSizeChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // cbfsizeCN
            // 
            this.cbfsizeCN.AutoCompleteCustomSource.AddRange(new string[] {
            "6",
            "6.75",
            "7",
            "7.5",
            "8",
            "8.25",
            "9",
            "9.75",
            "10",
            "10.5",
            "11",
            "11.25",
            "12",
            "12.75",
            "13",
            "13.5",
            "14",
            "14.25",
            "15",
            "15.75",
            "16",
            "16.5",
            "17",
            "17.25",
            "18",
            "18.75",
            "19",
            "19.5",
            "20",
            "20.25",
            "21",
            "21.75",
            "22",
            "22.5",
            "23",
            "23.25",
            "24",
            "24.75",
            "25",
            "25.5",
            "26",
            "26.25",
            "27",
            "27.75",
            "28",
            "28.5",
            "29",
            "29.25",
            "30",
            "30.75",
            "31",
            "31.5",
            "32",
            "32.25",
            "33",
            "33.75",
            "34",
            "34.5",
            "35",
            "35.25",
            "36"});
            this.cbfsizeCN.BackColor = System.Drawing.SystemColors.Info;
            this.cbfsizeCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfsizeCN.Items.AddRange(new object[] {
            "6",
            "6.75",
            "7",
            "7.5",
            "8",
            "8.25",
            "9",
            "9.75",
            "10",
            "10.5",
            "11",
            "11.25",
            "12",
            "12.75",
            "13",
            "13.5",
            "14",
            "14.25",
            "15",
            "15.75",
            "16",
            "16.5",
            "17",
            "17.25",
            "18",
            "18.75",
            "19",
            "19.5",
            "20",
            "20.25",
            "21",
            "21.75",
            "22",
            "22.5",
            "23",
            "23.25",
            "24",
            "24.75",
            "25",
            "25.5",
            "26",
            "26.25",
            "27",
            "27.75",
            "28",
            "28.5",
            "29",
            "29.25",
            "30",
            "30.75",
            "31",
            "31.5",
            "32",
            "32.25",
            "33",
            "33.75",
            "34",
            "34.5",
            "35",
            "35.25",
            "36"});
            this.cbfsizeCN.Name = "cbfsizeCN";
            this.cbfsizeCN.Size = new System.Drawing.Size(75, 27);
            this.cbfsizeCN.DropDownClosed += new System.EventHandler(this.RenderFontSizeChanged);
            this.cbfsizeCN.Click += new System.EventHandler(this.cbfsizeCN_Click);
            // 
            // cbfstyleCN
            // 
            this.cbfstyleCN.BackColor = System.Drawing.SystemColors.Info;
            this.cbfstyleCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfstyleCN.Items.AddRange(new object[] {
            "Đậm",
            "Nghiêng",
            "Thường"});
            this.cbfstyleCN.Name = "cbfstyleCN";
            this.cbfstyleCN.Size = new System.Drawing.Size(75, 27);
            this.cbfstyleCN.DropDownClosed += new System.EventHandler(this.RenderFontSizeChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // labelVN
            // 
            this.labelVN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVN.Name = "labelVN";
            this.labelVN.Size = new System.Drawing.Size(81, 24);
            this.labelVN.Text = "Kiểu chữ việt";
            // 
            // cbfnameVN
            // 
            this.cbfnameVN.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cbfnameVN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfnameVN.Name = "cbfnameVN";
            this.cbfnameVN.Size = new System.Drawing.Size(137, 27);
            this.cbfnameVN.DropDownClosed += new System.EventHandler(this.RenderFontSizeChanged);
            // 
            // cbfsizeVN
            // 
            this.cbfsizeVN.AutoCompleteCustomSource.AddRange(new string[] {
            "6",
            "6.75",
            "7",
            "7.5",
            "8",
            "8.25",
            "9",
            "9.75",
            "10",
            "10.5",
            "11",
            "11.25",
            "12",
            "12.75",
            "13",
            "13.5",
            "14",
            "14.25",
            "15",
            "15.75",
            "16",
            "16.5",
            "17",
            "17.25",
            "18",
            "18.75",
            "19",
            "19.5",
            "20",
            "20.25",
            "21",
            "21.75",
            "22",
            "22.5",
            "23",
            "23.25",
            "24",
            "24.75",
            "25",
            "25.5",
            "26",
            "26.25",
            "27",
            "27.75",
            "28",
            "28.5",
            "29",
            "29.25",
            "30",
            "30.75",
            "31",
            "31.5",
            "32",
            "32.25",
            "33",
            "33.75",
            "34",
            "34.5",
            "35",
            "35.25",
            "36"});
            this.cbfsizeVN.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cbfsizeVN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfsizeVN.Items.AddRange(new object[] {
            "6",
            "6.75",
            "7",
            "7.5",
            "8",
            "8.25",
            "9",
            "9.75",
            "10",
            "10.5",
            "11",
            "11.25",
            "12",
            "12.75",
            "13",
            "13.5",
            "14",
            "14.25",
            "15",
            "15.75",
            "16",
            "16.5",
            "17",
            "17.25",
            "18",
            "18.75",
            "19",
            "19.5",
            "20",
            "20.25",
            "21",
            "21.75",
            "22",
            "22.5",
            "23",
            "23.25",
            "24",
            "24.75",
            "25",
            "25.5",
            "26",
            "26.25",
            "27",
            "27.75",
            "28",
            "28.5",
            "29",
            "29.25",
            "30",
            "30.75",
            "31",
            "31.5",
            "32",
            "32.25",
            "33",
            "33.75",
            "34",
            "34.5",
            "35",
            "35.25",
            "36"});
            this.cbfsizeVN.Name = "cbfsizeVN";
            this.cbfsizeVN.Size = new System.Drawing.Size(75, 27);
            this.cbfsizeVN.DropDownClosed += new System.EventHandler(this.RenderFontSizeChanged);
            // 
            // cbfstyleVN
            // 
            this.cbfstyleVN.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cbfstyleVN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfstyleVN.Items.AddRange(new object[] {
            "Đậm",
            "Nghiêng",
            "Thường"});
            this.cbfstyleVN.Name = "cbfstyleVN";
            this.cbfstyleVN.Size = new System.Drawing.Size(75, 27);
            this.cbfstyleVN.DropDownClosed += new System.EventHandler(this.RenderFontSizeChanged);
            // 
            // labelLicence
            // 
            this.labelLicence.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLicence.ForeColor = System.Drawing.Color.Red;
            this.labelLicence.Name = "labelLicence";
            this.labelLicence.Size = new System.Drawing.Size(92, 24);
            this.labelLicence.Text = "toolStripLabel1";
            this.labelLicence.Click += new System.EventHandler(this.labelLicence_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 746);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bindingNavigator1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Phần mềm viết sớ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ContextMenuStrip contextMenuStrip2;
        private unvell.ReoGrid.ReoGridControl reoGridControl1;
        private SplitContainer splitContainer1;
        private Panel panel1;
        private Button button5;
        private Button button7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private BindingNavigator bindingNavigator1;
        private ToolStripLabel labelCN;
        private ToolStripComboBox cbfnameCN;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox cbfsizeCN;
        private ToolStripComboBox cbfstyleCN;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel labelVN;
        private ToolStripComboBox cbfnameVN;
        private ToolStripComboBox cbfsizeVN;
        private ToolStripComboBox cbfstyleVN;
        private ToolStripLabel toolStripLabel3;
        private ToolStripButton txtLoaiSo;
        private ToolStripSeparator toolStripSeparator2;
        private Button button2;
        private Button button1;
        private ToolStripButton toolStripButton1;
        private PictureBox pictureBox1;
        private Button button4;
        private CheckBox cbHideGridLine;
        private ContextMenuStrip ctextMenuS;
        private GroupBox groupBox2;
        private CheckBox checkBox1;
        private RadioButton rbSongNgu;
        private RadioButton rbChuViet;
        private RadioButton rbChuHan;
        private Button button8;
        private ToolStripLabel labelLicence;
        private RichTextBox richTextBox1;
        private ComboBox cbCanChuViet;
        private Label lbCanChuViet;
        private Button button3;
        private Button button6;
        private Button button9;
    }
}

