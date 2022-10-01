using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AppVietSo
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
            //  Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            CheckFolder();

        //    return;

            SplashScreen.ShowSplashScreen();
			Application.DoEvents();

            SplashScreen.SetStatus("--- Kiểm tra bản cập nhật ---");

            var url = "http://ltsgroup.xyz/AppSync/GetVersion";
            using (var webClient = new System.Net.WebClient())
            {
                var result = webClient.DownloadData(url);
                var htmlCode = Encoding.UTF8.GetString(result);
                var path = System.AppDomain.CurrentDomain.BaseDirectory;

                var localpath = path + "AppVietSo.exe";
                var localVersion = FileVersionInfo.GetVersionInfo(localpath);

                if (localVersion.FileVersion != htmlCode)
                {
                    Application.Exit();
                    System.Diagnostics.Process.Start("Updated.exe");
                    return;
                }

            }



            SplashScreen.SetStatus("--- Kiểm tra bản quyền ---");
            var licence = CheckKey.CheckLogin();
            if (licence == false)
            {
                Application.Exit();
                return;
            }
            SplashScreen.SetStatus("1. Tải dữ liệu font chữ hán");

            loadFont.loadListFontCN();
            SplashScreen.SetStatus("2.  Tải dữ liệu font chữ việt");
            loadFont.loadListFontVN();
            SplashScreen.SetStatus("3.  Tải dữ liệu thư viện chữ hán");
            CNDictionary.loadDatabase();
            SplashScreen.SetStatus("4.  Tải dữ liệu lòng sớ đang mở");
            Models.LongSo.GetLongSos(true);
            SplashScreen.SetStatus("5.  GetLabelTexts");
            LabelText.GetLabelTexts(true);
            //     OuputOK("6.  InstallFonts");
            var check = loadFont.CheckFontNoInstall();

            if (check)
            {
                Application.Exit();
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                return;
            }
            
             Application.Run(new Form1()); 
            //Application.Run(new frmWellCome());


        }
        public static UserSetting Stg;
        public static void CheckFolder()
        {
            List<string> path = new List<string>();
            Stg =  UserSetting.Load();

            path.Add(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/");
            path.Add(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/FileUpload/");
            foreach (var directory in path)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
        
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
             MessageBox.Show(LabelText.Get("Application_ThreadException") + " \n " + e.Exception.ToString());
        }
    }
}
