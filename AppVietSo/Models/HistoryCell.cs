using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid;
using unvell.ReoGrid.Graphics;

namespace AppVietSo.Models
{
    public class ItemHistory
    {
        public object Tag { get; set; }
        public CellStyle Style { get; set; }
        public object Data { get; set; }
        public string Comment { get; set; }
    }
	public class  CellStyle 
	{
	 
		/// <summary>
		/// Get or set cell background color.
		/// </summary>
		public SolidColor BackColor { get; set; }
		public ReoGridHorAlign HAlign { get; set; }
		public ReoGridVerAlign VAlign { get; set; }
		public SolidColor TextColor { get; set; }
		public string FontName { get; set; }
		public float FontSize { get; set; }
		public bool Bold { get; set; }
		public bool Italic { get; set; }
		public bool Strikethrough { get; set; }
		public bool Underline { get; set; }
		public TextWrapMode TextWrap { get; set; }
		public ushort Indent  { get; set; }
		public PaddingValue Padding { get; set; }
		public int RotateAngle { get; set; }
		 
        public static CellStyle Clone(ReferenceCellStyle style)
        {
            var cellstyle = new CellStyle();
            cellstyle.BackColor = style.BackColor;
            cellstyle.HAlign = style.HAlign;
            cellstyle.VAlign = style.VAlign;
            cellstyle.TextColor = style.TextColor;
            cellstyle.FontName = style.FontName;
            cellstyle.FontSize = style.FontSize;
            cellstyle.Bold = style.Bold;
            cellstyle.Italic = style.Italic;
            cellstyle.Strikethrough = style.Strikethrough;
            cellstyle.Underline = style.Underline;
            cellstyle.TextWrap = style.TextWrap;
            cellstyle.Indent = style.Indent;
            cellstyle.Padding = style.Padding;
            cellstyle.RotateAngle = style.RotateAngle;
            return cellstyle;
        }
    }

	public class HistoryCell
    {
        public int Index { get; set; }
        public Dictionary<int, ItemHistory> cell { get; set; }

        public ItemHistory BackItem()
        {
            int last = Index - 1;
            if (cell.ContainsKey(last))
            {
                var item = cell[last];
                return item;
            }
            return null;
        }  
        
        public ItemHistory NextItem()
        {
            int last = Index + 1;
            if (cell.ContainsKey(last))
            {
                var item = cell[last];
                return item;
            }
            return null;
        }
    }
}
