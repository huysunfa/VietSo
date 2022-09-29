using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
                    var filename = "Update.z";
                    webClient.DownloadFile("http://ltsgroup.xyz/FileUpload/Updated.zip", filename);


                    using (ZipArchive archive = ZipFile.OpenRead(filename))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                             
                                // Gets the full path to ensure that relative segments are removed.
                                string destinationPath = Path.GetFullPath(Path.Combine(path, entry.FullName));

                                // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                                // are case-insensitive.
                                if (destinationPath.StartsWith(path, StringComparison.Ordinal))
                                    entry.ExtractToFile(destinationPath,true);
                          
                        }
                    }

                    var listfilelocal = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data", "*.config").ToList();
                    foreach (var item in listfilelocal)
                    {
                        File.Delete(item);
                    }

                    //     ZipFile.ExtractToDirectory(filename, localpath);
                    Process.Start("AppVietSo.exe");
                }

            }
        }

    
    }
}
