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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
         [STAThread]
          static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new frmWellCome());


        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Có lỗi xảy ra, vui lòng gọi tới 0827.298.555 hoặc  zalo 0911.108.297 \n " + e.Exception.ToString());
        }
    }
}
