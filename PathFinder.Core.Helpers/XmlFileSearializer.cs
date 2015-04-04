using System.Xml.Serialization;

namespace PathFinder.Core.Helpers
{
    public static class XmlFileSearializer<T>
    {
        /// <summary>
        /// Saves to an xml file
        /// </summary>
        /// <param name="filename">File path of the new xml file</param>
        public static void Save(string filename, T obj)
        {
            using (var writer = new System.IO.StreamWriter(filename))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
                writer.Flush();
            }
        }

        public static T Load(string filename)
        {
            using (var stream = System.IO.File.OpenRead(filename))
            {
                var serializer = new XmlSerializer(typeof (T)) ;
                return (T)serializer.Deserialize(stream);
            }
        }
    }
}
