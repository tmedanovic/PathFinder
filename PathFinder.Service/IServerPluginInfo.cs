using System;
using PathFinder.Core.Plugins;

namespace PathFinder.Service
{
    public interface IServerPluginInfo : IPluginInfo
    {
        DateTime PublishDate { get; }

        int PluginType { get; }
    }
}
