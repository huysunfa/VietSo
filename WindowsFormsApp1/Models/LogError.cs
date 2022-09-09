

using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Models
{
	public class LogError
	{
		// Token: 0x0600006E RID: 110 RVA: 0x00008F5E File Offset: 0x0000715E
		public static void show(Exception ex)
		{
			MessageBox.Show("Xảy ra lỗi, xin gọi tới số 098 2116 022 - 098 306 2116" + Environment.NewLine + ex.Message, Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}
}
