using System;
using System.Linq;
using System.Windows.Forms;
using PathFinder.WinForms.App;

namespace PathFinder.WinForms
{
    internal static class Program
    {
        static void OpenSingleIntance(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    var mainForm = GetMainFormInstance();
                    mainForm.AddWindow(args[0]);
                    BringToFront(mainForm); 
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

        private static void BringToFront(Form form)
        {
            if (form.InvokeRequired)
            {
                form.Invoke((MethodInvoker) delegate
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }

                    form.Activate();
                });
            }
            else
            {
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                }

                form.Activate();
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
