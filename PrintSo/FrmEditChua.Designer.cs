namespace PrintSo
{
	// Token: 0x0200000F RID: 15
	public partial class FrmEditChua : global::System.Windows.Forms.Form
	{
		// Token: 0x06000085 RID: 133 RVA: 0x0000A8A5 File Offset: 0x00008AA5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000A8C4 File Offset: 0x00008AC4
		private void InitializeComponent()
		{
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::PrintSo.FrmEditChua));
			this.dgvPagoda = new global::System.Windows.Forms.DataGridView();
			this.ID = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FullName = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Leader = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Address = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			((global::System.ComponentModel.ISupportInitialize)this.dgvPagoda).BeginInit();
			base.SuspendLayout();
			this.dgvPagoda.AllowUserToAddRows = false;
			this.dgvPagoda.AllowUserToDeleteRows = false;
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			dataGridViewCellStyle.BackColor = global::System.Drawing.SystemColors.Info;
			dataGridViewCellStyle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = global::System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPagoda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvPagoda.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPagoda.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.ID,
				this.FullName,
				this.Leader,
				this.Address
			});
			dataGridViewCellStyle2.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = global::System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = global::System.Windows.Forms.DataGridViewTriState.False;
			this.dgvPagoda.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvPagoda.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dgvPagoda.Location = new global::System.Drawing.Point(0, 0);
			this.dgvPagoda.MultiSelect = false;
			this.dgvPagoda.Name = "dgvPagoda";
			dataGridViewCellStyle3.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = global::System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = global::System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPagoda.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvPagoda.RowTemplate.Height = 31;
			this.dgvPagoda.Size = new global::System.Drawing.Size(727, 240);
			this.dgvPagoda.TabIndex = 4;
			this.dgvPagoda.CellBeginEdit += new global::System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPagoda_CellBeginEdit);
			this.dgvPagoda.CellEndEdit += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagoda_CellEndEdit);
			this.ID.DataPropertyName = "ID";
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.Visible = false;
			this.FullName.DataPropertyName = "Name";
			dataGridViewCellStyle4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.FullName.DefaultCellStyle = dataGridViewCellStyle4;
			this.FullName.HeaderText = "Tên Chùa";
			this.FullName.Name = "FullName";
			this.FullName.Width = 250;
			this.Leader.DataPropertyName = "Leader";
			dataGridViewCellStyle5.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Leader.DefaultCellStyle = dataGridViewCellStyle5;
			this.Leader.HeaderText = "Người Chụ Trì";
			this.Leader.Name = "Leader";
			this.Leader.Width = 200;
			this.Address.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Address.DataPropertyName = "Address";
			this.Address.HeaderText = "Địa chỉ";
			this.Address.Name = "Address";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(727, 240);
			base.Controls.Add(this.dgvPagoda);
 			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmEditChua";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sửa tên Chùa, Điện, Nơi cúng";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FrmEditChua_FormClosing);
			base.Load += new global::System.EventHandler(this.FrmEditChua_Load);
			((global::System.ComponentModel.ISupportInitialize)this.dgvPagoda).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400007F RID: 127
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.DataGridView dgvPagoda;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.DataGridViewTextBoxColumn ID;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.DataGridViewTextBoxColumn FullName;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Leader;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Address;
	}
}
