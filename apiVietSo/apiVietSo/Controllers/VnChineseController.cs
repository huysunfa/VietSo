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
        public ActionResult Index(string vn="")
        {
            ViewBag.vn = vn;
            vn = vn.ToLower();
            vn = vn.Replace(" ", "");
            vn = vn.Trim();

            if (string.IsNullOrEmpty(vn))
            {
                return View( new List<VnChinese>());
            }
            return View(db.VnChinese.Where(v=>v.vn==vn).ToList());
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,vn,chinese,reading,used,nguCanh,UpdateDT,syncTime")] VnChinese vnChinese)
        {
            if (ModelState.IsValid)
            {
                db.VnChinese.Add(vnChinese);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vnChinese);
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,vn,chinese,reading,used,nguCanh,UpdateDT,syncTime")] VnChinese vnChinese)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vnChinese).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vnChinese);
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
            db.VnChinese.Remove(vnChinese);
            db.SaveChanges();
            return RedirectToAction("Index");
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
