using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Controls;
using PathFinder.Core.Views;
using PathFinder.Core.Windows;
using PathFinder.WinForms.Controls.Windows;

namespace PathFinder.WinForms.View
{
    public class TabbedView : BaseView
    {
        private readonly CustomTabControl m_fullViewPanel;
        private readonly ContextMenuStrip m_contextMenu;
        private readonly CustomTabPage m_newTab;

        private int NewTabIndex
        {
            get { return m_fullViewPanel.TabPages.IndexOf(m_newTab); }
        }

        public override Guid ViewStyleType 
        {
            get
            {
                return ViewStyle.Full;
            }
        }

        public override string ViewStyleName
        {
            get { return "Tabbed"; }
        }

        public TabbedView(Control container) : base(container)
        {
            m_fullViewPanel = new CustomTabControl();
            InitializeTabControl();

            //New tab
            m_newTab = new CustomTabPage();
            m_newTab.IsNewTabButton = true;
            m_fullViewPanel.TabPages.Add(m_newTab);
            m_fullViewPanel.Selecting += m_fullViewPanel_Selecting;

            //Context menu
            m_contextMenu = new ContextMenuStrip();

            var tsmiCloseTab = new ToolStripMenuItem("Close tab");
            tsmiCloseTab.Click += tsmiCloseTab_Click;
            m_contextMenu.Items.Add(tsmiCloseTab);

            var tsmiCloseAllTabs = new ToolStripMenuItem("Close all tabs");
            tsmiCloseAllTabs.Click += tsmiCloseAllTabs_Click;
            m_contextMenu.Items.Add(tsmiCloseAllTabs);

            var tsmiCloseTabsOnRight = new ToolStripMenuItem("Close tabs on right");

            var tsmiCloseAllTabsButThis = new ToolStripMenuItem("Close all but this");
            tsmiCloseAllTabsButThis.Click += tsmiCloseAllTabsButThis_Click;
            m_contextMenu.Items.Add(tsmiCloseAllTabsButThis);

            Container.Controls.Add(m_fullViewPanel);
        }

        private void InitializeTabControl()
        {
            m_fullViewPanel.Dock = DockStyle.Fill;
            m_fullViewPanel.Visible = false;
            m_fullViewPanel.MouseDown += m_fullViewPanel_MouseDown;
            m_fullViewPanel.DisplayStyle = TabStyle.Chrome;
            m_fullViewPanel.DisplayStyleProvider.BorderColor = SystemColors.ControlDark;
            m_fullViewPanel.DisplayStyleProvider.BorderColorHot = SystemColors.ControlDark;
            m_fullViewPanel.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(127, 157, 185);
            m_fullViewPanel.DisplayStyleProvider.CloserColor = Color.DarkGray;
            m_fullViewPanel.DisplayStyleProvider.CloserColorActive = Color.White;
            m_fullViewPanel.DisplayStyleProvider.FocusTrack = false;
            m_fullViewPanel.DisplayStyleProvider.HotTrack = true;
            m_fullViewPanel.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleRight;
            m_fullViewPanel.DisplayStyleProvider.Opacity = 1F;
            m_fullViewPanel.DisplayStyleProvider.Overlap = 10;
            m_fullViewPanel.DisplayStyleProvider.Padding = new Point(15, 5);
            m_fullViewPanel.DisplayStyleProvider.Radius = 10;
            m_fullViewPanel.DisplayStyleProvider.ShowTabCloser = true;
            m_fullViewPanel.DisplayStyleProvider.TextColor = SystemColors.ControlText;
            m_fullViewPanel.DisplayStyleProvider.TextColorDisabled = SystemColors.ControlDark;
            m_fullViewPanel.DisplayStyleProvider.TextColorSelected = SystemColors.ControlText;
            m_fullViewPanel.ItemSize = new Size(200,20);
            m_fullViewPanel.TabClosing += m_fullViewPanel_TabClosing;
        }

        void m_fullViewPanel_TabClosing(object sender, TabControlCancelEventArgs e)
        {
           CallWindowRemoving(e.TabPageIndex);
        }

        void m_fullViewPanel_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == m_newTab)
            {
                e.Cancel = true;
            }
        }

        private void MoveNewTab()
        {
            m_fullViewPanel.TabPages.Remove(m_newTab);
            m_fullViewPanel.TabPages.Add(m_newTab);
        }

        void tsmiCloseAllTabsButThis_Click(object sender, EventArgs e)
        {
           CloseAllButThis((int)m_contextMenu.Tag);
        }

        private void CloseAllButThis(int index)
        {
            m_fullViewPanel.SuspendLayout();

            var selectedTabIndex = index;

            for (var i = m_fullViewPanel.TabPages.Count - 1; i >= 0; i--)
            {
                if (i != selectedTabIndex && i != NewTabIndex)
                {
                    CallWindowRemoving(i);
                }
            }

            m_fullViewPanel.ResumeLayout();
        }

        private bool m_closeAll = false;

        void tsmiCloseAllTabs_Click(object sender, EventArgs e)
        {
            m_closeAll = true;
            OnNewWindow();
        }

        void tsmiCloseTab_Click(object sender, EventArgs e)
        {
            var tabIndex = (int) m_contextMenu.Tag;
            CallWindowRemoving(tabIndex);
        }

        private void m_fullViewPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (m_fullViewPanel.GetTabRect(NewTabIndex).Contains(e.Location))
                {
                    OnNewWindow();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (m_fullViewPanel.GetTabRect(NewTabIndex).Contains(e.Location))
                {
                    return;
                }

                for (var i = 0; i < m_fullViewPanel.TabPages.Count; i++)
                {
                    var r = m_fullViewPanel.GetTabRect(i);

                    if (!r.Contains(e.Location))
                    {
                        continue;
                    }

                    m_contextMenu.Tag = i;
                    m_contextMenu.Show(m_fullViewPanel, e.X, e.Y);
                }
            }
        }

        private void CallWindowRemoving(int tabPageIndex)
        {
            var window = m_fullViewPanel.TabPages[tabPageIndex].Controls.OfType<WinExplorerWindow>().Single();
            OnWindowRemoved(window);
        }

        private void RemoveTabPage(TabPage tp)
        {
           m_fullViewPanel.TabPages.Remove(tp);
        }

        public override void AddWindow(BaseWindow winExplorerWindow)
        {
            m_fullViewPanel.SuspendLayout();

            var tab = AddTab(winExplorerWindow, true);
            m_fullViewPanel.SelectedTab = tab;

            if (m_closeAll)
            {
                m_closeAll = false;
                CloseAllButThis(m_fullViewPanel.TabPages.IndexOf(tab));
            }

            m_fullViewPanel.ResumeLayout();
        }

        public override void RemoveWindow(BaseWindow baseWindow)
        {
            var tab = m_fullViewPanel.TabPages.Cast<TabPage>().SingleOrDefault(x => x.Controls.Contains(baseWindow));

            if (tab != null)
            {
                RemoveTabPage(tab);
                SelectLastTab();
            }
        }

        private TabPage AddTab(BaseWindow baseWindow, Boolean? lastPos = null)
        {
            var tp = new TabPage(TabName(baseWindow.WindowTitle));
            var explorerWindow = baseWindow as IExplorerWindow;
            if (explorerWindow != null)
            {
                explorerWindow.NonFileSystemTileView = true;
                explorerWindow.NoHeadersInAllViews = true;
                explorerWindow.Navigated += (e,s) => tp.Text = TabName(baseWindow.WindowTitle);
            }
            baseWindow.Load += fileView_Load;
            baseWindow.Initialize();
           
            baseWindow.Parent = tp;
            baseWindow.ControlBorderStyle = BorderStyle.None;

            if (lastPos.HasValue && m_fullViewPanel.TabPages.Count > 0)
            {
                var count = m_fullViewPanel.TabPages.Count;
                var pos = count - 1;
                m_fullViewPanel.TabPages.Insert(pos, tp);
            }
            else
            {
                m_fullViewPanel.TabPages.Add(tp);
            }

            baseWindow.Dock = DockStyle.Fill;
            return tp;
        }

        private string TabName(string filename)
        {
            return (filename.Length > 200 ? filename.Remove(200) + "..." : filename);
        }

        void fileView_Load(object sender, EventArgs e)
        {
            var fileView = ((WinExplorerWindow)sender);
            fileView.FileViewStyle = ExplorerBrowserViewMode.Auto;
            fileView.ShowDetails = false;
            fileView.NoHeadersInAllViews = true;
        }

        public override void SetWindows(IEnumerable<BaseWindow> windows)
        {
            m_fullViewPanel.SuspendLayout();
            m_fullViewPanel.TabPages.Clear();

            foreach (var fileView in windows)
            {
                AddTab(fileView);
            }

            MoveNewTab();

            m_fullViewPanel.ResumeLayout();
            m_fullViewPanel.Show();

            if (m_fullViewPanel.TabPages.Count > 0)
            {
                SelectLastTab();
            }
        }

        private void SelectLastTab()
        {
            var tab = m_fullViewPanel.TabPages.Cast<TabPage>().LastOrDefault(x => x != m_newTab);
            if (tab != null)
            {
                m_fullViewPanel.SelectedTab = tab;
                tab.Focus();
            }
            else
            {
                OnNewWindow();
            }
        }

        public override void ShowView()
        {
           m_fullViewPanel.Show();
        }

        public override void HideView()
        {
            m_fullViewPanel.Hide();
        }
    }
}
