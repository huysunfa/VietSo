using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
	[Serializable]
	public class CellPos
    {
        public int RowNo { get; set; }
        public int ColNo { get; set; }
       }

	[Serializable]
	public class CellData
    {
        public RectangleF Rct;
        public int RowNoOrg;
        public int ColNoOrg;
        public int RowNo;
        public int ColNo;
        public CellPos cellVN { get; set; }
        public CellPos cellCN { get; set; }
        public float fsizeVN { get; set; }
        public string fnameVN { get; set; }
        public int fstyleCN { get; set; }
        public float fsizeCN { get; set; }
        public string fnameCN { get; set; }
        public string TextCNBMK { get; set; }
        public string TextVNBMK { get; set; }
        public object Value { get; set; }
        public string TextVN { get; set; }
        public int fstyleVN { get; set; }
        public string TextCN { get; set; }
        public string alignVN { get; set; }
		public CellData Clone()
		{
			return new  CellData
			{
				Value = this.Value,
				TextVN = this.TextVN,
				TextCN = this.TextCN,
				TextVNBMK = this.TextVNBMK,
				TextCNBMK = this.TextCNBMK,
				Rct = this.Rct,
				fnameCN = this.fnameCN,
				fsizeCN = this.fsizeCN,
				fstyleCN = this.fstyleCN,
				fnameVN = this.fnameVN,
				fsizeVN = this.fsizeVN,
				fstyleVN = this.fstyleVN,
				alignVN = this.alignVN,
				RowNo = this.RowNo,
				ColNo = this.ColNo,
				RowNoOrg = this.RowNoOrg,
				ColNoOrg = this.ColNoOrg
			};
		}
		public string Text(bool isVN)
		{
			if (isVN)
			{
				if (!string.IsNullOrEmpty(this.TextVNBMK))
				{
					return this.TextVNBMK;
				}
				return this.TextVN;
			}
			else
			{
				if (!string.IsNullOrEmpty(this.TextCNBMK))
				{
					return this.TextCNBMK;
				}
				if (!string.IsNullOrEmpty(this.TextCN))
				{
					return this.TextCN;
				}
				if (string.IsNullOrEmpty(this.TextVNBMK))
				{
					string textVN = this.TextVN;
					object value = this.Value;
					string nguCanh;
					if (value != null)
					{
						if ((nguCanh = value.ToString()) != null)
						{
							goto IL_6D;
						}
					}
					nguCanh = "";
					IL_6D:
					return  LePhat.getCN(textVN, nguCanh);
				}
				string textVNBMK = this.TextVNBMK;
				object value2 = this.Value;
				string nguCanh2;
				if (value2 != null)
				{
					if ((nguCanh2 = value2.ToString()) != null)
					{
						goto IL_94;
					}
				}
				nguCanh2 = "";
				IL_94:
				return LePhat.getCN(textVNBMK, nguCanh2);
			}
		}
	}
}