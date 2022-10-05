using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using CommonModel;

namespace DataText
{
	// Token: 0x0200000E RID: 14
	public class DbExecute
	{
		// Token: 0x06000081 RID: 129 RVA: 0x000054B0 File Offset: 0x000036B0
		public DbExecute(string string_1)
		{
			this.sqliteConnection_0 = new global::System.Data.SQLite.SQLiteConnection(string_1, true);
			this.method_0();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000054D8 File Offset: 0x000036D8
		private void method_0()
		{
			try
			{
				if (this.sqliteConnection_0.State != global::System.Data.ConnectionState.Open)
				{
					this.sqliteConnection_0.Close();
					this.sqliteConnection_0.Open();
				}
			}
			catch (global::System.Exception ex)
			{
				throw new global::System.Exception(this.sqliteConnection_0.ConnectionString + ",  " + ex.Message);
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005540 File Offset: 0x00003740
		private void method_1()
		{
			if (this.sqliteConnection_0 != null)
			{
				this.sqliteConnection_0.Close();
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00005560 File Offset: 0x00003760
		public void beginTransaction()
		{
			this.sqliteTransaction_0 = this.sqliteConnection_0.BeginTransaction();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00005580 File Offset: 0x00003780
		public void commit()
		{
			this.sqliteTransaction_0.Commit();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005598 File Offset: 0x00003798
		public void rollback()
		{
			this.sqliteTransaction_0.Rollback();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000055B0 File Offset: 0x000037B0
		public int executeNonQuery(string query)
		{
			int result;
			try
			{
				this.method_0();
				result = new global::System.Data.SQLite.SQLiteCommand(query, this.sqliteConnection_0).ExecuteNonQuery();
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
			return result;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000055F0 File Offset: 0x000037F0
		public int executeNonQuery(global::System.Data.SQLite.SQLiteCommand command)
		{
			int result;
			try
			{
				if (command == null)
				{
					result = 0;
				}
				else
				{
					this.method_0();
					command.Connection = this.sqliteConnection_0;
					result = command.ExecuteNonQuery();
				}
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
			return result;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005638 File Offset: 0x00003838
		public object executeScalar(string query)
		{
			object result;
			try
			{
				this.method_0();
				result = new global::System.Data.SQLite.SQLiteCommand(query, this.sqliteConnection_0).ExecuteScalar();
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
			return result;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00005678 File Offset: 0x00003878
		public global::System.Data.DataTable Select(string query)
		{
			global::System.Data.DataTable result;
			try
			{
				this.method_0();
				global::System.Data.DataSet dataSet = new global::System.Data.DataSet();
				using (global::System.Data.SQLite.SQLiteDataAdapter sqliteDataAdapter = new global::System.Data.SQLite.SQLiteDataAdapter(query, this.sqliteConnection_0))
				{
					sqliteDataAdapter.Fill(dataSet);
				}
				result = dataSet.Tables[0];
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
			return result;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000056E8 File Offset: 0x000038E8
		public global::System.Data.DataTable Select(string query, global::System.Collections.Generic.Dictionary<string, object> prm)
		{
			global::System.Data.DataTable result;
			try
			{
				this.method_0();
				global::System.Data.SQLite.SQLiteCommand sqliteCommand = this.sqliteConnection_0.CreateCommand();
				sqliteCommand.CommandText = query;
				foreach (global::System.Collections.Generic.KeyValuePair<string, object> keyValuePair in prm)
				{
					sqliteCommand.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
				}
				global::System.Data.DataSet dataSet = new global::System.Data.DataSet();
				using (global::System.Data.SQLite.SQLiteDataAdapter sqliteDataAdapter = new global::System.Data.SQLite.SQLiteDataAdapter(sqliteCommand))
				{
					sqliteDataAdapter.Fill(dataSet);
				}
				result = dataSet.Tables[0];
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
			return result;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000057BC File Offset: 0x000039BC
		public global::System.Data.DataTable Select(global::CommonModel.AKT obj)
		{
			global::System.Data.DataTable result;
			try
			{
				this.method_0();
				global::System.Data.DataSet dataSet = new global::System.Data.DataSet();
				using (global::System.Data.SQLite.SQLiteDataAdapter sqliteDataAdapter = new global::System.Data.SQLite.SQLiteDataAdapter("Select * from " + obj.GetType().Name, this.sqliteConnection_0))
				{
					sqliteDataAdapter.Fill(dataSet);
				}
				result = dataSet.Tables[0];
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
			return result;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005840 File Offset: 0x00003A40
		public int del(string tableName, string fieldName, string value)
		{
			int result;
			try
			{
				this.method_0();
				string query = string.Format("DELETE FROM {0} WHERE {1}='{2}'", tableName, fieldName, value);
				result = this.executeNonQuery(query);
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
			return result;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00005884 File Offset: 0x00003A84
		public int del(string tableName, string whereCondition)
		{
			int result;
			try
			{
				this.method_0();
				string query = string.Format("DELETE FROM {0} WHERE {1}", tableName, whereCondition);
				result = this.executeNonQuery(query);
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
			return result;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000058C8 File Offset: 0x00003AC8
		public void update(global::CommonModel.AKT obj)
		{
			try
			{
				this.method_0();
				global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
				global::System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();
				global::System.Data.SQLite.SQLiteCommand sqliteCommand = new global::System.Data.SQLite.SQLiteCommand(this.sqliteConnection_0);
				foreach (global::System.Reflection.PropertyInfo propertyInfo in properties)
				{
					if (!(propertyInfo.GetSetMethod() == null))
					{
						object value = propertyInfo.GetValue(obj, null);
						if (value != null && !value.Equals(default(global::System.DateTime)))
						{
							if (!propertyInfo.Name.Equals("ID", global::System.StringComparison.OrdinalIgnoreCase))
							{
								list.Add(propertyInfo.Name + "=:" + propertyInfo.Name);
								sqliteCommand.Parameters.AddWithValue(propertyInfo.Name, value);
							}
							else
							{
								sqliteCommand.Parameters.AddWithValue(propertyInfo.Name, obj.getId());
							}
						}
					}
				}
				string commandText = string.Concat(new string[]
				{
					"UPDATE ",
					obj.GetType().Name,
					" SET ",
					string.Join(", ", list),
					" WHERE Id=:ID"
				});
				sqliteCommand.CommandText = commandText;
				sqliteCommand.ExecuteNonQuery();
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00005A28 File Offset: 0x00003C28
		public void insert(global::CommonModel.AKT obj)
		{
			try
			{
				this.method_0();
				global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
				global::System.Collections.Generic.List<string> list2 = new global::System.Collections.Generic.List<string>();
				global::System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();
				global::System.Data.SQLite.SQLiteCommand sqliteCommand = new global::System.Data.SQLite.SQLiteCommand(this.sqliteConnection_0);
				foreach (global::System.Reflection.PropertyInfo propertyInfo in properties)
				{
					if (!(propertyInfo.GetSetMethod() == null))
					{
						object value = propertyInfo.GetValue(obj, null);
						if (value != null && !value.Equals(default(global::System.DateTime)) && (!(propertyInfo.PropertyType == typeof(int)) || !value.Equals(0) || !propertyInfo.Name.Equals("ID", global::System.StringComparison.OrdinalIgnoreCase)))
						{
							list.Add(propertyInfo.Name);
							list2.Add(":" + propertyInfo.Name);
							sqliteCommand.Parameters.AddWithValue(propertyInfo.Name, value);
						}
					}
				}
				string commandText = string.Concat(new string[]
				{
					"INSERT INTO ",
					obj.GetType().Name,
					" (",
					string.Join(", ", list),
					") VALUES (",
					string.Join(", ", list2),
					")"
				});
				sqliteCommand.CommandText = commandText;
				sqliteCommand.ExecuteNonQuery();
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00005BBC File Offset: 0x00003DBC
		public int insertGetID(global::CommonModel.AKT obj)
		{
			int i;
			try
			{
				this.method_0();
				global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
				global::System.Collections.Generic.List<string> list2 = new global::System.Collections.Generic.List<string>();
				global::System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();
				global::System.Data.SQLite.SQLiteCommand sqliteCommand = new global::System.Data.SQLite.SQLiteCommand(this.sqliteConnection_0);
				foreach (global::System.Reflection.PropertyInfo propertyInfo in properties)
				{
					if (!(propertyInfo.GetSetMethod() == null))
					{
						object value = propertyInfo.GetValue(obj, null);
						if (value != null && !value.Equals(default(global::System.DateTime)) && (!(propertyInfo.PropertyType == typeof(int)) || !value.Equals(0) || !propertyInfo.Name.Equals("ID", global::System.StringComparison.OrdinalIgnoreCase)))
						{
							list.Add(propertyInfo.Name);
							list2.Add(":" + propertyInfo.Name);
							sqliteCommand.Parameters.AddWithValue(propertyInfo.Name, value);
						}
					}
				}
				string str = string.Concat(new string[]
				{
					"INSERT INTO ",
					obj.GetType().Name,
					" (",
					string.Join(", ", list),
					") VALUES (",
					string.Join(", ", list2),
					")"
				});
				sqliteCommand.CommandText = str + "; select last_insert_rowid();";
				i = int.Parse(sqliteCommand.ExecuteScalar().ToString());
			}
			catch (global::System.Exception ex)
			{
				this.method_1();
				throw ex;
			}
			return i;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00005D64 File Offset: 0x00003F64
		public static void setPassword(string dbName)
		{
			try
			{
				global::System.Data.SQLite.SQLiteConnection sqliteConnection = new global::System.Data.SQLite.SQLiteConnection(string.Format("Data Source={0};Password={1}", dbName, global::DataText.DbExecute.string_0));
				sqliteConnection.Open();
				new global::System.Data.SQLite.SQLiteCommand("VACUUM", sqliteConnection).ExecuteNonQuery();
				sqliteConnection.ChangePassword(global::DataText.DbExecute.string_0);
				sqliteConnection.Close();
			}
			catch
			{
				global::System.Data.SQLite.SQLiteConnection sqliteConnection2 = new global::System.Data.SQLite.SQLiteConnection(string.Format("Data Source={0}", dbName));
				sqliteConnection2.Open();
				new global::System.Data.SQLite.SQLiteCommand("VACUUM", sqliteConnection2).ExecuteNonQuery();
				sqliteConnection2.ChangePassword(global::DataText.DbExecute.string_0);
				sqliteConnection2.Close();
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00005E00 File Offset: 0x00004000
		public static void removePassword(string dbName)
		{
			global::System.Data.SQLite.SQLiteConnection sqliteConnection = new global::System.Data.SQLite.SQLiteConnection(string.Format("Data Source={0};Password={1}", dbName, global::DataText.DbExecute.string_0));
			sqliteConnection.Open();
			sqliteConnection.ChangePassword(null);
			sqliteConnection.Close();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00005E34 File Offset: 0x00004034
		// Note: this type is marked as 'beforefieldinit'.
		static DbExecute()
		{
		}

		// Token: 0x0400003F RID: 63
		private global::System.Data.SQLite.SQLiteConnection sqliteConnection_0;

		// Token: 0x04000040 RID: 64
		private global::System.Data.SQLite.SQLiteTransaction sqliteTransaction_0;

		// Token: 0x04000041 RID: 65
		private static string string_0 = "TamKhong.Com@gmail.com";
	}
}
