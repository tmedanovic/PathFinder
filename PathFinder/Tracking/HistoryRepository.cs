using System;
using System.Collections.Generic;
using System.Linq;
using GongSolutions.Shell.Interop;
using PathFinder.Core.Filesystem;
using PathFinder.Core.Helpers;

namespace PathFinder.WinForms.Tracking
{
    public class HistoryRepository : JsonFileSerializer<List<SerializeableKeyValue<string, DateTime>>>, IGenericRepository<IFileFolderInfo>
    {
        public event EventHandler<EventArgs> Changed;

        public HistoryRepository(string fileName)
            : base(fileName)
        {

        }

        public void Add(IFileFolderInfo item)
        {
            var lastEntry = Item.LastOrDefault();

            if (lastEntry == null || lastEntry.Key != item.ParsingName)
            {
                Item.Add(new SerializeableKeyValue<string, DateTime>(item.ParsingName, DateTime.UtcNow));
            }

            if (Item.Count > 20)
            {
                Item.RemoveAll(x => Item.IndexOf(x) > 20);
            }
            OnChanged();
        }

        public void Remove(IFileFolderInfo item)
        {
            Remove(item.ParsingName);
        }

        private void Remove(string path)
        {
            Item.RemoveAll(x => x.Key == path);
            OnChanged();
        }

        public IEnumerable<IFileFolderInfo> GetAll()
        {
            var items = Item.OrderByDescending(x => x.Value)
                .Select(x => x.Key).ToList();
                
            var info = new List<IFileFolderInfo>();
            foreach (var item in items)
            {
                try
                {
                    info.Add(ShellHelper.FolderInfoFromPath(item));
                }
                catch (Exception)
                {
                    
                   Remove(item);
                }
            }
            return info;
        }

        private void OnChanged()
        {
            if (Changed != null)
            {
                Changed(null, new EventArgs());
            }
        }
    }
}