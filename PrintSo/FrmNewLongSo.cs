using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CommonModel;
using DataModel;
using DataText;

namespace PrintSo
{
	// Token: 0x02000010 RID: 16
	public partial class FrmNewLongSo : Form
	{
		// Token: 0x06000087 RID: 135 RVA: 0x0000AD7C File Offset: 0x00008F7C
		public FrmNewLongSo(LongSoData longSo)
		{
			this.LongSo = longSo;
			this.InitializeComponent();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000AD9C File Offset: 0x00008F9C
		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.txtLongSoName.Text.Trim();
				if (string.IsNullOrWhiteSpace(text))
				{
					MessageBox.Show("Tên lòng sớ mới không được để trống", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					text = Util.RemoveDoubleSpace(text);
					text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
					this.FileName = UtilModel.StripUnicodeCharactersFromString(text);
					this.FileName = this.FileName.Replace(" ", "_");
					string text2 = Util.getDataPath + this.FileName + ".cus";
					if (File.Exists(text2))
					{
						MessageBox.Show("Tên lòng sớ đã tồn tại, hãy đặt tên khác", Util.domain, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						for (int i = 1; i < this.LongSo.LgSo.Count - 1; i++)
						{
							Dictionary<int, CellData> dictionary = this.LongSo.LgSo[i];
							for (int j = 0; j < dictionary.Count; j++)
							{
								dictionary[j] = new CellData();
							}
						}
						Dictionary<int, CellData> dictionary2 = this.LongSo.LgSo[0];
						dictionary2[dictionary2.Count - 2].TextVN = text;
						this.LongSo.TenSo = text;
						Security.writeFile(this.LongSo, text2);
						base.Close();
						base.DialogResult = DialogResult.OK;
					}
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000098E7 File Offset: 0x00007AE7
		private static int compareByName(ComboboxItem cbi, ComboboxItem cbi1)
		{
			return string.Compare(cbi.Text, cbi1.Text);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000AF14 File Offset: 0x00009114
		private void FrmNewLongSo_Load(object sender, EventArgs e)
		{
			this.txtLongSoName.Focus();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000AF24 File Offset: 0x00009124
		private void txtLongSoName_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					this.btnSave_Click(null, null);
				}
			}
			catch (Exception ex)
			{
				LogError.show(ex);
			}
		}

		// Token: 0x04000085 RID: 133
		private LongSoData LongSo;

		// Token: 0x04000086 RID: 134
		public string FileName = "";
	}
}
