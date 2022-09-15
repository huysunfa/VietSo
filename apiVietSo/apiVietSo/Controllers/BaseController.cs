using apiVietSo.Models;
using System;
using System.Collections.Generic;
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
    }
}