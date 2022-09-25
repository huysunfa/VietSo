using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class CsvExtentions
    {
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            if (!File.Exists(strFilePath))
            {
                return new DataTable();
            }
            var text = File.ReadAllText(strFilePath);
            return JsonConvert.DeserializeObject<DataTable>(text);
        }

        public static void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            var data = JsonConvert.SerializeObject(dtDataTable);
            File.WriteAllText(strFilePath, data);
        }
    }
}
