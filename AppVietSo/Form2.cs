using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unvell.ReoGrid;

namespace AppVietSo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var sheet = reoGridControl1.CurrentWorksheet;
            var row = sheet.UsedRange.Row;
            var col = sheet.UsedRange.Row;
            sheet.SetCols(10);
            sheet.SetRows(10);
         

            sheet.SetRowsHeight(0, 10, 30);
            sheet.SetColumnsWidth(0, 10, 59);
            sheet.ResetAllPageBreaks();
            sheet.SetRangeStyles(sheet.UsedRange, new unvell.ReoGrid.WorksheetRangeStyle
            {
                Flag = unvell.ReoGrid.PlainStyleFlag.FontSize,
                FontSize = 26
            });
           sheet.SetSettings(WorksheetSettings.View_ShowHeaders, false);
          // sheet.SetSettings(WorksheetSettings.Behavior_MouseWheelToScroll, false);
          // sheet.SetSettings(WorksheetSettings.Behavior_ScrollToFocusCell, false);
          // sheet.SetSettings(WorksheetSettings.Edit_AutoExpandColumnWidth, false);
          sheet.SetSettings(WorksheetSettings.Edit_AllowAdjustColumnWidth, true);
           sheet.SetSettings(WorksheetSettings.Edit_AutoExpandRowHeight, true);
           sheet.SetSettings(WorksheetSettings.View_AllowShowOutlines, true);
           sheet.SetSettings(WorksheetSettings.View_AllowCellTextOverflow, true);
            sheet.SetSettings(WorksheetSettings.View_ShowGridLine, true);
        }

        private bool m_bLayoutCalled = false;
        private void Form2_Layout(object sender, LayoutEventArgs e)
        {
            if (m_bLayoutCalled == false)
            {
                m_bLayoutCalled = true;
                this.Activate();
                SplashScreen.CloseForm();
            }
        }
    }
}
