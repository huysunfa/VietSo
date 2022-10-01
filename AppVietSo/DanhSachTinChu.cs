using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo
{
	public sealed class DanhSachTinChu
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00004AA8 File Offset: 0x00002CA8
		public static void FillTinChuToGrid(global::System.Collections.Generic.Dictionary<int, Family> selectedSoNos, bool isFillAddress, string pagodaID,  Year isNextYear, ThietLapTinChu tlTC, global::unvell.ReoGrid.Worksheet curWS, int startRowNum, int startColNum,bool PersonPerCol =false)
		{
			int num = startRowNum;
			int num2 = startColNum;
			foreach (Family family in selectedSoNos.Values)
			{
				global::System.Collections.Generic.List<Person> list = PersonBO.getList(pagodaID, family, PersonPerCol);
				if (list == null || list.Count <= 0)
				{
					throw new global::System.Exception("Không tìm thấy Mã sớ " + family.SoNo.ToString());
				}
				string text = "";
				global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>> listTinChu = LePhat.getListTinChu(ref text, list, tlTC.FormText, isNextYear);
				global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<Cell>> queue = new global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<Cell>>();
				foreach (global::System.Collections.Generic.Queue<string> queue2 in listTinChu)
				{
					global::System.Collections.Generic.Queue<Cell> queue3 = new global::System.Collections.Generic.Queue<Cell>();
					foreach (string value in queue2)
					{
						queue3.Enqueue(new Cell
						{
							Value = value
						});
					}
					queue.Enqueue(queue3);
				}
				DanhSachTinChu.LOAD92(curWS, queue, text, isFillAddress, startRowNum, startColNum, ref num, ref num2);
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004C30 File Offset: 0x00002E30
		private static void LOAD92(global::unvell.ReoGrid.Worksheet A_0, global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<Cell>> A_1, string A_2, bool A_3, int A_4, int A_5, ref int A_6, ref int A_7)
		{
			foreach (global::System.Collections.Generic.Queue<Cell> queue in A_1)
			{
				if (!string.IsNullOrWhiteSpace(A_2) && A_3)
				{
 					A_2 = A_2.Replace(",", "").Replace(".", "").Replace("-", "").Replace("_", "").Replace("  ", " ");
					foreach (string text in A_2.Split(new char[]
					{
					' '
					}))
					{
						queue.Enqueue(new Cell
						{
							Value = global::System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower()),
							FontBold = true
						});
					}
 		//			DanhSachTinChu.LOAD93(A_0, queue2, A_4, A_5, ref A_6, ref A_7);
				}

				DanhSachTinChu.LOAD93(A_0, queue, A_4, A_5, ref A_6, ref A_7);

		

				A_6 = 0;
				A_7 = A_7 - 1;
			}
		
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004D6C File Offset: 0x00002F6C
		private static void LOAD93(global::unvell.ReoGrid.Worksheet A_0, global::System.Collections.Generic.Queue<Cell> A_1, int A_2, int A_3, ref int A_4, ref int A_5)
		{
			foreach (Cell celD in A_1)
			{
				if (A_0.RowCount <= A_4)
				{
					A_4 = A_2;
					A_5--;
				}
				if (A_5 < 0)
				{
					A_0.InsertColumns(0, A_3 + 1);
					A_5 = A_3;
				}
				Excel.drawCellText(A_4, A_5, celD, A_0);
				A_4++;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003D58 File Offset: 0x00001F58
		public DanhSachTinChu()
		{
		}
	}
}
