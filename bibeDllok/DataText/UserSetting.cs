using System;
using System.Collections.Generic;
using System.IO;
using CommonModel;
using DataModel;

namespace DataText
{
	// Token: 0x02000027 RID: 39
	public class UserSetting
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x0000BCE0 File Offset: 0x00009EE0
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x0000BD08 File Offset: 0x00009F08
		public global::System.Collections.Generic.Dictionary<string, global::DataText.UserSettingPrint> PrintSetting
		{
			get
			{
				if (this.dictionary_0 == null)
				{
					this.dictionary_0 = new global::System.Collections.Generic.Dictionary<string, global::DataText.UserSettingPrint>();
				}
				return this.dictionary_0;
			}
			set
			{
				this.dictionary_0 = value;
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000BD1C File Offset: 0x00009F1C
		public global::DataText.UserSettingPrint GetPrintSetting(string sheet)
		{
			if (!this.PrintSetting.ContainsKey(sheet))
			{
				this.PrintSetting.Add(sheet, new global::DataText.UserSettingPrint());
			}
			return this.PrintSetting[sheet];
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x0000BD54 File Offset: 0x00009F54
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x0000BD68 File Offset: 0x00009F68
		public global::System.Collections.Generic.Dictionary<string, string> LongSoUserData
		{
			get
			{
				return this.dictionary_1;
			}
			set
			{
				this.dictionary_1 = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x0000BD7C File Offset: 0x00009F7C
		// (set) Token: 0x060002AA RID: 682 RVA: 0x0000BD90 File Offset: 0x00009F90
		public string LoaiSo
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0000BDA4 File Offset: 0x00009FA4
		// (set) Token: 0x060002AC RID: 684 RVA: 0x0000BDB8 File Offset: 0x00009FB8
		public string Chua
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060002AD RID: 685 RVA: 0x0000BDCC File Offset: 0x00009FCC
		// (set) Token: 0x060002AE RID: 686 RVA: 0x0000BDE0 File Offset: 0x00009FE0
		public bool IsPrintMaSo
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060002AF RID: 687 RVA: 0x0000BDF4 File Offset: 0x00009FF4
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x0000BE08 File Offset: 0x0000A008
		public bool IsGiaChu
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x0000BE1C File Offset: 0x0000A01C
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x0000BE30 File Offset: 0x0000A030
		public string NgonNgu
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000BE44 File Offset: 0x0000A044
		public void Save()
		{
			global::CommonModel.UtilModel.saveJsonObjToFile(global::System.IO.Path.Combine(global::DataModel.Util.getDataPath, "App.set"), this);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000BE68 File Offset: 0x0000A068
		public static global::DataText.UserSetting Load()
		{
			string text = global::System.IO.Path.Combine(global::DataModel.Util.getDataPath, "App.set");
			if (!global::System.IO.File.Exists(text))
			{
				return new global::DataText.UserSetting();
			}
			global::DataText.UserSetting userSetting = global::CommonModel.UtilModel.readObjFromJsonFile<global::DataText.UserSetting>(text);
			if (userSetting != null)
			{
				return userSetting;
			}
			return new global::DataText.UserSetting();
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00004254 File Offset: 0x00002454
		public UserSetting()
		{
		}

		// Token: 0x04000096 RID: 150
		private global::System.Collections.Generic.Dictionary<string, global::DataText.UserSettingPrint> dictionary_0;

		// Token: 0x04000097 RID: 151
		private string string_0;

		// Token: 0x04000098 RID: 152
		private string string_1;

		// Token: 0x04000099 RID: 153
		private string string_2;

		// Token: 0x0400009A RID: 154
		private bool bool_0;

		// Token: 0x0400009B RID: 155
		private bool bool_1;

		// Token: 0x0400009C RID: 156
		private global::System.Collections.Generic.Dictionary<string, string> dictionary_1;
	}
}
