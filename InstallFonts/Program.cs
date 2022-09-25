using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace InstallFonts
{
    class Program
    {
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void Run1()
        {
            
        }
        static void Main(string[] args)
        {
            if (!Program.IsAdministrator())
            {
                // Restart and run as admin
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                startInfo.Arguments = "restart";
                Process.Start(startInfo);
            }
            else
            {
                InstallFonts();
            }
        }
        private static string GetFontName(string fontPath)
        {
            PrivateFontCollection fontCol = new PrivateFontCollection();
            fontCol.AddFontFile(fontPath);
            return fontCol.Families[0].Name;
        }
        public static void InstallFonts()
        {
            // user fonts folder
            var fontsPath = System.AppDomain.CurrentDomain.BaseDirectory + "/Data/fontCN";

            // system fonts folder
            var fontDestination = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

            // import fonts
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
                // copy font to dest
                File.Copy(Path.Combine(fontsPath, fontFileName), Path.Combine(fontDestination, fontFileName));

                // add to registry
                using (RegistryKey fontsKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", true))
                {
                    fontsKey.SetValue(string.Format("{0} {1} {2}", fontName, fontStyle, fontType == "ttf" ? "(TrueType)" : "(OpenType)"),
                        fontFileName, RegistryValueKind.String);
                }
            }
        }
    }
}
