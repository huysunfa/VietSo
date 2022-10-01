﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid;
using unvell.ReoGrid.Print;

namespace AppVietSo.Models
{
    // Token: 0x0200001C RID: 28
    public static class ShareFun
    {

        // Token: 0x06000142 RID: 322 RVA: 0x00019260 File Offset: 0x00017460
        public static void SetWidthHeightBibe(global::unvell.ReoGrid.Worksheet sheet, int row, int col)
        {
            float dpi = 100f;
            float dpi2 = 100f;
            double num =  Util.InchToPixel(sheet.PrintSettings.PaperHeight, dpi);
            double num2 =  Util.InchToPixel(sheet.PrintSettings.PaperWidth, dpi2);
            float num3 = Util.InchToPixel(sheet.PrintSettings.Margins.Left, dpi);
            float num4 = Util.InchToPixel(sheet.PrintSettings.Margins.Right, dpi);
            float num5 = Util.InchToPixel(sheet.PrintSettings.Margins.Top, dpi2);
            float num6 = Util.InchToPixel(sheet.PrintSettings.Margins.Bottom, dpi2);
            double num7 = num - ((double)(num3 + num4) + (double)(num3 + num4) * 0.05);
            num2 -= (double)(num5 + num6);
            ushort height = (ushort)global::System.Math.Floor(num2 / (double)row);
            sheet.SetRowsHeight(0, sheet.RowCount, height);
            ushort width = (ushort)global::System.Math.Floor(num7 / (double)col);
            sheet.SetColumnsWidth(0, sheet.ColumnCount, width);
            sheet.ResetAllPageBreaks();
        }

        public static void SetRowCol(this unvell.ReoGrid.Worksheet sheet, int row, int col)
        {

            try
            {
                if (sheet.UsedRange.EndCol > 0)
                {
                    sheet.DeleteColumns(0, sheet.UsedRange.EndCol);
                    sheet.DeleteRows(0, sheet.UsedRange.EndRow);
                }
                sheet.SetRows(row);
                sheet.SetCols(col);
                sheet.SetWidthHeight(row, col);
            }
            catch (Exception ex)
            {

               
            }
        }

        public static void SetWidthHeight(this unvell.ReoGrid.Worksheet sheet, int row, int col)
        {

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

            sheet.SetRowsHeight(1, row - 1, height);
            ushort width = (ushort)System.Math.Floor(num7 / (double)(col + 1));
            sheet.SetColumnsWidth(1, col - 1, width);
            // margrin
            var heightFree = 0; //Util.LongSoHienTai.PageHeight - (num5 + num6+(height * (row -2)));
            var weightFree = 0;// Util.LongSoHienTai.PageWidth - (num3 + num4 + (width * (col - 2)));
            weightFree = weightFree < 0 ? 0 : weightFree;
            heightFree = heightFree < 0 ? 0 : heightFree;
            sheet.SetColumnsWidth(0, 1, (ushort)(num3+ weightFree));
            sheet.SetColumnsWidth(sheet.UsedRange.EndCol, 1, (ushort)(num4));
            sheet.SetRowsHeight(0, 1, (ushort)(num5+ heightFree));
            sheet.SetRowsHeight(sheet.UsedRange.EndRow, 1, (ushort)(num6));

     
            sheet.PrintSettings.Margins = new PageMargins(0);
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
