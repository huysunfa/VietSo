using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class CellData
    {
        public RectangleF Rct;
        public int RowNoOrg;
        public int ColNoOrg;
        public int RowNo;
        public int ColNo;

 
        public float fsizeVN { get; set; }
        public string fnameVN { get; set; }
        public int fstyleCN { get; set; }
        public float fsizeCN { get; set; }
        public string fnameCN { get; set; }
        public string TextCNBMK { get; set; }
        public string TextVNBMK { get; set; }
        public object Value { get; set; }
        public string TextVN { get; set; }
        public int fstyleVN { get; set; }
        public string TextCN { get; set; }
        public string alignVN { get; set; }

       
    }
}