using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CommonModel;
using DataModel;
using DataModel.Entities;
using DataText;
using PrintHelper;
using PrintSo.Properties;

namespace PrintSo
{
	// Token: 0x02000012 RID: 18
	public partial class FrmPreview : Form
	{
		// Token: 0x06000092 RID: 146 RVA: 0x0000B20C File Offset: 0x0000940C
		public FrmPreview()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000B25C File Offset: 0x0000945C
		private void FrmPreview_Load(object sender, EventArgs e)
		{
			this.welcome = new FrmWelcome();
			try
			{
				this.unre = new UnReDo<LongSoData>();
				this.welcome.Show(this);
				if (!File.Exists(Util.getDataPath + "\\TamKhong.com"))
				{
					File.Move(Util.getDataPath + "\\TamKhong_.com", Util.getDataPath + "\\TamKhong.com");
					try
					{
						Process.Start("http://" + Util.domain);
					}
					catch (Exception)
					{
					}
				}
				if (!File.Exists(Util.getDataPath + "\\TamKhongDic.com"))
				{
					File.Move(Util.getDataPath + "\\TamKhongDic_.com", Util.getDataPath + "\\TamKhongDic.com");
				}
				if (!File.Exists(Util.getDataPath + "\\LePhat.bibe"))
				{
					File.Move(Util.getDataPath + "\\LePhat_.bibe", Util.getDataPath + "\\LePhat.bibe");
				}
				if (!File.Exists(Util.getDataPath + "\\LeSao.bibe"))
				{
					File.Move(Util.getDataPath + "\\LeSao_.bibe", Util.getDataPath + "\\LeSao.bibe");
				}
				if (!File.Exists(Util.getDataPath + "\\PhucTho.bibe"))
				{
					File.Move(Util.getDataPath + "\\PhucTho_.bibe", Util.getDataPath + "\\PhucTho.bibe");
				}
				if (File.Exists(Util.getDataPath + "\\TamKhong_.com"))
				{
					File.Delete(Util.getDataPath + "\\TamKhong_.com");
				}
				if (File.Exists(Util.getDataPath + "\\TamKhongDic_.com"))
				{
					File.Delete(Util.getDataPath + "\\TamKhongDic_.com");
				}
				if (File.Exists(Util.getDataPath + "\\LePhat_.com"))
				{
					File.Delete(Util.getDataPath + "\\LePhat_.com");
				}
				if (File.Exists(Util.getDataPath + "\\LeSao_.com"))
				{
					File.Delete(Util.getDataPath + "\\LeSao_.com");
				}
				if (File.Exists(Util.getDataPath + "\\PhucTho_.com"))
				{
					File.Delete(Util.getDataPath + "\\PhucTho_.com");
				}
				PagodaBO.addColIsPrint();
				PersonBO.addColNgayMat();
				PersonBO.addColDanhXung();
				PersonBO.addAlterView();
				VnChineseBO.addColNguCanh();
				VnChineseBO.addColUpdateDT();
				VnChineseBO.addColSyscTime();
				this.txt_Focus.AutoSize = false;
				this.isFrmLoading = true;
				if (Program.Stg.LongSoUserData != null)
				{
					this.prD.LongSoUserData = Program.Stg.LongSoUserData;
					if (this.prD.LongSoUserData.ContainsKey("@nam"))
					{
						string nam = LePhat.getNam(DateTime.Now.AddYears(-1).Year.ToString());
						string nam2 = LePhat.getNam(DateTime.Now.Year.ToString());
						string nam3 = LePhat.getNam(DateTime.Now.AddYears(1).Year.ToString());
						if (nam == this.prD.LongSoUserData["@nam"])
						{
							this.prD.IsNextYear = Year.Pre;
						}
						else if (nam2 == this.prD.LongSoUserData["@nam"])
						{
							this.prD.IsNextYear = Year.Cur;
						}
						else if (nam3 == this.prD.LongSoUserData["@nam"])
						{
							this.prD.IsNextYear = Year.Nex;
						}
					}
				}
				string text = Util.getDataPath + "fontCN\\UVNButLong1.TTF";
				if (!File.Exists(text))
				{
					MessageBox.Show("Không tìm thấy file font " + text + "\n Xin hãy cài lại phần mềm.", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					base.Close();
				}
				this.loadCBXLoaiSo();
				text = Util.getDataPath + "fontCN\\CN_KHAI.TTF";
				if (!File.Exists(text))
				{
					MessageBox.Show("Không tìm thấy file font " + text + "\n Xin hãy cài lại phần mềm.", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					base.Close();
				}
				this.ckxMaSo.Checked = Program.Stg.IsPrintMaSo;
				string a = Program.Stg.NgonNgu;
				if (!(a == "cbxSongNgu"))
				{
					if (!(a == "cbxChuViet"))
					{
						if (!(a == "cbxChuTrung"))
						{
						}
						this.cbxChuTrung.Checked = true;
					}
					else
					{
						this.cbxChuViet.Checked = true;
					}
				}
				else
				{
					this.cbxSongNgu.Checked = true;
				}
				if (this.pnlAlign.Visible)
				{
					a = this.prD.LoaiSoData.SongNguAlign;
					if (!(a == "top"))
					{
						if (!(a == "right"))
						{
							if (!(a == "left"))
							{
								this.rbtnBottom.Checked = true;
							}
							else
							{
								this.rbtnLeft.Checked = true;
							}
						}
						else
						{
							this.rbtnRight.Checked = true;
						}
					}
					else
					{
						this.rbtnTop.Checked = true;
					}
				}
				this.loadCBXFontStyle();
				this.loadCBXFontSize();
				this.loadFont();
				this.setDefaultByLoaiSo();
				this.refreshTitle();
				this.uSupportInfo1.Width = this.splitCntMain.SplitterDistance;
				int num = 0;
				foreach (object obj in this.uSupportInfo1.Controls)
				{
					Control control = (Control)obj;
					num += control.Height + 13;
				}
				this.uSupportInfo1.Height = num;
				this.uSupportInfo1.Location = new Point(0, this.splitCntMain.Height - num - this.lblInfo.Height);
				new SynchronizeData(this.getVersion);
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000B880 File Offset: 0x00009A80
		private void FrmPreview_SizeChanged(object sender, EventArgs e)
		{
			this.ReLoad();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000B888 File Offset: 0x00009A88
		private void setDefaultByLoaiSo()
		{
			if (this.tlSCbxFontVN.SelectedItem == null)
			{
				if (string.IsNullOrEmpty(this.prD.LoaiSoData.fnameVN))
				{
					using (IEnumerator enumerator = this.tlSCbxFontVN.Items.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							ComboboxItem comboboxItem = (ComboboxItem)obj;
							if (comboboxItem.Text == "Times New Roman")
							{
								this.tlSCbxFontVN.SelectedItem = comboboxItem;
								break;
							}
						}
						goto IL_E9;
					}
				}
				foreach (object obj2 in this.tlSCbxFontVN.Items)
				{
					ComboboxItem comboboxItem2 = (ComboboxItem)obj2;
					if (comboboxItem2.Text == this.prD.LoaiSoData.fnameVN)
					{
						this.tlSCbxFontVN.SelectedItem = comboboxItem2;
						break;
					}
				}
			}
			IL_E9:
			foreach (object obj3 in this.tlSCbxFontVNSize.Items)
			{
				float num = (float)obj3;
				if (num == this.prD.LoaiSoData.fsizeVN)
				{
					this.tlSCbxFontVNSize.SelectedItem = num;
					break;
				}
			}
			foreach (object obj4 in this.tlSCbxFontCNSize.Items)
			{
				float num2 = (float)obj4;
				if (num2 == this.prD.LoaiSoData.fsizeCN)
				{
					this.tlSCbxFontCNSize.SelectedItem = num2;
					break;
				}
			}
			this.cbxVNLeft.Checked = !string.IsNullOrEmpty(this.prD.LoaiSoData.VNAlign);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000BA9C File Offset: 0x00009C9C
		private void loadCBXLoaiSo()
		{
			string[] files = Directory.GetFiles(Util.getDataPath, "*.bibe");
			if (files.Length == 0)
			{
				throw new Exception("Không tìm thấy file loại sớ nào, xin hãy cài lại phần mềm");
			}
			string path = files[0];
			if (File.Exists(Util.getDataPath + Program.Stg.LoaiSo + ".bibe"))
			{
				path = Util.getDataPath + Program.Stg.LoaiSo + ".bibe";
			}
			else if (File.Exists(Util.getDataPath + Program.Stg.LoaiSo + ".cus"))
			{
				path = Util.getDataPath + Program.Stg.LoaiSo + ".cus";
			}
			if (File.Exists(path))
			{
				string text = Path.GetFileNameWithoutExtension(path);
				this.tlSBtnLoaiSo.Tag = text;
				this.prD.LoaiSo = text;
				LongSoData longSo = LePhat.getLongSo(text);
				if (longSo != null && !string.IsNullOrEmpty(longSo.TenSo))
				{
					text = longSo.TenSo;
				}
				this.tlSBtnLoaiSo.Text = text;
				this.setDefaultByLoaiSo();
				this.ReLoad();
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000BBA0 File Offset: 0x00009DA0
		private void loadCBXFontStyle()
		{
			this.tlSCbxFontVNStyle.Items.Add(new ComboboxItem("Thường", FontStyle.Regular));
			this.tlSCbxFontVNStyle.Items.Add(new ComboboxItem("Đậm", FontStyle.Bold));
			this.tlSCbxFontVNStyle.Items.Add(new ComboboxItem("Ngiêng", FontStyle.Italic));
			this.tlSCbxFontVNStyle.SelectedIndex = 1;
			this.setWidthCombobox(this.tlSCbxFontVNStyle);
			this.tlSCbxFontCNStyle.Items.Add(new ComboboxItem("Thường", FontStyle.Regular));
			this.tlSCbxFontCNStyle.Items.Add(new ComboboxItem("Đậm", FontStyle.Bold));
			this.tlSCbxFontCNStyle.Items.Add(new ComboboxItem("Ngiêng", FontStyle.Italic));
			this.tlSCbxFontCNStyle.SelectedIndex = 1;
			this.setWidthCombobox(this.tlSCbxFontCNStyle);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000BCA4 File Offset: 0x00009EA4
		private void loadCBXFontSize()
		{
			for (float num = 9f; num < 100f; num += 1f)
			{
				this.tlSCbxFontVNSize.Items.Add(num);
				this.tlSCbxFontCNSize.Items.Add(num);
			}
			this.tlSCbxFontVNSize.SelectedIndex = 4;
			this.tlSCbxFontCNSize.SelectedIndex = 12;
			this.setWidthCombobox1(this.tlSCbxFontVNSize);
			this.setWidthCombobox1(this.tlSCbxFontCNSize);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000BD28 File Offset: 0x00009F28
		private void setWidthCombobox(ToolStripComboBox cbx)
		{
			cbx.DropDownWidth = cbx.Items.Cast<ComboboxItem>().Max((ComboboxItem x) => TextRenderer.MeasureText(x.Text, cbx.Font).Width);
			if (100 < cbx.DropDownWidth)
			{
				cbx.Width = Convert.ToInt32((double)cbx.DropDownWidth * 0.7);
				return;
			}
			cbx.Width = ((cbx.DropDownWidth < 50) ? 50 : cbx.DropDownWidth);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000BDD0 File Offset: 0x00009FD0
		private void setWidthCombobox1(ToolStripComboBox cbx)
		{
			cbx.DropDownWidth = cbx.Items.Cast<float>().Max((float x) => TextRenderer.MeasureText(x.ToString(), cbx.Font).Width);
			if (100 < cbx.DropDownWidth)
			{
				cbx.Width = Convert.ToInt32((double)cbx.DropDownWidth * 0.7);
				return;
			}
			cbx.Width = ((cbx.DropDownWidth < 65) ? 65 : cbx.DropDownWidth);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000BE78 File Offset: 0x0000A078
		private void tlSBtnInputKey_Click(object sender, EventArgs e)
		{
			try
			{
				if (FrmPreview.CusInfo == null)
				{
					if (new FrmKeyInput().ShowDialog(this) == DialogResult.OK)
					{
						this.refreshTitle();
					}
				}
				else
				{
					new FrmKeyRequest(FrmPreview.CusInfo).ShowDialog();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000BECC File Offset: 0x0000A0CC
		private void refreshTitle()
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				string str = "Phiên bản miễn phí";
				FrmPreview.CusInfo = null;
				string text = ExchangeData.CheckKeyOnline(Util.GetComputerIMEI(), ref FrmPreview.CusInfo);
				if (!string.IsNullOrEmpty(text))
				{
					MessageBox.Show(text, Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				if (FrmPreview.CusInfo != null && FrmPreview.CusInfo.StartDtime != default(DateTime))
				{
					if (36520 < (FrmPreview.CusInfo.EndDtime - FrmPreview.CusInfo.StartDtime).Days)
					{
						str = "Bản quyền trọn đời";
					}
					else
					{
						str = "Ngày hết hạn " + UtilModel.ConvertDate2String(FrmPreview.CusInfo.EndDtime) + " " + text;
					}
					this.tlSBtnInputKey.Text = FrmPreview.CusInfo.CusKey;
					if (!string.IsNullOrEmpty(FrmPreview.CusInfo.Action) && !FrmPreview.CusInfo.Action.Contains("LackInfo:"))
					{
						this.tlSBtnInputKey.Text = FrmPreview.CusInfo.CusKey + " " + FrmPreview.CusInfo.Action;
					}
				}
				this.Text = "BiBe.vn - " + this.getVersion + " - Phần mềm viết sớ - " + str;
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600009D RID: 157 RVA: 0x0000C038 File Offset: 0x0000A238
		private string getVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000C050 File Offset: 0x0000A250
		private void timerNotifyUpdate_Tick(object sender, EventArgs e)
		{
			if (!this.uHasNewVersionNote1.Visible && this.hasFileUpdate())
			{
				this.uHasNewVersionNote1.Left = base.Width - (this.uHasNewVersionNote1.Width + 21);
				this.uHasNewVersionNote1.Top = 5;
				this.uHasNewVersionNote1.ShowNotification(this.getVersion);
			}
			this.uHasNewVersionNote1.FlashColor();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000C0BC File Offset: 0x0000A2BC
		private bool hasFileUpdate()
		{
			string[] files = Directory.GetFiles(Util.getUpdatePath);
			foreach (string text in files)
			{
				if (text.Contains("UpdateBibe.exe"))
				{
					File.Delete(text);
				}
			}
			return files != null & files.Length != 0;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000C108 File Offset: 0x0000A308
		private void tlSBtnPrint_Click(object sender, EventArgs e)
		{
			try
			{
				if (new Valid().Right(FrmPreview.CusInfo, new Action(this.refreshTitle), this))
				{
					this.prD.Print();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000C15C File Offset: 0x0000A35C
		private void tlSBtnPrintAll_Click(object sender, EventArgs e)
		{
			try
			{
				if (new Valid().Right(FrmPreview.CusInfo, new Action(this.refreshTitle), this))
				{
					FrmPersonSelectPrint frmPersonSelectPrint = new FrmPersonSelectPrint();
					if (frmPersonSelectPrint.ShowDialog(this) == DialogResult.OK)
					{
						this.printAll(frmPersonSelectPrint.SelectedSoNos);
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000C1C0 File Offset: 0x0000A3C0
		private void printAll(Dictionary<int, Family> soNos)
		{
			if (MessageBox.Show("Có tổng cộng " + soNos.Count.ToString() + " Sớ sẽ được in", "Xác nhận in", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				FrmPrintProcess frmPrintProcess = new FrmPrintProcess(this.prD, soNos);
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
						this.setInfo("Sớ bị lỗi" + Environment.NewLine + string.Join<int>(", ", frmPrintProcess.SoNosError.ToArray()));
						MessageBox.Show(frmPrintProcess.SoNosError.Count.ToString() + " Sớ bị lỗi" + Environment.NewLine + string.Join<int>(", ", frmPrintProcess.SoNosError.ToArray()), Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					MessageBox.Show("Hoàn thành xong lệnh in", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000C2C4 File Offset: 0x0000A4C4
		private void printMulti()
		{
			try
			{
				if (new Valid().Right(FrmPreview.CusInfo, new Action(this.refreshTitle), this))
				{
					FrmPrintNo frmPrintNo = new FrmPrintNo();
					if (frmPrintNo.ShowDialog(this) == DialogResult.OK)
					{
						for (int i = 0; i < frmPrintNo.no; i++)
						{
							this.prD.Print();
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000C338 File Offset: 0x0000A538
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == (Keys)131162)
			{
				this.tlSBtnUndo_Click(null, null);
				return true;
			}
			if (keyData == (Keys)131161)
			{
				this.tlSBtnRedo_Click(null, null);
				return true;
			}
			if (keyData == (Keys)131152)
			{
				this.printMulti();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000C378 File Offset: 0x0000A578
		private void tlSBtnUndo_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.unre.CanUndo)
				{
					LePhat.setLongSoData(this.unre.Undo(this.prD.LoaiSoData));
					this.ReLoad();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000C3CC File Offset: 0x0000A5CC
		private void tlSBtnRedo_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.unre.CanRedo)
				{
					LePhat.setLongSoData(this.unre.Redo(this.prD.LoaiSoData));
					this.ReLoad();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000C420 File Offset: 0x0000A620
		private void tlSBtnLoaiSo_Click(object sender, EventArgs e)
		{
			try
			{
				string cusKey = "";
				if (FrmPreview.CusInfo != null)
				{
					cusKey = FrmPreview.CusInfo.CusKey;
				}
				if (this.lSL == null || this.lSL.Count == 0)
				{
					this.lSL = ExchangeLongSo.getLongSo(cusKey, ref this.error);
				}
				FrmDownloadLoaiSo frmDownloadLoaiSo = new FrmDownloadLoaiSo(this.lSL, this.error);
				if (frmDownloadLoaiSo.ShowDialog(this) == DialogResult.OK)
				{
					string fname = frmDownloadLoaiSo.FName;
					Program.Stg.LoaiSo = fname;
					this.loadCBXLoaiSo();
				}
				this.setDefaultByLoaiSo();
				this.ReLoad();
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000C4C8 File Offset: 0x0000A6C8
		private void tlSCbxFontCN_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.setFontCN();
			this.ReLoad();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000C4D6 File Offset: 0x0000A6D6
		private void tlSCbxFontVN_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.setFontVN();
			this.ReLoad();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000C4E4 File Offset: 0x0000A6E4
		private void setFontVN()
		{
			try
			{
				if (!this.isFrmLoading)
				{
					if (this.tlSCbxFontVN.SelectedItem == null)
					{
						MessageBox.Show("Xin hãy chọn kiểu chữ Quốc ngữ!", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						this.unre.Store(this.prD.LoaiSoData);
						if (0 < this.selectedRcTL.Count)
						{
							string text = (this.tlSCbxFontVN.SelectedItem as ComboboxItem).Text;
							using (List<CellData>.Enumerator enumerator = this.selectedRcTL.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									CellData cellData = enumerator.Current;
									CellData celLgSo = LePhat.getCelLgSo(cellData.ColNo, cellData.RowNo);
									celLgSo.fnameVN = text;
									celLgSo.fsizeVN = (float)this.tlSCbxFontVNSize.SelectedItem;
									celLgSo.fstyleVN = (int)(this.tlSCbxFontVNStyle.SelectedItem as ComboboxItem).Value;
								}
								goto IL_1CD;
							}
						}
						if (0 < this.tlSCbxFontVN.Items.Count && this.tlSCbxFontVN.SelectedItem != null)
						{
							FontStyle style = (FontStyle)(this.tlSCbxFontVNStyle.SelectedItem as ComboboxItem).Value;
							string text2 = (this.tlSCbxFontVN.SelectedItem as ComboboxItem).Text;
							this.prD.fFmlVN(text2, (float)this.tlSCbxFontVNSize.SelectedItem, style);
							if (this.prD.LoaiSoData != null)
							{
								this.prD.LoaiSoData.fnameVN = text2;
								this.prD.LoaiSoData.fsizeVN = (float)this.tlSCbxFontVNSize.SelectedItem;
								this.prD.LoaiSoData.fstyleVN = (int)(this.tlSCbxFontVNStyle.SelectedItem as ComboboxItem).Value;
							}
						}
						IL_1CD:
						LePhat.saveLongSo();
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000C700 File Offset: 0x0000A900
		private void setFontCN()
		{
			try
			{
				if (!this.isFrmLoading)
				{
					this.unre.Store(this.prD.LoaiSoData);
					if (0 < this.selectedRcTL.Count)
					{
						using (List<CellData>.Enumerator enumerator = this.selectedRcTL.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								CellData cellData = enumerator.Current;
								CellData celLgSo = LePhat.getCelLgSo(cellData.ColNo, cellData.RowNo);
								celLgSo.fnameCN = (this.tlSCbxFontCN.SelectedItem as ComboboxItem).Text;
								celLgSo.fsizeCN = (float)this.tlSCbxFontCNSize.SelectedItem;
								celLgSo.fstyleCN = (int)(this.tlSCbxFontCNStyle.SelectedItem as ComboboxItem).Value;
							}
							goto IL_1BC;
						}
					}
					if (0 < this.tlSCbxFontCN.Items.Count && this.tlSCbxFontCN.SelectedItem != null)
					{
						FontStyle style = (FontStyle)(this.tlSCbxFontCNStyle.SelectedItem as ComboboxItem).Value;
						string pNf = (this.tlSCbxFontCN.SelectedItem as ComboboxItem).Value as string;
						this.prD.fFmlCN(pNf, (float)this.tlSCbxFontCNSize.SelectedItem, style);
						if (this.prD.LoaiSoData != null)
						{
							this.prD.LoaiSoData.fnameCN = (this.tlSCbxFontCN.SelectedItem as ComboboxItem).Text;
							this.prD.LoaiSoData.fsizeCN = (float)this.tlSCbxFontCNSize.SelectedItem;
							this.prD.LoaiSoData.fstyleCN = (int)(this.tlSCbxFontCNStyle.SelectedItem as ComboboxItem).Value;
						}
					}
					IL_1BC:
					LePhat.saveLongSo();
					this.fntCN = null;
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000C4C8 File Offset: 0x0000A6C8
		private void tlSCbxFontCNStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.setFontCN();
			this.ReLoad();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000C4D6 File Offset: 0x0000A6D6
		private void tlSCbxFontVNStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.setFontVN();
			this.ReLoad();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000C4C8 File Offset: 0x0000A6C8
		private void tlSCbxFontCNSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.setFontCN();
			this.ReLoad();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000C4D6 File Offset: 0x0000A6D6
		private void tlSCbxFontVNSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.setFontVN();
			this.ReLoad();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000C914 File Offset: 0x0000AB14
		private void ReLoad()
		{
			try
			{
				if (!this.isFrmLoading && this.prD.LoaiSoData != null)
				{
					this.prD.LongSoLocation.Clear();
					this.prD.IsPrintMaSo = this.ckxMaSo.Checked;
					this.prD.LoaiSoData.Language = this.getNgonNgu();
					float num = (float)(this.pBx.Parent.Height - 21) / (float)this.prD.LoaiSoData.PageHeight;
					if (this.prD.scaleFactor == 1f || this.prD.scaleFactor < num)
					{
						this.prD.scaleFactor = num;
					}
					if (this.pBx.Image != null)
					{
						this.pBx.Image.Dispose();
					}
					this.pBx.Image = this.prD.PreView();
					this.drawOneSelectedCel(null);
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
			finally
			{
				this.hideTxtPnl();
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000CA30 File Offset: 0x0000AC30
		private void pBx_MouseWheel(object sender, MouseEventArgs e)
		{
			float num = this.prD.scaleFactor + (float)e.Delta * 0.00024999998f;
			if (e.Delta < 0 && num < (float)(this.pBx.Parent.Height - 22) / (float)this.prD.LoaiSoData.PageHeight)
			{
				return;
			}
			if (1f < num)
			{
				return;
			}
			this.prD.scaleFactor = num;
			this.ReLoad();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000CAA8 File Offset: 0x0000ACA8
		private void pBx_MouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Left && 0 < this.selectedRcTL.Count)
				{
					if (this.MouseMode == "move")
					{
						Graphics graphics = this.pBx.CreateGraphics();
						this.pBx.Refresh();
						RectangleF value = this.prD.RangeSelected(this.selectedRcTL);
						value.X = (float)e.X - this.selectedRcTL[0].Rct.Width / 2f;
						value.Y = (float)e.Y - this.selectedRcTL[0].Rct.Height / 2f;
						graphics.DrawRectangle(Pens.Gold, Rectangle.Round(value));
					}
					else
					{
						bool flag = false;
						foreach (CellData cellData in this.selectedRcTL)
						{
							if (this.isSelectedExist(cellData.Rct, e.X, e.Y))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							CellData selectedReg = this.getSelectedReg(e.X, e.Y);
							if (selectedReg != null)
							{
								this.selectedRcTL.Add(selectedReg);
								this.prD.DrawRangeSelected(this.pBx, selectedReg.Rct);
							}
						}
					}
				}
				else if (e.Button == MouseButtons.None)
				{
					if (this.isMoveOnSelected(e.X, e.Y))
					{
						this.pBx.Cursor = Cursors.SizeAll;
					}
					else
					{
						this.pBx.Cursor = Cursors.Default;
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000CC8C File Offset: 0x0000AE8C
		private bool isMoveOnSelected(int x, int y)
		{
			if (0 < this.selectedRcTL.Count)
			{
				RectangleF rectangleF = this.prD.RangeSelected(this.selectedRcTL);
				if ((Math.Abs(rectangleF.Top - (float)y) < 3f && rectangleF.Left < (float)x && (float)x < rectangleF.Right) || (Math.Abs(rectangleF.Bottom - (float)y) < 3f && rectangleF.Left < (float)x && (float)x < rectangleF.Right) || (Math.Abs(rectangleF.Left - (float)x) < 3f && rectangleF.Top < (float)y && (float)y < rectangleF.Bottom) || (Math.Abs(rectangleF.Right - (float)x) < 3f && rectangleF.Top < (float)y && (float)y < rectangleF.Bottom))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000CD74 File Offset: 0x0000AF74
		private void pBx_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Left && this.pBx.Cursor == Cursors.SizeAll)
				{
					this.MouseMode = "move";
				}
				else
				{
					if (this.isEditing)
					{
						this.EndEdit();
					}
					CellData selectedReg = this.getSelectedReg(e.X, e.Y);
					try
					{
						this.isFrmLoading = true;
						foreach (object obj in this.tlSCbxFontVN.Items)
						{
							ComboboxItem comboboxItem = (ComboboxItem)obj;
							if (comboboxItem.Text == this.prD.LoaiSoData.fnameVN)
							{
								this.tlSCbxFontVN.SelectedItem = comboboxItem;
								break;
							}
						}
						foreach (object obj2 in this.tlSCbxFontVNSize.Items)
						{
							float num = (float)obj2;
							if (num == this.prD.LoaiSoData.fsizeVN)
							{
								this.tlSCbxFontVNSize.SelectedItem = num;
								break;
							}
						}
						this.tlSCbxFontVNStyle.SelectedIndex = this.prD.LoaiSoData.fstyleVN;
						foreach (object obj3 in this.tlSCbxFontCN.Items)
						{
							ComboboxItem comboboxItem2 = (ComboboxItem)obj3;
							if (comboboxItem2.Text == this.prD.LoaiSoData.fnameCN)
							{
								this.tlSCbxFontCN.SelectedItem = comboboxItem2;
								break;
							}
						}
						foreach (object obj4 in this.tlSCbxFontCNSize.Items)
						{
							float num2 = (float)obj4;
							if (num2 == this.prD.LoaiSoData.fsizeCN)
							{
								this.tlSCbxFontCNSize.SelectedItem = num2;
								break;
							}
						}
						this.tlSCbxFontCNStyle.SelectedIndex = this.prD.LoaiSoData.fstyleCN;
						if (selectedReg == null && 0 < this.selectedRcTL.Count)
						{
							foreach (CellData cellData in this.selectedRcTL)
							{
								this.prD.DrawRangeSelected(this.pBx, cellData.Rct);
							}
							this.selectedRcTL.Clear();
						}
						else if (selectedReg != null)
						{
							foreach (object obj5 in this.tlSCbxFontVN.Items)
							{
								ComboboxItem comboboxItem3 = (ComboboxItem)obj5;
								if (comboboxItem3.Text == selectedReg.fnameVN)
								{
									this.tlSCbxFontVN.SelectedItem = comboboxItem3;
									break;
								}
							}
							foreach (object obj6 in this.tlSCbxFontVNSize.Items)
							{
								float num3 = (float)obj6;
								if (num3 == selectedReg.fsizeVN)
								{
									this.tlSCbxFontVNSize.SelectedItem = num3;
									break;
								}
							}
							foreach (object obj7 in this.tlSCbxFontVNStyle.Items)
							{
								ComboboxItem comboboxItem4 = (ComboboxItem)obj7;
								if (comboboxItem4.Value.Equals((FontStyle)selectedReg.fstyleVN))
								{
									this.tlSCbxFontVNStyle.SelectedItem = comboboxItem4;
									break;
								}
							}
							foreach (object obj8 in this.tlSCbxFontCN.Items)
							{
								ComboboxItem comboboxItem5 = (ComboboxItem)obj8;
								if (comboboxItem5.Text == selectedReg.fnameCN)
								{
									this.tlSCbxFontCN.SelectedItem = comboboxItem5;
									break;
								}
							}
							foreach (object obj9 in this.tlSCbxFontCNSize.Items)
							{
								float num4 = (float)obj9;
								if (num4 == selectedReg.fsizeCN)
								{
									this.tlSCbxFontCNSize.SelectedItem = num4;
									break;
								}
							}
							foreach (object obj10 in this.tlSCbxFontCNStyle.Items)
							{
								ComboboxItem comboboxItem6 = (ComboboxItem)obj10;
								if (comboboxItem6.Value.Equals((FontStyle)selectedReg.fstyleCN))
								{
									this.tlSCbxFontCNStyle.SelectedItem = comboboxItem6;
									break;
								}
							}
						}
					}
					finally
					{
						this.isFrmLoading = false;
					}
					this.drawOneSelectedCel(selectedReg);
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000D3A4 File Offset: 0x0000B5A4
		private void drawOneSelectedCel(CellData cld)
		{
			if (cld == null)
			{
				if (0 < this.selectedRcTL.Count)
				{
					cld = this.selectedRcTL[0];
				}
			}
			else if (0 < this.selectedRcTL.Count)
			{
				foreach (CellData cellData in this.selectedRcTL)
				{
					this.prD.DrawRangeSelected(this.pBx, cellData.Rct);
				}
			}
			this.selectedRcTL.Clear();
			if (cld != null)
			{
				this.selectedRcTL.Add(cld);
				this.prD.DrawRangeSelected(this.pBx, cld.Rct);
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000D468 File Offset: 0x0000B668
		private void pBx_MouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				if (!this.isEditing && this.selectedRcTL.Count > 0)
				{
					CellData selectedReg = this.getSelectedReg(e.X, e.Y);
					if (selectedReg != null && this.MouseMode == "move" && this.selectedRcTL[0] != selectedReg)
					{
						this.unre.Store(this.prD.LoaiSoData);
						LePhat.delTextLongSo(this.selectedRcTL);
						int num = selectedReg.RowNo;
						foreach (CellData cellData in (from o in this.selectedRcTL
						orderby o.RowNo
						select o).ToList<CellData>())
						{
							cellData.RowNo = num;
							cellData.ColNo = selectedReg.ColNo;
							num++;
						}
						LePhat.insertTextLongSo(this.selectedRcTL);
						this.ReLoad();
					}
					if (1 >= this.selectedRcTL.Count)
					{
						this.pBx.Refresh();
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
			finally
			{
				this.MouseMode = "";
				CellData selectedCel = this.getSelectedCel();
				if (!this.isEditing && selectedCel != null)
				{
					this.txt_Focus.Left = selectedCel.X() + this.pnlLongSo.AutoScrollPosition.X + 3;
					this.txt_Focus.Top = selectedCel.Y() + (int)selectedCel.Rct.Height + this.pnlLongSo.AutoScrollPosition.Y + 3;
					this.txt_Focus.Size = new Size(1, 1);
				}
				this.txt_Focus.Focus();
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000D684 File Offset: 0x0000B884
		private void pBx_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				CellData selectedCel = this.getSelectedCel();
				if (selectedCel != null)
				{
					this.BeginEdit(selectedCel.Text(true), true);
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000B880 File Offset: 0x00009A80
		private void ckxMaSo_CheckedChanged(object sender, EventArgs e)
		{
			this.ReLoad();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000D6C4 File Offset: 0x0000B8C4
		private void cbxChuViet_CheckedChanged(object sender, EventArgs e)
		{
			this.selectedRcTL.Clear();
			if (this.cbxChuViet.Checked)
			{
				if (this.cbxChuTrung.Checked)
				{
					this.cbxChuTrung.Checked = false;
				}
				if (this.cbxSongNgu.Checked)
				{
					this.cbxSongNgu.Checked = false;
				}
				if (4 <= this.tlSCbxFontVNSize.Items.Count)
				{
					this.tlSCbxFontVNSize.SelectedIndex = 4;
				}
				this.ReLoad();
				this.cbxVNLeft.Location = this.pnlAlign.Location;
			}
			this.tlSLblKieuChuCN.Visible = !this.cbxChuViet.Checked;
			this.tlSCbxFontCN.Visible = !this.cbxChuViet.Checked;
			this.tlSCbxFontCNSize.Visible = !this.cbxChuViet.Checked;
			this.tlSCbxFontCNStyle.Visible = !this.cbxChuViet.Checked;
			this.cbxVNLeft.Visible = this.cbxChuViet.Checked;
			this.cbxVNLeft.Checked = !string.IsNullOrEmpty(this.prD.LoaiSoData.VNAlign);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000D7F4 File Offset: 0x0000B9F4
		private void cbxChuTrung_CheckedChanged(object sender, EventArgs e)
		{
			this.selectedRcTL.Clear();
			if (this.cbxChuTrung.Checked)
			{
				if (this.cbxChuViet.Checked)
				{
					this.cbxChuViet.Checked = false;
				}
				if (this.cbxSongNgu.Checked)
				{
					this.cbxSongNgu.Checked = false;
				}
				this.ReLoad();
			}
			this.tlSLblKieuChuVN.Visible = !this.cbxChuTrung.Checked;
			this.tlSCbxFontVN.Visible = !this.cbxChuTrung.Checked;
			this.tlSCbxFontVNSize.Visible = !this.cbxChuTrung.Checked;
			this.tlSCbxFontVNStyle.Visible = !this.cbxChuTrung.Checked;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000D8B8 File Offset: 0x0000BAB8
		private void cbxSongNgu_CheckedChanged(object sender, EventArgs e)
		{
			this.selectedRcTL.Clear();
			if (this.cbxSongNgu.Checked)
			{
				if (this.cbxChuViet.Checked)
				{
					this.cbxChuViet.Checked = false;
				}
				if (this.cbxChuTrung.Checked)
				{
					this.cbxChuTrung.Checked = false;
				}
				this.ReLoad();
			}
			this.tlSLblKieuChuCN.Visible = true;
			this.tlSCbxFontCN.Visible = true;
			this.tlSCbxFontCNSize.Visible = true;
			this.tlSCbxFontCNStyle.Visible = true;
			this.tlSLblKieuChuVN.Visible = true;
			this.tlSCbxFontVN.Visible = true;
			this.tlSCbxFontVNSize.Visible = true;
			this.tlSCbxFontVNStyle.Visible = true;
			this.pnlAlign.Visible = this.cbxSongNgu.Checked;
			if (this.pnlAlign.Visible && !this.isFrmLoading)
			{
				string songNguAlign = this.prD.LoaiSoData.SongNguAlign;
				if (songNguAlign == "top")
				{
					this.rbtnTop.Checked = true;
					return;
				}
				if (songNguAlign == "right")
				{
					this.rbtnRight.Checked = true;
					return;
				}
				if (songNguAlign == "left")
				{
					this.rbtnLeft.Checked = true;
					return;
				}
				this.rbtnBottom.Checked = true;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000DA0D File Offset: 0x0000BC0D
		private void rbtnTop_CheckedChanged(object sender, EventArgs e)
		{
			this.prD.LoaiSoData.SongNguAlign = this.getSongNguAlign();
			this.ReLoad();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000DA2C File Offset: 0x0000BC2C
		private void cbxVNLeft_CheckedChanged(object sender, EventArgs e)
		{
			this.prD.LoaiSoData.VNAlign = this.getVNAlign();
			if (0 < this.selectedRcTL.Count)
			{
				foreach (CellData cellData in this.selectedRcTL)
				{
					LePhat.getCelLgSo(cellData.ColNo, cellData.RowNo).alignVN = this.getVNAlign();
				}
			}
			this.ReLoad();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000DAC0 File Offset: 0x0000BCC0
		private void btnNgachSo_Click(object sender, EventArgs e)
		{
			try
			{
				new FrmNgachSo().ShowDialog(this);
				this.prD.NgachSo = "";
				this.ReLoad();
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000DB08 File Offset: 0x0000BD08
		private void btnDanhSach_Click(object sender, EventArgs e)
		{
			try
			{
				if (new Valid().Right(FrmPreview.CusInfo, new Action(this.refreshTitle), this))
				{
					new FrmDanhSach().ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000DB5C File Offset: 0x0000BD5C
		private void btnTinChu_Click(object sender, EventArgs e)
		{
			try
			{
				FrmPerson frmPerson = new FrmPerson(false, (FrmPreview.CusInfo == null) ? "" : FrmPreview.CusInfo.CusKey);
				frmPerson.Width = base.Width;
				if (frmPerson.ShowDialog(this) == DialogResult.OK)
				{
					this.prD.PagodaID = frmPerson.GetPagodaID;
					this.prD.PagodaName = frmPerson.GetPagodaName;
					Pagoda pagoda = PagodaBO.get(frmPerson.GetPagodaID);
					if (pagoda != null)
					{
						this.prD.PagodaAddress = pagoda.Address;
					}
					if (0 < frmPerson.SelectedSoNos.Count)
					{
						using (Dictionary<int, Family>.Enumerator enumerator = frmPerson.SelectedSoNos.GetEnumerator())
						{
							if (enumerator.MoveNext())
							{
								KeyValuePair<int, Family> keyValuePair = enumerator.Current;
								this.prD.Fml = keyValuePair.Value;
							}
							goto IL_D7;
						}
					}
					this.prD.Fml = null;
					IL_D7:
					LePhat.SoNo = 0;
					this.ReLoad();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000DC74 File Offset: 0x0000BE74
		private void btnSaveNewLongSo_Click(object sender, EventArgs e)
		{
			try
			{
				FrmNewLongSo frmNewLongSo = new FrmNewLongSo(this.prD.LoaiSoData);
				if (frmNewLongSo.ShowDialog(this) == DialogResult.OK)
				{
					Program.Stg.LoaiSo = frmNewLongSo.FileName;
					this.loadCBXLoaiSo();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000DCCC File Offset: 0x0000BECC
		private void btnDeleteLongSo_Click(object sender, EventArgs e)
		{
			try
			{
				string text = "LePhat";
				object tag = this.tlSBtnLoaiSo.Tag;
				if (!text.Equals(((tag != null) ? tag.ToString() : null) ?? ""))
				{
					string text2 = "LeSao";
					object tag2 = this.tlSBtnLoaiSo.Tag;
					if (!text2.Equals(((tag2 != null) ? tag2.ToString() : null) ?? ""))
					{
						string text3 = "PhucTho";
						object tag3 = this.tlSBtnLoaiSo.Tag;
						if (!text3.Equals(((tag3 != null) ? tag3.ToString() : null) ?? ""))
						{
							if (MessageBox.Show("Xin hãy xác nhận muốn xóa lòng sớ: " + this.tlSBtnLoaiSo.Text, "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								string getDataPath = Util.getDataPath;
								object tag4 = this.tlSBtnLoaiSo.Tag;
								if (File.Exists(getDataPath + ((tag4 != null) ? tag4.ToString() : null) + ".cus"))
								{
									string getDataPath2 = Util.getDataPath;
									object tag5 = this.tlSBtnLoaiSo.Tag;
									File.Delete(getDataPath2 + ((tag5 != null) ? tag5.ToString() : null) + ".cus");
								}
								string getDataPath3 = Util.getDataPath;
								object tag6 = this.tlSBtnLoaiSo.Tag;
								if (File.Exists(getDataPath3 + ((tag6 != null) ? tag6.ToString() : null) + ".bibe"))
								{
									string getDataPath4 = Util.getDataPath;
									object tag7 = this.tlSBtnLoaiSo.Tag;
									File.Delete(getDataPath4 + ((tag7 != null) ? tag7.ToString() : null) + ".bibe");
								}
								this.loadCBXLoaiSo();
							}
							return;
						}
					}
				}
				MessageBox.Show("Lòng sớ mặc định không được phép xóa!", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000DE78 File Offset: 0x0000C078
		private void btnSetupPaper_Click(object sender, EventArgs e)
		{
			try
			{
				new FrmSetupPaper(this.prD, new RefreshPbx(this.ReLoad)).ShowDialog(this);
				LePhat.saveLongSo();
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000DEC4 File Offset: 0x0000C0C4
		private void FrmPreview_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				Program.Stg.LoaiSo = (this.tlSBtnLoaiSo.Tag as string);
				Program.Stg.LongSoUserData = this.prD.LongSoUserData;
				Program.Stg.IsPrintMaSo = this.ckxMaSo.Checked;
				Program.Stg.NgonNgu = this.getNgonNgu();
				Program.Stg.Save();
				LePhat.saveLongSo();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000DF4C File Offset: 0x0000C14C
		private string getNgonNgu()
		{
			if (this.cbxChuViet.Checked)
			{
				return this.cbxChuViet.Name;
			}
			if (this.cbxChuTrung.Checked)
			{
				return this.cbxChuTrung.Name;
			}
			if (this.cbxSongNgu.Checked)
			{
				return this.cbxSongNgu.Name;
			}
			return "";
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000DFA9 File Offset: 0x0000C1A9
		private string getSongNguAlign()
		{
			if (this.rbtnTop.Checked)
			{
				return "top";
			}
			if (this.rbtnRight.Checked)
			{
				return "right";
			}
			if (this.rbtnLeft.Checked)
			{
				return "left";
			}
			return "bottom";
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000DFE9 File Offset: 0x0000C1E9
		private string getVNAlign()
		{
			if (this.cbxVNLeft.Checked)
			{
				return "left";
			}
			return "";
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000E004 File Offset: 0x0000C204
		private void loadFont()
		{
			this.bgWorker.DoWork += this.bgWorker_DoWork;
			this.bgWorker.ProgressChanged += this.bgWorker_ProgressChanged;
			this.bgWorker.RunWorkerCompleted += this.bgWorker_RunWorkerCompleted;
			this.bgWorker.WorkerReportsProgress = true;
			this.bgWorker.WorkerSupportsCancellation = true;
			this.bgWorker.RunWorkerAsync(Util.getDataPath);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000E080 File Offset: 0x0000C280
		private void setInfo(string t)
		{
			if (this.lblInfo.InvokeRequired)
			{
				this.lblInfo.Invoke(new MethodInvoker(delegate()
				{
					this.lblInfo.Text = t;
				}));
				return;
			}
			this.lblInfo.Text = t;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000E0D8 File Offset: 0x0000C2D8
		private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				string str = (string)e.Argument;
				if (!Directory.Exists(str + "fontCN"))
				{
					Directory.CreateDirectory(str + "fontCN");
				}
				if (Directory.Exists(str + "fontCN\\Temp\\"))
				{
					string[] files = Directory.GetFiles(str + "fontCN\\Temp\\");
					if (files != null)
					{
						foreach (string text in files)
						{
							if (File.Exists(text))
							{
								File.Copy(text, text.Replace("fontCN\\Temp\\", "fontCN\\"), true);
								File.Delete(text);
							}
						}
					}
				}
				string[] files2 = Directory.GetFiles(str + "fontCN", "*.ttf", SearchOption.TopDirectoryOnly);
				e.Result = files2;
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000E1B4 File Offset: 0x0000C3B4
		private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			string info = "";
			try
			{
				if (e.Cancelled)
				{
					info = "Process was cancelled";
				}
				else if (e.Error != null)
				{
					info = "There was an error running the process. The thread aborted";
				}
				else
				{
					FrmPreview.<>c__DisplayClass69_0 CS$<>8__locals1 = new FrmPreview.<>c__DisplayClass69_0();
					string[] array = e.Result as string[];
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					foreach (string text in array)
					{
						CS$<>8__locals1.pfc = new PrivateFontCollection();
						CS$<>8__locals1.pfc.AddFontFile(text);
						IEnumerable<ComboboxItem> source = this.tlSCbxFontCN.Items.Cast<ComboboxItem>();
						Func<ComboboxItem, bool> predicate;
						if ((predicate = CS$<>8__locals1.<>9__0) == null)
						{
							predicate = (CS$<>8__locals1.<>9__0 = ((ComboboxItem cbi) => cbi.Text.Equals(CS$<>8__locals1.pfc.Families[0].Name)));
						}
						if (!source.Any(predicate))
						{
							ComboboxItem comboboxItem = new ComboboxItem(CS$<>8__locals1.pfc.Families[0].Name, text);
							this.tlSCbxFontCN.Items.Add(comboboxItem);
							if (CS$<>8__locals1.pfc.Families[0].Name == "CN-Khai")
							{
								this.tlSCbxFontCN.SelectedItem = comboboxItem;
							}
							dictionary.Add(CS$<>8__locals1.pfc.Families[0].Name, text);
						}
					}
					this.prD.fontFCN = dictionary;
					CS$<>8__locals1.fts = FontFamily.Families;
					int j;
					int i;
					for (i = 0; i < CS$<>8__locals1.fts.Length; i = j + 1)
					{
						if (!this.tlSCbxFontVN.Items.Cast<ComboboxItem>().Any((ComboboxItem cbi) => cbi.Text.Equals(CS$<>8__locals1.fts[i].Name)))
						{
							this.tlSCbxFontVN.Items.Add(new ComboboxItem(CS$<>8__locals1.fts[i].Name, CS$<>8__locals1.fts[i].Name));
						}
						CS$<>8__locals1.fts[i] = null;
						j = i;
					}
					if (this.tlSCbxFontVN.SelectedItem == null)
					{
						foreach (object obj in this.tlSCbxFontVN.Items)
						{
							ComboboxItem comboboxItem2 = (ComboboxItem)obj;
							if (comboboxItem2.Text == "Times New Roman")
							{
								this.tlSCbxFontVN.SelectedItem = comboboxItem2;
								break;
							}
						}
					}
					if (this.tlSCbxFontVN.SelectedItem == null)
					{
						this.tlSCbxFontVN.SelectedIndex = 0;
					}
					this.setWidthCombobox(this.tlSCbxFontVN);
				}
			}
			catch (Exception ex)
			{
				this.setInfo(ex.Message + Environment.NewLine + ex.StackTrace);
			}
			finally
			{
				this.isFrmLoading = false;
				FontStyle style = (FontStyle)(this.tlSCbxFontCNStyle.SelectedItem as ComboboxItem).Value;
				string pNf = (this.tlSCbxFontCN.SelectedItem as ComboboxItem).Value as string;
				this.prD.fFmlCN(pNf, (float)this.tlSCbxFontCNSize.SelectedItem, style);
				FontStyle style2 = (FontStyle)(this.tlSCbxFontVNStyle.SelectedItem as ComboboxItem).Value;
				string text2 = (this.tlSCbxFontVN.SelectedItem as ComboboxItem).Value as string;
				this.prD.fFmlVN(text2, (float)this.tlSCbxFontVNSize.SelectedItem, style2);
				this.ReLoad();
				this.notifyYear(info);
				if (this.welcome != null)
				{
					this.welcome.Close();
					this.welcome.Dispose();
					this.welcome = null;
				}
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000E5BC File Offset: 0x0000C7BC
		private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.setInfo(e.ProgressPercentage.ToString() + "%");
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000E5E7 File Offset: 0x0000C7E7
		private void notifyYear(string info)
		{
			if (!this.prD.HasYear())
			{
				info = "Xin hãy ấn chuột phải chọn 'Thêm năm' để tính tuổi không bị sai";
			}
			this.setInfo(info);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000E604 File Offset: 0x0000C804
		private void TSMItemThemChuSauTinChu_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.prD.LoaiSoData.TinChu == null)
				{
					this.prD.LoaiSoData.TinChu = new ThietLapTinChu();
				}
				if (new FrmThietLapTinChu(this.prD.LoaiSoData.TinChu).ShowDialog(this) == DialogResult.OK)
				{
					LePhat.saveLongSo();
					this.prD.clearLongSo();
					this.ReLoad();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000E688 File Offset: 0x0000C888
		private void TSMItemPaste_Click(object sender, EventArgs e)
		{
			try
			{
				this.Paste();
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000E6B4 File Offset: 0x0000C8B4
		private void TSMItemAddRow_Click(object sender, EventArgs e)
		{
			try
			{
				CellData selectedCel = this.getSelectedCel();
				if (selectedCel != null)
				{
					this.unre.Store(this.prD.LoaiSoData);
					LePhat.longSoAddRow(selectedCel.RowNo);
					this.ReLoad();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000E710 File Offset: 0x0000C910
		private void TSMItemAddCol_Click(object sender, EventArgs e)
		{
			try
			{
				CellData selectedCel = this.getSelectedCel();
				if (selectedCel != null)
				{
					this.unre.Store(this.prD.LoaiSoData);
					LePhat.longSoAddCol(selectedCel.ColNo);
					this.ReLoad();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000E76C File Offset: 0x0000C96C
		private void TSMItemDelRow_Click(object sender, EventArgs e)
		{
			try
			{
				CellData selectedCel = this.getSelectedCel();
				if (selectedCel != null)
				{
					this.unre.Store(this.prD.LoaiSoData);
					LePhat.longSoDelRow(selectedCel.RowNo);
					this.ReLoad();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000E7C8 File Offset: 0x0000C9C8
		private void TSMItemDelCol_Click(object sender, EventArgs e)
		{
			try
			{
				CellData selectedCel = this.getSelectedCel();
				if (selectedCel != null)
				{
					this.unre.Store(this.prD.LoaiSoData);
					LePhat.longSoDelCol(selectedCel.ColNo);
					this.ReLoad();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000E824 File Offset: 0x0000CA24
		private void TSMItemDelCel_Click(object sender, EventArgs e)
		{
			try
			{
				this.unre.Store(this.prD.LoaiSoData);
				LePhat.delTextLongSo(this.selectedRcTL);
				this.notifyYear("");
				this.ReLoad();
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000E87C File Offset: 0x0000CA7C
		private void TSMItemAddMua_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("@mua", "Mùa");
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000E88E File Offset: 0x0000CA8E
		private void TSMItemAddYear_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("@nam", "Năm");
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000E8A0 File Offset: 0x0000CAA0
		private void TSMItemAddMonth_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("@thang", "Tháng");
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000E8B2 File Offset: 0x0000CAB2
		private void TSMItemAddDay_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("@ngay", "Ngày");
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000E8C4 File Offset: 0x0000CAC4
		private void TSMItemAddNoiC_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("@noicung", "Nơi cúng");
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000E8D6 File Offset: 0x0000CAD6
		private void TSMItemAddAdress_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("@diachiyvu", "Địa chỉ");
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000E8E8 File Offset: 0x0000CAE8
		private void TSMItemAddNgachSo_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("$ngachso", "Ngạch sớ");
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000E8FA File Offset: 0x0000CAFA
		private void TSMItemAddTinChu_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("$Tinchu", "Tín chủ");
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000E90C File Offset: 0x0000CB0C
		private void TSMItemAddGiaChu_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("$Giachu", "Gia chủ");
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000E91E File Offset: 0x0000CB1E
		private void TSMItemAddHuongLinh_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("$hlinhten", "Hương linh");
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000E930 File Offset: 0x0000CB30
		private void TSMItemAddHLinhSinh_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("$hlinhsinh", "Hương linh");
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000E942 File Offset: 0x0000CB42
		private void TSMItemAddHLinhMat_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("$hlinhmat", "Hương linh");
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000E954 File Offset: 0x0000CB54
		private void TSMItemAddHLinhTho_Click(object sender, EventArgs e)
		{
			this.addTextLongSo("$hlinhtho", "Hưởng thọ");
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000E968 File Offset: 0x0000CB68
		private void addTextLongSo(string bm, string t)
		{
			try
			{
				CellData selectedCel = this.getSelectedCel();
				if (selectedCel != null)
				{
					this.unre.Store(this.prD.LoaiSoData);
					LePhat.setTextLongSo(selectedCel.ColNo, selectedCel.RowNo, bm);
					LePhat.setTextLongSo(selectedCel.ColNo, selectedCel.RowNo, t);
					this.notifyYear("");
					this.ReLoad();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000E9E8 File Offset: 0x0000CBE8
		private void showSuggest(CellData cld)
		{
			this.cbxSuggest.Items.Clear();
			object value = cld.Value;
			string text = (((value != null) ? value.ToString() : null) ?? "").ToLower();
			uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
			if (num <= 2078162603U)
			{
				if (num <= 845036753U)
				{
					if (num != 194293210U)
					{
						if (num != 519365700U)
						{
							if (num != 845036753U)
							{
								return;
							}
							if (!(text == "@nam"))
							{
								return;
							}
							this.cbxSuggest.Items.Add(new FrmPreview.ComboboxData(DateTime.Now.AddYears(-1).Year.ToString(), text));
							this.cbxSuggest.Items.Add(new FrmPreview.ComboboxData(DateTime.Now.Year.ToString(), text));
							this.cbxSuggest.Items.Add(new FrmPreview.ComboboxData(DateTime.Now.AddYears(1).Year.ToString(), text));
							this.showCBX(cld, text);
							return;
						}
						else if (!(text == "$Giachu"))
						{
							return;
						}
					}
					else if (!(text == "$hlinhsinh"))
					{
						return;
					}
				}
				else if (num != 1112591429U)
				{
					if (num != 1454330518U)
					{
						if (num != 2078162603U)
						{
							return;
						}
						if (!(text == "$hlinhten"))
						{
							return;
						}
					}
					else if (!(text == "$hlinhmat"))
					{
						return;
					}
				}
				else
				{
					if (!(text == "@thang"))
					{
						return;
					}
					for (int i = 1; i < 13; i++)
					{
						this.cbxSuggest.Items.Add(new FrmPreview.ComboboxData(i.ToString(), text));
					}
					this.showCBX(cld, text);
					return;
				}
			}
			else if (num <= 3054535759U)
			{
				if (num != 2441045416U)
				{
					if (num != 2596150221U)
					{
						if (num != 3054535759U)
						{
							return;
						}
						text == "@diachiyvu";
						return;
					}
					else if (!(text == "$hlinhtho"))
					{
						return;
					}
				}
				else
				{
					if (!(text == "@noicung"))
					{
						return;
					}
					string text2 = this.prD.LongSoUserData.ContainsKey(text) ? this.prD.LongSoUserData[text] : "";
					if (string.IsNullOrEmpty(text2))
					{
						text2 = this.prD.PagodaName;
					}
					this.BeginEdit(text2, false);
					return;
				}
			}
			else if (num <= 3506253560U)
			{
				if (num != 3206040392U)
				{
					if (num != 3506253560U)
					{
						return;
					}
					if (!(text == "$Tinchu"))
					{
						return;
					}
				}
				else
				{
					if (!(text == "@mua"))
					{
						return;
					}
					this.cbxSuggest.Items.Add(new FrmPreview.ComboboxData("Xuân", text));
					this.cbxSuggest.Items.Add(new FrmPreview.ComboboxData("Hạ", text));
					this.cbxSuggest.Items.Add(new FrmPreview.ComboboxData("Thu", text));
					this.cbxSuggest.Items.Add(new FrmPreview.ComboboxData("Đông", text));
					this.showCBX(cld, text);
					return;
				}
			}
			else if (num != 3657011626U)
			{
				if (num != 3689500426U)
				{
					return;
				}
				if (!(text == "$ngachso"))
				{
					return;
				}
				this.btnNgachSo_Click(null, null);
				return;
			}
			else
			{
				if (!(text == "@ngay"))
				{
					return;
				}
				for (int j = 1; j < 31; j++)
				{
					this.cbxSuggest.Items.Add(new FrmPreview.ComboboxData(j.ToString(), text));
				}
				this.showCBX(cld, text);
				return;
			}
			this.btnTinChu_Click(null, null);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000ED98 File Offset: 0x0000CF98
		private void showCBX(CellData cld, object bookMark)
		{
			this.cbxSuggest.Top = cld.Y() + this.pnlLongSo.AutoScrollPosition.Y + 5;
			this.cbxSuggest.Left = cld.X() + this.pnlLongSo.AutoScrollPosition.X + 5;
			this.cbxSuggest.Visible = true;
			this.cbxSuggest.Tag = bookMark;
			this.cbxSuggest.Focus();
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000EE18 File Offset: 0x0000D018
		private void cbxSuggest_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				FrmPreview.ComboboxData comboboxData = this.cbxSuggest.SelectedItem as FrmPreview.ComboboxData;
				if (comboboxData != null)
				{
					if ("@nam".Equals(comboboxData.bookMark))
					{
						string a = DateTime.Now.AddYears(-1).Year.ToString();
						string a2 = DateTime.Now.Year.ToString();
						string a3 = DateTime.Now.AddYears(1).Year.ToString();
						if (a == comboboxData.vn)
						{
							this.prD.IsNextYear = Year.Pre;
						}
						else if (a2 == comboboxData.vn)
						{
							this.prD.IsNextYear = Year.Cur;
						}
						else if (a3 == comboboxData.vn)
						{
							this.prD.IsNextYear = Year.Nex;
						}
						comboboxData.vn = LePhat.getNam(comboboxData.vn);
					}
					else if ("@thang".Equals(comboboxData.bookMark))
					{
						comboboxData.vn = LePhat.getChuNomMM(comboboxData.vn);
					}
					else
					{
						comboboxData.vn = LePhat.getChuNomDD(comboboxData.vn);
					}
					if (this.prD.LongSoUserData.ContainsKey(comboboxData.bookMark))
					{
						this.prD.LongSoUserData[comboboxData.bookMark] = comboboxData.vn;
					}
					else
					{
						this.prD.LongSoUserData.Add(comboboxData.bookMark, comboboxData.vn);
					}
					this.ReLoad();
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
			finally
			{
				this.hideTxtPnl();
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000EFE0 File Offset: 0x0000D1E0
		private CellData getSelectedCel()
		{
			if (0 < this.selectedRcTL.Count)
			{
				return this.selectedRcTL[0];
			}
			return null;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000F000 File Offset: 0x0000D200
		private CellData getCel(int rowKey, int colKey)
		{
			if (this.prD.LongSoLocation.ContainsKey(rowKey.ToString() + ":" + colKey.ToString()))
			{
				return this.prD.LongSoLocation[rowKey.ToString() + ":" + colKey.ToString()];
			}
			return null;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000F064 File Offset: 0x0000D264
		private CellData getSelectedReg(int x, int y)
		{
			foreach (KeyValuePair<string, CellData> keyValuePair in this.prD.LongSoLocation)
			{
				RectangleF rct = keyValuePair.Value.Rct;
				if (rct.Left <= (float)x && (float)x <= rct.Right && rct.Top <= (float)y && (float)y <= rct.Bottom)
				{
					return keyValuePair.Value;
				}
			}
			return null;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000F0FC File Offset: 0x0000D2FC
		private bool isCellBookmark(CellData cld)
		{
			object value = cld.Value;
			if (!(((value != null) ? value.ToString() : null) ?? "").Contains("@"))
			{
				object value2 = cld.Value;
				if (!(((value2 != null) ? value2.ToString() : null) ?? "").Contains("$"))
				{
					object value3 = cld.Value;
					return (((value3 != null) ? value3.ToString() : null) ?? "").Contains("*");
				}
			}
			return true;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000F17E File Offset: 0x0000D37E
		private bool isSelectedExist(RectangleF rct, int x, int y)
		{
			return rct.Left <= (float)x && (float)x <= rct.Right && rct.Top <= (float)y && (float)y <= rct.Bottom;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000F1B4 File Offset: 0x0000D3B4
		private void BeginEdit(string t, bool isEditA)
		{
			try
			{
				this.txt_Focus.SuspendLayout();
				CellData selectedCel = this.getSelectedCel();
				if (selectedCel != null)
				{
					this.isEditing = true;
					bool flag = this.isCellBookmark(selectedCel);
					if (isEditA && flag)
					{
						this.showSuggest(selectedCel);
					}
					else
					{
						this.txt_Focus.Left = selectedCel.X() + this.pnlLongSo.AutoScrollPosition.X + 7;
						this.txt_Focus.Top = selectedCel.Y() + this.pnlLongSo.AutoScrollPosition.Y + 5;
						this.txt_Focus.Size = new Size(Math.Max(63, (int)selectedCel.Rct.Width), (int)selectedCel.Rct.Height - 2);
						this.txt_Focus.Text = t;
						this.Old_Value = this.txt_Focus.Text;
						if (this.txt_Focus.Text != "")
						{
							this.txt_Focus.SelectionStart = this.txt_Focus.Text.Length;
							this.txt_Focus.SelectionLength = 0;
						}
						this.txt_Focus.Focus();
					}
				}
			}
			finally
			{
				this.txt_Focus.ResumeLayout();
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000F30C File Offset: 0x0000D50C
		private bool EndEdit()
		{
			if (this.isEditing)
			{
				int left = this.cbxSuggest.Left;
				if (1 < this.txt_Focus.Size.Width)
				{
					string text = this.txt_Focus.Text.Trim();
					if (text.Equals(this.Old_Value))
					{
						this.CancelEdit();
						return false;
					}
					CellData selectedCel = this.getSelectedCel();
					if (selectedCel == null)
					{
						return false;
					}
					if (this.isCellBookmark(selectedCel))
					{
						string text2 = "@noicung";
						object value = selectedCel.Value;
						if (text2.Equals(((value != null) ? value.ToString() : null) ?? "", StringComparison.OrdinalIgnoreCase))
						{
							if (string.IsNullOrEmpty(text))
							{
								Dictionary<string, string> longSoUserData = this.prD.LongSoUserData;
								object value2 = selectedCel.Value;
								if (longSoUserData.ContainsKey(((value2 != null) ? value2.ToString() : null) ?? ""))
								{
									Dictionary<string, string> longSoUserData2 = this.prD.LongSoUserData;
									object value3 = selectedCel.Value;
									longSoUserData2.Remove(((value3 != null) ? value3.ToString() : null) ?? "");
								}
							}
							else
							{
								Dictionary<string, string> longSoUserData3 = this.prD.LongSoUserData;
								object value4 = selectedCel.Value;
								if (longSoUserData3.ContainsKey(((value4 != null) ? value4.ToString() : null) ?? ""))
								{
									Dictionary<string, string> longSoUserData4 = this.prD.LongSoUserData;
									object value5 = selectedCel.Value;
									longSoUserData4[((value5 != null) ? value5.ToString() : null) ?? ""] = text;
								}
								else
								{
									Dictionary<string, string> longSoUserData5 = this.prD.LongSoUserData;
									object value6 = selectedCel.Value;
									longSoUserData5.Add(((value6 != null) ? value6.ToString() : null) ?? "", text);
								}
							}
						}
						else
						{
							MessageBox.Show("Phần này tự động điền, không thể sửa", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
					else
					{
						if (!Util.IsUpper(text))
						{
							text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
						}
						this.unre.Store(this.prD.LoaiSoData);
						LePhat.setTextLongSo(selectedCel.ColNoOrg, selectedCel.RowNoOrg, text);
					}
				}
				this.ReLoad();
				return true;
			}
			return false;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000F50E File Offset: 0x0000D70E
		private void CancelEdit()
		{
			this.hideTxtPnl();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000F518 File Offset: 0x0000D718
		private void hideTxtPnl()
		{
			if (this.isFrmLoading)
			{
				return;
			}
			CellData selectedCel = this.getSelectedCel();
			if (!this.isEditing && selectedCel != null)
			{
				this.txt_Focus.Left = selectedCel.X() + this.pnlLongSo.AutoScrollPosition.X + 3;
				this.txt_Focus.Top = selectedCel.Y() + (int)selectedCel.Rct.Height + this.pnlLongSo.AutoScrollPosition.Y + 3;
			}
			this.txt_Focus.Size = new Size(1, 1);
			this.txt_Focus.Text = "";
			this.txt_Focus.Focus();
			this.pnlDicSuggest.Visible = false;
			foreach (object obj in this.pnlDicSuggest.Controls)
			{
				Control value = (Control)obj;
				this.pnlDicSuggest.Controls.Remove(value);
			}
			this.cbxSuggest.Visible = false;
			this.cbxSuggest.Items.Clear();
			this.isEditing = false;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000F658 File Offset: 0x0000D858
		private void txt_Focus_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				Keys keyCode = e.KeyCode;
				if (keyCode <= Keys.Packet)
				{
					if (keyCode == Keys.Modifiers)
					{
						goto IL_523;
					}
					switch (keyCode)
					{
					case Keys.None:
					case Keys.LButton:
					case Keys.RButton:
					case Keys.Cancel:
					case Keys.MButton:
					case Keys.XButton1:
					case Keys.XButton2:
					case Keys.LineFeed:
					case Keys.Clear:
					case Keys.ShiftKey:
					case Keys.ControlKey:
					case Keys.Menu:
					case Keys.Pause:
					case Keys.Capital:
					case Keys.KanaMode:
					case Keys.JunjaMode:
					case Keys.FinalMode:
					case Keys.HanjaMode:
					case Keys.IMEConvert:
					case Keys.IMENonconvert:
					case Keys.IMEAccept:
					case Keys.IMEModeChange:
					case Keys.Prior:
					case Keys.Select:
					case Keys.Print:
					case Keys.Execute:
					case Keys.Snapshot:
					case Keys.Insert:
					case Keys.Help:
					case Keys.LWin:
					case Keys.RWin:
					case Keys.Apps:
					case Keys.Sleep:
					case Keys.Multiply:
					case Keys.Add:
					case Keys.Separator:
					case Keys.Subtract:
					case Keys.Decimal:
					case Keys.Divide:
					case Keys.F1:
					case Keys.F3:
					case Keys.F4:
					case Keys.F5:
					case Keys.F6:
					case Keys.F7:
					case Keys.F8:
					case Keys.F9:
					case Keys.F10:
					case Keys.F11:
					case Keys.F12:
					case Keys.F13:
					case Keys.F14:
					case Keys.F15:
					case Keys.F16:
					case Keys.F17:
					case Keys.F18:
					case Keys.F19:
					case Keys.F20:
					case Keys.F21:
					case Keys.F22:
					case Keys.F23:
					case Keys.F24:
					case Keys.NumLock:
					case Keys.Scroll:
					case Keys.LShiftKey:
					case Keys.RShiftKey:
					case Keys.LControlKey:
					case Keys.RControlKey:
					case Keys.LMenu:
					case Keys.RMenu:
					case Keys.BrowserBack:
					case Keys.BrowserForward:
					case Keys.BrowserRefresh:
					case Keys.BrowserStop:
					case Keys.BrowserSearch:
					case Keys.BrowserFavorites:
					case Keys.BrowserHome:
					case Keys.VolumeMute:
					case Keys.VolumeDown:
					case Keys.VolumeUp:
					case Keys.MediaNextTrack:
					case Keys.MediaPreviousTrack:
					case Keys.MediaStop:
					case Keys.MediaPlayPause:
					case Keys.LaunchMail:
					case Keys.SelectMedia:
					case Keys.LaunchApplication1:
					case Keys.LaunchApplication2:
					case Keys.OemSemicolon:
					case Keys.Oemplus:
					case Keys.Oemcomma:
					case Keys.OemMinus:
					case Keys.OemPeriod:
					case Keys.OemQuestion:
					case Keys.Oemtilde:
						goto IL_523;
					case Keys.LButton | Keys.RButton | Keys.MButton:
					case Keys.Back:
					case Keys.Tab:
					case Keys.LButton | Keys.RButton | Keys.Back:
					case Keys.RButton | Keys.MButton | Keys.Back:
					case Keys.LButton | Keys.RButton | Keys.MButton | Keys.Back:
					case Keys.RButton | Keys.MButton | Keys.ShiftKey:
					case Keys.RButton | Keys.Back | Keys.ShiftKey:
					case Keys.Space:
					case Keys.Next:
					case Keys.End:
					case Keys.Home:
					case Keys.D0:
					case Keys.D1:
					case Keys.D2:
					case Keys.D3:
					case Keys.D4:
					case Keys.D5:
					case Keys.D6:
					case Keys.D7:
					case Keys.D8:
					case Keys.D9:
					case Keys.RButton | Keys.Back | Keys.ShiftKey | Keys.Space:
					case Keys.LButton | Keys.RButton | Keys.Back | Keys.ShiftKey | Keys.Space:
					case Keys.MButton | Keys.Back | Keys.ShiftKey | Keys.Space:
					case Keys.LButton | Keys.MButton | Keys.Back | Keys.ShiftKey | Keys.Space:
					case Keys.RButton | Keys.MButton | Keys.Back | Keys.ShiftKey | Keys.Space:
					case Keys.LButton | Keys.RButton | Keys.MButton | Keys.Back | Keys.ShiftKey | Keys.Space:
					case (Keys)64:
					case Keys.A:
					case Keys.B:
					case Keys.C:
					case Keys.D:
					case Keys.E:
					case Keys.F:
					case Keys.G:
					case Keys.H:
					case Keys.I:
					case Keys.J:
					case Keys.K:
					case Keys.L:
					case Keys.M:
					case Keys.N:
					case Keys.O:
					case Keys.P:
					case Keys.Q:
					case Keys.R:
					case Keys.S:
					case Keys.T:
					case Keys.U:
					case Keys.V:
					case Keys.W:
					case Keys.X:
					case Keys.Y:
					case Keys.Z:
					case (Keys)94:
					case Keys.NumPad0:
					case Keys.NumPad1:
					case Keys.NumPad2:
					case Keys.NumPad3:
					case Keys.NumPad4:
					case Keys.NumPad5:
					case Keys.NumPad6:
					case Keys.NumPad7:
					case Keys.NumPad8:
					case Keys.NumPad9:
					case Keys.Back | Keys.F17:
					case Keys.LButton | Keys.Back | Keys.F17:
					case Keys.RButton | Keys.Back | Keys.F17:
					case Keys.LButton | Keys.RButton | Keys.Back | Keys.F17:
					case Keys.MButton | Keys.Back | Keys.F17:
					case Keys.LButton | Keys.MButton | Keys.Back | Keys.F17:
					case Keys.RButton | Keys.MButton | Keys.Back | Keys.F17:
					case Keys.LButton | Keys.RButton | Keys.MButton | Keys.Back | Keys.F17:
					case Keys.RButton | Keys.ShiftKey | Keys.F17:
					case Keys.LButton | Keys.RButton | Keys.ShiftKey | Keys.F17:
					case Keys.MButton | Keys.ShiftKey | Keys.F17:
					case Keys.LButton | Keys.MButton | Keys.ShiftKey | Keys.F17:
					case Keys.RButton | Keys.MButton | Keys.ShiftKey | Keys.F17:
					case Keys.LButton | Keys.RButton | Keys.MButton | Keys.ShiftKey | Keys.F17:
					case Keys.Back | Keys.ShiftKey | Keys.F17:
					case Keys.LButton | Keys.Back | Keys.ShiftKey | Keys.F17:
					case Keys.RButton | Keys.Back | Keys.ShiftKey | Keys.F17:
					case Keys.LButton | Keys.RButton | Keys.Back | Keys.ShiftKey | Keys.F17:
					case Keys.MButton | Keys.Back | Keys.ShiftKey | Keys.F17:
					case Keys.LButton | Keys.MButton | Keys.Back | Keys.ShiftKey | Keys.F17:
					case Keys.RButton | Keys.MButton | Keys.Back | Keys.ShiftKey | Keys.F17:
					case Keys.LButton | Keys.RButton | Keys.MButton | Keys.Back | Keys.ShiftKey | Keys.F17:
					case Keys.Back | Keys.ShiftKey | Keys.Space | Keys.F17:
					case Keys.LButton | Keys.Back | Keys.ShiftKey | Keys.Space | Keys.F17:
						break;
					case Keys.Return:
						e.SuppressKeyPress = true;
						this.EndEdit();
						this.MoveSelection(DirectionEnum.Down);
						goto IL_523;
					case Keys.Escape:
						e.SuppressKeyPress = true;
						this.CancelEdit();
						goto IL_523;
					case Keys.Left:
						if (this.isEditing)
						{
							return;
						}
						e.SuppressKeyPress = true;
						this.EndEdit();
						this.MoveSelection(DirectionEnum.Left);
						goto IL_523;
					case Keys.Up:
						if (this.isEditing)
						{
							return;
						}
						e.SuppressKeyPress = true;
						this.EndEdit();
						this.MoveSelection(DirectionEnum.Up);
						goto IL_523;
					case Keys.Right:
						if (this.isEditing)
						{
							return;
						}
						e.SuppressKeyPress = true;
						this.EndEdit();
						this.MoveSelection(DirectionEnum.Right);
						goto IL_523;
					case Keys.Down:
						if (this.isEditing)
						{
							return;
						}
						e.SuppressKeyPress = true;
						this.EndEdit();
						this.MoveSelection(DirectionEnum.Down);
						goto IL_523;
					case Keys.Delete:
						if (this.isEditing)
						{
							return;
						}
						e.SuppressKeyPress = true;
						this.unre.Store(this.prD.LoaiSoData);
						LePhat.delTextLongSo(this.selectedRcTL);
						this.notifyYear("");
						this.ReLoad();
						goto IL_523;
					case Keys.F2:
					{
						if (this.isEditing)
						{
							goto IL_523;
						}
						e.SuppressKeyPress = true;
						CellData selectedCel = this.getSelectedCel();
						if (selectedCel == null)
						{
							return;
						}
						this.BeginEdit(selectedCel.Text(true), true);
						goto IL_523;
					}
					default:
						switch (keyCode)
						{
						case Keys.OemOpenBrackets:
						case Keys.OemPipe:
						case Keys.OemCloseBrackets:
						case Keys.OemQuotes:
						case Keys.Oem8:
						case Keys.OemBackslash:
						case Keys.ProcessKey:
						case Keys.Packet:
							goto IL_523;
						}
						break;
					}
				}
				else if (keyCode <= Keys.Shift)
				{
					if (keyCode - Keys.Attn <= 8 || keyCode - Keys.KeyCode <= 1)
					{
						goto IL_523;
					}
				}
				else if (keyCode == Keys.Control || keyCode == Keys.Alt)
				{
					goto IL_523;
				}
				if (!this.isEditing)
				{
					if (e.Control)
					{
						if (e.KeyCode == Keys.V)
						{
							e.SuppressKeyPress = true;
							this.Paste();
						}
					}
					else
					{
						this.BeginEdit("", true);
					}
				}
				IL_523:;
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000FBB0 File Offset: 0x0000DDB0
		private Font fFmlCN()
		{
			string filename = (this.tlSCbxFontCN.SelectedItem as ComboboxItem).Value as string;
			PrivateFontCollection privateFontCollection = new PrivateFontCollection();
			privateFontCollection.AddFontFile(filename);
			this.ff = privateFontCollection.Families[0];
			float emSize = (float)this.tlSCbxFontCNSize.SelectedItem;
			return new Font(this.ff, emSize, FontStyle.Bold, GraphicsUnit.Point, 0);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000FC14 File Offset: 0x0000DE14
		private void txt_Focus_TextChanged(object sender, EventArgs e)
		{
			if (!this.isEditing)
			{
				return;
			}
			if (this.cbxChuViet.Checked)
			{
				return;
			}
			this.pnlDicSuggest.Visible = false;
			while (0 < this.pnlDicSuggest.Controls.Count)
			{
				foreach (object obj in this.pnlDicSuggest.Controls)
				{
					Control value = (Control)obj;
					this.pnlDicSuggest.Controls.Remove(value);
				}
			}
			this.pnlDicSuggest.Location = new Point(-this.pnlDicSuggest.Size.Width, -this.pnlDicSuggest.Size.Height);
			string text = this.txt_Focus.Text.Trim();
			if (!string.IsNullOrEmpty(text) && LePhat.getDic.ContainsKey(text.ToLower()))
			{
				List<VnChinese> list = LePhat.getDic[text.ToLower()];
				if (list.Count <= 0)
				{
					return;
				}
				int num = 1;
				int num2 = 1;
				this.calRowCol(list.Count, ref num, ref num2);
				this.pnlDicSuggest.Size = new Size(44 * num2, 44 * num);
				if (this.fntCN == null)
				{
					this.fntCN = this.fFmlCN();
				}
				int num3 = 0;
				foreach (VnChinese vnChinese in list)
				{
					if (!string.IsNullOrEmpty(vnChinese.chinese))
					{
						Button button = new Button();
						button.Text = vnChinese.chinese;
						button.BackColor = Color.LightYellow;
						button.Font = this.fntCN;
						button.Location = new Point(0, num3);
						button.Margin = new Padding(2, 2, 2, 2);
						button.Size = new Size(40, 40);
						button.Click += this.btn_Click;
						this.pnlDicSuggest.Controls.Add(button);
						num3 += button.Size.Width;
					}
				}
				num3 = this.txt_Focus.Location.Y + this.txt_Focus.Size.Height;
				if (this.pnlLongSo.Height < num3 + this.pnlDicSuggest.Size.Height && this.pnlLongSo.Height / 2 < this.txt_Focus.Location.Y && 0 <= num3 - this.pnlDicSuggest.Size.Height - this.txt_Focus.Size.Height)
				{
					num3 = num3 - this.pnlDicSuggest.Size.Height - this.txt_Focus.Size.Height - 3;
				}
				int num4 = this.txt_Focus.Location.X;
				if (this.pnlLongSo.Width < num4 + this.pnlDicSuggest.Size.Width && this.pnlLongSo.Width / 2 < this.txt_Focus.Location.X)
				{
					num4 = num4 - this.pnlDicSuggest.Size.Width + this.txt_Focus.Size.Width;
				}
				this.pnlDicSuggest.Location = new Point(num4, num3);
				this.pnlDicSuggest.Visible = true;
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000FFEC File Offset: 0x0000E1EC
		private void calRowCol(int count, ref int r, ref int c)
		{
			while (r * c < count)
			{
				if (r < c)
				{
					r++;
				}
				else
				{
					c++;
				}
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0001000C File Offset: 0x0000E20C
		private void btn_Click(object sender, EventArgs e)
		{
			try
			{
				CellData selectedCel = this.getSelectedCel();
				if (selectedCel != null)
				{
					Button button = (Button)sender;
					if (selectedCel.TextCN != button.Text)
					{
						object value = selectedCel.Value;
						if (!(((value != null) ? value.ToString() : null) ?? "").Contains("*"))
						{
							object value2 = selectedCel.Value;
							if (!(((value2 != null) ? value2.ToString() : null) ?? "").Contains("$"))
							{
								this.unre.Store(this.prD.LoaiSoData);
								LePhat.setTextCNLongSo(selectedCel.ColNoOrg, selectedCel.RowNoOrg, button.Text);
							}
						}
						string vn = this.txt_Focus.Text.Trim();
						string text = button.Text;
						object value3 = selectedCel.Value;
						LePhat.updateUsedTime(vn, text, ((value3 != null) ? value3.ToString() : null) ?? "");
					}
					if (!this.EndEdit())
					{
						this.ReLoad();
					}
					this.MoveSelection(DirectionEnum.Down);
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00010124 File Offset: 0x0000E324
		private void MoveSelection(DirectionEnum drt)
		{
			CellData selectedCel = this.getSelectedCel();
			if (selectedCel == null)
			{
				return;
			}
			int num = selectedCel.RowNo;
			int num2 = selectedCel.ColNo;
			switch (drt)
			{
			case DirectionEnum.Left:
				if (num2 <= 0)
				{
					return;
				}
				num2--;
				break;
			case DirectionEnum.Right:
				if (this.prD.LoaiSoData.LgSo.Count - 1 <= num2)
				{
					return;
				}
				num2++;
				break;
			case DirectionEnum.Up:
				if (num <= 0)
				{
					return;
				}
				num--;
				break;
			case DirectionEnum.Down:
				if (this.prD.LoaiSoData.LgSo[0].Count - 1 <= num)
				{
					return;
				}
				num++;
				break;
			}
			this.drawOneSelectedCel(this.getCel(num, num2));
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000101CC File Offset: 0x0000E3CC
		private void Paste()
		{
			CellData selectedCel = this.getSelectedCel();
			if (selectedCel == null)
			{
				return;
			}
			string text;
			try
			{
				text = Clipboard.GetText();
			}
			catch (Exception)
			{
				return;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			Queue<string> pasteText = Util.getPasteText(text);
			this.unre.Store(this.prD.LoaiSoData);
			LePhat.setTextLongSo(selectedCel.ColNo, selectedCel.RowNo, pasteText);
			this.ReLoad();
		}

		// Token: 0x0400008B RID: 139
		private static CustomerKey CusInfo;

		// Token: 0x0400008C RID: 140
		private bool isFrmLoading;

		// Token: 0x0400008D RID: 141
		private PrDocument prD = new PrDocument();

		// Token: 0x0400008E RID: 142
		private List<CellData> selectedRcTL = new List<CellData>();

		// Token: 0x0400008F RID: 143
		private string MouseMode = "";

		// Token: 0x04000090 RID: 144
		private const string MoveConst = "move";

		// Token: 0x04000091 RID: 145
		private UnReDo<LongSoData> unre;

		// Token: 0x04000092 RID: 146
		private FrmWelcome welcome;

		// Token: 0x04000093 RID: 147
		private string error = "Chọn loại sớ";

		// Token: 0x04000094 RID: 148
		private List<LongSo> lSL;

		// Token: 0x04000095 RID: 149
		private BackgroundWorker bgWorker = new BackgroundWorker();

		// Token: 0x04000096 RID: 150
		private string Old_Value;

		// Token: 0x04000097 RID: 151
		private bool isEditing;

		// Token: 0x04000098 RID: 152
		private FontFamily ff;

		// Token: 0x04000099 RID: 153
		private Font fntCN;

		// Token: 0x02000025 RID: 37
		public class ComboboxData
		{
			// Token: 0x06000169 RID: 361 RVA: 0x0001968A File Offset: 0x0001788A
			public ComboboxData(string vn, string bmk)
			{
				this.vn = vn;
				this.bookMark = bmk;
			}

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x0600016A RID: 362 RVA: 0x000196A0 File Offset: 0x000178A0
			// (set) Token: 0x0600016B RID: 363 RVA: 0x000196A8 File Offset: 0x000178A8
			public string vn { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x0600016C RID: 364 RVA: 0x000196B1 File Offset: 0x000178B1
			// (set) Token: 0x0600016D RID: 365 RVA: 0x000196B9 File Offset: 0x000178B9
			public string bookMark { get; set; }
		}

        private void splitCntMain_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
