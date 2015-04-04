using System.IO;
using GongSolutions.Shell;

namespace PathFinder.Core.Filesystem
{
    public static class ShellHelper
    {
        public static IFolderInfo FolderInfoFromPath(string path)
        {
            return FolderInfoFromShellItem(new ShellItem(path));
        }

        public static IFileInfo FileInfoFromPath(string path)
        {
            return FileInfoFromShellItem(new ShellItem(path));
        }

        public static IFileFolderInfo FromPath(string path)
        {
            return FromShellItem(new ShellItem(path));
        }

        public static IFileFolderInfo FromShellItem(ShellItem item)
        {
            if (item.IsFolder)
            {
                return FolderInfoFromShellItem(item);
            }
            return FileInfoFromShellItem(item);
        }

        public static IFolderInfo FolderInfoFromShellItem(ShellItem item)
        {
            var folderInfo = new FolderInfo();
            folderInfo.DisplayName = item.DisplayName;
            folderInfo.Icon = item.ShellIcon;
            folderInfo.IsFileSystemPath = item.IsFileSystem;
            folderInfo.ParsingName = item.ParsingName;
            return folderInfo;
        }

        public static IFileInfo FileInfoFromShellItem(ShellItem item)
        {
            var fileInfo = new FileInfo();
            fileInfo.DisplayName = item.DisplayName;
            fileInfo.Extension = Path.GetExtension(item.FileSystemPath);
            fileInfo.Icon = item.ShellIcon;
            fileInfo.ParsingName = item.FileSystemPath;
            return fileInfo;
        }
    }
}
