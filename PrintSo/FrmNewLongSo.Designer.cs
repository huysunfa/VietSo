namespace PrintSo
{
	// Token: 0x02000010 RID: 16
	public partial class FrmNewLongSo : global::System.Windows.Forms.Form
	{
		// Token: 0x0600008C RID: 140 RVA: 0x0000AF5C File Offset: 0x0000915C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000AF7C File Offset: 0x0000917C
		private void InitializeComponent()
		{
			this.btnSave = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtLongSoName = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.btnSave.BackColor = global::System.Drawing.Color.FromArgb(255, 128, 0);
			this.btnSave.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnSave.Location = new global::System.Drawing.Point(484, 169);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new global::System.Drawing.Size(101, 45);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Lưu";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new global::System.EventHandler(this.btnSave_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(153, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Tên Lòng sớ mới";
			this.txtLongSoName.Location = new global::System.Drawing.Point(173, 14);
			this.txtLongSoName.Name = "txtLongSoName";
			this.txtLongSoName.Size = new global::System.Drawing.Size(412, 28);
			this.txtLongSoName.TabIndex = 2;
			this.txtLongSoName.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.txtLongSoName_KeyDown);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(10f, 22f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(597, 226);
			base.Controls.Add(this.txtLongSoName);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnSave);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmNewLongSo";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Thêm lòng sớ";
			base.Load += new global::System.EventHandler(this.FrmNewLongSo_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000087 RID: 135
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.Button btnSave;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.TextBox txtLongSoName;
	}
}
