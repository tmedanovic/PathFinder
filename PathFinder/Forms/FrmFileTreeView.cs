using System;
using System.Windows.Forms;
using GongSolutions.Shell;
using PathFinder.Core;
using PathFinder.Core.Filesystem;
using PathFinder.WinForms.App;
using PathFinder.WinForms.Controls.Windows;
using PathFinder.WinForms.Helpers;
using PathFinder.WinForms.View;
using WeifenLuo.WinFormsUI.Docking;

namespace PathFinder.WinForms.Forms
{
    public partial class FrmFileTreeView : DockContent
    {
        private readonly WindowManager m_windowManager;
        public event EventHandler<NavigatedEventArgs> RootNavigated;

        public FrmFileTreeView(WindowManager windowManager)
        {
            InitializeComponent();
            tvRoot.TreeView.ShowLines = false;
            tvRoot.TreeView.Padding = new Padding(10);
            StyleHelper.SetExplorerTheme(tvRoot.TreeView.Handle);
            m_windowManager = windowManager;
            tvRoot.RootFolder = new ShellItem(Workspace.Settings.RootPath);
            tvRoot.SelectionChanged += tvRoot_SelectionChanged;
        }

        private void tvRoot_SelectionChanged(object sender, EventArgs e)
        {
            var item = tvRoot.SelectedFolder;
            var folderInfo = ShellHelper.FolderInfoFromShellItem(item);

            if (item != null)
            {
                var fv = new WinExplorerWindow(folderInfo);
                m_windowManager.AddWindow(fv);
            }

            OnRootNavigated(folderInfo);
        }

        private void OnRootNavigated(IFolderInfo fi)
        {
            if (RootNavigated != null)
            {
                RootNavigated(this, new NavigatedEventArgs(fi));
            }
        }
    }
}
