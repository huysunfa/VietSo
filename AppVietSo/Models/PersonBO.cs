using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
	public class PersonBO 
	{
		// Token: 0x060000FB RID: 251 RVA: 0x00006620 File Offset: 0x00004820
		public static void addColNgayMat()
		{
			try
			{
				string query = "ALTER TABLE Person ADD COLUMN NgayMat TEXT";
				TamKhong.dbex.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00006658 File Offset: 0x00004858
		public static void addColDanhXung()
		{
			try
			{
				string query = "ALTER TABLE Person ADD COLUMN DanhXung TEXT";
				TamKhong.dbex.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00006690 File Offset: 0x00004890
		public static void addAlterView()
		{
			try
			{
				string query = "DROP VIEW ChuSo;\r\nCREATE VIEW ChuSo AS SELECT * FROM Person AS ps\r\nWHERE ps.id=(SELECT ID FROM Person ps1 WHERE ps.SoNo=ps1.SoNo AND ps.PagodaID=ps1.PagodaID AND (Status<>'Deleted' OR Status IS NULL) AND (NgayMat='' OR NgayMat IS NULL) ORDER BY Orders, NamSinh ASC LIMIT 1);";
				TamKhong.dbex.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000066C8 File Offset: 0x000048C8
		public static global::System.Data.DataTable getAll()
		{
			return TamKhong.dbex.Select(new global::DataModel.Entities.Person());
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000066E4 File Offset: 0x000048E4
		public static global::System.Collections.Generic.List<global::DataModel.Entities.Person> getList()
		{
			string query = "Select * from Person WHERE Status='Changed' OR Status='New' OR Status='Deleted' LIMIT 200";
			global::System.Collections.Generic.Dictionary<string, object> prm = new global::System.Collections.Generic.Dictionary<string, object>();
			return BaseBO.GetObject<global::DataModel.Entities.Person>(TamKhong.dbex.Select(query, prm));
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00006710 File Offset: 0x00004910
		public static global::System.Data.DataTable getList(string pagodaID)
		{
			string query = "Select * from Person WHERE PagodaID=@PagodaID AND (Status<>'Deleted' OR Status IS NULL) ORDER BY SoNo, Orders, NamSinh ASC";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@PagodaID", pagodaID);
			return TamKhong.dbex.Select(query, dictionary);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00006744 File Offset: 0x00004944
		private static global::System.Collections.Generic.List<global::DataModel.Entities.Person> \u206B\u206C\u202E\u202A\u206D\u202B\u200F\u200D\u200E\u202C\u206C\u202C\u206F\u206A\u206D\u200D\u200E\u200C\u206F\u200D\u206E\u202E\u206D\u206F\u200F\u200F\u206A\u202A\u200C\u202E\u200C\u202B\u202D\u200D\u206A\u202A\u206C\u202C\u200C\u202E\u202E(string A_0, int A_1)
		{
			string query = "Select * from Person WHERE PagodaID=@PagodaID AND SoNo=@SoNo ORDER BY Orders, NamSinh ASC";
		global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
		dictionary.Add("@PagodaID", A_0);
			dictionary.Add("@SoNo", A_1);
			return BaseBO.GetObject<global::DataModel.Entities.Person>(TamKhong.dbex.Select(query, dictionary));
		}

	// Token: 0x06000102 RID: 258 RVA: 0x00006790 File Offset: 0x00004990
	public static global::System.Collections.Generic.List<global::DataModel.Entities.Person> getList(string pagodaID, Family fml)
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
		return BaseBO.GetObject<global::DataModel.Entities.Person>(TamKhong.dbex.Select(query, dictionary));
	}

	// Token: 0x06000103 RID: 259 RVA: 0x00006824 File Offset: 0x00004A24
	public static global::System.Collections.Generic.List<global::DataModel.Entities.Person> getHuonglinhs(string pagodaID, Family fml)
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
		return BaseBO.GetObject<global::DataModel.Entities.Person>(TamKhong.dbex.Select(query, dictionary));
	}

	// Token: 0x06000104 RID: 260 RVA: 0x000068B8 File Offset: 0x00004AB8
	public static global::System.Collections.Generic.List<int> getListSoNo(string pagodaID)
	{
		string query = "Select SoNo from Person WHERE PagodaID=@PagodaID AND (Status<>'Deleted' OR Status IS NULL) GROUP BY SoNo";
		global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
		dictionary.Add("@PagodaID", pagodaID);
		global::System.Data.DataTable dataTable = TamKhong.dbex.Select(query, dictionary);
		global::System.Collections.Generic.List<int> list = new global::System.Collections.Generic.List<int>();
		foreach (object obj in dataTable.Rows)
		{
			global::System.Data.DataRow dataRow = (global::System.Data.DataRow)obj;
			list.Add(BaseBO.GetInt(dataRow["SoNo"]));
		}
		return list;
	}

	// Token: 0x06000105 RID: 261 RVA: 0x00006954 File Offset: 0x00004B54
	public static int getNewSoNo(string pagodaID)
	{
		string query = "SELECT * FROM Person WHERE PagodaID=@PagodaID ORDER BY SoNo DESC LIMIT 1";
		global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
		dictionary.Add("@PagodaID", pagodaID);
		using (global::System.Collections.IEnumerator enumerator = TamKhong.dbex.Select(query, dictionary).Rows.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return BaseBO.GetInt(((global::System.Data.DataRow)enumerator.Current)["SoNo"]) + 1;
			}
		}
		return 1;
	}

	// Token: 0x06000106 RID: 262 RVA: 0x000069E4 File Offset: 0x00004BE4
	public static global::System.Data.DataTable getListChuSo(string pagodaID, string orderBy = "SoNo")
	{
		string query = "SELECT * FROM ChuSo WHERE PagodaID=@PagodaID ORDER BY " + orderBy;
		global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
		dictionary.Add("@PagodaID", pagodaID);
		return TamKhong.dbex.Select(query, dictionary);
	}

	// Token: 0x06000107 RID: 263 RVA: 0x00006404 File Offset: 0x00004604
	public static void update(global::DataModel.Entities.Person prn)
	{
		TamKhong.dbex.update(prn);
	}

	// Token: 0x06000108 RID: 264 RVA: 0x00006A20 File Offset: 0x00004C20
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
		TamKhong.dbex.executeNonQuery(query);
	}

	// Token: 0x06000109 RID: 265 RVA: 0x00006A70 File Offset: 0x00004C70
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
		TamKhong.dbex.executeNonQuery(query);
	}

	// Token: 0x0600010A RID: 266 RVA: 0x00006AB8 File Offset: 0x00004CB8
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
		TamKhong.dbex.executeNonQuery(query);
	}

	// Token: 0x0600010B RID: 267 RVA: 0x000064C8 File Offset: 0x000046C8
	public static void set(global::DataModel.Entities.Person prn)
	{
		TamKhong.dbex.insert(prn);
	}

	// Token: 0x0600010C RID: 268 RVA: 0x00006B08 File Offset: 0x00004D08
	public static int setGetID(global::DataModel.Entities.Person prn)
	{
		return TamKhong.dbex.insertGetID(prn);
	}

	// Token: 0x0600010D RID: 269 RVA: 0x00006B20 File Offset: 0x00004D20
	public static global::DataModel.Entities.Person get(string id)
	{
		string query = "Select * from Person WHERE ID=@ID";
		global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
		dictionary.Add("@ID", id);
		using (global::System.Collections.IEnumerator enumerator = TamKhong.dbex.Select(query, dictionary).Rows.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				global::System.Data.DataRow dataRow = (global::System.Data.DataRow)enumerator.Current;
				return new global::DataModel.Entities.Person
				{
					ID = BaseBO.GetString(dataRow["ID"]),
					FullName = BaseBO.GetString(dataRow["FullName"]),
					NamSinh = BaseBO.GetInt(dataRow["NamSinh"]),
					GioiTinh = BaseBO.GetBool(dataRow["GioiTinh"]),
					Address = BaseBO.GetString(dataRow["Address"]),
					PagodaID = BaseBO.GetString(dataRow["PagodaID"]),
					SoNo = BaseBO.GetInt(dataRow["SoNo"]),
					Orders = BaseBO.GetInt(dataRow["Orders"]),
					Status = BaseBO.GetString(dataRow["Status"]),
					UpdateDT = BaseBO.GetDateTime(dataRow["UpdateDT"])
				};
			}
		}
		return null;
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00006C9C File Offset: 0x00004E9C
	public static void delete(string id)
	{
		global::DataModel.Entities.Person person = new global::DataModel.Entities.Person();
		person.ID = id;
		person.Status = "Deleted";
		person.UpdateDT = global::System.DateTime.Now;
		TamKhong.dbex.update(person);
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00006CD8 File Offset: 0x00004ED8
	public static void delete(global::DataModel.Entities.Person prn)
	{
		TamKhong.dbex.del("Person", "ID", prn.ID.ToString());
	}

	// Token: 0x06000110 RID: 272 RVA: 0x00006D08 File Offset: 0x00004F08
	public static void Order(int downUp, string id, int soNo, string pagodaID)
	{
		global::System.Collections.Generic.List<global::DataModel.Entities.Person> list = PersonBO.\u206B\u206C\u202E\u202A\u206D\u202B\u200F\u200D\u200E\u202C\u206C\u202C\u206F\u206A\u206D\u200D\u200E\u200C\u206F\u200D\u206E\u202E\u206D\u206F\u200F\u200F\u206A\u202A\u200C\u202E\u200C\u202B\u202D\u200D\u206A\u202A\u206C\u202C\u200C\u202E\u202E(pagodaID, soNo);
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
				goto IL_110;
			}
			if (downUp != 1)
			{
				person.Orders = i + 1;
				PersonBO.update(person);
				if (i < list.Count - 1)
				{
					list[i + 1].Orders = i;
					list[i + 1].Status = "Changed";
					list[i + 1].UpdateDT = global::System.DateTime.Now;
					PersonBO.update(list[i + 1]);
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
						PersonBO.update(list[i - 1]);
					}
					num--;
					goto IL_110;
				}
				goto IL_110;
			}
			IL_11D:
			i++;
			continue;
			IL_110:
			person.Orders = num;
			PersonBO.update(person);
			goto IL_11D;
		}
	}

	// Token: 0x06000111 RID: 273 RVA: 0x0000660C File Offset: 0x0000480C
	public PersonBO()
	{
	}
}
}
