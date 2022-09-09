using System;
using DataModel;
using unvell.ReoGrid;

namespace PrintSo
{
	// Token: 0x0200001C RID: 28
	public static class ShareFun
	{
		// Token: 0x06000142 RID: 322 RVA: 0x00019260 File Offset: 0x00017460
		public static void SetWidthHeight(Worksheet sheet, int row, int col)
		{
			float dpi = 100f;
			float dpi2 = 100f;
			double num = (double)Util.InchToPixel(sheet.PrintSettings.PaperHeight, dpi);
			double num2 = (double)Util.InchToPixel(sheet.PrintSettings.PaperWidth, dpi2);
			float num3 = Util.InchToPixel(sheet.PrintSettings.Margins.Left, dpi);
			float num4 = Util.InchToPixel(sheet.PrintSettings.Margins.Right, dpi);
			float num5 = Util.InchToPixel(sheet.PrintSettings.Margins.Top, dpi2);
			float num6 = Util.InchToPixel(sheet.PrintSettings.Margins.Bottom, dpi2);
			double num7 = num - ((double)(num3 + num4) + (double)(num3 + num4) * 0.05);
			num2 -= (double)(num5 + num6);
			ushort height = (ushort)Math.Floor(num2 / (double)row);
			sheet.SetRowsHeight(0, sheet.RowCount, height);
			ushort width = (ushort)Math.Floor(num7 / (double)col);
			sheet.SetColumnsWidth(0, sheet.ColumnCount, width);
			sheet.ResetAllPageBreaks();
		}

		// Token: 0x0400014A RID: 330
		public const decimal inchesTomm = 25.4m;
	}
}
