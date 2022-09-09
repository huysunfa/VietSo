using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrintSo
{
	// Token: 0x02000017 RID: 23
	public class PanelBibe : Panel
	{
		// Token: 0x06000130 RID: 304 RVA: 0x00018578 File Offset: 0x00016778
		protected override Point ScrollToControl(Control activeControl)
		{
			return this.DisplayRectangle.Location;
		}
	}
}
