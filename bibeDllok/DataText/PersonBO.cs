using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using DataModel.Entities;

namespace DataText
{
	// Token: 0x02000011 RID: 17
	public class PersonBO : global::DataText.TamKhong
	{
		// Token: 0x060000FB RID: 251 RVA: 0x000065B4 File Offset: 0x000047B4
		public static void addColNgayMat()
		{
			try
			{
				string query = "ALTER TABLE Person ADD COLUMN NgayMat TEXT";
				global::DataText.TamKhong.dbex.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000065E8 File Offset: 0x000047E8
		public static void addColDanhXung()
		{
			try
			{
				string query = "ALTER TABLE Person ADD COLUMN DanhXung TEXT";
				global::DataText.TamKhong.dbex.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000661C File Offset: 0x0000481C
		public static void addAlterView()
		{
			try
			{
				string query = "DROP VIEW ChuSo;\r\nCREATE VIEW ChuSo AS SELECT * FROM Person AS ps\r\nWHERE ps.id=(SELECT ID FROM Person ps1 WHERE ps.SoNo=ps1.SoNo AND ps.PagodaID=ps1.PagodaID AND (Status<>'Deleted' OR Status IS NULL) AND (NgayMat='' OR NgayMat IS NULL) ORDER BY Orders, NamSinh ASC LIMIT 1);";
				global::DataText.TamKhong.dbex.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00006650 File Offset: 0x00004850
		public static global::System.Data.DataTable getAll()
		{
			return global::DataText.TamKhong.dbex.Select(new global::DataModel.Entities.Person());
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000666C File Offset: 0x0000486C
		public static global::System.Collections.Generic.List<global::DataModel.Entities.Person> getList()
		{
			string query = "Select * from Person WHERE Status='Changed' OR Status='New' OR Status='Deleted' LIMIT 200";
			global::System.Collections.Generic.Dictionary<string, object> prm = new global::System.Collections.Generic.Dictionary<string, object>();
			return global::DataText.BaseBO.GetObject<global::DataModel.Entities.Person>(global::DataText.TamKhong.dbex.Select(query, prm));
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00006698 File Offset: 0x00004898
		public static global::System.Data.DataTable getList(string pagodaID)
		{
			string query = "Select * from Person WHERE PagodaID=@PagodaID AND (Status<>'Deleted' OR Status IS NULL) ORDER BY SoNo, Orders, NamSinh ASC";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@PagodaID", pagodaID);
			return global::DataText.TamKhong.dbex.Select(query, dictionary);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000066CC File Offset: 0x000048CC
		private static global::System.Collections.Generic.List<global::DataModel.Entities.Person> smethod_0(string string_0, int int_0)
		{
			string query = "Select * from Person WHERE PagodaID=@PagodaID AND SoNo=@SoNo ORDER BY Orders, NamSinh ASC";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@PagodaID", string_0);
			dictionary.Add("@SoNo", int_0);
			return global::DataText.BaseBO.GetObject<global::DataModel.Entities.Person>(global::DataText.TamKhong.dbex.Select(query, dictionary));
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00006714 File Offset: 0x00004914
		public static global::System.Collections.Generic.List<global::DataModel.Entities.Person> getList(string pagodaID, global::DataText.Family fml)
		{
			string str = "";
			if (0 < fml.IDs.Count)
			{
				str = "AND ID IN (" + string.Join(",", fml.IDs) + ") ";
			}
			string query = "Select * from Person WHERE PagodaID=@PagodaID AND SoNo=@SoNo AND (NgayMat='' OR NgayMat IS NULL) " + str + "ORDER BY Orders, NamSinh ASC";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@PagodaID", pagodaID);
			dictionary.Add("@SoNo", fml.SoNo);
			return global::DataText.BaseBO.GetObject<global::DataModel.Entities.Person>(global::DataText.TamKhong.dbex.Select(query, dictionary));
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000067A0 File Offset: 0x000049A0
		public static global::System.Collections.Generic.List<global::DataModel.Entities.Person> getHuonglinhs(string pagodaID, global::DataText.Family fml)
		{
			string str = "";
			if (0 < fml.IDs.Count)
			{
				str = " AND ID IN (" + string.Join(",", fml.IDs) + ") ";
			}
			string query = "Select * from Person WHERE PagodaID=@PagodaID AND SoNo=@SoNo AND NgayMat IS NOT NULL AND NgayMat<>''" + str + "ORDER BY Orders, NamSinh ASC";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@PagodaID", pagodaID);
			dictionary.Add("@SoNo", fml.SoNo);
			return global::DataText.BaseBO.GetObject<global::DataModel.Entities.Person>(global::DataText.TamKhong.dbex.Select(query, dictionary));
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000682C File Offset: 0x00004A2C
		public static global::System.Collections.Generic.List<int> getListSoNo(string pagodaID)
		{
			string query = "Select SoNo from Person WHERE PagodaID=@PagodaID AND (Status<>'Deleted' OR Status IS NULL) GROUP BY SoNo";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@PagodaID", pagodaID);
			global::System.Data.DataTable dataTable = global::DataText.TamKhong.dbex.Select(query, dictionary);
			global::System.Collections.Generic.List<int> list = new global::System.Collections.Generic.List<int>();
			foreach (object obj in dataTable.Rows)
			{
				global::System.Data.DataRow dataRow = (global::System.Data.DataRow)obj;
				list.Add(global::DataText.BaseBO.GetInt(dataRow["SoNo"]));
			}
			return list;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000068C4 File Offset: 0x00004AC4
		public static int getNewSoNo(string pagodaID)
		{
			string query = "SELECT * FROM Person WHERE PagodaID=@PagodaID ORDER BY SoNo DESC LIMIT 1";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@PagodaID", pagodaID);
			using (global::System.Collections.IEnumerator enumerator = global::DataText.TamKhong.dbex.Select(query, dictionary).Rows.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return global::DataText.BaseBO.GetInt(((global::System.Data.DataRow)enumerator.Current)["SoNo"]) + 1;
				}
			}
			return 1;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00006950 File Offset: 0x00004B50
		public static global::System.Data.DataTable getListChuSo(string pagodaID, string orderBy = "SoNo")
		{
			string query = "SELECT * FROM ChuSo WHERE PagodaID=@PagodaID ORDER BY " + orderBy;
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@PagodaID", pagodaID);
			return global::DataText.TamKhong.dbex.Select(query, dictionary);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000063AC File Offset: 0x000045AC
		public static void update(global::DataModel.Entities.Person prn)
		{
			global::DataText.TamKhong.dbex.update(prn);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00006988 File Offset: 0x00004B88
		public static void updateStatus(int id, string status)
		{
			string query = string.Concat(new string[]
			{
				"UPDATE Person SET Status='",
				status,
				"' WHERE ID='",
				id.ToString(),
				"'"
			});
			global::DataText.TamKhong.dbex.executeNonQuery(query);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000069D4 File Offset: 0x00004BD4
		public static void update(string pagodaOldID, string pagodaNewID)
		{
			string query = string.Concat(new string[]
			{
				"UPDATE Person SET PagodaID='",
				pagodaNewID,
				"' WHERE PagodaID='",
				pagodaOldID,
				"'"
			});
			global::DataText.TamKhong.dbex.executeNonQuery(query);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00006A1C File Offset: 0x00004C1C
		public static void updateID(int oldID, string newID)
		{
			string query = string.Concat(new string[]
			{
				"UPDATE Person SET Status='Sync', ID='",
				newID,
				"' WHERE ID='",
				oldID.ToString(),
				"'"
			});
			global::DataText.TamKhong.dbex.executeNonQuery(query);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00006468 File Offset: 0x00004668
		public static void set(global::DataModel.Entities.Person prn)
		{
			global::DataText.TamKhong.dbex.insert(prn);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00006A68 File Offset: 0x00004C68
		public static int setGetID(global::DataModel.Entities.Person prn)
		{
			return global::DataText.TamKhong.dbex.insertGetID(prn);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00006A80 File Offset: 0x00004C80
		public static global::DataModel.Entities.Person get(string id)
		{
			string query = "Select * from Person WHERE ID=@ID";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@ID", id);
			using (global::System.Collections.IEnumerator enumerator = global::DataText.TamKhong.dbex.Select(query, dictionary).Rows.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					global::System.Data.DataRow dataRow = (global::System.Data.DataRow)enumerator.Current;
					return new global::DataModel.Entities.Person
					{
						ID = global::DataText.BaseBO.GetString(dataRow["ID"]),
						FullName = global::DataText.BaseBO.GetString(dataRow["FullName"]),
						NamSinh = global::DataText.BaseBO.GetInt(dataRow["NamSinh"]),
						GioiTinh = global::DataText.BaseBO.GetBool(dataRow["GioiTinh"]),
						Address = global::DataText.BaseBO.GetString(dataRow["Address"]),
						PagodaID = global::DataText.BaseBO.GetString(dataRow["PagodaID"]),
						SoNo = global::DataText.BaseBO.GetInt(dataRow["SoNo"]),
						Orders = global::DataText.BaseBO.GetInt(dataRow["Orders"]),
						Status = global::DataText.BaseBO.GetString(dataRow["Status"]),
						UpdateDT = global::DataText.BaseBO.GetDateTime(dataRow["UpdateDT"])
					};
				}
			}
			return null;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00006BE4 File Offset: 0x00004DE4
		public static void delete(string id)
		{
			global::DataModel.Entities.Person person = new global::DataModel.Entities.Person();
			person.ID = id;
			person.Status = "Deleted";
			person.UpdateDT = global::System.DateTime.Now;
			global::DataText.TamKhong.dbex.update(person);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00006C20 File Offset: 0x00004E20
		public static void delete(global::DataModel.Entities.Person prn)
		{
			global::DataText.TamKhong.dbex.del("Person", "ID", prn.ID.ToString());
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00006C50 File Offset: 0x00004E50
		public static void Order(int downUp, string id, int soNo, string pagodaID)
		{
			global::System.Collections.Generic.List<global::DataModel.Entities.Person> list = global::DataText.PersonBO.smethod_0(pagodaID, soNo);
			int i = 0;
			while (i < list.Count)
			{
				int num = i;
				global::DataModel.Entities.Person person = list[i];
				if (person.Status != "Deleted")
				{
					person.Status = "Changed";
				}
				person.UpdateDT = global::System.DateTime.Now;
				if (!person.ID.Equals(id))
				{
					goto IL_10C;
				}
				if (downUp != 1)
				{
					person.Orders = i + 1;
					global::DataText.PersonBO.update(person);
					if (i < list.Count - 1)
					{
						list[i + 1].Orders = i;
						list[i + 1].Status = "Changed";
						list[i + 1].UpdateDT = global::System.DateTime.Now;
						global::DataText.PersonBO.update(list[i + 1]);
					}
					i++;
				}
				else
				{
					if (0 <= i - 1)
					{
						list[i - 1].Orders = num;
						list[i - 1].Status = "Changed";
						list[i - 1].UpdateDT = global::System.DateTime.Now;
						if (0 < i)
						{
							global::DataText.PersonBO.update(list[i - 1]);
						}
						num--;
						goto IL_10C;
					}
					goto IL_10C;
				}
				IL_119:
				i++;
				continue;
				IL_10C:
				person.Orders = num;
				global::DataText.PersonBO.update(person);
				goto IL_119;
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000065A0 File Offset: 0x000047A0
		public PersonBO()
		{
		}
	}
}
