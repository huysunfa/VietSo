using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo
{
	internal class ToolTipCustom : global::System.Windows.Forms.ToolTip
	{
		// Token: 0x06000134 RID: 308 RVA: 0x000185E8 File Offset: 0x000167E8
		public ToolTipCustom()
		{
			base.OwnerDraw = true;
			base.ShowAlways = true;
			base.Popup += this.OnPopup;
			base.Draw += this.OnDraw;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00018640 File Offset: 0x00016840
		private void OnPopup(object sender, global::System.Windows.Forms.PopupEventArgs e)
		{
			global::System.Drawing.Size toolTipSize = e.ToolTipSize;
			toolTipSize.Height += 7;
			toolTipSize.Width += 0x10;
			e.ToolTipSize = toolTipSize;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0001867C File Offset: 0x0001687C
		private void OnDraw(object sender, global::System.Windows.Forms.DrawToolTipEventArgs e)
		{
			global::System.Drawing.Graphics graphics = e.Graphics;
			global::System.Drawing.Drawing2D.LinearGradientBrush linearGradientBrush = new global::System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, global::System.Drawing.ColorTranslator.FromHtml("#ffd13c"), global::System.Drawing.Color.MintCream, 45f);
			graphics.FillRectangle(linearGradientBrush, e.Bounds);
			graphics.DrawRectangle(new global::System.Drawing.Pen(global::System.Drawing.Brushes.Red, 1f), new global::System.Drawing.Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
			graphics.DrawString(e.ToolTipText, new global::System.Drawing.Font(e.Font, global::System.Drawing.FontStyle.Bold), global::System.Drawing.Brushes.Black, new global::System.Drawing.PointF((float)(e.Bounds.X + 5), (float)(e.Bounds.Y + 5)));
			linearGradientBrush.Dispose();
		}

		// Token: 0x0400013D RID: 317
		public global::System.Drawing.Size PopupSize = new global::System.Drawing.Size(0xC8, 0x64);
	}
}
