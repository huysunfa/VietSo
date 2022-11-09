using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppVietSo.Models
{
    public class LongSoData
    {
        public string Language { get; set; }
        public object SongNguAlign { get; set; }
        public object VNAlign { get; set; }
        public object TinChu { get; set; }
        public int PageHeight { get; set; }

        public int PageWidth { get; set; }
        public float PagePaddingTop { get; set; }
        public float PagePaddingBottom { get; set; }
        public float PagePaddingLeft { get; set; }
        public float PagePaddingRight { get; set; }
        public Dictionary<int, Dictionary<int, CellData>> LgSo;
        public object fnameCN { get; set; }
        public float fsizeCN { get; set; }
        public string fstyleCN { get; set; }
        public object fnameVN { get; set; }
        public float fsizeVN { get; set; }
        public string fstyleVN { get; set; }
        public LongSo LSo { get; set; }
        public string PrinterName { get; set; }
        public PaperSize paperSize { get; set; }
        public float ScaleFactor { get; set; }
        public bool KhoaCung { get; set; }
        public int PageBreakRow { get; set; }
        public static LongSoData get(string filename, LongSo LSo)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return null;
            }
            var json = System.IO.File.ReadAllText(@"Data\" + filename);
            json = Security.Decrypt(json);
            json = json.Replace("$", "@");
            var result = JsonConvert.DeserializeObject<LongSoData>(json);
            if (result.LSo== null)
            {
                result.LSo = LSo;
            }
            result.fsizeVN = result.fsizeVN == 0 ? result.fsizeCN : result.fsizeVN;
            if (result.ScaleFactor == 0)
            {
              //  float scale = (float)SystemParameters.VirtualScreenWidth / (float)result.PageWidth;
                result.ScaleFactor = 1;
            }
            foreach (var item in result.LgSo)
            {
                foreach (var it in item.Value)
                {
                    if (string.IsNullOrEmpty(it.Value.TextVN) && !string.IsNullOrEmpty(it.Value.TextCN))
                    {
                        it.Value.TextVN = CNDictionary.getVN(it.Value.TextCN);
                    }
                    if (!string.IsNullOrEmpty(it.Value.TextVN) && string.IsNullOrEmpty(it.Value.TextCN))
                    {
                        it.Value.TextCN = CNDictionary.getCN(it.Value.TextVN);
                    }
                }
            }

            if (result.KhoaCung==false)
            {
              //  if (result.PagePaddingLeft==0)
                {
                    result.PagePaddingLeft = 20;
                    result.PagePaddingTop = 10;
                    result.PagePaddingLeft = 10;
                }
            }
            return result;
        }
        public static void save(LongSoData item)
        {
            var result = JsonConvert.SerializeObject(item);
            result = Security.Encrypt(result);
            File.WriteAllText("Data/" + item.LSo.FileName, result);
        }

        public static string fstyleToString(int fstyleCN)
        {

            switch (fstyleCN)
            {
                case 1: return "Đậm";
                case 2: return "Nghiêng";
                case 3: return "Thường";
            }
            return null;
        }
        public static int StringTofstyle(string fstyleCN)
        {

            switch (fstyleCN)
            {
                case "Đậm": return 1;
                case "Nghiêng": return 2;
                case "Thường": return 3;
            }
            return 0;
        }
        public bool PageLandscape { get; set; }

    }

    public class Lgso
    {
        public object Value { get; set; }
        public object TextVN { get; set; }
        public object TextCN { get; set; }
        public object TextVNBMK { get; set; }
        public object TextCNBMK { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public object fnameCN { get; set; }
        public float fsizeCN { get; set; }
        public int fstyleCN { get; set; }
        public object fnameVN { get; set; }
        public float fsizeVN { get; set; }
        public int fstyleVN { get; set; }
        public object alignVN { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
        public string Row { get; set; }
        public string Col { get; set; }
    }

}
