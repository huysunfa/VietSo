
namespace AppVietSo
{
	public partial class FrmPersonSelectPrint : global::System.Windows.Forms.Form
	{
		// Token: 0x06000046 RID: 70 RVA: 0x00005478 File Offset: 0x00003678
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005498 File Offset: 0x00003698
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCbxChua = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nUpDTo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nUpDFrom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTongLaSo = new System.Windows.Forms.Label();
            this.dgvPerson = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTipCustom1 = new AppVietSo.ToolTipCustom();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnPrint,
            this.toolStripSeparator1,
            this.toolCbxChua,
            this.toolStripSeparator2,
            this.toolTxtSearch,
            this.toolBtnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(1, 10, 1, 10);
            this.toolStrip1.Size = new System.Drawing.Size(1010, 51);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolBtnPrint
            // 
            this.toolBtnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.toolBtnPrint.Image = global::AppVietSo.Properties.Resources.print;
            this.toolBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnPrint.Name = "toolBtnPrint";
            this.toolBtnPrint.Size = new System.Drawing.Size(199, 28);
            this.toolBtnPrint.Text = "in nhà được chọn";
            this.toolBtnPrint.Click += new System.EventHandler(this.toolBtnPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolCbxChua
            // 
            this.toolCbxChua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolCbxChua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolCbxChua.Name = "toolCbxChua";
            this.toolCbxChua.Size = new System.Drawing.Size(265, 31);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolTxtSearch
            // 
            this.toolTxtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolTxtSearch.Name = "toolTxtSearch";
            this.toolTxtSearch.Size = new System.Drawing.Size(199, 31);
            this.toolTxtSearch.ToolTipText = "nhập Tên hoặc Mã sớ";
            this.toolTxtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolTxtSearch_KeyPress);
            // 
            // toolBtnSearch
            // 
            this.toolBtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.toolBtnSearch.Image = global::AppVietSo.Properties.Resources.search;
            this.toolBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSearch.Name = "toolBtnSearch";
            this.toolBtnSearch.Size = new System.Drawing.Size(76, 28);
            this.toolBtnSearch.Text = " Tìm ";
            this.toolBtnSearch.ToolTipText = "Tên hoặc mã sớ";
            this.toolBtnSearch.Click += new System.EventHandler(this.toolBtnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 558);
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
            this.splitContainer1.Panel1.Controls.Add(this.nUpDTo);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.nUpDFrom);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblTongLaSo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvPerson);
            this.splitContainer1.Size = new System.Drawing.Size(1010, 558);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 4;
            // 
            // nUpDTo
            // 
            this.nUpDTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUpDTo.Location = new System.Drawing.Point(102, 144);
            this.nUpDTo.Name = "nUpDTo";
            this.nUpDTo.Size = new System.Drawing.Size(65, 30);
            this.nUpDTo.TabIndex = 10;
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
            this.label3.Location = new System.Drawing.Point(33, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "đến mã";
            // 
            // nUpDFrom
            // 
            this.nUpDFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUpDFrom.Location = new System.Drawing.Point(102, 112);
            this.nUpDFrom.Name = "nUpDFrom";
            this.nUpDFrom.Size = new System.Drawing.Size(65, 30);
            this.nUpDFrom.TabIndex = 8;
            this.nUpDFrom.ValueChanged += new System.EventHandler(this.nUpDFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chọn từ mã";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.MaximumSize = new System.Drawing.Size(200, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 125);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quý Thầy hãy tích chọn danh sách bên cạnh, sau đó ấn nút \"in nhà đươc chọn\"";
            // 
            // lblTongLaSo
            // 
            this.lblTongLaSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongLaSo.AutoSize = true;
            this.lblTongLaSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLaSo.Location = new System.Drawing.Point(13, 474);
            this.lblTongLaSo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongLaSo.Name = "lblTongLaSo";
            this.lblTongLaSo.Size = new System.Drawing.Size(99, 24);
            this.lblTongLaSo.TabIndex = 4;
            this.lblTongLaSo.Text = "Tổng lá sớ";
            // 
            // dgvPerson
            // 
            this.dgvPerson.AllowUserToAddRows = false;
            this.dgvPerson.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPerson.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPerson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Checked,
            this.SoNo,
            this.FullName,
            this.NamSinh,
            this.NgayMat,
            this.GioiTinh,
            this.Address});
            this.dgvPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerson.Location = new System.Drawing.Point(0, 0);
            this.dgvPerson.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPerson.MultiSelect = false;
            this.dgvPerson.Name = "dgvPerson";
            this.dgvPerson.ReadOnly = true;
            this.dgvPerson.RowHeadersVisible = false;
            this.dgvPerson.RowHeadersWidth = 51;
            this.dgvPerson.RowTemplate.Height = 31;
            this.dgvPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerson.Size = new System.Drawing.Size(804, 558);
            this.dgvPerson.TabIndex = 3;
            this.dgvPerson.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerson_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // Checked
            // 
            this.Checked.DataPropertyName = "Checked";
            this.Checked.HeaderText = "Chọn";
            this.Checked.MinimumWidth = 6;
            this.Checked.Name = "Checked";
            this.Checked.ReadOnly = true;
            this.Checked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Checked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Checked.ToolTipText = "Chọn để in";
            this.Checked.Width = 50;
            // 
            // SoNo
            // 
            this.SoNo.DataPropertyName = "SoNo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SoNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.SoNo.HeaderText = "Mã sớ";
            this.SoNo.MinimumWidth = 6;
            this.SoNo.Name = "SoNo";
            this.SoNo.ReadOnly = true;
            this.SoNo.Width = 45;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FullName.DataPropertyName = "FullName";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullName.DefaultCellStyle = dataGridViewCellStyle4;
            this.FullName.HeaderText = "Họ tên";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            // 
            // NamSinh
            // 
            this.NamSinh.DataPropertyName = "NamSinh";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamSinh.DefaultCellStyle = dataGridViewCellStyle5;
            this.NamSinh.HeaderText = "Năm sinh";
            this.NamSinh.MinimumWidth = 6;
            this.NamSinh.Name = "NamSinh";
            this.NamSinh.ReadOnly = true;
            this.NamSinh.Width = 85;
            // 
            // NgayMat
            // 
            this.NgayMat.DataPropertyName = "NgayMat";
            this.NgayMat.HeaderText = "Ngày mất";
            this.NgayMat.MinimumWidth = 6;
            this.NgayMat.Name = "NgayMat";
            this.NgayMat.ReadOnly = true;
            this.NgayMat.Width = 125;
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.MinimumWidth = 6;
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.ReadOnly = true;
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
            this.Address.ReadOnly = true;
            // 
            // toolTipCustom1
            // 
            this.toolTipCustom1.OwnerDraw = true;
            this.toolTipCustom1.ShowAlways = true;
            // 
            // FrmPersonSelectPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "FrmPersonSelectPrint";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn gia đình cần in";
            this.Load += new System.EventHandler(this.FrmPersonSelectPrint_Load);
            this.SizeChanged += new System.EventHandler(this.FrmPersonSelectPrint_SizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUpDTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x0400002F RID: 47
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.ToolStrip toolStrip1;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.ToolStripComboBox toolCbxChua;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.ToolStripTextBox toolTxtSearch;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.ToolStripButton toolBtnSearch;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.DataGridView dgvPerson;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000038 RID: 56
		private global::AppVietSo.ToolTipCustom toolTipCustom1;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Label lblTongLaSo;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.ToolStripButton toolBtnPrint;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.DataGridViewTextBoxColumn ID;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn Checked;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.DataGridViewTextBoxColumn SoNo;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FullName;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.DataGridViewTextBoxColumn NamSinh;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.DataGridViewTextBoxColumn NgayMat;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.DataGridViewComboBoxColumn GioiTinh;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Address;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.NumericUpDown nUpDTo;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.NumericUpDown nUpDFrom;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Label label1;
	}
}
