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
    public class ListLongSoesController : BaseController
    {

        public ActionResult Index()
        {
            return View(db.ListLongSoes.ToList());
        }

      

        public ActionResult Edit(int? id)
        {

            ListLongSo listLongSo = db.ListLongSoes.Where(z => z.SoID == id).FirstOrDefault();

            listLongSo = listLongSo ?? new ListLongSo();
            ViewBag.LoaiSoes = db.LoaiSoes.ToList();
            return View(listLongSo);
        }

        // POST: ListLongSoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
         public ActionResult Edit(ListLongSo listLongSo,HttpPostedFileBase FileName= null)
        {
            var urlfile = SubmitFile(FileName).FirstOrDefault();

            var item = db.ListLongSoes.Where(v => v.SoID == listLongSo.SoID).FirstOrDefault();
            item = item ?? new ListLongSo();
            item.LoaiSo = listLongSo.LoaiSo;
            item.TenSo = listLongSo.TenSo;
            item.ChuGiai = listLongSo.ChuGiai;
            if (!string.IsNullOrEmpty(urlfile))
            {
                item.FileName = urlfile;
            }

            if (item.SoID==0)
            {
                db.ListLongSoes.Add(item);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
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
