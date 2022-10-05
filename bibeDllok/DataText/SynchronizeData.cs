using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using CommonModel;
using DataModel;
using DataModel.Entities;

namespace DataText
{
	// Token: 0x02000021 RID: 33
	public class SynchronizeData
	{
		// Token: 0x0600021A RID: 538 RVA: 0x0000A7BC File Offset: 0x000089BC
		public SynchronizeData(string string_3)
		{
			this.backgroundWorker_0 = new global::System.ComponentModel.BackgroundWorker();
			this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
			this.backgroundWorker_0.ProgressChanged += this.backgroundWorker_0_ProgressChanged;
			this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.RunWorkerAsync(string_3);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000A844 File Offset: 0x00008A44
		private void backgroundWorker_0_DoWork(object sender, global::System.ComponentModel.DoWorkEventArgs e)
		{
			try
			{
				this.method_5((string)e.Argument);
				this.method_0();
				this.method_1();
				this.method_2();
				global::DataText.SynchronizeData.smethod_2();
			}
			catch (global::System.Exception ex)
			{
				global::DataText.ELogger.LogMessage(ex, "");
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000A898 File Offset: 0x00008A98
		private void backgroundWorker_0_ProgressChanged(object sender, global::System.ComponentModel.ProgressChangedEventArgs e)
		{
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000A898 File Offset: 0x00008A98
		private void backgroundWorker_0_RunWorkerCompleted(object sender, global::System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000A8A8 File Offset: 0x00008AA8
		private void method_0()
		{
			string text = global::DataModel.Util.ReadKeyFile();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			text = "keyfile=" + global::System.Web.HttpUtility.UrlEncode(text);
			global::System.Collections.Generic.List<global::DataModel.Entities.Pagoda> list = global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.List<global::DataModel.Entities.Pagoda>>(global::DataModel.Util.queryServer("AppSync/DataPagoda/", text));
			if (list != null && 0 < list.Count)
			{
				global::System.Collections.Generic.Dictionary<string, string> dictionary = new global::System.Collections.Generic.Dictionary<string, string>();
				foreach (global::DataModel.Entities.Pagoda pagoda in list)
				{
					global::DataModel.Entities.Pagoda pagoda2 = global::DataText.PagodaBO.get(pagoda.ID);
					if (pagoda2 == null)
					{
						pagoda.Status = "Sync";
						global::DataText.PagodaBO.set(pagoda);
						dictionary.Add(pagoda.ID, "");
					}
					else if (pagoda2.Status == "New" && pagoda.Status == "Deleted")
					{
						dictionary.Add(pagoda.ID, "Deleted");
					}
					else if (pagoda2.UpdateDT < pagoda.UpdateDT)
					{
						if (pagoda.Status == "Deleted")
						{
							global::DataText.PagodaBO.delete(pagoda);
							dictionary.Add(pagoda.ID, "Deleted");
						}
						else
						{
							pagoda.Status = "Sync";
							global::DataText.PagodaBO.update(pagoda);
							dictionary.Add(pagoda.ID, "");
						}
					}
				}
				global::DataModel.Util.queryServer("AppSync/DataPagodaConfirm/", text + "&reconfirm=" + global::CommonModel.UtilModel.Convert2JSON(dictionary));
			}
			global::System.Collections.Generic.List<global::DataModel.Entities.Person> list2 = global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.List<global::DataModel.Entities.Person>>(global::DataModel.Util.queryServer("AppSync/DataPerson/", text));
			if (list2 != null && 0 < list2.Count)
			{
				global::System.Collections.Generic.Dictionary<string, string> dictionary2 = new global::System.Collections.Generic.Dictionary<string, string>();
				foreach (global::DataModel.Entities.Person person in list2)
				{
					global::DataModel.Entities.Person person2 = global::DataText.PersonBO.get(person.ID);
					if (person2 == null)
					{
						person.Status = "Sync";
						global::DataText.PersonBO.set(person);
						dictionary2.Add(person.ID, "");
					}
					else if (person2.Status == "New" && person.Status == "Deleted")
					{
						dictionary2.Add(person.ID, "Deleted");
					}
					else if (person2.UpdateDT < person.UpdateDT)
					{
						if (!(person.Status == "Deleted"))
						{
							person.Status = "Sync";
							global::DataText.PersonBO.update(person);
							dictionary2.Add(person.ID, "");
						}
						else
						{
							global::DataText.PersonBO.delete(person2);
							dictionary2.Add(person.ID, "Deleted");
						}
					}
				}
				global::DataModel.Util.queryServer("AppSync/DataPersonConfirm/", text + "&reconfirm=" + global::CommonModel.UtilModel.Convert2JSON(dictionary2));
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000ABA4 File Offset: 0x00008DA4
		private void method_1()
		{
			string text = global::DataModel.Util.ReadKeyFile();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			global::System.Collections.Generic.List<global::DataModel.Entities.Pagoda> list = global::DataText.PagodaBO.getList();
			if (list != null && list.Count > 0)
			{
				string str = global::CommonModel.UtilModel.Convert2JSON(list);
				string text2 = "keyfile=" + global::System.Web.HttpUtility.UrlEncode(text) + "&pgd=" + global::System.Web.HttpUtility.UrlEncode(str);
				global::System.Collections.Generic.Dictionary<string, string> dictionary = global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.Dictionary<string, string>>(global::DataModel.Util.queryServer("AppSync/DataPagodaClient/", text2));
				if (dictionary != null)
				{
					foreach (global::System.Collections.Generic.KeyValuePair<string, string> keyValuePair in dictionary)
					{
						if (!string.IsNullOrEmpty(keyValuePair.Value))
						{
							global::DataText.PagodaBO.update(keyValuePair.Value, keyValuePair.Key);
							global::DataText.PersonBO.update(keyValuePair.Value, keyValuePair.Key);
						}
						else
						{
							global::DataText.PagodaBO.update(new global::DataModel.Entities.Pagoda
							{
								ID = keyValuePair.Key,
								Status = "Sync"
							});
						}
					}
				}
			}
			global::System.Collections.Generic.List<global::DataModel.Entities.Person> list2 = global::DataText.PersonBO.getList();
			if (list2 != null && list2.Count > 0)
			{
				string str2 = global::CommonModel.UtilModel.Convert2JSON(list2);
				string text3 = "keyfile=" + global::System.Web.HttpUtility.UrlEncode(text) + "&psn=" + global::System.Web.HttpUtility.UrlEncode(str2);
				global::System.Collections.Generic.Dictionary<int, string> dictionary2 = global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.Dictionary<int, string>>(global::DataModel.Util.queryServer("AppSync/DataPersonClient/", text3));
				if (dictionary2 != null)
				{
					foreach (global::System.Collections.Generic.KeyValuePair<int, string> keyValuePair2 in dictionary2)
					{
						if (!string.IsNullOrEmpty(keyValuePair2.Value))
						{
							if (!(keyValuePair2.Value == "Deleted"))
							{
								int num = 0;
								if (int.TryParse(keyValuePair2.Value, out num))
								{
									global::DataText.PersonBO.updateID(keyValuePair2.Key, keyValuePair2.Value);
								}
							}
							else
							{
								global::DataText.PersonBO.delete(keyValuePair2.Key.ToString());
							}
						}
						else
						{
							global::DataText.PersonBO.updateStatus(keyValuePair2.Key, "Sync");
						}
					}
				}
			}
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000ADB4 File Offset: 0x00008FB4
		private void method_2()
		{
			string text = "";
			text = "keyfile=" + global::System.Web.HttpUtility.UrlEncode(text);
			string text2 = global::DataModel.Util.queryServer("AppSync/updateDataList/", text);
			if (!string.IsNullOrEmpty(text2))
			{
				global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> stack = global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo>>(text2);
				global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> stack2 = new global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo>();
				if (global::System.IO.File.Exists(global::DataModel.Util.getDataPath + "updated.info"))
				{
					global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> stack3 = global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo>>(global::System.IO.File.ReadAllText(global::DataModel.Util.getDataPath + "updated.info"));
					bool flag = false;
					using (global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo>.Enumerator enumerator = stack.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							global::DataModel.Entities.FileDownloadInfo fileDownloadInfo = enumerator.Current;
							flag = false;
							using (global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo>.Enumerator enumerator2 = stack3.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									if (enumerator2.Current.Equal(fileDownloadInfo))
									{
										flag = true;
										break;
									}
								}
								goto IL_D6;
							}
							IL_CC:
							stack2.Push(fileDownloadInfo);
							continue;
							IL_D6:
							if (!flag)
							{
								goto IL_CC;
							}
						}
						goto IL_EE;
					}
				}
				stack2 = stack;
				IL_EE:
				if (stack2 != null & 0 < stack2.Count)
				{
					global::DataText.SynchronizeData.Class9 class9_ = new global::DataText.SynchronizeData.Class9
					{
						stack_0 = stack2
					};
					this.method_3(class9_);
				}
				return;
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000AEF4 File Offset: 0x000090F4
		private void method_3(global::DataText.SynchronizeData.Class9 class9_0)
		{
			try
			{
				this.webClient_0 = new global::System.Net.WebClient();
				this.webClient_0.DownloadFileCompleted += this.webClient_0_DownloadFileCompleted;
				this.fileDownloadInfo_0 = class9_0.stack_0.Pop();
				this.method_4(class9_0);
			}
			catch (global::System.Exception ex)
			{
				global::DataText.ELogger.LogMessage(ex, "");
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000AF5C File Offset: 0x0000915C
		private void method_4(global::DataText.SynchronizeData.Class9 class9_0)
		{
			this.string_2 = global::DataModel.Util.getTempPath + this.fileDownloadInfo_0.FileName + "." + this.fileDownloadInfo_0.Extension;
			if (global::System.IO.File.Exists(this.string_2))
			{
				global::System.IO.File.Delete(this.string_2);
			}
			string str = "";
			string text = "";
			if (this.fileDownloadInfo_0.DirName != "")
			{
				str = this.fileDownloadInfo_0.DirName.Substring(1) + "\\Temp\\";
				text = this.fileDownloadInfo_0.DirName.Replace("\\", "/");
			}
			string text2 = global::DataModel.Util.getDataPath + str;
			if (!global::System.IO.Directory.Exists(text2))
			{
				global::System.IO.Directory.CreateDirectory(text2);
			}
			this.string_1 = text2 + this.fileDownloadInfo_0.FileName + "." + this.fileDownloadInfo_0.Extension;
			string uriString = string.Concat(new string[]
			{
				global::DataModel.Util.mainURL,
				"AppSync/updateDataFile/",
				this.fileDownloadInfo_0.FileName,
				"/",
				this.fileDownloadInfo_0.Extension,
				text
			});
			this.webClient_0.DownloadFileAsync(new global::System.Uri(uriString), this.string_2, class9_0);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000B0A4 File Offset: 0x000092A4
		private void webClient_0_DownloadFileCompleted(object sender, global::System.ComponentModel.AsyncCompletedEventArgs e)
		{
			try
			{
				global::DataText.SynchronizeData.Class9 @class = (global::DataText.SynchronizeData.Class9)e.UserState;
				global::System.IO.File.Copy(this.string_2, this.string_1, true);
				global::System.IO.File.Delete(this.string_2);
				if (!this.fileDownloadInfo_0.Extension.Contains("bibe"))
				{
					global::DataText.SynchronizeData.smethod_0(this.fileDownloadInfo_0, global::DataModel.Util.getDataPath);
				}
				if (@class.stack_0.Count > 0)
				{
					this.fileDownloadInfo_0 = @class.stack_0.Pop();
					this.method_4(@class);
				}
			}
			catch (global::System.Exception ex)
			{
				global::DataText.ELogger.LogMessage(ex, "");
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000B148 File Offset: 0x00009348
		private static void smethod_0(global::DataModel.Entities.FileDownloadInfo fileDownloadInfo_1, string string_3)
		{
			global::System.Collections.Generic.List<global::DataModel.Entities.FileDownloadInfo> list = new global::System.Collections.Generic.List<global::DataModel.Entities.FileDownloadInfo>();
			if (global::System.IO.File.Exists(string_3 + "updated.info"))
			{
				list = global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.List<global::DataModel.Entities.FileDownloadInfo>>(global::System.IO.File.ReadAllText(string_3 + "updated.info"));
				foreach (global::DataModel.Entities.FileDownloadInfo fileDownloadInfo in list)
				{
					if (fileDownloadInfo.DirName == fileDownloadInfo_1.DirName & fileDownloadInfo.FileName == fileDownloadInfo_1.FileName)
					{
						list.Remove(fileDownloadInfo);
						break;
					}
				}
			}
			list.Add(fileDownloadInfo_1);
			using (global::System.IO.StreamWriter streamWriter = new global::System.IO.StreamWriter(string_3 + "updated.info", false))
			{
				streamWriter.Write(global::CommonModel.UtilModel.Convert2JSON(list));
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000B22C File Offset: 0x0000942C
		private void method_5(string string_3)
		{
			string getUpdatePath = global::DataModel.Util.getUpdatePath;
			if (global::System.IO.File.Exists(getUpdatePath + "notifyUpdate.txt"))
			{
				return;
			}
			global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> stack = global::DataText.SynchronizeData.smethod_1(global::DataModel.Util.getRunPath, "updateList", string_3);
			if (stack != null && 0 < stack.Count)
			{
				global::System.IO.File.WriteAllText(getUpdatePath + "notifyUpdate.txt", "");
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000B284 File Offset: 0x00009484
		private static global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> smethod_1(string string_3, string string_4, string string_5)
		{
			global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> stack = new global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo>();
			global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> result;
			using (global::System.Net.WebClient webClient = new global::System.Net.WebClient())
			{
				webClient.Encoding = global::System.Text.Encoding.UTF8;
				string uriString = string.Concat(new string[]
				{
					global::DataModel.Util.mainURL,
					"AppSync/",
					string_4,
					"/",
					string_5.Replace(".", ""),
					"/"
				});
				string text = webClient.DownloadString(new global::System.Uri(uriString));
				if (!string.IsNullOrEmpty(text))
				{
					global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> stack2 = global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo>>(text);
					if (global::System.IO.File.Exists(string_3 + "updated.info"))
					{
						global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> stack3 = global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo>>(global::System.IO.File.ReadAllText(string_3 + "updated.info"));
						bool flag = false;
						using (global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo>.Enumerator enumerator = stack2.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								global::DataModel.Entities.FileDownloadInfo fileDownloadInfo = enumerator.Current;
								flag = false;
								using (global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo>.Enumerator enumerator2 = stack3.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										if (enumerator2.Current.Equal(fileDownloadInfo))
										{
											flag = true;
											break;
										}
									}
									goto IL_10C;
								}
								IL_102:
								stack.Push(fileDownloadInfo);
								continue;
								IL_10C:
								if (!flag)
								{
									goto IL_102;
								}
							}
							return stack;
						}
					}
					return stack2;
				}
				result = stack;
			}
			return result;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000B418 File Offset: 0x00009618
		public static void downloadUpdateCode(string version, global::DataText.SynchronizeData.UpdateProgressDelegate prg)
		{
			global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> stack = global::DataText.SynchronizeData.smethod_1(global::DataModel.Util.getRunPath, "updateList", version);
			if (stack != null && 0 < stack.Count)
			{
				string getUpdateTempPath = global::DataModel.Util.getUpdateTempPath;
				using (global::System.Net.WebClient webClient = new global::System.Net.WebClient())
				{
					webClient.Encoding = global::System.Text.Encoding.UTF8;
					int count = stack.Count;
					while (0 < stack.Count)
					{
						global::DataModel.Entities.FileDownloadInfo fileDownloadInfo = stack.Pop();
						string text = getUpdateTempPath + fileDownloadInfo.FileName + "." + fileDownloadInfo.Extension;
						if (global::System.IO.File.Exists(text))
						{
							global::System.IO.File.Delete(text);
						}
						prg((count - stack.Count).ToString() + "/" + (count + 1).ToString(), (int)(100.0 - (double)stack.Count / (double)count * 90.0));
						string address = string.Concat(new string[]
						{
							global::DataModel.Util.mainURL,
							"AppSync/updateFile/",
							fileDownloadInfo.FileName,
							"/",
							fileDownloadInfo.Extension,
							"/"
						});
						webClient.DownloadFile(address, text);
						global::DataText.SynchronizeData.smethod_0(fileDownloadInfo, global::DataModel.Util.getRunPath);
					}
					string[] files = global::System.IO.Directory.GetFiles(getUpdateTempPath);
					if (files != null)
					{
						foreach (string text2 in files)
						{
							if (global::System.IO.File.Exists(text2))
							{
								global::System.IO.File.Copy(text2, text2.Replace("Update\\Temp\\", "Update\\"), true);
							}
						}
					}
				}
				global::System.IO.Directory.Delete(getUpdateTempPath, true);
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000B5D0 File Offset: 0x000097D0
		private static void smethod_2()
		{
			try
			{
				if (global::DataText.SynchronizeData.isNeedUpDicFile())
				{
					global::CustomerKey customerKey = global::DataText.SynchronizeData.smethod_3();
					if (customerKey != null)
					{
						foreach (global::DataModel.Entities.VnChinese vnChinese in global::DataText.VnChineseBO.getList())
						{
							vnChinese.KeySoft = customerKey.CusKey;
							string str = global::CommonModel.UtilModel.Convert2JSON(vnChinese);
							string text = "vncn=" + global::System.Web.HttpUtility.UrlEncode(str);
							if (global::System.Convert.ToBoolean(global::DataModel.Util.queryServer("AppSync/DicReceiveRecord/", text)))
							{
								global::DataText.VnChineseBO.updatesyncTime(vnChinese.vn, vnChinese.chinese);
							}
						}
					}
				}
			}
			catch (global::System.Exception ex)
			{
				global::DataText.ELogger.LogMessage(ex, "");
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000B694 File Offset: 0x00009894
		public static bool isNeedUpDicFile()
		{
			string text = global::DataModel.Util.ReadKeyFile();
			if (!string.IsNullOrEmpty(text))
			{
				text = "keyfile=" + global::System.Web.HttpUtility.UrlEncode(text);
				return global::System.Convert.ToBoolean(global::DataModel.Util.queryServer("AppSync/DicIsNeed/", text));
			}
			return false;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000B6D4 File Offset: 0x000098D4
		private static global::CustomerKey smethod_3()
		{
			string text = global::DataModel.Util.ReadKeyFile();
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			text = global::DataModel.Util.UnZIP(text);
			return global::CommonModel.UtilModel.ConvertJSON2Obj<global::CustomerKey>(text);
		}

		// Token: 0x04000079 RID: 121
		private global::System.ComponentModel.BackgroundWorker backgroundWorker_0;

		// Token: 0x0400007A RID: 122
		private const string string_0 = "updated.info";

		// Token: 0x0400007B RID: 123
		private global::System.Net.WebClient webClient_0;

		// Token: 0x0400007C RID: 124
		private string string_1;

		// Token: 0x0400007D RID: 125
		private string string_2;

		// Token: 0x0400007E RID: 126
		private global::DataModel.Entities.FileDownloadInfo fileDownloadInfo_0;

		// Token: 0x02000022 RID: 34
		private class Class9
		{
			// Token: 0x0600026D RID: 621 RVA: 0x00004254 File Offset: 0x00002454
			public Class9()
			{
			}

			// Token: 0x0400007F RID: 127
			public global::System.Collections.Generic.Stack<global::DataModel.Entities.FileDownloadInfo> stack_0;
		}

		// Token: 0x02000023 RID: 35
		// (Invoke) Token: 0x0600026F RID: 623
		public delegate void UpdateProgressDelegate(string msg, int percent);
	}
}
