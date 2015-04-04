using System;

namespace PathFinder.Core.Views
{
    public class ViewChangedEventArgs : EventArgs
    {
        public ViewChangedEventArgs(Guid newViewStyle)
        {
            NewViewStyle = newViewStyle;
        }

        public Guid NewViewStyle { get; set; }
    }
}