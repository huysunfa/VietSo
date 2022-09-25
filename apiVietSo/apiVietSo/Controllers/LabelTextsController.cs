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
    public class LabelTextsController : Controller
    {
        private vietsoEntities db = new vietsoEntities();

        // GET: LabelTexts
        public ActionResult Index()
        {
            return View(db.LabelTexts.ToList());
        }

        // GET: LabelTexts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabelText labelText = db.LabelTexts.Find(id);
            if (labelText == null)
            {
                return HttpNotFound();
            }
            return View(labelText);
        }

        // GET: LabelTexts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabelTexts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Label,Title,DataType,Note,KeySoft")] LabelText labelText)
        {
            if (ModelState.IsValid)
            {
                db.LabelTexts.Add(labelText);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labelText);
        }

        // GET: LabelTexts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabelText labelText = db.LabelTexts.Find(id);
            if (labelText == null)
            {
                return HttpNotFound();
            }
            return View(labelText);
        }

        // POST: LabelTexts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Label,Title,DataType,Note,KeySoft")] LabelText labelText)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labelText).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labelText);
        }

        // GET: LabelTexts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabelText labelText = db.LabelTexts.Find(id);
            if (labelText == null)
            {
                return HttpNotFound();
            }
            return View(labelText);
        }

        // POST: LabelTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabelText labelText = db.LabelTexts.Find(id);
            db.LabelTexts.Remove(labelText);
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
