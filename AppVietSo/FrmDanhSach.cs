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
using unvell.ReoGrid.IO.OpenXML.Schema;
using unvell.ReoGrid.Print;

namespace AppVietSo
{
	public partial class FrmDanhSach : Form
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000021D5 File Offset: 0x000003D5
		public FrmDanhSach()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000021F0 File Offset: 0x000003F0
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002271 File Offset: 0x00000471
		private int row
		{
			get
			{
				if (Program.Stg.GetPrintSetting("TinChuH").Rows == 0)
				{
					if (this.curWS.PrintSettings.PaperName == "A4")
					{
						Program.Stg.GetPrintSetting("TinChuH").Rows = 0x1B;
					}
					else
					{
						Program.Stg.GetPrintSetting("TinChuH").Rows = 0x1D;
					}
				}
				return Program.Stg.GetPrintSetting("TinChuH").Rows;
			}
			set
			{
				Program.Stg.GetPrintSetting("TinChuH").Rows = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002288 File Offset: 0x00000488
		// (set) Token: 0x0600000F RID: 15 RVA: 0x0000233D File Offset: 0x0000053D
		private int col
		{
			get
			{
				if (Program.Stg.GetPrintSetting("TinChuH").Cols == 0)
				{
					if (this.curWS.PrintSettings.PaperName == "A4")
					{
						Program.Stg.GetPrintSetting("TinChuH").Cols = 0x10;
					}
					else if (this.curWS.PrintSettings.PaperName == "A3")
					{
						Program.Stg.GetPrintSetting("TinChuH").Cols = 0x12;
					}
					else
					{
						Program.Stg.GetPrintSetting("TinChuH").Cols = 0x10;
					}
				}
				return Program.Stg.GetPrintSetting("TinChuH").Cols;
			}
			set
			{
				Program.Stg.GetPrintSetting("TinChuH").Cols = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002354 File Offset: 0x00000554
		private int startColNum
		{
			get
			{
				return this.col - 1;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000235E File Offset: 0x0000055E
		private unvell.ReoGrid.Worksheet curWS
		{
			get
			{
				return this.reoGridControl1.CurrentWorksheet;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000236C File Offset: 0x0000056C
		private void FrmDanhSach_Load(object sender, EventArgs e)
		{
		//	try
			{
				this.reoGridControl1.SetSettings(WorkbookSettings.View_Default, false);
				this.splitContainer1.SplitterDistance = this.groupBox2.Width;
				this.cbxFontName.Width = this.splitContainer1.Panel1.Width - 0xF;
				this.isInit = true;
				this.reoGridControl1.SetSettings(WorkbookSettings.View_Default, false);
				this.curWS.SetSettings(WorksheetSettings.View_ShowHeaders, false);
				PageSettings wfps = new PageSettings();
				this.curWS.PrintSettings.ApplySystemPageSettings(wfps);
				this.PageSetting();
				this.nmrRows.Value = this.row;
				this.nmrCols.Value = this.col;
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
				if (!string.IsNullOrEmpty(Program.Stg.GetPrintSetting("TinChuH").FontName))
				{
					foreach (object obj in this.cbxFontName.Items)
					{
						ComboboxItem comboboxItem = (ComboboxItem)obj;
						if (comboboxItem.Text == Program.Stg.GetPrintSetting("TinChuH").FontName)
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
				if (0m < Program.Stg.GetPrintSetting("TinChuH").FontSize)
				{
					this.numUpDownFontSize.Value = Program.Stg.GetPrintSetting("TinChuH").FontSize;
				}
				else
				{
					this.numUpDownFontSize.Value = 14m;
				}
				this.cbxFontStyle.SelectedIndex = 0;
			}
			//
			{
				//
			}
			//
			{
				this.isInit = false;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002678 File Offset: 0x00000878
		private void FrmDanhSach_SizeChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000267C File Offset: 0x0000087C
		private void btnTinChu_Click(object sender, EventArgs e)
		{
		//	try
			{
				frmTinChu frmPerson = new frmTinChu();
				if (frmPerson.ShowDialog() == DialogResult.OK)
				{
					this.pagodaID = frmPerson.GetPagodaID;
					this.selectedSoNos = frmPerson.SelectedSoNos;
					this.FillTinChu();
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000026D8 File Offset: 0x000008D8
		private void FillTinChu()
		{
		//	try
			{
				var  PersonPerCol = ckxPersonPerCol.Checked;
				Cursor.Current = Cursors.WaitCursor;
				this.PageSetting();
				tlTC.MoreText = ActiveData.Get("@thietLapTinChuMoreText");
				tlTC.FormText = ActiveData.Get("@thietLapTinChuFormText");
				if (!string.IsNullOrEmpty(this.pagodaID) && this.selectedSoNos != null && this.selectedSoNos.Count > 0)
				{
					DanhSachTinChu.FillTinChuToGrid(this.selectedSoNos, this.isFillAddress, this.pagodaID, this.isNextYear, this.tlTC, this.curWS, 0, this.startColNum, PersonPerCol);
					Excel.HorizontalAlign(this.curWS, ReoGridHorAlign.Center);
					this.curWS.ResetAllPageBreaks();
					this.updatePageTotal();
					this.updateFont();
				}
			}
			//
			{
				Cursor.Current = Cursors.Default;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000278C File Offset: 0x0000098C
		private void btnPrintPreview_Click(object sender, EventArgs e)
		{
            //try
            {
                if (string.IsNullOrEmpty(Program.Stg.GetPrintSetting("TinChuH").PageTitleLeft) && string.IsNullOrEmpty(Program.Stg.GetPrintSetting("TinChuH").PageTitleCenter) && string.IsNullOrEmpty(Program.Stg.GetPrintSetting("TinChuH").PageTitleRight))
                {
                    Program.Stg.GetPrintSetting("TinChuH").PageTitleLeft = Util.domain;
                    Program.Stg.GetPrintSetting("TinChuH").PageTitleRight = "Trang &[Page] /Tổng &[Pages]";
                }
                //this.curWS.PrintSettings.PageTitleLeft = Program.Stg.GetPrintSetting("TinChuH").PageTitleLeft;
                //this.curWS.PrintSettings.PageTitleCenter = Program.Stg.GetPrintSetting("TinChuH").PageTitleCenter;
                //this.curWS.PrintSettings.PageTitleRight = Program.Stg.GetPrintSetting("TinChuH").PageTitleRight;
                //this.curWS.PrintSettings.IsFooter = Program.Stg.GetPrintSetting("TinChuH").PageIsFooter;
                //this.curWS.PrintSettings.ShowPageNo = Program.Stg.GetPrintSetting("TinChuH").PageIsShowPageNo;
                FrmPrintPreview frmPrintPreview = new FrmPrintPreview(this.curWS, false);
                 frmPrintPreview.ZoomIndex = Program.Stg.GetPrintSetting("TinChuH").ZoomIndex;
                frmPrintPreview.ShowDialog(this);
                unvell.ReoGrid.Print.PageMargins margins = this.curWS.PrintSettings.Margins;
                Program.Stg.GetPrintSetting("TinChuH").MarginT = margins.Top;
                Program.Stg.GetPrintSetting("TinChuH").MarginB = margins.Bottom;
                Program.Stg.GetPrintSetting("TinChuH").MarginL = margins.Left;
                Program.Stg.GetPrintSetting("TinChuH").MarginR = margins.Right;
                //Program.Stg.GetPrintSetting("TinChuH").PageTitleLeft = this.curWS.PrintSettings.PageTitleLeft;
                //Program.Stg.GetPrintSetting("TinChuH").PageTitleCenter = this.curWS.PrintSettings.PageTitleCenter;
                //Program.Stg.GetPrintSetting("TinChuH").PageTitleRight = this.curWS.PrintSettings.PageTitleRight;
                //Program.Stg.GetPrintSetting("TinChuH").PageIsFooter = this.curWS.PrintSettings.IsFooter;
                //Program.Stg.GetPrintSetting("TinChuH").PageIsShowPageNo = this.curWS.PrintSettings.ShowPageNo;
                //Program.Stg.GetPrintSetting("TinChuH").PaperName = this.curWS.PrintSettings.PaperName;
                Program.Stg.GetPrintSetting("TinChuH").ZoomIndex = frmPrintPreview.ZoomIndex;
                this.FillTinChu();
            }
            //
            {
                //
            }
        }

		// Token: 0x06000017 RID: 23 RVA: 0x00002AA0 File Offset: 0x00000CA0
		private void btnPrintSetting_Click(object sender, EventArgs e)
		{
			//try
			{
				using (PageSetupDialog pageSetupDialog = new PageSetupDialog())
				{
					pageSetupDialog.PageSettings = this.curWS.PrintSettings.CreateSystemPageSettings();
					pageSetupDialog.AllowMargins = true;
					pageSetupDialog.AllowPrinter = true;
					pageSetupDialog.AllowPaper = true;
					pageSetupDialog.EnableMetric = true;
					if (pageSetupDialog.ShowDialog() == DialogResult.OK)
					{
						this.curWS.PrintSettings.ApplySystemPageSettings(pageSetupDialog.PageSettings);
					}
				}
				this.curWS.ResetAllPageBreaks();
			}
			//
			{
				//
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002B40 File Offset: 0x00000D40
		private void PageSetting()
		{
			if (string.IsNullOrEmpty(Program.Stg.GetPrintSetting("TinChuH").PaperName))
			{
				this.curWS.PrintSettings.PaperName = "A3";
			}
			else
			{
				this.curWS.PrintSettings.PaperName = Program.Stg.GetPrintSetting("TinChuH").PaperName;
			}
			PageSettings pageSettings = this.curWS.PrintSettings.CreateSystemPageSettings();
			Excel.SetRowCol(this.curWS, this.row, this.col);
			this.curWS.EnableSettings(WorksheetSettings.View_ShowPageBreaks);
			this.curWS.SetSettings(WorksheetSettings.Behavior_AllowUserChangingPageBreaks, false);
			pageSettings.Landscape = true;
			if (Program.Stg.PrintSetting.ContainsKey("TinChuH") && Program.Stg.GetPrintSetting("TinChuH").MarginT != 0f)
			{
				pageSettings.Margins = new unvell.ReoGrid.Print.PageMargins(Program.Stg.GetPrintSetting("TinChuH").MarginT, Program.Stg.GetPrintSetting("TinChuH").MarginB, Program.Stg.GetPrintSetting("TinChuH").MarginL, Program.Stg.GetPrintSetting("TinChuH").MarginR);
			}
			this.curWS.PrintSettings.ApplySystemPageSettings(pageSettings);
			this.curWS.PrintSettings.PageOrder = PrintPageOrder.OverThenDown;
			//ShareFun.SetRowCol(this.curWS, this.row, this.col);
			ShareFun.SetWidthHeightBibe(this.curWS, this.row, this.col);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002CC0 File Offset: 0x00000EC0
		private void nmrCols_ValueChanged(object sender, EventArgs e)
		{
		//	try
			{
				if (!this.isInit)
				{
					this.col = (int)this.nmrCols.Value;
					//ShareFun.SetRowCol(this.curWS, this.row, this.col);
					ShareFun.SetWidthHeightBibe(this.curWS, this.row, this.col);
					this.updatePageTotal();
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002D24 File Offset: 0x00000F24
		private void nmrRows_ValueChanged(object sender, EventArgs e)
		{
			//try
			{
				if (!this.isInit)
				{
					this.row = (int)this.nmrRows.Value;
					float scaleFactor = this.curWS.ScaleFactor;
					this.FillTinChu();
					this.curWS.ScaleFactor = scaleFactor;
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002D88 File Offset: 0x00000F88
		private void nmrStartRowNum_ValueChanged(object sender, EventArgs e)
		{
			//try
			{
				this.FillTinChu();
			}
			//
			{
				//
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002DB4 File Offset: 0x00000FB4
		private void updatePageTotal()
		{
			this.lblPageTotal.Text = string.Format("Số trang: {0}", this.curWS.PrintPageCounts);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002DDC File Offset: 0x00000FDC
		private void ckxPersonPerCol_CheckedChanged(object sender, EventArgs e)
		{
			this.FillTinChu();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002E18 File Offset: 0x00001018
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002E20 File Offset: 0x00001020
		private void cbxIsAddress_CheckedChanged(object sender, EventArgs e)
		{
			//try
			{
				this.isFillAddress = this.cbxIsAddress.Checked;
				this.FillTinChu();
			}
			//
			{
				//
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002E60 File Offset: 0x00001060
		private void btnKhuonTinChu_Click(object sender, EventArgs e)
		{
		//	try
			{
				if (new FrmThietLapTinChu().ShowDialog(this) == DialogResult.OK)
				{
					this.FillTinChu();
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002EA0 File Offset: 0x000010A0
		private void numUpDownFontSize_ValueChanged(object sender, EventArgs e)
		{
			//try
			{
				this.curWS.SetRangeStyles(this.curWS.UsedRange, new WorksheetRangeStyle
				{
					Flag = PlainStyleFlag.FontSize,
					FontSize = (float)this.numUpDownFontSize.Value
				});
			}
			//
			{
				//
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002F00 File Offset: 0x00001100
		private void cbxFontStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			//try
			{
				string text = this.cbxFontStyle.SelectedItem as string;
				if (!string.IsNullOrEmpty(text))
				{
					this.curWS.SetRangeStyles(this.curWS.UsedRange, new WorksheetRangeStyle
					{
						Flag = PlainStyleFlag.FontStyleAll,
						Bold = ("Đậm" == text),
						Italic = ("Nghiêng" == text)
					});
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002F88 File Offset: 0x00001188
		private void cbxFontName_SelectedIndexChanged(object sender, EventArgs e)
		{
		//	try
			{
				ComboboxItem comboboxItem = this.cbxFontName.SelectedItem as ComboboxItem;
				if (comboboxItem != null)
				{
					string text = comboboxItem.Text;
					this.curWS.SetRangeStyles(this.curWS.UsedRange, new WorksheetRangeStyle
					{
						Flag = PlainStyleFlag.FontName,
						FontName = text
					});
				}
			}
			//
			{
				//
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002FF8 File Offset: 0x000011F8
		private void updateFont()
		{
			this.numUpDownFontSize_ValueChanged(null, null);
			this.cbxFontStyle_SelectedIndexChanged(null, null);
			this.cbxFontName_SelectedIndexChanged(null, null);
		}

		// Token: 0x04000003 RID: 3
		private bool isInit;

		// Token: 0x04000004 RID: 4
		private bool isFillAddress;

		// Token: 0x04000005 RID: 5
		private Year isNextYear;

		// Token: 0x04000006 RID: 6
		private ThietLapTinChu tlTC = new ThietLapTinChu();

		// Token: 0x04000007 RID: 7
		private Dictionary<int, Family> selectedSoNos;

		// Token: 0x04000008 RID: 8
		private string pagodaID;
	}
}
