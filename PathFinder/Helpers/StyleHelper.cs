using System;
using System.Runtime.InteropServices;

namespace PathFinder.WinForms.Helpers
{
    public static class StyleHelper
    {
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        public static void SetExplorerTheme(IntPtr hwnd)
        {
            SetWindowTheme(hwnd, "Explorer", null);
        }
    }
}
