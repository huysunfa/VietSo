using apiVietSo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace apiVietSo.Controllers
{
    public class AppSyncController : Controller
    {
        public ContentResult JsonMax(string data)
        {
            return new ContentResult
            {
                Content = data,
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
        public string ToJson(DataTable dt, bool ConvertLabel = true)
        {
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
            Dictionary<string, object> item;
            foreach (DataRow row in dt.Rows)
            {
                item = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    item.Add(col.ColumnName, (Convert.IsDBNull(row[col]) ? null : row[col]));
                }
                lst.Add(item);
            }
            return JsonConvert.SerializeObject(lst);
        }
        public string ToJson<T>(List<T> dt)
        {

            string sJSONResponse = JsonConvert.SerializeObject(dt);
            return sJSONResponse;
        }
        public ActionResult Catalog()
        {

            var data = LongSo.GetLongSos();
            var result = new List<LongSo>();
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + @"\FileUpload";
            //     var fileArray = Directory.GetFiles(path, "*.hc", SearchOption.AllDirectories).Select(z => z.ToUpper()).ToList();

            foreach (var item in data)
            {
                //if (fileArray.Where(z => z.Contains(item.FileName.ToUpper())).Count() > 0)
                {
                    result.Add(item);
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDictionary()
        {
            var data = SqlModule.GetDataTable($@"select vn,chinese from (select vn,chinese,ROW_NUMBER() over(partition by VN ORDER BY ID ) as RN from VnChinese) a1
                where rn = 1");
            var result = ToJson(data);
            return JsonMax(result);
        }

        public ActionResult checkOnline(string key, string mac)
        {

            var data = SqlModule.GetDataTable($@"select * from LicenceData where Licence ='{key}'
                and ISNULL(ExpiryDate, getdate()) >= CONVERT(date, getdate()) and isnull(IP_Active,'{mac}') ='{mac}' ");

            if (data.Rows.Count > 0)
            {
                return JsonMax("OK");
            }

            return JsonMax("NG");

        }

        public ActionResult UpdateKeyOnline(string key, string mac)
        {

            SqlModule.ExcuteCommand($@"update LicenceData set IP_Active ='{mac}',Date_Active = getdate() where  Licence ='{key}'");
            return JsonMax("OK");

        }
        public ActionResult UpdateKeyInfoOnline(string key, string mac, string hoten, string diachi, string sdt)
        {

            SqlModule.ExcuteCommand($@"update LicenceData set hoten =N'{hoten}',DIACHI=N'{diachi}',SDT=N'{sdt}' WHERE Licence =N'{key}'");
            return JsonMax("OK");

        }

        public ActionResult GetDictionaryNguCanh()
        {
            var data = SqlModule.GetDataTable($"SELECT  LABEL vn,TITLE chinese,NOTE used, DATATYPE nguCanh FROM LabelText WHERE keysoft='Sugget'");
            var result = ToJson(data);
            return JsonMax(result);
        }
        public ActionResult GetLicenceData(string key)
        {
            var data = SqlModule.GetDataTable($@" SELECT * FROM [LicenceData] where Licence='{key}'");

            var result = ToJson(data);
            return JsonMax(result);
        }

        public ActionResult GetLongSo()
        {
            using (Models.vietsoEntities db = new vietsoEntities())
            {
                var path = Server.MapPath("~/FileUpload/");
                //var files = Directory.GetFiles(path, "*.hc", SearchOption.AllDirectories).Select(z => z.ToUpper().Split('\\').LastOrDefault()).ToList();

                var ouput = new List<ListLongSo>();
                var data = db.ListLongSoes.ToList();
                foreach (var item in data)
                {
                    var url = item.FileName.ToUpper();
                    url = url.Replace('/', '\'');
                    url = url.Split('\'').LastOrDefault();
                    //if (files.Contains(url))
                    //{
                    ouput.Add(item);
                    //}
                }
                var result = ToJson(ouput);
                return JsonMax(result);
            }

        }
        public ActionResult GetListLongSo_ChoDuyet(string TenSo, String CreatedBy)
        {
            TenSo = TenSo.ToUpper();
            using (Models.vietsoEntities db = new vietsoEntities())
            {
                var data = db.ListLongSo_ChoDuyet.Where(v => v.TenSo.ToUpper() == TenSo && v.CreatedBy == CreatedBy).OrderByDescending(z => z.Created).ToList();
                var result = ToJson(data);
                return JsonMax(result);
            }

        }

        public ActionResult GetLabelTexts()
        {
            using (Models.vietsoEntities db = new vietsoEntities())
            {
                var data = db.LabelTexts.ToList();
                var result = ToJson(data);
                return JsonMax(result);
            }

        }
        public ActionResult AddItemListLongSo(ListLongSo_ChoDuyet item)
        {
            using (Models.vietsoEntities db = new vietsoEntities())
            {
                var old = db.ListLongSo_ChoDuyet.Where(v => v.CreatedBy == item.CreatedBy && item.TenSo == v.TenSo && string.IsNullOrEmpty(v.TrangThai));
                db.ListLongSo_ChoDuyet.RemoveRange(old);
                item.Created = DateTime.Now;
                db.ListLongSo_ChoDuyet.Add(item);
                db.SaveChanges();
                return JsonMax("OK");
            }

        }
        [HttpPost]
        public ActionResult SubmitError(LogError item)
        {
            using (Models.vietsoEntities db = new vietsoEntities())
            {
                item.DateCreated = DateTime.Now;
                db.LogErrors.Add(item);
                db.SaveChanges();

                try
                {
                    SendMailExtentions.SendEmail(new string[] { "huy1965@robotech.com.vn" }, "SubmitError", item.Error);
                }
                catch (Exception)
                {

                }
                return JsonMax("OK");

            }

        }

        public ActionResult GetListFont()
        {

            var path = Server.MapPath("~/FileUpload/fontCN").ToUpper();
            var domain = Server.MapPath("~/").ToUpper();
            var request = Request.Url.Scheme + "://" + Request.Url.Authority;

            var files = Directory.GetFiles(path, "*.ttf", SearchOption.AllDirectories).Select(z => request + "/" + z.ToUpper().Replace(domain, "")).ToList();

            var result = ToJson(files);
            return JsonMax(result);


        }
        public ActionResult GetVersion()
        {

            using (Models.vietsoEntities db = new vietsoEntities())
            {
                var version = db.LabelTexts.Where(v => v.Label == "version").Select(v => v.Title).FirstOrDefault();
                return JsonMax(version);
            }



        }
        [HttpPost]
        public ActionResult UploadFileData(HttpPostedFileBase file)
        {
            // extract only the fielname            
            var imageName = Path.GetFileName(file.FileName);
            var path = DateTime.Now.ToString("ddMMyyyy_HHmmss_") + imageName;
            var imgsrc = Path.Combine(Server.MapPath("~/FileUpload/"), path);
            string filepathToSave = "/FileUpload/" + path;
            file.SaveAs(imgsrc);
            var request = Request.Url.Scheme + "://" + Request.Url.Authority;
            var oupt = request + filepathToSave;
            return JsonMax(oupt);
        }
    }
}
