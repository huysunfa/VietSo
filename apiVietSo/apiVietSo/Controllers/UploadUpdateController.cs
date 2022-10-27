using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apiVietSo.Controllers
{
    public class UploadUpdateController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImport(List<HttpPostedFileBase> baseFile = null)
        {
            var url1 = uploadFile(baseFile).ToList();
            //var UrlFile = ((baseFile != null) ? url1[1].Substring(1, url1[1].Length - 1) : null);


            var temp = Server.MapPath("~/FileUpload/temp");
            //if (System.IO.Directory.Exists(temp))
            //{
            //    System.IO.Directory.Delete(temp, true);
            //}
            //Directory.CreateDirectory(temp);
            //foreach (var f in url1)
            //{
            //    var dic = temp +"/"+ Path.GetFileName(f);
            //    System.IO.File.Copy(f, dic);
            //}

            var archive = Server.MapPath("~/FileUpload/Updated.zip");

            if (System.IO.File.Exists(archive))
            {
                System.IO.File.Delete(archive);
            }
            ZipFile.CreateFromDirectory(temp, archive);

            var exe = url1.Where(v => v.EndsWith(".exe")).FirstOrDefault();
            if (exe != null)
            {
                var ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(temp + "/" + exe).FileVersion;
                db.Database.ExecuteSqlCommand($"update labeltext set Title='{ver}' where label='version'");
            }
            return Content("Import OK");

        }



        public List<string> uploadFile(List<HttpPostedFileBase> files, int? idFile = 0)
        {
            string Root_Path = "~/FileUpload/temp";
            var result = new List<string>();
            foreach (var file in files)
            {

                if (file != null)
                {
                    List<string> listEx = new List<string>("pdf".Split('|'));
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    //if (listEx.IndexOf(extension.Replace(".", "")) > -1)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var Name = Path.GetFileName(file.FileName);
                        var datenow = DateTime.Now;
                        //string[] time = datenow.ToString("dd:MM:yy:HH:mm:ss").Split(':');
                        var filePath = Path.Combine(Request.MapPath(Root_Path));
                        if (!System.IO.File.Exists(filePath)) Directory.CreateDirectory(filePath);
                        string fileNameOnyly = fileName.ToString();
                        fileName = fileNameOnyly;
                        filePath = Path.Combine(filePath, fileName);
                        file.SaveAs(filePath);
                        result.Add(fileName);
                    }
                }
            }
            return result;

        }

    }
}