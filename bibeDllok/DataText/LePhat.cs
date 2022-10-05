using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CommonModel;
using DataModel;
using DataModel.Entities;

namespace DataText
{
	// Token: 0x0200001D RID: 29
	public sealed class LePhat
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00007B74 File Offset: 0x00005D74
		public static global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.List<global::DataModel.Entities.VnChinese>> getDic
		{
			get
			{
				if (global::DataText.LePhat.dictionary_0 == null)
				{
					global::DataText.LePhat.dictionary_0 = global::DataText.VnChineseBO.getDic();
				}
				return global::DataText.LePhat.dictionary_0;
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00007B98 File Offset: 0x00005D98
		public static void updateUsedTime(string vn, string cn, string nguCanh)
		{
			if (!string.IsNullOrEmpty(nguCanh))
			{
				nguCanh = nguCanh.Replace("$", "").Replace("@", "").Replace("*", "");
			}
			global::DataText.VnChineseBO.updateUsedTime(vn.ToLower(), cn, nguCanh);
			global::DataText.LePhat.dictionary_0 = null;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00007BF0 File Offset: 0x00005DF0
		public static global::DataText.CellData getCelLgSo(int colKey, int rowKey)
		{
			global::DataText.CellData cellData = global::DataText.LePhat.longSoData_0.LgSo[colKey][rowKey];
			if (cellData == null)
			{
				cellData = new global::DataText.CellData();
				global::DataText.LePhat.longSoData_0.LgSo[colKey][rowKey] = cellData;
			}
			return cellData;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00007C38 File Offset: 0x00005E38
		public static void ClearLgSo()
		{
			global::DataText.LePhat.longSoData_0 = null;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00007C4C File Offset: 0x00005E4C
		public static global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<global::DataText.CellData>> getTinChu(string pagodaID, global::DataText.Family fml, ref string giaChu, ref string address, global::DataModel.Year isNextYear)
		{
			if (global::DataText.LePhat.year_0 == isNextYear && pagodaID == global::DataText.LePhat.string_1)
			{
				if (fml.SoNo == global::DataText.LePhat.SoNo)
				{
					if (global::DataText.LePhat.queue_0 != null)
					{
						address = global::DataText.LePhat.string_3;
						giaChu = global::DataText.LePhat.string_4;
						return global::DataText.LePhat.queue_0;
					}
				}
			}
			global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>> queue = global::DataText.LePhat.smethod_0(pagodaID, fml, ref giaChu, ref address, isNextYear);
			global::DataText.LePhat.queue_0 = new global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<global::DataText.CellData>>();
			foreach (global::System.Collections.Generic.Queue<string> queue2 in queue)
			{
				global::System.Collections.Generic.Queue<global::DataText.CellData> item = new global::System.Collections.Generic.Queue<global::DataText.CellData>();
				foreach (string vn in queue2)
				{
					global::DataText.LePhat.getChuNho(ref item, vn, "*tinchu");
				}
				global::DataText.LePhat.queue_0.Enqueue(item);
			}
			return global::DataText.LePhat.queue_0;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00007D40 File Offset: 0x00005F40
		private static global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>> smethod_0(string string_5, global::DataText.Family family_0, ref string string_6, ref string string_7, global::DataModel.Year year_1)
		{
			if (string.IsNullOrEmpty(string_5) || family_0 == null)
			{
				throw new global::System.Exception("Chưa chọn Chùa/Điện hoặc Mã sớ");
			}
			string_7 = global::DataText.LePhat.string_3;
			global::DataText.LePhat.string_1 = string_5;
			global::DataText.LePhat.SoNo = family_0.SoNo;
			global::DataText.LePhat.year_0 = year_1;
			global::System.Collections.Generic.List<global::DataModel.Entities.Person> list = global::DataText.PersonBO.getList(string_5, family_0);
			if (list != null && list.Count > 0)
			{
				string_6 = list[0].FullName;
				global::DataText.LePhat.string_4 = string_6;
				if (global::DataText.LePhat.longSoData_0.TinChu == null)
				{
					global::DataText.LePhat.longSoData_0.TinChu = new global::DataText.ThietLapTinChu();
				}
				global::DataText.ThietLapTinChu tinChu = global::DataText.LePhat.longSoData_0.TinChu;
				global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>> listTinChu = global::DataText.LePhat.getListTinChu(ref string_7, list, tinChu.FormText, year_1);
				if (!string.IsNullOrWhiteSpace(tinChu.MoreText))
				{
					global::System.Collections.Generic.Queue<string> item = global::DataText.LePhat.convert2Queue(tinChu.MoreText);
					listTinChu.Enqueue(item);
				}
				return listTinChu;
			}
			throw new global::System.Exception("Không tìm thấy Mã sớ " + family_0.SoNo.ToString());
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00007E2C File Offset: 0x0000602C
		public static global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>> getListTinChu(ref string address, global::System.Collections.Generic.List<global::DataModel.Entities.Person> psnL, string formText, global::DataModel.Year isNextYear)
		{
			global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>> queue = new global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>>();
			global::DataText.LePhat.string_3 = "";
			foreach (global::DataModel.Entities.Person person in psnL)
			{
				if (string.IsNullOrEmpty(global::DataText.LePhat.string_3))
				{
					global::DataText.LePhat.string_3 = person.Address;
					address = global::DataText.LePhat.string_3;
				}
				string text;
				if (person.NamSinh.Equals(0))
				{
					text = "$ten";
				}
				else
				{
					person.isNextYear = isNextYear;
					text = formText.Replace("$canchi", person.Menh);
					text = text.Replace("$sotuoi", person.Tuoi);
					text = text.Replace("$tuoi", global::DataText.LePhat.getChuNomYYYY(person.Tuoi));
					text = text.Replace("$sao", person.Sao);
					if (global::DataText.LePhat.dictionary_1 == null)
					{
						global::DataText.LePhat.dictionary_1 = global::DataText.Security.readFile<global::System.Collections.Generic.Dictionary<string, string>>(global::DataModel.Util.getDataPath + "QuanTien.qnt");
					}
					if (global::DataText.LePhat.dictionary_1 != null && global::DataText.LePhat.dictionary_1.ContainsKey(person.Menh.ToLower()))
					{
						text = text.Replace("$quantien", global::DataText.LePhat.dictionary_1[person.Menh.ToLower()]);
					}
				}
				text = text.Replace("$danh", person.DanhXung.Trim());
				text = text.Replace("$ten", person.FullName.Trim());
				global::System.Collections.Generic.Queue<string> item = global::DataText.LePhat.convert2Queue(text);
				queue.Enqueue(item);
			}
			return queue;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00007FC8 File Offset: 0x000061C8
		public static global::System.Collections.Generic.List<global::DataModel.Entities.Person> getHuongL(string pagodaID, global::DataText.Family fml)
		{
			if (string.IsNullOrEmpty(pagodaID) || fml == null)
			{
				throw new global::System.Exception("Chưa chọn Chùa/Điện hoặc Mã sớ");
			}
			return global::DataText.PersonBO.getHuonglinhs(pagodaID, fml);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00007FF4 File Offset: 0x000061F4
		public static global::System.Collections.Generic.Queue<string> convert2Queue(string s)
		{
			s = global::System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.Trim().ToLower());
			global::System.Collections.Generic.Queue<string> queue = new global::System.Collections.Generic.Queue<string>();
			foreach (string item in s.Trim().Split(new char[]
			{
				' '
			}))
			{
				queue.Enqueue(item);
			}
			return queue;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00008054 File Offset: 0x00006254
		public static global::System.Collections.Generic.Queue<global::DataText.CellData> convertToCell(global::System.Collections.Generic.Queue<string> sQ, string v)
		{
			global::System.Collections.Generic.Queue<global::DataText.CellData> result = new global::System.Collections.Generic.Queue<global::DataText.CellData>();
			foreach (string vn in sQ)
			{
				global::DataText.LePhat.getChuNho(ref result, vn, v);
			}
			return result;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000080AC File Offset: 0x000062AC
		public static void setTextLongSo(int colNo, int rowNo, string text)
		{
			if (colNo >= 0 && rowNo >= 0)
			{
				global::DataText.CellData celLgSo = global::DataText.LePhat.getCelLgSo(colNo, rowNo);
				if (string.IsNullOrEmpty(text))
				{
					celLgSo.TextVN = text;
				}
				else if (!text.Contains("@") && !text.Contains("$"))
				{
					celLgSo.TextVN = text;
				}
				else
				{
					celLgSo.Value = text;
				}
				global::DataText.LePhat.saveLongSo();
				return;
			}
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000810C File Offset: 0x0000630C
		public static void setTextCNLongSo(int colNo, int rowNo, string text)
		{
			if (colNo >= 0 && rowNo >= 0)
			{
				global::DataText.LePhat.getCelLgSo(colNo, rowNo).TextCN = text;
				global::DataText.LePhat.saveLongSo();
				return;
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00008134 File Offset: 0x00006334
		public static void setTextLongSo(int colNo, int rowNo, global::System.Collections.Generic.Queue<string> q)
		{
			if (colNo >= 0 && rowNo >= 0 && q != null && q.Count != 0)
			{
				foreach (string text in q)
				{
					global::DataText.CellData celLgSo = global::DataText.LePhat.getCelLgSo(colNo, rowNo);
					if (!global::DataModel.Util.isChineseLang(text))
					{
						if (!string.IsNullOrEmpty(text))
						{
							celLgSo.TextVN = global::System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
						}
						else
						{
							celLgSo.TextCN = text;
							celLgSo.TextVN = text;
						}
					}
					else
					{
						celLgSo.TextCN = text;
					}
					rowNo++;
					if (global::DataText.LePhat.longSoData_0.LgSo[colNo].Count <= rowNo)
					{
						break;
					}
				}
				global::DataText.LePhat.saveLongSo();
				return;
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000820C File Offset: 0x0000640C
		public static void insertTextLongSo(global::System.Collections.Generic.List<global::DataText.CellData> cld)
		{
			if (cld.Count == 1)
			{
				global::DataText.LePhat.longSoData_0.LgSo[cld[0].ColNo][cld[0].RowNo] = cld[0];
			}
			else
			{
				foreach (global::DataText.CellData cellData in cld)
				{
					global::DataText.LePhat.longSoData_0.LgSo[cellData.ColNo][cellData.RowNo] = cellData;
				}
			}
			global::DataText.LePhat.saveLongSo();
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000082B8 File Offset: 0x000064B8
		public static void delTextLongSo(global::System.Collections.Generic.List<global::DataText.CellData> cld)
		{
			if (cld.Count == 1)
			{
				global::DataText.LePhat.longSoData_0.LgSo[cld[0].ColNoOrg][cld[0].RowNoOrg] = new global::DataText.CellData();
			}
			else
			{
				foreach (global::DataText.CellData cellData in cld)
				{
					global::DataText.LePhat.longSoData_0.LgSo[cellData.ColNoOrg][cellData.RowNoOrg] = new global::DataText.CellData();
				}
			}
			global::DataText.LePhat.saveLongSo();
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00008368 File Offset: 0x00006568
		public static void saveLongSo()
		{
			if (!string.IsNullOrEmpty(global::DataText.LePhat.string_0) && global::DataText.LePhat.longSoData_0 != null)
			{
				global::DataText.Security.writeFile(global::DataText.LePhat.longSoData_0, global::DataText.LePhat.string_0);
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00008398 File Offset: 0x00006598
		public static void saveLongSo(global::DataText.LongSoData lgSoD, string pnf)
		{
			if (!string.IsNullOrEmpty(pnf) && lgSoD != null)
			{
				global::DataText.Security.writeFile(lgSoD, pnf);
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000083B8 File Offset: 0x000065B8
		public static void longSoAddRow(int rowNo)
		{
			if (rowNo < 0)
			{
				return;
			}
			global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> dictionary = new global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>>();
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> keyValuePair in global::DataText.LePhat.longSoData_0.LgSo)
			{
				global::System.Collections.Generic.Dictionary<int, global::DataText.CellData> dictionary2 = new global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>();
				dictionary.Add(keyValuePair.Key, dictionary2);
				bool flag = false;
				foreach (global::System.Collections.Generic.KeyValuePair<int, global::DataText.CellData> keyValuePair2 in keyValuePair.Value)
				{
					int num = keyValuePair2.Key;
					if (rowNo == num)
					{
						dictionary2.Add(num, new global::DataText.CellData());
						flag = true;
					}
					if (flag)
					{
						num++;
					}
					dictionary2.Add(num, keyValuePair2.Value);
				}
			}
			global::DataText.LePhat.longSoData_0.LgSo = dictionary;
			global::DataText.LePhat.saveLongSo();
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000084B8 File Offset: 0x000066B8
		public static void longSoDelRow(int rowNo)
		{
			if (rowNo < 0)
			{
				return;
			}
			global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> dictionary = new global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>>();
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> keyValuePair in global::DataText.LePhat.longSoData_0.LgSo)
			{
				global::System.Collections.Generic.Dictionary<int, global::DataText.CellData> dictionary2 = new global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>();
				dictionary.Add(keyValuePair.Key, dictionary2);
				bool flag = false;
				foreach (global::System.Collections.Generic.KeyValuePair<int, global::DataText.CellData> keyValuePair2 in keyValuePair.Value)
				{
					int num = keyValuePair2.Key;
					if (rowNo != num)
					{
						if (flag)
						{
							num--;
						}
						dictionary2.Add(num, keyValuePair2.Value);
					}
					else
					{
						flag = true;
					}
				}
			}
			global::DataText.LePhat.longSoData_0.LgSo = dictionary;
			global::DataText.LePhat.saveLongSo();
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000085AC File Offset: 0x000067AC
		public static void longSoAddCol(int colNo)
		{
			if (colNo < 0)
			{
				return;
			}
			bool flag = false;
			global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> dictionary = new global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>>();
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> keyValuePair in global::DataText.LePhat.longSoData_0.LgSo)
			{
				int num = keyValuePair.Key;
				if (colNo == num)
				{
					colNo++;
					global::System.Collections.Generic.Dictionary<int, global::DataText.CellData> dictionary2 = new global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>();
					dictionary.Add(colNo, dictionary2);
					foreach (global::System.Collections.Generic.KeyValuePair<int, global::DataText.CellData> keyValuePair2 in keyValuePair.Value)
					{
						dictionary2.Add(keyValuePair2.Key, new global::DataText.CellData());
					}
					flag = true;
				}
				if (!flag)
				{
					num++;
				}
				global::System.Collections.Generic.Dictionary<int, global::DataText.CellData> dictionary3 = new global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>();
				dictionary.Add(num, dictionary3);
				foreach (global::System.Collections.Generic.KeyValuePair<int, global::DataText.CellData> keyValuePair3 in keyValuePair.Value)
				{
					dictionary3.Add(keyValuePair3.Key, keyValuePair3.Value);
				}
			}
			global::DataText.LePhat.longSoData_0.LgSo = dictionary;
			global::DataText.LePhat.saveLongSo();
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00008708 File Offset: 0x00006908
		public static void longSoDelCol(int colNo)
		{
			if (colNo < 0)
			{
				return;
			}
			bool flag = false;
			global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> dictionary = new global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>>();
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> keyValuePair in global::DataText.LePhat.longSoData_0.LgSo)
			{
				int num = keyValuePair.Key;
				if (colNo != num)
				{
					if (!flag)
					{
						num--;
					}
					global::System.Collections.Generic.Dictionary<int, global::DataText.CellData> dictionary2 = new global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>();
					dictionary.Add(num, dictionary2);
					using (global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>.Enumerator enumerator2 = keyValuePair.Value.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							global::System.Collections.Generic.KeyValuePair<int, global::DataText.CellData> keyValuePair2 = enumerator2.Current;
							dictionary2.Add(keyValuePair2.Key, keyValuePair2.Value);
						}
						continue;
					}
				}
				flag = true;
			}
			global::DataText.LePhat.longSoData_0.LgSo = dictionary;
			global::DataText.LePhat.saveLongSo();
		}

		// Token: 0x060001BE RID: 446 RVA: 0x000087F8 File Offset: 0x000069F8
		public static void clearLongSo()
		{
			global::DataText.LePhat.queue_0 = null;
			global::DataText.LePhat.longSoData_0 = null;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00008814 File Offset: 0x00006A14
		public static void setLongSoData(global::DataText.LongSoData lgSo)
		{
			global::DataText.LePhat.longSoData_0 = lgSo;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00008828 File Offset: 0x00006A28
		public static global::DataText.LongSoData getLongSo(string file)
		{
			if (file != null && (!(global::DataText.LePhat.string_2 == file) || global::DataText.LePhat.longSoData_0 == null))
			{
				global::DataText.LePhat.string_2 = file;
				string text = global::DataText.Security.smethod_1(global::DataText.LePhat.smethod_1());
				if (text.Contains("LgSo"))
				{
					global::DataText.LePhat.longSoData_0 = global::CommonModel.UtilModel.ConvertJSON2Obj<global::DataText.LongSoData>(text);
				}
				else
				{
					global::DataText.LongSoDataOld longSoDataOld = global::CommonModel.UtilModel.ConvertJSON2Obj<global::DataText.LongSoDataOld>(text);
					global::DataText.LePhat.longSoData_0 = new global::DataText.LongSoData();
					global::DataText.LePhat.longSoData_0.Language = longSoDataOld.Language;
					global::DataText.LePhat.longSoData_0.SongNguAlign = longSoDataOld.SongNguAlign;
					global::DataText.LePhat.longSoData_0.PageHeight = ((longSoDataOld.PageHeight == 0) ? 0x491 : longSoDataOld.PageHeight);
					global::DataText.LePhat.longSoData_0.PageWidth = ((longSoDataOld.PageWidth == 0) ? 0x73A : longSoDataOld.PageWidth);
					global::DataText.LePhat.longSoData_0.PagePaddingTop = longSoDataOld.PagePaddingTop;
					global::DataText.LePhat.longSoData_0.PagePaddingBottom = longSoDataOld.PagePaddingBottom;
					global::DataText.LePhat.longSoData_0.PagePaddingLeft = longSoDataOld.PagePaddingLeft;
					global::DataText.LePhat.longSoData_0.PagePaddingRight = longSoDataOld.PagePaddingRight;
					global::DataText.LePhat.longSoData_0.LgSo = new global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>>();
					if (longSoDataOld.LongSo == null)
					{
						longSoDataOld.LongSo = global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.Dictionary<string, string>>>(text);
					}
					foreach (global::System.Collections.Generic.KeyValuePair<string, global::System.Collections.Generic.Dictionary<string, string>> keyValuePair in longSoDataOld.LongSo)
					{
						global::System.Collections.Generic.Dictionary<int, global::DataText.CellData> dictionary = new global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>();
						global::DataText.LePhat.longSoData_0.LgSo.Add(int.Parse(keyValuePair.Key), dictionary);
						foreach (global::System.Collections.Generic.KeyValuePair<string, string> keyValuePair2 in keyValuePair.Value)
						{
							global::DataText.CellData cellData = new global::DataText.CellData();
							if (!string.IsNullOrEmpty(keyValuePair2.Value))
							{
								string text2 = keyValuePair2.Value;
								string textCN = "";
								if (text2.Contains(global::DataText.LePhat.char_0.ToString()))
								{
									string[] array = text2.Split(new char[]
									{
										global::DataText.LePhat.char_0
									});
									text2 = array[0];
									textCN = array[1];
								}
								if (!string.IsNullOrEmpty(text2) && (text2.Contains("@") || text2.Contains("$")))
								{
									cellData.Value = text2;
								}
								else
								{
									cellData.TextVN = text2;
								}
								cellData.TextCN = textCN;
							}
							dictionary.Add(int.Parse(keyValuePair2.Key), cellData);
						}
					}
				}
				return global::DataText.LePhat.longSoData_0;
			}
			return global::DataText.LePhat.longSoData_0;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00008AD4 File Offset: 0x00006CD4
		private static byte[] smethod_1()
		{
			byte[] array = null;
			if (global::System.IO.File.Exists(global::DataModel.Util.getDataPath + global::DataText.LePhat.string_2 + ".cus"))
			{
				global::DataText.LePhat.string_0 = global::DataModel.Util.getDataPath + global::DataText.LePhat.string_2 + ".cus";
				array = global::System.IO.File.ReadAllBytes(global::DataText.LePhat.string_0);
			}
			else if (global::System.IO.File.Exists(global::DataModel.Util.getDataPath + global::DataText.LePhat.string_2 + ".bibe"))
			{
				global::DataText.LePhat.string_0 = global::DataModel.Util.getDataPath + global::DataText.LePhat.string_2 + ".bibe";
				array = global::System.IO.File.ReadAllBytes(global::DataText.LePhat.string_0);
			}
			if (array == null)
			{
				throw new global::System.Exception("không tìm thấy File loại sớ này, xin hãy tải lại loại sớ");
			}
			return array;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00008B74 File Offset: 0x00006D74
		public static global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> longSoClone(global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> loaiSoData)
		{
			if (loaiSoData == null)
			{
				return loaiSoData;
			}
			global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> dictionary = new global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>>();
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>> keyValuePair in loaiSoData)
			{
				global::System.Collections.Generic.Dictionary<int, global::DataText.CellData> dictionary2 = new global::System.Collections.Generic.Dictionary<int, global::DataText.CellData>();
				dictionary.Add(keyValuePair.Key, dictionary2);
				foreach (global::System.Collections.Generic.KeyValuePair<int, global::DataText.CellData> keyValuePair2 in keyValuePair.Value)
				{
					global::DataText.CellData value = keyValuePair2.Value;
					value.ColNoOrg = keyValuePair.Key;
					value.RowNoOrg = keyValuePair2.Key;
					dictionary2.Add(keyValuePair2.Key, value.Clone());
				}
			}
			return dictionary;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00008C5C File Offset: 0x00006E5C
		public static string getNam(string yyyy)
		{
			string str;
			string str2;
			global::DataModel.Util.getCanChiVN(int.Parse(yyyy), out str, out str2);
			return str + " " + str2;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00008C84 File Offset: 0x00006E84
		public static void getChuNho(ref global::System.Collections.Generic.Queue<global::DataText.CellData> rslt, string vn, string value)
		{
			if (global::DataText.LePhat.smethod_2(vn))
			{
				global::DataText.CellData cellData = new global::DataText.CellData();
				cellData.Value = value;
				cellData.TextVNBMK = vn;
				cellData.TextCNBMK = vn;
				rslt.Enqueue(cellData);
				return;
			}
			string text = vn;
			if (!value.Contains("*"))
			{
				text = global::DataText.LePhat.getCN(vn, value ?? "");
			}
			if (text == vn)
			{
				global::DataText.CellData cellData2 = new global::DataText.CellData();
				cellData2.Value = value;
				cellData2.TextVNBMK = vn;
				rslt.Enqueue(cellData2);
				return;
			}
			global::DataText.CellData cellData3 = new global::DataText.CellData();
			cellData3.Value = value;
			int lengthInTextElements = new global::System.Globalization.StringInfo(text).LengthInTextElements;
			if (1 >= lengthInTextElements)
			{
				cellData3.TextVNBMK = vn;
				cellData3.TextCNBMK = text;
				rslt.Enqueue(cellData3);
				return;
			}
			global::System.Globalization.TextElementEnumerator textElementEnumerator = global::System.Globalization.StringInfo.GetTextElementEnumerator(text);
			text = vn;
			while (textElementEnumerator.MoveNext())
			{
				cellData3.TextVNBMK = text;
				cellData3.TextCNBMK = textElementEnumerator.Current.ToString();
				rslt.Enqueue(cellData3);
				text = "";
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00008D78 File Offset: 0x00006F78
		private static bool smethod_2(string string_5)
		{
			int num;
			return int.TryParse(string_5, out num);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00008D90 File Offset: 0x00006F90
		public static string getCN(string vn, string nguCanh)
		{
			if (string.IsNullOrEmpty(vn))
			{
				return vn;
			}
			if (!string.IsNullOrEmpty(nguCanh))
			{
				nguCanh = nguCanh.Replace("$", "").Replace("@", "").Replace("*", "").ToLower();
			}
			if (!global::DataText.LePhat.getDic.ContainsKey(vn.ToLower()))
			{
				return vn;
			}
			global::System.Collections.Generic.List<global::DataModel.Entities.VnChinese> list = global::DataText.LePhat.getDic[vn.ToLower()];
			if (list.Count > 0)
			{
				foreach (global::DataModel.Entities.VnChinese vnChinese in list)
				{
					if (!string.IsNullOrEmpty(vnChinese.chinese) && !string.IsNullOrEmpty(vnChinese.nguCanh) && vnChinese.nguCanh == nguCanh)
					{
						return vnChinese.chinese;
					}
				}
				return list[0].chinese;
			}
			return vn;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00008E94 File Offset: 0x00007094
		public static string getChuNomMM(string m)
		{
			return global::System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(global::DataText.LePhat.smethod_4(m).ToLower());
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00008EBC File Offset: 0x000070BC
		public static string getChuNomDD(string day)
		{
			return global::System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(global::DataText.LePhat.smethod_3(day).ToLower());
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00008EE4 File Offset: 0x000070E4
		public static string getChuNomYYYY(string age)
		{
			return global::System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(global::DataText.LePhat.smethod_5(age).ToLower());
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00008F0C File Offset: 0x0000710C
		private static string smethod_3(string string_5)
		{
			uint num = global::Class10.smethod_0(string_5);
			if (num > 0x340CA71CU)
			{
				if (num <= 0x89F29333U)
				{
					if (num <= 0x3C0CB3B4U)
					{
						if (num != 0x360CAA42U)
						{
							if (num != 0x370CABD5U)
							{
								if (num == 0x3C0CB3B4U)
								{
									if (string_5 == "9")
									{
										return "SƠ CỬU";
									}
								}
							}
							else if (string_5 == "2")
							{
								return "SƠ NHỊ";
							}
						}
						else if (string_5 == "3")
						{
							return "SƠ TAM";
						}
					}
					else if (num > 0x87F05176U)
					{
						if (num == 0x88F291A0U)
						{
							if (string_5 == "25")
							{
								return "NHỊ THẬP NGŨ";
							}
						}
						else if (num == 0x89F29333U && string_5 == "24")
						{
							return "NHỊ THẬP TỨ";
						}
					}
					else if (num != 0x3D0CB547U)
					{
						if (num == 0x87F05176U && string_5 == "30")
						{
							return "TAM THẬP";
						}
					}
					else if (string_5 == "8")
					{
						return "SƠ BÁT";
					}
				}
				else if (num <= 0x8DF2997FU)
				{
					if (num > 0x8BF29659U)
					{
						if (num != 0x8CF297ECU)
						{
							if (num == 0x8DF2997FU)
							{
								if (string_5 == "20")
								{
									return "NHỊ THẬP";
								}
							}
						}
						else if (string_5 == "21")
						{
							return "NHỊ THẬP NHẤT";
						}
					}
					else if (num != 0x8AF294C6U)
					{
						if (num == 0x8BF29659U)
						{
							if (string_5 == "26")
							{
								return "NHỊ THẬP LỤC";
							}
						}
					}
					else if (string_5 == "27")
					{
						return "NHỊ THẬP THẤT";
					}
				}
				else if (num <= 0x8FF29CA5U)
				{
					if (num == 0x8EF29B12U)
					{
						if (string_5 == "23")
						{
							return "NHỊ THẬP TAM";
						}
					}
					else if (num == 0x8FF29CA5U)
					{
						if (string_5 == "22")
						{
							return "NHỊ THẬP NHỊ";
						}
					}
				}
				else if (num != 0x94F2A484U)
				{
					if (num == 0x95F2A617U)
					{
						if (string_5 == "28")
						{
							return "NHỊ THẬP BÁT";
						}
					}
				}
				else if (string_5 == "29")
				{
					return "NHỊ THẬP CỬU";
				}
			}
			else if (num > 0x1BEB2A44U)
			{
				if (num > 0x300CA0D0U)
				{
					if (num > 0x320CA3F6U)
					{
						if (num != 0x330CA589U)
						{
							if (num == 0x340CA71CU && string_5 == "1")
							{
								return "SƠ NHẤT";
							}
						}
						else if (string_5 == "6")
						{
							return "SƠ LỤC";
						}
					}
					else if (num == 0x310CA263U)
					{
						if (string_5 == "4")
						{
							return "SƠ TỨ";
						}
					}
					else if (num == 0x320CA3F6U)
					{
						if (string_5 == "7")
						{
							return "SƠ THẤT";
						}
					}
				}
				else if (num <= 0x1DEB2D6AU)
				{
					if (num == 0x1CEB2BD7U)
					{
						if (string_5 == "11")
						{
							return "THẬP NHẤT";
						}
					}
					else if (num == 0x1DEB2D6AU)
					{
						if (string_5 == "12")
						{
							return "THẬP NHỊ";
						}
					}
				}
				else if (num != 0x1EEB2EFDU)
				{
					if (num == 0x300CA0D0U && string_5 == "5")
					{
						return "SƠ NGŨ";
					}
				}
				else if (string_5 == "13")
				{
					return "THẬP TAM";
				}
			}
			else if (num > 0x17EB23F8U)
			{
				if (num > 0x19EB271EU)
				{
					if (num != 0x1AEB28B1U)
					{
						if (num == 0x1BEB2A44U && string_5 == "10")
						{
							return "SƠ THẬP";
						}
					}
					else if (string_5 == "17")
					{
						return "THẬP THẤT";
					}
				}
				else if (num != 0x18EB258BU)
				{
					if (num == 0x19EB271EU)
					{
						if (string_5 == "16")
						{
							return "THẬP LỤC";
						}
					}
				}
				else if (string_5 == "15")
				{
					return "THẬP NGŨ";
				}
			}
			else if (num != 0x13EB1DACU)
			{
				if (num == 0x14EB1F3FU)
				{
					if (string_5 == "19")
					{
						return "THẬP CỬU";
					}
				}
				else if (num == 0x17EB23F8U && string_5 == "14")
				{
					return "THẬP TỨ";
				}
			}
			else if (string_5 == "18")
			{
				return "THẬP BÁT";
			}
			return string_5;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00009344 File Offset: 0x00007544
		private static string smethod_4(string string_5)
		{
			uint num = global::Class10.smethod_0(string_5);
			if (num <= 0x320CA3F6U)
			{
				if (num > 0x1DEB2D6AU)
				{
					if (num == 0x300CA0D0U)
					{
						if (string_5 == "5")
						{
							return "NGŨ";
						}
					}
					else if (num != 0x310CA263U)
					{
						if (num == 0x320CA3F6U && string_5 == "7")
						{
							return "THẤT";
						}
					}
					else if (string_5 == "4")
					{
						return "TỨ";
					}
				}
				else if (num == 0x1BEB2A44U)
				{
					if (string_5 == "10")
					{
						return "THẬP";
					}
				}
				else if (num != 0x1CEB2BD7U)
				{
					if (num == 0x1DEB2D6AU)
					{
						if (string_5 == "12")
						{
							return "THẬP NHỊ";
						}
					}
				}
				else if (string_5 == "11")
				{
					return "THẬP NHẤT";
				}
			}
			else if (num <= 0x360CAA42U)
			{
				if (num == 0x330CA589U)
				{
					if (string_5 == "6")
					{
						return "LỤC";
					}
				}
				else if (num == 0x340CA71CU)
				{
					if (string_5 == "1")
					{
						return "CHÍNH";
					}
				}
				else if (num == 0x360CAA42U && string_5 == "3")
				{
					return "TAM";
				}
			}
			else if (num == 0x370CABD5U)
			{
				if (string_5 == "2")
				{
					return "NHỊ";
				}
			}
			else if (num == 0x3C0CB3B4U)
			{
				if (string_5 == "9")
				{
					return "CỬU";
				}
			}
			else if (num == 0x3D0CB547U)
			{
				if (string_5 == "8")
				{
					return "BÁT";
				}
			}
			return string_5;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000094D8 File Offset: 0x000076D8
		private static string smethod_5(string string_5)
		{
			uint num = global::Class10.smethod_0(string_5);
			if (num <= 0x86E14559U)
			{
				if (num > 0x1BEB2A44U)
				{
					if (num > 0x6433CFE3U)
					{
						if (num > 0x6D361CA5U)
						{
							if (num <= 0x83E140A0U)
							{
								if (num != 0x6F33E134U)
								{
									if (num != 0x7033E2C7U)
									{
										if (num == 0x83E140A0U)
										{
											if (string_5 == "50")
											{
												return "NGŨ THẬP";
											}
										}
									}
									else if (string_5 == "109")
									{
										return "NHẤT BÁCH CỬU";
									}
								}
								else if (string_5 == "108")
								{
									return "NHẤT BÁCH BÁT";
								}
							}
							else if (num > 0x85E143C6U)
							{
								if (num != 0x85F04E50U)
								{
									if (num == 0x86E14559U)
									{
										if (string_5 == "53")
										{
											return "NGŨ THẬP TAM";
										}
									}
								}
								else if (string_5 == "32")
								{
									return "TAM THẬP NHỊ";
								}
							}
							else if (num == 0x84E14233U)
							{
								if (string_5 == "51")
								{
									return "NGŨ THẬP NHẤT";
								}
							}
							else if (num == 0x85E143C6U)
							{
								if (string_5 == "52")
								{
									return "NGŨ THẬP NHỊ";
								}
							}
						}
						else if (num > 0x6733D49CU)
						{
							if (num <= 0x6933D7C2U)
							{
								if (num == 0x6833D62FU)
								{
									if (string_5 == "101")
									{
										return "NHẤT BÁCH NHẤT";
									}
								}
								else if (num == 0x6933D7C2U && string_5 == "102")
								{
									return "NHẤT BÁCH NHỊ";
								}
							}
							else if (num == 0x6A33D955U)
							{
								if (string_5 == "103")
								{
									return "NHẤT BÁCH TAM";
								}
							}
							else if (num == 0x6D361CA5U && string_5 == "110")
							{
								return "NHẤT BÁCH THẬP";
							}
						}
						else if (num != 0x6533D176U)
						{
							if (num != 0x6633D309U)
							{
								if (num == 0x6733D49CU && string_5 == "100")
								{
									return "NHẤT BÁCH";
								}
							}
							else if (string_5 == "107")
							{
								return "NHẤT BÁCH THẤT";
							}
						}
						else if (string_5 == "106")
						{
							return "NHẤT BÁCH LỤC";
						}
					}
					else if (num > 0x330CA589U)
					{
						if (num > 0x370CABD5U)
						{
							if (num <= 0x3D0CB547U)
							{
								if (num != 0x3C0CB3B4U)
								{
									if (num == 0x3D0CB547U)
									{
										if (string_5 == "8")
										{
											return "BÁT";
										}
									}
								}
								else if (string_5 == "9")
								{
									return "CỬU";
								}
							}
							else if (num == 0x6333CE50U)
							{
								if (string_5 == "104")
								{
									return "NHẤT BÁCH TỨ";
								}
							}
							else if (num == 0x6433CFE3U)
							{
								if (string_5 == "105")
								{
									return "NHẤT BÁCH NGŨ";
								}
							}
						}
						else if (num == 0x340CA71CU)
						{
							if (string_5 == "1")
							{
								return "NHẤT";
							}
						}
						else if (num != 0x360CAA42U)
						{
							if (num == 0x370CABD5U && string_5 == "2")
							{
								return "NHỊ";
							}
						}
						else if (string_5 == "3")
						{
							return "TAM";
						}
					}
					else if (num <= 0x1EEB2EFDU)
					{
						if (num != 0x1CEB2BD7U)
						{
							if (num != 0x1DEB2D6AU)
							{
								if (num == 0x1EEB2EFDU && string_5 == "13")
								{
									return "THẬP TAM";
								}
							}
							else if (string_5 == "12")
							{
								return "THẬP NHỊ";
							}
						}
						else if (string_5 == "11")
						{
							return "THẬP NHẤT";
						}
					}
					else if (num <= 0x310CA263U)
					{
						if (num == 0x300CA0D0U)
						{
							if (string_5 == "5")
							{
								return "NGŨ";
							}
						}
						else if (num == 0x310CA263U)
						{
							if (string_5 == "4")
							{
								return "TỨ";
							}
						}
					}
					else if (num != 0x320CA3F6U)
					{
						if (num == 0x330CA589U && string_5 == "6")
						{
							return "LỤC";
						}
					}
					else if (string_5 == "7")
					{
						return "THẤT";
					}
				}
				else if (num > 0x14E8E0A8U)
				{
					if (num <= 0x18E8E6F4U)
					{
						if (num <= 0x15E8E23BU)
						{
							if (num != 0x14EB1F3FU)
							{
								if (num != 0x14FEA6F7U)
								{
									if (num == 0x15E8E23BU)
									{
										if (string_5 == "60")
										{
											return "LỤC THẬP";
										}
									}
								}
								else if (string_5 == "99")
								{
									return "CỬU THẬP CỬU";
								}
							}
							else if (string_5 == "19")
							{
								return "THẬP CỬU";
							}
						}
						else if (num <= 0x17E8E561U)
						{
							if (num != 0x16E8E3CEU)
							{
								if (num == 0x17E8E561U)
								{
									if (string_5 == "62")
									{
										return "LỤC THẬP NHỊ";
									}
								}
							}
							else if (string_5 == "63")
							{
								return "LỤC THẬP TAM";
							}
						}
						else if (num != 0x17EB23F8U)
						{
							if (num == 0x18E8E6F4U)
							{
								if (string_5 == "65")
								{
									return "LỤC THẬP NGŨ";
								}
							}
						}
						else if (string_5 == "14")
						{
							return "THẬP TỨ";
						}
					}
					else if (num <= 0x19EB271EU)
					{
						if (num != 0x18EB258BU)
						{
							if (num == 0x19E8E887U)
							{
								if (string_5 == "64")
								{
									return "LỤC THẬP TỨ";
								}
							}
							else if (num == 0x19EB271EU && string_5 == "16")
							{
								return "THẬP LỤC";
							}
						}
						else if (string_5 == "15")
						{
							return "THẬP NGŨ";
						}
					}
					else if (num > 0x1AEB28B1U)
					{
						if (num != 0x1BE8EBADU)
						{
							if (num == 0x1BEB2A44U)
							{
								if (string_5 == "10")
								{
									return "THẬP";
								}
							}
						}
						else if (string_5 == "66")
						{
							return "LỤC THẬP LỤC";
						}
					}
					else if (num != 0x1AE8EA1AU)
					{
						if (num == 0x1AEB28B1U && string_5 == "17")
						{
							return "THẬP THẤT";
						}
					}
					else if (string_5 == "67")
					{
						return "LỤC THẬP THẤT";
					}
				}
				else if (num <= 0xCE8D410U)
				{
					if (num > 0x9FE95A6U)
					{
						if (num == 0xAFE9739U)
						{
							if (string_5 == "97")
							{
								return "CỬU THẬP THẤT";
							}
						}
						else if (num == 0xBFE98CCU)
						{
							if (string_5 == "90")
							{
								return "CỬU THẬP";
							}
						}
						else if (num == 0xCE8D410U && string_5 == "69")
						{
							return "LỤC THẬP CỬU";
						}
					}
					else if (num == 0x7FE9280U)
					{
						if (string_5 == "94")
						{
							return "CỬU THẬP TỨ";
						}
					}
					else if (num != 0x8FE9413U)
					{
						if (num == 0x9FE95A6U && string_5 == "96")
						{
							return "CỬU THẬP LỤC";
						}
					}
					else if (string_5 == "95")
					{
						return "CỬU THẬP NGŨ";
					}
				}
				else if (num <= 0xDFE9BF2U)
				{
					if (num != 0xCFE9A5FU)
					{
						if (num != 0xDE8D5A3U)
						{
							if (num == 0xDFE9BF2U && string_5 == "92")
							{
								return "CỬU THẬP NHỊ";
							}
						}
						else if (string_5 == "68")
						{
							return "LỤC THẬP BÁT";
						}
					}
					else if (string_5 == "91")
					{
						return "CỬU THẬP NHẤT";
					}
				}
				else if (num <= 0x13EB1DACU)
				{
					if (num == 0xEFE9D85U)
					{
						if (string_5 == "93")
						{
							return "CỬU THẬP TAM";
						}
					}
					else if (num == 0x13EB1DACU)
					{
						if (string_5 == "18")
						{
							return "THẬP BÁT";
						}
					}
				}
				else if (num == 0x13FEA564U)
				{
					if (string_5 == "98")
					{
						return "CỬU THẬP BÁT";
					}
				}
				else if (num == 0x14E8E0A8U && string_5 == "61")
				{
					return "LỤC THẬP NHẤT";
				}
			}
			else if (num > 0x8CE14ECBU)
			{
				if (num > 0x8FF05E0EU)
				{
					if (num > 0x91E39541U)
					{
						if (num > 0x95F2A617U)
						{
							if (num <= 0x98E5DEDDU)
							{
								if (num == 0x97E5DD4AU)
								{
									if (string_5 == "78")
									{
										return "THẤT THẬP BÁT";
									}
								}
								else if (num == 0x98E5DEDDU)
								{
									if (string_5 == "79")
									{
										return "THẤT THẬP CỬU";
									}
								}
							}
							else if (num == 0x9901B55AU)
							{
								if (string_5 == "89")
								{
									return "BÁT THẬP CỬU";
								}
							}
							else if (num == 0x9A01B6EDU && string_5 == "88")
							{
								return "BÁT THẬP BÁT";
							}
						}
						else if (num == 0x9201AA55U)
						{
							if (string_5 == "80")
							{
								return "BÁT THẬP";
							}
						}
						else if (num == 0x94F2A484U)
						{
							if (string_5 == "29")
							{
								return "NHỊ THẬP CỬU";
							}
						}
						else if (num == 0x95F2A617U)
						{
							if (string_5 == "28")
							{
								return "NHỊ THẬP BÁT";
							}
						}
					}
					else if (num <= 0x90E393AEU)
					{
						if (num == 0x8FF29CA5U)
						{
							if (string_5 == "22")
							{
								return "NHỊ THẬP NHỊ";
							}
						}
						else if (num == 0x9001A72FU)
						{
							if (string_5 == "82")
							{
								return "BÁT THẬP NHỊ";
							}
						}
						else if (num == 0x90E393AEU)
						{
							if (string_5 == "49")
							{
								return "TỨ THẬP CỬU";
							}
						}
					}
					else if (num > 0x90F05FA1U)
					{
						if (num != 0x9101A8C2U)
						{
							if (num == 0x91E39541U && string_5 == "48")
							{
								return "TỨ THẬP BÁT";
							}
						}
						else if (string_5 == "81")
						{
							return "BÁT THẬP NHẤT";
						}
					}
					else if (num != 0x90E5D245U)
					{
						if (num == 0x90F05FA1U)
						{
							if (string_5 == "39")
							{
								return "TAM THẬP CỬU";
							}
						}
					}
					else if (string_5 == "71")
					{
						return "THẤT THẬP NHẤT";
					}
				}
				else if (num <= 0x8DE5CD8CU)
				{
					if (num <= 0x8CF05955U)
					{
						if (num == 0x8CE38D62U)
						{
							if (string_5 == "45")
							{
								return "TỨ THẬP NGŨ";
							}
						}
						else if (num == 0x8CE5CBF9U)
						{
							if (string_5 == "75")
							{
								return "THẤT THẬP NGŨ";
							}
						}
						else if (num == 0x8CF05955U && string_5 == "35")
						{
							return "TAM THẬP NGŨ";
						}
					}
					else if (num > 0x8D01A276U)
					{
						if (num != 0x8DE38EF5U)
						{
							if (num == 0x8DE5CD8CU)
							{
								if (string_5 == "72")
								{
									return "THẤT THẬP NHỊ";
								}
							}
						}
						else if (string_5 == "44")
						{
							return "TỨ THẬP TỨ";
						}
					}
					else if (num == 0x8CF297ECU)
					{
						if (string_5 == "21")
						{
							return "NHỊ THẬP NHẤT";
						}
					}
					else if (num == 0x8D01A276U)
					{
						if (string_5 == "85")
						{
							return "BÁT THẬP NGŨ";
						}
					}
				}
				else if (num > 0x8EE5CF1FU)
				{
					if (num > 0x8F01A59CU)
					{
						if (num != 0x8FE5D0B2U)
						{
							if (num == 0x8FF05E0EU)
							{
								if (string_5 == "38")
								{
									return "TAM THẬP BÁT";
								}
							}
						}
						else if (string_5 == "70")
						{
							return "THẤT THẬP";
						}
					}
					else if (num == 0x8EF29B12U)
					{
						if (string_5 == "23")
						{
							return "NHỊ THẬP TAM";
						}
					}
					else if (num == 0x8F01A59CU)
					{
						if (string_5 == "83")
						{
							return "BÁT THẬP TAM";
						}
					}
				}
				else if (num != 0x8DF2997FU)
				{
					if (num != 0x8E01A409U)
					{
						if (num == 0x8EE5CF1FU && string_5 == "73")
						{
							return "THẤT THẬP TAM";
						}
					}
					else if (string_5 == "84")
					{
						return "BÁT THẬP TỨ";
					}
				}
				else if (string_5 == "20")
				{
					return "NHỊ THẬP";
				}
			}
			else if (num > 0x89F0549CU)
			{
				if (num > 0x8B019F50U)
				{
					if (num > 0x8BE5CA66U)
					{
						if (num > 0x8BF29659U)
						{
							if (num == 0x8C01A0E3U)
							{
								if (string_5 == "86")
								{
									return "BÁT THẬP LỤC";
								}
							}
							else if (num == 0x8CE14ECBU && string_5 == "59")
							{
								return "NGŨ THẬP CỬU";
							}
						}
						else if (num == 0x8BF057C2U)
						{
							if (string_5 == "34")
							{
								return "TAM THẬP TỨ";
							}
						}
						else if (num == 0x8BF29659U)
						{
							if (string_5 == "26")
							{
								return "NHỊ THẬP LỤC";
							}
						}
					}
					else if (num != 0x8BE14D38U)
					{
						if (num != 0x8BE38BCFU)
						{
							if (num == 0x8BE5CA66U)
							{
								if (string_5 == "74")
								{
									return "THẤT THẬP TỨ";
								}
							}
						}
						else if (string_5 == "46")
						{
							return "TỨ THẬP LỤC";
						}
					}
					else if (string_5 == "58")
					{
						return "NGŨ THẬP BÁT";
					}
				}
				else if (num <= 0x8AE38A3CU)
				{
					if (num == 0x89F29333U)
					{
						if (string_5 == "24")
						{
							return "NHỊ THẬP TỨ";
						}
					}
					else if (num == 0x8AE14BA5U)
					{
						if (string_5 == "57")
						{
							return "NGŨ THẬP THẤT";
						}
					}
					else if (num == 0x8AE38A3CU)
					{
						if (string_5 == "47")
						{
							return "TỨ THẬP THẤT";
						}
					}
				}
				else if (num <= 0x8AF0562FU)
				{
					if (num != 0x8AE5C8D3U)
					{
						if (num == 0x8AF0562FU && string_5 == "37")
						{
							return "TAM THẬP THẤT";
						}
					}
					else if (string_5 == "77")
					{
						return "THẤT THẬP THẤT";
					}
				}
				else if (num == 0x8AF294C6U)
				{
					if (string_5 == "27")
					{
						return "NHỊ THẬP THẤT";
					}
				}
				else if (num == 0x8B019F50U && string_5 == "87")
				{
					return "BÁT THẬP THẤT";
				}
			}
			else if (num <= 0x88E1487FU)
			{
				if (num <= 0x87E146ECU)
				{
					if (num != 0x86E383F0U)
					{
						if (num == 0x86F04FE3U)
						{
							if (string_5 == "33")
							{
								return "TAM THẬP TAM";
							}
						}
						else if (num == 0x87E146ECU)
						{
							if (string_5 == "54")
							{
								return "NGŨ THẬP TỨ";
							}
						}
					}
					else if (string_5 == "43")
					{
						return "TỨ THẬP TAM";
					}
				}
				else if (num != 0x87E38583U)
				{
					if (num != 0x87F05176U)
					{
						if (num == 0x88E1487FU && string_5 == "55")
						{
							return "NGŨ THẬP NGŨ";
						}
					}
					else if (string_5 == "30")
					{
						return "TAM THẬP";
					}
				}
				else if (string_5 == "42")
				{
					return "TỨ THẬP NHỊ";
				}
			}
			else if (num <= 0x88F291A0U)
			{
				if (num == 0x88E38716U)
				{
					if (string_5 == "41")
					{
						return "TỨ THẬP NHẤT";
					}
				}
				else if (num != 0x88F05309U)
				{
					if (num == 0x88F291A0U)
					{
						if (string_5 == "25")
						{
							return "NHỊ THẬP NGŨ";
						}
					}
				}
				else if (string_5 == "31")
				{
					return "TAM THẬP NHẤT";
				}
			}
			else if (num > 0x89E388A9U)
			{
				if (num == 0x89E5C740U)
				{
					if (string_5 == "76")
					{
						return "THẤT THẬP LỤC";
					}
				}
				else if (num == 0x89F0549CU)
				{
					if (string_5 == "36")
					{
						return "TAM THẬP LỤC";
					}
				}
			}
			else if (num == 0x89E14A12U)
			{
				if (string_5 == "56")
				{
					return "NGŨ THẬP LỤC";
				}
			}
			else if (num == 0x89E388A9U)
			{
				if (string_5 == "40")
				{
					return "TỨ THẬP";
				}
			}
			return string_5;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00004254 File Offset: 0x00002454
		public LePhat()
		{
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000A420 File Offset: 0x00008620
		// Note: this type is marked as 'beforefieldinit'.
		static LePhat()
		{
		}

		// Token: 0x0400004D RID: 77
		private static char char_0 = '±';

		// Token: 0x0400004E RID: 78
		private static string string_0;

		// Token: 0x0400004F RID: 79
		private static string string_1;

		// Token: 0x04000050 RID: 80
		private static global::DataModel.Year year_0;

		// Token: 0x04000051 RID: 81
		public static int SoNo;

		// Token: 0x04000052 RID: 82
		private static string string_2;

		// Token: 0x04000053 RID: 83
		private static global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<global::DataText.CellData>> queue_0;

		// Token: 0x04000054 RID: 84
		private static string string_3;

		// Token: 0x04000055 RID: 85
		private static string string_4;

		// Token: 0x04000056 RID: 86
		private static global::DataText.LongSoData longSoData_0;

		// Token: 0x04000057 RID: 87
		private static global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.List<global::DataModel.Entities.VnChinese>> dictionary_0;

		// Token: 0x04000058 RID: 88
		private static global::System.Collections.Generic.Dictionary<string, string> dictionary_1;
	}
}
