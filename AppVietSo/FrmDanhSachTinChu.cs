using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 using AppVietSo.Properties;
 using unvell.ReoGrid.Print;
using AppVietSo.Models;
using unvell.ReoGrid;
using System.Drawing.Printing;

namespace AppVietSo
{
	public partial class FrmDanhSachTinChu : Form
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00006B6D File Offset: 0x00004D6D
		private Worksheet curWS
		{
			get
			{
				return this.reoGridControl1.CurrentWorksheet;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00006B7A File Offset: 0x00004D7A
		public FrmDanhSachTinChu(DataTable dt)
		{
			this.dt = dt;
			this.InitializeComponent();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00006B90 File Offset: 0x00004D90
		private void FrmDanhSachTinChu_Load(object sender, EventArgs e)
		{
			 
				this.reoGridControl1.SetSettings(WorkbookSettings.View_Default, false);
				Cursor.Current = Cursors.WaitCursor;
				this.splitContainer1.SplitterDistance = this.btnPrintPreview.Width + 0x14;
				FontFamily[] families = FontFamily.Families;
				for (int i = 0; i < families.Length; i++)
				{
					FontFamily ff = families[i];
					if (!this.cbxFontName.Items.Cast<ComboboxItem>().Any((ComboboxItem cbi) => cbi.Text.Equals(ff.Name)))
					{
						ComboboxItem item = new ComboboxItem(ff.Name, ff);
						this.cbxFontName.Items.Add(item);
					}
				}
				if (!string.IsNullOrEmpty(Program.Stg.GetPrintSetting("TinChuD").FontName))
				{
					foreach (object obj in this.cbxFontName.Items)
					{
						ComboboxItem comboboxItem = (ComboboxItem)obj;
						if (comboboxItem.Text == Program.Stg.GetPrintSetting("TinChuD").FontName)
						{
							this.cbxFontName.SelectedItem = comboboxItem;
							break;
						}
					}
				}
				if (this.cbxFontName.SelectedItem == null)
				{
					foreach (object obj2 in this.cbxFontName.Items)
					{
						ComboboxItem comboboxItem2 = (ComboboxItem)obj2;
						if (comboboxItem2.Text == "Times New Roman")
						{
							this.cbxFontName.SelectedItem = comboboxItem2;
							break;
						}
					}
				}
				if (0m < Program.Stg.GetPrintSetting("TinChuD").FontSize)
				{
					this.numUpDownFontSize.Value = Program.Stg.GetPrintSetting("TinChuD").FontSize;
				}
				else
				{
					this.numUpDownFontSize.Value = 16m;
				}
				this.cbxFontName.Width = this.splitContainer1.Panel1.Width - 0xF;
				if (this.ckxSpaceFamily.Checked == Program.Stg.GetPrintSetting("TinChuD").SpaceFamily)
				{
					this.FillTinChu();
				}
				else
				{
					this.ckxSpaceFamily.Checked = Program.Stg.GetPrintSetting("TinChuD").SpaceFamily;
				}
				this.isFrmLoading = true;
		 
				this.isFrmLoading = false;
				Cursor.Current = Cursors.Default;
		 
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00006E80 File Offset: 0x00005080
		private void FillTinChu()
		{
			 
				Cursor.Current = Cursors.WaitCursor;
				List<Person> @object = BaseBO.GetObject<Person>(this.dt);
				List<ExcelPerson> list = new List<ExcelPerson>();
				list.Add(new ExcelPerson
				{
					MaCell = new Models.Cell()
										{
						Value = "Số Sớ",
						HAlignment = 2,
						FontBold = true,
						FontSize = 12f
					},
					NameCell = new Models.Cell(){
						Value = "Họ Và Tên",
						HAlignment = 2,
						FontBold = true,
						FontSize = 12f
					},
					YearCell = new Models.Cell(){
						Value = "Năm",
						HAlignment = 2,
						FontBold = true,
						FontSize = 12f
					},
					GenderCell = new Models.Cell()					{
						Value = "Giới tính",
						HAlignment = 2,
						FontBold = true,
						FontSize = 12f
					},
					MenhCell = new Models.Cell()					{
						Value = "Mệnh",
						HAlignment = 2,
						FontBold = true,
						FontSize = 12f
					},
					SaoCell = new Models.Cell()					{
						Value = "Sao",
						HAlignment = 2,
						FontBold = true,
						FontSize = 12f
					},
					AddressCell = new Models.Cell()					{
						Value = "Địa chỉ",
						HAlignment = 2,
						FontBold = true,
						FontSize = 12f
					},
					NoteCell = new Models.Cell()					{
						Value = "Ghi chú",
						HAlignment = 2,
						FontBold = true,
						FontSize = 12f
					}
				});
				decimal value = this.nUpDFrom.Value;
				decimal value2 = this.nUpDTo.Value;
				int num = 0;
				foreach (Person person in @object)
				{
					if ((value == 1m && value2 == 2m) || (value <= person.SoNo && person.SoNo <= value2))
					{
						ExcelPerson excelPerson = new ExcelPerson();
						excelPerson.MaCell = new Models.Cell();
						excelPerson.MaCell.Value = person.SoNo;
						excelPerson.MaCell.HAlignment = 2;
						excelPerson.MaCell.VAlignment = 2;
						excelPerson.NameCell = new Models.Cell();
						excelPerson.NameCell.Value = person.FullName;
						excelPerson.NameCell.VAlignment = 2;
						if (num != person.SoNo)
						{
							num = person.SoNo;
							excelPerson.NameCell.FontBold = true;
							if (num != 1 && Program.Stg.GetPrintSetting("TinChuD").SpaceFamily)
							{
								list.Add(new ExcelPerson());
							}
						}
						excelPerson.YearCell = new Models.Cell();
						excelPerson.YearCell.Value = person.NamSinh;
						excelPerson.YearCell.HAlignment = 2;
						excelPerson.YearCell.VAlignment = 2;
						excelPerson.GenderCell = new Models.Cell();
						excelPerson.GenderCell.Value = person.GioiTinhDisplay;
						excelPerson.GenderCell.HAlignment = 2;
						excelPerson.GenderCell.VAlignment = 2;
						excelPerson.MenhCell = new Models.Cell();
						excelPerson.MenhCell.Value = person.Menh;
						excelPerson.MenhCell.VAlignment = 2;
						excelPerson.SaoCell = new Models.Cell();
						excelPerson.SaoCell.Value = person.Sao;
						excelPerson.SaoCell.VAlignment = 2;
						excelPerson.AddressCell = new Models.Cell();
						excelPerson.AddressCell.Value = person.Address;
						excelPerson.AddressCell.VAlignment = 2;
						excelPerson.NoteCell = new Models.Cell();
						list.Add(excelPerson);
					}
				}
				this.PageSetting(this.curWS, list.Count);
				Excel.FillDataToGrid(list.Cast<object>().ToList<object>(), 0, this.curWS);
				Excel.SetColDataTextWrap(this.curWS, 1);
				Excel.SetColDataTextWrap(this.curWS, 6);
				this.updateFont();
			 
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000073B4 File Offset: 0x000055B4
		private void PageSetting(Worksheet curWS, int row)
		{
			if (string.IsNullOrEmpty(Program.Stg.GetPrintSetting("TinChuD").PaperName))
			{
				curWS.PrintSettings.PaperName = "A4";
			}
			else
			{
				curWS.PrintSettings.PaperName = Program.Stg.GetPrintSetting("TinChuD").PaperName;
			}
			PageSettings pageSettings = curWS.PrintSettings.CreateSystemPageSettings();
			Excel.SetRowCol(curWS, row, 8);
			pageSettings.Landscape = false;
			if (Program.Stg.PrintSetting.ContainsKey("TinChuD") && Program.Stg.GetPrintSetting("TinChuD").MarginT != 0f)
			{
				pageSettings.Margins = new PageMargins(Program.Stg.GetPrintSetting("TinChuD").MarginT, Program.Stg.GetPrintSetting("TinChuD").MarginB, Program.Stg.GetPrintSetting("TinChuD").MarginL, Program.Stg.GetPrintSetting("TinChuD").MarginR);
			}
			curWS.PrintSettings.ApplySystemPageSettings(pageSettings);
			curWS.PrintSettings.PageOrder = PrintPageOrder.OverThenDown;
			curWS.SetRowsHeight(0, curWS.RowCount, 0x1E);
			curWS.SetColumnsWidth(0, 1, 0x3C);
			curWS.SetColumnsWidth(1, 1, 0x118);
			curWS.SetColumnsWidth(2, 1, 0x41);
			curWS.SetColumnsWidth(3, 1, 0x41);
			curWS.SetColumnsWidth(4, 1, 0x64);
			curWS.SetColumnsWidth(5, 1, 0x6E);
			curWS.SetColumnsWidth(6, 1, 0x1F4);
			curWS.SetColumnsWidth(7, 1, 0x12C);
			this.updateCol();
			curWS.DisableSettings(WorksheetSettings.Edit_AutoFormatCell);
			curWS.SetSettings(WorksheetSettings.Edit_Readonly, true);
			this.AutoSplitPage();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00007558 File Offset: 0x00005758
		private void AutoSplitPage()
		{
			this.curWS.PrintSettings.PageScaling = 1f;
			this.curWS.EnableSettings(WorksheetSettings.View_ShowPageBreaks);
			if (1 < this.curWS.ColumnPageBreaks.Count)
			{
				int num = this.curWS.ColumnPageBreaks[1];
				if (num == 8)
				{
					this.curWS.AutoSetMaximumScaleForPages();
				}
				this.curWS.ChangeColumnPageBreak(num, 8, true);
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000075D0 File Offset: 0x000057D0
		private void updateCol()
		{
			foreach (int col in Program.Stg.GetPrintSetting("TinChuD").ColHiden)
			{
				Excel.SetColVisible(this.curWS, col, false);
			}
			foreach (KeyValuePair<int, ushort> keyValuePair in Program.Stg.GetPrintSetting("TinChuD").ColWidth)
			{
				this.curWS.SetColumnsWidth(keyValuePair.Key, 1, keyValuePair.Value);
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000769C File Offset: 0x0000589C
		private void TlStrpMnItmHideCol_Click(object sender, EventArgs e)
		{
			//try
			{
				this.SetColVisible(this.curWS.SelectionRange.Col, false);
			}
			//
			{
				//
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000076DC File Offset: 0x000058DC
		private void TlStrpMnItmShowCol_Click(object sender, EventArgs e)
		{
		//	try
			{
				int i = this.curWS.SelectionRange.Col;
				int num = i + this.curWS.SelectionRange.Cols;
				while (i < num)
				{
					this.SetColVisible(i, true);
					i++;
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00007740 File Offset: 0x00005940
		private void contextMenuStripCol_Opening(object sender, CancelEventArgs e)
		{
			//try
			{
				for (int i = 0; i < this.curWS.ColumnCount; i++)
				{
					if (!this.curWS.ColumnHeaders[i].IsVisible && !this.contextMenuStripCol.Items.ContainsKey(i.ToString()))
					{
						ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
						toolStripMenuItem.Name = i.ToString();
						toolStripMenuItem.Text = "Hiện cột '" + this.curWS.ColumnHeaders[i].Text + "'";
						toolStripMenuItem.Click += this.ShowCol_Click;
						this.contextMenuStripCol.Items.Add(toolStripMenuItem);
					}
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00007818 File Offset: 0x00005A18
		private void ShowCol_Click(object sender, EventArgs e)
		{
		//	try
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				int col = 0;
				if (int.TryParse(toolStripMenuItem.Name, out col))
				{
					this.SetColVisible(col, true);
					if (this.contextMenuStripCol.Items.ContainsKey(toolStripMenuItem.Name))
					{
						this.contextMenuStripCol.Items.RemoveByKey(toolStripMenuItem.Name);
					}
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000788C File Offset: 0x00005A8C
		public void SetColVisible(int col, bool flg)
		{
		//	try
			{
				Excel.SetColVisible(this.curWS, col, flg);
				if (flg)
				{
					if (Program.Stg.GetPrintSetting("TinChuD").ColHiden.Contains(col))
					{
						Program.Stg.GetPrintSetting("TinChuD").ColHiden.Remove(col);
					}
				}
				else if (!Program.Stg.GetPrintSetting("TinChuD").ColHiden.Contains(col))
				{
					Program.Stg.GetPrintSetting("TinChuD").ColHiden.Add(col);
				}
				this.AutoSplitPage();
			}
			//
			{
				//
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00007938 File Offset: 0x00005B38
		public void StoreColWidth()
		{
		//	try
			{
				foreach (unvell.ReoGrid.ColumnHeader columnHeader in this.curWS.ColumnHeaders)
				{
					int index = columnHeader.Index;
					ushort width = columnHeader.Width;
					if (Program.Stg.GetPrintSetting("TinChuD").ColWidth.ContainsKey(index))
					{
						Program.Stg.GetPrintSetting("TinChuD").ColWidth[index] = width;
					}
					else
					{
						Program.Stg.GetPrintSetting("TinChuD").ColWidth.Add(index, width);
					}
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002E18 File Offset: 0x00001018
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000079F8 File Offset: 0x00005BF8
		private void btnPrintPreview_Click(object sender, EventArgs e)
		{

			 
			var sheet = reoGridControl1.CurrentWorksheet;
			 
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
					session.PrintDocument.DefaultPageSettings.PaperSize = Util.LongSoHienTai.paperSize;
					session.PrintDocument.PrinterSettings.DefaultPageSettings.PaperSize = session.PrintDocument.DefaultPageSettings.PaperSize;
					ppd.Document = session.PrintDocument;
					ppd.SetBounds(0, 0, Width, Height - 40);
 					ppd.WindowState = FormWindowState.Maximized;
					ppd.Document.PrinterSettings.PrinterName = Util.LongSoHienTai.PrinterName;
					ppd.ShowDialog(this);
 				}
			}

			return;


			//try
			{
				if (string.IsNullOrEmpty(Program.Stg.GetPrintSetting("TinChuD").PageTitleLeft) && string.IsNullOrEmpty(Program.Stg.GetPrintSetting("TinChuD").PageTitleCenter) && string.IsNullOrEmpty(Program.Stg.GetPrintSetting("TinChuD").PageTitleRight))
				{
					Program.Stg.GetPrintSetting("TinChuD").PageTitleLeft = Util.domain;
					Program.Stg.GetPrintSetting("TinChuD").PageTitleRight = "Trang &[Page] /Tổng &[Pages]";
				}
				//this.curWS.PrintSettings.PageTitleLeft = Program.Stg.GetPrintSetting("TinChuD").PageTitleLeft;
				//this.curWS.PrintSettings.PageTitleCenter = Program.Stg.GetPrintSetting("TinChuD").PageTitleCenter;
				//this.curWS.PrintSettings.PageTitleRight = Program.Stg.GetPrintSetting("TinChuD").PageTitleRight;
				//this.curWS.PrintSettings.IsFooter = Program.Stg.GetPrintSetting("TinChuD").PageIsFooter;
				//this.curWS.PrintSettings.ShowPageNo = Program.Stg.GetPrintSetting("TinChuD").PageIsShowPageNo;
				FrmPrintPreview frmPrintPreview = new FrmPrintPreview();
				//frmPrintPreview.Sheet = this.curWS;
			//	frmPrintPreview.ZoomIndex = Program.Stg.GetPrintSetting("TinChuD").ZoomIndex;
				frmPrintPreview.ShowDialog(this);
				PageMargins margins = this.curWS.PrintSettings.Margins;
				Program.Stg.GetPrintSetting("TinChuD").MarginT = margins.Top;
				Program.Stg.GetPrintSetting("TinChuD").MarginB = margins.Bottom;
				Program.Stg.GetPrintSetting("TinChuD").MarginL = margins.Left;
				Program.Stg.GetPrintSetting("TinChuD").MarginR = margins.Right;
				//Program.Stg.GetPrintSetting("TinChuD").PageTitleLeft = this.curWS.PrintSettings.PageTitleLeft;
				//Program.Stg.GetPrintSetting("TinChuD").PageTitleCenter = this.curWS.PrintSettings.PageTitleCenter;
				//Program.Stg.GetPrintSetting("TinChuD").PageTitleRight = this.curWS.PrintSettings.PageTitleRight;
				//Program.Stg.GetPrintSetting("TinChuD").PageIsFooter = this.curWS.PrintSettings.IsFooter;
				//Program.Stg.GetPrintSetting("TinChuD").PageIsShowPageNo = this.curWS.PrintSettings.ShowPageNo;
				//Program.Stg.GetPrintSetting("TinChuD").PaperName = this.curWS.PrintSettings.PaperName;
				//Program.Stg.GetPrintSetting("TinChuD").ZoomIndex = frmPrintPreview.ZoomIndex;
			}
			//
			{
				//
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00007D04 File Offset: 0x00005F04
		private void numUpDownFontSize_ValueChanged(object sender, EventArgs e)
		{
			//try
			{
				Cursor.Current = Cursors.WaitCursor;
				this.curWS.SetRangeStyles(RangePosition.FromCellPosition(1, 0, this.curWS.MaxContentRow, this.curWS.MaxContentCol), new WorksheetRangeStyle
				{
					Flag = PlainStyleFlag.FontSize,
					FontSize = (float)this.numUpDownFontSize.Value
				});
				if (!this.isFrmLoading)
				{
					Program.Stg.GetPrintSetting("TinChuD").FontSize = (int)this.numUpDownFontSize.Value;
					for (int i = this.curWS.UsedRange.Row; i < this.curWS.UsedRange.Rows; i++)
					{
						this.curWS.AutoFitRowHeight(i, false);
					}
				}
			}
			//
			{
				//
			}
			
			{
				Cursor.Current = Cursors.Default;
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00007E08 File Offset: 0x00006008
		private void cbxFontName_SelectedIndexChanged(object sender, EventArgs e)
		{
		//	try
			{
				Cursor.Current = Cursors.WaitCursor;
				ComboboxItem comboboxItem = this.cbxFontName.SelectedItem as ComboboxItem;
				if (comboboxItem != null)
				{
					string text = comboboxItem.Text;
					this.curWS.SetRangeStyles(this.curWS.UsedRange, new WorksheetRangeStyle
					{
						Flag = PlainStyleFlag.FontName,
						FontName = text
					});
					if (!this.isFrmLoading)
					{
						Program.Stg.GetPrintSetting("TinChuD").FontName = text;
						for (int i = this.curWS.UsedRange.Row; i < this.curWS.UsedRange.Rows; i++)
						{
							this.curWS.AutoFitRowHeight(i, false);
						}
					}
				}
			}
			//
			{
				//
			}
			
			{
				Cursor.Current = Cursors.Default;
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00007EF8 File Offset: 0x000060F8
		private void updateFont()
		{
			this.numUpDownFontSize_ValueChanged(null, null);
			this.cbxFontName_SelectedIndexChanged(null, null);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00007F0C File Offset: 0x0000610C
		private void ckxSpaceFamily_CheckedChanged(object sender, EventArgs e)
		{
			//try
			{
				Program.Stg.GetPrintSetting("TinChuD").SpaceFamily = this.ckxSpaceFamily.Checked;
				this.FillTinChu();
			}
			//
			{
				//
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00007F58 File Offset: 0x00006158
		private void nUpDFrom_ValueChanged(object sender, EventArgs e)
		{
			this.setSelected(sender, e);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00007F58 File Offset: 0x00006158
		private void nUpDTo_ValueChanged(object sender, EventArgs e)
		{
			this.setSelected(sender, e);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00007F64 File Offset: 0x00006164
		private void setSelected(object sender, EventArgs e)
		{
			//try
			{
				decimal value = this.nUpDFrom.Value;
				decimal value2 = this.nUpDTo.Value;
				if (value < value2)
				{
					this.FillTinChu();
				}
				else
				{
					this.nUpDTo.Value = value + 1m;
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00007FCC File Offset: 0x000061CC
		private void FrmDanhSachTinChu_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.StoreColWidth();
		}

		// Token: 0x04000051 RID: 81
		private DataTable dt;

		// Token: 0x04000052 RID: 82
		private const int newColIndex = 8;

		// Token: 0x04000053 RID: 83
		private bool isFrmLoading;
	}
}
