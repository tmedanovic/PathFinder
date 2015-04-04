namespace PathFinder.Core.Plugins
{
    public interface IPlugin
    {
        string Name { get; }

        string Description { get; }

        string Version { get; }
    }
}
