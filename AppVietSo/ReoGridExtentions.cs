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

        public static void PreView(this ReoGridControl reoGrid, object sender = null, EventArgs e = null)
        {
            //      LoadDataToDataGrid(reoGrid);

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
            worksheet.ResetAllPageBreaks();
            var MaxRow = worksheet.RowPageBreaks.Max(v => v);
            var MinRow = worksheet.RowPageBreaks.Min(v => v);
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
