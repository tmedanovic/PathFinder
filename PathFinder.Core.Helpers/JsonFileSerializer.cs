using System.IO;
using System.Web.Script.Serialization;

namespace PathFinder.Core.Helpers
{
    public class JsonFileSerializer<T> where T : class, new()
    {
        public string Filename { get; private set; }
        public T Item = new T();

        public JsonFileSerializer(string filename)
        {
            Filename = filename;
        }
 
        public void Save()
        {
            SaveFile(Item, Filename);
        }

        public static void SaveFile(T pSettings, string path)
        {
            File.WriteAllText(path , (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public void Load()
        {
            Item = LoadFile(Filename);
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