using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    class UserSettingPrint
    {
        public int ZoomIndex { get; set; }
        public float MarginT { get; set; }
        public float MarginB { get; set; }
        public float MarginL { get; set; }
        public float MarginR { get; set; }
        public bool PageIsShowPageNo { get; set; }
        public bool PageIsFooter { get; set; }
        public string PageTitleLeft { get; set; }
        public string PageTitleCenter { get; set; }
        public string PageTitleRight { get; set; }
        public string PaperName { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public decimal FontSize { get; set; }
        public string FontName { get; set; }
        public bool SpaceFamily { get; set; }
        public List<int> ColHiden { get; set; }
        public Dictionary<int, ushort> ColWidth { get; set; }
    }
}




