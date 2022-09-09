using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
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
            sheet.DisableSettings(unvell.ReoGrid.WorksheetSettings.Behavior_MouseWheelToScroll);
            sheet.DisableSettings(unvell.ReoGrid.WorksheetSettings.Behavior_ScrollToFocusCell);
  

            sheet.SetRowsHeight(0, 10, 30);
 			sheet.SetColumnsWidth(0, 10, 59);
			sheet.ResetAllPageBreaks();
		}
    }
}
