using System;
using System.Collections.Generic;
using PathFinder.Core.Windows;

namespace PathFinder.Core.Views
{
    public interface IView
    {
        event EventHandler<WindowEventArgs> WindowRemoved;
        event EventHandler<WindowReorderEventArgs> WindowReorder;
        event EventHandler<EventArgs> NewWindow;
        Guid ViewStyleType { get; }
        void AddWindow(BaseWindow baseWindow);
        void RemoveWindow(BaseWindow baseWindow);
        void SetWindows(IEnumerable<BaseWindow> windows);
        void ShowView();
        void HideView();
    }
}