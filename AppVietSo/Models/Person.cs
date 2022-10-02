using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class Person : AKT
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public int NamSinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Address { get; set; }
        public string PagodaID { get; set; }
        public int SoNo { get; set; }
        public int Orders { get; set; }
        public string Status { get; set; }
        public DateTime UpdateDT { get; set; }
        public string NgayMat { get; set; }
        public string DanhXung { get; set; }
        //public string DaiHanY { get; set; }
        //public int getAge { get; set; }
        //public string GioiTinhDisplay { get; set; }
        //public string HTho { get; set; }
        //public string Menh { get; set; }
        //public string Sao { get; set; }
        //public string Tuoi { get; set; }
        public override object getId()
        {
            return this.ID;
        }
        public string GioiTinhDisplay
        {
            get
            {
                if (!this.GioiTinh)
                {
                    return "Nữ";
                }
                return "Nam";
            }
        }
        public string Menh
        {
            get
            {
                if (!this.NamSinh.Equals(0))
                {
                    string str;
                    string str2;
                    Util.getCanChiVN(this.NamSinh, out str, out str2);
                    return str + " " + str2;
                }
                return "";
            }
        }
        // Token: 0x17000041 RID: 65
        // (get) Token: 0x06000129 RID: 297 RVA: 0x00006890 File Offset: 0x00004A90
        public string DaiHanY
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.NgayMat) && 3 < this.NgayMat.Length)
                {
                    int year = 0;
                    if (this.NgayMat.Length == 4)
                    {
                        int.TryParse(this.NgayMat, out year);
                    }
                    else
                    {
                        int.TryParse(this.NgayMat.Split(new char[]
                        {
                            '/'
                        })[2], out year);
                    }
                    if (!year.Equals(0))
                    {
                        string str;
                        string str2;
                        Util.getCanChiVN(year, out str, out str2);
                        return str + " " + str2;
                    }
                }
                return "";
            }
        }

        // Token: 0x17000042 RID: 66
        // (get) Token: 0x0600012A RID: 298 RVA: 0x00006920 File Offset: 0x00004B20
        public string HTho
        {
            get
            {
                if (!this.NamSinh.Equals(0) && !string.IsNullOrWhiteSpace(this.NgayMat) && 3 < this.NgayMat.Length)
                {
                    int num = 0;
                    if (this.NgayMat.Length != 4)
                    {
                        int.TryParse(this.NgayMat.Split(new char[]
                        {
                            '/'
                        })[2], out num);
                    }
                    else
                    {
                        int.TryParse(this.NgayMat, out num);
                    }
                    int num2 = num - new global::System.DateTime(this.NamSinh, 1, 1).Year;
                    if (new global::System.DateTime(this.NamSinh, 1, 1) > new global::System.DateTime(num, 1, 1).AddYears(-num2))
                    {
                        num2--;
                    }
                    return (num2 + 1).ToString() ?? "";
                }
                return "";
            }
        }

        public Year isNextYear = Year.Cur;
        // Token: 0x17000043 RID: 67
        // (get) Token: 0x0600012B RID: 299 RVA: 0x00006A00 File Offset: 0x00004C00
        private int getAge
        {
            get
            {
 
                DateTime.TryParseExact(NgayMat, "dd/MM/yyyy",
                           System.Globalization.CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.None,
                           out DateTime mat);
                return (mat.Year - this.NamSinh)+1;
            }
        }

        // Token: 0x17000044 RID: 68
        // (get) Token: 0x0600012C RID: 300 RVA: 0x00006AE8 File Offset: 0x00004CE8
        public string Tuoi
        {
            get
            {
                if (!this.NamSinh.Equals(0))
                {
                    return this.getAge.ToString() ?? "";
                }
                return "";
            }
        }

        // Token: 0x17000045 RID: 69
        // (get) Token: 0x0600012D RID: 301 RVA: 0x00006B24 File Offset: 0x00004D24
        public string Sao
        {
            get
            {
                if (this.NamSinh.Equals(0))
                {
                    return "";
                }
                return Util.getSaoVN(this.getAge, this.GioiTinh);
            }
        }
    }
}
