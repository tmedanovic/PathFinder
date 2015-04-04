using System.Drawing;
using System.IO;
using GongSolutions.Shell;

namespace PathFinder.Core.Filesystem
{
    public class FolderInfo : IFolderInfo
    {
        public FolderInfo()
        {
        }

        public FolderInfo(string parsingName, bool isFileSystemPath, string displayName)
        {
            ParsingName = parsingName;
            IsFileSystemPath = isFileSystemPath;
            DisplayName = displayName;
        }

        public string ParsingName { get; set; }

        public bool IsFileSystemPath { get; set; }

        public string DisplayName { get; set; }

        public bool IsFolder
        {
            get { return true; }
        }

        public Icon Icon { get; set; }
    }
}