namespace PathFinder.Core.Filesystem
{
    public interface IFolderInfo : IFileFolderInfo
    {
        bool IsFileSystemPath { get; }
    }
}