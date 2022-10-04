using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using apiVietSo.Models;

namespace apiVietSo.Controllers
{
    public class VnChineseController : BaseController
    {
        private vietsoEntities db = new vietsoEntities();

        // GET: VnChinese
        public ActionResult Index(string vn = "")
        {
            ViewBag.vn = vn;
            vn = vn.ToLower();
            vn = vn.Replace(" ", "");
            vn = vn.Trim();

            if (string.IsNullOrEmpty(vn))
            {
                return View(new List<VnChinese>());
            }
            return View(db.VnChinese.Where(v => v.vn == vn).ToList());
        }

        // GET: VnChinese/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VnChinese vnChinese = db.VnChinese.Find(id);
            if (vnChinese == null)
            {
                return HttpNotFound();
            }
            return View(vnChinese);
        }

        // GET: VnChinese/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VnChinese/Create
        [HttpPost]
        public ActionResult Create(VnChinese vnChinese)
        {

            db.VnChinese.Add(vnChinese);
            db.SaveChanges();
            return RedirectToAction("Index", new { vn = vnChinese.vn });

        }

        // GET: VnChinese/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VnChinese vnChinese = db.VnChinese.Find(id);
            if (vnChinese == null)
            {
                return HttpNotFound();
            }
            return View(vnChinese);
        }

        // POST: VnChinese/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(VnChinese vnChinese)
        {

            VnChinese item = db.VnChinese.Find(vnChinese.ID);

            item.chinese = vnChinese.chinese;
            item.vn = vnChinese.vn;
            db.SaveChanges();

            return RedirectToAction("Index", new { vn = vnChinese.vn });
        }

        // GET: VnChinese/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VnChinese vnChinese = db.VnChinese.Find(id);
            if (vnChinese == null)
            {
                return HttpNotFound();
            }
            return View(vnChinese);
        }

        // POST: VnChinese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VnChinese vnChinese = db.VnChinese.Find(id);
            var vn = vnChinese.vn;
            db.VnChinese.Remove(vnChinese);
            db.SaveChanges();
            return RedirectToAction("Index", new { vn = vn });
        }

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
