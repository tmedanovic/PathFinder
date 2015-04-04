namespace PathFinder.Core.Filesystem
{
    public interface IFileInfo : IFileFolderInfo
    {
        string Extension { get; }
    }
}