using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Controls;
using PathFinder.Core.Views;
using PathFinder.Core.Windows;
using PathFinder.WinForms.Controls.Windows;

namespace PathFinder.WinForms.VIew
{
    public class TabbedView : BaseView
    {
        private readonly TabControl m_fullViewPanel;
        private readonly ContextMenuStrip m_contextMenu;
        private readonly TabPage m_newTab;

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
            m_fullViewPanel = new TabControl();
            m_fullViewPanel.Dock = DockStyle.Fill;
            m_fullViewPanel.Visible = false;
            m_fullViewPanel.MouseDown += m_fullViewPanel_MouseDown;

            //New tab
            m_newTab = new TabPage("  +  ");
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
            m_fullViewPanel.SuspendLayout();

            var selectedTabIndex = (int)m_contextMenu.Tag;

            for (var i = m_fullViewPanel.TabPages.Count - 1; i >= 0; i--)
            {
                if (i != selectedTabIndex && i != NewTabIndex)
                {
                    CallWindowRemoving(i);
                }
            }

            m_fullViewPanel.ResumeLayout();
        }

        void tsmiCloseAllTabs_Click(object sender, EventArgs e)
        {
            m_fullViewPanel.SuspendLayout();

            for (var i = m_fullViewPanel.TabPages.Count - 1; i >= 0 ; i--)
            {
                if( i != NewTabIndex)
                {
                    CallWindowRemoving(i);
                }
            }

            m_fullViewPanel.ResumeLayout();
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
                for (var i = 0; i < m_fullViewPanel.TabPages.Count; i++)
                {
                    if (i != NewTabIndex)
                    {
                        var r = m_fullViewPanel.GetTabRect(i);
                        var closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);

                        if (closeButton.Contains(e.Location))
                        {
                            CallWindowRemoving(i);
                            break;
                        }
                    }
                }

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

            var tab = AddTab(winExplorerWindow);
            m_fullViewPanel.SelectedTab = tab;
            MoveNewTab();

            m_fullViewPanel.ResumeLayout();
        }

        public override void RemoveWindow(BaseWindow baseWindow)
        {
            m_fullViewPanel.SuspendLayout();

            var tab = m_fullViewPanel.TabPages.Cast<TabPage>().SingleOrDefault(x => x.Controls.Contains(baseWindow));

            if (tab != null)
            {
                RemoveTabPage(tab);
            }

            MoveNewTab();
            SelectLastTab();

            m_fullViewPanel.ResumeLayout();
        }

        private TabPage AddTab(BaseWindow baseWindow)
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
            m_fullViewPanel.TabPages.Add(tp);
            baseWindow.Dock = DockStyle.Fill;
            return tp;
        }

        private string TabName(string filename)
        {
            return (filename.Length > 200 ? filename.Remove(200) + "..." : filename) + "    x";
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
