using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using PathFinder.Core.Controls;
using PathFinder.Core.Plugins;

namespace PathFinder.Service
{
    public class PluginTestService : IPluginService
    {
        public void UploadPlugin(PluginPackage pluginPackage)
        {
            throw new NotImplementedException();
        }

        public IPagedList<IServerPluginInfo> GetAvailablePlugins(string serchTerm, int pageIndex, int pageSize, int type)
        {
            var list = new List<IServerPluginInfo>();

            for(int i = 0; i < 50 ; i++)
            {
                var plg = new PluginInfo();
                plg.PluginId = Guid.NewGuid();
                plg.Name = "Plugin " + i.ToString();
                plg.Description = "This is plugin test description";
                plg.Version = "1.0.0";
                plg.CreatedBy = "Test developer";
                plg.Icon = SystemIcons.Warning;
                plg.PublishDate = DateTime.UtcNow;
                plg.PluginType = (int) PluginType.Untested;
                list.Add(plg);
            }

            return new PagedList<IServerPluginInfo>(list, pageIndex, pageSize);
        }

        public IPagedList<IServerPluginInfo> GetPluginUpdates(IEnumerable<IPluginInfo> plugins)
        {
            throw new NotImplementedException();
        }

        public PluginPackage DownloadPlugin(Guid pluginId, string version)
        {
            throw new NotImplementedException();
        }

        private class PluginInfo : IServerPluginInfo
        {
            public Guid PluginId { get; set; }
            public Icon Icon { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Version { get; set; }
            public string CreatedBy { get; set; }
            public DateTime PublishDate { get; set; }
            public int PluginType { get; set; }
        }

        private class PagedList<T> : IPagedList<T>
        {
            public PagedList(IEnumerable<T> source, int pageIndex, int pageSize)
            {
                PreviousPages = new List<int>();
                NextPages = new List<int>();
                PageIndex = pageIndex;
                PageSize = pageSize;
                TotalCount = source.Count();
                TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
                Items = source.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
                AddNextPages();
                AddPreviousPages();
            }

            private void AddPreviousPages()
            {
                for (int i = 6; i >= 1; i--)
                {
                    if ((PageIndex - i) >= 1)
                    {
                        PreviousPages.Add(PageIndex - i);
                    }
                }
            }

            private void AddNextPages()
            {
                for (int i = 1; i < 6 && (i + PageIndex) <= TotalPages; i++)
                {
                    NextPages.Add(PageIndex + i);
                }
            }

            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public int TotalCount { get; set; }
            public int TotalPages { get; set; }
            public List<int> PreviousPages { get; set; }
            public List<int> NextPages { get; set; }
            public List<T> Items { get; set; }
        }
    }
}
