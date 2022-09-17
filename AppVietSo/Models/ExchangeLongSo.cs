using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class ExchangeLongSo
    {

        // Token: 0x0600015E RID: 350 RVA: 0x00007400 File Offset: 0x00005600
        public static List<LongSo> getLongSo(string cusKey, ref string error)
        {
            try
            {
                string para = "comID=" + Util.GetComputerIMEI() + "&cusKey=" + cusKey;
                return UtilModel.ConvertJSON2Obj<List<LongSo>>(Util.queryServer("AppSync/DataLongSo/", para));
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return null;
        }

        // Token: 0x0600015F RID: 351 RVA: 0x00007458 File Offset: 0x00005658
        public static bool downloadFile(string fileName)
        {
            bool result;
            try
            {
                WebClient webClient = new WebClient();
                string text = fileName.Split('@').LastOrDefault().Split('/').LastOrDefault();
                string uriString = Util.mainURL + fileName;
                webClient.DownloadFile(new Uri(uriString), text);
                string destFileName = Util.getDataPath + fileName;
                File.Copy(text, destFileName, true);
                if (File.Exists(text))
                {
                    File.Delete(text);
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool downloadFileBibe(string fileName)
        {
            bool result;
            
                fileName = fileName.Replace("\\", "//");
                WebClient webClient = new WebClient();
                string text = fileName.Split('@').LastOrDefault().Split('/').LastOrDefault();
                var uriString = new Uri(fileName).AbsoluteUri;
                webClient.DownloadFile(uriString, text);
                string destFileName = Util.getDataPath + "/FileUpload/" + text;
                File.Copy(text, destFileName, true);
                if (File.Exists(text))
                {
                    File.Delete(text);
                }
                result = true;
            
            return result;
        }

        public static bool downloadFileFont(string fileName)
        {
            bool result;
            try
            {
                WebClient webClient = new WebClient();
                string text = fileName.Split('@').LastOrDefault().Split('/').LastOrDefault();
                string uriString = Util.mainURL + fileName;
                webClient.DownloadFile(new Uri(uriString), text);
                string destFileName = Util.getDataPath + "/FontCN/" + text;
                File.Copy(text, destFileName, true);
                if (File.Exists(text))
                {
                    File.Delete(text);
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
