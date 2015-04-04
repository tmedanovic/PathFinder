using System;
using PathFinder.Core.Filesystem;

namespace PathFinder.Core
{
    public class NavigatedEventArgs : EventArgs
    {
        public NavigatedEventArgs(IFolderInfo folderInfo)
        {
            FolderInfo = folderInfo;
        }

        public IFolderInfo FolderInfo { get; set; }
    }
}