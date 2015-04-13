using System;
using System.Collections.Generic;
using PathFinder.Core.Controls;
using PathFinder.Core.Plugins;

namespace PathFinder.Service
{
    public interface IPluginService
    {
        void UploadPlugin(PluginPackage pluginPackage);

        IPagedList<IServerPluginInfo> GetAvailablePlugins(string serchTerm, int page, int pageSize, int type);

        IPagedList<IServerPluginInfo> GetPluginUpdates(IEnumerable<IPluginInfo> plugins);

        IPagedList<IServerPluginInfo> GetPluginInfo(IEnumerable<IPluginInfo> plugins);

        PluginPackage DownloadPlugin(Guid pluginId, string version);
    }
}
