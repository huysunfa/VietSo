using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using DataModel.Entities;

namespace DataText
{
	// Token: 0x02000010 RID: 16
	public class PagodaBO : global::DataText.TamKhong
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x0000631C File Offset: 0x0000451C
		public static global::System.Data.DataTable getAll()
		{
			return global::DataText.TamKhong.dbex.Select(new global::DataModel.Entities.Pagoda());
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00006338 File Offset: 0x00004538
		public static global::System.Collections.Generic.List<global::DataModel.Entities.Pagoda> getList()
		{
			string query = "Select * from Pagoda WHERE Status='Changed' OR Status='New' LIMIT 50";
			global::System.Collections.Generic.Dictionary<string, object> prm = new global::System.Collections.Generic.Dictionary<string, object>();
			return global::DataText.BaseBO.GetObject<global::DataModel.Entities.Pagoda>(global::DataText.TamKhong.dbex.Select(query, prm));
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00006364 File Offset: 0x00004564
		public static global::System.Collections.Generic.List<global::DataModel.Entities.Pagoda> getList(string pagodaID, int soNo)
		{
			string query = "Select * from Pagoda WHERE PagodaID=@PagodaID AND SoNo=@SoNo ORDER BY Orders, NamSinh ASC";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@PagodaID", pagodaID);
			dictionary.Add("@SoNo", soNo);
			return global::DataText.BaseBO.GetObject<global::DataModel.Entities.Pagoda>(global::DataText.TamKhong.dbex.Select(query, dictionary));
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000063AC File Offset: 0x000045AC
		public static void update(global::DataModel.Entities.Pagoda pgd)
		{
			global::DataText.TamKhong.dbex.update(pgd);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000063C4 File Offset: 0x000045C4
		public static void update(string oldID, string newID)
		{
			string query = string.Concat(new string[]
			{
				"UPDATE Pagoda SET Status='Sync', ID='",
				newID,
				"' WHERE ID='",
				oldID,
				"'"
			});
			global::DataText.TamKhong.dbex.executeNonQuery(query);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000640C File Offset: 0x0000460C
		public static void addColIsPrint()
		{
			try
			{
				string query = "ALTER TABLE Pagoda ADD COLUMN IsPrint BOOLEAN default 0";
				global::DataText.TamKhong.dbex.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00006440 File Offset: 0x00004640
		public static void delete(global::DataModel.Entities.Pagoda pgd)
		{
			global::DataText.TamKhong.dbex.del("Pagoda", "ID", pgd.ID);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00006468 File Offset: 0x00004668
		public static void set(global::DataModel.Entities.Pagoda pgd)
		{
			global::DataText.TamKhong.dbex.insert(pgd);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00006480 File Offset: 0x00004680
		public static global::DataModel.Entities.Pagoda get(string id)
		{
			string query = "Select * from Pagoda WHERE ID=@ID";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@ID", id);
			global::DataModel.Entities.Pagoda result;
			using (global::System.Collections.IEnumerator enumerator = global::DataText.TamKhong.dbex.Select(query, dictionary).Rows.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					goto IL_102;
				}
				global::System.Data.DataRow dataRow = (global::System.Data.DataRow)enumerator.Current;
				result = new global::DataModel.Entities.Pagoda
				{
					ID = global::DataText.BaseBO.GetString(dataRow["ID"]),
					Name = global::DataText.BaseBO.GetString(dataRow["Name"]),
					Address = global::DataText.BaseBO.GetString(dataRow["Address"]),
					Leader = global::DataText.BaseBO.GetString(dataRow["Leader"]),
					Phone = global::DataText.BaseBO.GetString(dataRow["Phone"]),
					Status = global::DataText.BaseBO.GetString(dataRow["Status"]),
					UpdateDT = global::DataText.BaseBO.GetDateTime(dataRow["UpdateDT"])
				};
			}
			return result;
			IL_102:
			return null;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000065A0 File Offset: 0x000047A0
		public PagodaBO()
		{
		}
	}
}
