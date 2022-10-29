using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid;

namespace AppVietSo
{
    public static class ReoGridExtentions
    {
        public static void ShowBolder(this ReoGridControl reoGridControl1, bool show = true)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            worksheet.SetRangeBorders(worksheet.UsedRange, BorderPositions.All,
                               new unvell.ReoGrid.RangeBorderStyle { Style = BorderLineStyle.None });

            if (show)
            {
                var rangedata = new RangePosition(
                    worksheet.UsedRange.Row + 1
                    , worksheet.UsedRange.Col + 1
                    , worksheet.UsedRange.EndRow - 1
                    , worksheet.UsedRange.EndCol - 1
                    );

                worksheet.SetRangeBorders(rangedata, BorderPositions.All,
                                     new unvell.ReoGrid.RangeBorderStyle
                                     {
                                         Style = BorderLineStyle.Solid,
                                         Color = Color.WhiteSmoke
                                     });
            }
        }
        public static void ChangeWidthSize(this Worksheet sheet, bool check)
        {
            //if (Util.LongSoHienTai.KhoaCung)
            //{
            //    return;
            //}
            for (int i = 1; i < sheet.RowCount; i++)
            {
                sheet.RowHeaders[i].IsAutoHeight = check;

            }
            for (int i = 1; i < sheet.ColumnCount; i++)
            {
                sheet.ColumnHeaders[i].IsAutoWidth = check;

            }
            if (check == false)
            {
                return;
            }
 
            int TotalWidth = 0;
            for (int i = 1; i < sheet.ColumnCount; i++)
            {
                var oldW = sheet.GetColumnWidth(i);
                sheet.AutoFitColumnWidth(i, check);

                var newW = sheet.GetColumnWidth(i);

                if (newW < oldW)
                {
                    newW = oldW;
                    sheet.SetColumnsWidth(i, 1, oldW);

                }
                TotalWidth += newW;
            }
            //int TotalHeight = 0;
            //for (int i = 1; i < sheet.RowCount; i = i + 1)
            //{
            //    var oldW = sheet.GetRowHeight(i);
            //    sheet.AutoFitRowHeight(i, check);
            //    var newW = sheet.GetRowHeight(i);
            //    if (newW < oldW)
            //    {
            //        newW = oldW;
            //        sheet.SetRowsHeight(i, 1, oldW);

            //    }
            //    TotalHeight += newW;

            //}
            var tile = (float)TotalWidth / (float)Util.LongSoHienTai.PageWidth;
            var TotalHeight = (float)Util.LongSoHienTai.PageHeight * tile;
            int row = (sheet.UsedRange.EndRow - 2);
            var old = TotalHeight / row;
            sheet.SetRowsHeight(1, row, (ushort)old);

            var free = TotalHeight - (row * (int)old);
            var colend = (ushort)(sheet.GetRowHeight(row + 2) + free);
            sheet.SetRowsHeight(row + 1, 1, colend);

        }
        public static void PreView(this ReoGridControl reoGrid, object sender = null, EventArgs e = null)
        {
            //      LoadDataToDataGrid(reoGrid);

        }
        //   public static void SetOnePage(this Worksheet worksheet)
        //{
        //    worksheet.ResetAllPageBreaks();
        //    var MaxRow = worksheet.RowPageBreaks.Max(v => v);
        //    var MinRow = worksheet.RowPageBreaks.Min(v => v);
        //    foreach (var item in worksheet.RowPageBreaks.ToList())
        //    {
        //        if (item == MaxRow || item == MinRow)
        //        {
        //            continue;
        //        }

        //        if (worksheet.RowPageBreaks.Contains(item))
        //        {
        //            worksheet.ChangeRowPageBreak(item, MaxRow, false);
        //        }
        //    }

        //    var MaxCol = worksheet.ColumnPageBreaks.Max(v => v);
        //    var MinCol = worksheet.ColumnPageBreaks.Min(v => v);
        //    foreach (var item in worksheet.ColumnPageBreaks.ToList())
        //    {
        //        if (item == MaxCol || item == MinCol)
        //        {
        //            continue;
        //        }
        //        if (worksheet.ColumnPageBreaks.Contains(item))
        //        {
        //            worksheet.ChangeColumnPageBreak(item, MaxCol, false);
        //        }
        //    }

        //}

        public static void AddKhoaCung(this Worksheet worksheet_0, bool Checked)
        {
            var cover = new RangePosition(
                    1, 1, worksheet_0.UsedRange.EndRow - 1
                     , worksheet_0.UsedRange.EndCol - 1);
            worksheet_0.SetRangeBorders(cover, BorderPositions.All,
                               new unvell.ReoGrid.RangeBorderStyle
                               {
                                   Style = BorderLineStyle.None,

                               });

            if (Checked)
            {
                for (int i = 1; i < worksheet_0.Columns - 1; i = i + 2)
                {
                    var rangedata = new RangePosition(
                    1, i, worksheet_0.UsedRange.EndRow - 1
                     , 2);
                    worksheet_0.SetRangeBorders(rangedata, BorderPositions.LeftRight,
                                     new unvell.ReoGrid.RangeBorderStyle
                                     {
                                         Style = BorderLineStyle.BoldSolid,
                                         Color = Color.Black
                                     });
                }


                worksheet_0.SetRangeBorders(cover, BorderPositions.TopBottom,
                                 new unvell.ReoGrid.RangeBorderStyle
                                 {
                                     Style = BorderLineStyle.BoldSolid,
                                     Color = Color.Black
                                 });
            }


        }

        public static float GetTotalWidth(this Worksheet worksheet)
        {
            float TotalWidth = 0;
            for (int i = 0; i < worksheet.UsedRange.EndCol; i++)
            {
                var height = worksheet.GetColumnWidth(i);
                TotalWidth += height;
            }
            TotalWidth += worksheet.PrintSettings.Margins.Left;
            TotalWidth += worksheet.PrintSettings.Margins.Right;
            return TotalWidth;
        }

        public static void SetOnePage(this Worksheet worksheet)
        {

            var MaxRow = worksheet.RowPageBreaks.Count > 0 ? worksheet.RowPageBreaks.Max(v => v) : 0;


            worksheet.ResetAllPageBreaks();

            var MaxCol = worksheet.ColumnPageBreaks.Max(v => v);
            var MinCol = worksheet.ColumnPageBreaks.Min(v => v);
            foreach (var item in worksheet.ColumnPageBreaks.ToList())
            {
                if (item == MaxCol || item == MinCol)
                {
                    continue;
                }
                if (worksheet.ColumnPageBreaks.Contains(item))
                {
                    worksheet.ChangeColumnPageBreak(item, MaxCol, false);
                }
            }

            if (Util.LongSoHienTai.KhoaCung)
            {
                  var MinRow = worksheet.RowPageBreaks.Min(v => v);
                MaxRow = worksheet.RowPageBreaks.Count > 0 ? worksheet.RowPageBreaks.Max(v => v) : 0;
                foreach (var item in worksheet.RowPageBreaks.ToList())
                {
                    if (item == MaxRow || item == MinRow)
                    {
                        continue;
                    }

                    if (worksheet.RowPageBreaks.Contains(item))
                    {
                        worksheet.ChangeRowPageBreak(item, MaxRow, false);
                    }
                }
 
                if (Util.LongSoHienTai.PageBreakRow == 0)
                {
                    Util.LongSoHienTai.PageBreakRow = MaxRow;
                }

                var start = 1;
                while (start + Util.LongSoHienTai.PageBreakRow < MaxRow)
                {
                    start = start + Util.LongSoHienTai.PageBreakRow;
                    if (start+2 > MaxRow)
                    {
                        continue;
                    }
                    worksheet.InsertRowPageBreak(start, true);

                }
            }
            else
            {
                var MinRow = worksheet.RowPageBreaks.Min(v => v);
                MaxRow = worksheet.RowPageBreaks.Count > 0 ? worksheet.RowPageBreaks.Max(v => v) : 0;
                foreach (var item in worksheet.RowPageBreaks.ToList())
                {
                    if (item == MaxRow || item == MinRow)
                    {
                        continue;
                    }

                    if (worksheet.RowPageBreaks.Contains(item))
                    {
                        worksheet.ChangeRowPageBreak(item, MaxRow, false);
                    }
                }

            }



        }
        public static void SettingsValue(this Worksheet worksheet, object sender = null, EventArgs e = null)
        {
            worksheet.SelectionForwardDirection = SelectionForwardDirection.Down;
            worksheet.SetSettings(WorksheetSettings.View_ShowHeaders, false);
            worksheet.SetSettings(WorksheetSettings.Behavior_MouseWheelToScroll, false);
            worksheet.SetSettings(WorksheetSettings.Behavior_ScrollToFocusCell, false);
            worksheet.SetSettings(WorksheetSettings.Edit_AutoExpandColumnWidth, false);
            worksheet.SetSettings(WorksheetSettings.Edit_AllowAdjustColumnWidth, false);
            worksheet.SetSettings(WorksheetSettings.Edit_AutoExpandRowHeight, false);
            worksheet.SetSettings(WorksheetSettings.Edit_AllowAdjustRowHeight, false);
            worksheet.SetSettings(WorksheetSettings.View_AllowCellTextOverflow, true);
            worksheet.SetSettings(WorksheetSettings.View_ShowGridLine, true);

            worksheet.EnableSettings(WorksheetSettings.View_ShowPageBreaks);
        }


    }
}
