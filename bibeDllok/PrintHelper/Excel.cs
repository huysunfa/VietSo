using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using unvell.ReoGrid;
using unvell.ReoGrid.CellTypes;

namespace PrintHelper
{
	// Token: 0x0200000D RID: 13
	public static class Excel
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00004DE8 File Offset: 0x00002FE8
		public static void HorizontalAlign(global::unvell.ReoGrid.Worksheet ws, global::unvell.ReoGrid.ReoGridHorAlign hAlign)
		{
			foreach (global::unvell.ReoGrid.ColumnHeader columnHeader in ws.ColumnHeaders)
			{
				columnHeader.Style.HorizontalAlign = hAlign;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004E3C File Offset: 0x0000303C
		public static void SetColDataTextWrap(global::unvell.ReoGrid.Worksheet ws, int col)
		{
			global::unvell.ReoGrid.RangePosition rangePosition;
			rangePosition..ctor(0, col, ws.RowCount, 1);
			ws.SetRangeStyles(rangePosition, new global::unvell.ReoGrid.WorksheetRangeStyle
			{
				Flag = 0x200000L,
				TextWrapMode = 1
			});
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004E7C File Offset: 0x0000307C
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

		// Token: 0x0600006D RID: 109 RVA: 0x00004EA8 File Offset: 0x000030A8
		public static void SetColVisible(global::unvell.ReoGrid.Worksheet ws, int col, bool flg = true)
		{
			if (ws.ColumnHeaders[col].IsVisible != flg)
			{
				ws.ColumnHeaders[col].IsVisible = flg;
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00004EDC File Offset: 0x000030DC
		public static void FillDataToGrid(global::System.Collections.Generic.List<object> cvL, int rIndexStart, global::unvell.ReoGrid.Worksheet ws)
		{
			if (cvL != null && cvL.Count > 0)
			{
				ws.SuspendFormulaReferenceUpdates();
				ws.ResetFormulas();
				int i = rIndexStart;
				int num = 0;
				try
				{
					while (i < cvL.Count)
					{
						object object_ = cvL[i];
						global::PrintHelper.Excel.smethod_0(i, out num, object_, ws);
						i++;
					}
					i -= rIndexStart;
					int num2 = 0;
					int num3 = i;
					int num4 = num;
					global::unvell.ReoGrid.BorderPositions borderPositions = 0x10;
					global::unvell.ReoGrid.RangeBorderStyle rangeBorderStyle = default(global::unvell.ReoGrid.RangeBorderStyle);
					rangeBorderStyle.Color = global::System.Drawing.Color.Black;
					rangeBorderStyle.Style = 2;
					ws.SetRangeBorders(rIndexStart, num2, num3, num4, borderPositions, rangeBorderStyle);
					int num5 = 0;
					int num6 = i;
					int num7 = num;
					global::unvell.ReoGrid.BorderPositions borderPositions2 = 0x2F;
					rangeBorderStyle = default(global::unvell.ReoGrid.RangeBorderStyle);
					rangeBorderStyle.Color = global::System.Drawing.Color.Black;
					rangeBorderStyle.Style = 1;
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

		// Token: 0x0600006F RID: 111 RVA: 0x00004FB0 File Offset: 0x000031B0
		private static void smethod_0(int int_0, out int int_1, object object_0, global::unvell.ReoGrid.Worksheet worksheet_0)
		{
			global::System.ComponentModel.PropertyDescriptorCollection properties = global::System.ComponentModel.TypeDescriptor.GetProperties(object_0);
			int_1 = 0;
			for (int i = 0; i <= properties.Count - 1; i++)
			{
				global::System.ComponentModel.PropertyDescriptor propertyDescriptor = properties[i];
				if (propertyDescriptor.PropertyType.Name == "Cell")
				{
					global::PrintHelper.Excel.smethod_1(int_0, int_1, (global::PrintHelper.Cell)propertyDescriptor.GetValue(object_0), worksheet_0);
					int_1++;
				}
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005014 File Offset: 0x00003214
		private static void smethod_1(int int_0, int int_1, global::PrintHelper.Cell cell_0, global::unvell.ReoGrid.Worksheet worksheet_0)
		{
			if (cell_0.ValType is global::System.Collections.Generic.List<object>)
			{
				global::PrintHelper.Excel.smethod_2(int_0, int_1, cell_0, worksheet_0);
				return;
			}
			global::PrintHelper.Excel.drawCellText(int_0, int_1, cell_0, worksheet_0);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00005044 File Offset: 0x00003244
		public static void drawCellText(int r, int c, global::PrintHelper.Cell celD, global::unvell.ReoGrid.Worksheet ws)
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
				cell.Style.HAlign = 1;
				break;
			case 2:
				cell.Style.HAlign = 2;
				break;
			case 3:
				cell.Style.HAlign = 3;
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

		// Token: 0x06000072 RID: 114 RVA: 0x00005204 File Offset: 0x00003404
		private static void smethod_2(int int_0, int int_1, global::PrintHelper.Cell cell_0, global::unvell.ReoGrid.Worksheet worksheet_0)
		{
			worksheet_0[int_0, int_1] = new global::unvell.ReoGrid.CellTypes.DropdownListCell((global::System.Collections.Generic.List<object>)cell_0.ValType);
			worksheet_0[int_0, int_1] = cell_0.Value;
			global::unvell.ReoGrid.Cell cell = worksheet_0.Cells[int_0, int_1];
			cell.Style.TextColor = global::System.Drawing.Color.Black;
			cell.Style.BackColor = global::System.Drawing.Color.White;
			cell.Style.Italic = false;
			if (!string.IsNullOrEmpty(cell_0.BColor) && cell_0.BColor != "White")
			{
				cell.Style.BackColor = cell_0.BackColor;
			}
			if (!string.IsNullOrEmpty(cell_0.FColor) && cell_0.FColor != "Black")
			{
				cell.Style.TextColor = cell_0.ForeColor;
			}
		}
	}
}
