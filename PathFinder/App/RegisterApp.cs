using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace PathFinder.WinForms.App
{
    public class RegisterApp
    {
        private static bool Register(bool register)
        {
            string pfFolder = AppDomain.CurrentDomain.BaseDirectory;
            string pfregPath = Path.Combine(pfFolder, "pfreg.exe");
            string pfPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string action = register ? "R" : "U";
            string args = String.Format("{0} {1}", action, pfPath);
            var proc = Process.Start(pfregPath, args);

            if (proc == null)
            {
                return false;
            }

            proc.WaitForExit();
            return (proc.ExitCode == 0);
        }

        public static bool Unregister()
        {
            return Register(false);
        }

        public static bool Register()
        {
            return Register(true);
        }

        public static bool IsRegistered()
        {
            var key = Registry.CurrentUser.OpenSubKey(@"Software\Classes\Directory\shell\PathFinder");
            return key != null;
        }
    }
}
