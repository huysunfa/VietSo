using AppVietSo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
            Application.Run(new frmWellCome());


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
