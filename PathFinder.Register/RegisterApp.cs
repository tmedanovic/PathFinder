using System;
using Microsoft.Win32;

namespace PathFinder.Register
{
    public class RegisterApp
    {
        public static void Register(string appPath)
        {
            Register(appPath, @"Software\Classes\Drive\shell");
            Register(appPath, @"Software\Classes\Directory\shell");
        }

        public static void Unregister()
        {
            Unregister(@"Software\Classes\Drive\shell");
            Unregister(@"Software\Classes\Directory\shell");
        }

        private static void Register(string appPath, string key)
        {
            var shellKey = Registry.CurrentUser.CreateSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree);
            
            shellKey.SetValue("", "PathFinder");

            var shellPfKey = shellKey.CreateSubKey("PathFinder");
            shellPfKey.SetValue("", "Open in Path finder");

            var shellPfCommandKey = shellPfKey.CreateSubKey("command");

            if (key.EndsWith(@"Drive\shell"))
            {
                shellPfCommandKey.SetValue("", String.Format("{0} %1", appPath));
            }
            else
            {
                shellPfCommandKey.SetValue("", String.Format("{0} \"%1\"", appPath));
            }
        }

        private static void Unregister(string key)
        {
            var shellKey = Registry.CurrentUser.OpenSubKey(key, true);
            shellKey.SetValue("", "none");

            shellKey.DeleteSubKeyTree("PathFinder");
        }
    }
}
