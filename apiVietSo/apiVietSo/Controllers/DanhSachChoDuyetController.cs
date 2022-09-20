using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apiVietSo.Controllers
{
    public class DanhSachChoDuyetController : BaseController
    {
        // GET: DanhSachChoDuyet
        public ActionResult Index()
        {
            var data = db.ListLongSo_ChoDuyet.Where(z => string.IsNullOrEmpty(z.TrangThai))
                .GroupBy(z => z.TenSo).Select(v => new { key = v.Key, val = v.Sum(a => 1) }).ToDictionary(v => v.key, v => v.val);
            return View(data);
        }
        public ActionResult SubmitItem(List<int> ID, int num = 0)
        {
            var data = db.ListLongSo_ChoDuyet.Where(v => ID.Contains(v.SoID)).OrderBy(V=>V.Created);
            foreach (var item in data)
            {
                if (num == 1)
                {
                    item.TrangThai = "ĐỒNG Ý";
                    var idx = item.FileName.IndexOf("FileUpload");
                    var FileName = "/" + item.FileName.Substring(idx, item.FileName.Length - idx);

                    var ls = db.ListLongSoes.Where(v => v.TenSo == item.TenSo).FirstOrDefault();
                    if (ls!=null)
                    {
                        ls.FileName = FileName;
                        ls.Updated = DateTime.Now;
                        ls.UpdatedBy = item.CreatedBy;
                    }
                    else
                    {
                        var nd = db.LicenceDatas.Where(v => v.IP_Active == item.CreatedBy).FirstOrDefault();
                        ls = new Models.ListLongSo();
                        ls.TenSo = item.TenSo;
                        ls.FileName = item.FileName;
                        ls.LoaiSo = "Khác";
                        ls.ChuGiai = "Lòng sớ của thầy "+ nd.HoTen;
                    }
                }
                else
                {
                    item.TrangThai = "TỪ CHỐI";
                }

            }
            db.SaveChanges();
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult danhsachchitiet(string key)
        {
            ViewBag.key = key;

            var data = db.ListLongSo_ChoDuyet
                .Where(z => string.IsNullOrEmpty(z.TrangThai))
                .Where(v => v.TenSo == key).OrderByDescending(z => z.Created).ToList();
            foreach (var item in data)
            {
                var nd = db.LicenceDatas.Where(v => v.IP_Active == item.CreatedBy).FirstOrDefault();
                if (nd != null)
                {
                    item.CreatedBy = nd.HoTen + " [" + nd.SDT + "]";
                }
                var idx = item.FileName.IndexOf("FileUpload");
                item.FileName = "/" + item.FileName.Substring(idx, item.FileName.Length - idx);
            }
            return PartialView(data);
        }
    }
}