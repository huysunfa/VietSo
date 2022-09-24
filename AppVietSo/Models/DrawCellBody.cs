using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid.CellTypes;
using unvell.ReoGrid.Rendering;

namespace AppVietSo.Models
{
    class DrawCellBody : CellBody
    {
        Font font;
        public DrawCellBody(Font _font)
        {
            font = _font;
        }
        public override void OnPaint(CellDrawingContext dc)
        {
            // draw an ellipse inside cell
             System.Drawing.Brush brush = new SolidBrush(Color.Black);

            dc.Graphics.PlatformGraphics.DrawString(dc.Cell.DisplayText
                , font
                , brush, PointF.Empty
                );
        }
    }

}
