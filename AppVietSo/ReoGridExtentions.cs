using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid;

namespace AppVietSo
{
    public static class ReoGridExtentions
    {
        public static void ShowBolder(this ReoGridControl reoGridControl1, bool show = true)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            worksheet.SetRangeBorders(worksheet.UsedRange, BorderPositions.All,
                               new unvell.ReoGrid.RangeBorderStyle { Style = BorderLineStyle.None });

            if (show)
            {
                var rangedata = new RangePosition(
                    worksheet.UsedRange.Row + 1
                    , worksheet.UsedRange.Col + 1
                    , worksheet.UsedRange.EndRow - 1
                    , worksheet.UsedRange.EndCol - 1
                    );

                worksheet.SetRangeBorders(rangedata, BorderPositions.All,
                                     new unvell.ReoGrid.RangeBorderStyle
                                     {
                                         Style = BorderLineStyle.Solid,
                                         Color = Color.WhiteSmoke
                                     });
            }
        }
        
        public static void PreView(this ReoGridControl reoGrid ,object sender= null, EventArgs e=null)
        {
      //      LoadDataToDataGrid(reoGrid);

        }
    }
}
