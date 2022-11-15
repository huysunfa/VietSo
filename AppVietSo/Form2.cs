using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unvell.ReoGrid;
using unvell.ReoGrid.Actions;

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
            sheet.SetCols(32);
            sheet.SetRows(32);

            sheet.SetRowsHeight(0, 32, 30);
            sheet.SetColumnsWidth(0, 32, 59);

            for (int i = 0; i < sheet.UsedRange.Rows; i++)
            {

                for (int j = 0; j < sheet.UsedRange.Cols; j++)
                {
                    sheet.Cells[i, j].Data = i * j;
                }
            }
          
 
            sheet.SetSettings(WorksheetSettings.View_ShowPageBreaks, true);
     
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

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument doc = null;
            var printsetting = ActiveData.Get("@SuDungCauHinhMayInMacDinh").ToBool();

            try
            {
                doc = reoGridControl1.CurrentWorksheet.CreatePrintSession(printsetting).PrintDocument;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var pd = new System.Windows.Forms.PrintDialog())
            {
                pd.Document = doc;
                pd.UseEXDialog = true;  // in 64bit Windows

                if (pd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                }
            }

            if (doc != null) doc.Dispose();

        }

     

    }
}
