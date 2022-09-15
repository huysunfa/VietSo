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
    public class LoaiSoesController : BaseController
    {

        // GET: LoaiSoes
        public ActionResult Index()
        {
            return View(db.LoaiSoes.ToList());
        }

        // GET: LoaiSoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSo loaiSo = db.LoaiSoes.Find(id);
            if (loaiSo == null)
            {
                return HttpNotFound();
            }
            return View(loaiSo);
        }

        // GET: LoaiSoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiSoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoaiSoID,TenLoaiSo")] LoaiSo loaiSo)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSoes.Add(loaiSo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiSo);
        }

        // GET: LoaiSoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSo loaiSo = db.LoaiSoes.Find(id);
            if (loaiSo == null)
            {
                return HttpNotFound();
            }
            return View(loaiSo);
        }

        // POST: LoaiSoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoaiSoID,TenLoaiSo")] LoaiSo loaiSo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSo);
        }

        // GET: LoaiSoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSo loaiSo = db.LoaiSoes.Find(id);
            if (loaiSo == null)
            {
                return HttpNotFound();
            }
            return View(loaiSo);
        }

        // POST: LoaiSoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiSo loaiSo = db.LoaiSoes.Find(id);
            db.LoaiSoes.Remove(loaiSo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

     
    }
}
