using System;
using System.Drawing;

namespace PathFinder.Core.Plugins
{
    public interface IPluginInfo
    {
        Guid PluginId { get; }

        Icon Icon { get; }

        string Name { get; }

        string Description { get; }

        string Version { get; }

        string CreatedBy { get; }
    }
}
