using System;

namespace PathFinder.Core.Windows
{
    public class WindowEventArgs : EventArgs
    {
        public WindowEventArgs(BaseWindow baseWindow)
        {
            BaseWindow = baseWindow;
        }

        public BaseWindow BaseWindow { get; set; }
    }
}