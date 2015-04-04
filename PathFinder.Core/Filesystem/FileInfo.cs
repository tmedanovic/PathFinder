using System.Drawing;
using System.IO;

namespace PathFinder.Core.Filesystem
{
    public class FileInfo : IFileInfo
    {
        public FileInfo()
        {
        }

        public FileInfo(string path)
        {
            ParsingName = path;
            DisplayName = Path.GetFileName(path);
            IsFolder = false;
            Icon = Icon.ExtractAssociatedIcon(path);
            Extension = Path.GetExtension(path);
        }

        public string ParsingName { get; set; }

        public string DisplayName { get; set; }

        public bool IsFolder { get; set; }

        public Icon Icon { get; set; }

        public string Extension { get; set; }
    }
}
