using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{

	// Token: 0x02000010 RID: 16
	public class PagodaBO  
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x00006370 File Offset: 0x00004570
		public static DataTable getAll()
		{
			string query = "Select * from Pagoda ";
		 Dictionary<string, object> prm = new global::System.Collections.Generic.Dictionary<string, object>();
			return DbExecute.Select(query, prm);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000638C File Offset: 0x0000458C
		public static global::System.Collections.Generic.List<Pagoda> getList()
		{
			string query = "Select * from Pagoda WHERE Status='Changed' OR Status='New' LIMIT 50";
			global::System.Collections.Generic.Dictionary<string, object> prm = new global::System.Collections.Generic.Dictionary<string, object>();
			return BaseBO.GetObject<Pagoda>(DbExecute.Select(query, prm));
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000063B8 File Offset: 0x000045B8
		public static global::System.Collections.Generic.List<Pagoda> getList(string pagodaID, int soNo)
		{
			string query = "Select * from Pagoda WHERE PagodaID=@PagodaID AND SoNo=@SoNo ORDER BY Orders, NamSinh ASC";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@PagodaID", pagodaID);
			dictionary.Add("@SoNo", soNo);
			return BaseBO.GetObject<Pagoda>(DbExecute.Select(query, dictionary));
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00006404 File Offset: 0x00004604
		public static void update(Pagoda pgd)
		{
			DbExecute.update(pgd, pgd.ID);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000641C File Offset: 0x0000461C
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
			DbExecute.executeNonQuery(query);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00006464 File Offset: 0x00004664
		public static void addColIsPrint()
		{
			try
			{
				string query = "ALTER TABLE Pagoda ADD COLUMN IsPrint BOOLEAN default 0";
				DbExecute.executeNonQuery(query);
			}
			catch (global::System.Data.SQLite.SQLiteException)
			{
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000649C File Offset: 0x0000469C
		public static void delete(Pagoda pgd)
		{
			DbExecute.del("Pagoda", "ID", pgd.ID);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000064C8 File Offset: 0x000046C8
		public static void set(Pagoda pgd)
		{
			DbExecute.insert(pgd);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000064E0 File Offset: 0x000046E0
		public static Pagoda get(string id)
		{
			string query = "Select * from Pagoda WHERE ID=@ID";
			global::System.Collections.Generic.Dictionary<string, object> dictionary = new global::System.Collections.Generic.Dictionary<string, object>();
			dictionary.Add("@ID", id);
			Pagoda result = new Pagoda() ;
            foreach (DataRow dataRow in DbExecute.Select(query, dictionary).Rows)
            {
 
 				result = new Pagoda
				{
					ID = BaseBO.GetString(dataRow["ID"]),
					Name = BaseBO.GetString(dataRow["Name"]),
					Address = BaseBO.GetString(dataRow["Address"]),
					Leader = BaseBO.GetString(dataRow["Leader"]),
					Phone = BaseBO.GetString(dataRow["Phone"]),
					Status = BaseBO.GetString(dataRow["Status"]),
					UpdateDT = BaseBO.GetDateTime(dataRow["UpdateDT"])
				};
			}
			return result;
 		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000660C File Offset: 0x0000480C
		public PagodaBO()
		{
		}
	}
}
