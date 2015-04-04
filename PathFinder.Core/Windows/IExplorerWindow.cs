using System;

namespace PathFinder.Core.Windows
{
    public interface IExplorerWindow
    {
        event EventHandler<NavigatedEventArgs> Navigated;

        bool NoHeadersInAllViews { get; set; }

        bool NonFileSystemTileView { get; set; }
    }
}
