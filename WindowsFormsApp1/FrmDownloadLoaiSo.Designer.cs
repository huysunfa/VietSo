namespace WindowsFormsApp1
{
	// Token: 0x0200000E RID: 14
	public partial class FrmDownloadLoaiSo : global::System.Windows.Forms.Form
	{
		// Token: 0x0600007C RID: 124 RVA: 0x000098FA File Offset: 0x00007AFA
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000991C File Offset: 0x00007B1C
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLongSo = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiSo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuGiai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvParent = new System.Windows.Forms.DataGridView();
            this.LoaiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblSuggestInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLongSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLongSo
            // 
            this.dgvLongSo.AllowUserToAddRows = false;
            this.dgvLongSo.AllowUserToDeleteRows = false;
            this.dgvLongSo.AllowUserToResizeRows = false;
            this.dgvLongSo.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLongSo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLongSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLongSo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.LoaiSo1,
            this.FileName,
            this.TenSo,
            this.ChuGiai,
            this.btnAction});
            this.dgvLongSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLongSo.Location = new System.Drawing.Point(0, 0);
            this.dgvLongSo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgvLongSo.MultiSelect = false;
            this.dgvLongSo.Name = "dgvLongSo";
            this.dgvLongSo.ReadOnly = true;
            this.dgvLongSo.RowHeadersVisible = false;
            this.dgvLongSo.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLongSo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLongSo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLongSo.RowTemplate.Height = 40;
            this.dgvLongSo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLongSo.Size = new System.Drawing.Size(779, 611);
            this.dgvLongSo.TabIndex = 1;
            this.dgvLongSo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLongSo_CellContentClick);
            this.dgvLongSo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLongSo_CellMouseDoubleClick);
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
            // LoaiSo1
            // 
            this.LoaiSo1.DataPropertyName = "LoaiSo1";
            this.LoaiSo1.HeaderText = "LoaiSo1";
            this.LoaiSo1.MinimumWidth = 6;
            this.LoaiSo1.Name = "LoaiSo1";
            this.LoaiSo1.ReadOnly = true;
            this.LoaiSo1.Visible = false;
            this.LoaiSo1.Width = 125;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "FileName";
            this.FileName.MinimumWidth = 6;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Visible = false;
            this.FileName.Width = 125;
            // 
            // TenSo
            // 
            this.TenSo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenSo.DataPropertyName = "TenSo";
            this.TenSo.HeaderText = "Lòng Sớ";
            this.TenSo.MinimumWidth = 6;
            this.TenSo.Name = "TenSo";
            this.TenSo.ReadOnly = true;
            this.TenSo.Width = 89;
            // 
            // ChuGiai
            // 
            this.ChuGiai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChuGiai.DataPropertyName = "ChuGiai";
            this.ChuGiai.HeaderText = "Chú giải";
            this.ChuGiai.MinimumWidth = 6;
            this.ChuGiai.Name = "ChuGiai";
            this.ChuGiai.ReadOnly = true;
            // 
            // btnAction
            // 
            this.btnAction.DataPropertyName = "btnAction";
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAction.HeaderText = "";
            this.btnAction.MinimumWidth = 6;
            this.btnAction.Name = "btnAction";
            this.btnAction.ReadOnly = true;
            this.btnAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnAction.Text = "Tải về";
            this.btnAction.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 214);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = ">>";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Gold;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(685, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "OK";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvParent
            // 
            this.dgvParent.AllowUserToAddRows = false;
            this.dgvParent.AllowUserToDeleteRows = false;
            this.dgvParent.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoaiSo});
            this.dgvParent.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvParent.Location = new System.Drawing.Point(0, 0);
            this.dgvParent.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgvParent.Name = "dgvParent";
            this.dgvParent.ReadOnly = true;
            this.dgvParent.RowHeadersVisible = false;
            this.dgvParent.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvParent.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvParent.RowTemplate.Height = 35;
            this.dgvParent.Size = new System.Drawing.Size(208, 691);
            this.dgvParent.TabIndex = 4;
            this.dgvParent.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParent_CellEnter);
            // 
            // LoaiSo
            // 
            this.LoaiSo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LoaiSo.DataPropertyName = "LoaiSo";
            this.LoaiSo.HeaderText = "Loại sớ";
            this.LoaiSo.MinimumWidth = 6;
            this.LoaiSo.Name = "LoaiSo";
            this.LoaiSo.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nhập tên lòng sớ muốn tìm";
            // 
            // txt
            // 
            this.txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.Location = new System.Drawing.Point(202, 14);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(373, 30);
            this.txt.TabIndex = 6;
            this.txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(581, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 33);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer1.Location = new System.Drawing.Point(265, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblSuggestInfo);
            this.splitContainer1.Panel1.Controls.Add(this.txt);
            this.splitContainer1.Panel1.Controls.Add(this.btnFind);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvLongSo);
            this.splitContainer1.Size = new System.Drawing.Size(779, 691);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 8;
            // 
            // lblSuggestInfo
            // 
            this.lblSuggestInfo.AutoSize = true;
            this.lblSuggestInfo.BackColor = System.Drawing.Color.Yellow;
            this.lblSuggestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuggestInfo.ForeColor = System.Drawing.Color.Black;
            this.lblSuggestInfo.Location = new System.Drawing.Point(28, 48);
            this.lblSuggestInfo.Name = "lblSuggestInfo";
            this.lblSuggestInfo.Size = new System.Drawing.Size(628, 22);
            this.lblSuggestInfo.TabIndex = 8;
            this.lblSuggestInfo.Text = "Nếu tìm không thấy thì chỉ nhập 1 chữ vì có thể khác tên, chỉ trùng nhau 1 chữ";
            this.lblSuggestInfo.Visible = false;
            // 
            // FrmDownloadLoaiSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 691);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.dgvParent);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDownloadLoaiSo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn loại sớ";
            this.Load += new System.EventHandler(this.FrmDownloadLoaiSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLongSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParent)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x0400006C RID: 108
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.DataGridView dgvLongSo;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.DataGridView dgvParent;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.DataGridViewTextBoxColumn LoaiSo;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.TextBox txt;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.Button btnFind;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x0400007C RID: 124
		private global::System.Windows.Forms.Label lblSuggestInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiSo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChuGiai;
        private System.Windows.Forms.DataGridViewButtonColumn btnAction;
    }
}
