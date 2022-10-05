using System;
using System.Collections.Generic;
using System.Globalization;
using DataModel;
using DataModel.Entities;
using DataText;
using unvell.ReoGrid;

namespace PrintHelper
{
	// Token: 0x0200000C RID: 12
	public sealed class DanhSachTinChu
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00004AA4 File Offset: 0x00002CA4
		public static void FillTinChuToGrid(global::System.Collections.Generic.Dictionary<int, global::DataText.Family> selectedSoNos, bool isFillAddress, string pagodaID, global::DataModel.Year isNextYear, global::DataText.ThietLapTinChu tlTC, global::unvell.ReoGrid.Worksheet curWS, int startRowNum, int startColNum)
		{
			int num = startRowNum;
			int num2 = startColNum;
			foreach (global::DataText.Family family in selectedSoNos.Values)
			{
				global::System.Collections.Generic.List<global::DataModel.Entities.Person> list = global::DataText.PersonBO.getList(pagodaID, family);
				if (list == null || list.Count <= 0)
				{
					throw new global::System.Exception("Không tìm thấy Mã sớ " + family.SoNo.ToString());
				}
				string string_ = "";
				global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>> listTinChu = global::DataText.LePhat.getListTinChu(ref string_, list, tlTC.FormText, isNextYear);
				global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<global::PrintHelper.Cell>> queue = new global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<global::PrintHelper.Cell>>();
				foreach (global::System.Collections.Generic.Queue<string> queue2 in listTinChu)
				{
					global::System.Collections.Generic.Queue<global::PrintHelper.Cell> queue3 = new global::System.Collections.Generic.Queue<global::PrintHelper.Cell>();
					foreach (string value in queue2)
					{
						queue3.Enqueue(new global::PrintHelper.Cell
						{
							Value = value
						});
					}
					queue.Enqueue(queue3);
				}
				global::PrintHelper.DanhSachTinChu.smethod_0(curWS, queue, string_, isFillAddress, startRowNum, startColNum, ref num, ref num2);
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004C2C File Offset: 0x00002E2C
		private static void smethod_0(global::unvell.ReoGrid.Worksheet worksheet_0, global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<global::PrintHelper.Cell>> queue_0, string string_0, bool bool_0, int int_0, int int_1, ref int int_2, ref int int_3)
		{
			foreach (global::System.Collections.Generic.Queue<global::PrintHelper.Cell> queue_ in queue_0)
			{
				global::PrintHelper.DanhSachTinChu.smethod_1(worksheet_0, queue_, int_0, int_1, ref int_2, ref int_3);
			}
			if (!string.IsNullOrWhiteSpace(string_0) && bool_0)
			{
				global::System.Collections.Generic.Queue<global::PrintHelper.Cell> queue = new global::System.Collections.Generic.Queue<global::PrintHelper.Cell>();
				string_0 = string_0.Replace(",", "").Replace(".", "").Replace("-", "").Replace("_", "").Replace("  ", " ");
				foreach (string text in string_0.Split(new char[]
				{
					' '
				}))
				{
					queue.Enqueue(new global::PrintHelper.Cell
					{
						Value = global::System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower()),
						FontBold = true
					});
				}
				queue.Enqueue(new global::PrintHelper.Cell());
				global::PrintHelper.DanhSachTinChu.smethod_1(worksheet_0, queue, int_0, int_1, ref int_2, ref int_3);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004D60 File Offset: 0x00002F60
		private static void smethod_1(global::unvell.ReoGrid.Worksheet worksheet_0, global::System.Collections.Generic.Queue<global::PrintHelper.Cell> queue_0, int int_0, int int_1, ref int int_2, ref int int_3)
		{
			foreach (global::PrintHelper.Cell celD in queue_0)
			{
				if (worksheet_0.RowCount <= int_2)
				{
					int_2 = int_0;
					int_3--;
				}
				if (int_3 < 0)
				{
					worksheet_0.InsertColumns(0, int_1 + 1);
					int_3 = int_1;
				}
				global::PrintHelper.Excel.drawCellText(int_2, int_3, celD, worksheet_0);
				int_2++;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003D54 File Offset: 0x00001F54
		public DanhSachTinChu()
		{
		}
	}
}
