using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using PathFinder.Core.Plugins;
using PathFinder.Service;
using PathFinder.WinForms.App;

namespace PathFinder.WinForms.Plugins
{
    public class PluginManager
    {
        private IPluginService m_pluginService;

        public void InstallPlugin(Guid pluginId, string packagePath)
        {
            var pluginPath = Path.Combine(Workspace.PluginsPath(), pluginId.ToString());
            ZipFile.ExtractToDirectory(packagePath, pluginPath);
        }

        public void UninstallPlugin(Guid pluginId)
        {
            var pluginPath = Path.Combine(Workspace.PluginsPath(), pluginId.ToString());
            Directory.Delete(pluginPath);
        }

        public void UpdatePlugin(Guid pluginId, string version)
        {
            UninstallPlugin(pluginId);
            DownloadAndInstall(pluginId, version);
        }

        private void DownloadAndInstall(Guid pluginId, string version)
        {
            var downloadedPackPath = DownladPlugin(pluginId, version);
            InstallPlugin(pluginId, downloadedPackPath);
            File.Delete(downloadedPackPath);
        }

        private string DownladPlugin(Guid pluginId, string version)
        {
           //Download plugin
           var pluginPackage = m_pluginService.DownloadPlugin(pluginId, version);
           
           //Get package path
           var pluginFolderName = pluginId.ToString();
           var pluginDownloadPath = Path.Combine(Workspace.PluginsPath(), "Packages", pluginFolderName);

           //Save plugin as file
           File.WriteAllBytes(pluginDownloadPath, pluginPackage.PackageFile);
           return pluginDownloadPath;
        }

        private IEnumerable<Guid> GetInstalledPlugins()
        {
            var di = new DirectoryInfo(Workspace.PluginsPath());
            var pluginfolderNames = di.GetDirectories().Select(x => x.Name);

            var installedPluginGuids = new List<Guid>();

            foreach (var pFolderName in pluginfolderNames)
            {
                Guid pluginId;
                if(Guid.TryParse(pFolderName, out pluginId))
                {
                    installedPluginGuids.Add(pluginId);
                }
            }
            return installedPluginGuids;
        }
    }
}
