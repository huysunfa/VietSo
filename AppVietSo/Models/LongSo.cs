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

        public static List<LongSo> GetLongSos(bool require =false)
        {
            List<LongSo> data = new List<LongSo>();

            if (File.Exists(Util.getDicLongSoPath))
            {
                data = JsonConvert.DeserializeObject<List<LongSo>>(Security.Decrypt(System.IO.File.ReadAllText(Util.getDicLongSoPath)));
            }
            if (data.Count == 0 || require)
            {
                var json = CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/GetLongSo");
                data = JsonConvert.DeserializeObject<List<LongSo>>(json);
                var output = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                output = Security.Encrypt(output);
                System.IO.File.WriteAllText(Util.getDicLongSoPath, output);
            }

            return data;
        }
        public static string GetDefault()
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory + "/Data/FileUpload/";
            if (Directory.GetFiles(path, "*" + ConstData.ExtentionsFile).Count() == 0)
            {
                ExchangeLongSo.downloadFile("/FileUpload/LePhat.hc");
            }
            var macdinh = Directory.GetFiles(path, "*" + ConstData.ExtentionsFile).OrderByDescending(z => new FileInfo(z).CreationTime).FirstOrDefault();
            if (!String.IsNullOrEmpty(macdinh))
            {
                var file = new FileInfo(macdinh);
                return "/FileUpload/" + file.Name;
            }
            else
            {

            }
            return null;
        }
        public static void saveToFile()
        {
            if (Util.LongSoHienTai != null && Util.LongSoHienTai.LgSo.Count > 0)
            {
                LongSoData.save(Util.LongSoHienTai);
            }
        }
        public static void loadDataLongSo()
        {
            saveToFile();

            if (string.IsNullOrEmpty(Util.NameLongSoHienTai))
            {
                Util.NameLongSoHienTai = GetDefault();
            }
            var LSo = new LongSo();
            LSo.FileName = Util.NameLongSoHienTai;
            LSo.TenSo = LongSo.GetTenSoByFileName(LSo.FileName).TenSo;

            if (string.IsNullOrEmpty(LSo.TenSo))
            {
                LSo.TenSo = LSo.FileName;
                LSo.TenSo = LSo.TenSo.Split('/').LastOrDefault();
                LSo.TenSo = LSo.TenSo.Split('.').FirstOrDefault();
            }
            Util.LongSoHienTai = LongSoData.get(LSo.FileName, LSo);
           
        }
        public static LongSo GetTenSoByFileName(string FileName)
        {
            FileName = FileName + "";
            FileName = FileName.Replace("\\", "/").Split('/').LastOrDefault();
            var output = LongSo.GetLongSos().Where(v => v.NameFileOnly.Contains(FileName)).FirstOrDefault();
            if (output == null)
            {

                var tenso = FileName.Replace("\\","/").Split('/').LastOrDefault().Split('.').FirstOrDefault();
                return new LongSo() { FileName = FileName, TenSo = tenso };
            }
            return output;
        }
    }
}
