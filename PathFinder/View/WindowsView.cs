using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PathFinder.Core;
using PathFinder.Core.Views;
using PathFinder.Core.Windows;
using PathFinder.WinForms.Controls.Windows;

namespace PathFinder.WinForms.VIew
{
    public class WindowsView : BaseView
    {
        private readonly FlowLayoutPanel m_flowViewPanel;

        public WindowsView(Control container) : base(container)
        {
            m_flowViewPanel = new FlowLayoutPanel();
            m_flowViewPanel.Dock = DockStyle.Fill;
            m_flowViewPanel.Visible = false;
            m_flowViewPanel.AllowDrop = true;
            m_flowViewPanel.AutoScroll = true;
            m_flowViewPanel.DragEnter += m_flowViewPanel_DragEnter;
            m_flowViewPanel.DragDrop += m_flowViewPanel_DragDrop;
            m_flowViewPanel.Padding = new Padding(10);
            Container.Controls.Add(m_flowViewPanel);
        }

        void m_flowViewPanel_DragDrop(object sender, DragEventArgs e)
        {
            var data = (WinExplorerWindow)e.Data.GetData(typeof(WinExplorerWindow));
            var destination = (FlowLayoutPanel)sender;

            var p = destination.PointToClient(new Point(e.X, e.Y));
            var item = destination.GetChildAtPoint(p);
            var index = destination.Controls.GetChildIndex(item, false);
            destination.Controls.SetChildIndex(data, index);
            destination.Invalidate();

          //  OnWindowReorder(data, index);
        }

        void m_flowViewPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        public override Guid ViewStyleType
        {
            get { return ViewStyle.Flow; }
        }

        public override string ViewStyleName
        {
            get { return "Windows"; }
        }

        public override void AddWindow(BaseWindow baseWindow)
        {
            var explorerWindow = baseWindow as IExplorerWindow;
            if (explorerWindow != null)
            {
                explorerWindow.NonFileSystemTileView = false;
            }
            baseWindow.Initialize();
            baseWindow.Dock = DockStyle.None;
            baseWindow.ControlBorderStyle = BorderStyle.FixedSingle;
            m_flowViewPanel.Controls.Add(baseWindow);
        }

        public override void RemoveWindow(BaseWindow baseWindow)
        {
           m_flowViewPanel.Controls.Remove(baseWindow);
        }

        public override void SetWindows(IEnumerable<BaseWindow> windows)
        {
            m_flowViewPanel.SuspendLayout();
            m_flowViewPanel.Controls.Clear();

            foreach (var fileView in windows)
            {
                AddWindow(fileView);
            }
            m_flowViewPanel.ResumeLayout();
            m_flowViewPanel.Show();
        }

        public override void ShowView()
        {
            m_flowViewPanel.Show();
        }

        public override void HideView()
        {
            m_flowViewPanel.Hide();
        }
    }
}
