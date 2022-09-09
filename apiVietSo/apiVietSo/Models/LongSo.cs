using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiVietSo.Models
{
    public class LongSo
    {
        public string LoaiSo { get; set; }
        public string TenSo { get; set; }
        public string ChuGiai { get; set; }
        public string FileName { get; set; }
        public string ID { get; set; }
        public static List<LongSo> GetLongSos()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + @"\FileUpload\Catalog.json";
            var json = System.IO.File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<List<LongSo>>(json);
            return result;

        }
    }
}
