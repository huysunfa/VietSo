using System.Windows.Forms;

namespace AppVietSo
{
    partial class frmTinChu
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBtnAddPerson = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCbxChua = new System.Windows.Forms.ToolStripComboBox();
            this.toolBtnEditChua = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnOk = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlChooseMa = new System.Windows.Forms.Panel();
            this.nUpDFrom = new System.Windows.Forms.NumericUpDown();
            this.nUpDTo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.lblTongNguoi = new System.Windows.Forms.Label();
            this.lblTongLaSo = new System.Windows.Forms.Label();
            this.pnlOverPerson = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOverPerson = new System.Windows.Forms.DataGridView();
            this.MaSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckbChuSo = new System.Windows.Forms.CheckBox();
            this.dgvPerson = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhXung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderUp = new System.Windows.Forms.DataGridViewImageColumn();
            this.Orders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDown = new System.Windows.Forms.DataGridViewImageColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PagodaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlChooseMa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOverPerson)).BeginInit();
            this.pnlOverPerson.Panel1.SuspendLayout();
            this.pnlOverPerson.Panel2.SuspendLayout();
            this.pnlOverPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnAddPerson,
            this.toolStripSeparator1,
            this.toolCbxChua,
            this.toolBtnEditChua,
            this.toolStripSeparator2,
            this.toolTxtSearch,
            this.toolBtnSearch,
            this.toolStripSeparator3,
            this.toolBtnOk});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(1, 10, 1, 10);
            this.toolStrip1.Size = new System.Drawing.Size(1371, 53);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolBtnAddPerson
            // 
            this.toolBtnAddPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.toolBtnAddPerson.Image = global::AppVietSo.Properties.Resources.add;
            this.toolBtnAddPerson.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAddPerson.Name = "toolBtnAddPerson";
            this.toolBtnAddPerson.Size = new System.Drawing.Size(156, 30);
            this.toolBtnAddPerson.Text = "Thêm Tín Chủ";
            this.toolBtnAddPerson.Click += new System.EventHandler(this.toolBtnAddPerson_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // toolCbxChua
            // 
            this.toolCbxChua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolCbxChua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolCbxChua.Name = "toolCbxChua";
            this.toolCbxChua.Size = new System.Drawing.Size(265, 33);
            // 
            // toolBtnEditChua
            // 
            this.toolBtnEditChua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnEditChua.Image = global::AppVietSo.Properties.Resources.edit;
            this.toolBtnEditChua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnEditChua.Name = "toolBtnEditChua";
            this.toolBtnEditChua.Size = new System.Drawing.Size(29, 30);
            this.toolBtnEditChua.Text = "Sửa tên Chùa, Điện";
            this.toolBtnEditChua.Click += new System.EventHandler(this.toolBtnEditChua_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // toolTxtSearch
            // 
            this.toolTxtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolTxtSearch.Name = "toolTxtSearch";
            this.toolTxtSearch.Size = new System.Drawing.Size(199, 33);
            this.toolTxtSearch.ToolTipText = "nhập Tên hoặc Mã sớ";
            this.toolTxtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolTxtSearch_KeyPress);
            // 
            // toolBtnSearch
            // 
            this.toolBtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.toolBtnSearch.Image = global::AppVietSo.Properties.Resources.search;
            this.toolBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSearch.Name = "toolBtnSearch";
            this.toolBtnSearch.Size = new System.Drawing.Size(76, 30);
            this.toolBtnSearch.Text = " Tìm ";
            this.toolBtnSearch.ToolTipText = "Tên hoặc mã sớ";
            this.toolBtnSearch.Click += new System.EventHandler(this.toolBtnSearch_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // toolBtnOk
            // 
            this.toolBtnOk.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolBtnOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.toolBtnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnOk.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.toolBtnOk.Name = "toolBtnOk";
            this.toolBtnOk.Padding = new System.Windows.Forms.Padding(15, 1, 15, 1);
            this.toolBtnOk.Size = new System.Drawing.Size(73, 30);
            this.toolBtnOk.Text = "OK";
            this.toolBtnOk.Click += new System.EventHandler(this.toolBtnOk_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1371, 679);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlChooseMa);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrintPreview);
            this.splitContainer1.Panel1.Controls.Add(this.lblTongNguoi);
            this.splitContainer1.Panel1.Controls.Add(this.lblTongLaSo);
            this.splitContainer1.Panel1.Controls.Add(this.pnlOverPerson);
            this.splitContainer1.Panel1.Controls.Add(this.ckbChuSo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvPerson);
            this.splitContainer1.Size = new System.Drawing.Size(1371, 679);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 4;
            // 
            // pnlChooseMa
            // 
            this.pnlChooseMa.Controls.Add(this.nUpDFrom);
            this.pnlChooseMa.Controls.Add(this.nUpDTo);
            this.pnlChooseMa.Controls.Add(this.label2);
            this.pnlChooseMa.Controls.Add(this.label3);
            this.pnlChooseMa.Location = new System.Drawing.Point(0, 44);
            this.pnlChooseMa.Margin = new System.Windows.Forms.Padding(4);
            this.pnlChooseMa.Name = "pnlChooseMa";
            this.pnlChooseMa.Size = new System.Drawing.Size(247, 110);
            this.pnlChooseMa.TabIndex = 55;
            // 
            // nUpDFrom
            // 
            this.nUpDFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUpDFrom.Location = new System.Drawing.Point(136, 18);
            this.nUpDFrom.Margin = new System.Windows.Forms.Padding(4);
            this.nUpDFrom.Name = "nUpDFrom";
            this.nUpDFrom.Size = new System.Drawing.Size(87, 30);
            this.nUpDFrom.TabIndex = 52;
            this.nUpDFrom.ValueChanged += new System.EventHandler(this.nUpDFrom_ValueChanged);
            // 
            // nUpDTo
            // 
            this.nUpDTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUpDTo.Location = new System.Drawing.Point(136, 58);
            this.nUpDTo.Margin = new System.Windows.Forms.Padding(4);
            this.nUpDTo.Name = "nUpDTo";
            this.nUpDTo.Size = new System.Drawing.Size(87, 30);
            this.nUpDTo.TabIndex = 54;
            this.nUpDTo.ValueChanged += new System.EventHandler(this.nUpDTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 51;
            this.label2.Text = "Chọn từ mã";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 53;
            this.label3.Text = "đến mã";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.AutoSize = true;
            this.btnPrintPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPreview.Location = new System.Drawing.Point(8, 178);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(203, 43);
            this.btnPrintPreview.TabIndex = 50;
            this.btnPrintPreview.Text = "In danh sách tín chủ";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // lblTongNguoi
            // 
            this.lblTongNguoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongNguoi.AutoSize = true;
            this.lblTongNguoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongNguoi.Location = new System.Drawing.Point(16, 645);
            this.lblTongNguoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongNguoi.Name = "lblTongNguoi";
            this.lblTongNguoi.Size = new System.Drawing.Size(108, 24);
            this.lblTongNguoi.TabIndex = 5;
            this.lblTongNguoi.Text = "Tổng người";
            // 
            // lblTongLaSo
            // 
            this.lblTongLaSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongLaSo.AutoSize = true;
            this.lblTongLaSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLaSo.Location = new System.Drawing.Point(16, 613);
            this.lblTongLaSo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongLaSo.Name = "lblTongLaSo";
            this.lblTongLaSo.Size = new System.Drawing.Size(99, 24);
            this.lblTongLaSo.TabIndex = 4;
            this.lblTongLaSo.Text = "Tổng lá sớ";
            // 
            // pnlOverPerson
            // 
            this.pnlOverPerson.Location = new System.Drawing.Point(11, 242);
            this.pnlOverPerson.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOverPerson.Name = "pnlOverPerson";
            this.pnlOverPerson.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlOverPerson.Panel1
            // 
            this.pnlOverPerson.Panel1.Controls.Add(this.label1);
            // 
            // pnlOverPerson.Panel2
            // 
            this.pnlOverPerson.Panel2.Controls.Add(this.dgvOverPerson);
            this.pnlOverPerson.Size = new System.Drawing.Size(212, 156);
            this.pnlOverPerson.SplitterDistance = 30;
            this.pnlOverPerson.SplitterWidth = 5;
            this.pnlOverPerson.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sớ có quá nhiều người";
            // 
            // dgvOverPerson
            // 
            this.dgvOverPerson.AllowUserToAddRows = false;
            this.dgvOverPerson.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOverPerson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOverPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSo,
            this.TotalPerson});
            this.dgvOverPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOverPerson.Location = new System.Drawing.Point(0, 0);
            this.dgvOverPerson.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOverPerson.Name = "dgvOverPerson";
            this.dgvOverPerson.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOverPerson.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOverPerson.RowHeadersVisible = false;
            this.dgvOverPerson.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvOverPerson.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOverPerson.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvOverPerson.Size = new System.Drawing.Size(212, 121);
            this.dgvOverPerson.TabIndex = 0;
            // 
            // MaSo
            // 
            this.MaSo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaSo.DataPropertyName = "MaSo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MaSo.DefaultCellStyle = dataGridViewCellStyle2;
            this.MaSo.HeaderText = "Mã Sớ";
            this.MaSo.MinimumWidth = 6;
            this.MaSo.Name = "MaSo";
            this.MaSo.ReadOnly = true;
            // 
            // TotalPerson
            // 
            this.TotalPerson.DataPropertyName = "TotalPerson";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TotalPerson.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalPerson.HeaderText = "Số người";
            this.TotalPerson.MinimumWidth = 6;
            this.TotalPerson.Name = "TotalPerson";
            this.TotalPerson.ReadOnly = true;
            this.TotalPerson.Width = 78;
            // 
            // ckbChuSo
            // 
            this.ckbChuSo.AutoSize = true;
            this.ckbChuSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbChuSo.Location = new System.Drawing.Point(12, 11);
            this.ckbChuSo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ckbChuSo.Name = "ckbChuSo";
            this.ckbChuSo.Size = new System.Drawing.Size(167, 28);
            this.ckbChuSo.TabIndex = 0;
            this.ckbChuSo.Text = "Chỉ hiện Chủ sớ";
            this.ckbChuSo.UseVisualStyleBackColor = true;
            this.ckbChuSo.CheckedChanged += new System.EventHandler(this.ckbChuSo_CheckedChanged);
            // 
            // dgvPerson
            // 
            this.dgvPerson.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPerson.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPerson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Checked,
            this.SoNo,
            this.DanhXung,
            this.FullName,
            this.NamSinh,
            this.NgayMat,
            this.GioiTinh,
            this.Address,
            this.orderUp,
            this.Orders,
            this.orderDown,
            this.Status,
            this.UpdateDT,
            this.action,
            this.PagodaID});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPerson.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerson.Location = new System.Drawing.Point(0, 0);
            this.dgvPerson.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPerson.MultiSelect = false;
            this.dgvPerson.Name = "dgvPerson";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPerson.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvPerson.RowHeadersWidth = 51;
            this.dgvPerson.RowTemplate.Height = 31;
            this.dgvPerson.Size = new System.Drawing.Size(1153, 679);
            this.dgvPerson.TabIndex = 3;
            this.dgvPerson.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPerson_CellBeginEdit);
            this.dgvPerson.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerson_CellContentClick);
            this.dgvPerson.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerson_CellEndEdit);
            this.dgvPerson.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dgvPerson_CellToolTipTextNeeded);
            this.dgvPerson.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPerson_CellValidating);
            this.dgvPerson.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPerson_RowPrePaint);
            this.dgvPerson.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPerson_UserDeletingRow);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // Checked
            // 
            this.Checked.DataPropertyName = "Checked";
            this.Checked.HeaderText = "Chọn";
            this.Checked.MinimumWidth = 6;
            this.Checked.Name = "Checked";
            this.Checked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Checked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Checked.ToolTipText = "Chọn để in";
            this.Checked.Width = 50;
            // 
            // SoNo
            // 
            this.SoNo.DataPropertyName = "SoNo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SoNo.DefaultCellStyle = dataGridViewCellStyle8;
            this.SoNo.HeaderText = "Mã sớ";
            this.SoNo.MinimumWidth = 6;
            this.SoNo.Name = "SoNo";
            this.SoNo.Width = 45;
            // 
            // DanhXung
            // 
            this.DanhXung.DataPropertyName = "DanhXung";
            this.DanhXung.HeaderText = "Danh xưng";
            this.DanhXung.MinimumWidth = 6;
            this.DanhXung.Name = "DanhXung";
            this.DanhXung.Width = 85;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FullName.DataPropertyName = "FullName";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullName.DefaultCellStyle = dataGridViewCellStyle9;
            this.FullName.HeaderText = "Họ tên";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            // 
            // NamSinh
            // 
            this.NamSinh.DataPropertyName = "NamSinh";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamSinh.DefaultCellStyle = dataGridViewCellStyle10;
            this.NamSinh.HeaderText = "Năm sinh";
            this.NamSinh.MinimumWidth = 6;
            this.NamSinh.Name = "NamSinh";
            this.NamSinh.Width = 85;
            // 
            // NgayMat
            // 
            this.NgayMat.DataPropertyName = "NgayMat";
            this.NgayMat.HeaderText = "Ngày mất";
            this.NgayMat.MinimumWidth = 6;
            this.NgayMat.Name = "NgayMat";
            this.NgayMat.Width = 125;
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.MinimumWidth = 6;
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GioiTinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.GioiTinh.Width = 70;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Địa chỉ";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            // 
            // orderUp
            // 
            this.orderUp.DataPropertyName = "orderUp";
            this.orderUp.HeaderText = "";
            this.orderUp.Image = global::AppVietSo.Properties.Resources.upArrow;
            this.orderUp.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.orderUp.MinimumWidth = 6;
            this.orderUp.Name = "orderUp";
            this.orderUp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.orderUp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.orderUp.ToolTipText = "Lên trên";
            this.orderUp.Width = 30;
            // 
            // Orders
            // 
            this.Orders.DataPropertyName = "Orders";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Orders.DefaultCellStyle = dataGridViewCellStyle11;
            this.Orders.HeaderText = "Thứ tự";
            this.Orders.MinimumWidth = 6;
            this.Orders.Name = "Orders";
            this.Orders.ToolTipText = "Thứ tự khi viết sớ";
            this.Orders.Width = 35;
            // 
            // orderDown
            // 
            this.orderDown.DataPropertyName = "orderDown";
            this.orderDown.HeaderText = "";
            this.orderDown.Image = global::AppVietSo.Properties.Resources.downArrow;
            this.orderDown.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.orderDown.MinimumWidth = 6;
            this.orderDown.Name = "orderDown";
            this.orderDown.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.orderDown.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.orderDown.ToolTipText = "Xuống dưới";
            this.orderDown.Width = 30;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Visible = false;
            this.Status.Width = 125;
            // 
            // UpdateDT
            // 
            this.UpdateDT.DataPropertyName = "UpdateDT";
            this.UpdateDT.HeaderText = "UpdateDT";
            this.UpdateDT.MinimumWidth = 6;
            this.UpdateDT.Name = "UpdateDT";
            this.UpdateDT.Visible = false;
            this.UpdateDT.Width = 125;
            // 
            // action
            // 
            this.action.DataPropertyName = "action";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle12.NullValue = "Xóa";
            this.action.DefaultCellStyle = dataGridViewCellStyle12;
            this.action.HeaderText = "";
            this.action.MinimumWidth = 6;
            this.action.Name = "action";
            this.action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.action.Width = 50;
            // 
            // PagodaID
            // 
            this.PagodaID.DataPropertyName = "PagodaID";
            this.PagodaID.HeaderText = "PagodaID";
            this.PagodaID.MinimumWidth = 6;
            this.PagodaID.Name = "PagodaID";
            this.PagodaID.Visible = false;
            this.PagodaID.Width = 125;
            // 
            // frmTinChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 732);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "frmTinChu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách tín chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPerson_FormClosing);
            this.Load += new System.EventHandler(this.FrmPerson_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlChooseMa.ResumeLayout(false);
            this.pnlChooseMa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDTo)).EndInit();
            this.pnlOverPerson.Panel1.ResumeLayout(false);
            this.pnlOverPerson.Panel1.PerformLayout();
            this.pnlOverPerson.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlOverPerson)).EndInit();
            this.pnlOverPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Token: 0x040000E5 RID: 229
        private global::System.ComponentModel.IContainer components;

        // Token: 0x040000E6 RID: 230
        private ToolStrip toolStrip1;

        // Token: 0x040000E7 RID: 231
        private ToolStripButton toolBtnAddPerson;

        // Token: 0x040000E8 RID: 232
        private ToolStripComboBox toolCbxChua;

        // Token: 0x040000E9 RID: 233
        private ToolStripTextBox toolTxtSearch;

        // Token: 0x040000EA RID: 234
        private ToolStripButton toolBtnSearch;

        // Token: 0x040000EB RID: 235
        private ToolStripSeparator toolStripSeparator1;

        // Token: 0x040000EC RID: 236
        private Panel panel1;

        // Token: 0x040000ED RID: 237
        private ToolStripSeparator toolStripSeparator2;

        // Token: 0x040000EE RID: 238
        private ToolStripSeparator toolStripSeparator3;

        // Token: 0x040000EF RID: 239
        private DataGridView dgvPerson;

        // Token: 0x040000F0 RID: 240
        private SplitContainer splitContainer1;

        // Token: 0x040000F1 RID: 241
        private CheckBox ckbChuSo;

        // Token: 0x040000F2 RID: 242
     //   private ToolTipCustom toolTipCustom1;

        // Token: 0x040000F3 RID: 243
        private ToolStripButton toolBtnEditChua;

        // Token: 0x040000F4 RID: 244
        private DataGridView dgvOverPerson;

        // Token: 0x040000F5 RID: 245
        private SplitContainer pnlOverPerson;

        // Token: 0x040000F6 RID: 246
        private Label label1;

        // Token: 0x040000F7 RID: 247
        private DataGridViewTextBoxColumn MaSo;

        // Token: 0x040000F8 RID: 248
        private DataGridViewTextBoxColumn TotalPerson;

        // Token: 0x040000F9 RID: 249
        private Label lblTongNguoi;

        // Token: 0x040000FA RID: 250
        private Label lblTongLaSo;

        // Token: 0x040000FB RID: 251
        private Button btnPrintPreview;

        // Token: 0x040000FC RID: 252
        private DataGridViewTextBoxColumn ID;

        // Token: 0x040000FD RID: 253
        private DataGridViewCheckBoxColumn Checked;

        // Token: 0x040000FE RID: 254
        private DataGridViewTextBoxColumn SoNo;

        // Token: 0x040000FF RID: 255
        private DataGridViewTextBoxColumn DanhXung;

        // Token: 0x04000100 RID: 256
        private DataGridViewTextBoxColumn FullName;

        // Token: 0x04000101 RID: 257
        private DataGridViewTextBoxColumn NamSinh;

        // Token: 0x04000102 RID: 258
        private DataGridViewTextBoxColumn NgayMat;

        // Token: 0x04000103 RID: 259
        private DataGridViewComboBoxColumn GioiTinh;

        // Token: 0x04000104 RID: 260
        private DataGridViewTextBoxColumn Address;

        // Token: 0x04000105 RID: 261
        private DataGridViewImageColumn orderUp;

        // Token: 0x04000106 RID: 262
        private DataGridViewTextBoxColumn Orders;

        // Token: 0x04000107 RID: 263
        private DataGridViewImageColumn orderDown;

        // Token: 0x04000108 RID: 264
        private DataGridViewTextBoxColumn Status;

        // Token: 0x04000109 RID: 265
        private DataGridViewTextBoxColumn UpdateDT;

        // Token: 0x0400010A RID: 266
        private DataGridViewButtonColumn action;

        // Token: 0x0400010B RID: 267
        private DataGridViewTextBoxColumn PagodaID;

        // Token: 0x0400010C RID: 268
        private NumericUpDown nUpDTo;

        // Token: 0x0400010D RID: 269
        private Label label3;

        // Token: 0x0400010E RID: 270
        private NumericUpDown nUpDFrom;

        // Token: 0x0400010F RID: 271
        private Label label2;

        // Token: 0x04000110 RID: 272
        private Panel pnlChooseMa;

        // Token: 0x04000111 RID: 273
        private ToolStripButton toolBtnOk;
    }
}
