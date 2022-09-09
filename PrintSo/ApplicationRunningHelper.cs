using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PrintSo
{
	// Token: 0x02000003 RID: 3
	public static class ApplicationRunningHelper
	{
		// Token: 0x06000007 RID: 7
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x06000008 RID: 8
		[DllImport("user32.dll")]
		private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

		// Token: 0x06000009 RID: 9
		[DllImport("user32.dll")]
		private static extern bool IsIconic(IntPtr hWnd);

		// Token: 0x0600000A RID: 10 RVA: 0x0000216C File Offset: 0x0000036C
		public static bool AlreadyRunning()
		{
			Process currentProcess = Process.GetCurrentProcess();
			Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
			if (processesByName.Length > 1)
			{
				for (int i = 0; i < processesByName.Length; i++)
				{
					if (processesByName[i].Id != currentProcess.Id)
					{
						IntPtr mainWindowHandle = processesByName[i].MainWindowHandle;
						if (ApplicationRunningHelper.IsIconic(mainWindowHandle))
						{
							ApplicationRunningHelper.ShowWindowAsync(mainWindowHandle, 9);
						}
						ApplicationRunningHelper.SetForegroundWindow(mainWindowHandle);
						break;
					}
				}
				return true;
			}
			return false;
		}
	}
}
