using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsConvertBibe
{
    class BulkCopy
    {
        static string StrConnection = @"Data Source=112.78.2.154;Initial Catalog=lts43636_vietso;;User ID=lts43636_vietso;Password=Vietso123;";
        public void BulkInsertAll(DataTable table, string tbName)
        {
            using (var conn = new SqlConnection(StrConnection))
            {
                conn.Open();


                var bulkCopy = new SqlBulkCopy(conn)
                {
                    DestinationTableName = tbName
                };

                bulkCopy.WriteToServer(table);
            }
        }

        public void BulkInsertAll<T>(IEnumerable<T> entities, string tbName)
        {
            using (var conn = new SqlConnection(StrConnection))
            {
                conn.Open();

                Type t = typeof(T);

                var bulkCopy = new SqlBulkCopy(conn)
                {
                    DestinationTableName = tbName
                };

                var properties = t.GetProperties().Where(EventTypeFilter).ToArray();
                var table = new DataTable();

                foreach (var property in properties)
                {
                    Type propertyType = property.PropertyType;
                    if (propertyType.IsGenericType &&
                        propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        propertyType = Nullable.GetUnderlyingType(propertyType);
                    }

                    table.Columns.Add(new DataColumn(property.Name, propertyType));
                }
                int a = 0;
                foreach (var entity in entities)
                {
                    table.Rows.Add(
                        properties.Select(
                        property => property.GetValue(entity, null) ?? DBNull.Value
                        ).ToArray());
                    a++;
                }
                int bulkCopyTimeout = 100000000;

                bulkCopy.BulkCopyTimeout = bulkCopyTimeout;

                bulkCopy.WriteToServer(table);
            }
        }

        private bool EventTypeFilter(System.Reflection.PropertyInfo p)
        {
            var attribute = Attribute.GetCustomAttribute(p,
                typeof(AssociationAttribute)) as AssociationAttribute;

            if (attribute == null) return true;
            if (attribute.IsForeignKey == false) return true;

            return false;
        }
    }
}
