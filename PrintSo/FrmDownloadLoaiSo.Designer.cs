namespace PrintSo
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
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::PrintSo.FrmDownloadLoaiSo));
			this.dgvLongSo = new global::System.Windows.Forms.DataGridView();
			this.ID = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LoaiSo1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FileName = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TenSo = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ChuGiai = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnAction = new global::System.Windows.Forms.DataGridViewButtonColumn();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.dgvParent = new global::System.Windows.Forms.DataGridView();
			this.LoaiSo = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label2 = new global::System.Windows.Forms.Label();
			this.txt = new global::System.Windows.Forms.TextBox();
			this.btnFind = new global::System.Windows.Forms.Button();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.lblSuggestInfo = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.dgvLongSo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dgvParent).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			base.SuspendLayout();
			this.dgvLongSo.AllowUserToAddRows = false;
			this.dgvLongSo.AllowUserToDeleteRows = false;
			this.dgvLongSo.AllowUserToResizeRows = false;
			this.dgvLongSo.BackgroundColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = global::System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = global::System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.dgvLongSo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvLongSo.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLongSo.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.ID,
				this.LoaiSo1,
				this.FileName,
				this.TenSo,
				this.ChuGiai,
				this.btnAction
			});
			this.dgvLongSo.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dgvLongSo.Location = new global::System.Drawing.Point(0, 0);
			this.dgvLongSo.Margin = new global::System.Windows.Forms.Padding(5, 6, 5, 6);
			this.dgvLongSo.MultiSelect = false;
			this.dgvLongSo.Name = "dgvLongSo";
			this.dgvLongSo.ReadOnly = true;
			this.dgvLongSo.RowHeadersVisible = false;
			dataGridViewCellStyle2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dgvLongSo.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvLongSo.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 15.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dgvLongSo.RowTemplate.Height = 40;
			this.dgvLongSo.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvLongSo.Size = new global::System.Drawing.Size(779, 611);
			this.dgvLongSo.TabIndex = 1;
			this.dgvLongSo.CellContentClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLongSo_CellContentClick);
			this.dgvLongSo.CellMouseDoubleClick += new global::System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLongSo_CellMouseDoubleClick);
			this.ID.DataPropertyName = "ID";
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Visible = false;
			this.LoaiSo1.DataPropertyName = "LoaiSo1";
			this.LoaiSo1.HeaderText = "LoaiSo1";
			this.LoaiSo1.Name = "LoaiSo1";
			this.LoaiSo1.ReadOnly = true;
			this.LoaiSo1.Visible = false;
			this.FileName.DataPropertyName = "FileName";
			this.FileName.HeaderText = "FileName";
			this.FileName.Name = "FileName";
			this.FileName.ReadOnly = true;
			this.FileName.Visible = false;
			this.TenSo.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.TenSo.DataPropertyName = "TenSo";
			this.TenSo.HeaderText = "Lòng Sớ";
			this.TenSo.Name = "TenSo";
			this.TenSo.ReadOnly = true;
			this.TenSo.Width = 89;
			this.ChuGiai.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ChuGiai.DataPropertyName = "ChuGiai";
			this.ChuGiai.HeaderText = "Chú giải";
			this.ChuGiai.Name = "ChuGiai";
			this.ChuGiai.ReadOnly = true;
			this.btnAction.DataPropertyName = "btnAction";
			this.btnAction.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.btnAction.HeaderText = "";
			this.btnAction.Name = "btnAction";
			this.btnAction.ReadOnly = true;
			this.btnAction.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.btnAction.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.btnAction.Width = 70;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 16f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(217, 214);
			this.label1.Margin = new global::System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(38, 26);
			this.label1.TabIndex = 2;
			this.label1.Text = ">>";
			this.btnClose.BackColor = global::System.Drawing.Color.Gold;
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.Location = new global::System.Drawing.Point(685, 5);
			this.btnClose.Margin = new global::System.Windows.Forms.Padding(5, 6, 5, 6);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(80, 40);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "OK";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.dgvParent.AllowUserToAddRows = false;
			this.dgvParent.AllowUserToDeleteRows = false;
			this.dgvParent.BackgroundColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = global::System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = global::System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.dgvParent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvParent.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvParent.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.LoaiSo
			});
			this.dgvParent.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.dgvParent.Location = new global::System.Drawing.Point(0, 0);
			this.dgvParent.Margin = new global::System.Windows.Forms.Padding(5, 6, 5, 6);
			this.dgvParent.Name = "dgvParent";
			this.dgvParent.ReadOnly = true;
			this.dgvParent.RowHeadersVisible = false;
			dataGridViewCellStyle4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.dgvParent.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvParent.RowTemplate.Height = 35;
			this.dgvParent.Size = new global::System.Drawing.Size(208, 691);
			this.dgvParent.TabIndex = 4;
			this.dgvParent.CellEnter += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParent_CellEnter);
			this.LoaiSo.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.LoaiSo.DataPropertyName = "LoaiSo";
			this.LoaiSo.HeaderText = "Loại sớ";
			this.LoaiSo.Name = "LoaiSo";
			this.LoaiSo.ReadOnly = true;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(2, 19);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(198, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Nhập tên lòng sớ muốn tìm";
			this.txt.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 15f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txt.Location = new global::System.Drawing.Point(202, 14);
			this.txt.Name = "txt";
			this.txt.Size = new global::System.Drawing.Size(373, 30);
			this.txt.TabIndex = 6;
			this.txt.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
			this.btnFind.Location = new global::System.Drawing.Point(581, 12);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new global::System.Drawing.Size(75, 33);
			this.btnFind.TabIndex = 7;
			this.btnFind.Text = "Tìm";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new global::System.EventHandler(this.btnFind_Click);
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.splitContainer1.Location = new global::System.Drawing.Point(265, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.Controls.Add(this.lblSuggestInfo);
			this.splitContainer1.Panel1.Controls.Add(this.txt);
			this.splitContainer1.Panel1.Controls.Add(this.btnFind);
			this.splitContainer1.Panel1.Controls.Add(this.btnClose);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.dgvLongSo);
			this.splitContainer1.Size = new global::System.Drawing.Size(779, 691);
			this.splitContainer1.SplitterDistance = 76;
			this.splitContainer1.TabIndex = 8;
			this.lblSuggestInfo.AutoSize = true;
			this.lblSuggestInfo.BackColor = global::System.Drawing.Color.Yellow;
			this.lblSuggestInfo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 13f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblSuggestInfo.ForeColor = global::System.Drawing.Color.Black;
			this.lblSuggestInfo.Location = new global::System.Drawing.Point(28, 48);
			this.lblSuggestInfo.Name = "lblSuggestInfo";
			this.lblSuggestInfo.Size = new global::System.Drawing.Size(628, 22);
			this.lblSuggestInfo.TabIndex = 8;
			this.lblSuggestInfo.Text = "Nếu tìm không thấy thì chỉ nhập 1 chữ vì có thể khác tên, chỉ trùng nhau 1 chữ";
			this.lblSuggestInfo.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 18f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1044, 691);
			base.Controls.Add(this.splitContainer1);
			base.Controls.Add(this.dgvParent);
			base.Controls.Add(this.label1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			//base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmDownloadLoaiSo";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Chọn loại sớ";
			base.Load += new global::System.EventHandler(this.FrmDownloadLoaiSo_Load);
			((global::System.ComponentModel.ISupportInitialize)this.dgvLongSo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dgvParent).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
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

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.DataGridViewTextBoxColumn ID;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.DataGridViewTextBoxColumn LoaiSo1;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FileName;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TenSo;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.DataGridViewTextBoxColumn ChuGiai;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.DataGridViewButtonColumn btnAction;

		// Token: 0x0400007C RID: 124
		private global::System.Windows.Forms.Label lblSuggestInfo;
	}
}
