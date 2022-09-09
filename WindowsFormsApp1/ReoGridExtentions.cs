using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid;

namespace WindowsFormsApp1
{
    public static class ReoGridExtentions
    {
        public static void ShowBolder(this ReoGridControl reoGridControl1, bool show = true)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            worksheet.SetRangeBorders(worksheet.UsedRange, BorderPositions.All,
                                 new unvell.ReoGrid.RangeBorderStyle
                                 {
                                     Style = (show? BorderLineStyle.Solid : BorderLineStyle.None),
                                     Color = Color.WhiteSmoke
                                 });
        }
    }
}
