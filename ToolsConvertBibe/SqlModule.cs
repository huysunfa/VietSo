using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ToolsConvertBibe
{
    public class SqlModule
    {
        static string StrConnection = @"Data Source=112.78.2.154;Initial Catalog=lts43636_vietso;;User ID=lts43636_vietso;Password=Vietso123;";
        public static DataTable GetDataTable(string sql, params object[] parameters)
        {
            DataTable result = new DataTable();
            SqlConnection conn = new SqlConnection(StrConnection);
            if (conn == null)
            {
                throw new InvalidCastException("SqlConnection is invalid for this database");
            }
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters);
                cmd.CommandTimeout = 9999;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    result.Load(reader);
                }
                conn.Close();

                return result;
            }
        }

        public static void ExcuteCommand(string CommandStr = "")
        {
            SqlConnection conn = new SqlConnection(StrConnection);
            if (conn == null)
            {
                throw new InvalidCastException("SqlConnection is invalid for this database");
            }
            var CMD = new SqlCommand(CommandStr, conn);
            conn.Open();
            CMD.CommandTimeout = 9999;
            CMD.ExecuteNonQuery();

            conn.Close();
        }

    }
}
 