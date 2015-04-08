using System;
using System.Collections.Generic;
using System.Linq;
using GongSolutions.Shell;
using GongSolutions.Shell.Interop;
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
            Remove(item.ParsingName);
        }

        private void Remove(string path)
        {
            Item.Dictionary.Remove(path);
            OnChanged();
        }

        public IEnumerable<IFileFolderInfo> GetAll()
        {
            var items = Item.Dictionary.OrderByDescending(x => x.Value)
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