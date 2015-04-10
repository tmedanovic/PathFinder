namespace PathFinder.Core.Plugins
{
    public interface IPluginInfo
    {
        string Name { get; }

        string Description { get; }

        string Version { get; }
    }
}
