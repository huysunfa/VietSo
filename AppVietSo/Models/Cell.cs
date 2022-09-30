using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class Cell
    {
 
        public CellBorder BdrLeft { get; set; }
        public CellBorder BdrTop { get; set; }
        public int RowSpan { get; set; }
        public int ColSpan { get; set; }
        public string MergeRange { get; set; }
        public int VAlignment { get; set; }
        public int HAlignment { get; set; }
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
        public string BColor { get; set; }
        public string FColor { get; set; }
        public bool FontItalic { get; set; }
        public bool FontBold { get; set; }
        public float FontSize { get; set; }
        public string FontName { get; set; }
        public string Formula { get; set; }
        public object Value { get; set; }
        public object ValType { get; set; }
        public bool IsReadOnly { get; set; }
        public CellBorder BdrBottom { get; set; }
        public CellBorder BdrRight { get; set; }
    }
}