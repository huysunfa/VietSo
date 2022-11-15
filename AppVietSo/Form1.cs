using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using unvell.ReoGrid;
using unvell.ReoGrid.Actions;
using unvell.ReoGrid.CellTypes;
using unvell.ReoGrid.Print;

namespace AppVietSo
{
    public partial class Form1 : Form
    {
        bool editting = false;
        public Form1()
        {
            InitializeComponent();
        }


        FlowLayoutPanel dynamicPanel = new FlowLayoutPanel();
        PrivateFontCollection pfc = new PrivateFontCollection();
        #region Function
        public void loadListFont()
        {

            var lastVN = cbfnameVN.Text;
            var lastCN = cbfnameCN.Text;

            cbfnameCN.Items.Clear();
            cbfnameVN.Items.Clear();

            foreach (var item in loadFont.loadListFontCN())
            {
                cbfnameCN.Items.Add(item);
            }
            foreach (var item in loadFont.loadListFontVN())
            {
                cbfnameVN.Items.Add(item);
            }
            cbfnameVN.Text = lastVN;
            cbfnameCN.Text = lastCN;
        }
        public void addMenuContext()
        {

        }
        private void addTextLongSo(string bm, string t)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var Row = worksheet.SelectionRange.Row;
            var Col = worksheet.SelectionRange.Col;
            var item = worksheet.Cells[Row, Col];
            var selection = item.DataFormatArgs + "";
            if (selection.CheckNo() || Row == 0 || Col == 0)
            {
                return;
            }
            if (bm.StartsWith("@"))
            {
                bm = bm.ToLower();
                var val = ActiveData.Get(bm, out string CN, out string VN);
                if (!val)
                {
                    if (frmTinChu.keys.Contains(bm) || bm == "@tinchu")
                    {
                        frmTinChu frm = new frmTinChu();
                        frm.ShowDialog();
                        ActiveData.Get(bm, out CN, out VN);
                        setText(Row, Col, VN, CN);

                    }
                    else
                    {
                        showSugget(bm, t);
                    }
                }
                else
                {
                    setText(Row, Col, bm, CN + "_" + VN);
                }
            }
            else
            {
                setText(Row, Col, bm, bm);
            }
            SaveData();
        }

        #endregion

        #region Menu chuột phải

        // Token: 0x060000CE RID: 206 RVA: 0x0000E604 File Offset: 0x0000C804
        private void TSMItemThemChuSauTinChu_Click(object sender, global::System.EventArgs e)
        {
            SaveData();
            var frm = new FrmThietLapTinChu();
            frm.ShowDialog();
            ReLoad(sender, e);
        }
        private void TSMItemThemChuSauHuongLinh_Click(object sender, global::System.EventArgs e)
        {
            SaveData();
            var frm = new FrmThietLapHuongLinh();
            frm.ShowDialog();
            ReLoad(sender, e);
        }

        // Token: 0x060000CF RID: 207 RVA: 0x0000E688 File Offset: 0x0000C888
        //private void TSMItemPaste_Click(object sender, global::System.EventArgs e)
        //{
        //    var worksheet = reoGridControl1.CurrentWorksheet;
        //    int Col = worksheet.UsedRange.EndCol;
        //    int Row = worksheet.UsedRange.EndRow;
        //    var cell2 = reoGridControl1.CurrentWorksheet.Cells[Row, Col];
        //    if (cell2.CheckNo())
        //    {
        //        return;
        //    }

        //    var text = Clipboard.GetText();

        //    object[,] data = RGUtility.ParseTabbedString(text);

        //     var select = worksheet.SelectionRange;
        //    int maxCol = select.Row + data.Length;
        //    int maxRow = select.Row + data.Length;
        //    var action = new SetRangeDataAction(select, data);
        //    reoGridControl1.DoAction(reoGridControl1.CurrentWorksheet, action);


        //    return;
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        var row = input[i].Split('\t');
        //        for (int j = 0; j < row.Length; j++)
        //        {
        //            if (select.Row + i > Row)
        //            {
        //                continue;
        //            }

        //            if (select.Col + j > Col)
        //            {
        //                continue;
        //            }
        //            var item = worksheet.Cells[select.Row + i, select.Col + j];
        //            if (item.Style.BackColor == Color.LightGray)
        //            {
        //                continue;
        //            }

        //            item.Data = row[j];


        //            var cell = item.Tag.getCellData();


        //            if ((string)item.DataFormatArgs == "TextVN")
        //            {
        //                cell.Value = null;
        //                cell.TextVN = row[j];
        //                cell.TextCN = CNDictionary.getCN(row[j]);
        //            }
        //            else
        //            {
        //                cell.Value = null;
        //                cell.TextCN = row[j];
        //                cell.TextVN = CNDictionary.getVN(row[j]);
        //            }
        //            item.Tag = cell;


        //        }
        //    }
        //    SaveData();
        //}
        private void TSMItemPaste_Click(object sender, global::System.EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            int Col = worksheet.UsedRange.EndCol;
            int Row = worksheet.UsedRange.EndRow;
            var cell2 = reoGridControl1.CurrentWorksheet.Cells[Row, Col];
            if (cell2.CheckNo())
            {
                return;
            }

            var text = Clipboard.GetText();


            var input = text.Split('\n');
            var select = worksheet.SelectionRange;
            for (int i = 0; i < input.Length; i++)
            {
                var row = input[i].Split('\t');
                for (int j = 0; j < row.Length; j++)
                {
                    if (select.Row + i > Row)
                    {
                        continue;
                    }

                    if (select.Col + j > Col)
                    {
                        continue;
                    }
                    var item = worksheet.Cells[select.Row + i, select.Col + j];
                    if (item.Style.BackColor == Color.LightGray)
                    {
                        continue;
                    }

                    item.Data = row[j];


                    var cell = item.Tag.getCellData();


                    if ((string)item.DataFormatArgs == "TextVN")
                    {
                        cell.Value = null;
                        cell.TextVN = row[j];
                        cell.TextCN = CNDictionary.getCN(row[j]);
                    }
                    else
                    {
                        cell.Value = null;
                        cell.TextCN = row[j];
                        cell.TextVN = CNDictionary.getVN(row[j]);
                    }
                    item.Tag = cell;


                }
            }
            SaveData();
        }

        private void TSMItemAddRow_Click(object sender, global::System.EventArgs e)
        {

            var worksheet = reoGridControl1.CurrentWorksheet;
            var i = worksheet.SelectionRange.Row;
            if (rbSongNgu.Checked)
            {

                var PosText = cbCanChuViet.Text;
                if (PosText == "DƯỚI")
                {
                    var action = new InsertRowsAction(i - 1, 2);
                    reoGridControl1.DoAction(action);
                }
                if (PosText == "TRÊN")
                {
                    var action = new InsertRowsAction(i, 2);
                    reoGridControl1.DoAction(action);
                }
                if (PosText == "PHẢI" || PosText == "TRÁI")
                {
                    var action = new InsertRowsAction(i, 1);
                    reoGridControl1.DoAction(action);
                }


            }
            else
            {
                var action = new InsertRowsAction(i, 1);
                reoGridControl1.DoAction(action);
            }



            for (int cnt = 0; cnt < worksheet.UsedRange.EndCol; cnt++)
            {
                if (rbChuHan.Checked)
                {
                    worksheet.Cells[i, cnt].DataFormatArgs = "TextCN";
                }
                if (rbChuViet.Checked)
                {
                    worksheet.Cells[i, cnt].DataFormatArgs = "TextVN";
                }

                if (rbSongNgu.Checked)
                {
                    var PosText = cbCanChuViet.Text;
                    if (PosText == "DƯỚI")
                    {
                        worksheet.Cells[i - 1, cnt].DataFormatArgs = worksheet.Cells[i + 1, cnt].DataFormatArgs;
                        worksheet.Cells[i, cnt].DataFormatArgs = worksheet.Cells[i + 2, cnt].DataFormatArgs;

                        var item = worksheet.Cells[i - 1, cnt];
                        ReoGridExtentions.ChangeFontAndSize(worksheet, (item.DataFormatArgs + ""), item.Address, cbfnameCN.Text, cbfstyleCN.Text, cbfsizeCN.Text, cbfnameVN.Text, cbfstyleVN.Text, cbfsizeVN.Text);

                        var item2 = worksheet.Cells[i, cnt];
                        ChangeFontAndSize(worksheet, (item2.DataFormatArgs + ""), item2.Address);

                    }
                    if (PosText == "TRÊN")
                    {
                        worksheet.Cells[i + 1, cnt].DataFormatArgs = worksheet.Cells[i - 1, cnt].DataFormatArgs;
                        worksheet.Cells[i, cnt].DataFormatArgs = worksheet.Cells[i - 2, cnt].DataFormatArgs;

                        var item = worksheet.Cells[i, cnt];
                        ChangeFontAndSize(worksheet, (item.DataFormatArgs + ""), item.Address);

                        var item2 = worksheet.Cells[i + 1, cnt];
                        ChangeFontAndSize(worksheet, (item2.DataFormatArgs + ""), item2.Address);
                    }
                    if (PosText == "PHẢI" || PosText == "TRÁI")
                    {
                        worksheet.Cells[i, cnt].DataFormatArgs = worksheet.Cells[i - 1, cnt].DataFormatArgs;
                        var item = worksheet.Cells[i, cnt];
                        ChangeFontAndSize(worksheet, (item.DataFormatArgs + ""), item.Address);
                    }


                }
                else
                {
                    var item = worksheet.Cells[i, cnt];
                    ChangeFontAndSize(worksheet, (item.DataFormatArgs + ""), item.Address);
                }
            }


            reoGridControl1.ShowBolder(cbHideGridLine.Checked);
            SaveData();
            worksheet.ScaleFactor += (float)0.001;
        }
        public void ChangeFontAndSize(Worksheet worksheet, string Data, string Address)
        {
            ReoGridExtentions.ChangeFontAndSize(worksheet, Data, Address, cbfnameCN.Text, cbfstyleCN.Text, cbfsizeCN.Text, cbfnameVN.Text, cbfstyleVN.Text, cbfsizeVN.Text);

        }
        private void TSMItemAddCol_Click(object sender, global::System.EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var cnt = worksheet.SelectionRange.Col;
            if (rbSongNgu.Checked)
            {
                var PosText = cbCanChuViet.Text;
                if (PosText == "PHẢI")
                {
                    if (cnt == 0) return;

                    var action = new InsertColumnsAction(cnt - 1, 2);
                    reoGridControl1.DoAction(action);
                }
                if (PosText == "TRÁI")
                {
                    var action = new InsertColumnsAction(cnt, 2);
                    reoGridControl1.DoAction(action);
                }
                if (PosText == "TRÊN" || PosText == "DƯỚI")
                {
                    var action = new InsertColumnsAction(cnt, 1);
                    reoGridControl1.DoAction(action);
                }

            }
            else
            {
                var action = new InsertColumnsAction(cnt, 1);
                reoGridControl1.DoAction(action);
            }



            for (int i = 0; i < worksheet.UsedRange.EndRow; i++)
            {
                if (rbChuHan.Checked)
                {
                    worksheet.Cells[i, cnt].DataFormatArgs = "TextCN";
                }
                if (rbChuViet.Checked)
                {
                    worksheet.Cells[i, cnt].DataFormatArgs = "TextVN";
                }

                if (rbSongNgu.Checked)
                {
                    var PosText = cbCanChuViet.Text;
                    if (PosText == "PHẢI")
                    {
                        worksheet.Cells[i, cnt - 1].DataFormatArgs = worksheet.Cells[i, cnt + 1].DataFormatArgs;
                        worksheet.Cells[i, cnt].DataFormatArgs = worksheet.Cells[i, cnt + 2].DataFormatArgs;

                        var item = worksheet.Cells[i, cnt - 1];
                        ChangeFontAndSize(worksheet, (item.DataFormatArgs + ""), item.Address);

                        var item2 = worksheet.Cells[i, cnt];
                        ChangeFontAndSize(worksheet, (item2.DataFormatArgs + ""), item2.Address);

                    }
                    if (PosText == "TRÁI")
                    {
                        worksheet.Cells[i, cnt + 1].DataFormatArgs = worksheet.Cells[i, cnt - 1].DataFormatArgs;
                        worksheet.Cells[i, cnt].DataFormatArgs = worksheet.Cells[i, cnt - 2].DataFormatArgs;

                        var item = worksheet.Cells[i, cnt];
                        ChangeFontAndSize(worksheet, (item.DataFormatArgs + ""), item.Address);

                        var item2 = worksheet.Cells[i, cnt + 1];
                        ChangeFontAndSize(worksheet, (item2.DataFormatArgs + ""), item2.Address);
                    }
                    if (PosText == "TRÊN" || PosText == "DƯỚI")
                    {
                        worksheet.Cells[i, cnt].DataFormatArgs = worksheet.Cells[i, cnt - 1].DataFormatArgs;
                        var item = worksheet.Cells[i, cnt];
                        ChangeFontAndSize(worksheet, (item.DataFormatArgs + ""), item.Address);
                    }


                }
                else
                {
                    var item = worksheet.Cells[i, cnt];
                    ChangeFontAndSize(worksheet, (item.DataFormatArgs + ""), item.Address);
                }
            }


            reoGridControl1.ShowBolder(cbHideGridLine.Checked);
            SaveData();
            worksheet.ScaleFactor += (float)0.001;
        }

        // Token: 0x060000D2 RID: 210 RVA: 0x0000E76C File Offset: 0x0000C96C
        private void TSMItemDelRow_Click(object sender, global::System.EventArgs e)
        {

            var worksheet = reoGridControl1.CurrentWorksheet;
            var i = worksheet.SelectionRange.Row;
            if (rbSongNgu.Checked)
            {

                var PosText = cbCanChuViet.Text;
                if (PosText == "PHẢI")
                {
                    var action = new RemoveRowsAction(i - 1, 2);
                    reoGridControl1.DoAction(action);
                }
                if (PosText == "TRÁI")
                {
                    var action = new RemoveRowsAction(i, 2);
                    reoGridControl1.DoAction(action);
                }
                if (PosText == "TRÊN" || PosText == "DƯỚI")
                {
                    var action = new RemoveRowsAction(i, 1);
                    reoGridControl1.DoAction(action);
                }


            }
            else
            {
                var action = new RemoveRowsAction(i, 1);
                reoGridControl1.DoAction(action);
            }





            SaveData();
            worksheet.ScaleFactor += (float)0.001;
        }

        // Token: 0x060000D3 RID: 211 RVA: 0x0000E7C8 File Offset: 0x0000C9C8
        private void TSMItemDelCol_Click(object sender, global::System.EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var cnt = worksheet.SelectionRange.Col;
            if (rbSongNgu.Checked)
            {
                var PosText = cbCanChuViet.Text;
                if (PosText == "PHẢI")
                {
                    var action = new RemoveColumnsAction(cnt - 1, 2);
                    reoGridControl1.DoAction(action);
                }
                if (PosText == "TRÁI")
                {
                    var action = new RemoveColumnsAction(cnt, 2);
                    reoGridControl1.DoAction(action);
                }
                if (PosText == "TRÊN" || PosText == "DƯỚI")
                {
                    var action = new RemoveColumnsAction(cnt, 1);
                    reoGridControl1.DoAction(action);
                }

            }
            else
            {
                var action = new RemoveColumnsAction(cnt, 1);
                reoGridControl1.DoAction(action);
            }

            SaveData();
            worksheet.ScaleFactor += (float)0.001;
        }

        // Token: 0x060000D4 RID: 212 RVA: 0x0000E824 File Offset: 0x0000CA24
        private void TSMItemDelCel_Click(object sender, global::System.EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var select = worksheet.SelectionRange;
            //var render = false;

            var action = new RemoveRangeDataAction(select);
            var action2 = new RemoveRangeStyleAction(select, PlainStyleFlag.BackColor);
            reoGridControl1.DoAction(action2);
            reoGridControl1.DoAction(action);


            //for (int i = select.Row; i <= select.EndRow; i++)
            //{
            //    for (int j = select.Col; j <= select.EndCol; j++)
            //    {
            //        var item = worksheet.Cells[i, j];
            //        item.Data = "";
            //        item.DataFormatArgs = (item.DataFormatArgs + "").Split('_').LastOrDefault();
            //        var cell = worksheet.Cells[i, j].Tag.getCellData();
            //        if ((cell.Value + "") == "@tinchu")
            //        {
            //            render = true;

            //        }
            //        item.Tag = new CellData();
            //        setColorTag(worksheet, item, Color.White);
            //    }
            //}
            SaveData();
            //if (render)
            //{
            //    ReLoad(sender, e);
            //}
        }

        private void TSMItemAddMua_Click(object sender, global::System.EventArgs e)
        {

            addTextLongSo("@mua", "Mùa");
        }

        // Token: 0x060000D6 RID: 214 RVA: 0x0000E88E File Offset: 0x0000CA8E
        private void TSMItemAddYear_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@nam", "Năm");
        }

        // Token: 0x060000D7 RID: 215 RVA: 0x0000E8A0 File Offset: 0x0000CAA0
        private void TSMItemAddMonth_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@thang", "Tháng");
        }

        // Token: 0x060000D8 RID: 216 RVA: 0x0000E8B2 File Offset: 0x0000CAB2
        private void TSMItemAddDay_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@ngay", "Ngày");
        }
        private void TSMItemAddGio_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@gio", "Giờ");
        }

        // Token: 0x060000D9 RID: 217 RVA: 0x0000E8C4 File Offset: 0x0000CAC4
        private void TSMItemAddNoiC_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@noicung", "Nơi cúng");
        }

        // Token: 0x060000DA RID: 218 RVA: 0x0000E8D6 File Offset: 0x0000CAD6
        private void TSMItemAddAdress_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();

            addTextLongSo("@diachiyvu", "Địa chỉ");
        }

        // Token: 0x060000DB RID: 219 RVA: 0x0000E8E8 File Offset: 0x0000CAE8
        private void TSMItemAddNgachSo_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@ngachso", "Ngạch sớ");
        }

        private void TSMItemEditText_Click(object sender, global::System.EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var Row = worksheet.SelectionRange.Row;
            var Col = worksheet.SelectionRange.Col;

            var cell = worksheet.Cells[Row, Col];
            string TextVN = cell.Tag.getCellData().TextVN;
            var frmMatChu = new frmThemMatChu(TextVN);
            frmMatChu.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y);
            frmMatChu.ShowDialog();
            RenderStyle();
        }
        public void RenderStyle(string pos = "")
        {
            ReoGridExtentions.RenderStyle(reoGridControl1,
                rbSongNgu.Checked,
                  cbCanChuViet.Text,
                InMaSo.Checked,
                KhoaCung.Checked,
                rbChuViet.Checked,
                rbChuHan.Checked,
               pos,
                cbHideGridLine.Checked,
                ShowPageBreaks.Checked,
               cbfnameCN.Text,
              cbfstyleCN.Text,
              cbfsizeCN.Text,
              cbfnameVN.Text,
              cbfstyleVN.Text,
              cbfsizeVN.Text
            );
        }
        // Token: 0x060000DC RID: 220 RVA: 0x0000E8FA File Offset: 0x0000CAFA
        private void TSMItemAddTinChu_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@tinchu", "Tín chủ");
            var worksheet = reoGridControl1.CurrentWorksheet;
            var Col = worksheet.SelectionRange.Col;
            if (rbSongNgu.Checked)
            {
                worksheet.AutoFitColumnWidth(Col, false);
            }
            ctextMenuS.Close();
        }

        // Token: 0x060000DD RID: 221 RVA: 0x0000E90C File Offset: 0x0000CB0C
        private void TSMItemAddGiaChu_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@giachu", "Gia chủ");
        }
        private void TSMItemAddHoGiaChu_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@hogiachu", "Gia chủ");
        }

        // Token: 0x060000DE RID: 222 RVA: 0x0000E91E File Offset: 0x0000CB1E
        private void TSMItemAddHuongLinh_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@hlinh", "Hương linh");
            var worksheet = reoGridControl1.CurrentWorksheet;
            var Col = worksheet.SelectionRange.Col;
            if (rbSongNgu.Checked)
            {
                worksheet.AutoFitColumnWidth(Col, false);
            }
            ctextMenuS.Close();

        }

        private void TSMItemAddTenHuongLinh_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@hlinhten", "Hương linh");
        }
        private void TSMItemAddHoHuongLinh_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@hlinhho", "Hương linh");
        }

        // Token: 0x060000DF RID: 223 RVA: 0x0000E930 File Offset: 0x0000CB30
        private void TSMItemAddHLinhSinh_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@hlinhsinh", "Hương linh");
        }

        // Token: 0x060000E0 RID: 224 RVA: 0x0000E942 File Offset: 0x0000CB42
        private void TSMItemAddHLinhMat_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@hlinhmat", "Hương linh");
        }

        // Token: 0x060000E1 RID: 225 RVA: 0x0000E954 File Offset: 0x0000CB54
        private void TSMItemAddHLinhTho_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@hlinhtho", "Hưởng thọ");
        }
        private void TSMItemAddHLinhDiaChi_Click(object sender, global::System.EventArgs e)
        {
            ActiveData.UpdateDataByID();
            addTextLongSo("@hlinhdiachi", "Địa chỉ người mất");
        }


        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            if (m_bLayoutCalled == false)
            {
                m_bLayoutCalled = true;
                SplashScreen.CloseForm();
                this.Activate();

            }

            //return;
            pfc.AddFontFile("data/fontCN/CN_KHAI.TTF");
            cbCanChuViet.SelectedItem = "PHẢI";
            addMenuContext();

            loadListFont();

            var worksheet = reoGridControl1.CurrentWorksheet;
            reoGridControl1.SetSettings(WorkbookSettings.View_ShowSheetTabControl, false);

            worksheet.SettingsValue();

            // add listview columns
            dynamicPanel.Location = new Point(MousePosition.X, MousePosition.Y);
            dynamicPanel.Name = "Panel1";
            dynamicPanel.Visible = false;
            dynamicPanel.TabIndex = 9999;
            dynamicPanel.Size = new System.Drawing.Size(400, 200);
            dynamicPanel.BackColor = Color.Gray;

            Controls.Add(dynamicPanel);
            dynamicPanel.BringToFront();
            worksheet.CellEditTextChanging += (s, r1) =>
            {

                var txt = r1.Text;
                loaddd(txt);
            };
            worksheet.BeforeCellEdit += (s, r1) =>
         {

             var cell = r1.Cell.Tag.getCellData();
             if (!String.IsNullOrEmpty(cell.TextVN))
             {
                 r1.EditText = cell.TextVN;
             }
         };

            var luiCN = false;
            reoGridControl1.Undid += (s, r1) =>
            {
                try
                {

                    var row = (SetCellDataAction)r1.Action;
                    var select = new CellPosition() { Row = row.Row, Col = row.Col };
                    var cells = reoGridControl1.CurrentWorksheet.Cells[row.Row, row.Col];
                    cells.DataFormatArgs = cells.Tag;
                    cells.Tag = null;
                    if (luiCN == false && rbSongNgu.Checked)
                    {
                        luiCN = true;
                        reoGridControl1.Undo();
                    };
                   var input=(cells.DataFormatArgs+"").ToListData();
                    for (int i = 0; i < input.Count(); i++)
                    {
                        reoGridControl1.Undo();
                    }
                    luiCN = false;
                    ReoGridExtentions.setColorTag(worksheet, cells, Color.Orange);

                }
                catch
                {
                    worksheet.ScaleFactor += (float)0.001;
                    SaveData();
                }
            };

            reoGridControl1.Redid += (s, r1) =>
            {
                try
                {
                    var row = (SetCellDataAction)r1.Action;
                    var select = new CellPosition() { Row = row.Row, Col = row.Col };
                    var cells = reoGridControl1.CurrentWorksheet.Cells[row.Row, row.Col];

                    reoGridControl1.CurrentWorksheet.Cells[row.Row, row.Col].Tag = cells.DataFormatArgs.getCellData();
                    editting = true;
                    ReoGridExtentions.setColorTag(worksheet, cells, Color.Orange);

                }
                catch (Exception)
                {
                    worksheet.ScaleFactor += (float)0.001;
                    SaveData();
                }
            };


            worksheet.BeforeSelectionRangeChange += (s, r1) =>
            {
                var limitCol = new int[] { 0, reoGridControl1.CurrentWorksheet.UsedRange.EndCol };
                var limitRow = new int[] { 0, reoGridControl1.CurrentWorksheet.UsedRange.EndRow };
                if (limitRow.Contains(r1.StartRow) || limitRow.Contains(r1.EndRow))
                {
                    r1.IsCancelled = true;
                }
                if (limitCol.Contains(r1.StartCol) || limitCol.Contains(r1.EndCol))
                {
                    r1.IsCancelled = true;
                }

                var Row = r1.StartRow;
                var Col = r1.StartCol;
                var cell = worksheet.Cells[Row, Col];
                //if (cell.CheckNo() || cell.DataFormatArgs.CheckNo())
                //{
                //    r1.IsCancelled = true;
                //}

                if (Util.LongSoHienTai.KhoaCung)
                {
                    if (r1.StartRow == reoGridControl1.CurrentWorksheet.UsedRange.EndRow - 1)
                    {
                        var r = MessageBox.Show("Đây là dòng cuối cùng của sớ, thầy có muốn thêm dòng mới không ??", "", MessageBoxButtons.YesNo);
                        if (r == DialogResult.Yes)
                        {
                            var max = Util.LongSoHienTai.LgSo.Values.Max(v => v.Values.Count);
                            foreach (var item in Util.LongSoHienTai.LgSo)
                            {
                                for (int i = 0; i <= max; i++)
                                {
                                    if (!Util.LongSoHienTai.LgSo[item.Key].ContainsKey(i))
                                    {
                                        Util.LongSoHienTai.LgSo[item.Key].Add(i, new CellData());
                                    }

                                }


                            }
                            ReLoad(sender, e);
                            reoGridControl1.CurrentWorksheet.SelectRange(1, 1, 1, 1);
                        }
                    }
                }

                if (cell.Style.BackColor == Color.LightGray)
                {
                    r1.IsCancelled = true;



                }


            };
            worksheet.BeforeCellEdit += (s, r1) =>
            {

                if (r1.Cell != null && r1.Cell.DataFormatArgs.CheckNo())
                {
                    r1.IsCancelled = true;
                    return;
                }
                if (r1.Cell != null && r1.Cell.DataFormatArgs.CheckSkip())
                {
                    r1.IsCancelled = true;
                    return;
                }
                if (rbSongNgu.Checked)
                {
                    if (r1.Cell != null && (String)r1.Cell.DataFormatArgs == "TextCN")
                    {
                        r1.IsCancelled = true;
                        //   MessageBox.Show("Khi ở chế độ song ngữ, vui lòng chỉ sửa chữ việt, chữ hán việt sẽ đi theo chữ việt");
                        return;
                    }
                }
            };

            worksheet.AfterCellEdit += (s, r1) =>
            {

                if (r1.NewData != r1.Cell)
                {
                    if (string.IsNullOrEmpty(r1.NewData + ""))
                    {
                        return;
                    }
                    var cell = r1.Cell.Tag.getCellData();

                    string TextVN = r1.NewData + "";
                    string TextCN = ActiveData.Get(TextVN);

                    if (string.IsNullOrEmpty(TextCN) && dynamicPanel.Controls.Count > 0)
                    {
                        TextVN = dynamicPanel.Controls[0].Tag + "";
                        TextCN = dynamicPanel.Controls[0].Text;
                        if (TextCN == "Thêm mặt chữ")
                        {
                            TextCN = TextVN;
                        }
                    }
                    setText(r1.Cell.Row, r1.Cell.Column, TextVN, TextCN);

                    r1.NewData = r1.Cell.renderViewText();


                }

            };


            worksheet.BeforeSelectionRangeChange += (s, r1) =>
            {
                dynamicPanel.Visible = false;
            };

            worksheet.Scaled += (s, r1) =>
            {
                if (Util.LongSoHienTai.ScaleFactor != worksheet.ScaleFactor)
                {
                    Util.LongSoHienTai.ScaleFactor = worksheet.ScaleFactor;
                    SaveData();
                }

            };


            Task.Run(() =>
            {

                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                var key = CheckKey.LocalKey();
                var date = ActiveData.Get("DateLicence");
                this.Invoke(new Action(() =>
                {
                    lbVersion.Text = " Version:" + version;
                    this.Text += $" Bản quyền {key} sử dụng đến ngày : " + date;
                    labelLicence.Text = $"Bản quyền sử dụng đến ngày : " + date;
                }));

            });
            rbChuHan.Checked = true;

        }
        void loaddd(string txt = "")
        {
            if (txt == "")
            {
                return;
            }
            dynamicPanel.Visible = false;
            dynamicPanel.Location = new Point(MousePosition.X, MousePosition.Y);
            for (int i = 0; i < dynamicPanel.Controls.Count; i++)
            {
                dynamicPanel.Controls.RemoveAt(i);
            }
            dynamicPanel.Controls.Clear();
            txt = txt.Replace(" ", "");
            var oldTxt = txt;
            txt = txt.ToLower();
            if (CNDictionary.database.ContainsKey(txt))
            {

                var cache = ActiveData.Get(txt);
                var input = CNDictionary.database[txt].Distinct().OrderByDescending(v => (v == cache ? 1 : 0));
                int stt = 0;
                foreach (var it in input)
                {

                    Button textBox1 = new Button();
                    textBox1.Location = new Point(10, 10);
                    textBox1.Text = it;
                    var size = it.Length * 50;
                    if (size < 70)
                    {
                        size = 70;
                    }
                    textBox1.Size = new Size(size, 40);
                    textBox1.Click += new EventHandler(DynamicButton_Click);

                    textBox1.BackColor = Color.LightYellow;
                    textBox1.Font = new Font(cbfnameCN.Text, 22);

                    textBox1.Tag = oldTxt;


                    dynamicPanel.Controls.Add(textBox1);
                    stt++;


                }
                if (input.Count() > 20)
                {
                    var line = (int)(input.Count() / 5);
                    line = line + 1;
                    dynamicPanel.Size = new System.Drawing.Size(400, line * 50);
                }
                else
                {
                    dynamicPanel.Size = new System.Drawing.Size(400, 200);
                }

            }

            var btnAddMatChu = new Button();
            btnAddMatChu.Location = new Point(10, 10);
            btnAddMatChu.Text = "Thêm mặt chữ";
            btnAddMatChu.Size = new Size(100, 40);
            // btnAddMatChu.Dock = DockStyle.Fill;
            btnAddMatChu.Tag = oldTxt;

            btnAddMatChu.BackColor = Color.Orange;
            btnAddMatChu.Click += new EventHandler(ThemMatChu_Click);
            dynamicPanel.Controls.Add(btnAddMatChu);
            dynamicPanel.Visible = true;

        }



        public void setText(int Row, int Col, string TextVN = "", string TextCN = "")
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var item = worksheet.Cells[new CellPosition() { Col = Col, Row = Row }];
            TextVN += "";
            var cell = item.Tag.getCellData();
            if (TextVN.Contains("@"))
            {
                cell.TextCN = TextCN.Split('_').FirstOrDefault();
                cell.TextVN = TextCN.Split('_').LastOrDefault();
                cell.Value = TextVN;
            }
            else
            {
                cell.TextCN = TextCN;
                cell.TextVN = TextVN;
            }
            item.Tag = cell;

            SaveData();
            var text = item.renderViewText();
            var action = new SetCellDataAction(item.Row, item.Column, text);
            reoGridControl1.DoAction(reoGridControl1.CurrentWorksheet, action);



            if (TextVN.Contains("@"))
            {
                var cnt = (cell.TextCN + "").Split(' ').Where(v => !string.IsNullOrEmpty(v)).Count();
                if ((worksheet.UsedRange.EndRow - Row - cnt) < 0)
                {
                    var colAdd = cnt / (worksheet.UsedRange.EndRow - Row);
                    worksheet.InsertColumns(Col, colAdd-1);
                    worksheet.ScaleFactor += (float)0.001;
                }

                RenderStyle(item.Address);
            }

            if (rbSongNgu.Checked && item.Style.BackColor != Color.LightBlue)
            {
                var PosText = cbCanChuViet.Text;
                if (PosText == "PHẢI")
                {
                    SetTextSongNgu(worksheet, item, Col - 1, Row);
                }
                if (PosText == "TRÁI")
                {
                    SetTextSongNgu(worksheet, item, Col + 1, Row);
                }
                if (PosText == "TRÊN")
                {
                    SetTextSongNgu(worksheet, item, Col, Row + 1);
                }
                if (PosText == "DƯỚI")
                {
                    SetTextSongNgu(worksheet, item, Col, Row - 1);
                }
            }
        }

        public void SetTextSongNgu(Worksheet worksheet, unvell.ReoGrid.Cell item, int Col, int Row)
        {

            var itemCN = worksheet.Cells[new CellPosition() { Col = Col, Row = Row }];
            itemCN.Tag = item.Tag;
            var TextCN = item.Tag.getCellData().TextCN;
            //        itemCN.Data = TextCN;
            var action = new SetCellDataAction(itemCN.Row, itemCN.Column, TextCN);
            reoGridControl1.DoAction(reoGridControl1.CurrentWorksheet, action);

            //  RenderStyle(itemCN.Address);
            worksheet.AutoFitColumnWidth(itemCN.Column, false);
            worksheet.AutoFitColumnWidth(item.Column, false);
        } 
        
        //public void SetText(Worksheet worksheet, unvell.ReoGrid.Cell item)
        //{
        //    var text = item.renderViewText();

        //    var itemCN = worksheet.Cells[new CellPosition() { Col = Col, Row = Row }];
        //    itemCN.Tag = item.Tag;
        //    var TextCN = item.Tag.getCellData().TextCN;
        //    //        itemCN.Data = TextCN;
        //    var action = new SetCellDataAction(itemCN.Row, itemCN.Column, TextCN);
        //    reoGridControl1.DoAction(reoGridControl1.CurrentWorksheet, action);

        //    //  RenderStyle(itemCN.Address);
        //    worksheet.AutoFitColumnWidth(itemCN.Column, false);
        //    worksheet.AutoFitColumnWidth(item.Column, false);
        //}
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var Row = worksheet.SelectionRange.Row;
            var Col = worksheet.SelectionRange.Col;
            var name = (Button)sender;
            string TextVN = name.Tag.ToString();
            string TextCN = name.Text;
            setText(Row, Col, TextVN, TextCN);
            ActiveData.Update(TextVN, TextCN);
            var item = worksheet.Cells[Row, Col];
            worksheet.StartEdit(Row, Col, item.renderViewText());
            worksheet.EndEdit(EndEditReason.NormalFinish);
            dynamicPanel.Visible = false;
            SaveData();


        }

        private void ThemMatChu_Click(object sender, EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var Row = worksheet.SelectionRange.Row;
            var Col = worksheet.SelectionRange.Col;
            var name = (Button)sender;
            string TextVN = name.Tag.ToString();
            var frmMatChu = new frmThemMatChu(TextVN);
            frmMatChu.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y);
            frmMatChu.ShowDialog();
            var cn = ActiveData.Get(TextVN);
            if (string.IsNullOrEmpty(cn))
            {
                name.Text = cn;
            }
            worksheet.EndEdit(EndEditReason.NormalFinish);
            dynamicPanel.Visible = false;
            SaveData();
        }




        private void reoGridControl1_TextChanged(object sender, EventArgs e)
        {
            dynamicPanel.Location = new Point(MousePosition.X, MousePosition.Y);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ReLoad(sender, e);
            }
            if (rbChuViet.Checked || rbSongNgu.Checked)
            {
                if (Util.LongSoHienTai.KhoaCung)
                {
                    return;
                }
            }

        }



        public void ReLoad(object sender, EventArgs e)
        {

            ShowFontChange();
            Models.LongSo.loadDataLongSo();
            loadSettingFont();
            ReoGridExtentions.ReLoad(reoGridControl1,
              rbSongNgu.Checked,
              cbCanChuViet.Text,
              InMaSo.Checked,
              KhoaCung.Checked,
              rbChuViet.Checked,
              rbChuHan.Checked,
                cbHideGridLine.Checked,
              ShowPageBreaks.Checked,
                cbfnameCN.Text,
              cbfstyleCN.Text,
              cbfsizeCN.Text,
              cbfnameVN.Text,
              cbfstyleVN.Text,
              cbfsizeVN.Text,
              cbHienMauEdit.Checked
              );
        }

        public void ShowFontChange()
        {
            cbfnameCN.Visible = false;
            cbfsizeCN.Visible = false;
            labelCN.Visible = false;
            cbfstyleCN.Visible = false;
            cbfnameVN.Visible = false;
            cbfsizeVN.Visible = false;
            labelVN.Visible = false;
            cbfstyleVN.Visible = false;

            if (rbChuHan.Checked || rbSongNgu.Checked)
            {
                cbfnameCN.Visible = true;
                cbfsizeCN.Visible = true;
                labelCN.Visible = true;
                cbfstyleCN.Visible = true;
            }
            if (rbChuViet.Checked || rbSongNgu.Checked)
            {
                cbfnameVN.Visible = true;
                cbfsizeVN.Visible = true;
                labelVN.Visible = true;
                cbfstyleVN.Visible = true;
            }

            cbCanChuViet.Visible = rbSongNgu.Checked;
            cbfstyleCN.SelectedIndex = 0;


        }


        public void loadSettingFont()
        {
            var Data = Util.LongSoHienTai;
            #region Setting Font
            Data.fsizeCN = Data.fsizeCN == 0 && !string.IsNullOrEmpty(cbfsizeCN.Text) ? float.Parse(cbfsizeCN.Text) : Data.fsizeCN;
            Data.fsizeVN = Data.fsizeVN == 0 && !string.IsNullOrEmpty(cbfsizeVN.Text) ? float.Parse(cbfsizeVN.Text) : Data.fsizeVN;
            Data.fsizeCN = Data.fsizeCN == 0 ? Util.DefaultFontSize : Data.fsizeCN;
            Data.fsizeVN = Data.fsizeVN == 0 ? Util.DefaultFontSize : Data.fsizeVN;

            txtLoaiSo.Text = Util.LongSoHienTai.LSo.TenSo;
            cbfsizeCN.SelectedItem = Data.fsizeCN + "";
            cbfsizeVN.SelectedItem = Data.fsizeVN + "";
            cbfstyleCN.Text = Data.fstyleCN;
            cbfstyleVN.Text = Data.fstyleVN;

            if (string.IsNullOrEmpty(Data.fnameCN + "")) Data.fnameCN = "CN-Khai";
            if (string.IsNullOrEmpty(Data.fnameVN + "")) Data.fnameVN = "Times New Roman";

            cbfnameCN.SelectedItem = Data.fnameCN + "";
            cbfnameVN.SelectedItem = Data.fnameVN + "";
            KhoaCung.Checked = Data.KhoaCung;
            ShowPageBreaks.Checked = Data.KhoaCung;
            #endregion
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SaveData();
            FrmSetupPaper fm = new FrmSetupPaper();
            fm.ShowDialog();
            ReLoad(sender, e);
        }



        private void button7_Click(object sender, EventArgs e)
        {
            SaveData();
            ReLoad(sender, e);

        }



        private void txtLoaiSo_Click(object sender, EventArgs e)
        {

            SaveData();
            FrmDownloadLoaiSo frm = new FrmDownloadLoaiSo();
            frm.ShowDialog();
            ReLoad(sender, e);

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveData();
            frmNgachSo frm = new frmNgachSo();
            frm.ShowDialog();
            RenderStyle();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var frm = new frmTinChu();
            frm.ShowDialog();
            RenderStyle();
            ReoGridExtentions.AddMaSo(reoGridControl1, InMaSo.Checked);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmPersonSelectPrint frmPersonSelectPrint = new FrmPersonSelectPrint();
            if (frmPersonSelectPrint.ShowDialog(this) == DialogResult.OK)
            {
                this.printAll(frmPersonSelectPrint.SelectedSoNos);
            }
        }
        // Token: 0x060000A2 RID: 162 RVA: 0x0000C1C0 File Offset: 0x0000A3C0
        private void printAll(Dictionary<int, Family> soNos)
        {
            if (MessageBox.Show("Có tổng cộng " + soNos.Count.ToString() + " Sớ sẽ được in", "Xác nhận in", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                FrmPrintProcess frmPrintProcess = new FrmPrintProcess(this.reoGridControl1, soNos);
                DialogResult dialogResult = frmPrintProcess.ShowDialog(this);
                if (dialogResult == DialogResult.Cancel)
                {
                    MessageBox.Show("Lệnh in đã bị hủy", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (dialogResult == DialogResult.OK)
                {
                    if (0 < frmPrintProcess.SoNosError.Count)
                    {
                        MessageBox.Show(frmPrintProcess.SoNosError.Count.ToString() + " Sớ bị lỗi" + Environment.NewLine + string.Join<int>(", ", frmPrintProcess.SoNosError.ToArray()), Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    MessageBox.Show("Hoàn thành xong lệnh in", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            var macdinh = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/FileUpload", "*" + ConstData.ExtentionsFile, SearchOption.AllDirectories).Count();
            if (macdinh == 1)
            {
                MessageBox.Show("Không thể xóa lòng sớ cuối cùng !");
                return;
            }
            File.Delete("data/" + Util.LongSoHienTai.LSo.FileName);
            Util.NameLongSoHienTai = null;
            Util.LongSoHienTai = null;
            ReLoad(sender, e);
        }


        private void cbHideGridLine_CheckedChanged(object sender, EventArgs e)
        {
            if (KhoaCung.Checked)
            {
                MessageBox.Show("Lòng sớ KHOA CÚNG không được thay đổi dòng kẻ");

            }
            else
            {
                reoGridControl1.ShowBolder(cbHideGridLine.Checked);
            }
        }

        private void ctextMenuS_Opening(object sender, CancelEventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var select = worksheet.SelectionRange;
            if (rbSongNgu.Checked)
            {
                if (worksheet.Cells[select.Row, select.Col].DataFormatArgs.CheckSkip())
                {
                    e.Cancel = true;
                    return;
                };
            }
        }

        private void reoGridControl1_Click_1(object sender, EventArgs e)
        {
            var position = reoGridControl1.CurrentWorksheet.SelectionRange;
            var cell = reoGridControl1.CurrentWorksheet.Cells[position.Row, position.Col].Tag.getCellData();

            var Tag = cell.Value + "";
            if (Tag.Contains("@"))
            {
                Tag = Tag.ToLower();
                if (frmTinChu.keys.Contains(Tag) || Tag == "@tinchu" || Tag == "@hlinh")
                {
                    var frm = new frmTinChu();
                    frm.ShowDialog();
                    ReLoad(sender, e);
                }
                else
                {
                    showSugget(Tag, Tag);
                    RenderStyle();
                }
            }


        }
        public void showSugget(string key, string t)
        {
            var position = reoGridControl1.CurrentWorksheet.SelectionRange;
            var cell = reoGridControl1.CurrentWorksheet.Cells[position.Row, position.Col];
            Util.strDataSugget = cell.Data + "";

            if (cell.CheckNo() || cell.DataFormatArgs.CheckNo() || cell.DataFormatArgs.CheckSkip())
            {
                return;
            }

            var oldData = Util.strDataSugget;
            if (key == "@ngachso")
            {
                var frm = new frmNgachSo();
                frm.ShowDialog();
            }
            else
            {

                var frm = new frmSugget(key, t);
                frm.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y);

                frm.ShowDialog();

            }
            ActiveData.Update(key, Util.strDataSugget);
            addTextLongSo(key, t);

            //if (Util.strDataSugget == oldData)
            //{
            //    return;
            //}
            //if (string.IsNullOrEmpty(Util.strDataSugget))
            //{
            //    Util.strDataSugget = t;
            //}

            //var item = reoGridControl1.CurrentWorksheet.Cells[position.Row, position.Col];
            //var cell = item.Tag.getCellData();
            //cell.TextCN = Util.strDataSugget;
            //cell.TextVN = key;
            //item.Tag = cell;

            // ActiveData.Update(key, Util.strDataSugget);
            //setText(position.Row, position.Col, cell.TextVN, cell.TextCN);
        }

        public void LogOutput(string input)
        {
            if (richTextBox1.Visible)
            {
                richTextBox1.Text = input + ":" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff") + "\n" + richTextBox1.Text;
            }
        }




        private void cbfsizeCN_Click(object sender, EventArgs e)
        {

        }



        public void SaveData()
        {

            if (reoGridControl1.CurrentWorksheet.UsedRange.Rows <= 1)
            {
                return;
            }
            if (Util.LongSoHienTai == null)
            {
                return;
            }
            editting = false;
            LogOutput("SaveData");



            var LgSo = new Dictionary<int, Dictionary<int, CellData>>();

            var sheet = reoGridControl1.CurrentWorksheet;
            var position = sheet.UsedRange;
            if (position.Cols <= 1)
            {
                return;
            }
            int c = 0;
            for (int i = 1; i < position.Cols - 1; i++)
            {
                var row = new Dictionary<int, CellData>();
                int k = 0;
                for (int j = 1; j < position.Rows - 1; j++)
                {
                    CellData value = new CellData();
                    if (position.EndCol >= i && position.EndRow >= j)
                    {

                        var item = sheet.Cells[j, i];
                        if (item.DataFormatArgs.CheckSkip())
                        {
                            continue;
                        }
                        if (!item.DataFormatArgs.CheckNo())
                        {

                            if (!string.IsNullOrEmpty(item.Data + "") && item.Tag == null)
                            {
                                var newitem = new CellData();

                                if ((item.DataFormatArgs + "") == "TextCN")
                                {
                                    newitem.TextCN = item.Data + "";
                                    newitem.TextVN = CNDictionary.getVN(item.Data + "");
                                }
                                else
                                {
                                    newitem.TextVN = item.Data + "";
                                    newitem.TextCN = CNDictionary.getCN(item.Data + "");
                                }

                                item.Tag = newitem;

                            }

                            var cell = item.Tag.getCellData();

                            value.TextCN = cell.TextCN;
                            value.TextVN = cell.TextVN;
                            value.Value = cell.Value;

                            if (string.IsNullOrEmpty(value.Value + "") && (value.TextVN + "").StartsWith("@"))
                            {
                                value.Value = value.TextVN;
                            }
                            if (string.IsNullOrEmpty(item.Data + "") && !(value.TextVN + "").StartsWith("@"))
                            {
                                value = new CellData();
                            }
                        }
                        else
                        {

                        }
                        row.Add(k, value);
                        k++;

                    }
                }
                if (row.Count > 0)
                {
                    LgSo.Add(c, row);
                    c++;
                }


                Util.LongSoHienTai.LgSo = LgSo;
            }

            float.TryParse(cbfsizeCN.Text, out float fsizeCN);
            float.TryParse(cbfsizeVN.Text, out float fsizeVN);

            if (fsizeCN != 0) Util.LongSoHienTai.fsizeCN = fsizeCN;
            if (fsizeVN != 0) Util.LongSoHienTai.fsizeVN = fsizeVN;

            Util.LongSoHienTai.fnameCN = cbfnameCN.Text;
            Util.LongSoHienTai.fnameVN = cbfnameVN.Text;

            Util.LongSoHienTai.fstyleCN = cbfstyleCN.Text;
            Util.LongSoHienTai.fstyleVN = cbfstyleVN.Text;
            Util.LongSoHienTai.KhoaCung = KhoaCung.Checked;

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Visible = true;
            //richTextBox1.Text = "";
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            frmCreateNew frm = new frmCreateNew();
            frm.ShowDialog();
            ReLoad(sender, e);
        }

        private void labelLicence_Click(object sender, EventArgs e)
        {
            var frm = new frmKeyInfo();
            frm.ShowDialog();
        }

        private void RenderFontSizeChanged(object sender, EventArgs e)
        {

            SaveData();
            RenderStyle();
            ReoGridExtentions.ChangeWidthSize(reoGridControl1.CurrentWorksheet);
        }


        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            ReLoad(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new UploadToServer();
            frm.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

            var sheet = reoGridControl1.CurrentWorksheet;
            ReoGridExtentions.ChangeWidthSize(sheet);

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            //var sheet = reoGridControl1.CurrentWorksheet;
            //ChangeWidthSize(sheet, checkBox2.Checked);
            ReLoad(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            reoGridControl1.Undo();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            reoGridControl1.Redo();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LongSo.saveToFile();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            if (Util.LongSoHienTai.paperSize == null)
            {
                MessageBox.Show("Vui lòng chọn khổ giấy trước khi in ");
                var frm = new FrmSetupPaper();
                frm.ShowDialog();
                ReLoad(sender, e);
                return;
            }
            var sheet = reoGridControl1.CurrentWorksheet;
            sheet.PrintSettings.PaperName = Util.LongSoHienTai.paperSize.PaperName;
            sheet.PrintSettings.PaperWidth = Util.LongSoHienTai.paperSize.Width;
            sheet.PrintSettings.PaperHeight = Util.LongSoHienTai.paperSize.Height;
            ////    sheet.PrintSettings.PageScaling =3f;
            if (KhoaCung.Checked == false)
            {

                sheet.SetRangeBorders(sheet.UsedRange, BorderPositions.All,
                     new unvell.ReoGrid.RangeBorderStyle
                     {
                         Style = BorderLineStyle.None,
                     });

            }
            sheet.SetRangeStyles(sheet.UsedRange, new WorksheetRangeStyle
            {
                // style item flag
                Flag = PlainStyleFlag.BackColor,
                // style item
                BackColor = Color.White,
            });
            int PageNumber = 1;
            if (Util.LongSoHienTai.KhoaCung)
            {
                PageNumber = reoGridControl1.CurrentWorksheet.SelectionRange.Row / Util.LongSoHienTai.PageBreakRow;
                PageNumber = PageNumber + 1;
                if (PageNumber < 1)
                {
                    PageNumber = 1;
                }
                sheet.PrintSettings.Landscape = false;
            }
            FrmPrintPreview frmPrintPreview = new FrmPrintPreview(reoGridControl1.CurrentWorksheet, KhoaCung.Checked, PageNumber);
            frmPrintPreview.ShowDialog(this);

            ReLoad(sender, e);


        }

        private void button11_Click(object sender, EventArgs e)
        {
            var frm = new FrmDanhSach();
            frm.ShowDialog();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ReLoad(sender, e);
        }

        private bool m_bLayoutCalled = false;
        private void Form1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mơLongSơTaiVêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "HC file|*.hc";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var file = new FileInfo(openFileDialog1.FileName);
                string destFileName = Util.getDataPath + "FileUpload/" + DateTime.Now.ToString("ddMM_HHmmss") + file.Name;

                File.Copy(openFileDialog1.FileName, destFileName, true);
                var file2 = new FileInfo(destFileName);

                Util.NameLongSoHienTai = "/FileUpload/" + file2.Name;
                ReLoad(sender, e);
            }
        }

        private void taiBôChưHanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmDownloadFont();
            frm.ShowDialog();
            loadFont.loadListFontCN(true);
            var check = loadFont.CheckFontNoInstall();

            if (check)
            {
                Application.Exit();
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                return;
            }
        }

        private void lâyDưLiêuMơiNhâtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var listfilelocal = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data", "*.config").ToList();
            foreach (var item in listfilelocal)
            {
                File.Delete(item);
            }
            MessageBox.Show("Đã update dữ liệu mới nhất");
        }

        private void reoGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void reoGridControl1_DoubleClick(object sender, EventArgs e)
        {


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            ReoGridExtentions.AddMaSo(reoGridControl1, InMaSo.Checked);

            //      RenderStyle();
        }



        private void xóaCộtKhôngCóNộiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var LgSo = new Dictionary<int, Dictionary<int, CellData>>();

            var sheet = reoGridControl1.CurrentWorksheet;
            var position = sheet.UsedRange;
            if (position.Cols <= 1)
            {
                return;
            }
            var listCol = new List<int>();
            for (int i = 1; i <= position.EndCol - 1; i++)
            {
                var check = false;
                for (int j = 1; j <= position.EndRow - 1; j++)
                {
                    var item = sheet.Cells[j, i];
                    if (!string.IsNullOrEmpty(item.Data + ""))
                    {
                        check = true;
                        break;
                    }


                }
                if (check == false)
                {
                    listCol.Add(i);
                }
            }
            foreach (var item in listCol.OrderByDescending(z => z))
            {
                try
                {

                    sheet.DeleteColumns(item, 1);
                }
                catch (Exception)
                {


                }
            }
            SaveData();

            ReLoad(sender, e);

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            reoGridControl1.CurrentWorksheet.AddKhoaCung(KhoaCung.Checked);
            Util.LongSoHienTai.KhoaCung = KhoaCung.Checked;
            if (KhoaCung.Checked)
            {
                rbSongNgu.Checked = true;
            }
        }

        private void cbHideGridLine_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmCreateNew frm = new frmCreateNew(true);
            frm.ShowDialog();
            ReLoad(sender, e);
        }

        private void cbfnameCN_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void càiĐặtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSettings();
            frm.ShowDialog();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            ReoGridExtentions.AddColorEdit(reoGridControl1, cbHienMauEdit.Checked);


        }
    }
}
