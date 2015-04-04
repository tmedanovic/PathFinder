namespace PathFinder.Core.Plugins
{
    public abstract class Plugin
    {
        private Plugin()
        {

        }

        public Plugin(IPluginHost host)
        {

        }

        public abstract string  Name { get; }

        public abstract string Description { get; }

        public abstract string Version { get; }
    }
}
