using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid.Print;

namespace AppVietSo.Models
{
    // Token: 0x0200001C RID: 28
    public static class ShareFun
    {

        // Token: 0x06000142 RID: 322 RVA: 0x00019260 File Offset: 0x00017460
        public static void SetWidthHeight2(this global::unvell.ReoGrid.Worksheet sheet, int row, int col)
        {
            float dpi = 100f;
            float dpi2 = 100f;
            double num = Util.LongSoHienTai.PageHeight;
            double num2 = Util.LongSoHienTai.PageWidth;
            float num3 = Util.InchToPixel(Util.LongSoHienTai.PagePaddingLeft, dpi);
            float num4 = Util.InchToPixel(Util.LongSoHienTai.PagePaddingRight, dpi);
            float num5 = Util.InchToPixel(Util.LongSoHienTai.PagePaddingTop, dpi2);
            float num6 = Util.InchToPixel(Util.LongSoHienTai.PagePaddingBottom, dpi2);
            double num7 = num - ((double)(num3 + num4) + (double)(num3 + num4) * 0.05);
            num2 -= (double)(num5 + num6);
            ushort height = (ushort)global::System.Math.Floor(num2 / (double)row);
            sheet.SetRowsHeight(0, sheet.RowCount, height);
            ushort width = (ushort)global::System.Math.Floor(num7 / (double)col);
            sheet.SetColumnsWidth(0, sheet.ColumnCount, width);
            sheet.ResetAllPageBreaks();
        }

        public static void SetWidthHeight(this unvell.ReoGrid.Worksheet sheet, int row, int col)
        {

            const float cmPreInch = 2.54f * 10;
            float dpi = 100f;
            double num = Util.LongSoHienTai.PageWidth;
            double num2 = Util.LongSoHienTai.PageHeight;
            float num3 = Util.LongSoHienTai.PagePaddingLeft;
            float num4 = Util.LongSoHienTai.PagePaddingRight;
            float num5 = Util.LongSoHienTai.PagePaddingTop;
            float num6 = Util.LongSoHienTai.PagePaddingBottom;
            double num7 = num - ((double)(num3 + num4) + (double)(num3 + num4) * 0.05);
            num2 -= (double)(num5 + num6);
            ushort height = (ushort)System.Math.Floor(num2 / (double)(row + 2));
            sheet.SetRows(row - 1);
            sheet.SetCols(col - 1);
            sheet.SetRowsHeight(0, sheet.RowCount, height);
            ushort width = (ushort)System.Math.Floor(num7 / (double)(col + 1));
            sheet.SetColumnsWidth(0, sheet.ColumnCount, width);
            //sheet.ResetAllPageBreaks();


            //    sheet.PrintSettings.Margins = new PageMargins(0,0,0,0);

            var PagePaddingTop = toMM((int)Util.LongSoHienTai.PagePaddingTop) / cmPreInch;
            var PagePaddingBottom = toMM((int)Util.LongSoHienTai.PagePaddingBottom) / cmPreInch;
            var PagePaddingLeft = toMM((int)Util.LongSoHienTai.PagePaddingLeft) / cmPreInch;
            var PagePaddingRight = toMM((int)Util.LongSoHienTai.PagePaddingRight) / cmPreInch;
            sheet.PrintSettings.Margins = new PageMargins(PagePaddingTop, PagePaddingBottom, PagePaddingLeft, PagePaddingRight);
            sheet.PrintSettings.PaperHeight = (int)Util.PixelToInch(Util.LongSoHienTai.PageWidth, dpi);
            sheet.PrintSettings.PaperWidth = (int)Util.PixelToInch(Util.LongSoHienTai.PageHeight, dpi);
        }

        // Token: 0x06000143 RID: 323 RVA: 0x00019367 File Offset: 0x00017567
        // Note: this type is marked as 'beforefieldinit'.


        // Token: 0x0400014A RID: 330
        public const decimal inchesTomm = 25.4m;

        public static int toMM(int i)
        {
            return (int)Math.Round((double)i / 100.0 * 25.4, 0);
        }
        public static int toPaperSize(decimal d)
        {
            return (int)Math.Round(d / 25.4m * 100m, 0);
        }

    }
}
