using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apiVietSo.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return Redirect("/LicenceDatas");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Catalog()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + @"\FileUpload\Catalog.json";

            var txt = System.IO.File.ReadAllText(path);
            txt = txt.Replace("\n", "");
            txt = txt.Replace("\r", "");
            return Json(txt, JsonRequestBehavior.AllowGet);
        }
    }
}