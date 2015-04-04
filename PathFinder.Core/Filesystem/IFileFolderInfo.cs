using System.Drawing;

namespace PathFinder.Core.Filesystem
{
    public interface IFileFolderInfo
    {
        string ParsingName { get; }

        string DisplayName { get; }

        bool IsFolder { get;}

        Icon Icon { get; }
    }
}