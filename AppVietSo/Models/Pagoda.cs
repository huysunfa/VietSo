using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
	public class Pagoda :  AKT
	{
 
		public string ID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Leader { get; set; }
		public string Phone { get; set; }
		public string KeySoft { get; set; }
		public bool IsPrint { get; set; }
		// Token: 0x06000104 RID: 260 RVA: 0x00006598 File Offset: 0x00004798
		public override object getId()
		{
			return this.ID;
		}
		  
		 
 		public string IsPrintDisplay
		{
			get
			{
				if (!this.IsPrint)
				{
					return "";
				}
				return "In Hộ";
			}
		}

	 

		public string Status{ get; set; }
		public DateTime UpdateDT { get; set; }
 }
}
