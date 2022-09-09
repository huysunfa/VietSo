using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
 public   class ExchangeLongSo
    {

		// Token: 0x0600015E RID: 350 RVA: 0x00007400 File Offset: 0x00005600
		public static List<LongSo> getLongSo(string cusKey, ref string error)
		{
			try
			{
				string para = "comID=" + Util.GetComputerIMEI() + "&cusKey=" + cusKey;
				return UtilModel.ConvertJSON2Obj<List<LongSo>>(Util.queryServer("AppSync/DataLongSo/", para));
			}
			catch (Exception ex)
			{
				error = ex.Message;
			}
			return null;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00007458 File Offset: 0x00005658
		public static bool downloadFile(string fileName)
		{
			bool result;
			try
			{
				WebClient webClient = new WebClient();
				string text = Util.getTempPath + fileName + ConstData.ExtentionsFile;
				string uriString = Util.mainURL + "FileUpload/" + fileName + ConstData.ExtentionsFile;
				webClient.DownloadFile(new Uri(uriString), text);
				string destFileName = Util.getDataPath + fileName + ConstData.ExtentionsFile;
				File.Copy(text, destFileName, true);
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
	}
}
