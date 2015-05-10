using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PathFinder.Core.Views;
using PathFinder.Core.Windows;
using PathFinder.WinForms.App;
using PathFinder.WinForms.Controls.Windows;
using PathFinder.WinForms.Helpers;

namespace PathFinder.WinForms.View
{
    public class WindowManager
    {
        private readonly Dictionary<int, BaseWindow> m_windows = new Dictionary<int, BaseWindow>();
        private readonly Control m_container;
        private readonly List<BaseView> m_views = new List<BaseView>();

        public event EventHandler<ViewChangedEventArgs> ViewStyleChanged;
        public event EventHandler<WindowEventArgs> WindowOpened;
        public event EventHandler<WindowEventArgs> WindowClosed;

        public Guid CurrentViewStyle { get; private set; }

        public WindowManager(Control container)
        {
            m_container = container;

            var splitViewPanel = new SplitContainer();
            splitViewPanel.Dock = DockStyle.Fill;
            splitViewPanel.Visible = false;
            m_container.Controls.Add(splitViewPanel);

            AddView(new WindowsView(container));
            AddView(new TabbedView(container));

            ChangeView(ViewStyle.Full);
        }

        public void AddView(BaseView view)
        {
            m_views.Add(view);
            view.WindowRemoved += view_WindowRemoved;
            view.WindowReorder += view_WindowReorder;
            view.NewWindow += view_NewWindow;
        }

        void view_NewWindow(object sender, EventArgs e)
        {
            var window = new WinExplorerWindow(Workspace.Settings.StartPath);
            AddWindow(window);
        }

        void view_WindowReorder(object sender, WindowReorderEventArgs e)
        {
            var oldKey = GetWindowKey(e.BaseWindow);
            m_windows.RenameKey(oldKey, e.NewIndex);
        }

        void view_WindowRemoved(object sender, WindowEventArgs e)
        {
            RemoveWindow(e.BaseWindow);
        }

        public IEnumerable<BaseWindow> Windows
        {
            get { return m_windows.OrderBy(x => x.Key).Select( x=> x.Value); }
        }

        public IEnumerable<BaseView> Views
        {
            get { return m_views.OrderByDescending(x => x.ViewStyleName); }
        }

        public int GetWindowKey(BaseWindow baseWindow)
        {
            return m_windows.FirstOrDefault(x => x.Value == baseWindow).Key;
        }

        public void AddWindow(BaseWindow baseWindow)
        {
            int i = 0;

            if (m_windows.Any())
            {
                i = m_windows.Keys.Max() + 1;
            }
            else
            {
                i = 1;
            }

            m_windows.Add(i, baseWindow);
            baseWindow.Closed += window_Closed;
            //m_views.ForEach(x => x.AddWindow(window));
            AddToCurrentView(baseWindow);
            OnWindowOpened(baseWindow);
        }

        void window_Closed(object sender, WindowEventArgs e)
        {
            RemoveWindow(e.BaseWindow);
        }

        public void RemoveWindow(BaseWindow baseWindow)
        {
            RemoveFromCurrentView(baseWindow);
            var key = GetWindowKey(baseWindow);
            m_windows.Remove(key);
            OnWindowClosed(baseWindow);
        }

        public void MarkByNum(int num)
        {
            BaseWindow baseWindow;
            if (m_windows.TryGetValue(num, out baseWindow))
            {
                baseWindow.Mark();
            }
        }

        public void ChangeView(Guid viewStyleType)
        {
            if(CurrentViewStyle == viewStyleType)
            {
                return;
            }

            //var marked = GetMarkedControls().ToList();
            m_container.SuspendLayout();

            HideAllViews();
            CurrentViewStyle = viewStyleType;
            GetView(viewStyleType).SetWindows(Windows);

            m_container.ResumeLayout();

            OnViewStyleChanged(viewStyleType);
        }

        private BaseView GetView(Guid viewStyleType)
        {
            return m_views.Single(x => x.ViewStyleType == viewStyleType);
        }

        private BaseView GetCurrentView()
        {
            return GetView(CurrentViewStyle);
        }

        private void AddToCurrentView(BaseWindow baseWindow)
        {
            GetCurrentView().AddWindow(baseWindow);
        }

        private void RemoveFromCurrentView(BaseWindow baseWindow)
        {
            GetCurrentView().RemoveWindow(baseWindow);
        }

        private void HideAllViews()
        {
            m_views.ForEach(x => x.HideView());
        }

        private IEnumerable<BaseWindow> GetMarkedControls()
        {
            return m_windows.Values.Where(x => x.Marked);
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
    }
}