using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public static class loadFont
    {
        public static List<string> loadListFontVN()
        {

            List<string> output = null;
            var path = Util.getDicFontVN;
            if (File.Exists(path))
            {
                output = JsonConvert.DeserializeObject<List<string>>(Security.Decrypt(System.IO.File.ReadAllText(path)));
            }
            if (output == null)
            {
                #region output
                output = new List<string>();
                foreach (FontFamily font in System.Drawing.FontFamily.Families)
                {
                    output.Add(font.Name);
                }
                var jsonoutput = Newtonsoft.Json.JsonConvert.SerializeObject(output);
                jsonoutput = Security.Encrypt(jsonoutput);
                System.IO.File.WriteAllText(path, jsonoutput);
                #endregion


            }
            return output;



        }
        public static List<string> loadListFontCN(bool replace=false)
        {

            PrivateFontCollection pfc = new PrivateFontCollection();
            List<string> output = null;
            var path = Util.getDicFontCN;
            if (File.Exists(path))
            {
                output = JsonConvert.DeserializeObject<List<string>>(Security.Decrypt(System.IO.File.ReadAllText(path)));
            }
            if (output == null || replace == true)
            {
                #region output
                output = new List<string>();
                pfc = LoadInMemoryFonts();

                foreach (var item in pfc.Families)
                {
                    output.Add(item.Name);

                }
                var jsonoutput = Newtonsoft.Json.JsonConvert.SerializeObject(output);
                jsonoutput = Security.Encrypt(jsonoutput);
                System.IO.File.WriteAllText(path, jsonoutput);
                #endregion


            }
            return output;

        }

        public static void DownloadFont()
        {
            var json = CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/GetListFont");
            var data = JsonConvert.DeserializeObject<List<string>>(json);
            string[] fileEntries = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/fontCN").Select(v=>v.Split('\\').LastOrDefault().ToUpper()).ToArray();
            foreach (var item in data)
            {
                var name = item;
                name = name.Replace("\\", "/");
                name = name.Split('/').LastOrDefault().ToUpper();
                if (!fileEntries.Contains(name))
                {
                    var urldownload = "/FILEUPLOAD/FONTCN/"+name;
                    ExchangeLongSo.downloadFileFont(urldownload);
                }
            }

        }
        public static PrivateFontCollection LoadInMemoryFonts()
        {
            var fontCollection = new PrivateFontCollection();
            string[] fileEntries = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/fontCN");
            Array.ForEach(fileEntries, fontFile =>
            {
                using (var fileStream = new FileStream(fontFile, FileMode.Open, FileAccess.Read))
                {
                    var memStream = new MemoryStream();
                    fileStream.CopyTo(memStream);
                    var fontData = memStream.ToArray();
                    var fontDataPtr = Marshal.AllocCoTaskMem(fontData.Length);

                    Marshal.Copy(fontData, 0, fontDataPtr, fontData.Length);
                    fontCollection.AddMemoryFont(fontDataPtr, fontData.Length);

                    Marshal.FreeCoTaskMem(fontDataPtr);


                }
            });
            return fontCollection;
        }
    }
}
