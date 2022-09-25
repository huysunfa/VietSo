using AppVietSo.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace AppVietSo
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
        public static List<string> loadListFontCN(bool replace = false)
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
       
        private static string GetFontName(string fontPath)
        {
            PrivateFontCollection fontCol = new PrivateFontCollection();
            fontCol.AddFontFile(fontPath);
            return fontCol.Families[0].Name;
        }
        public static bool CheckFontNoInstall()
        {
            // user fonts folder
            var fontsPath = System.AppDomain.CurrentDomain.BaseDirectory + "/Data/fontCN";

            // system fonts folder
            var fontDestination = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            int cnt = 0;
             foreach (var fontFile in Directory.GetFiles(fontsPath))
            {
                // get font props
                var fontFileName = Path.GetFileName(fontFile);               // OpenSans-Regular.ttf
                var fontName = GetFontName(fontFile);                        // Open Sans
                var fontStyle = fontFileName.Split('.').FirstOrDefault();    // Regular, Bold 
                var fontType = fontFileName.Split('.').LastOrDefault();    // ttf
 
                if (File.Exists($"{fontDestination}\\{fontFileName}"))
                {
                    continue;
                }
                cnt++;
            }
            if (cnt>0)
            {
                var dialogResult = System.Windows.Forms.MessageBox.Show( "Có " + cnt + " chưa được đăng ký vào máy, thầy có muốn cài đặt ngay không ???", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("InstallFonts.exe");
                    Thread.Sleep(2000);
                    return true;
                }
                 

            }
            return false;
        }
        public static void DownloadFont()
        {
            var json = CNDictionary.getDataFromUrl(Util.mainURL + "/AppSync/GetListFont");
            var data = JsonConvert.DeserializeObject<List<string>>(json);
            string[] fileEntries = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/fontCN").Select(v => v.Split('\\').LastOrDefault().ToUpper()).ToArray();
            foreach (var item in data)
            {
                var name = item;
                name = name.Replace("\\", "/");
                name = name.Split('/').LastOrDefault().ToUpper();
                if (!fileEntries.Contains(name))
                {
                    var urldownload = "/FILEUPLOAD/FONTCN/" + name;
                    ExchangeLongSo.downloadFileFont(urldownload);
                }
            }

        }
        public static PrivateFontCollection LoadInMemoryFonts()
        {
            var fontCollection = new PrivateFontCollection();
            string[] fileEntries = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/fontCN");
            foreach (var fontFile in fileEntries)
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
               //     loadFont.RegisterFont(fontFile, fontCollection.Families[fontCollection.Families.Count()-1].Name) ;


                }
            }
            return fontCollection;
        }
    }
}
