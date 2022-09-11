using apiVietSo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace apiVietSo
{

    public class LoginAuth : AuthorizeAttribute
    {
        public static string Decrypt(string cipher)
        {
            string key = "Ktd@";
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }

        public static string NameSession = "NguoiDung";
        public static string LastUrl = "LastUrl";
        private static bool SkipAuthorization(AuthorizationContext filterContext)
        {
            Contract.Assert(filterContext != null);
            return filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any()
                   || filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any();
        }
        public static  StaffInfo GetCookiesLogin()
        {
            var nd = HttpContext.Current.Request.Cookies[LoginAuth.NameSession];
            string StaffID = "";

            if (!string.IsNullOrEmpty(nd["_Key"]))
            {
                StaffID = nd["_Key"];
                StaffID = Decrypt(StaffID);
            }

            using (Models.vietsoEntities db = new Models.vietsoEntities())
            {
                return db.StaffInfoes.Where(z => z.StaffID == StaffID).FirstOrDefault();
            }

        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (HttpContext.Current.Session[LoginAuth.NameSession] == null)
            {

                if (HttpContext.Current.Request.Cookies[LoginAuth.NameSession] != null)
                {
                    var StaffInfomation = GetCookiesLogin();
                    if (StaffInfomation != null)
                    {
                        HttpContext.Current.Session[LoginAuth.NameSession] = StaffInfomation;
                        return;
                    }
                }

                if (SkipAuthorization(filterContext)) return;
                var lastUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;
                HttpContext.Current.Session["lastUrl"] = lastUrl;
                filterContext.Result = new RedirectResult("/login/index");

            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result =
           new RedirectToRouteResult(
               new RouteValueDictionary{
                   { "area", "Default" },
                   { "controller", "Login" },
                   { "action", "Index" }

            });

        }
        public static Models.StaffInfo StaffInfo(HttpSessionStateBase Session)
        {
            if (Session == null)
            {
                return new StaffInfo();
            }
            var nd = (StaffInfo)Session[LoginAuth.NameSession];

            if (nd == null)
                nd = GetCookiesLogin();
            return nd;
        }
        public static StaffInfo StaffInfo(HttpSessionState Session)
        {
            var nd = (StaffInfo)Session[LoginAuth.NameSession];
            if (nd == null)
                nd = GetCookiesLogin();

            return nd;
        }
    }
}

