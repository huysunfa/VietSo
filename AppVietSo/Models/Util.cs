using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class Util
    {
        public static LongSoData LongSoHienTai;
        public static ThietLapTinChu thietLapTinChu;
        public static string NameLongSoHienTai;
        public static string domain = "ltsgroup.xyz";
        public static string sdtSupport = "0827.298.555";
        public static string mainURL = "http://ltsgroup.xyz/";
        public static string getTempPath = Path.GetTempPath();
        public static string getDataPath = System.IO.Directory.GetCurrentDirectory() + "/Data/";
        public static string getNgachSoPath = "Data/NgachSo.Config";
        public static string getDictionaryPath = "Data/Dictionary.Config";
        public static string getTinChuPath = "Data/TinChu";
        public static string getDicLongSoPath = "Data/DicLongSoPath.Config";
        public static string getDictionaryNguCanhPath = "Data/DictionaryNguCanh.Config";
        public static string getDicFontVN = "Data/DicFontVN.Config";
        public static string getDicFontCN = "Data/DicFontCN.Config";
        public static string getDicLabelText = "Data/DicLabelText.Config";
        public static float DefaultFontSize = 16;
        public static string strDataSugget;
        // Token: 0x06000078 RID: 120 RVA: 0x000050A8 File Offset: 0x000032A8
        public static float InchToPixel(float inch, float dpi)
        {
            return inch * dpi;
        }

        // Token: 0x06000079 RID: 121 RVA: 0x000050B8 File Offset: 0x000032B8
        public static float PixelToInch(float px, float dpi)
        {
            return px / dpi;
        }

        // Token: 0x0600007A RID: 122 RVA: 0x000050C8 File Offset: 0x000032C8
        public static void getCanChi(int year, out string can, out string chi)
        {
            string[] array = new string[]
            {
                "Canh",
                "Tân",
                "Nhâm",
                "Qúy",
                "Giáp",
                "Ất",
                "Bính",
                "Đinh",
                "Mậu",
                "Kỷ"
            };
            string[] array2 = new string[]
            {
                "Thân",
                "Dậu",
                "Tuất",
                "Hơi",
                "Tý",
                "Sửu",
                "Dần",
                "Mão",
                "Thìn",
                "Tỵ",
                "Ngọ",
                "Mùi"
            };
            can = array[year % 10];
            chi = array2[year % 12];
        }

        // Token: 0x0600007B RID: 123 RVA: 0x000051C0 File Offset: 0x000033C0
        public static string getCanChiVN(int year)
        {
            string[] array = new string[]
            {
                "Canh",
                "Tân",
                "Nhâm",
                "Quý",
                "Giáp",
                "Ất",
                "Bính",
                "Đinh",
                "Mậu",
                "Kỷ"
            };
            string[] array2 = new string[]
            {
                "Thân",
                "Dậu",
                "Tuất",
                "Hợi",
                "Tý",
                "Sửu",
                "Dần",
                "Mão",
                "Thìn",
                "Tỵ",
                "Ngọ",
                "Mùi"
            };
            return array[year % 10] + " " + array2[year % 12];
        }


        public static string getSaoVN(int year, bool isMale)
        {
            if (year <= 0)
            {
                return "";
            }
            while (9 < year)
            {
                year -= 9;
            }
            year--;
            string[] array = new string[]
            {
                "La Hầu",
                "Thổ Tú",
                "Thủy Diệu",
                "Thái Bạch",
                "Thái Dương",
                "Vân Hán",
                "Kế Đô",
                "Thái Âm",
                "Mộc Đức"
            };
            string[] array2 = new string[]
            {
                "Kế Đô",
                "Vân Hán",
                "Mộc Đức",
                "Thái Âm",
                "Thổ Tú",
                "La Hầu",
                "Thái Dương",
                "Thái Bạch",
                "Thủy Diệu"
            };
            if (!isMale)
            {
                return array2[year];
            }
            return array[year];
        }



        // Token: 0x06000082 RID: 130 RVA: 0x000055C8 File Offset: 0x000037C8
        public static string filterCheck(string filter)
        {
            filter = Util.RemoveDoubleSpace(filter);
            while (filter.Contains(")"))
            {
                filter = filter.Replace(")", "");
            }
            while (filter.Contains("("))
            {
                filter = filter.Replace("(", "");
            }
            filter = filter.Replace(" ", " AND ");
            return filter;
        }

        // Token: 0x06000083 RID: 131 RVA: 0x00005638 File Offset: 0x00003838
        public static DateTime ConvertStr2Date(string cnToDateStr, bool isAddTime = true)
        {
            DateTime result = default(DateTime);
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



        // Token: 0x0600008E RID: 142 RVA: 0x000058C8 File Offset: 0x00003AC8
        public static string NonUnicode(string text)
        {
            string[] array = new string[]
            {
                "á",
                "à",
                "ả",
                "ã",
                "ạ",
                "â",
                "ấ",
                "ầ",
                "ẩ",
                "ẫ",
                "ậ",
                "ă",
                "ắ",
                "ằ",
                "ẳ",
                "ẵ",
                "ặ",
                "đ",
                "é",
                "è",
                "ẻ",
                "ẽ",
                "ẹ",
                "ê",
                "ế",
                "ề",
                "ể",
                "ễ",
                "ệ",
                "í",
                "ì",
                "ỉ",
                "ĩ",
                "ị",
                "ó",
                "ò",
                "ỏ",
                "õ",
                "ọ",
                "ô",
                "ố",
                "ồ",
                "ổ",
                "ỗ",
                "ộ",
                "ơ",
                "ớ",
                "ờ",
                "ở",
                "ỡ",
                "ợ",
                "ú",
                "ù",
                "ủ",
                "ũ",
                "ụ",
                "ư",
                "ứ",
                "ừ",
                "ử",
                "ữ",
                "ự",
                "ý",
                "ỳ",
                "ỷ",
                "ỹ",
                "ỵ"
            };
            string[] array2 = new string[]
            {
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "d",
                "e",
                "e",
                "e",
                "e",
                "e",
                "e",
                "e",
                "e",
                "e",
                "e",
                "e",
                "i",
                "i",
                "i",
                "i",
                "i",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "o",
                "u",
                "u",
                "u",
                "u",
                "u",
                "u",
                "u",
                "u",
                "u",
                "u",
                "u",
                "y",
                "y",
                "y",
                "y",
                "y"
            };
            for (int i = 0; i <= array.Length - 1; i++)
            {
                text = text.Replace(array[i], array2[i]);
                text = text.Replace(array[i].ToUpper(), array2[i].ToUpper());
            }
            return text;
        }

        // Token: 0x0600008F RID: 143 RVA: 0x00005E48 File Offset: 0x00004048
        public static string RemoveDoubleSpace(string s)
        {
            s = s.Trim();
            while (s.Contains("  "))
            {
                s = s.Replace("  ", " ");
            }
            return s;
        }

        // Token: 0x06000090 RID: 144 RVA: 0x00005E84 File Offset: 0x00004084
        public static bool isChineseLang(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (char.GetUnicodeCategory(s[i]) == UnicodeCategory.OtherLetter)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000091 RID: 145 RVA: 0x00005EB8 File Offset: 0x000040B8

        // Token: 0x06000093 RID: 147 RVA: 0x00005F08 File Offset: 0x00004108
        public static bool IsUpper(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsLower(value[i]))
                {
                    return false;
                }
            }
            return true;
        }

        // Token: 0x06000094 RID: 148 RVA: 0x00005F38 File Offset: 0x00004138
        public static string GetComputerIMEI()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress().ToString();
                }
            }
            return null;
        }
        public static string queryServer(string url, string para)
        {
            string json = new WebClient().DownloadString(url + "?" + para);
            return json;
        }
    }
}
