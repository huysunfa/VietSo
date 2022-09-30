using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace AppVietSo.Models
{
    public class DbExecute
    {

        public static int executeNonQuery(string query)
        {
            int result;
            var con = new SQLiteConnection(string.Format("Data Source=TamKhong.com;Version=3"), true);
            con.Open();
            var cmd = new SQLiteCommand(con);
            cmd.CommandText = query;
            result = cmd.ExecuteNonQuery();
            return result;
        }
        // DataText.DbExecute
        // Token: 0x0600008B RID: 139 RVA: 0x000056F0 File Offset: 0x000038F0
        public static DataTable Select(string query, global::System.Collections.Generic.Dictionary<string, object> prm)
        {
            global::System.Data.DataTable result;
            try
            {
                var con = new SQLiteConnection(string.Format("Data Source=" + Util.getDataPath + "TamKhong.com;Version=3"), true);
                con.Open();

                var sqliteCommand = new SQLiteCommand(con);
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
                throw ex;
            }
            return result;
        }
        // DataText.DbExecute
        // Token: 0x0600008F RID: 143 RVA: 0x000058D0 File Offset: 0x00003AD0
        public static void update<T>(T obj)
        {
            try
            {
                var con = new SQLiteConnection(string.Format("Data Source=TamKhong.com;Version=3"), true);
                con.Open();

                global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
                global::System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();
                var sqliteCommand = new SQLiteCommand(con);
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
                                sqliteCommand.Parameters.AddWithValue(propertyInfo.Name, obj);
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
                throw ex;
            }
        }
        // DataText.DbExecute
        // Token: 0x06000090 RID: 144 RVA: 0x00005A38 File Offset: 0x00003C38
        public static void insert<T>(T obj)
        {
            try
            {
                var con = new SQLiteConnection(string.Format("Data Source=TamKhong.com;Version=3"), true);
                con.Open();

                global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
                global::System.Collections.Generic.List<string> list2 = new global::System.Collections.Generic.List<string>();
                global::System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();
                var sqliteCommand = new SQLiteCommand(con);
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
                throw ex;
            }
        }

        // DataText.DbExecute
        // Token: 0x06000091 RID: 145 RVA: 0x00005BD4 File Offset: 0x00003DD4
        public static int insertGetID<T>(T obj)
        {
            int i;

            var con = new SQLiteConnection(string.Format("Data Source=TamKhong.com;Version=3"), true);
            con.Open();

            global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
            global::System.Collections.Generic.List<string> list2 = new global::System.Collections.Generic.List<string>();
            global::System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();
            var sqliteCommand = new SQLiteCommand(con);
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

            return i;
        }
        // DataText.DbExecute
        // Token: 0x0600008D RID: 141 RVA: 0x00005848 File Offset: 0x00003A48
        public static int del(string tableName, string fieldName, string value)
        {
            int result;
            try
            {

                string query = string.Format("DELETE FROM {0} WHERE {1}='{2}'", tableName, fieldName, value);
                result = DbExecute.executeNonQuery(query);
            }
            catch (global::System.Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }