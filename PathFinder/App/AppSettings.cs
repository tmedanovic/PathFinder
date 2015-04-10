using System;
using System.ComponentModel;
using System.IO;
using PathFinder.Core.Helpers;
using PathFinder.WinForms.Helpers;

namespace PathFinder.WinForms.App
{
    public static class Workspace
    {
        public static AppSettings Settings = new AppSettings();

        public static string AppPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string PluginsPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
        }

        public static string AppTempPath(string filename)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(folder, "PathFinder");

            // Check if folder exists and if not, create it
            if (!Directory.Exists(specificFolder))
            {
                Directory.CreateDirectory(specificFolder);
            }

            if (filename != null)
            {
                return Path.Combine(specificFolder, filename);
            }
            return specificFolder;
        }
    }

    public class AppSettings
    {
        private readonly JsonClassSerializer<AppSettings> m_serializer = 
            new JsonClassSerializer<AppSettings>(Workspace.AppTempPath("options.jsn"));

        [DefaultValue(AppCloseAction.Close)]
        public AppCloseAction CloseAction { get; set; }

        [DefaultValue(false)]
        public bool SingleInstance { get; set; }

        [DefaultValue("shell:///MyComputerFolder")]
        public string StartPath { get; set; }

        [DefaultValue("shell:///Desktop")]
        public string RootPath { get; set; }

        public void Load()
        {
            m_serializer.Load(this);
        }

        public void Save()
        {
            m_serializer.Save(this);
        }
    }

    public enum AppCloseAction
    {
        Close,
        MinimizeToTray,
        MinimizeToTaskbar
    }
}
