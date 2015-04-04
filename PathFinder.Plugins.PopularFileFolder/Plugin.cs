using System;
using PathFinder.Core;
using PathFinder.Core.Plugins;
using PathFinder.Core.Windows;
using PathFinder.Plugins.PopularFileFolder.Forms;

namespace PathFinder.Plugins.PopularFileFolder
{
    public class Plugin : PathFinder.Core.Plugins.Plugin
    {
        private FrmPopularFolders m_frmPopularFolders;
        private FrmPopularFolders m_frmHistory;

        private void InitTrackers()
        {
            Tracking.Trackers.HistoryTracker.Load();
            Tracking.Trackers.PopularFoldersTracker.Load();
        }

        public Plugin(IPluginHost host) : base(host)
        {
            InitTrackers();

            m_frmPopularFolders = new FrmPopularFolders();
            m_frmPopularFolders.Load += m_frmPopularFolders_Load;


            m_frmHistory = new FrmPopularFolders();

            host.WindowOpened += host_WindowOpened;
            host.ApplicationClosing += host_ApplicationClosing;
            host.Register(m_frmPopularFolders, DockFormStyle.DockLeft);
        }

        void m_frmPopularFolders_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void host_ApplicationClosing(object sender, EventArgs e)
        {
            Tracking.Trackers.HistoryTracker.Save();
            Tracking.Trackers.PopularFoldersTracker.Save();
        }

        void host_WindowOpened(object sender, WindowEventArgs e)
        {
            var window = e.BaseWindow as IExplorerWindow;
            if (window != null)
            {
                window.Navigated += window_Navigated;
            }
        }

        void window_Navigated(object sender, Core.NavigatedEventArgs e)
        {
            if (e.FolderInfo.IsFileSystemPath)
            {
                Tracking.Trackers.HistoryTracker.Add(e.FolderInfo.ParsingName);
                Tracking.Trackers.PopularFoldersTracker.Add(e.FolderInfo.ParsingName);
            }
        }

        public override string Name
        {
            get { return "Popular files and folders"; }
        }

        public override string Description 
        {
            get { return "Keeps track of your most visited files and folders"; }
        }

        public override string Version 
        {
            get { return "1.0.0"; }
        }
    }
}
