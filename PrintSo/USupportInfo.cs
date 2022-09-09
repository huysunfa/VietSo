using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DataModel;

namespace PrintSo
{
	// Token: 0x0200001A RID: 26
	public class USupportInfo : UserControl
	{
		// Token: 0x06000137 RID: 311 RVA: 0x0001875B File Offset: 0x0001695B
		public USupportInfo()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0001876C File Offset: 0x0001696C
		private void lkLblUtraView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				string text = "C:\\Program Files (x86)\\UltraViewer\\UltraViewer_Desktop.exe";
				if (!File.Exists(text))
				{
					text = "C:\\Program Files\\UltraViewer\\UltraViewer_Desktop.exe";
				}
				if (!File.Exists(text))
				{
					text = Util.getRunPath + "Connect\\UltraViewer.exe";
				}
				if (File.Exists(text))
				{
					Process.Start(text);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000187F0 File Offset: 0x000169F0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00018810 File Offset: 0x00016A10
		private void InitializeComponent()
		{
			this.lkLblUtraView = new LinkLabel();
			this.label5 = new Label();
			this.label3 = new Label();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label4 = new Label();
			base.SuspendLayout();
			this.lkLblUtraView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.lkLblUtraView.AutoSize = true;
			this.lkLblUtraView.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lkLblUtraView.Location = new Point(16, 182);
			this.lkLblUtraView.Margin = new Padding(5, 0, 5, 0);
			this.lkLblUtraView.Name = "lkLblUtraView";
			this.lkLblUtraView.Size = new Size(85, 18);
			this.lkLblUtraView.TabIndex = 12;
			this.lkLblUtraView.TabStop = true;
			this.lkLblUtraView.Text = "Hỗ trợ từ xa";
			this.lkLblUtraView.LinkClicked += this.lkLblUtraView_LinkClicked;
			this.label5.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.ForeColor = Color.Red;
			this.label5.Location = new Point(5, 154);
			this.label5.Margin = new Padding(5, 0, 5, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(107, 20);
			this.label5.TabIndex = 11;
			this.label5.Text = "098 3062 116";
			this.label3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Red;
			this.label3.Location = new Point(5, 124);
			this.label3.Margin = new Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(107, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "098 2116 022";
			this.label1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(5, 97);
			this.label1.Margin = new Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(174, 18);
			this.label1.TabIndex = 7;
			this.label1.Text = "Hỗ trợ phần mềm xin gọi:";
			this.label2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.ForeColor = Color.Green;
			this.label2.Location = new Point(5, 14);
			this.label2.Margin = new Padding(5, 0, 5, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(142, 36);
			this.label2.TabIndex = 13;
			this.label2.Text = "Cung cấp kinh sách,\r\nvật phẩm tín ngưỡng";
			this.label4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(27, 62);
			this.label4.Margin = new Padding(5, 0, 5, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(99, 20);
			this.label4.TabIndex = 14;
			this.label4.Text = "0368570292";
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.lkLblUtraView);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			this.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Margin = new Padding(5);
			base.Name = "USupportInfo";
			base.Size = new Size(230, 214);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400013E RID: 318
		private IContainer components;

		// Token: 0x0400013F RID: 319
		private LinkLabel lkLblUtraView;

		// Token: 0x04000140 RID: 320
		private Label label5;

		// Token: 0x04000141 RID: 321
		private Label label3;

		// Token: 0x04000142 RID: 322
		private Label label1;

		// Token: 0x04000143 RID: 323
		private Label label2;

		// Token: 0x04000144 RID: 324
		private Label label4;
	}
}
