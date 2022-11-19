using AppVietSo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid;
using unvell.ReoGrid.Actions;
using unvell.ReoGrid.Print;

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
        public static void ChangeWidthSize(this Worksheet sheet)
        {
            if (Util.LongSoHienTai.KhoaCung)
            {


                for (int i = 1; i < sheet.RowCount; i++)
                {
                    sheet.RowHeaders[i].IsAutoHeight = true;

                }
                for (int i = 1; i < sheet.ColumnCount; i++)
                {
                    sheet.ColumnHeaders[i].IsAutoWidth = true;

                }

                int TotalWidth = 0;
                for (int i = 1; i < sheet.ColumnCount; i++)
                {
                    var oldW = sheet.GetColumnWidth(i);
                    sheet.AutoFitColumnWidth(i, false);

                    var newW = sheet.GetColumnWidth(i);

                    if (newW < oldW)
                    {
                        newW = oldW;
                        sheet.SetColumnsWidth(i, 1, oldW);

                    }
                    TotalWidth += newW;
                }

                var tile = (float)TotalWidth / (float)Util.LongSoHienTai.PageHeight;
                var TotalHeight = (float)Util.LongSoHienTai.PageWidth * tile;
                int row = Util.LongSoHienTai.PageBreakRow;
                var old = TotalHeight / row;
                sheet.SetRowsHeight(1, sheet.UsedRange.Rows - 1, (ushort)old);


            }
            else
            {
                for (int i = 1; i < sheet.RowCount; i++)
                {
                    sheet.RowHeaders[i].IsAutoHeight = true;

                }
                for (int i = 1; i < sheet.ColumnCount; i++)
                {
                    sheet.ColumnHeaders[i].IsAutoWidth = true;

                }

                int TotalWidth = 0;
                for (int i = 1; i < sheet.ColumnCount; i++)
                {
                    var oldW = sheet.GetColumnWidth(i);
                    sheet.AutoFitColumnWidth(i, false);

                    var newW = sheet.GetColumnWidth(i);

                    if (newW < oldW)
                    {
                        newW = oldW;
                        sheet.SetColumnsWidth(i, 1, oldW);

                    }
                    TotalWidth += newW;
                }

                var tile = (float)TotalWidth / (float)Util.LongSoHienTai.PageWidth;
                var TotalHeight = (float)Util.LongSoHienTai.PageHeight * tile;
                int row = (sheet.UsedRange.EndRow - 1);
                var old = TotalHeight / row;
                sheet.SetRowsHeight(1, row, (ushort)old);

                var free = TotalHeight - (row * (int)old);
                var colend = (ushort)(sheet.GetRowHeight(row) + free);
                sheet.SetRowsHeight(row, 1, colend);

            }
        }
        public static void PreView(this ReoGridControl reoGrid, object sender = null, EventArgs e = null)
        {
            //      LoadDataToDataGrid(reoGrid);

        }
        //   public static void SetOnePage(this Worksheet worksheet)
        //{
        //    worksheet.ResetAllPageBreaks();
        //    var MaxRow = worksheet.RowPageBreaks.Max(v => v);
        //    var MinRow = worksheet.RowPageBreaks.Min(v => v);
        //    foreach (var item in worksheet.RowPageBreaks.ToList())
        //    {
        //        if (item == MaxRow || item == MinRow)
        //        {
        //            continue;
        //        }

        //        if (worksheet.RowPageBreaks.Contains(item))
        //        {
        //            worksheet.ChangeRowPageBreak(item, MaxRow, false);
        //        }
        //    }

        //    var MaxCol = worksheet.ColumnPageBreaks.Max(v => v);
        //    var MinCol = worksheet.ColumnPageBreaks.Min(v => v);
        //    foreach (var item in worksheet.ColumnPageBreaks.ToList())
        //    {
        //        if (item == MaxCol || item == MinCol)
        //        {
        //            continue;
        //        }
        //        if (worksheet.ColumnPageBreaks.Contains(item))
        //        {
        //            worksheet.ChangeColumnPageBreak(item, MaxCol, false);
        //        }
        //    }

        //}

        public static void AddKhoaCung(this Worksheet worksheet_0, bool Checked)
        {
            var cover = new RangePosition(
                    1, 1, worksheet_0.UsedRange.EndRow - 1
                     , worksheet_0.UsedRange.EndCol - 1);
            worksheet_0.SetRangeBorders(cover, BorderPositions.All,
                               new unvell.ReoGrid.RangeBorderStyle
                               {
                                   Style = BorderLineStyle.None,

                               });

            if (Checked)
            {
                for (int i = 1; i < worksheet_0.Columns - 1; i = i + 2)
                {
                    var rangedata = new RangePosition(
                    1, i, worksheet_0.UsedRange.EndRow - 1
                     , 2);
                    worksheet_0.SetRangeBorders(rangedata, BorderPositions.LeftRight,
                                     new unvell.ReoGrid.RangeBorderStyle
                                     {
                                         Style = BorderLineStyle.BoldSolid,
                                         Color = Color.Black
                                     });
                }
                for (int i = 1; i < worksheet_0.Rows; i = i + Util.LongSoHienTai.PageBreakRow)
                {
                    worksheet_0.SetRangeBorders(i, 0, Util.LongSoHienTai.PageBreakRow, worksheet_0.UsedRange.Cols - 1, BorderPositions.TopBottom,
                     new unvell.ReoGrid.RangeBorderStyle
                     {
                         Style = BorderLineStyle.BoldSolid,
                         Color = Color.Black
                     });
                }

                worksheet_0.SetRangeBorders(cover, BorderPositions.TopBottom,
                     new unvell.ReoGrid.RangeBorderStyle
                     {
                         Style = BorderLineStyle.BoldSolid,
                         Color = Color.Black
                     });
            }


        }

        public static float GetTotalWidth(this Worksheet worksheet)
        {
            float TotalWidth = 0;
            for (int i = 0; i <= worksheet.UsedRange.EndCol; i++)
            {
                var height = worksheet.GetColumnWidth(i);
                TotalWidth += height;
            }
            TotalWidth += worksheet.PrintSettings.Margins.Left;
            TotalWidth += worksheet.PrintSettings.Margins.Right;
            return TotalWidth;
        }
        public static float GetTotalHeight(this Worksheet worksheet)
        {
            float TotalWidth = 0;
            for (int i = 0; i <= worksheet.UsedRange.EndRow; i++)
            {
                var height = worksheet.GetRowHeight(i);
                TotalWidth += height;
            }
            TotalWidth += worksheet.PrintSettings.Margins.Top;
            TotalWidth += worksheet.PrintSettings.Margins.Bottom;
            return TotalWidth;
        }

        public static void SetOnePage(this Worksheet worksheet)
        {

            var MaxRow = worksheet.RowPageBreaks.Count > 0 ? worksheet.RowPageBreaks.Max(v => v) : 0;


            worksheet.ResetAllPageBreaks();

            var MaxCol = worksheet.ColumnPageBreaks.Max(v => v);
            var MinCol = worksheet.ColumnPageBreaks.Min(v => v);
            foreach (var item in worksheet.ColumnPageBreaks.ToList())
            {
                if (item == MaxCol || item == MinCol)
                {
                    continue;
                }
                if (worksheet.ColumnPageBreaks.Contains(item))
                {
                    worksheet.ChangeColumnPageBreak(item, MaxCol, false);
                }
            }

            if (Util.LongSoHienTai.KhoaCung)
            {
                var MinRow = worksheet.RowPageBreaks.Min(v => v);
                MaxRow = worksheet.RowPageBreaks.Count > 0 ? worksheet.RowPageBreaks.Max(v => v) : 0;
                foreach (var item in worksheet.RowPageBreaks.ToList())
                {
                    if (item == MaxRow || item == MinRow)
                    {
                        continue;
                    }

                    if (worksheet.RowPageBreaks.Contains(item))
                    {
                        worksheet.ChangeRowPageBreak(item, MaxRow, false);
                    }
                }

                if (Util.LongSoHienTai.PageBreakRow == 0)
                {
                    Util.LongSoHienTai.PageBreakRow = MaxRow;
                }

                var start = 1;
                while (start + Util.LongSoHienTai.PageBreakRow < MaxRow)
                {
                    start = start + Util.LongSoHienTai.PageBreakRow;
                    if (start + 2 > MaxRow)
                    {
                        continue;
                    }
                    worksheet.InsertRowPageBreak(start, true);

                }
            }
            else
            {
                var MinRow = worksheet.RowPageBreaks.Min(v => v);
                MaxRow = worksheet.RowPageBreaks.Count > 0 ? worksheet.RowPageBreaks.Max(v => v) : 0;
                foreach (var item in worksheet.RowPageBreaks.ToList())
                {
                    if (item == MaxRow || item == MinRow)
                    {
                        continue;
                    }

                    if (worksheet.RowPageBreaks.Contains(item))
                    {
                        worksheet.ChangeRowPageBreak(item, MaxRow, false);
                    }
                }

            }



        }
        public static void SetOnePage2(this Worksheet worksheet)
        {
            if (Util.LongSoHienTai.KhoaCung)
            {
                if (worksheet.RowPageBreaks.Count == 0)
                {
                    return;
                }
                var MinRow = worksheet.RowPageBreaks.Min(v => v);
                var MaxRow = worksheet.RowPageBreaks.Count > 0 ? worksheet.RowPageBreaks.Max(v => v) : 0;
                foreach (var item in worksheet.RowPageBreaks.ToList())
                {
                    if (item == MaxRow || item == MinRow)
                    {
                        continue;
                    }

                    if (worksheet.RowPageBreaks.Contains(item))
                    {
                        worksheet.ChangeRowPageBreak(item, MaxRow, false);
                    }
                }

                if (Util.LongSoHienTai.PageBreakRow == 0)
                {
                    Util.LongSoHienTai.PageBreakRow = MaxRow;
                }

                var start = 1;
                while (start + Util.LongSoHienTai.PageBreakRow < MaxRow)
                {
                    start = start + Util.LongSoHienTai.PageBreakRow;
                    if (start + 2 > MaxRow)
                    {
                        continue;
                    }
                    worksheet.InsertRowPageBreak(start, true);

                }

                var hientai = worksheet.GetTotalWidth();

                var KhoGiay = Util.LongSoHienTai.PageHeight - ShareFun.toPaperSize((decimal)Util.LongSoHienTai.PagePaddingRight) - ShareFun.toPaperSize((decimal)Util.LongSoHienTai.PagePaddingLeft);

                var Scaling = KhoGiay / hientai;
                worksheet.PrintSettings.PageScaling = (float)Scaling;

            }
            else
            {
                var hientai = worksheet.GetTotalWidth();
                var tile = hientai / (Util.LongSoHienTai.PageWidth - ShareFun.mmToPixel(Util.LongSoHienTai.PagePaddingLeft) - ShareFun.mmToPixel(Util.LongSoHienTai.PagePaddingRight));
                var height = (Util.LongSoHienTai.PageHeight - ShareFun.mmToPixel(Util.LongSoHienTai.PagePaddingTop) - ShareFun.mmToPixel(Util.LongSoHienTai.PagePaddingBottom)) * tile / (worksheet.UsedRange.Rows - 1);
                worksheet.SetRowsHeight(1, worksheet.UsedRange.Rows - 1, (ushort)(height));



                worksheet.ResetAllPageBreaks();

                var MaxRow = worksheet.UsedRange.Rows;
                var MaxCol = worksheet.UsedRange.Cols;
                var MinCol = worksheet.ColumnPageBreaks.Min(v => v);
                var MinRow = worksheet.RowPageBreaks.Min(v => v);
                foreach (var item in worksheet.ColumnPageBreaks)
                {
                    if (item == MaxCol || item == MinCol)
                    {
                        continue;
                    }
                    if (worksheet.ColumnPageBreaks.Contains(item))
                    {
                        worksheet.ChangeColumnPageBreak(item, MaxCol, false);
                    }
                }

                foreach (var item in worksheet.RowPageBreaks.ToList())
                {
                    if (item == MaxRow || item == MinRow)
                    {
                        continue;
                    }
                    if (worksheet.RowPageBreaks.Contains(item))
                    {
                        worksheet.ChangeRowPageBreak(item, MaxRow, false);
                    }
                }
            }



        }
        public static void SettingsValue(this Worksheet worksheet, object sender = null, EventArgs e = null)
        {
            worksheet.SelectionForwardDirection = SelectionForwardDirection.Down;
            worksheet.SetSettings(WorksheetSettings.View_ShowHeaders, false);
            worksheet.SetSettings(WorksheetSettings.Behavior_MouseWheelToScroll, false);
            worksheet.SetSettings(WorksheetSettings.Behavior_ScrollToFocusCell, false);
            worksheet.SetSettings(WorksheetSettings.Edit_AutoExpandColumnWidth, false);
            worksheet.SetSettings(WorksheetSettings.Edit_AllowAdjustColumnWidth, false);
            worksheet.SetSettings(WorksheetSettings.Edit_AutoExpandRowHeight, false);
            worksheet.SetSettings(WorksheetSettings.Edit_AllowAdjustRowHeight, false);
            worksheet.SetSettings(WorksheetSettings.View_AllowCellTextOverflow, true);
            worksheet.SetSettings(WorksheetSettings.View_ShowGridLine, true);

            worksheet.EnableSettings(WorksheetSettings.View_ShowPageBreaks);
        }

        public static void ReLoad(ReoGridControl reoGrid = null, bool rbSongNgu = false, string cbCanChuViet = null,
            bool InMaSo = false,
            bool KhoaCung = false,
            bool rbChuViet = false,
            bool rbChuHan = false,
             bool cbHideGridLine = false,
            bool ShowPageBreaks = false
            , string cbfnameCN = null,
            string cbfstyleCN = null,
            string cbfsizeCN = null,
            string cbfnameVN = null,
            string cbfstyleVN = null,
            string cbfsizeVN = null,
            bool ColorEdit = false
            )
        {

            var worksheet = reoGrid.CurrentWorksheet;
            // Models.LongSo.loadDataLongSo();
            var Data = Util.LongSoHienTai;
            if (Data == null || Data.LgSo == null || Data.LgSo.Count == 0)
            {
                return;
            }
            worksheet.Reset();
            reoGrid.ClearActionHistory();
            worksheet.PrintSettings.Margins = new PageMargins(0);

            PrinterSettings settings = new PrinterSettings();
            if (Util.LongSoHienTai.paperSize != null)
            {
                var PaperSize = settings.PaperSizes.Cast<System.Drawing.Printing.PaperSize>().ToList().Where(V => V.PaperName == Util.LongSoHienTai.paperSize.PaperName).FirstOrDefault();

                var PageSettings = new System.Drawing.Printing.PageSettings()
                {
                    PaperSize = PaperSize
                };
                worksheet.PrintSettings.ApplySystemPageSettings(PageSettings);
            }

            if (worksheet.UsedRange.EndCol > 0)
            {
                worksheet.DeleteColumns(0, worksheet.UsedRange.EndCol - 1);
                worksheet.DeleteRows(0, worksheet.UsedRange.EndRow - 1);
            }

            #region set chiều dài chiều rộng của ô dữ liệu
            int c = Data.LgSo.Count;
            int r = Data.LgSo.Select(z => z.Value.Count).Max(z => z);
            if (rbSongNgu)
            {
                if (cbCanChuViet == "PHẢI" || cbCanChuViet == "TRÁI")
                {
                    c = c * 2;
                }
                if (cbCanChuViet == "TRÊN" || cbCanChuViet == "DƯỚI")
                {
                    r = r * 2;
                }
            }
            c = c + 2;
            r = r + 2;
            worksheet.SetRowCol(r, c);
            #endregion
            #region Hiển thị dữ liệu
            // hiển thị từng cột


            LoadDataToDataGrid(worksheet, rbSongNgu, cbCanChuViet, rbChuViet, rbChuHan);

            #endregion


            worksheet.ScaleFactor = Util.LongSoHienTai.ScaleFactor;

            RenderStyle(reoGrid,
                rbSongNgu,
                 cbCanChuViet,
             InMaSo,
             KhoaCung,
             rbChuViet,
             rbChuHan,
                "",
             cbHideGridLine,
             ShowPageBreaks,
               cbfnameCN,
               cbfstyleCN,
               cbfsizeCN,
               cbfnameVN,
               cbfstyleVN,
               cbfsizeVN);
            ReoGridExtentions.ChangeWidthSize(worksheet);
            reoGrid.ClearActionHistory();
            reoGrid.ClearActionHistoryForWorksheet(worksheet);
            worksheet.SetOnePage2();
            AddMaSo(reoGrid, InMaSo);
            AddColorEdit(reoGrid, ColorEdit);

            if (KhoaCung)
            {
                reoGrid.CurrentWorksheet.AddKhoaCung(KhoaCung);
            }


        }

        public static void renderText(ReoGridControl reoGrid, string CN, string VN, int i, int j, bool songngu = false, string cbCanChuViet = null)
        {
            var sheet = reoGrid.CurrentWorksheet;
            if (string.IsNullOrEmpty(VN))
            {
                sheet.Cells[i, j].Data = VN;
                return;
            }
            int nextI = 1;
            int nextJ = 1;
            if (songngu)
            {
                if (cbCanChuViet == "PHẢI" || cbCanChuViet == "TRÁI")
                {
                    nextJ = 2;
                }
                if (cbCanChuViet == "TRÊN" || cbCanChuViet == "DƯỚI")
                {
                    nextI = 2;
                }
            }
            var startRow = i;
            var startCol = j;
            var DataFormatArgs = "";
            var cnt = VN.Split(' ').Where(v => !string.IsNullOrEmpty(v)).ToList();
            var cntCN = CN.Split(' ').Where(v => !string.IsNullOrEmpty(v)).ToList();

            for (int k = 0; k < cnt.Count; k++)
            {
                var item = sheet.Ranges[new CellPosition() { Row = i, Col = j }.ToAddress()];

                if (k > 0)
                {

                    // nếu số dòng vượt quá điểm kết thúc
                    if (item.Row >= sheet.UsedRange.EndRow - 1)
                    {
                        item.Row = item.EndRow;
                        // nếu số cột vượt quá điểm bắt đầu
                        if ((item.Col - nextJ) <= sheet.UsedRange.Col)
                        {
                            continue;

                        }
                        else
                        {
                            // số dòng reset lại
                            i = startRow;
                            // số cột reset về dầu
                            j = j - nextJ;
                        }
                    }
                    else
                    {
                        i += nextI;
                    }
                }
                if (j < sheet.UsedRange.Col || i < sheet.UsedRange.Row)
                {
                    continue;
                }
                var row = sheet.Cells[i, j];
                var cell = row.Tag.getCellData();
                cell.TextVN = cnt[k];
                cell.TextCN = CNDictionary.getCN(cell.TextVN);
                row.Tag = cell;


                if (k > 0 && row.DataFormatArgs.CheckSkip() == false)
                {
                    row.DataFormatArgs = "NO_" + DataFormatArgs;
                }
                else
                {
                    DataFormatArgs = row.DataFormatArgs + "";
                }


                if (DataFormatArgs == "TextVN")
                {

                    var text = cell.TextVN;
                    var action = new SetCellDataAction(row.Row, row.Column, text);
                    reoGrid.DoAction(reoGrid.CurrentWorksheet, action);

                }
                else
                {
                    var text = cell.TextCN;
                    var action = new SetCellDataAction(row.Row, row.Column, text);
                    reoGrid.DoAction(reoGrid.CurrentWorksheet, action);
                }
            }
        }




        public static void RenderStyle(ReoGridControl reoGridControl1 = null, bool rbSongNgu = false, string cbCanChuViet = null,
            bool InMaSo = false,
            bool KhoaCung = false,
            bool rbChuViet = false,
            bool rbChuHan = false,
            string pos = "",
            bool cbHideGridLine = false,
            bool ShowPageBreaks = false
            , string cbfnameCN = null,
            string cbfstyleCN = null,
            string cbfsizeCN = null,
            string cbfnameVN = null,
            string cbfstyleVN = null,
            string cbfsizeVN = null
            )
        {
            var sheet = reoGridControl1.CurrentWorksheet;
            var position = sheet.UsedRange;

            //if (rbSongNgu.Checked)
            //{
            //    pos = null;
            //    SaveData();
            //    LoadDataToDataGrid(sheet);
            //}

            if (!string.IsNullOrEmpty(pos))
            {
                position = new RangePosition(pos);

            }

            string Status = "";
            if (rbChuViet) Status = "TextVN";
            if (rbChuHan) Status = "TextCN";
            if (rbSongNgu) Status = "TextSN";

            if (Status != "TextSN")
            {
                ChangeFontAndSize(sheet, Status, position.ToAddress(), cbfnameCN, cbfstyleCN, cbfsizeCN, cbfnameVN, cbfstyleVN, cbfsizeVN);
            }
            if (string.IsNullOrEmpty(pos))
            {
                sheet.DeleteRangeData(position);
            }

            for (int i = position.Row; i <= position.EndRow; i++)
            {
                for (int j = position.Col; j <= position.EndCol; j++)
                {
                    var item = sheet.Cells[i, j];
                    item.IsReadOnly = false;

                    // nếu bắt đầu bằng @ thì bôi màu
                    var cell = item.Tag.getCellData();
                    if ((cell.Value + "").StartsWith("@") && (cell.Value + "") != ("@giachu"))
                    {



                        ActiveData.Get(cell.Value + "", out string CN, out string VN);

                        renderText(reoGridControl1, CN, VN, i, j, rbSongNgu, cbCanChuViet);

                    }
                    else
                    {
                        if (item.DataFormatArgs.CheckNo())
                        {
                            //  item.IsReadOnly = true;
                            continue;
                        }


                        switch (Status)
                        {

                            case "TextVN": item.Data = cell.TextVN; break;
                            case "TextCN": item.Data = cell.TextCN; break;
                            case "TextSN": item.Data = ((item.DataFormatArgs + "") == "TextVN") ? cell.TextVN : cell.TextCN; break;

                        }
                        //switch (Status)
                        //{
                        //    case "TextVN":  renderText(sheet, cell.TextVN, i, j); break;
                        //    case "TextCN":  renderText(sheet, cell.TextCN, i, j); break;
                        //    default:
                        //        break;
                        //}
                    }



                }
            }


            if (Util.LongSoHienTai.PageHeight < Util.LongSoHienTai.PageWidth)
            {
                sheet.PrintSettings.Landscape = true;
            }
            if (Util.LongSoHienTai.KhoaCung)
            {
                sheet.PrintSettings.Landscape = false;
            }
            sheet.SetRangeStyles(position, new WorksheetRangeStyle
            {
                // style item flag
                Flag = PlainStyleFlag.BackColor,
                BackColor = Color.White,
            });
            sheet.SetRangeStyles(position, new WorksheetRangeStyle
            {
                Flag = PlainStyleFlag.HorizontalAlign,
                HAlign = ReoGridHorAlign.Center,
            });
            sheet.SetRangeStyles(position, new WorksheetRangeStyle
            {
                Flag = PlainStyleFlag.Padding,
                Padding = new PaddingValue(0)
            });

            reoGridControl1.ShowBolder(cbHideGridLine);
            if (KhoaCung)
            {
                reoGridControl1.CurrentWorksheet.AddKhoaCung(KhoaCung);
            }

            if (string.IsNullOrEmpty(pos))
            {
                //sheet.SetWidthHeight(sheet.UsedRange.EndRow, sheet.UsedRange.EndCol);
                // ReoGridExtentions.ChangeWidthSize(sheet);
                sheet.SetRangeStyles(sheet.UsedRange.ToAddress(), new WorksheetRangeStyle
                {
                    // style item flag
                    Flag = PlainStyleFlag.BackColor,
                    // style item
                    BackColor = Color.White,
                });

                sheet.SetRangeStyles(sheet.UsedRange.ToAddress(), new WorksheetRangeStyle
                {
                    Flag = PlainStyleFlag.HorizontalAlign,
                    HAlign = ReoGridHorAlign.Center,
                });

                sheet.SetRangeStyles(sheet.UsedRange.ToAddress(), new WorksheetRangeStyle
                {
                    Flag = PlainStyleFlag.VerticalAlign,
                    VAlign = ReoGridVerAlign.Middle,
                });
            }
            for (int i = position.Row; i <= position.EndRow; i++)
            {
                for (int j = position.Col; j <= position.EndCol; j++)
                {
                    var item = sheet.Cells[i, j];
                    var cell = item.Tag.getCellData();
                    if (rbSongNgu)
                        ChangeFontAndSize(sheet, (item.DataFormatArgs + ""), item.Address, cbfnameCN, cbfstyleCN, cbfsizeCN, cbfnameVN, cbfstyleVN, cbfsizeVN);

                    if ((cell.Value + "").StartsWith("@") || (!string.IsNullOrEmpty(item.Data + "") && item.DataFormatArgs.CheckNo()))
                    {
                        if (rbSongNgu && item.DataFormatArgs.CheckSkip())
                        {

                            continue;

                        }
                        setColorTag(sheet, item, Color.Orange);
                    }

                }
            }
            sheet.SetSettings(WorksheetSettings.View_ShowPageBreaks, ShowPageBreaks);

            sheet.SetRangeStyles(sheet.UsedRange, new WorksheetRangeStyle()
            {
                Flag = PlainStyleFlag.Padding,
                Padding = new PaddingValue(0, 0, 0, 0),
            });
        }
        public static void ChangeFontAndSize(Worksheet sheet, string Data, string Address, string cbfnameCN, string cbfstyleCN, string cbfsizeCN, string cbfnameVN, string cbfstyleVN, string cbfsizeVN)
        {

            var FontName = "";
            var Bold = false;
            var Italic = false;
            float FontSize = 16;
            Data = Data.Split('_').LastOrDefault();
            if (Data == "TextCN")
            {
                FontName = cbfnameCN;
                Bold = LongSoData.StringTofstyle(cbfstyleCN) == 1 ? true : false;
                Italic = LongSoData.StringTofstyle(cbfstyleCN) == 2 ? true : false;
                float.TryParse(cbfsizeCN, out FontSize);
            }
            if (Data == "TextVN")
            {

                FontName = cbfnameVN;
                Bold = LongSoData.StringTofstyle(cbfstyleVN) == 1 ? true : false;
                Italic = LongSoData.StringTofstyle(cbfstyleVN) == 2 ? true : false;
                float.TryParse(cbfsizeVN, out FontSize);


            }

            sheet.SetRangeStyles(Address, new unvell.ReoGrid.WorksheetRangeStyle
            {
                Flag = unvell.ReoGrid.PlainStyleFlag.FontStyleBold,
                Bold = Bold,
            });

            sheet.SetRangeStyles(Address, new unvell.ReoGrid.WorksheetRangeStyle
            {
                Flag = unvell.ReoGrid.PlainStyleFlag.FontStyleItalic,
                Italic = Italic,
            });
            sheet.SetRangeStyles(Address, new unvell.ReoGrid.WorksheetRangeStyle
            {
                Flag = unvell.ReoGrid.PlainStyleFlag.FontSize,
                FontSize = FontSize
            });
            sheet.SetRangeStyles(Address, new WorksheetRangeStyle()
            {
                Flag = PlainStyleFlag.FontName,
                FontName = FontName,
            });

        }
        public static void LoadDataToDataGrid(Worksheet worksheet, bool rbSongNgu, string cbCanChuViet, bool rbChuViet, bool rbChuHan)
        {
            var songngu = rbSongNgu;
            var PosText = cbCanChuViet;

            var position = worksheet.UsedRange;
            var LgSo = Util.LongSoHienTai.LgSo;

            var col = 0;
            for (int i = 1; i < position.Cols - 1; i++)
            {

                var row = 0;

                for (int j = 1; j < position.Rows - 1; j++)
                {
                    var item = worksheet.Cells[j, i];
                    if (rbChuViet) item.DataFormatArgs = "TextVN";
                    if (rbChuHan) item.DataFormatArgs = "TextCN";


                    if (LgSo.ContainsKey(col))
                    {
                        if (LgSo[col].ContainsKey(row))
                        {
                            var cell = LgSo[col][row];
                            item.Tag = cell;
                        }
                    }
                    if (rbSongNgu)
                    {

                        switch (PosText)
                        {
                            case "TRÁI":

                                item.DataFormatArgs = "TextVN";
                                worksheet.Cells[j, i + 1].Tag = item.Tag;
                                worksheet.Cells[j, i + 1].DataFormatArgs = "SKIP_TextCN";
                                break;
                            case "PHẢI":
                                item.DataFormatArgs = "SKIP_TextCN";

                                worksheet.Cells[j, i + 1].Tag = item.Tag;
                                worksheet.Cells[j, i + 1].DataFormatArgs = "TextVN";

                                break;
                            case "TRÊN":
                                item.DataFormatArgs = "TextVN";
                                worksheet.Cells[j + 1, i].Tag = item.Tag;
                                worksheet.Cells[j + 1, i].DataFormatArgs = "SKIP_TextCN";
                                break;
                            case "DƯỚI":
                                item.DataFormatArgs = "SKIP_TextCN";
                                worksheet.Cells[j + 1, i].Tag = item.Tag;
                                worksheet.Cells[j + 1, i].DataFormatArgs = "TextVN";
                                break;
                            default:
                                break;
                        }


                        if (PosText == "TRÊN" || PosText == "DƯỚI")
                        {
                            j = j + 1;
                        }
                    }
                    row++;
                }

                if (songngu)
                {
                    if (PosText == "PHẢI" || PosText == "TRÁI")
                    {
                        i = i + 1;
                    }
                }
                col++;

            }
            //foreach (var item in Util.LongSoHienTai.LgSo.OrderBy(z => z.Key))
            //{
            //    // hiển thị từng dòng
            //    foreach (var it in item.Value.OrderBy(z => z.Key))
            //    {
            //        if (!string.IsNullOrEmpty(it.Value.Value + ""))
            //        {
            //            it.Value.TextCN = (it.Value.Value + "").ToLower();
            //            it.Value.TextVN = it.Value.TextCN;
            //        }
            //        var numcol = item.Key + 1;
            //        var numrow = it.Key + 1;
            //        var row2 = 0;
            //        var col2 = 0;
            //        // nếu là song ngữ thì tách cột ra
            //        if (songngu)
            //        {
            //            if (PosText == "PHẢI" || PosText == "TRÁI")
            //            {
            //                numcol = numcol * 2;
            //                col2 = 1;
            //            }
            //            if (PosText == "TRÊN" || PosText == "DƯỚI")
            //            {
            //                numrow = numrow * 2;
            //                row2 = 1;
            //            }
            //        }

            //        if (worksheet.ColumnCount < numcol + 1 || worksheet.RowCount < numrow + 1)
            //        {
            //            continue;
            //        }
            //        var col = new CellPosition() { Col = numcol, Row = numrow };



            //        #region Hiển thị dữ liệu theo hạng mục người dùng chọn
            //        if (rbChuViet)
            //        {
            //            worksheet.Cells[col].DataFormatArgs = "TextVN";
            //            it.Value.cellCN = new CellPos();
            //            it.Value.cellVN = new CellPos() { ColNo = numcol, RowNo = numrow };
            //        }
            //        if (rbChuHan)
            //        {
            //            worksheet.Cells[col].DataFormatArgs = "TextCN";
            //            it.Value.cellVN = new CellPos();
            //            it.Value.cellCN = new CellPos() { ColNo = numcol, RowNo = numrow };
            //        }

            //        if ((it.Value.Value + "").StartsWith("@"))
            //        {
            //            ActiveData.Get(it.Value.Value + "", out string CN, out string VN);
            //            it.Value.TextVN = VN;
            //            it.Value.TextCN = CN;

            //        }
            //        worksheet.Cells[col].Tag = it.Value;

            //        worksheet.Cells[col].DataFormat = unvell.ReoGrid.DataFormat.CellDataFormatFlag.Text;

            //        if (songngu)
            //        {
            //            if (PosText == "TRÁI" || PosText == "TRÊN") worksheet.Cells[col].DataFormatArgs = "SKIP_TextCN";
            //            if (PosText == "PHẢI" || PosText == "DƯỚI") worksheet.Cells[col].DataFormatArgs = "TextVN";

            //            var cell2 = new CellPosition() { Col = numcol - col2, Row = numrow - row2 };

            //            it.Value.cellVN = new CellPos();
            //            it.Value.cellCN = new CellPos() { ColNo = cell2.Col, RowNo = cell2.Row };

            //            worksheet.Cells[cell2].Tag = it.Value;

            //            if (PosText == "TRÁI" || PosText == "TRÊN") worksheet.Cells[cell2].DataFormatArgs = "TextVN";
            //            if (PosText == "PHẢI" || PosText == "DƯỚI") worksheet.Cells[cell2].DataFormatArgs = "SKIP_TextCN";
            //        }
            //        #endregion

            //    }
            //}
        }
        public static void setColorTag(Worksheet sheet, unvell.ReoGrid.Cell item, Color color)
        {
            if (color == null)
            {
                color = Color.Orange;
            }

            var cell = item.Tag.getCellData();

            if ((cell.Value + "").StartsWith("@") || item.DataFormatArgs.CheckNo() || color != Color.Orange)
            {
                sheet.SetRangeStyles(item.Address, new WorksheetRangeStyle
                {
                    // style item flag
                    Flag = PlainStyleFlag.BackColor,
                    // style item
                    BackColor = color,
                });
            }
            else
            {
                sheet.SetRangeStyles(item.Address, new WorksheetRangeStyle
                {
                    // style item flag
                    Flag = PlainStyleFlag.BackColor,
                    // style item
                    BackColor = Color.White,
                });
            }
        }

        public static void setColorTag(Worksheet sheet, RangePosition rangePosition, Color color)
        {

            if (color == null)
            {
                color = Color.Orange;
            }

            sheet.SetRangeStyles(rangePosition, new WorksheetRangeStyle
            {
                // style item flag
                Flag = PlainStyleFlag.BackColor,
                // style item
                BackColor = color,
            });

        }


        public static void AddMaSo(ReoGridControl reoGridControl1 = null, bool input = false)
        {
            if (Util.LongSoHienTai.KhoaCung)
            {
                foreach (var item in reoGridControl1.CurrentWorksheet.RowPageBreaks.ToList())
                {
                    var row = (int)((item / Util.LongSoHienTai.PageBreakRow)) * 8;
                    if (reoGridControl1.CurrentWorksheet.Rows <= row)
                    {
                        continue;
                    }
                    var col = reoGridControl1.CurrentWorksheet.UsedRange.EndCol;

                    if (row != 0)
                    {
                        for (int i = 1; i < reoGridControl1.CurrentWorksheet.UsedRange.EndCol - 1; i++)
                        {


                            var celli = reoGridControl1.CurrentWorksheet.Cells[row, i];
                            setColorTag(reoGridControl1.CurrentWorksheet, celli, Color.LightGray);
                            celli.Data = "";

                        }
                        var cell = reoGridControl1.CurrentWorksheet.Cells[row, col - 1];
                        setColorTag(reoGridControl1.CurrentWorksheet, cell, Color.LightBlue);
                    }
                }

            }
            else
            {

                var sheet = reoGridControl1.CurrentWorksheet;
                var cell = sheet.Cells[sheet.UsedRange.EndRow - 1, sheet.UsedRange.EndCol - 1];
                if (input)
                {
                    cell.Data = ActiveData.Get("@maso");
                }
                else
                {
                    cell.Data = null;
                }
            }
        }
        public static void AddColorEdit(ReoGridControl reoGridControl1 = null, bool input = false)
        {
            var sheet = reoGridControl1.CurrentWorksheet;
            var position = sheet.UsedRange;
            if (position.Cols <= 1)
            {
                return;
            }
            for (int i = 1; i < position.Cols - 1; i++)
            {
                for (int j = 1; j < position.Rows - 1; j++)
                {
                    if (position.EndCol >= i && position.EndRow >= j)
                    {

                        var item = sheet.Cells[j, i];
                        var cell = item.Tag.getCellData();
                        if ((cell.Value + "").StartsWith("@") || item.CheckNo() || item.DataFormatArgs.CheckSkip() || item.DataFormatArgs.CheckSkip() || item.DataFormatArgs.CheckNo())
                        {
                            continue;
                        }
                        if (input)
                        {
                            ReoGridExtentions.setColorTag(sheet, item, Color.LightSteelBlue);

                        }
                        else
                        {
                            ReoGridExtentions.setColorTag(sheet, item, Color.White);

                        }

                    }
                }
            }
        }
    }
}
