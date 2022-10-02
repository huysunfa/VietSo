using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo
{
	public class PrDocument :  PrintBase
	{
		// Token: 0x0600013F RID: 319 RVA: 0x00006BFC File Offset: 0x00004DFC
		public void fFmlCN(string pNf, float fontSize, global::System.Drawing.FontStyle style)
		{
			global::System.Drawing.Text.PrivateFontCollection privateFontCollection = new global::System.Drawing.Text.PrivateFontCollection();
			privateFontCollection.AddFontFile(pNf);
			this.fontFamily_0 = privateFontCollection.Families[0];
			this.font_0 = new global::System.Drawing.Font(this.fontFamily_0, fontSize, style, global::System.Drawing.GraphicsUnit.Point);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00006C38 File Offset: 0x00004E38
		public void fFmlVN(string ff, float fontSize, global::System.Drawing.FontStyle style)
		{
			this.font_1 = new global::System.Drawing.Font(ff, fontSize, style, global::System.Drawing.GraphicsUnit.Point);
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00006C54 File Offset: 0x00004E54
		// (set) Token: 0x06000142 RID: 322 RVA: 0x00006C68 File Offset: 0x00004E68
		public string PagodaID
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00006C7C File Offset: 0x00004E7C
		// (set) Token: 0x06000144 RID: 324 RVA: 0x00006C90 File Offset: 0x00004E90
		public string PagodaName
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_1 = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00006CA4 File Offset: 0x00004EA4
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00006CB8 File Offset: 0x00004EB8
		public string PagodaAddress
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.string_2;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.string_2 = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00006CCC File Offset: 0x00004ECC
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00006DBC File Offset: 0x00004FBC
		public string NgachSo
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.string_3) && global::System.IO.File.Exists(Util.getDataPath + "ngachso.ngs"))
				{
					global::System.Data.DataTable dataTable =Security.readFile<global::System.Data.DataTable>(Util.getDataPath + "ngachso.ngs");
					if (dataTable != null && 0 < dataTable.Rows.Count && dataTable.Columns.Contains("NgSChecked") && dataTable.Columns.Contains("NgSContent"))
					{
						global::System.Data.DataRow[] array = dataTable.Select("NgSChecked='True'");
						if (array != null && array.Length != 0)
						{
							object obj = array[0]["NgSContent"];
							string text;
							if (obj != null)
							{
								if ((text = obj.ToString()) != null)
								{
									goto IL_A9;
								}
							}
							text = "";
							IL_A9:
							this.string_3 = text;
						}
						else
						{
							this.string_3 = "";
						}
					}
					else
					{
						this.string_3 = "";
						global::System.IO.File.Delete(Util.getDataPath + "ngachso.ngs");
					}
				}
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00006DD0 File Offset: 0x00004FD0
		// (set) Token: 0x0600014A RID: 330 RVA: 0x00006DE4 File Offset: 0x00004FE4
		public bool IsPrintMaSo
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (set) Token: 0x0600014B RID: 331 RVA: 0x00006DF8 File Offset: 0x00004FF8
		public string LoaiSo
		{
			set
			{
				this.string_4 = value;
				this.clearLongSo();
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00006E14 File Offset: 0x00005014
		public void clearLongSo()
		{
			 LePhatBibe.clearLongSo();
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00006E28 File Offset: 0x00005028
		public LongSoData LoaiSoData
		{
			get
			{
				return LePhatBibe.getLongSo(this.string_4);
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00006E40 File Offset: 0x00005040
		public override global::System.Drawing.Bitmap PreView()
		{
			int width = global::System.Convert.ToInt32((float)this.LoaiSoData.PageWidth * this.scaleFactor);
			int height = global::System.Convert.ToInt32((float)this.LoaiSoData.PageHeight * this.scaleFactor);
			global::System.Drawing.Bitmap bitmap = new global::System.Drawing.Bitmap(width, height);
			global::System.Drawing.Graphics graphics = global::System.Drawing.Graphics.FromImage(bitmap);
			this.Draw(graphics, false);
			graphics.Dispose();
			return bitmap;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00006E9C File Offset: 0x0000509C
		public global::System.Drawing.Bitmap GetBitmap()
		{
			int pageWidth = this.LoaiSoData.PageWidth;
			int pageHeight = this.LoaiSoData.PageHeight;
			global::System.Drawing.Bitmap bitmap = new global::System.Drawing.Bitmap(pageWidth, pageHeight);
			global::System.Drawing.Graphics graphics = global::System.Drawing.Graphics.FromImage(bitmap);
			this.Draw(graphics, true);
			graphics.Dispose();
			return bitmap;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00006EDC File Offset: 0x000050DC
		protected override int GetPaperHeight()
		{
			if (this.LoaiSoData == null)
			{
				return 0x491;
			}
			return this.LoaiSoData.PageHeight;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00006F04 File Offset: 0x00005104
		protected override int GetPaperWidth()
		{
			if (this.LoaiSoData == null)
			{
				return 0x73A;
			}
			return this.LoaiSoData.PageWidth;
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00006F2C File Offset: 0x0000512C
		private decimal writeHeightAvalable
		{
			get
			{
				return this.LoaiSoData.PageHeight - ((decimal)this.LoaiSoData.PagePaddingTop * 5m + (decimal)this.LoaiSoData.PagePaddingBottom * 5m);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00006F80 File Offset: 0x00005180
		private decimal writeWidthAvalable
		{
			get
			{
				return (decimal)this.LoaiSoData.PageWidth - (decimal)((decimal)this.LoaiSoData.PagePaddingLeft * 5m + (decimal)this.LoaiSoData.PagePaddingRight * 5m);
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00006FD4 File Offset: 0x000051D4
		public override void Draw(global::System.Drawing.Graphics grp, bool isPrint = false)
		{
			if (this.LoaiSoData == null)
			{
				return;
			}
			grp.Clear(global::System.Drawing.Color.White);
			if (!isPrint)
			{
				grp.ScaleTransform(this.scaleFactor, this.scaleFactor);
			}
			float num = (float)this.writeHeightAvalable / (float)this.LoaiSoData.LgSo[0].Count;
			float num2 = (float)this.writeWidthAvalable / (float)this.LoaiSoData.LgSo.Count;
			if (this.IsPrintMaSo && base.Fml != null)
			{
				this.method_17(grp, (float)this.LoaiSoData.PageWidth - num2 * 1.8f, (float)this.LoaiSoData.PageHeight - num * 1.8f, num2, num, base.Fml.SoNo.ToString(), global::System.Drawing.Color.Black, null, global::System.Drawing.StringAlignment.Far);
			}
			float float_ = (float)this.LoaiSoData.PageWidth - (float)this.LoaiSoData.PagePaddingRight * 5f;
			global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary_ =LePhatBibe.longSoClone(this.LoaiSoData.LgSo);
			string string_ = "";
			if (!string.IsNullOrEmpty(this.PagodaID) && base.Fml != null)
			{
				this.method_11(dictionary_, ref string_);
			}
			this.method_13(dictionary_);
			this.method_9(dictionary_, string_);
			if (this.method_2(this.string_4) && base.Fml != null)
			{
				this.method_3(ref dictionary_, ref num2, this.method_5(grp, dictionary_));
			}
			this.method_6(grp, dictionary_, float_, (float)this.LoaiSoData.PagePaddingTop * 5f, num, num2, isPrint, this.writeHeightAvalable);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00007168 File Offset: 0x00005368
		private bool method_2(string string_5)
		{
			if (!global::System.IO.File.Exists(Util.getDataPath + "TinChuArea.txt"))
			{
				return false;
			}
			string text = global::System.IO.File.ReadAllText(Util.getDataPath + "TinChuArea.txt");
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			string[] array = text.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Trim().Equals(string_5, global::System.StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000071E0 File Offset: 0x000053E0
		private void method_3(ref global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary_0, ref float float_0, float float_1)
		{
			int num = 0;
			int num2 = 0;
			this.method_14(dictionary_0, out num, out num2, "$Tinchu");
			if (num == -1 && num2 == -1)
			{
				return;
			}
			int num3 = 0;
			int i = num2 - 1;
			while (i < dictionary_0.Count)
			{
				if (!this.method_10(dictionary_0[i]))
				{
					if (0xA >= num2 - i)
					{
						i--;
						continue;
					}
				}
				else
				{
					num3 = i;
				}
				IL_4F:
				if (num3 == 0)
				{
					return;
				}
				if (float_1 < float_0)
				{
					return;
				}
				this.method_4(ref dictionary_0, num3);
				float_0 = (float)this.writeWidthAvalable / (float)dictionary_0.Count;
				this.method_3(ref dictionary_0, ref float_0, float_1);
				return;
			}
			goto IL_4F;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00007270 File Offset: 0x00005470
		private void method_4(ref global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary_0, int int_0)
		{
			if (int_0 < 0)
			{
				return;
			}
			bool flag = false;
			global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary = new global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>>();
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.Dictionary<int,CellData>> keyValuePair in dictionary_0)
			{
				int num = keyValuePair.Key;
				if (int_0 != num)
				{
					if (!flag)
					{
						num--;
					}
					global::System.Collections.Generic.Dictionary<int,CellData> dictionary2 = new global::System.Collections.Generic.Dictionary<int,CellData>();
					dictionary.Add(num, dictionary2);
					using (global::System.Collections.Generic.Dictionary<int,CellData>.Enumerator enumerator2 = keyValuePair.Value.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							global::System.Collections.Generic.KeyValuePair<int,CellData> keyValuePair2 = enumerator2.Current;
							dictionary2.Add(keyValuePair2.Key, keyValuePair2.Value);
						}
						continue;
					}
				}
				flag = true;
			}
			dictionary_0 = dictionary;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000734C File Offset: 0x0000554C
		private float method_5(global::System.Drawing.Graphics graphics_0, global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary_0)
		{
			float num = 0f;
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.Dictionary<int,CellData>> keyValuePair in dictionary_0)
			{
				foreach (global::System.Collections.Generic.KeyValuePair<int,CellData> keyValuePair2 in keyValuePair.Value)
				{
					 CellData value = keyValuePair2.Value;
					string text = value.Text(this.isVN);
					if (!string.IsNullOrWhiteSpace(text) && !text.Contains(" "))
					{
						global::System.Drawing.SizeF sizeF = graphics_0.MeasureString(text, this.method_20(value, this.isVN));
						if (num < sizeF.Width)
						{
							num = sizeF.Width;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00007438 File Offset: 0x00005638
		private void method_6(global::System.Drawing.Graphics graphics_0, global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary_0, float float_0, float float_1, float float_2, float float_3, bool bool_1, decimal decimal_0)
		{
			int num = 0;
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.Dictionary<int,CellData>> keyValuePair in dictionary_0)
			{
				int key = keyValuePair.Key;
				num++;
				float_0 -= float_3;
				float num2 = float_1;
				global::System.Collections.Generic.Dictionary<int,CellData> value = keyValuePair.Value;
				for (int i = 0; i < value.Count; i++)
				{
					int num3 = value.Keys.ElementAt(i);
					 CellData cellData = value[num3];
					if ((double)((float)((int)decimal_0) + float_1) > global::System.Math.Round((double)num2))
					{
						if (!bool_1)
						{
							this.method_16(graphics_0, float_0, num2, float_3, float_2, num3.ToString() + ":" + key.ToString());
						}
						object value2 = cellData.Value;
						if (value2 == null)
						{
							goto IL_B5;
						}
						string text;
						if ((text = value2.ToString()) == null)
						{
							goto IL_B5;
						}
						IL_BB:
						if (!text.Contains("@"))
						{
							object value3 = cellData.Value;
							if (value3 == null)
							{
								goto IL_DD;
							}
							string text2;
							if ((text2 = value3.ToString()) == null)
							{
								goto IL_DD;
							}
							IL_E3:
							if (text2.Contains("$"))
							{
								goto IL_EF;
							}
							goto IL_101;
							IL_DD:
							text2 = "";
							goto IL_E3;
						}
						goto IL_EF;
						IL_101:
						this.method_8(cellData, num3, key, float_0, num2, float_2, float_3);
						this.method_7(graphics_0, float_0, num2, float_3, float_2, cellData);
						num2 += float_2;
						goto IL_12A;
						IL_EF:
						if (!bool_1)
						{
							this.method_15(graphics_0, float_0, num2, float_3, float_2);
							goto IL_101;
						}
						goto IL_101;
						IL_B5:
						text = "";
						goto IL_BB;
					}
					IL_12A:;
				}
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000075BC File Offset: 0x000057BC
		private void method_7(global::System.Drawing.Graphics graphics_0, float float_0, float float_1, float float_2, float float_3,CellData cellData_0)
		{
			string language = this.LoaiSoData.Language;
			if (language == "cbxSongNgu")
			{
				this.method_21(graphics_0, float_0, float_1, float_2, float_3, cellData_0);
				return;
			}
			if (!(language == "cbxChuViet") && !(language == "cbxChuTrung"))
			{
				this.method_19(graphics_0, float_0, float_1, float_2, float_3, cellData_0);
				return;
			}
			this.method_18(graphics_0, float_0, float_1, float_2, float_3, cellData_0);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000762C File Offset: 0x0000582C
		private void method_8( CellData cellData_0, int int_0, int int_1, float float_0, float float_1, float float_2, float float_3)
		{
			cellData_0.Rct = new global::System.Drawing.RectangleF(this.scaleFactor * float_0, this.scaleFactor * float_1, this.scaleFactor * float_3, this.scaleFactor * float_2);
			cellData_0.RowNo = int_0;
			cellData_0.ColNo = int_1;
			string key = int_0.ToString() + ":" + int_1.ToString();
			if (this.LongSoLocation.ContainsKey(key))
			{
				this.LongSoLocation[key] = cellData_0;
				return;
			}
			this.LongSoLocation.Add(key, cellData_0);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000076B8 File Offset: 0x000058B8
		private void method_9(global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary_0, string string_5)
		{
			for (int i = 0; i < dictionary_0.Count; i++)
			{
				global::System.Collections.Generic.Dictionary<int,CellData> dictionary = dictionary_0[dictionary_0.Keys.ElementAt(i)];
				int j = 0;
				while (j < dictionary.Count)
				{
					int key = dictionary.Keys.ElementAt(j);
					 CellData cellData = dictionary[key];
					object value = cellData.Value;
					if (value == null)
					{
						goto IL_4D;
					}
					string text;
					if ((text = value.ToString()) == null)
					{
						goto IL_4D;
					}
					IL_53:
					if (text.Contains("@"))
					{
						object value2 = cellData.Value;
						if (value2 == null)
						{
							goto IL_79;
						}
						string text2;
						if ((text2 = value2.ToString()) == null)
						{
							goto IL_79;
						}
						IL_7F:
						global::System.Collections.Generic.Queue< CellData> queue = this.method_24(text2.ToLower(), string_5);
						int num = j;
						bool flag = false;
						while (queue.Count > 0)
						{
							 CellData cellData2 = queue.Dequeue();
							 CellData cellData3 = dictionary[dictionary.Keys.ElementAt(j)];
							cellData3.TextCN = cellData2.TextCN;
							cellData3.TextCNBMK = cellData2.TextCNBMK;
							cellData3.TextVN = cellData2.TextVN;
							cellData3.TextVNBMK = cellData2.TextVNBMK;
							cellData3.Value = cellData2.Value;
							if (queue.Count > 0)
							{
								j++;
								if (j < dictionary.Count)
								{
									string str = dictionary[dictionary.Keys.ElementAt(j)].Text(this.isVN);
									object value3 = dictionary[dictionary.Keys.ElementAt(j)].Value;
									if (!string.IsNullOrEmpty(str + ((value3 != null) ? value3.ToString() : null)))
									{
										int num2 = 0;
										for (int k = j; k < dictionary.Count; k++)
										{
											string str2 = dictionary[dictionary.Keys.ElementAt(k)].Text(this.isVN);
											object value4 = dictionary[dictionary.Keys.ElementAt(k)].Value;
											if (string.IsNullOrEmpty(str2 + ((value4 != null) ? value4.ToString() : null)))
											{
												num2 = k;
												IL_214:
												while (j < num2)
												{
													dictionary[dictionary.Keys.ElementAt(num2)] = dictionary[dictionary.Keys.ElementAt(num2 - 1)];
													dictionary[dictionary.Keys.ElementAt(num2 - 1)] = new CellData();
													num2--;
												}
												goto IL_219;
											}
										}
										goto IL_214;
									}
								}
								IL_219:
								if (dictionary.Count == j)
								{
									int num3 = 0;
									for (int l = i + 1; l < dictionary_0.Count; l++)
									{
										if (this.method_10(dictionary_0[dictionary_0.Keys.ElementAt(l)]))
										{
											num3 = l;
											break;
										}
									}
									while (i + 1 < num3)
									{
										global::System.Collections.Generic.Dictionary<int,CellData> dictionary2 = dictionary_0[dictionary_0.Keys.ElementAt(num3)];
										global::System.Collections.Generic.Dictionary<int,CellData> dictionary3 = dictionary_0[dictionary_0.Keys.ElementAt(num3 - 1)];
										for (int m = 0; m < dictionary2.Count; m++)
										{
											dictionary2[dictionary2.Keys.ElementAt(m)] = dictionary3[dictionary3.Keys.ElementAt(m)];
											dictionary3[dictionary3.Keys.ElementAt(m)] = new CellData();
										}
										num3--;
									}
									j = num;
									i++;
									flag = true;
									dictionary = dictionary_0[dictionary_0.Keys.ElementAt(i)];
								}
							}
						}
						if (!flag)
						{
							goto IL_32C;
						}
						break;
						IL_79:
						text2 = "";
						goto IL_7F;
					}
					IL_32C:
					j++;
					continue;
					IL_4D:
					text = "";
					goto IL_53;
				}
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00007A14 File Offset: 0x00005C14
		private bool method_10(global::System.Collections.Generic.Dictionary<int,CellData> dictionary_0)
		{
			using (global::System.Collections.Generic.Dictionary<int,CellData>.Enumerator enumerator = dictionary_0.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					global::System.Collections.Generic.KeyValuePair<int,CellData> keyValuePair = enumerator.Current;
					 CellData value = keyValuePair.Value;
					if ((value.Value != null && !((string)value.Value == "")) || !string.IsNullOrEmpty(value.TextCN) || !string.IsNullOrEmpty(value.TextVN))
					{
						return false;
					}
				}
				return true;
			}
			bool result;
			return result;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00007AA4 File Offset: 0x00005CA4
		private void method_11(global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary_0, ref string string_5)
		{
			string text = "";
			global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue< CellData>> tinChu =LePhatBibe.getTinChu(this.PagodaID, base.Fml, ref text, ref string_5, this.IsNextYear);
			int num;
			int num2;
			this.method_14(dictionary_0, out num, out num2, "$Giachu");
			if (0 <= num && 0 <= num2)
			{
				 CellData cellData = dictionary_0[num2][num];
				cellData.Value = "$Giachu";
				cellData.TextVNBMK = text;
				cellData.TextCNBMK = text;
				dictionary_0[num2][num] = cellData;
			}
			this.method_12(dictionary_0);
			num = 0;
			num2 = 0;
			this.method_14(dictionary_0, out num, out num2, "$Tinchu");
			if (num == -1)
			{
				if (num2 == -1)
				{
					return;
				}
			}
			int num3 = num;
			int num4 = num2;
			foreach (global::System.Collections.Generic.Queue< CellData> queue in tinChu)
			{
				foreach ( CellData cellData2 in queue)
				{
					if (num4 > 0 && dictionary_0.Count > num4)
					{
						if (dictionary_0[num4].Count <= num3)
						{
							num3 = num;
							num4--;
						}
						string text2 = "$Tinchu";
						object value = dictionary_0[num4][num3].Value;
						if (value == null)
						{
							goto IL_121;
						}
						string value2;
						if ((value2 = value.ToString()) == null)
						{
							goto IL_121;
						}
						IL_127:
						if (text2.Equals(value2, global::System.StringComparison.OrdinalIgnoreCase))
						{
							cellData2.Value = dictionary_0[num4][num3].Value;
						}
						dictionary_0[num4][num3] = cellData2;
						num3++;
						continue;
						IL_121:
						value2 = "";
						goto IL_127;
					}
					throw new global::System.Exception("Số cột không đủ để viết tín chủ");
				}
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00007C74 File Offset: 0x00005E74
		private void method_12(global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary_0)
		{
			global::System.Collections.Generic.List<Person> huongL =LePhatBibe.getHuongL(this.PagodaID, base.Fml);
			if (huongL != null && huongL.Count > 0)
			{
				for (int i = 0; i < dictionary_0.Count; i++)
				{
					global::System.Collections.Generic.Dictionary<int,CellData> dictionary = dictionary_0[i];
					int j = 0;
					while (j < dictionary.Count)
					{
						 CellData cellData = dictionary[j];
						object value = cellData.Value;
						if (value == null)
						{
							goto IL_59;
						}
						string text;
						if ((text = value.ToString()) == null)
						{
							goto IL_59;
						}
						IL_5F:
						if (text.ToLower().Contains("$hlinhten".ToLower()))
						{
							int num = j;
							int num2 = i;
							foreach (Person person in huongL)
							{
								foreach ( CellData cellData2 in LePhatBibe.convertToCell( LePhatBibe.convert2Queue(person.FullName), "*huonglinh"))
								{
									if (num2 > 0 && dictionary_0.Count > num2)
									{
										if (dictionary_0[num2].Count <= num)
										{
											num = j;
											num2--;
										}
										string text2 = "$hlinhten";
										object value2 = dictionary_0[num2][num].Value;
										if (value2 == null)
										{
											goto IL_114;
										}
										string value3;
										if ((value3 = value2.ToString()) == null)
										{
											goto IL_114;
										}
										IL_11A:
										if (text2.Equals(value3, global::System.StringComparison.OrdinalIgnoreCase))
										{
											cellData2.Value = dictionary_0[num2][num].Value;
										}
										dictionary_0[num2][num] = cellData2;
										num++;
										continue;
										IL_114:
										value3 = "";
										goto IL_11A;
									}
									throw new global::System.Exception("Số cột không đủ để viết hương linh");
								}
							}
						}
						object value4 = cellData.Value;
						if (value4 == null)
						{
							goto IL_1AF;
						}
						string text3;
						if ((text3 = value4.ToString()) == null)
						{
							goto IL_1AF;
						}
						IL_1B5:
						if (text3.ToLower().Contains("$hlinhsinh".ToLower()))
						{
							int num3 = j;
							int num4 = i;
							foreach (Person person2 in huongL)
							{
								foreach ( CellData cellData3 in LePhatBibe.convertToCell( LePhatBibe.convert2Queue(person2.Menh), "*hlinhsinh"))
								{
									if (num4 > 0 && dictionary_0.Count > num4)
									{
										if (dictionary_0[num4].Count <= num3)
										{
											num3 = j;
											num4--;
										}
										string text4 = "$hlinhsinh";
										object value5 = dictionary_0[num4][num3].Value;
										if (value5 == null)
										{
											goto IL_26A;
										}
										string value6;
										if ((value6 = value5.ToString()) == null)
										{
											goto IL_26A;
										}
										IL_270:
										if (text4.Equals(value6, global::System.StringComparison.OrdinalIgnoreCase))
										{
											cellData3.Value = dictionary_0[num4][num3].Value;
										}
										dictionary_0[num4][num3] = cellData3;
										num3++;
										continue;
										IL_26A:
										value6 = "";
										goto IL_270;
									}
									throw new global::System.Exception("Số cột không đủ để viết hương linh");
								}
							}
						}
						object value7 = cellData.Value;
						if (value7 == null)
						{
							goto IL_305;
						}
						string text5;
						if ((text5 = value7.ToString()) == null)
						{
							goto IL_305;
						}
						IL_30B:
						if (text5.ToLower().Contains("$hlinhmat".ToLower()))
						{
							int num5 = j;
							int num6 = i;
							foreach (Person person3 in huongL)
							{
								foreach ( CellData cellData4 inLePhat.convertToCell( LePhatBibe.convert2Queue(person3.DaiHanY), "*hlinhmat"))
								{
									if (num6 > 0 && dictionary_0.Count > num6)
									{
										if (dictionary_0[num6].Count <= num5)
										{
											num5 = j;
											num6--;
										}
										string text6 = "$hlinhmat";
										object value8 = dictionary_0[num6][num5].Value;
										if (value8 == null)
										{
											goto IL_3C0;
										}
										string value9;
										if ((value9 = value8.ToString()) == null)
										{
											goto IL_3C0;
										}
										IL_3C6:
										if (text6.Equals(value9, global::System.StringComparison.OrdinalIgnoreCase))
										{
											cellData4.Value = dictionary_0[num6][num5].Value;
										}
										dictionary_0[num6][num5] = cellData4;
										num5++;
										continue;
										IL_3C0:
										value9 = "";
										goto IL_3C6;
									}
									throw new global::System.Exception("Số cột không đủ để viết hương linh");
								}
							}
						}
						object value10 = cellData.Value;
						if (value10 == null)
						{
							goto IL_45B;
						}
						string text7;
						if ((text7 = value10.ToString()) == null)
						{
							goto IL_45B;
						}
						IL_461:
						if (text7.ToLower().Contains("$hlinhtho".ToLower()))
						{
							int num7 = j;
							int num8 = i;
							foreach (Person person4 in huongL)
							{
								foreach ( CellData cellData5 inLePhat.convertToCell( LePhatBibe.convert2Queue( LePhatBibe.getChuNomYYYY(person4.HTho)), "*hlinhtho"))
								{
									if (num8 > 0 && dictionary_0.Count > num8)
									{
										if (dictionary_0[num8].Count <= num7)
										{
											num7 = j;
											num8--;
										}
										string text8 = "$hlinhtho";
										object value11 = dictionary_0[num8][num7].Value;
										if (value11 == null)
										{
											goto IL_51B;
										}
										string value12;
										if ((value12 = value11.ToString()) == null)
										{
											goto IL_51B;
										}
										IL_521:
										if (text8.Equals(value12, global::System.StringComparison.OrdinalIgnoreCase))
										{
											cellData5.Value = dictionary_0[num8][num7].Value;
										}
										dictionary_0[num8][num7] = cellData5;
										num7++;
										continue;
										IL_51B:
										value12 = "";
										goto IL_521;
									}
									throw new global::System.Exception("Số cột không đủ để viết hương linh");
								}
							}
						}
						j++;
						continue;
						IL_45B:
						text7 = "";
						goto IL_461;
						IL_305:
						text5 = "";
						goto IL_30B;
						IL_1AF:
						text3 = "";
						goto IL_1B5;
						IL_59:
						text = "";
						goto IL_5F;
					}
				}
				return;
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00008308 File Offset: 0x00006508
		private void method_13(global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary_0)
		{
			int num;
			int num2;
			this.method_14(dictionary_0, out num, out num2, "$ngachso");
			if (num == -1)
			{
				if (num2 == -1)
				{
					return;
				}
			}
			if (!string.IsNullOrWhiteSpace(this.NgachSo))
			{
				int num3 = num;
				int num4 = num2;
				bool flag = true;
				foreach (string text in Util.getPasteText(this.NgachSo))
				{
					if (num4 <= 0 || dictionary_0.Count <= num4)
					{
						throw new global::System.Exception("Số cột không đủ để viết ngạch sớ");
					}
					if (dictionary_0[num4].Count <= num3)
					{
						num3 = num;
						num4--;
					}
					dictionary_0[num4][num3].Value = null;
					dictionary_0[num4][num3].TextVN = null;
					dictionary_0[num4][num3].TextCN = null;
					if (flag)
					{
						dictionary_0[num4][num3].Value = "$ngachso";
						flag = false;
					}
					else
					{
						dictionary_0[num4][num3].Value = "*ngachso";
					}
					if (text != null && text.Contains("@"))
					{
						dictionary_0[num4][num3].Value = text;
					}
					else
					{
						dictionary_0[num4][num3].TextVNBMK = global::System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
					}
					num3++;
				}
				return;
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000849C File Offset: 0x0000669C
		private void method_14(global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.Dictionary<int,CellData>> dictionary_0, out int int_0, out int int_1, string string_5)
		{
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.Dictionary<int,CellData>> keyValuePair in dictionary_0)
			{
				foreach (global::System.Collections.Generic.KeyValuePair<int,CellData> keyValuePair2 in keyValuePair.Value)
				{
					object value = keyValuePair2.Value.Value;
					if (value == null)
					{
						goto IL_48;
					}
					string text;
					if ((text = value.ToString()) == null)
					{
						goto IL_48;
					}
					IL_4E:
					if (!text.ToLower().Contains(string_5.ToLower()))
					{
						continue;
					}
					int_0 = keyValuePair2.Key;
					int_1 = keyValuePair.Key;
					return;
					IL_48:
					text = "";
					goto IL_4E;
				}
			}
			int_0 = -1;
			int_1 = -1;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00008578 File Offset: 0x00006778
		private void method_15(global::System.Drawing.Graphics graphics_0, float float_0, float float_1, float float_2, float float_3)
		{
			global::System.Drawing.RectangleF rect = new global::System.Drawing.RectangleF(float_0, float_1, float_2, float_3);
			graphics_0.FillRectangle(new global::System.Drawing.SolidBrush(this.color_0), rect);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000085A4 File Offset: 0x000067A4
		private void method_16(global::System.Drawing.Graphics graphics_0, float float_0, float float_1, float float_2, float float_3, string string_5)
		{
			graphics_0.DrawRectangle(global::System.Drawing.Pens.WhiteSmoke, float_0, float_1, float_2, float_3);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000085C4 File Offset: 0x000067C4
		private void method_17(global::System.Drawing.Graphics graphics_0, float float_0, float float_1, float float_2, float float_3, string string_5, global::System.Drawing.Color color_1, global::System.Drawing.Font font_2 = null, global::System.Drawing.StringAlignment stringAlignment_0 = global::System.Drawing.StringAlignment.Center)
		{
			if (string.IsNullOrEmpty(string_5))
			{
				return;
			}
			global::System.Drawing.SolidBrush brush = new global::System.Drawing.SolidBrush(color_1);
			global::System.Drawing.RectangleF layoutRectangle = new global::System.Drawing.RectangleF(float_0, float_1, float_2, float_3);
			if (font_2 == null)
			{
				font_2 = new global::System.Drawing.Font("Times New Roman", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point);
			}
			global::System.Drawing.StringFormat stringFormat = new global::System.Drawing.StringFormat();
			stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
			stringFormat.Alignment = stringAlignment_0;
			graphics_0.DrawString(string_5, font_2, brush, layoutRectangle, stringFormat);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000862C File Offset: 0x0000682C
		private void method_18(global::System.Drawing.Graphics graphics_0, float float_0, float float_1, float float_2, float float_3,CellData cellData_0)
		{
			if (cellData_0 == null)
			{
				return;
			}
			string text = cellData_0.Text(this.isVN);
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			global::System.Drawing.RectangleF layoutRectangle = new global::System.Drawing.RectangleF(float_0, float_1, float_2, float_3);
			global::System.Drawing.Font font = this.method_20(cellData_0, this.isVN);
			global::System.Drawing.SizeF size = graphics_0.MeasureString(text, font);
			if (size.Height < float_3)
			{
				size = new global::System.Drawing.SizeF(size.Width, float_3);
			}
			layoutRectangle.Size = size;
			int num;
			if (this.isVN && !string.IsNullOrEmpty(this.LoaiSoData.VNAlign+""))
			{
				if ((num = (string.IsNullOrEmpty(cellData_0.alignVN) ? 1 : 0)) != 0)
				{
					if (!text.Contains(" "))
					{
						goto IL_E5;
					}
				}
			}
			else
			{
				num = 0;
			}
			float_0 += float_2 / 2f;
			float_1 += float_3 / 2f;
			float_0 -= size.Width / 2f;
			float_1 -= size.Height / 2f;
			layoutRectangle.Location = new global::System.Drawing.PointF(float_0, float_1);
			IL_E5:
			global::System.Drawing.StringFormat stringFormat = new global::System.Drawing.StringFormat();
			if (num != 0)
			{
				string vnalign = this.LoaiSoData.VNAlign;
				if (!(vnalign == "top") && !(vnalign == "bottom"))
				{
					if (vnalign == "left")
					{
						stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
						stringFormat.Alignment = global::System.Drawing.StringAlignment.Near;
					}
					else
					{
						stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
						stringFormat.Alignment = global::System.Drawing.StringAlignment.Center;
					}
				}
			}
			else
			{
				stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
				stringFormat.Alignment = global::System.Drawing.StringAlignment.Center;
			}
			graphics_0.DrawString(text, font, new global::System.Drawing.SolidBrush(global::System.Drawing.Color.Black), layoutRectangle, stringFormat);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x000087A8 File Offset: 0x000069A8
		private void method_19(global::System.Drawing.Graphics graphics_0, float float_0, float float_1, float float_2, float float_3,CellData cellData_0)
		{
			if (cellData_0 == null || !string.IsNullOrEmpty(this.LoaiSoData.Language))
			{
				return;
			}
			string text;
			global::System.Drawing.Font font;
			if (!"$Tinchu".Equals(cellData_0.Value) && !"*tinchu".Equals(cellData_0.Value) && !"@diachiyvu".Equals(cellData_0.Value) && !"*diachiyvu".Equals(cellData_0.Value))
			{
				text = cellData_0.Text(this.isVN);
				font = this.method_20(cellData_0, false);
			}
			else
			{
				text = cellData_0.Text(true);
				font = this.method_20(cellData_0, true);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				global::System.Drawing.RectangleF layoutRectangle = new global::System.Drawing.RectangleF(float_0, float_1, float_2, float_3);
				global::System.Drawing.SizeF size = graphics_0.MeasureString(text, font);
				if (size.Height < float_3)
				{
					size = new global::System.Drawing.SizeF(size.Width, float_3);
				}
				layoutRectangle.Size = size;
				int num;
				if (this.isVN && !string.IsNullOrEmpty(this.LoaiSoData.VNAlign))
				{
					if ((num = (string.IsNullOrEmpty(cellData_0.alignVN) ? 1 : 0)) != 0)
					{
						if (!text.Contains(" "))
						{
							goto IL_162;
						}
					}
				}
				else
				{
					num = 0;
				}
				float_0 += float_2 / 2f;
				float_1 += float_3 / 2f;
				float_0 -= size.Width / 2f;
				float_1 -= size.Height / 2f;
				layoutRectangle.Location = new global::System.Drawing.PointF(float_0, float_1);
				IL_162:
				global::System.Drawing.StringFormat stringFormat = new global::System.Drawing.StringFormat();
				if (num != 0)
				{
					string vnalign = this.LoaiSoData.VNAlign;
					if (!(vnalign == "top") && !(vnalign == "bottom"))
					{
						if (vnalign == "left")
						{
							stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
							stringFormat.Alignment = global::System.Drawing.StringAlignment.Near;
						}
						else
						{
							stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
							stringFormat.Alignment = global::System.Drawing.StringAlignment.Center;
						}
					}
				}
				else
				{
					stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
					stringFormat.Alignment = global::System.Drawing.StringAlignment.Center;
				}
				graphics_0.DrawString(text, font, new global::System.Drawing.SolidBrush(global::System.Drawing.Color.Black), layoutRectangle, stringFormat);
				return;
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x000089A4 File Offset: 0x00006BA4
		private global::System.Drawing.Font method_20( CellData cellData_0, bool bool_1)
		{
			global::System.Drawing.Font font = null;
			if (bool_1)
			{
				if (!string.IsNullOrEmpty(cellData_0.fnameVN))
				{
					font = new global::System.Drawing.Font(cellData_0.fnameVN, cellData_0.fsizeVN, (global::System.Drawing.FontStyle)cellData_0.fstyleVN, global::System.Drawing.GraphicsUnit.Point);
				}
				else
				{
					if (this.font_1 == null)
					{
						this.font_1 = new global::System.Drawing.Font("Times New Roman", 13f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point);
					}
					font = this.font_1;
				}
			}
			else if (!string.IsNullOrEmpty(cellData_0.fnameCN))
			{
				if (this.fontFCN != null)
				{
					using (global::System.Collections.Generic.Dictionary<string, string>.Enumerator enumerator = this.fontFCN.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							global::System.Collections.Generic.KeyValuePair<string, string> keyValuePair = enumerator.Current;
							if (keyValuePair.Key == cellData_0.fnameCN)
							{
								global::System.Drawing.Text.PrivateFontCollection privateFontCollection = new global::System.Drawing.Text.PrivateFontCollection();
								privateFontCollection.AddFontFile(keyValuePair.Value);
								font = new global::System.Drawing.Font(privateFontCollection.Families[0], cellData_0.fsizeCN, (global::System.Drawing.FontStyle)cellData_0.fstyleCN, global::System.Drawing.GraphicsUnit.Point);
								break;
							}
						}
						goto IL_1A3;
					}
				}
				font = new global::System.Drawing.Font(cellData_0.fnameCN, cellData_0.fsizeCN, (global::System.Drawing.FontStyle)cellData_0.fstyleCN, global::System.Drawing.GraphicsUnit.Point);
			}
			else
			{
				if (this.font_0 == null && this.fontFCN != null)
				{
					foreach (global::System.Collections.Generic.KeyValuePair<string, string> keyValuePair2 in this.fontFCN)
					{
						global::System.Drawing.Text.PrivateFontCollection privateFontCollection2 = new global::System.Drawing.Text.PrivateFontCollection();
						privateFontCollection2.AddFontFile(keyValuePair2.Value);
						if (privateFontCollection2.Families[0].Name == "CN-Khai")
						{
							this.font_0 = new global::System.Drawing.Font(privateFontCollection2.Families[0], 20f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point);
							break;
						}
					}
				}
				font = this.font_0;
			}
			IL_1A3:
			if (font == null)
			{
				font = new global::System.Drawing.Font("Times New Roman", 13f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point);
			}
			return font;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00008B88 File Offset: 0x00006D88
		private bool isVN
		{
			get
			{
				return this.LoaiSoData.Language == "cbxChuViet";
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00008BAC File Offset: 0x00006DAC
		private void method_21(global::System.Drawing.Graphics graphics_0, float float_0, float float_1, float float_2, float float_3,CellData cellData_0)
		{
			if (cellData_0 == null)
			{
				return;
			}
			global::System.Drawing.RectangleF layoutRectangle = new global::System.Drawing.RectangleF(float_0, float_1, float_2, float_3);
			string text = cellData_0.Text(false);
			string text2 = cellData_0.Text(true);
			if (!string.IsNullOrEmpty(text) && text != text2)
			{
				if (this.font_0 == null)
				{
					this.font_0 = new global::System.Drawing.Font("CN-Khai", 20f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point);
				}
				graphics_0.DrawString(text, this.font_0, new global::System.Drawing.SolidBrush(global::System.Drawing.Color.Black), layoutRectangle, this.method_22(false));
			}
			if (!string.IsNullOrEmpty(text2))
			{
				this.method_23(graphics_0, float_0, float_1, float_2, float_3, text2, this.font_1, this.method_22(true));
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00008C50 File Offset: 0x00006E50
		private global::System.Drawing.StringFormat method_22(bool bool_1)
		{
			global::System.Drawing.StringFormat stringFormat = new global::System.Drawing.StringFormat();
			if (!bool_1)
			{
				string songNguAlign = this.LoaiSoData.SongNguAlign;
				if (songNguAlign == "top")
				{
					stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Far;
					stringFormat.Alignment = global::System.Drawing.StringAlignment.Center;
				}
				else if (!(songNguAlign == "bottom"))
				{
					if (songNguAlign == "left")
					{
						stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
						stringFormat.Alignment = global::System.Drawing.StringAlignment.Far;
					}
					else
					{
						stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
						stringFormat.Alignment = global::System.Drawing.StringAlignment.Near;
					}
				}
				else
				{
					stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Near;
					stringFormat.Alignment = global::System.Drawing.StringAlignment.Center;
				}
			}
			else
			{
				string songNguAlign = this.LoaiSoData.SongNguAlign;
				if (!(songNguAlign == "top"))
				{
					if (!(songNguAlign == "bottom"))
					{
						if (!(songNguAlign == "left"))
						{
							stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
							stringFormat.Alignment = global::System.Drawing.StringAlignment.Far;
						}
						else
						{
							stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Center;
							stringFormat.Alignment = global::System.Drawing.StringAlignment.Near;
						}
					}
					else
					{
						stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Far;
						stringFormat.Alignment = global::System.Drawing.StringAlignment.Center;
					}
				}
				else
				{
					stringFormat.LineAlignment = global::System.Drawing.StringAlignment.Near;
					stringFormat.Alignment = global::System.Drawing.StringAlignment.Center;
				}
			}
			return stringFormat;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00008D54 File Offset: 0x00006F54
		private void method_23(global::System.Drawing.Graphics graphics_0, float float_0, float float_1, float float_2, float float_3, string string_5, global::System.Drawing.Font font_2, global::System.Drawing.StringFormat stringFormat_0)
		{
			if (string.IsNullOrEmpty(string_5))
			{
				return;
			}
			if (font_2 == null)
			{
				font_2 = new global::System.Drawing.Font("Times New Roman", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point);
			}
			global::System.Drawing.SizeF size = graphics_0.MeasureString(string_5, font_2);
			size = new global::System.Drawing.SizeF(size.Width, float_3);
			global::System.Drawing.RectangleF layoutRectangle = default(global::System.Drawing.RectangleF);
			float_0 += float_2 / 2f;
			float_0 -= size.Width / 2f;
			layoutRectangle.Location = new global::System.Drawing.PointF(float_0, float_1);
			layoutRectangle.Size = size;
			graphics_0.DrawString(string_5, font_2, new global::System.Drawing.SolidBrush(global::System.Drawing.Color.Black), layoutRectangle, stringFormat_0);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00008DF0 File Offset: 0x00006FF0
		private global::System.Collections.Generic.Queue< CellData> method_24(string string_5, string string_6)
		{
			string text = "";
			global::System.Collections.Generic.Queue< CellData> queue = new global::System.Collections.Generic.Queue< CellData>();
			if (!(string_5 == "@diachiyvu"))
			{
				if (!(string_5 == "@noicung"))
				{
					if (this.LongSoUserData.ContainsKey(string_5))
					{
						text = this.LongSoUserData[string_5];
					}
				}
				else
				{
					if (this.LongSoUserData.ContainsKey(string_5))
					{
						text = this.LongSoUserData[string_5];
					}
					if (string.IsNullOrEmpty(text))
					{
						text = this.PagodaName;
					}
				}
			}
			else if (string.IsNullOrEmpty(string_6))
			{
				if (!string.IsNullOrEmpty(this.PagodaAddress))
				{
					text = this.PagodaAddress.Replace(",", "").Replace(".", "").Replace("-", "").Replace("_", "");
				}
			}
			else
			{
				text = string_6.Replace(",", "").Replace(".", "").Replace("-", "").Replace("_", "");
			}
			if (string.IsNullOrEmpty(text))
			{
				return queue;
			}
			string[] array = text.Split(new char[]
			{
				' '
			});
			bool flag = true;
			string value = "";
			foreach (string text2 in array)
			{
				if (!string.IsNullOrEmpty(value))
				{
					value = string_5.Replace("$", "*").Replace("@", "*");
				}
				else
				{
					value = string_5;
				}
				 LePhatBibe.getChuNho(ref queue, global::System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text2.ToLower()), value);
				if (("@nam").method_25(string_5) && flag)
				{
					flag = false;
					queue.Enqueue(new CellData());
					queue.Enqueue(new CellData());
					queue.Enqueue(new CellData());
				}
			}
			return queue;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00008FD8 File Offset: 0x000071D8
		public bool HasYear()
		{
			foreach (global::System.Collections.Generic.Dictionary<int,CellData> dictionary in this.LoaiSoData.LgSo.Values)
			{
				foreach ( CellData cellData in dictionary.Values)
				{
					object value = cellData.Value;
					if (value == null)
					{
						goto IL_4E;
					}
					string text;
					if ((text = value.ToString()) == null)
					{
						goto IL_4E;
					}
					IL_54:
					if (text.Contains("@"))
					{
						 PrDocument prDocument = "@nam";
						object value2 = cellData.Value;
						if (value2 == null)
						{
							goto IL_7A;
						}
						string text2;
						if ((text2 = value2.ToString()) == null)
						{
							goto IL_7A;
						}
						IL_80:
						if (!prDocument.method_25(text2.ToLower()))
						{
							continue;
						}
						return true;
						IL_7A:
						text2 = "";
						goto IL_80;
					}
					continue;
					IL_4E:
					text = "";
					goto IL_54;
				}
			}
			return false;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000090CC File Offset: 0x000072CC
		public PrDocument()
		{
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00009100 File Offset: 0x00007300
		bool method_25(string string_5)
		{
			return base.Equals(string_5);
		}

		// Token: 0x0400005F RID: 95
		private global::System.Drawing.FontFamily fontFamily_0;

		// Token: 0x04000060 RID: 96
		private global::System.Drawing.Font font_0;

		// Token: 0x04000061 RID: 97
		public global::System.Collections.Generic.Dictionary<string, string> fontFCN;

		// Token: 0x04000062 RID: 98
		private global::System.Drawing.Font font_1;

		// Token: 0x04000063 RID: 99
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_0;

		// Token: 0x04000064 RID: 100
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_1;

		// Token: 0x04000065 RID: 101
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string string_2;

		// Token: 0x04000066 RID: 102
		private string string_3;

		// Token: 0x04000067 RID: 103
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000068 RID: 104
		public Year IsNextYear;

		// Token: 0x04000069 RID: 105
		private string string_4;

		// Token: 0x0400006A RID: 106
		public global::System.Collections.Generic.Dictionary<string,CellData> LongSoLocation = new global::System.Collections.Generic.Dictionary<string,CellData>();

		// Token: 0x0400006B RID: 107
		public global::System.Collections.Generic.Dictionary<string, string> LongSoUserData = new global::System.Collections.Generic.Dictionary<string, string>();

		// Token: 0x0400006C RID: 108
		private global::System.Drawing.Color color_0 = global::System.Drawing.Color.DarkOrange;
	}
}
