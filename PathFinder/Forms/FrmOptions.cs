using System;
using System.Linq;
using System.Windows.Forms;
using GongSolutions.Shell;
using PathFinder.WinForms.App;

namespace PathFinder.WinForms.Forms
{
    public partial class FrmOptions : Form
    {
        private AppSettings settings = new AppSettings();

        public FrmOptions()
        {
            InitializeComponent();

            rbOnCloseClose.Tag = AppCloseAction.Close;
            rbOnCloseMinimizeToTaskbar.Tag = AppCloseAction.MinimizeToTaskbar;
            rbOnCloseMinimizeToTray.Tag = AppCloseAction.MinimizeToTray;

            bsOptions.DataSource = settings;
        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            settings.Load();

            var rbc = gbOnClose.Controls.OfType<RadioButton>()
                     .Single(x =>((AppCloseAction)x.Tag) == settings.CloseAction);

            rbc.Checked = true;
            cbSingleInstance.Checked = settings.SingleInstance;

            scbNewTabStartPath.SelectedFolder = new ShellItem(settings.StartPath);
            scbRootTreeviewPath.SelectedFolder = new ShellItem(settings.RootPath);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (scbNewTabStartPath.SelectedFolder.IsFileSystem)
            {
                settings.StartPath = scbNewTabStartPath.SelectedFolder.FileSystemPath;
            }
            else
            {
                settings.StartPath = scbNewTabStartPath.SelectedFolder.ToUri().ToString();
            }

            if (scbRootTreeviewPath.SelectedFolder.IsFileSystem)
            {
                settings.RootPath = scbRootTreeviewPath.SelectedFolder.FileSystemPath;
            }
            else
            {
                settings.RootPath = scbRootTreeviewPath.SelectedFolder.ToUri().ToString();
            }

            settings.Save();
            Workspace.Settings.Load();
        }

        private void rbOnCloseClose_CheckedChanged(object sender, EventArgs e)
        {
            settings.CloseAction = ((AppCloseAction) ((RadioButton) sender).Tag);
        }

        private void cbSingleInstance_CheckedChanged(object sender, EventArgs e)
        {
            settings.SingleInstance = cbSingleInstance.Checked;
        }
    }
}
