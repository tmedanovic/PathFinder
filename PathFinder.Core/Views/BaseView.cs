using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PathFinder.Core.Windows;

namespace PathFinder.Core.Views
{
    public abstract class BaseView : IView
    {
        protected Control Container { get; set; }

        public event EventHandler<WindowEventArgs> WindowRemoved;
        public event EventHandler<WindowReorderEventArgs> WindowReorder;
        public event EventHandler<EventArgs> NewWindow;

        public abstract Guid ViewStyleType { get; }

        public abstract string ViewStyleName { get; }

        protected BaseView(Control container)
        {
            Container = container;
        }

        public abstract void AddWindow(BaseWindow baseWindow);
        public abstract void RemoveWindow(BaseWindow baseWindow);
        public abstract void SetWindows(IEnumerable<BaseWindow> windows);
        public abstract void ShowView();
        public abstract void HideView();

        protected virtual void OnWindowRemoved(BaseWindow baseWindow)
        {
            if (WindowRemoved != null)
            {
                WindowRemoved(this, new WindowEventArgs(baseWindow));
            }
        }

        protected virtual void OnWindowReorder(BaseWindow baseWindow, int newIndex)
        {
            if (WindowReorder != null)
            {
                WindowReorder(this, new WindowReorderEventArgs(baseWindow, newIndex));
            }
        }

        protected virtual void OnNewWindow()
        {
            if (NewWindow != null)
            {
                NewWindow(this, new EventArgs());
            }
        }
    }
}
