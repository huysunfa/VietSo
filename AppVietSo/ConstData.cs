using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unvell.ReoGrid;

namespace AppVietSo
{
    public static class ConstData
    {
        public const string ExtentionsFile = ".hc";
        public static CellData getCellData(this object input)
        {
            var result = (CellData)input;
            if (result == null)
            {
                result = new CellData();
            }
            return result;
        }
        public static string renderViewText(this unvell.ReoGrid.Cell input)
        {
            var Status = input.DataFormatArgs + "";
            var cell = input.Tag.getCellData();
            switch (Status)
            {

                case "TextVN": return cell.TextVN;   
                case "TextCN": return cell.TextCN; 

            }
            return null;
        }
        public static List<string> ToListData(this string input)
        {
            var result = (input + "").Split(' ').Where(v =>  !string.IsNullOrEmpty(v+"")).ToList();

            return result;
        }
        public static bool CheckNo(this object input, string Duoi = "")
        {

            if ((input + "").StartsWith("NO"))
            {
                if (!string.IsNullOrEmpty(Duoi) && !(input + "").EndsWith(Duoi))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
             public static bool CheckSkip(this object input, string Duoi = "")
        {

            if ((input + "").StartsWith("SKIP"))
            {
                if (!string.IsNullOrEmpty(Duoi) && !(input + "").EndsWith(Duoi))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public static DataTable ToDataTable(this DataGridView dataGridView, string tableName)
        {

            DataGridView dgv = dataGridView;
            DataTable table = new DataTable(tableName);

            // Crea las columnas 
            for (int iCol = 0; iCol < dgv.Columns.Count; iCol++)
            {
                table.Columns.Add(dgv.Columns[iCol].Name);
            }

            /**
              * THIS DOES NOT WORK
              */
            // Agrega las filas 
            /*for (int i = 0; i < dgv.Rows.Count; i++)
            {
                // Obtiene el DataBound de la fila y copia los valores de la fila 
                DataRowView boundRow = (DataRowView)dgv.Rows[i].DataBoundItem;
                var cells = new object[boundRow.Row.ItemArray.Length];
                for (int iCol = 0; iCol < boundRow.Row.ItemArray.Length; iCol++)
                {
                    cells[iCol] = boundRow.Row.ItemArray[iCol];
                }

                // Agrega la fila clonada                 
                table.Rows.Add(cells);
            }*/

            /* THIS WORKS BUT... */
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Index >= dgv.Rows.Count - 1)
                {
                    continue;
                }

                DataRow datarw = table.NewRow();

                for (int iCol = 0; iCol < dgv.Columns.Count; iCol++)
                {
                    datarw[iCol] = row.Cells[iCol].Value;
                }

                table.Rows.Add(datarw);
            }

            return table;
        }
    }
}
