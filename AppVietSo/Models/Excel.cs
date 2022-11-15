using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid;

namespace AppVietSo.Models
{
    // Token: 0x0200000D RID: 13
    public static class Excel
    {
        // Token: 0x0600006A RID: 106 RVA: 0x00004DF4 File Offset: 0x00002FF4
        public static void HorizontalAlign(global::unvell.ReoGrid.Worksheet ws, global::unvell.ReoGrid.ReoGridHorAlign hAlign)
        {

            for (int i = 0; i < ws.ColumnCount; i++)
            {
                unvell.ReoGrid.ColumnHeader columnHeader = ws.ColumnHeaders[i];
                columnHeader.Style.HorizontalAlign = hAlign;
            }
        }

        // Token: 0x0600006B RID: 107 RVA: 0x00004E48 File Offset: 0x00003048
        public static void SetColDataTextWrap(global::unvell.ReoGrid.Worksheet ws, int col)
        {
            RangePosition rangePosition = new RangePosition(0, col, ws.RowCount, 1);
            ws.SetRangeStyles(rangePosition, new global::unvell.ReoGrid.WorksheetRangeStyle
            {
                Flag = unvell.ReoGrid.PlainStyleFlag.TextWrap,
                TextWrapMode = unvell.ReoGrid.TextWrapMode.WordBreak
            });
        }

        // Token: 0x0600006C RID: 108 RVA: 0x00004E84 File Offset: 0x00003084
        public static void SetRowCol(global::unvell.ReoGrid.Worksheet ws, int row, int col)
        {
            ws.Reset();
            if (0 < row)
            {
                ws.SetRows(row);
            }
            if (0 < col)
            {
                ws.SetCols(col);
            }
        }

        // Token: 0x0600006D RID: 109 RVA: 0x00004EB0 File Offset: 0x000030B0
        public static void SetColVisible(global::unvell.ReoGrid.Worksheet ws, int col, bool flg = true)
        {
            if (ws.ColumnHeaders[col].IsVisible != flg)
            {
                ws.ColumnHeaders[col].IsVisible = flg;
            }
        }

        // Token: 0x0600006E RID: 110 RVA: 0x00004EE4 File Offset: 0x000030E4
        public static void FillDataToGrid(global::System.Collections.Generic.List<object> cvL, int rIndexStart, global::unvell.ReoGrid.Worksheet ws)
        {
            if (cvL != null && cvL.Count > 0)
            {
                ws.SuspendFormulaReferenceUpdates();
                ws.Recalculate();
                int i = rIndexStart;
                int num = 0;
                try
                {
                    while (i < cvL.Count)
                    {
                        object obj = cvL[i];
                        Excel.RID111(i, out num, obj, ws);
                        i++;
                    }
                    i -= rIndexStart;
                    int num2 = 0;
                    int num3 = i;
                    int num4 = num;
                    global::unvell.ReoGrid.BorderPositions borderPositions = BorderPositions.InsideHorizontal;
                    global::unvell.ReoGrid.RangeBorderStyle rangeBorderStyle = default(global::unvell.ReoGrid.RangeBorderStyle);
                    rangeBorderStyle.Color = global::System.Drawing.Color.Black;
                    rangeBorderStyle.Style = BorderLineStyle.Dotted;
                    ws.SetRangeBorders(rIndexStart, num2, num3, num4, borderPositions, rangeBorderStyle);
                    int num5 = 0;
                    int num6 = i;
                    int num7 = num;
                    global::unvell.ReoGrid.BorderPositions borderPositions2 = BorderPositions.InsideVertical;
                    rangeBorderStyle = default(global::unvell.ReoGrid.RangeBorderStyle);
                    rangeBorderStyle.Color = global::System.Drawing.Color.Black;
                    rangeBorderStyle.Style = BorderLineStyle.Solid;
                    ws.SetRangeBorders(rIndexStart, num5, num6, num7, borderPositions2, rangeBorderStyle);
                }
                finally
                {
                    ws.ResumeFormulaReferenceUpdates();
                    ws.Recalculate();
                }
                return;
            }
        }

        // Token: 0x0600006F RID: 111 RVA: 0x00004FB8 File Offset: 0x000031B8
        private static void RID111(int A_0, out int A_1, object A_2, global::unvell.ReoGrid.Worksheet A_3)
        {
            global::System.ComponentModel.PropertyDescriptorCollection properties = global::System.ComponentModel.TypeDescriptor.GetProperties(A_2);
            A_1 = 0;
            for (int i = 0; i <= properties.Count - 1; i++)
            {
                global::System.ComponentModel.PropertyDescriptor propertyDescriptor = properties[i];
                if (propertyDescriptor.PropertyType.Name == "Cell")
                {
                    var a2 = (Models.Cell)propertyDescriptor.GetValue(A_2);
                    a2 = a2 ?? new Cell();
                    Excel.RID112(A_0, A_1, a2, A_3);
                    A_1++;
                }
            }
        }

        // Token: 0x06000070 RID: 112 RVA: 0x00005020 File Offset: 0x00003220
        private static void RID112(int A_0, int A_1, Models.Cell A_2, global::unvell.ReoGrid.Worksheet A_3)
        {
            if (A_2 != null && A_2.ValType is global::System.Collections.Generic.List<object>)
            {
                Excel.RID114(A_0, A_1, A_2, A_3);
                return;
            }
            Excel.drawCellText(A_0, A_1, A_2, A_3);
        }

        // Token: 0x06000071 RID: 113 RVA: 0x00005050 File Offset: 0x00003250
        public static void drawCellText(int r, int c, Models.Cell celD, global::unvell.ReoGrid.Worksheet ws)
        {
            global::unvell.ReoGrid.Cell cell = ws.Cells[r, c];
            cell.Style.TextColor = global::System.Drawing.Color.Black;
            cell.Style.BackColor = global::System.Drawing.Color.White;
            cell.Style.Italic = false;
            if (!string.IsNullOrEmpty(celD.MergeRange))
            {
                ws.MergeRange(celD.MergeRange);
            }
            cell.Style.Bold = celD.FontBold;
            if (0f < celD.FontSize)
            {
                cell.Style.FontSize = celD.FontSize;
            }
            switch (celD.HAlignment)
            {
                case 1:
                    cell.Style.HAlign = ReoGridHorAlign.Left;
                    break;
                case 2:
                    cell.Style.HAlign = ReoGridHorAlign.Center;
                    break;
                case 3:
                    cell.Style.HAlign = ReoGridHorAlign.Right;
                    break;
            }
            if (!string.IsNullOrEmpty(celD.BColor) && celD.BColor != "White")
            {
                cell.Style.BackColor = celD.BackColor;
            }
            if (!string.IsNullOrEmpty(celD.FColor) && celD.FColor != "Black")
            {
                cell.Style.TextColor = celD.ForeColor;
            }
            if (!string.IsNullOrEmpty(celD.Formula))
            {
                cell.Data = null;
                string formula = celD.Formula;
                if (formula.StartsWith("="))
                {
                    throw new global::System.Exception("Error: thừa dấu = " + formula);
                }
                if (formula.Contains(';'))
                {
                    throw new global::System.Exception("Error: dấu ; " + formula);
                }
                cell.Formula = formula;
            }
            else
            {
                cell.Data = celD.Value;
            }
            cell.IsReadOnly = celD.IsReadOnly;
        }

        // Token: 0x06000072 RID: 114 RVA: 0x00005210 File Offset: 0x00003410
        private static void RID114(int A_0, int A_1, Models.Cell A_2, global::unvell.ReoGrid.Worksheet A_3)
        {
            A_3[A_0, A_1] = new global::unvell.ReoGrid.CellTypes.DropdownListCell((global::System.Collections.Generic.List<object>)A_2.ValType);
            A_3[A_0, A_1] = A_2.Value;
            global::unvell.ReoGrid.Cell cell = A_3.Cells[A_0, A_1];
            cell.Style.TextColor = global::System.Drawing.Color.Black;
            cell.Style.BackColor = global::System.Drawing.Color.White;
            cell.Style.Italic = false;
            if (!string.IsNullOrEmpty(A_2.BColor) && A_2.BColor != "White")
            {
                cell.Style.BackColor = A_2.BackColor;
            }
            if (!string.IsNullOrEmpty(A_2.FColor) && A_2.FColor != "Black")
            {
                cell.Style.TextColor = A_2.ForeColor;
            }
        }
    }
}
