using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PathFinder.Core;
using PathFinder.Core.Filesystem;
using PathFinder.Core.Plugins;
using PathFinder.Core.Views;
using PathFinder.Core.Windows;
using PathFinder.WinForms.App;
using PathFinder.WinForms.Controls;
using PathFinder.WinForms.Controls.Windows;
using PathFinder.WinForms.Forms;
using PathFinder.WinForms.Helpers;
using PathFinder.WinForms.Tracking;
using PathFinder.WinForms.VIew;
using WeifenLuo.WinFormsUI.Docking;

namespace PathFinder.WinForms
{
   // [Export(typeof(IPluginHost))]
    public partial class MainForm : Form, IPluginHost
    {
        private readonly FrmFileTreeView m_fileTreeView;
        private readonly FrmFileView m_fileView;
        private readonly WindowManager m_windowManager;
        private readonly FrmFileFolders m_folderHistory;
        private readonly FrmFileFolders m_popularFolders;
        private readonly DeserializeDockContent m_deserializeDockContent;

        public MainForm(string path) : this()
        {
            AddWindow(path);
        }

        public MainForm()
        {
            InitializeComponent();
            InizializeKeystrokeActions();

            m_fileView = new FrmFileView();
            m_windowManager = new WindowManager(m_fileView);
            m_fileTreeView = new FrmFileTreeView(m_windowManager);
            m_deserializeDockContent = GetContentFromPersistString;
            m_folderHistory = new FrmFileFolders(FileFolderContentType.Folder, TrackerType.History, Trackers.HistoryTracker);
            m_popularFolders = new FrmFileFolders(FileFolderContentType.Folder, TrackerType.Popular, Trackers.PopularFoldersTracker);
            m_windowManager.WindowOpened += m_windowManager_WindowOpened;
            InitPluginEventHandlers();
        }

        void m_windowManager_WindowOpened(object sender, WindowEventArgs e)
        {
            var window = e.BaseWindow as IExplorerWindow;
            if (window != null)
            {
                window.Navigated += MainForm_Navigated;
            }
        }

        void MainForm_Navigated(object sender, NavigatedEventArgs e)
        {
            if (e.FolderInfo.IsFileSystemPath)
            {
                Trackers.HistoryTracker.Add(e.FolderInfo);
                Trackers.PopularFoldersTracker.Add(e.FolderInfo);
            }
        }

        private void InitPluginEventHandlers()
        {
            m_fileTreeView.RootNavigated += (sender, args) => OnRootNavigated(args.FolderInfo);
            m_windowManager.ViewStyleChanged += (sender, args) => OnViewStyleChanged(args.NewViewStyle);
            m_windowManager.WindowOpened += (sender, args) => OnWindowOpened(args.BaseWindow);
            m_windowManager.WindowClosed += (sender, args) => OnWindowClosed(args.BaseWindow);
        }

        #region Plugins

        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<IPlugin>> Plugins { get; set; }
        private CompositionContainer m_container;

        public void LoadPlugins()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly()));

            var di = new DirectoryInfo(Workspace.PluginsPath());
            var folders = di.GetDirectories().Select(x => x.FullName);

            foreach (string folder in folders)
            {
                var directoryCatalog = new DirectoryCatalog(folder);
                catalog.Catalogs.Add(directoryCatalog);
            }

            m_container = new CompositionContainer(catalog);
            m_container.ComposeParts(this);

            foreach (var plugin in Plugins)
            {
                try
                {
                    plugin.Value.Initialize(this);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #region IPluginHost Members

        public event EventHandler<NavigatedEventArgs> RootNavigated;
        public event EventHandler<ViewChangedEventArgs> ViewStyleChanged;
        public event EventHandler<WindowEventArgs> WindowOpened;
        public event EventHandler<WindowEventArgs> WindowClosed;
        public event EventHandler<EventArgs> ApplicationClosing;

        public IEnumerable<BaseWindow> OpenedWindows 
        {
            get { return m_windowManager.Windows; }
        }

        public void Register(ToolStrip toolStrip)
        {
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip);
        }

        public void Register(UserControl dockContent, DockFormStyle state)
        {
            if (state == DockFormStyle.Document)
            {
                throw new NotSupportedException("DockState cannot be value of DockState.Document");
            }

            var dockFrm = new FrmPluginDock(dockContent);
            dockFrm.Show(dockPanel, state.ToDockState());
        }

        public void Register(BaseView view)
        {
           m_windowManager.AddView(view);
        }

        public void AddWindow(BaseWindow window)
        {
            m_windowManager.AddWindow(window);
        }

        public void ChangeView(Guid view)
        {
            m_windowManager.ChangeView(ViewStyle.Flow);
        }

        public void RegisterKeyStroke(KeystrokeAction keystrokeAction)
        {
            KeystrokeActions.RegisterAction(keystrokeAction);
        }

        private void OnRootNavigated(IFolderInfo fi)
        {
            if (RootNavigated != null)
            {
                RootNavigated(this, new NavigatedEventArgs(fi));
            }
        }

        private void OnViewStyleChanged(Guid newViewStyle)
        {
            if (ViewStyleChanged != null)
            {
                ViewStyleChanged(this, new ViewChangedEventArgs(newViewStyle));
            }
        }

        private void OnWindowOpened(BaseWindow window)
        {
            if (WindowOpened != null)
            {
                WindowOpened(this, new WindowEventArgs(window));
            }
        }

        private void OnWindowClosed(BaseWindow window)
        {
            if (WindowClosed != null)
            {
                WindowClosed(this, new WindowEventArgs(window));
            }
        }

        private void OnApplicationClosing()
        {
            if (ApplicationClosing != null)
            {
                ApplicationClosing(this, new EventArgs());
            }
        }

        #endregion


        #endregion

        public void AddWindow(string path)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) delegate
                {
                    var fv = new WinExplorerWindow(path);
                    m_windowManager.AddWindow(fv);
                });
            }
            else
            {
                var fv = new WinExplorerWindow(path);
                m_windowManager.AddWindow(fv);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tsMainMenu.Renderer = new NoLineToolStripRendere();

            Workspace.Settings.Load();
            Measures.SplitterSize = 30;

            var theme = new VS2012LightTheme();
            theme.Apply(dockPanel);

            if (File.Exists(Workspace.AppTempPath("dock.xml")))
            {
                dockPanel.LoadFromXml(Workspace.AppTempPath("dock.xml"), m_deserializeDockContent);
            }
            else
            {
                m_fileView.Show(dockPanel, DockState.Document);
                m_fileTreeView.Show(dockPanel, DockState.DockLeft);
                m_folderHistory.Show(m_fileTreeView.Pane, DockAlignment.Bottom, 0.50);
                m_popularFolders.Show(m_folderHistory.Pane, DockAlignment.Right, 0.50);
            }
            InitializeMainMenu();
       //     LoadPlugins();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyValue >= 48 && e.KeyValue <= 57)
            {
                int pressedNum = e.KeyValue - 48;
                m_windowManager.MarkByNum(pressedNum);
            }

            KeystrokeActions.NotifyActions(e.KeyCode, e.Modifiers);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (Workspace.Settings.CloseAction == AppCloseAction.MinimizeToTaskbar)
                {
                    e.Cancel = true;
                    WindowState = FormWindowState.Minimized;
                }
                else if (Workspace.Settings.CloseAction == AppCloseAction.MinimizeToTray)
                {
                    e.Cancel = true;
                    WindowState = FormWindowState.Minimized;
                }
            }
            Trackers.HistoryTracker.Save();
            Trackers.PopularFoldersTracker.Save();

            dockPanel.SaveAsXml(Workspace.AppTempPath("dock.xml"));
            OnApplicationClosing();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (Workspace.Settings.CloseAction == AppCloseAction.MinimizeToTray)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    MinimizeToTray();
                }
            }
        }

        #region Keystroke Actions

        private void InizializeKeystrokeActions()
        {
            RegisterKeyStroke(new KeystrokeAction(
                KeystrokeActions.ViewFlow,
                "Switch to windows view",
                Keys.F,
                Keys.Control, (act) => m_windowManager.ChangeView(ViewStyle.Flow)));

            RegisterKeyStroke(new KeystrokeAction(
                KeystrokeActions.ViewFlow,
                "Switch to tabbed view",
                Keys.W,
                Keys.Control, (act) => m_windowManager.ChangeView(ViewStyle.Full)));

            RegisterKeyStroke(new KeystrokeAction(
               KeystrokeActions.ViewFlow,
               "Show options",
               Keys.O,
               Keys.Control, (act) =>
               {
                   var frm = new FrmOptions();
                   frm.ShowDialog(this);
               }));
        }


        #endregion

        private void MinimizeToTray()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            notifyIcon.Visible = true;
            ShowInTaskbar = false;
        }

        private void RestoreFromTray()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
            notifyIcon.Icon = null;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RestoreFromTray();
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof (FrmFileTreeView).ToString())
            {
                return m_fileTreeView;
            }
            else if(persistString == typeof(FrmFileView).ToString())
            {
                return m_fileView;
            }
            else if(persistString.StartsWith(typeof(FrmFileFolders).ToString()))
            {
                var val = persistString.Split('#');
                FileFolderContentType ct;

                if(!FileFolderContentType.TryParse(val[1], out ct))
                {
                    return null;
                }

                TrackerType tt;
                if (!TrackerType.TryParse(val[2], out tt))
                {
                    return null;
                }

                if (tt == TrackerType.History)
                {
                    return m_folderHistory;
                }
                else
                {
                    return m_popularFolders;
                }
            }
            return null;
        }

        #region Main menu

        private void InitializeMainMenu()
        {
            var tsmiCurrentView = new ToolStripMenuItem("Current view");

            foreach (var view in m_windowManager.Views)
            {
                var tsmiCurrentViewStyle = new ToolStripMenuItem(view.ViewStyleName);
                tsmiCurrentViewStyle.Tag = view.ViewStyleType;
                tsmiCurrentViewStyle.CheckOnClick = false;
                tsmiCurrentViewStyle.Checked = m_windowManager.CurrentViewStyle == view.ViewStyleType;
                tsmiCurrentViewStyle.Click += (s, e) =>
                {
                    var newView = ((Guid) ((ToolStripMenuItem) s).Tag);
                    m_windowManager.ChangeView(newView);
                    foreach (var item in tsmiCurrentView.DropDownItems.OfType<ToolStripMenuItem>())
                    {
                        item.Checked = item == s;
                    }
                };
                tsmiCurrentView.DropDownItems.Add(tsmiCurrentViewStyle);
            }
            var tsmiView = (ToolStripDropDownButton)tsMainMenu.Items.Find("tsddbView", false)[0];
            tsmiView.DropDownItems.Add(tsmiCurrentView);
        }


        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiOptions_Click(object sender, EventArgs e)
        {
            var frm = new FrmOptions();
            frm.ShowDialog(this);
        }

        #endregion

        private void tsmiPluginManager_Click(object sender, EventArgs e)
        {
            var frm = new FrmPluginManager();
            frm.Show(this);
        }
    }
}