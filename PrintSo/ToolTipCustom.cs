using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PrintSo
{
	// Token: 0x02000019 RID: 25
	internal class ToolTipCustom : ToolTip
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
		private void OnPopup(object sender, PopupEventArgs e)
		{
			Size toolTipSize = e.ToolTipSize;
			toolTipSize.Height += 7;
			toolTipSize.Width += 16;
			e.ToolTipSize = toolTipSize;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0001867C File Offset: 0x0001687C
		private void OnDraw(object sender, DrawToolTipEventArgs e)
		{
			Graphics graphics = e.Graphics;
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Bounds, ColorTranslator.FromHtml("#ffd13c"), Color.MintCream, 45f);
			graphics.FillRectangle(linearGradientBrush, e.Bounds);
			graphics.DrawRectangle(new Pen(Brushes.Red, 1f), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
			graphics.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.Black, new PointF((float)(e.Bounds.X + 5), (float)(e.Bounds.Y + 5)));
			linearGradientBrush.Dispose();
		}

		// Token: 0x0400013D RID: 317
		public Size PopupSize = new Size(200, 100);
	}
}
