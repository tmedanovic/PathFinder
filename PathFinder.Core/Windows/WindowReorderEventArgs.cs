using System;

namespace PathFinder.Core.Windows
{
    public class WindowReorderEventArgs : EventArgs
    {
        public WindowReorderEventArgs(BaseWindow baseWindow, int newIndex)
        {
            BaseWindow = baseWindow;
        }

        public BaseWindow BaseWindow { get; set; }

        public int NewIndex { get; set; }
    }
}