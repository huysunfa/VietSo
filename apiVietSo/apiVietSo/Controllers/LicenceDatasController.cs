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
    public class LicenceDatasController : BaseController
    {
        private vietsoEntities  db = new vietsoEntities();

        // GET: LicenceDatas
        public ActionResult Index()
        {
            return View(db.LicenceDatas.OrderByDescending(z => z.CreatedDate).ToList());
        }

        // GET: LicenceDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenceData licenceData = db.LicenceDatas.Find(id);
            if (licenceData == null)
            {
                return HttpNotFound();
            }
            return View(licenceData);
        }

        // GET: LicenceDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateAuto()
        {
            var licenceData = new LicenceData();
            tt: licenceData.Licence = Guid.NewGuid().ToString().Split('-').FirstOrDefault();
            if (db.LicenceDatas.Where(v => v.Licence == licenceData.Licence).Count() > 0)
            {
                goto tt;
            }
            licenceData.CreatedDate = DateTime.Now;
            licenceData.ExpiryDate = DateTime.Now.Date.AddYears(1);
            db.LicenceDatas.Add(licenceData);
            db.SaveChanges();
            ViewBag.Licence = licenceData.Licence;
            return View("index", db.LicenceDatas.OrderByDescending(z => z.CreatedDate).ToList());
        }

        // POST: LicenceDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LicenceData licenceData)
        {
            if (db.LicenceDatas.Where(v => v.Licence == licenceData.Licence).Count() > 0)
            {
                return Content("Key " + licenceData.Licence + " đã bị trùng !!!");
            }
            if (ModelState.IsValid)
            {
                licenceData.CreatedDate = DateTime.Now;
                db.LicenceDatas.Add(licenceData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(licenceData);
        }

        // GET: LicenceDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenceData licenceData = db.LicenceDatas.Where(z => z.ID == id).FirstOrDefault();
            if (licenceData == null)
            {
                return HttpNotFound();
            }
            return View(licenceData);
        }

        // POST: LicenceDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LicenceData licenceData)
        {
            LicenceData item = db.LicenceDatas.Where(z => z.ID == licenceData.ID).FirstOrDefault();
            item.ExpiryDate = licenceData.ExpiryDate;
            item.IP_Active = licenceData.IP_Active;
            item.HoTen = licenceData.HoTen;
            item.SDT = licenceData.SDT;
            item.DiaChi = licenceData.DiaChi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: LicenceDatas/Delete/5
        public ActionResult Delete(int? id)
        {

            LicenceData licenceData = db.LicenceDatas.Where(z => z.ID == id).FirstOrDefault();
            if (licenceData == null)
            {
                return HttpNotFound();
            }
            return View(licenceData);
        }

        // POST: LicenceDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LicenceData licenceData = db.LicenceDatas.Where(z => z.ID == id).FirstOrDefault();
            db.LicenceDatas.Remove(licenceData);
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
