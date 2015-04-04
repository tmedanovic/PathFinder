using System;
using System.Collections.Generic;
using System.Linq;
using PathFinder.Core.Filesystem;
using PathFinder.Core.Helpers;

namespace PathFinder.WinForms.Tracking
{
    public class FavoritesRepository : JsonDictionarySerializer<string, int>, IGenericRepository<IFileFolderInfo>
    {
        public event EventHandler<EventArgs> Changed;

        public FavoritesRepository(string fileName) : base(fileName)
        {

        }

        public void Add(IFileFolderInfo item)
        {
            if (Item.Dictionary.ContainsKey(item.ParsingName))
            {
                Item.Dictionary[item.ParsingName]++;
                Sort();
            }
            else
            {
                Item.Dictionary.Add(item.ParsingName, 1);
            }
            OnChanged();
        }

        private void Sort()
        {
            Item.Dictionary = Item.Dictionary
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public void Remove(IFileFolderInfo item)
        {
            Item.Dictionary.Remove(item.ParsingName);
            OnChanged();
        }

        public IEnumerable<IFileFolderInfo> GetAll()
        {
            return Item.Dictionary.ToList().Select(x => x.Key).ToList().Select(ShellHelper.FolderInfoFromPath);
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