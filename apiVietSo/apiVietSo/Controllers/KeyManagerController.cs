using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apiVietSo.Controllers
{
    public class KeyManagerController : Controller
    {
         public ActionResult Index()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + @"\FileUpload\Key.licence";

            if (!System.IO.File.Exists(path))
            {
                System.IO.File.WriteAllText(path,"");
            }
            var txt = System.IO.File.ReadAllLines(path);
         
            return View(txt);
        }  
        [HttpPost]
        public ActionResult AddKey()
        {
            var key = Guid.NewGuid().ToString();

            string path = System.Web.HttpContext.Current.Server.MapPath("~") + @"\FileUpload\Key.licence";
            var txt = System.IO.File.ReadAllLines(path).ToList();
            txt.Add(key + "|"+DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            System.IO.File.WriteAllLines(path, txt);

            return Json(key, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Check(string key)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + @"\FileUpload\Key.licence";

            if (!System.IO.File.Exists(path))
            {
                System.IO.File.WriteAllText(path, "");
            }
            var txt = System.IO.File.ReadAllLines(path).Select(z=>   z.Split('|').FirstOrDefault().ToUpper());
            if (txt.Contains(key.ToUpper()))
            {
                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            return Json("NG", JsonRequestBehavior.AllowGet);
        }
    }
}