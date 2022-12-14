using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class LePhat
    {
		public static string CaiDatLongSo;
		public static Dictionary<string, string> dicData;
		private static global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.List<VnChinese>> dictionary_0;
		public static string getCN(string vn, string nguCanh)
		{
			if (string.IsNullOrEmpty(vn))
			{
				return vn;
			}
			if (!string.IsNullOrEmpty(nguCanh))
			{
				nguCanh = nguCanh.Replace("$", "").Replace("@", "").Replace("*", "").ToLower();
			}
			if (! LePhat.getDic.ContainsKey(vn.ToLower()))
			{
				return vn;
			}
			global::System.Collections.Generic.List<VnChinese> list =  LePhat.getDic[vn.ToLower()];
			if (list.Count > 0)
			{
				foreach (VnChinese vnChinese in list)
				{
					if (!string.IsNullOrEmpty(vnChinese.chinese) && !string.IsNullOrEmpty(vnChinese.nguCanh) && vnChinese.nguCanh == nguCanh)
					{
						return vnChinese.chinese;
					}
				}
				return list[0].chinese;
			}
			return vn;
		}

		public static global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.List<VnChinese>> getDic
		{
			get
			{
				if (LePhat.dictionary_0 == null)
				{
					LePhat.dictionary_0 = VnChineseBO.getDic();
				}
				return LePhat.dictionary_0;
			}
		}
		public static global::System.Collections.Generic.Queue<string> convert2Queue(string s)
		{
			s = global::System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.Trim().ToLower());
			global::System.Collections.Generic.Queue<string> queue = new global::System.Collections.Generic.Queue<string>();
			foreach (string item in s.Trim().Split(new char[]
			{
				' '
			}))
			{
				queue.Enqueue(item);
			}
			return queue;
		}
		public static global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>> getListTinChu(ref string address, global::System.Collections.Generic.List< Person> psnL, string formText, Year isNextYear)
		{
			global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>> queue = new global::System.Collections.Generic.Queue<global::System.Collections.Generic.Queue<string>>();
			 LePhat.CaiDatLongSo ="";
			foreach (Person person in psnL)
			{
				if (string.IsNullOrEmpty(LePhat.CaiDatLongSo))
				{
					LePhat.CaiDatLongSo = person.Address;
					address = LePhat.CaiDatLongSo;
				}
				string text ;
				if (person.NamSinh.Equals(0))
				{
					text = "$ten";
				}
				else
				{
					person.isNextYear = isNextYear;
					text = (formText+"").Replace("$canchi", person.Menh);
					text = text.Replace("$sotuoi", person.Tuoi);
					text = text.Replace("$tuoi", CNDictionary.getChuNomYYYY(person.Tuoi));
					text = text.Replace("$sao", person.Sao);
					if (LePhat.dicData == null)
					{
						LePhat.dicData = Security.readFile<Dictionary<string, string>>(Util.getDataPath + "QuanTien.qnt");
					}
					if (LePhat.dicData != null && LePhat.dicData.ContainsKey(person.Menh.ToLower()))
					{
						text = text.Replace("$quantien", LePhat.dicData[person.Menh.ToLower()]);
					}
				}
				text = text.Replace("$danh", (person.DanhXung+"").Trim());
				text = text.Replace("$ten", (person.FullName+"").Trim());
				global::System.Collections.Generic.Queue<string> item = LePhat.convert2Queue(text);
				queue.Enqueue(item);
			}
			return queue;
		}
    }
}
