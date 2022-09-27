using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Updated
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://ltsgroup.xyz/AppSync/GetVersion";
            using (var webClient = new System.Net.WebClient())
            {
                var result = webClient.DownloadData(url);
                var htmlCode = Encoding.UTF8.GetString(result);
         var path= System.AppDomain.CurrentDomain.BaseDirectory;

                var localpath = path+ "AppVietSo.exe";
                var localVersion = FileVersionInfo.GetVersionInfo(localpath);

                if (localVersion.FileVersion != htmlCode)
                {
                    webClient.DownloadFile("https://ltsgroup.xyz/FileUpload/Update.z", "Update.z");
                }

            }
        }
    }
}
