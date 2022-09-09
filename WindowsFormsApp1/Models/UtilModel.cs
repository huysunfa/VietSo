using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WindowsFormsApp1.Models
{
    public class UtilModel
    {
        // Token: 0x06000271 RID: 625 RVA: 0x000092AC File Offset: 0x000074AC
        public static string filterCheck(string filter)
        {
            filter = filter.Trim();
            while (filter.Contains("  "))
            {
                filter = filter.Replace("  ", " ");
            }
            filter = filter.Replace(" ", " AND ");
            return filter;
        }

        // Token: 0x06000272 RID: 626 RVA: 0x000092FC File Offset: 0x000074FC
        public static string RemoveHTMLClass(string html)
        {
            return new Regex(" class=\"[a-zA-Z0-9 _-]*\"?").Replace(html, "");
        }

        // Token: 0x06000273 RID: 627 RVA: 0x00009320 File Offset: 0x00007520
        public static string createBtn(string url, string title)
        {
            return string.Concat(new string[]
            {
                "<div class=\"fbsBtn\" onclick=\"fbs_click('",
                url,
                "', '",
                title,
                "');\"><svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 16 16' style='height: 16px; width: 16px;'><path fill='#ffffff' fill-rule='evenodd' d='M4.55,7 C4.7984,7 5,7.23403636 5,7.52247273 L5,13.4775273 C5,13.7659636 4.7984,14 4.55,14 L2.45,14 C2.2016,14 2,13.7659636 2,13.4775273 L2,7.52247273 C2,7.23403636 2.2016,7 2.45,7 L4.55,7 Z M6.54470232,13.2 C6.24016877,13.1641086 6.01734614,12.8982791 6,12.5737979 C6.01734614,12.5737979 6.01344187,9.66805666 6,8.14398693 C6.01344187,7.61903931 6.10849456,6.68623352 6.39801308,6.27384278 C7.10556287,5.26600749 7.60281698,4.6079584 7.89206808,4.22570082 C8.18126341,3.8435016 8.52813047,3.4708734 8.53777961,3.18572676 C8.55077527,2.80206854 8.53655255,2.79471518 8.53777961,2.35555666 C8.53900667,1.91639814 8.74565444,1.5 9.27139313,1.5 C9.52544997,1.5 9.7301456,1.55690094 9.91922413,1.80084547 C10.2223633,2.15596568 10.4343097,2.71884727 10.4343097,3.60971169 C10.4343097,4.50057612 9.50989975,6.1729303 9.50815961,6.18 C9.50815961,6.18 13.5457098,6.17908951 13.5464084,6.18 C14.1635544,6.17587601 14.5,6.72543196 14.5,7.29718426 C14.5,7.83263667 14.1341135,8.27897346 13.6539433,8.3540827 C13.9452023,8.49286263 14.1544715,8.82364675 14.1544715,9.20555417 C14.1544715,9.68159617 13.8293011,10.0782687 13.3983805,10.1458495 C13.6304619,10.2907572 13.7736931,10.5516845 13.7736931,10.847511 C13.7736931,11.2459343 13.5138356,11.5808619 13.1594388,11.6612236 C13.3701582,11.7991865 13.5063617,12.0543945 13.5063617,12.3429843 C13.5063617,12.7952155 13.1715421,13.1656844 12.7434661,13.2 L6.54470232,13.2 Z'></path></svg><span>share</span></div>"
            });
        }


        // Token: 0x06000276 RID: 630 RVA: 0x00009458 File Offset: 0x00007658
        public static int RandNumber(int Low, int High)
        {
            return new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), NumberStyles.HexNumber)).Next(Low, High);
        }

        // Token: 0x06000277 RID: 631 RVA: 0x00009498 File Offset: 0x00007698
        public static object getInstance(string className)
        {
            return Assembly.GetExecutingAssembly().CreateInstance(className);
        }

        // Token: 0x06000278 RID: 632 RVA: 0x000094B0 File Offset: 0x000076B0


        // Token: 0x0600027A RID: 634 RVA: 0x00009518 File Offset: 0x00007718
        public static bool IsNumeric(string strToCheck)
        {
            return Regex.IsMatch(strToCheck, "^\\d+(\\.\\d+)?$");
        }

        // Token: 0x0600027B RID: 635 RVA: 0x00009534 File Offset: 0x00007734
        public static string formatHTML(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.Replace("&", "&amp;").Replace("\"", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;");
            }
            return "";
        }

        // Token: 0x0600027C RID: 636 RVA: 0x00009594 File Offset: 0x00007794
        public static DataView getDataView(Dictionary<object, IKT> dic)
        {
            DataTable dataTable = new DataTable();
            foreach (KeyValuePair<object, IKT> keyValuePair in dic)
            {
                IKT value = keyValuePair.Value;
                DataRow dataRow = dataTable.NewRow();
                foreach (PropertyInfo propertyInfo in value.GetType().GetProperties())
                {
                    if (!dataTable.Columns.Contains(propertyInfo.Name))
                    {
                        dataTable.Columns.Add(propertyInfo.Name);
                    }
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(value, null);
                }
                dataTable.Rows.Add(dataRow);
            }
            return new DataView(dataTable);
        }

        // Token: 0x0600027D RID: 637 RVA: 0x00009670 File Offset: 0x00007870
        public static DataTable getDataTable(Dictionary<object, IKT> dic)
        {
            DataTable dataTable = new DataTable();
            foreach (KeyValuePair<object, IKT> keyValuePair in dic)
            {
                IKT value = keyValuePair.Value;
                DataRow dataRow = dataTable.NewRow();
                foreach (PropertyInfo propertyInfo in value.GetType().GetProperties())
                {
                    if (!dataTable.Columns.Contains(propertyInfo.Name))
                    {
                        dataTable.Columns.Add(propertyInfo.Name);
                    }
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(value, null);
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        // Token: 0x0600027E RID: 638 RVA: 0x00009748 File Offset: 0x00007948
        public static void moveFile(string pathNFileOld, string pathNFileNew)
        {
            if (File.Exists(pathNFileOld))
            {
                if (File.Exists(pathNFileNew))
                {
                    throw new Exception("File: " + pathNFileNew + " Exists");
                }
                File.Move(pathNFileOld, pathNFileNew);
            }
        }

        // Token: 0x0600027F RID: 639 RVA: 0x00009788 File Offset: 0x00007988
        public static void deleteFile(string pathNFile)
        {
            if (File.Exists(pathNFile))
            {
                File.Delete(pathNFile);
            }
            if (File.Exists(pathNFile + ".txt"))
            {
                File.Delete(pathNFile + ".txt");
            }
        }

        // Token: 0x06000280 RID: 640 RVA: 0x000097C8 File Offset: 0x000079C8
        public static void SetTextboxEnterTarget(WebControl control, string targetButtonClientId)
        {
            if (control != null)
            {
                string value = string.Format("return EnterKeyPress(event,{0});", targetButtonClientId);
                control.Attributes.Add("onkeypress", value);
            }
        }

        // Token: 0x06000281 RID: 641 RVA: 0x000097F8 File Offset: 0x000079F8
        public static void SetNextTextbox(WebControl control, string targetClientId)
        {
            if (control != null)
            {
                string value = string.Format("return TabNext(event,{0});", targetClientId);
                control.Attributes.Add("onkeypress", value);
            }
        }

        // Token: 0x06000282 RID: 642 RVA: 0x00009828 File Offset: 0x00007A28
        public static void bindText2Holder(PlaceHolder phrContent, StringBuilder sbr)
        {
            Literal literal = new Literal();
            literal.Text = sbr.ToString();
            phrContent.Controls.Add(literal);
        }

        // Token: 0x06000283 RID: 643 RVA: 0x00009854 File Offset: 0x00007A54
        public static void bindText2Holder(PlaceHolder phrContent, string s)
        {
            Literal literal = new Literal();
            literal.Text = s;
            phrContent.Controls.Add(literal);
        }

        // Token: 0x06000284 RID: 644 RVA: 0x00009828 File Offset: 0x00007A28
        public static void bindText2Holder(Panel pnl, StringBuilder sbr)
        {
            Literal literal = new Literal();
            literal.Text = sbr.ToString();
            pnl.Controls.Add(literal);
        }

        // Token: 0x06000285 RID: 645 RVA: 0x00009854 File Offset: 0x00007A54
        public static void bindText2Holder(Panel pnl, string s)
        {
            Literal literal = new Literal();
            literal.Text = s;
            pnl.Controls.Add(literal);
        }

        // Token: 0x06000286 RID: 646 RVA: 0x00009854 File Offset: 0x00007A54
        public static void bindText2Holder(HtmlGenericControl dynDiv, string s)
        {
            Literal literal = new Literal();
            literal.Text = s;
            dynDiv.Controls.Add(literal);
        }

        // Token: 0x06000287 RID: 647 RVA: 0x0000987C File Offset: 0x00007A7C
        public static bool IsValidImageFile(FileUpload fileUp)
        {
            try
            {
                if (fileUp.PostedFile != null && fileUp.PostedFile.ContentLength > 0)
                {
                    using (new Bitmap(fileUp.PostedFile.InputStream))
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return false;
        }



        // Token: 0x0600028D RID: 653 RVA: 0x00009D7C File Offset: 0x00007F7C
        public static void downloadFileSecurity(string pathNFile, ref string error)
        {
            pathNFile += ".txt";
            if (File.Exists(pathNFile))
            {
                FileStream fileStream = new FileStream(pathNFile, FileMode.Open);
                long length = fileStream.Length;
                byte[] buffer = new byte[(int)length];
                fileStream.Read(buffer, 0, (int)length);
                fileStream.Close();
                string text = pathNFile.Substring(pathNFile.LastIndexOf('/') + 1);
                text = text.Substring(0, text.LastIndexOf('.'));
                HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "Attachment; Filename=" + text);
                HttpContext.Current.Response.AddHeader("Content-Length", length.ToString());
                HttpContext.Current.Response.BinaryWrite(buffer);
                return;
            }
            error = "This file does not exist.";
        }

        // Token: 0x0600028E RID: 654 RVA: 0x00009E54 File Offset: 0x00008054
        public static void downloadFile(string pathNFile, ref string error)
        {
            if (File.Exists(pathNFile))
            {
                FileStream fileStream = new FileStream(pathNFile, FileMode.Open);
                long length = fileStream.Length;
                byte[] buffer = new byte[(int)length];
                fileStream.Read(buffer, 0, (int)length);
                fileStream.Close();
                string str = pathNFile.Substring(pathNFile.LastIndexOf('/') + 1);
                HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "Attachment; Filename=" + str);
                HttpContext.Current.Response.AddHeader("Content-Length", length.ToString());
                HttpContext.Current.Response.BinaryWrite(buffer);
                return;
            }
            error = "This file does not exist.";
        }

        // Token: 0x0600028F RID: 655 RVA: 0x00009F10 File Offset: 0x00008110
        public static string getServerPath(string path)
        {
            return HttpContext.Current.Server.MapPath("~/" + path) + "/";
        }

        // Token: 0x06000291 RID: 657 RVA: 0x00009F44 File Offset: 0x00008144
        public static string getBrowser()
        {
            return HttpContext.Current.Request.Browser.Browser;
        }

        // Token: 0x06000292 RID: 658 RVA: 0x00009F68 File Offset: 0x00008168
        public static string getFileName(string pathNFile)
        {
            if (pathNFile.LastIndexOf('/') != -1)
            {
                string[] array = pathNFile.Split(new char[]
                {
                    '/'
                });
                return array[array.Length - 1].Trim();
            }
            return "";
        }

        // Token: 0x06000293 RID: 659 RVA: 0x00009FA4 File Offset: 0x000081A4
        public static void ResizeImage(ref System.Drawing.Image fullSizeImage, int maxWidth, int maxHeight)
        {
            if (fullSizeImage == null)
            {
                return;
            }
            fullSizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            fullSizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (fullSizeImage.Width <= maxWidth)
            {
                maxWidth = fullSizeImage.Width;
            }
            int num = fullSizeImage.Height * maxWidth / fullSizeImage.Width;
            if (num > maxHeight)
            {
                maxWidth = fullSizeImage.Width * maxHeight / fullSizeImage.Height;
                num = maxHeight;
            }
            System.Drawing.Image image = new Bitmap(maxWidth, num, PixelFormat.Format24bppRgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.DrawImage(fullSizeImage, 0, 0, maxWidth, num);
            fullSizeImage = null;
            fullSizeImage = image;
        }


        // Token: 0x06000295 RID: 661 RVA: 0x0000A1A4 File Offset: 0x000083A4
        public static void BindJavaScript(string textScript, Page page)
        {
            string script = "<script language='javascript' type='text/javascript'>" + textScript + "</script>";
            page.ClientScript.RegisterClientScriptBlock(typeof(Page), "keyStr", script);
        }

        // Token: 0x06000296 RID: 662 RVA: 0x0000A1E0 File Offset: 0x000083E0
        public static void BindJavaScript(string textScript, string key, Page page)
        {
            string script = "<script language='javascript' type='text/javascript'>" + textScript + "</script>";
            page.ClientScript.RegisterClientScriptBlock(typeof(Page), key, script);
        }

        // Token: 0x06000297 RID: 663 RVA: 0x0000A218 File Offset: 0x00008418
        public static void RemoveSign4Vietnamese(ref string str)
        {
            string[] array = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    str = str.Replace(array[i][j], array[0][i - 1]);
                }
            }
            str = str.Replace("  ", " ");
            str = str.Replace(" ", "_");
        }

        // Token: 0x06000298 RID: 664 RVA: 0x0000A324 File Offset: 0x00008524
        public static string formatCurrency(double num)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("vi-VN");
            return num.ToString("#,###", cultureInfo.NumberFormat);
        }

        // Token: 0x06000299 RID: 665 RVA: 0x0000A350 File Offset: 0x00008550
        public static string formatDouble(object str)
        {
            return string.Format("{0:0,0.##}", str);
        }

        // Token: 0x0600029A RID: 666 RVA: 0x0000A36C File Offset: 0x0000856C
        public static string formatInt(object str)
        {
            return string.Format("{0:0,0}", str);
        }

        // Token: 0x0600029B RID: 667 RVA: 0x0000A388 File Offset: 0x00008588
        public static bool Convert2Double(object value, out double reValue)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";
            numberFormatInfo.NumberGroupSizes = new int[]
            {
                3
            };
            return double.TryParse(string.Concat(value), out reValue);
        }

        // Token: 0x0600029C RID: 668 RVA: 0x0000A3D0 File Offset: 0x000085D0
        public static double Convert2Double(object value)
        {
            if (value == null)
            {
                return 0.0;
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return 0.0;
            }
            if (string.IsNullOrWhiteSpace(value.ToString()))
            {
                return 0.0;
            }
            return Convert.ToDouble(value, new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = ",",
                NumberGroupSizes = new int[]
                {
                    3
                }
            });
        }

        // Token: 0x0600029E RID: 670 RVA: 0x0000A450 File Offset: 0x00008650
        public static T ConvertJSON2Obj<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(json);
        }

        // Token: 0x0600029F RID: 671 RVA: 0x0000A478 File Offset: 0x00008678
        public static T readObjFromJsonFile<T>(string pathNfile)
        {
            if (!File.Exists(pathNfile))
            {
                throw new Exception("File is not exist " + pathNfile);
            }
            return UtilModel.ConvertJSON2Obj<T>(File.ReadAllText(pathNfile));
        }

        // Token: 0x060002A0 RID: 672 RVA: 0x0000A4AC File Offset: 0x000086AC
        public static void saveJsonObjToFile(string pathNfile, object o)
        {
            File.WriteAllText(pathNfile, JsonConvert.SerializeObject(o));
        }

        // Token: 0x060002A1 RID: 673 RVA: 0x0000A4C8 File Offset: 0x000086C8
        public static string RemoveDuplucateDot(string value)
        {
            string[] array = value.Split(new char[]
            {
                '.'
            });
            if (2 < array.Length)
            {
                value = "";
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == array.Length - 1)
                    {
                        value = value + "." + array[i];
                        break;
                    }
                    value += array[i];
                }
            }
            return value;
        }

        // Token: 0x060002A2 RID: 674 RVA: 0x0000A52C File Offset: 0x0000872C
        public static string StripUnicodeCharactersFromString(string inputValue)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string input = inputValue.Normalize(NormalizationForm.FormD);
            return regex.Replace(input, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
        }

        // Token: 0x060002A3 RID: 675 RVA: 0x0000A570 File Offset: 0x00008770
        public static string AddImgUrl(string url)
        {
            return "{\"ImgUrl\":\"" + url + "\"}";
        }

        // Token: 0x060002A4 RID: 676 RVA: 0x0000A590 File Offset: 0x00008790
        public static string AddRedirect(string url)
        {
            return "{\"Redirect\":\"" + url + "\"}";
        }

        // Token: 0x060002A5 RID: 677 RVA: 0x0000A5B0 File Offset: 0x000087B0
        public static string AddError(string errorMessage)
        {
            return "{\"ErrorData\":\"" + errorMessage + "\"}";
        }

        // Token: 0x060002A6 RID: 678 RVA: 0x0000A5D0 File Offset: 0x000087D0
        public static string InformNoRight()
        {
            return "Bạn không có quyền. <a href='/Admin'>Quay lại</a>";
        }

        // Token: 0x060002A7 RID: 679 RVA: 0x0000A5E4 File Offset: 0x000087E4
        public static string AddInformUser(string errorMessage)
        {
            return "{\"InformUser\":\"" + errorMessage + "\"}";
        }

        // Token: 0x060002A8 RID: 680 RVA: 0x0000A604 File Offset: 0x00008804
        public static string AddPaging(object obj, int total, string jsoncallback)
        {
            string text = JsonConvert.SerializeObject(obj);
            return string.Concat(new object[]
            {
                jsoncallback,
                "({\"Total\": ",
                total,
                ", \"TableData\":",
                text,
                "})"
            });
        }

        // Token: 0x060002A9 RID: 681 RVA: 0x0000A654 File Offset: 0x00008854
        public static string AddPaging(object obj, int total)
        {
            string text = JsonConvert.SerializeObject(obj);
            return string.Concat(new object[]
            {
                "[{\"Total\": ",
                total,
                ", \"TableData\":",
                text,
                "}]"
            });
        }

        // Token: 0x060002AA RID: 682 RVA: 0x0000A6A0 File Offset: 0x000088A0
        public static string AddPaging(object obj, int total, string TableTitle, string TableTitleID)
        {
            string text = JsonConvert.SerializeObject(obj);
            return string.Concat(new object[]
            {
                "[{\"Total\": ",
                total,
                ", \"TableTitle\": \"",
                TableTitle,
                "\", \"TableTitleID\": \"",
                TableTitleID,
                "\", \"TableData\":",
                text,
                "}]"
            });
        }



        public static DateTime ConvertStr2Date(string cnToDateStr, bool isAddTime = true)
        {
            DateTime result = DateTime.Now;
            if (!string.IsNullOrEmpty(cnToDateStr))
            {
                if (cnToDateStr.Length == 10)
                {
                    result = Convert.ToDateTime(cnToDateStr, new CultureInfo("fr-FR"));
                    if (isAddTime)
                    {
                        result = result.Date.AddHours((double)DateTime.Now.Hour).AddMinutes((double)DateTime.Now.Minute).AddSeconds((double)DateTime.Now.Second);
                    }
                }
                else if (!DateTime.TryParse(cnToDateStr, out result))
                {
                    result = Convert.ToDateTime(cnToDateStr, new CultureInfo("fr-FR"));
                }
            }
            return result;
        }

        // Token: 0x060002AE RID: 686 RVA: 0x0000B01C File Offset: 0x0000921C
        public static string ConvertDate2String(DateTime d)
        {
            return d.ToString("dd/MM/yyyy");
        }

        // Token: 0x060002AF RID: 687 RVA: 0x0000B038 File Offset: 0x00009238
        public static string ConvertDate2Str(DateTime d)
        {
            return d.ToString("dd/MM/yyyy hh:mm tt", DateTimeFormatInfo.InvariantInfo);
        }

        // Token: 0x060002B0 RID: 688 RVA: 0x0000B058 File Offset: 0x00009258
        public static string RemoveComma(object str)
        {
            if (str != null)
            {
                return str.ToString().Replace(",", "");
            }
            return "0";
        }

        // Token: 0x060002B1 RID: 689 RVA: 0x0000B088 File Offset: 0x00009288
        public static object GetEnumDescriptions(Type enumType)
        {
            List<KeyValuePair<Enum, string>> list = new List<KeyValuePair<Enum, string>>();
            foreach (object obj in Enum.GetValues(enumType))
            {
                Enum @enum = (Enum)obj;
                string text = @enum.ToString();
                object obj2 = @enum.GetType().GetField(text).GetCustomAttributes(typeof(DescriptionAttribute), false).First<object>();
                if (obj2 != null)
                {
                    text = (obj2 as DescriptionAttribute).Description;
                }
                list.Add(new KeyValuePair<Enum, string>(@enum, text));
            }
            return list;
        }
    }
}
