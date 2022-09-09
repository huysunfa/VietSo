using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DataText;

namespace PrintSo
{
	// Token: 0x02000018 RID: 24
	internal static class Program
	{
		// Token: 0x06000132 RID: 306 RVA: 0x0001859C File Offset: 0x0001679C
		[STAThread]
		private static void Main()
		{
			if (ApplicationRunningHelper.AlreadyRunning())
			{
				return;
			}
			Program.Stg = UserSetting.Load();
			if (Environment.OSVersion.Version.Major >= 6)
			{
				Program.SetProcessDPIAware();
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmPreview());
		}

		// Token: 0x06000133 RID: 307
		[DllImport("user32.dll")]
		private static extern bool SetProcessDPIAware();

		// Token: 0x0400013C RID: 316
		public static UserSetting Stg;
	}
}
