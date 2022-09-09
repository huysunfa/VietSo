namespace PrintSo
{
	// Token: 0x02000005 RID: 5
	public partial class FrmNgachSo : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000043F0 File Offset: 0x000025F0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00004410 File Offset: 0x00002610
		private void InitializeComponent()
		{
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new global::System.Windows.Forms.DataGridViewCellStyle();
			this.dgvNgS = new global::System.Windows.Forms.DataGridView();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.NgSChecked = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.NgSName = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NgSContent = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			((global::System.ComponentModel.ISupportInitialize)this.dgvNgS).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			base.SuspendLayout();
			this.dgvNgS.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvNgS.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvNgS.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.NgSChecked,
				this.NgSName,
				this.NgSContent
			});
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = global::System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.dgvNgS.DefaultCellStyle = dataGridViewCellStyle;
			this.dgvNgS.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dgvNgS.Location = new global::System.Drawing.Point(0, 0);
			this.dgvNgS.Name = "dgvNgS";
			this.dgvNgS.RowTemplate.Height = 24;
			this.dgvNgS.Size = new global::System.Drawing.Size(1152, 489);
			this.dgvNgS.TabIndex = 0;
			this.dgvNgS.CellContentClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNgS_CellContentClick);
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.Controls.Add(this.btnClose);
			this.splitContainer1.Panel2.Controls.Add(this.dgvNgS);
			this.splitContainer1.Size = new global::System.Drawing.Size(1152, 535);
			this.splitContainer1.SplitterDistance = 42;
			this.splitContainer1.TabIndex = 1;
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.BackColor = global::System.Drawing.Color.FromArgb(255, 128, 0);
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.Location = new global::System.Drawing.Point(1063, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(86, 35);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Ok";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.NgSChecked.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.NgSChecked.DataPropertyName = "NgSChecked";
			this.NgSChecked.HeaderText = "Chọn";
			this.NgSChecked.Name = "NgSChecked";
			this.NgSChecked.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.NgSChecked.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.NgSChecked.Width = 60;
			this.NgSName.DataPropertyName = "NgSName";
			dataGridViewCellStyle2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.NgSName.DefaultCellStyle = dataGridViewCellStyle2;
			this.NgSName.HeaderText = "Tên";
			this.NgSName.Name = "NgSName";
			this.NgSName.Width = 200;
			this.NgSContent.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.NgSContent.DataPropertyName = "NgSContent";
			dataGridViewCellStyle3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.NgSContent.DefaultCellStyle = dataGridViewCellStyle3;
			this.NgSContent.HeaderText = "Nội dung";
			this.NgSContent.Name = "NgSContent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1152, 535);
			base.Controls.Add(this.splitContainer1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmNgachSo";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ngạch sớ";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FrmNgachSo_FormClosing);
			base.Load += new global::System.EventHandler(this.FrmNgachSo_Load);
			((global::System.ComponentModel.ISupportInitialize)this.dgvNgS).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400001F RID: 31
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.DataGridView dgvNgS;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn NgSChecked;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.DataGridViewTextBoxColumn NgSName;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.DataGridViewTextBoxColumn NgSContent;
	}
}
