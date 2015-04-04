using System;
using System.IO;
using System.Web.Script.Serialization;

namespace PathFinder.Plugins.PopularFileFolder.Helpers
{
    public class JsonFileSerializer<T> where T : class, new()
    {
        public string Filename { get; private set; }
        public string Folder { get; private set; }

        public T Item = new T();

        public JsonFileSerializer(string folderName, string fileName)
        {
            Filename = fileName;
            Folder = folderName;
        }
 
        private string FullPath()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(folder, Folder);

            // Check if folder exists and if not, create it
            if (!Directory.Exists(specificFolder))
            {
                Directory.CreateDirectory(specificFolder);
            }

            return Path.Combine(specificFolder, Filename);
        }

        public void Save()
        {
            SaveFile(Item, FullPath());
        }

        public static void SaveFile(T pSettings, string path)
        {
            File.WriteAllText(path , (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public void Load()
        {
            Item = LoadFile(FullPath());
        }

        private static T LoadFile(string path)
        {
            T t = new T();
            if (File.Exists(path))
            {
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(path));
                
            }
            return t;
        }
    }
}