using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
 public   class LongSo
    {
        public string LoaiSo { get; set; }
        public string TenSo { get; set; }
        public string ChuGiai { get; set; }
        public string FileName { get; set; }
        public string ID { get; set; }
        public static List<LongSo> GetLongSos()
        {
            var json = new WebClient().DownloadData(Util.mainURL+"/AppSync/Catalog");
              var txt = Encoding.UTF8.GetString(json);

            var result = JsonConvert.DeserializeObject<List<LongSo>>(txt);
            return result;

        }
    }
}
