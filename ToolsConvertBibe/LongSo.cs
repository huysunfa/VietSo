using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
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
        public string NameFileOnly { get { return (FileName+"").Replace("\\","/").Split('/').LastOrDefault(); } }

       
    }
}
