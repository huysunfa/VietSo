using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVietSo
{
	public partial class FrmHeaderFooter : Form
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00004AA0 File Offset: 0x00002CA0
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00004AB4 File Offset: 0x00002CB4
		public string PageTitleLeft { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00004AC8 File Offset: 0x00002CC8
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00004ADC File Offset: 0x00002CDC
		public string PageTitleCenter { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00004AF0 File Offset: 0x00002CF0
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00004B04 File Offset: 0x00002D04
		public string PageTitleRight { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00004B18 File Offset: 0x00002D18
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00004B2C File Offset: 0x00002D2C
		public bool IsFooter { get; set; }

		// Token: 0x0600006A RID: 106 RVA: 0x00004B40 File Offset: 0x00002D40
		public FrmHeaderFooter()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004B5C File Offset: 0x00002D5C
		private void FrmHeaderFooter_Load(object sender, EventArgs e)
		{
			try
			{
				this.txtLeft.Text = this.PageTitleLeft;
				this.txtCenter.Text = this.PageTitleCenter;
				this.txtRight.Text = this.PageTitleRight;
				if (this.IsFooter)
				{
					this.rbtnFooter.Checked = true;
				}
				else
				{
					this.rbtnHeader.Checked = true;
				}
			}
			catch (Exception exception_)
			{
 			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004BD8 File Offset: 0x00002DD8
		private void btnInsertPage_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.textBox_0 == null)
				{
					this.textBox_0 = this.txtLeft;
				}
				string text = this.textBox_0.Text;
				this.textBox_0.Text = text.Insert(this.textBox_0.SelectionStart, "&[Page]");
			}
			catch (Exception exception_)
			{
 			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00004C40 File Offset: 0x00002E40
		private void btnInsertPages_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.textBox_0 == null)
				{
					this.textBox_0 = this.txtLeft;
				}
				string text = this.textBox_0.Text;
				this.textBox_0.Text = text.Insert(this.textBox_0.SelectionStart, "&[Pages]");
			}
			catch (Exception exception_)
			{
 			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00004CA8 File Offset: 0x00002EA8
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				this.PageTitleLeft = this.txtLeft.Text;
				this.PageTitleCenter = this.txtCenter.Text;
				this.PageTitleRight = this.txtRight.Text;
				this.IsFooter = this.rbtnFooter.Checked;
				base.DialogResult = DialogResult.OK;
			}
			catch (Exception exception_)
			{
 			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00004D1C File Offset: 0x00002F1C
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00004D30 File Offset: 0x00002F30
		private void txtRight_Leave(object sender, EventArgs e)
		{
			this.textBox_0 = (sender as TextBox);
		}

		// Token: 0x0400002E RID: 46
 		private string string_0;

 		private string string_1;

		// Token: 0x04000030 RID: 48
		 
		private string string_2;

	 
		private bool bool_0;

		// Token: 0x04000032 RID: 50
		private TextBox textBox_0;
	}
}
