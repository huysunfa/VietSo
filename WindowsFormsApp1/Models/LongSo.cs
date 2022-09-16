using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class LongSo
    {
        public int SoID { get; set; }
        public string LoaiSo { get; set; }
        public string TenSo { get; set; }
        public string ChuGiai { get; set; }
        public string FileName { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public static List<LongSo> GetLongSos()
        {
            List<LongSo> data = new List<LongSo>();

            if (File.Exists(Util.getDicLongSoPath))
            {
                 data = JsonConvert.DeserializeObject<List<LongSo>>(Security.Decrypt(System.IO.File.ReadAllText(Util.getDicLongSoPath)));
            }
            if (data.Count==0)
            {
                var json = CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/GetLongSo");
                data = JsonConvert.DeserializeObject<List<LongSo>>(json);
                var output = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                output = Security.Encrypt(output);
                System.IO.File.WriteAllText(Util.getDicLongSoPath, output);
            }
          
            return data;
        }
    }
}
