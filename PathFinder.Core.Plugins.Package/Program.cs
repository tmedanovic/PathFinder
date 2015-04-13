using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using PathFinder.Core.Plugins;

namespace PathFinder.Plugins.Package
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("You must specify you plugin path and output folder");
            }

            var sourcePath = args[0];
            var pp = new PlugingPack();
            pp.LoadPlugins(sourcePath);
        }
    }

    class PlugingPack
    {
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<IPlugin, IPluginInfo>> Plugins { get; set; }

        private CompositionContainer m_container;
        
        public void LoadPlugins(string path)
        {
            var catalog = new AggregateCatalog();
            var directoryCatalog = new DirectoryCatalog(path);
            catalog.Catalogs.Add(directoryCatalog);

            var plgGrp = Plugins.GroupBy(x => x.GetType().ReflectedType.Assembly.GetName()).Where(g => g.Count() > 1).ToList();

            if (plgGrp.Any())
            {
               // Console.WriteLine("Error:" + String.Format("IPlugin detected multiple times in same assambly({0})", plgGrp.First(x=> x.Key)));
            }
        }
    }
}
