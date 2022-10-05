using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using CommonModel;
using DataModel;
using DataModel.Entities;

namespace DataText
{
	// Token: 0x02000018 RID: 24
	public class ExchangeLongSo
	{
		// Token: 0x0600015E RID: 350 RVA: 0x000073A0 File Offset: 0x000055A0
		public static global::System.Collections.Generic.List<global::DataModel.Entities.LongSo> getLongSo(string cusKey, ref string error)
		{
			try
			{
				string text = "comID=" + global::DataModel.Util.GetComputerIMEI() + "&cusKey=" + cusKey;
				return global::CommonModel.UtilModel.ConvertJSON2Obj<global::System.Collections.Generic.List<global::DataModel.Entities.LongSo>>(global::DataModel.Util.queryServer("AppSync/DataLongSo/", text));
			}
			catch (global::System.Exception ex)
			{
				error = ex.Message;
			}
			return null;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x000073F4 File Offset: 0x000055F4
		public static bool downloadFile(string fileName)
		{
			bool result;
			try
			{
				global::System.Net.WebClient webClient = new global::System.Net.WebClient();
				string text = global::DataModel.Util.getTempPath + fileName + ".bibe";
				string uriString = global::DataModel.Util.mainURL + "AppSync/downloadFileLongSo/" + fileName;
				webClient.DownloadFile(new global::System.Uri(uriString), text);
				string destFileName = global::DataModel.Util.getDataPath + fileName + ".bibe";
				global::System.IO.File.Copy(text, destFileName, true);
				if (global::System.IO.File.Exists(text))
				{
					global::System.IO.File.Delete(text);
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00004254 File Offset: 0x00002454
		public ExchangeLongSo()
		{
		}
	}
}
