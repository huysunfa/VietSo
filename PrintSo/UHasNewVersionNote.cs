using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using DataModel;
using DataText;

namespace PrintSo
{
	// Token: 0x0200001B RID: 27
	public class UHasNewVersionNote : UserControl
	{
		// Token: 0x0600013B RID: 315 RVA: 0x00018D56 File Offset: 0x00016F56
		public UHasNewVersionNote()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00018D64 File Offset: 0x00016F64
		public void ShowNotification(string version)
		{
			this.version = version;
			base.Visible = true;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00018D74 File Offset: 0x00016F74
		public void FlashColor()
		{
			if (this.btnUpdate.BackColor == Color.Red)
			{
				this.btnUpdate.BackColor = Color.Yellow;
				return;
			}
			this.btnUpdate.BackColor = Color.Red;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00018DB0 File Offset: 0x00016FB0
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			FrmProgressOne frmProgressOne = new FrmProgressOne();
			try
			{
				string text = Util.getRunPath + "UpdateBibe.exe ";
				if (File.Exists(text))
				{
					frmProgressOne.Show();
					SynchronizeData.downloadUpdateCode(this.version, new SynchronizeData.UpdateProgressDelegate(frmProgressOne.setInfo));
					Process.Start(text);
					Form form = base.FindForm();
					form.Close();
					form.Dispose();
				}
				else
				{
					using (WebClient webClient = new WebClient())
					{
						string address = Util.mainURL + "DataOfUser/UpdateBibe.exe";
						webClient.DownloadFile(address, text);
					}
					if (File.Exists(text))
					{
						MessageBox.Show("Server đang bận. xin hãy update sau ít phút.", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Không tìm thấy tệp 'UpdateBibe.exe'. Xin vui lòng cài lại phần mềm.", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				frmProgressOne.Close();
				frmProgressOne.Dispose();
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00018ED0 File Offset: 0x000170D0
		private void linkLblView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(Util.mainURL + "cac-tinh-nang-moi-tren-phan-mem-viet-so-han-nom");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00018F2C File Offset: 0x0001712C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00018F4C File Offset: 0x0001714C
		private void InitializeComponent()
		{
			this.label1 = new Label();
			this.linkLblView = new LinkLabel();
			this.btnUpdate = new Button();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Dock = DockStyle.Left;
			this.label1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(0, 0);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(125, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Có phiên bản mới !";
			this.linkLblView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.linkLblView.AutoSize = true;
			this.linkLblView.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.linkLblView.Location = new Point(0, 24);
			this.linkLblView.Margin = new Padding(4, 0, 4, 0);
			this.linkLblView.Name = "linkLblView";
			this.linkLblView.Size = new Size(112, 17);
			this.linkLblView.TabIndex = 1;
			this.linkLblView.TabStop = true;
			this.linkLblView.Text = "Hãy ấn cập nhật";
			this.linkLblView.LinkClicked += this.linkLblView_LinkClicked;
			this.btnUpdate.AutoSize = true;
			this.btnUpdate.BackColor = Color.Red;
			this.btnUpdate.Dock = DockStyle.Right;
			this.btnUpdate.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.btnUpdate.ForeColor = Color.Black;
			this.btnUpdate.Location = new Point(147, 0);
			this.btnUpdate.Margin = new Padding(4);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new Size(90, 48);
			this.btnUpdate.TabIndex = 2;
			this.btnUpdate.Text = "Cập nhật";
			this.btnUpdate.UseVisualStyleBackColor = false;
			this.btnUpdate.Click += this.btnUpdate_Click;
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoSize = true;
			base.Controls.Add(this.btnUpdate);
			base.Controls.Add(this.linkLblView);
			base.Controls.Add(this.label1);
			this.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Margin = new Padding(0);
			base.Name = "UHasNewVersionNote";
			base.Size = new Size(237, 48);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000145 RID: 325
		private string version;

		// Token: 0x04000146 RID: 326
		private IContainer components;

		// Token: 0x04000147 RID: 327
		private Label label1;

		// Token: 0x04000148 RID: 328
		private LinkLabel linkLblView;

		// Token: 0x04000149 RID: 329
		private Button btnUpdate;
	}
}
