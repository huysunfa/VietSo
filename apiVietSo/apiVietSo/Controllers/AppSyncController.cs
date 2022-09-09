using apiVietSo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace apiVietSo.Controllers
{
    public class AppSyncController : Controller
    {
        public ActionResult Catalog()
        {

            var data = LongSo.GetLongSos();
            var result = new List<LongSo>();
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + @"\FileUpload";
            var fileArray = Directory.GetFiles(path, "*.hc", SearchOption.AllDirectories).Select(z => z.ToUpper()).ToList();

            foreach (var item in data)
            {
                if (fileArray.Where(z=>z.Contains(item.FileName.ToUpper())).Count()>0)
                {
                    result.Add(item);
                }
            }
 
             return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
