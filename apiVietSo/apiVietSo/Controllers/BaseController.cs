using apiVietSo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apiVietSo.Controllers
{
    [LoginAuth]
    public class BaseController : Controller
    {
        public vietsoEntities db = new vietsoEntities();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Upload File
        public List<string> SubmitFile(HttpPostedFileBase files)
        {
            if (files== null)
            {
                return new List<string>();
            }
            List<HttpPostedFileBase> input = new List<HttpPostedFileBase>();
            input.Add(files);
            var output = SubmitFile(input);
            return output;
        }
        public List<string> SubmitFile(List<HttpPostedFileBase> files)
        {

            List<string> FileUp = new List<string>();
            if (files == null)
            {
                return FileUp;
            }
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                if (file == null)
                {
                    continue;
                }
                string fname;
                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    var g = Guid.NewGuid().ToString().Split('-').FirstOrDefault();
                    fname = g + DateTime.Now.ToString("ddhhmmss") + "@" + file.FileName;
                }
                System.IO.Directory.CreateDirectory(Server.MapPath("~/FileUpload/"));

                string ext = Path.GetExtension(fname);
                string newnane = "/FileUpload/" + fname;
                FileUp.Add(newnane);

                fname = Path.Combine(Server.MapPath("~/FileUpload/"), fname);
                file.SaveAs(fname);
            }

            return FileUp;
        }


        #endregion
    }
}