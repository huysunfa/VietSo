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
    public class ListLongSoesController :BaseController 
    {
 
         public ActionResult Index()
        {
            return View(db.ListLongSoes.ToList());
        }

        // GET: ListLongSoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListLongSo listLongSo = db.ListLongSoes.Find(id);
            if (listLongSo == null)
            {
                return HttpNotFound();
            }
            return View(listLongSo);
        }

        // GET: ListLongSoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListLongSoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoID,LoaiSo,TenSo,ChuGiai,FileName,CreatedBy,Created,UpdatedBy,Updated")] ListLongSo listLongSo)
        {
            if (ModelState.IsValid)
            {
                db.ListLongSoes.Add(listLongSo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listLongSo);
        }

        // GET: ListLongSoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListLongSo listLongSo = db.ListLongSoes.Find(id);
            if (listLongSo == null)
            {
                return HttpNotFound();
            }
            return View(listLongSo);
        }

        // POST: ListLongSoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoID,LoaiSo,TenSo,ChuGiai,FileName,CreatedBy,Created,UpdatedBy,Updated")] ListLongSo listLongSo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listLongSo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listLongSo);
        }

        // GET: ListLongSoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListLongSo listLongSo = db.ListLongSoes.Find(id);
            if (listLongSo == null)
            {
                return HttpNotFound();
            }
            return View(listLongSo);
        }

        // POST: ListLongSoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListLongSo listLongSo = db.ListLongSoes.Find(id);
            db.ListLongSoes.Remove(listLongSo);
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
