using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using unvell.ReoGrid;

namespace AppVietSo
{
	public partial class FrmPrintProcess : Form
	{
		// Token: 0x06000119 RID: 281 RVA: 0x00016760 File Offset: 0x00014960
		public FrmPrintProcess(ReoGridControl prD, Dictionary<int, Family> soNos)
		{
			this.InitializeComponent();
			this.SoNos = soNos;
			this.PrD = prD;
			this.bgWorker.DoWork += this.bgWorker_DoWork;
			this.bgWorker.ProgressChanged += this.bgWorker_ProgressChanged;
			this.bgWorker.RunWorkerCompleted += this.bgWorker_RunWorkerCompleted;
			this.bgWorker.WorkerReportsProgress = true;
			this.bgWorker.WorkerSupportsCancellation = true;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000167FA File Offset: 0x000149FA
		private void btnStop_Click(object sender, EventArgs e)
		{
			this.bgWorker.CancelAsync();
			this.btnStop.Enabled = false;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00016813 File Offset: 0x00014A13
		private void FrmPrintProcess_Load(object sender, EventArgs e)
		{
			this.bgWorker.RunWorkerAsync();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00016820 File Offset: 0x00014A20
		private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				this.bgWorker.ReportProgress(this.SoNos.Count, 0);
				int num = 0;
				foreach (KeyValuePair<int, Family> keyValuePair in this.SoNos)
				{
					if (this.bgWorker.CancellationPending)
					{
						e.Cancel = true;
						break;
					}
					num++;
					int percentProgress = num / this.SoNos.Count * 0x64;
					this.bgWorker.ReportProgress(percentProgress, keyValuePair.Key);

					Program.Stg.Chua = keyValuePair.Key+"";

					try
                    {
                       this.PrD.PreView();
                    }
                    catch (Exception)
                    {
                        this.SoNosError.Add(keyValuePair.Key);
                        continue;
                    }
                    this.PrD.CurrentWorksheet.PrintSettings.PageScaling = 1f;    // scale to 70%

					print();
					Thread.Sleep(400);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		public void print()
		{
			var sheet = PrD.CurrentWorksheet;
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
				 
					session.PrintDocument.DefaultPageSettings.PaperSize = Util.LongSoHienTai.paperSize;
					session.PrintDocument.PrinterSettings.DefaultPageSettings.PaperSize = session.PrintDocument.DefaultPageSettings.PaperSize;
  				session.PrintDocument.PrinterSettings.PrinterName = Util.LongSoHienTai.PrinterName;
					session.Print();
 				 
			}
		}
		// Token: 0x0600011D RID: 285 RVA: 0x00016964 File Offset: 0x00014B64
		private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			Control control = this.lblStatus;
			string[] array = new string[5];
			array[0] = "Đang in số sớ ";
			int num = 1;
			object userState = e.UserState;
			array[num] = ((userState != null) ? userState.ToString() : null);
			array[2] = ". Đã in được ";
			array[3] = e.ProgressPercentage.ToString();
			array[4] = "%";
			control.Text = string.Concat(array);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000169C8 File Offset: 0x00014BC8
		private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				if (e.Cancelled)
				{
					base.DialogResult = DialogResult.Cancel;
				}
				else
				{
					base.DialogResult = DialogResult.OK;
				}
				base.Close();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04000112 RID: 274
		private Dictionary<int, Family> SoNos;

		// Token: 0x04000113 RID: 275
		private ReoGridControl PrD;

		// Token: 0x04000114 RID: 276
		private BackgroundWorker bgWorker = new BackgroundWorker();

		// Token: 0x04000115 RID: 277
		public List<int> SoNosError = new List<int>();
	}
}
