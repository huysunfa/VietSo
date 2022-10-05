using System;
using System.Windows.Forms;
using DataModel;

namespace PrintHelper
{
	// Token: 0x02000016 RID: 22
	public class Valid
	{
		// Token: 0x060001EA RID: 490 RVA: 0x00009730 File Offset: 0x00007930
		public bool Right(global::CustomerKey cusKey, global::System.Action refreshTitle, global::System.Windows.Forms.IWin32Window owner)
		{
			if (cusKey == null)
			{
				if (!this.RequestReg(cusKey, owner))
				{
					return false;
				}
				refreshTitle();
			}
			else
			{
				this.method_1(cusKey, refreshTitle, owner);
			}
			return this.method_0(cusKey, owner);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0000976C File Offset: 0x0000796C
		public bool RequestReg(global::CustomerKey cusKey, global::System.Windows.Forms.IWin32Window owner)
		{
			if (new global::PrintHelper.FrmKeyRequest(cusKey).ShowDialog(owner) != global::System.Windows.Forms.DialogResult.OK)
			{
				global::System.Windows.Forms.MessageBox.Show("Xin hãy 'Đăng ký dùng phần mềm' để có thể dùng chức năng này!", global::DataModel.Util.domain, global::System.Windows.Forms.MessageBoxButtons.OK, global::System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x000097A0 File Offset: 0x000079A0
		private bool method_0(global::CustomerKey customerKey_0, global::System.Windows.Forms.IWin32Window iwin32Window_0)
		{
			if (customerKey_0 == null)
			{
				return false;
			}
			if (!customerKey_0.Action.Contains("Hết hạn sử dụng"))
			{
				return true;
			}
			new global::PrintHelper.FrmPayInfo().ShowDialog(iwin32Window_0);
			return false;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000097D4 File Offset: 0x000079D4
		private void method_1(global::CustomerKey customerKey_0, global::System.Action action_0, global::System.Windows.Forms.IWin32Window iwin32Window_0)
		{
			if (customerKey_0.Action.Contains("LackInfo:"))
			{
				global::System.Windows.Forms.MessageBox.Show(customerKey_0.Action.Replace("LackInfo:", ""), global::DataModel.Util.domain, global::System.Windows.Forms.MessageBoxButtons.OK, global::System.Windows.Forms.MessageBoxIcon.Exclamation);
				if (new global::PrintHelper.FrmKeyRequest(customerKey_0).ShowDialog(iwin32Window_0) == global::System.Windows.Forms.DialogResult.OK)
				{
					action_0();
				}
			}
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00003D54 File Offset: 0x00001F54
		public Valid()
		{
		}
	}
}
