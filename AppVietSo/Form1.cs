using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using unvell.ReoGrid;
using unvell.ReoGrid.CellTypes;
using unvell.ReoGrid.Print;

namespace AppVietSo
{
    public partial class Form1 : Form
    {
        bool loading = false;
        public Form1()
        {
            InitializeComponent();
        }


        PrivateFontCollection pfc = new PrivateFontCollection();
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




        FlowLayoutPanel dynamicPanel = new FlowLayoutPanel();
        public void addMenuContext()
        {
            var TSMItemPaste = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddRow = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddCol = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemDelRow = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemDelCol = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemDelCel = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemThemChuSauTinChu = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddMua = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddYear = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddMonth = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddDay = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddNoiC = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddAdress = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddGiaChu = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddTinChu = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddHuongLinh = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddHLinhSinh = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddHLinhMat = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddHLinhTho = new global::System.Windows.Forms.ToolStripMenuItem();
            var TSMItemAddNgachSo = new global::System.Windows.Forms.ToolStripMenuItem();

            ctextMenuS.ImageScalingSize = new global::System.Drawing.Size(0x14, 0x14);
            ctextMenuS.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
             {
              TSMItemPaste,
              TSMItemAddRow,
              TSMItemAddCol,
              TSMItemDelRow,
              TSMItemDelCol,
              TSMItemDelCel,
           //   TSMItemThemChuSauTinChu,
              TSMItemAddMua,
              TSMItemAddYear,
              TSMItemAddMonth,
              TSMItemAddDay,
              TSMItemAddNoiC,
              TSMItemAddAdress,
              TSMItemAddGiaChu,
              TSMItemAddTinChu,
              TSMItemAddHuongLinh,
              TSMItemAddHLinhSinh,
              TSMItemAddHLinhMat,
              TSMItemAddHLinhTho,
              TSMItemAddNgachSo
             });

            ctextMenuS.Name = "ctextMenuS";
            ctextMenuS.Size = new global::System.Drawing.Size(0x135, 0x20C);
            TSMItemPaste.Image = global::AppVietSo.Properties.Resources.Paste;
            TSMItemPaste.Name = "TSMItemPaste";
            TSMItemPaste.ShortcutKeys = (global::System.Windows.Forms.Keys)0x20056;
            TSMItemPaste.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemPaste.Text = "Dán";
            TSMItemPaste.Click += TSMItemPaste_Click;
            TSMItemAddRow.Image = global::AppVietSo.Properties.Resources.Add1;
            TSMItemAddRow.Name = "TSMItemAddRow";
            TSMItemAddRow.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddRow.Text = "Thêm dòng";
            TSMItemAddRow.Click += TSMItemAddRow_Click;
            TSMItemAddCol.Image = global::AppVietSo.Properties.Resources.Add1;
            TSMItemAddCol.Name = "TSMItemAddCol";
            TSMItemAddCol.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddCol.Text = "Thêm cột";
            TSMItemAddCol.Click += TSMItemAddCol_Click;
            TSMItemDelRow.Image = global::AppVietSo.Properties.Resources.Delete;
            TSMItemDelRow.Name = "TSMItemDelRow";
            TSMItemDelRow.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemDelRow.Text = "Xóa dòng";
            TSMItemDelRow.Click += TSMItemDelRow_Click;
            TSMItemDelCol.Image = global::AppVietSo.Properties.Resources.Delete;
            TSMItemDelCol.Name = "TSMItemDelCol";
            TSMItemDelCol.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemDelCol.Text = "Xóa cột";
            TSMItemDelCol.Click += TSMItemDelCol_Click;
            TSMItemDelCel.ShortcutKeys = Keys.Delete;
            TSMItemDelCel.Image = global::AppVietSo.Properties.Resources.Delete;
            TSMItemDelCel.Name = "TSMItemDelCel";
            TSMItemDelCel.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemDelCel.Text = "Xóa ô";
            TSMItemDelCel.Click += TSMItemDelCel_Click;
            //  TSMItemThemChuSauTinChu.Image = global::AppVietSo.Properties.Resources.edit;
            //TSMItemThemChuSauTinChu.Name = "TSMItemThemChuSauTinChu";
            //TSMItemThemChuSauTinChu.Size = new global::System.Drawing.Size(0x134, 0x1A);
            //TSMItemThemChuSauTinChu.Text = "Khuôn mẫu Tín chủ";
            //TSMItemThemChuSauTinChu.Click += TSMItemThemChuSauTinChu_Click;
            TSMItemAddMua.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddMua.Name = "TSMItemAddMua";
            TSMItemAddMua.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddMua.Text = "Thêm mùa (@mua)";
            TSMItemAddMua.Click += TSMItemAddMua_Click;
            TSMItemAddYear.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddYear.Name = "TSMItemAddYear";
            TSMItemAddYear.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddYear.Text = "Thêm năm (@nam)";
            TSMItemAddYear.Click += TSMItemAddYear_Click;
            TSMItemAddMonth.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddMonth.Name = "TSMItemAddMonth";
            TSMItemAddMonth.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddMonth.Text = "Thêm tháng (@thang)";
            TSMItemAddMonth.Click += TSMItemAddMonth_Click;
            TSMItemAddDay.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddDay.Name = "TSMItemAddDay";
            TSMItemAddDay.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddDay.Text = "Thêm ngày (@ngay)";
            TSMItemAddDay.Click += TSMItemAddDay_Click;
            TSMItemAddNoiC.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddNoiC.Name = "TSMItemAddNoiC";
            TSMItemAddNoiC.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddNoiC.Text = "Thêm nơi cúng(@noicung)";
            TSMItemAddNoiC.Click += TSMItemAddNoiC_Click;
            TSMItemAddAdress.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddAdress.Name = "TSMItemAddAdress";
            TSMItemAddAdress.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddAdress.Text = "Thêm địa chỉ (@diachiyvu)";
            TSMItemAddAdress.Click += TSMItemAddAdress_Click;
            TSMItemAddGiaChu.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddGiaChu.Name = "TSMItemAddGiaChu";
            TSMItemAddGiaChu.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddGiaChu.Text = "Thêm gia chủ (@giachu)";
            TSMItemAddGiaChu.Click += TSMItemAddGiaChu_Click;
            TSMItemAddTinChu.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddTinChu.Name = "TSMItemAddTinChu";
            TSMItemAddTinChu.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddTinChu.Text = "Thêm tín chủ (@tinchu)";
            TSMItemAddTinChu.Click += TSMItemAddTinChu_Click;
            TSMItemAddHuongLinh.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddHuongLinh.Name = "TSMItemAddHuongLinh";
            TSMItemAddHuongLinh.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddHuongLinh.Text = "Thêm Tên Hương linh (@hlinhten)";
            TSMItemAddHuongLinh.Click += TSMItemAddHuongLinh_Click;
            TSMItemAddHLinhSinh.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddHLinhSinh.Name = "TSMItemAddHLinhSinh";
            TSMItemAddHLinhSinh.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddHLinhSinh.Text = "Hương linh Năm sinh (@hlinhsinh)";
            TSMItemAddHLinhSinh.Click += TSMItemAddHLinhSinh_Click;
            TSMItemAddHLinhMat.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddHLinhMat.Name = "TSMItemAddHLinhMat";
            TSMItemAddHLinhMat.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddHLinhMat.Text = "Hương linh Năm mất (@hlinhmat)";
            TSMItemAddHLinhMat.Click += TSMItemAddHLinhMat_Click;
            TSMItemAddHLinhTho.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddHLinhTho.Name = "TSMItemAddHLinhTho";
            TSMItemAddHLinhTho.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddHLinhTho.Text = "Hương linh Hưởng thọ (@hlinhtho)";
            TSMItemAddHLinhTho.Click += TSMItemAddHLinhTho_Click;
            TSMItemAddNgachSo.Image = global::AppVietSo.Properties.Resources.Adda;
            TSMItemAddNgachSo.Name = "TSMItemAddNgachSo";
            TSMItemAddNgachSo.Size = new global::System.Drawing.Size(0x134, 0x1A);
            TSMItemAddNgachSo.Text = "Thêm ngạch sớ (@ngachso)";
            TSMItemAddNgachSo.Click += TSMItemAddNgachSo_Click;
        }

        // Token: 0x060000CE RID: 206 RVA: 0x0000E604 File Offset: 0x0000C804
        private void TSMItemThemChuSauTinChu_Click(object sender, global::System.EventArgs e)
        {

        }

        // Token: 0x060000CF RID: 207 RVA: 0x0000E688 File Offset: 0x0000C888
        private void TSMItemPaste_Click(object sender, global::System.EventArgs e)
        {
            var text = Clipboard.GetText();

            var input = text.Split('\n');
            var worksheet = reoGridControl1.CurrentWorksheet;
            var select = worksheet.SelectionRange;
            int Col = worksheet.UsedRange.EndCol;
            int Row = worksheet.UsedRange.EndRow;
            for (int i = 1; i < input.Length - 1; i++)
            {
                var row = input[i].Split('\t');
                for (int j = 1; j < row.Length - 1; j++)
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
                    item.Data = row[j];


                    var cell = item.Tag.getCellData();



                    if ((string)item.DataFormatArgs == "TextVN")
                    {
                        cell.TextVN = row[j];
                        cell.TextCN = CNDictionary.getCN(row[j]);
                    }
                    else
                    {
                        cell.TextCN = row[j];
                        cell.TextVN = CNDictionary.getVN(row[j]);
                    }
                    item.Tag = cell;


                }
            }
            //for (int i = select.Row; i <= select.EndRow; i++)
            //{
            //    for (int j = select.Col; j <= select.EndCol; j++)
            //    {
            //        worksheet.Cells[i, j].Data = text;

            //    }
            //}
            SaveData();
        }

        // Token: 0x060000D0 RID: 208 RVA: 0x0000E6B4 File Offset: 0x0000C8B4
        private void TSMItemAddRow_Click(object sender, global::System.EventArgs e)
        {

            var worksheet = reoGridControl1.CurrentWorksheet;
            var cnt = worksheet.SelectionRange.Row;
            worksheet.InsertRows(cnt, 1);
            reoGridControl1.ShowBolder(false);
            SaveData();
            ReLoad(sender, e);
        }

        // Token: 0x060000D1 RID: 209 RVA: 0x0000E710 File Offset: 0x0000C910
        private void TSMItemAddCol_Click(object sender, global::System.EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var cnt = worksheet.SelectionRange.Col;
            worksheet.InsertColumns(cnt, 1);
            reoGridControl1.ShowBolder(false);
            SaveData();
            ReLoad(sender, e);
        }

        // Token: 0x060000D2 RID: 210 RVA: 0x0000E76C File Offset: 0x0000C96C
        private void TSMItemDelRow_Click(object sender, global::System.EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var cnt = worksheet.SelectionRange.Row;
            worksheet.DeleteRows(cnt, 1);
            SaveData();
            ReLoad(sender, e);
        }

        // Token: 0x060000D3 RID: 211 RVA: 0x0000E7C8 File Offset: 0x0000C9C8
        private void TSMItemDelCol_Click(object sender, global::System.EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var cnt = worksheet.SelectionRange.Col;
            worksheet.DeleteColumns(cnt, 1);
            SaveData();
            ReLoad(sender, e);
        }

        // Token: 0x060000D4 RID: 212 RVA: 0x0000E824 File Offset: 0x0000CA24
        private void TSMItemDelCel_Click(object sender, global::System.EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var select = worksheet.SelectionRange;
            for (int i = select.Row; i <= select.EndRow; i++)
            {
                for (int j = select.Col; j <= select.EndCol; j++)
                {
                    worksheet.Cells[i, j].Data = "";
                    worksheet.Cells[i, j].Tag = new CellData();
                }
            }
            SaveData();
        }
        private void addTextLongSo(string bm, string t)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var Row = worksheet.SelectionRange.Row;
            var Col = worksheet.SelectionRange.Col;

            var selection = worksheet.Cells[Row, Col].DataFormatArgs + "";
            if (selection == "NO" || Row == 0 || Col == 0)
            {
                return;
            }
            if (bm.StartsWith("@"))
            {
                var val = ActiveData.Get(bm, out string CN, out string VN);
                if (!val)
                {
                    if (frmTinChu.keys.Contains(bm))
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
            RenderStyle();
        }

        // Token: 0x060000D5 RID: 213 RVA: 0x0000E87C File Offset: 0x0000CA7C
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

        // Token: 0x060000D9 RID: 217 RVA: 0x0000E8C4 File Offset: 0x0000CAC4
        private void TSMItemAddNoiC_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@noicung", "Nơi cúng");
        }

        // Token: 0x060000DA RID: 218 RVA: 0x0000E8D6 File Offset: 0x0000CAD6
        private void TSMItemAddAdress_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@diachiyvu", "Địa chỉ");
        }

        // Token: 0x060000DB RID: 219 RVA: 0x0000E8E8 File Offset: 0x0000CAE8
        private void TSMItemAddNgachSo_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@ngachso", "Ngạch sớ");
        }

        // Token: 0x060000DC RID: 220 RVA: 0x0000E8FA File Offset: 0x0000CAFA
        private void TSMItemAddTinChu_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@tinchu", "Tín chủ");
        }

        // Token: 0x060000DD RID: 221 RVA: 0x0000E90C File Offset: 0x0000CB0C
        private void TSMItemAddGiaChu_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@giachu", "Gia chủ");
        }

        // Token: 0x060000DE RID: 222 RVA: 0x0000E91E File Offset: 0x0000CB1E
        private void TSMItemAddHuongLinh_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@hlinhten", "Hương linh");
        }

        // Token: 0x060000DF RID: 223 RVA: 0x0000E930 File Offset: 0x0000CB30
        private void TSMItemAddHLinhSinh_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@hlinhsinh", "Hương linh");
        }

        // Token: 0x060000E0 RID: 224 RVA: 0x0000E942 File Offset: 0x0000CB42
        private void TSMItemAddHLinhMat_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@hlinhmat", "Hương linh");
        }

        // Token: 0x060000E1 RID: 225 RVA: 0x0000E954 File Offset: 0x0000CB54
        private void TSMItemAddHLinhTho_Click(object sender, global::System.EventArgs e)
        {
            addTextLongSo("@hlinhtho", "Hưởng thọ");
        }


        private void Client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            // Check e.Error for errors
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            cbCanChuViet.SelectedItem = "RIGHT";
            addMenuContext();

            loadListFont();

            var worksheet = reoGridControl1.CurrentWorksheet;
            //worksheet.SetRangeBorders(worksheet.PrintableRange, BorderPositions.All, RangeBorderStyle.SilverSolid);
            worksheet.SetSettings(WorksheetSettings.View_ShowHeaders, false);
            worksheet.DisableSettings(unvell.ReoGrid.WorksheetSettings.Behavior_MouseWheelToScroll);
            worksheet.DisableSettings(unvell.ReoGrid.WorksheetSettings.Behavior_ScrollToFocusCell);
            worksheet.EnableSettings(WorksheetSettings.View_ShowPageBreaks);

            // add listview columns
            dynamicPanel.Location = new Point(MousePosition.X, MousePosition.Y);
            dynamicPanel.Name = "Panel1";
            dynamicPanel.Visible = false;
            dynamicPanel.TabIndex = 9999;
            dynamicPanel.Size = new System.Drawing.Size(400, 200);
            dynamicPanel.BackColor = Color.LightBlue;

            Controls.Add(dynamicPanel);
            dynamicPanel.BringToFront();
            worksheet.CellEditTextChanging += (s, r1) =>
            {
                var txt = r1.Text;
                loaddd(txt);
            };

            worksheet.BeforeSelectionRangeChange += (s, r1) =>
            {
                var limit = new int[] { 0, worksheet.UsedRange.EndRow, worksheet.UsedRange.EndCol };
                if (limit.Contains(r1.StartRow) || limit.Contains(r1.EndRow) || limit.Contains(r1.StartCol) || limit.Contains(r1.EndCol))
                {
                    r1.IsCancelled = true;
                }
            };
            worksheet.BeforeCellEdit += (s, r1) =>
            {

                if (r1.Cell != null && (String)r1.Cell.DataFormatArgs == "NO")
                {
                    r1.IsCancelled = true;
                    return;
                }
                if (rbSongNgu.Checked)
                {
                    if (r1.Cell != null && (String)r1.Cell.DataFormatArgs == "TextCN")
                    {
                        r1.IsCancelled = true;
                        MessageBox.Show("Khi ở chế độ song ngữ, vui lòng chỉ sửa chữ việt, chữ hán việt sẽ đi theo chữ việt");
                        return;
                    }
                }
            };

            worksheet.AfterCellEdit += (s, r1) =>
            {
                if (r1.NewData != r1.Cell)
                {
                    var cell = r1.Cell.Tag.getCellData();
                    if ((string)r1.NewData == (string)cell.TextVN || (string)r1.NewData == (string)cell.TextCN)
                    {
                        return;
                    }
                    string TextVN = r1.NewData + "";
                    string TextCN = r1.NewData + "";
                    if (dynamicPanel.Controls.Count > 0)
                    {
                        TextVN = dynamicPanel.Controls[0].Tag + "";
                        TextCN = dynamicPanel.Controls[0].Text;
                    }
                    setText(r1.Cell.Row, r1.Cell.Column, TextVN, TextCN);
                    if ((string)r1.Cell.DataFormatArgs == "TextCN")
                    {
                        r1.NewData = TextCN;
                    }
                    else
                    {
                        r1.NewData = TextVN;
                    }


                }
            };


            worksheet.BeforeSelectionRangeChange += (s, r1) =>
            {
                dynamicPanel.Visible = false;
            };

            worksheet.Scaled += (s, r1) =>
            {
                Util.LongSoHienTai.ScaleFactor = worksheet.ScaleFactor;
                SaveData();
            };

            rbChuHan.Checked = true;

            loading = true;
            Task.Run(() =>
            {

                var key = CheckKey.LocalKey();
                var date = CheckKey.infoKey(key).ToString("dd/MM/yyyy");
                this.Invoke(new Action(() =>
                {
                    this.Text += $" Bản quyền {key} sử dụng đến ngày : " + date;
                    labelLicence.Text = $"Bản quyền sử dụng đến ngày : " + date;
                }));

            });
            //    ReLoad(sender, e);
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

            var input = CNDictionary.database.Where(z => txt != "" && z.Key.ToLower().StartsWith(txt.ToLower())).OrderBy(v => v.Key.Length).ToList();

            int stt = 0;
            foreach (var it in input)
            {
                if (stt > 10)
                {
                    break;
                }


                Button textBox1 = new Button();
                textBox1.Location = new Point(10, 10);
                textBox1.Text = it.Value;
                var size = it.Value.Length * 50;
                if (size < 70)
                {
                    size = 70;
                }
                textBox1.Size = new Size(size, 40);
                textBox1.Click += new EventHandler(DynamicButton_Click);

                textBox1.Font = new Font(cbfnameCN.Text, 16);

                textBox1.Tag = txt;


                dynamicPanel.Controls.Add(textBox1);
                stt++;

            }
            dynamicPanel.Visible = true;

        }
        public void setText(int Row, int Col, string TextVN, string TextCN = "")
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            //Util.LongSoHienTai.LgSo[Col][Row].TextVN = TextVN;
            //Util.LongSoHienTai.LgSo[Col][Row].TextCN = TextCN;
            //LongSoData.save(Util.LongSoHienTai);
            var item = worksheet.Cells[new CellPosition() { Col = Col, Row = Row }];
            item.EndEdit();

            var cell = (CellData)item.Tag;
            cell.TextCN = TextCN;
            cell.TextVN = TextVN;
            item.Tag = cell;

            RenderStyle();
        }
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var Row = worksheet.SelectionRange.Row;
            var Col = worksheet.SelectionRange.Col;
            var name = (Button)sender;
            setText(Row, Col, name.Tag.ToString(), name.Text);


            dynamicPanel.Visible = false;


        }




        private void reoGridControl1_TextChanged(object sender, EventArgs e)
        {
            dynamicPanel.Location = new Point(MousePosition.X, MousePosition.Y);

        }

        private void reoGridControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //   RenderStyle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ReLoad(sender, e);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

            FrmDownloadLoaiSo frm = new FrmDownloadLoaiSo();
            frm.ShowDialog();
            // ReLoad(sender, e);
        }
        public void ReLoad(object sender, EventArgs e)
        {
            Models.LongSo.loadDataLongSo();
            loadSettingFont();
            var Data = Util.LongSoHienTai;
            if (Data == null || Data.LgSo == null || Data.LgSo.Count == 0)
            {
                return;
            }

            var worksheet = reoGridControl1.CurrentWorksheet;
            worksheet.Reset();

            #region set chiều dài chiều rộng của ô dữ liệu
            int c = Data.LgSo.Count;
            int r = Data.LgSo.Select(z => z.Value.Count).Max(z => z);
            if (rbSongNgu.Checked)
            {
                if (cbCanChuViet.Text == "RIGHT" || cbCanChuViet.Text == "LEFT")
                {
                    c = c * 2;
                }
                if (cbCanChuViet.Text == "TOP" || cbCanChuViet.Text == "BOTTOM")
                {
                    r = r * 2;
                }
                c = c + 1;
            }
            c = c + 2;
            r = r + 2;

            ShowFontChange();
            worksheet.SetWidthHeight(r, c);
            #endregion
            #region Hiển thị dữ liệu
            // hiển thị từng cột


            LoadDataToDataGrid(worksheet);

            #endregion


            worksheet.ScaleFactor = Util.LongSoHienTai.ScaleFactor;
            RenderStyle();

        }
        public void LoadDataToDataGrid(Worksheet worksheet)
        {
            foreach (var item in Util.LongSoHienTai.LgSo.OrderBy(z => z.Key))
            {
                // hiển thị từng dòng
                foreach (var it in item.Value.OrderBy(z => z.Key))
                {
                    if (!string.IsNullOrEmpty(it.Value.Value + ""))
                    {
                        it.Value.TextCN = (it.Value.Value + "").ToLower();
                        it.Value.TextVN = it.Value.TextCN;
                    }
                    var numcol = item.Key + 1;
                    var numrow = it.Key + 1;
                    var row2 = 0;
                    var col2 = 0;
                    // nếu là song ngữ thì tách cột ra
                    if (rbSongNgu.Checked)
                    {
                        if (cbCanChuViet.Text == "RIGHT" || cbCanChuViet.Text == "LEFT")
                        {
                            numcol = numcol * 2 + 1;
                            col2 = 1;
                        }
                        if (cbCanChuViet.Text == "TOP" || cbCanChuViet.Text == "BOTTOM")
                        {
                            numrow = numrow * 2 + 1;
                            row2 = 1;
                        }
                    }

                    if (worksheet.ColumnCount < numcol + 1 || worksheet.RowCount < numrow + 1)
                    {
                        continue;
                    }
                    var col = new CellPosition() { Col = numcol, Row = numrow };

                    worksheet.Cells[col].Tag = it.Value;

                    worksheet.Cells[col].DataFormat = unvell.ReoGrid.DataFormat.CellDataFormatFlag.Text;

                    #region Hiển thị dữ liệu theo hạng mục người dùng chọn
                    if (rbChuViet.Checked)
                    {
                        worksheet.Cells[col].DataFormatArgs = "TextVN";
                    }
                    if (rbChuHan.Checked)
                    {
                        worksheet.Cells[col].DataFormatArgs = "TextCN";
                    }
                    if (rbSongNgu.Checked)
                    {
                        if (cbCanChuViet.Text == "LEFT" || cbCanChuViet.Text == "TOP") worksheet.Cells[col].DataFormatArgs = "TextCN";
                        if (cbCanChuViet.Text == "RIGHT" || cbCanChuViet.Text == "BOTTOM") worksheet.Cells[col].DataFormatArgs = "TextVN";



                        //   if (numcol == 0) continue;

                        var cell2 = new CellPosition() { Col = numcol - col2, Row = numrow - row2 };

                        worksheet.Cells[cell2].Tag = it.Value;

                        if (cbCanChuViet.Text == "LEFT" || cbCanChuViet.Text == "TOP") worksheet.Cells[cell2].DataFormatArgs = "TextVN";
                        if (cbCanChuViet.Text == "RIGHT" || cbCanChuViet.Text == "BOTTOM") worksheet.Cells[cell2].DataFormatArgs = "TextCN";

                    }
                    #endregion

                }
            }
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
            lbCanChuViet.Visible = rbSongNgu.Checked;


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
            #endregion
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FrmSetupPaper fm = new FrmSetupPaper();
            fm.ShowDialog();
            ReLoad(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang trong quá trình hoàn thiện, xin vui lòng chờ tại bản demo lần sau");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ReLoad(sender, e);
        }



        private void txtLoaiSo_Click(object sender, EventArgs e)
        {
            FrmDownloadLoaiSo frm = new FrmDownloadLoaiSo();
            frm.ShowDialog();
            ReLoad(sender, e);

        }

        private void cbfnameCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderStyle();
        }


        private void cbfnameVN_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        private void cbfstyleCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RenderStyle();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmNgachSo frm = new frmNgachSo();
            frm.ShowDialog();
            RenderStyle();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmTinChu frm = new frmTinChu();
            frm.ShowDialog();
            RenderStyle();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang trong quá trình hoàn thiện, xin vui lòng chờ tại bản demo lần sau");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var sheet = reoGridControl1.CurrentWorksheet;
            if (Util.LongSoHienTai.PageHeight < Util.LongSoHienTai.PageWidth)
            {
                sheet.PrintSettings.Landscape = true;
            }
            sheet.SetRangeBorders(sheet.UsedRange, BorderPositions.All,
                 new unvell.ReoGrid.RangeBorderStyle
                 {
                     Style = BorderLineStyle.None,
                 });
            sheet.SetRangeStyles(sheet.UsedRange, new WorksheetRangeStyle
            {
                // style item flag
                Flag = PlainStyleFlag.BackColor,
                // style item
                BackColor = Color.White,
            });
            using (var session = sheet.CreatePrintSession())
            {
                using (PrintPreviewDialog ppd = new PrintPreviewDialog())
                {
                    ppd.Document = session.PrintDocument;
                    ppd.SetBounds(0, 0, Width, Height - 40);
                    float scale = (float)System.Windows.SystemParameters.VirtualScreenWidth / (float)Util.LongSoHienTai.PageWidth;
                    ppd.PrintPreviewControl.Zoom = scale * 0.7;
                    ppd.WindowState = FormWindowState.Maximized;
                    ppd.Document.PrinterSettings.PrinterName = Util.LongSoHienTai.PrinterName;
                    ppd.ShowDialog(this);
                    RenderStyle();
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
            ReLoad(sender, e);
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Tính năng này đang trong quá trình hoàn thiện, xin vui lòng chờ tại bản demo lần sau");
            //rbChuHan.Checked = true;
        }

        private void cbHideGridLine_CheckedChanged(object sender, EventArgs e)
        {
            reoGridControl1.ShowBolder(cbHideGridLine.Checked);
        }

        private void ctextMenuS_Opening(object sender, CancelEventArgs e)
        {
            var worksheet = reoGridControl1.CurrentWorksheet;
            var select = worksheet.SelectionRange;
            if (rbSongNgu.Checked)
            {
                if ((string)worksheet.Cells[select.Row, select.Col].DataFormatArgs == "TextCN")
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
                if (frmTinChu.keys.Contains(Tag))
                {
                    frmTinChu frm = new frmTinChu();
                    frm.ShowDialog();
                    ActiveData.Get(Tag, out string CN, out string VN);

                }
                else
                {
                    showSugget(Tag, Tag);
                }
                RenderStyle();
            }
        }
        public void showSugget(string key, string t)
        {
            var position = reoGridControl1.CurrentWorksheet.SelectionRange;
            Util.strDataSugget = reoGridControl1.CurrentWorksheet.Cells[position.Row, position.Col].Data + "";

            if (key == "@ngachso")
            {
                var frm = new frmNgachSo();
                frm.ShowDialog();

            }
            else
            {


                var frm = new frmSugget(key, t);
                frm.ShowDialog();
            }

            if (string.IsNullOrEmpty(Util.strDataSugget))
            {
                Util.strDataSugget = t;
            }

            var item = reoGridControl1.CurrentWorksheet.Cells[position.Row, position.Col];
            var cell = item.Tag.getCellData();
            cell.TextCN = Util.strDataSugget;
            cell.TextVN = key;
            item.Tag = cell;

            ActiveData.Update(key, Util.strDataSugget);
        }
        private void button8_Click(object sender, EventArgs e)
        {

        }
        public void LogOutput(string input)
        {
            if (richTextBox1.Visible)
            {
                richTextBox1.Text = input + ":" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff") + "\n" + richTextBox1.Text;
            }
        }
        public void renderText(Worksheet sheet, string txt, int i, int j)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return;
            }
            var cnt = txt.Split(' ').Where(v => !string.IsNullOrEmpty(v)).ToList();
            for (int k = 0; k < cnt.Count; k++)
            {
                var item = sheet.Ranges[new CellPosition() { Row = i, Col = j }.ToAddress()];
                //           item.Row+=1;
                if (k > 0)
                {

                    if (item.Row >= sheet.UsedRange.EndRow)
                    {
                        item.Row = item.EndRow;
                        if (item.Col >= sheet.UsedRange.EndCol)
                        {
                            item.Row = item.Row - 1;
                        }
                        else
                        {
                            item.Col += 1;
                        }
                    }
                    else
                    {
                        item.Row += 1;
                    }
                }
                var row = sheet.Cells[item.Row, item.Col];
                row.Data = cnt[k];
                if (k > 0)
                {
                    row.DataFormatArgs = "NO";
                }
            }
        }
        public void RenderStyle()
        {

            LogOutput("RenderStyle");
            var sheet = reoGridControl1.CurrentWorksheet;
            var position = sheet.UsedRange;

            if (rbSongNgu.Checked)
            {
                SaveData();
                LoadDataToDataGrid(sheet);
            }
            reoGridControl1.ShowBolder(false);
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

            reoGridControl1.ShowBolder(cbHideGridLine.Checked);

            string Status = "";
            if (rbChuViet.Checked) Status = "TextVN";
            if (rbChuHan.Checked) Status = "TextCN";
            if (rbSongNgu.Checked) Status = "TextSN";

            if (Status != "TextSN")
            {
                ChangeFontAndSize(sheet, Status, sheet.UsedRange.ToAddress());
            }

            for (int i = 0; i <= position.EndRow; i++)
            {
                for (int j = 0; j <= position.EndCol; j++)
                {
                    var item = sheet.Cells[i, j];

                    item.IsReadOnly = false;
                    // nếu bắt đầu bằng @ thì bôi màu
                    var cell = item.Tag.getCellData();
                    if ((cell.Value + "").StartsWith("@") || (String)item.DataFormatArgs == "NO")
                    {
                        sheet.SetRangeStyles(item.Address, new WorksheetRangeStyle
                        {
                            // style item flag
                            Flag = PlainStyleFlag.BackColor,
                            // style item
                            BackColor = Color.SkyBlue,
                        });
                        ActiveData.Get(cell.Value + "", out string CN, out string VN);
                        if ((String)item.DataFormatArgs == "TextVN")
                        {
                            renderText(sheet, VN, i, j);
                        }
                        if ((String)item.DataFormatArgs == "TextCN")
                        {
                            renderText(sheet, CN, i, j);
                            //    item.Data = CN;
                        }
                    }
                    else
                    {
                        if ((String)item.DataFormatArgs == "NO")
                        {
                            item.IsReadOnly = true;
                            continue;
                        }
                         switch (Status)
                        {
                            case "TextVN": item.Data = cell.TextVN; break;
                            case "TextCN": item.Data = cell.TextCN; break;
                            case "TextSN": item.Data = ((item.DataFormatArgs + "") == "TextVN") ? cell.TextVN : cell.TextCN; break;
                            default:
                                break;
                        }
                    }


                    if (rbSongNgu.Checked) ChangeFontAndSize(sheet, (item.DataFormatArgs + ""), item.Address);


                }
            }
            if (rbSongNgu.Checked) ChangeWidthSize(sheet, true);

            SaveData();
        }
        public void ChangeFontAndSize(Worksheet sheet, string Data, string Address)
        {

            var FontName = "";
            var Bold = false;
            var Italic = false;
            float FontSize = 16;
            if (Data == "TextCN")
            {
                FontName = cbfnameCN.Text;
                Bold = LongSoData.StringTofstyle(cbfstyleCN.Text) == 1 ? true : false;
                Italic = LongSoData.StringTofstyle(cbfstyleCN.Text) == 2 ? true : false;
                float.TryParse(cbfsizeCN.Text, out FontSize);
            }
            if (Data == "TextVN")
            {

                FontName = cbfnameVN.Text;
                Bold = LongSoData.StringTofstyle(cbfstyleVN.Text) == 1 ? true : false;
                Italic = LongSoData.StringTofstyle(cbfstyleVN.Text) == 2 ? true : false;
                float.TryParse(cbfsizeVN.Text, out FontSize);


            }
          
            sheet.SetRangeStyles(Address, new unvell.ReoGrid.WorksheetRangeStyle
            {
                Flag = unvell.ReoGrid.PlainStyleFlag.FontStyleAll,
                Bold = Bold,
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

        public void ChangeWidthSize(Worksheet sheet, bool check)
        {
            sheet = reoGridControl1.CurrentWorksheet;

            for (int i = 1; i < sheet.ColumnCount; i = i + 1)
            {
                sheet.AutoFitColumnWidth(i, check);
            }
        }
        private void cbfstyleVN_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = cbfstyleVN.Text;
            var check = LongSoData.StringTofstyle(val);
            var sheet = reoGridControl1.CurrentWorksheet;


            sheet.SetRangeStyles(sheet.UsedRange, new unvell.ReoGrid.WorksheetRangeStyle
            {
                Flag = unvell.ReoGrid.PlainStyleFlag.FontStyleAll,
                Bold = check == 1 ? true : false,
                Italic = check == 2 ? true : false,
            });

        }

        private void cbfsizeCN_Click(object sender, EventArgs e)
        {

        }

        private void cbfsizeVN_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  RenderStyle();

        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        public void SaveData()
        {

            LogOutput("SaveData");
            if (!rbSongNgu.Checked)
            {


                var LgSo = new Dictionary<int, Dictionary<int, CellData>>();

                var sheet = reoGridControl1.CurrentWorksheet;
                var position = sheet.UsedRange;
                if (position.Cols <= 1)
                {
                    return;
                }
                for (int i = 1; i <= position.EndCol - 1; i++)
                {
                    LgSo.Add(i - 1, new Dictionary<int, CellData>());
                    for (int j = 1; j <= position.EndRow - 1; j++)
                    {


                        CellData value = new CellData();
                        if (sheet.MaxContentCol >= i && sheet.MaxContentRow >= j)
                        {

                            var item = sheet.Cells[j, i];

                            if ((string)item.DataFormatArgs != "TextVN" && (string)item.DataFormatArgs != "TextCN")
                            {
                                continue;
                            }
                            var cell = item.Tag.getCellData();

                            value.TextCN = cell.TextCN;
                            value.TextVN = cell.TextVN;
                            value.Value = cell.Value;

                        }

                        LgSo[i - 1].Add(j - 1, value);

                    }
                }
                Util.LongSoHienTai.LgSo = LgSo;
            }
            if (rbSongNgu.Checked)
            {


                var LgSo = new Dictionary<int, Dictionary<int, CellData>>();

                var sheet = reoGridControl1.CurrentWorksheet;
                var position = sheet.UsedRange;
                if (position.Cols <= 1)
                {
                    return;
                }
                int c = 0;
                for (int i = 0; i <= position.EndCol + 1; i++)
                {
                    var row = new Dictionary<int, CellData>();
                    int k = 0;
                    for (int j = 0; j <= position.EndRow + 1; j++)
                    {


                        CellData value = new CellData();
                        if (position.EndCol >= i && position.EndRow >= j)
                        {

                            var item = sheet.Cells[j, i];
                            if ((string)item.DataFormatArgs == "TextVN")
                            {

                                var cell = item.Tag.getCellData();

                                value.TextCN = cell.TextCN;
                                value.TextVN = cell.TextVN;
                                value.Value = cell.Value;


                                row.Add(k, value);
                                k++;
                            }
                        }
                    }
                    if (row.Count > 0)
                    {
                        LgSo.Add(c, row);
                        c++;
                    }
                }
                //var LgSoResult = new Dictionary<int, Dictionary<int, CellData>>();
                //int c = 0;
                //foreach (var item in LgSo)
                //{
                //    int j = 0;
                //    LgSoResult.Add(c, new Dictionary<int, CellData>());
                //    foreach (var it in item.Value)
                //    {
                //        LgSoResult[c].Add(j, it.Value);
                //        j++;
                //    }
                //    c++;

                //}
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

            LongSoData.save(Util.LongSoHienTai);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SaveData();
            // ReLoad(sender, e);
            //SaveData();
            //ReLoad(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
            richTextBox1.Text = "";
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
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

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

            var listfilelocal = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data", "*.config").ToList();
            foreach (var item in listfilelocal)
            {
                File.Delete(item);
            }
            MessageBox.Show("Đã update dữ liệu mới nhất");
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            var frm = new frmDownloadFont();
            frm.ShowDialog();
            loadFont.loadListFontCN(true);
            MessageBox.Show("Vui lòng tắt phần mềm đi mở lại để sử dụng những font vừa download !");
        }

        private void button10_Click_1(object sender, EventArgs e)
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

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                var sheet = reoGridControl1.CurrentWorksheet;
                ChangeWidthSize(sheet, checkBox2.Checked);
            }
            else
            {
                ReLoad(sender, e);
            }
        }
    }
}
