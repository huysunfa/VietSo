namespace PrintSo
{
	// Token: 0x02000009 RID: 9
	public partial class FrmPrintNo : global::System.Windows.Forms.Form
	{
		// Token: 0x0600004B RID: 75 RVA: 0x000065B4 File Offset: 0x000047B4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000065D4 File Offset: 0x000047D4
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.nUpDown = new global::System.Windows.Forms.NumericUpDown();
			((global::System.ComponentModel.ISupportInitialize)this.nUpDown).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(11, 22);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(68, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Số bản in";
			this.btnPrint.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnPrint.Location = new global::System.Drawing.Point(261, 12);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(162, 36);
			this.btnPrint.TabIndex = 2;
			this.btnPrint.Text = "Print (in)";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			this.nUpDown.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nUpDown.Location = new global::System.Drawing.Point(112, 18);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.nUpDown;
			int[] array = new int[4];
			array[0] = 1000;
			//numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.nUpDown;
			int[] array2 = new int[4];
			array2[0] = 1;
			//numericUpDown2.Minimum = new decimal(array2);
			this.nUpDown.Name = "nUpDown";
			this.nUpDown.Size = new global::System.Drawing.Size(100, 24);
			this.nUpDown.TabIndex = 1;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.nUpDown;
			int[] array3 = new int[4];
			array3[0] = 1;
			//numericUpDown3.Value = new decimal(array3);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(455, 58);
			base.Controls.Add(this.nUpDown);
			base.Controls.Add(this.btnPrint);
			base.Controls.Add(this.label1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FrmPrintNo";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nhập số bản in";
			base.Load += new global::System.EventHandler(this.FrmPrintNo_Load);
			((global::System.ComponentModel.ISupportInitialize)this.nUpDown).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400004A RID: 74
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.Button btnPrint;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.NumericUpDown nUpDown;
	}
}
