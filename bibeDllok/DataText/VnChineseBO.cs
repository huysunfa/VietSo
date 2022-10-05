using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using DataModel.Entities;

namespace DataText
{
	// Token: 0x0200000F RID: 15
	public class VnChineseBO : global::DataText.TamKhongDic
	{
		// Token: 0x060000C5 RID: 197 RVA: 0x00005E4C File Offset: 0x0000404C
		public static void addColNguCanh()
		{
			try
			{
				string query = "ALTER TABLE VnChinese ADD COLUMN nguCanh TEXT";
				global::DataText.TamKhongDic.dbex.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00005E80 File Offset: 0x00004080
		public static void addColUpdateDT()
		{
			try
			{
				string query = "ALTER TABLE VnChinese ADD COLUMN UpdateDT DATETIME";
				global::DataText.TamKhongDic.dbex.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00005EB4 File Offset: 0x000040B4
		public static void addColSyscTime()
		{
			try
			{
				string query = "ALTER TABLE VnChinese ADD COLUMN syncTime DATETIME";
				global::DataText.TamKhongDic.dbex.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00005EE8 File Offset: 0x000040E8
		public static global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.List<global::DataModel.Entities.VnChinese>> getDic()
		{
			string query = "Select * from VnChinese ORDER BY used DESC";
			global::System.Data.DataTable dataTable = global::DataText.TamKhongDic.dbex.Select(query);
			global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.List<global::DataModel.Entities.VnChinese>> dictionary = new global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.List<global::DataModel.Entities.VnChinese>>();
			foreach (object obj in dataTable.Rows)
			{
				global::System.Data.DataRow dataRow = (global::System.Data.DataRow)obj;
				string text = global::DataText.BaseBO.GetString(dataRow["vn"]).ToLower();
				global::DataModel.Entities.VnChinese vnChinese = new global::DataModel.Entities.VnChinese();
				vnChinese.vn = text;
				vnChinese.chinese = global::DataText.BaseBO.GetString(dataRow["chinese"]);
				vnChinese.nguCanh = global::DataText.BaseBO.GetString(dataRow["nguCanh"]);
				if (dictionary.ContainsKey(text))
				{
					dictionary[text].Add(vnChinese);
				}
				else
				{
					dictionary.Add(text, new global::System.Collections.Generic.List<global::DataModel.Entities.VnChinese>
					{
						vnChinese
					});
				}
			}
			return dictionary;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00005FE0 File Offset: 0x000041E0
		public static global::System.Collections.Generic.List<global::DataModel.Entities.VnChinese> getList()
		{
			string query = "SELECT * FROM VnChinese WHERE 0 < used AND (syncTime ISNULL OR UpdateDT ISNULL OR syncTime < UpdateDT) ORDER BY used DESC";
			global::System.Data.DataTable dataTable = global::DataText.TamKhongDic.dbex.Select(query);
			global::System.Collections.Generic.List<global::DataModel.Entities.VnChinese> list = new global::System.Collections.Generic.List<global::DataModel.Entities.VnChinese>();
			foreach (object obj in dataTable.Rows)
			{
				global::System.Data.DataRow dataRow = (global::System.Data.DataRow)obj;
				global::DataModel.Entities.VnChinese vnChinese = new global::DataModel.Entities.VnChinese();
				vnChinese.vn = global::DataText.BaseBO.GetString(dataRow["vn"]).ToLower();
				vnChinese.chinese = global::DataText.BaseBO.GetString(dataRow["chinese"]);
				vnChinese.nguCanh = global::DataText.BaseBO.GetString(dataRow["nguCanh"]);
				if (!list.Contains(vnChinese))
				{
					list.Add(vnChinese);
				}
			}
			return list;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000060B0 File Offset: 0x000042B0
		public static int count()
		{
			string query = "Select count(*) num from VnChinese";
			int @int;
			using (global::System.Collections.IEnumerator enumerator = global::DataText.TamKhongDic.dbex.Select(query).Rows.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					return 0;
				}
				@int = global::DataText.BaseBO.GetInt(((global::System.Data.DataRow)enumerator.Current)["num"]);
			}
			return @int;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00006124 File Offset: 0x00004324
		public static void update(global::DataModel.Entities.VnChinese vnc)
		{
			global::DataText.TamKhongDic.dbex.update(vnc);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000613C File Offset: 0x0000433C
		public static void updateUsedTime(string vn, string cn, string nguCanh)
		{
			global::System.Data.SQLite.SQLiteCommand sqliteCommand = new global::System.Data.SQLite.SQLiteCommand();
			string commandText = "UPDATE VnChinese SET used=used+1, nguCanh=:nguCanh, UpdateDT=:UpdateDT WHERE chinese =:chinese and vn =:vn";
			sqliteCommand.CommandText = commandText;
			sqliteCommand.Parameters.AddWithValue("nguCanh", nguCanh);
			sqliteCommand.Parameters.AddWithValue("UpdateDT", global::System.DateTime.Now);
			sqliteCommand.Parameters.AddWithValue("chinese", cn);
			sqliteCommand.Parameters.AddWithValue("vn", vn);
			global::DataText.TamKhongDic.dbex.executeNonQuery(sqliteCommand);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000061BC File Offset: 0x000043BC
		public static void updatesyncTime(string vn, string cn)
		{
			global::System.Data.SQLite.SQLiteCommand sqliteCommand = new global::System.Data.SQLite.SQLiteCommand();
			string commandText = "UPDATE VnChinese SET syncTime=:syncTime WHERE chinese =:chinese and vn =:vn";
			sqliteCommand.CommandText = commandText;
			sqliteCommand.Parameters.AddWithValue("syncTime", global::System.DateTime.Now);
			sqliteCommand.Parameters.AddWithValue("chinese", cn);
			sqliteCommand.Parameters.AddWithValue("vn", vn);
			global::DataText.TamKhongDic.dbex.executeNonQuery(sqliteCommand);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00006228 File Offset: 0x00004428
		public static void set(global::DataModel.Entities.VnChinese vnc)
		{
			global::DataText.TamKhongDic.dbex.insert(vnc);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00006240 File Offset: 0x00004440
		public static global::DataModel.Entities.VnChinese get(string id)
		{
			string query = "Select * from VnChinese WHERE vn=@vn";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@vn", id);
			using (global::System.Collections.IEnumerator enumerator = global::DataText.TamKhongDic.dbex.Select(query, dictionary).Rows.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					global::System.Data.DataRow dataRow = (global::System.Data.DataRow)enumerator.Current;
					return new global::DataModel.Entities.VnChinese
					{
						vn = global::DataText.BaseBO.GetString(dataRow["vn"]),
						chinese = global::DataText.BaseBO.GetString(dataRow["chinese"]),
						reading = global::DataText.BaseBO.GetString(dataRow["reading"])
					};
				}
			}
			return null;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00006308 File Offset: 0x00004508
		public VnChineseBO()
		{
		}
	}
}
