using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PathFinder.WinForms.App;

namespace PathFinder.WinForms
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        static void OpenSingleIntance(string[] args)
        {
            try
            {

            if (args.Length > 0)
            {
                var mainForm = GetMainFormInstance();
                mainForm.AddWindow(args[0]);
                BringToFront();
            }
                     }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "; " + ex.StackTrace);
            }
        }

        private static MainForm GetMainFormInstance()
        {
            return Application.OpenForms.OfType<MainForm>().FirstOrDefault();
        }

        private static void BringToFront()
        {
            Process current = Process.GetCurrentProcess();
            foreach (var process in Process.GetProcessesByName(current.ProcessName))
            {
                if (process.Id != current.Id)
                {
                    SetForegroundWindow(process.MainWindowHandle);
                    break;
                }
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                Workspace.Settings.Load();

                // test if this is the first instance and register receiver, if so.
                if (!Workspace.Settings.SingleInstance || SingleInstanceEnforcer.IsFirst(OpenSingleIntance))
                {
                    Run(args);
                }
                else
                {
                    // send command line args to running app, then terminate
                    SingleInstanceEnforcer.PassCommandLine(args);
                }

                SingleInstanceEnforcer.Cleanup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "; " + ex.StackTrace);
            }
        }

        private static void Run(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                Application.Run(new MainForm(args[0]));
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
