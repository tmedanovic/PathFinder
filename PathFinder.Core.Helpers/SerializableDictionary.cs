using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace PathFinder.Core.Helpers
{
    public class SerializableDictionary<T,TL>
    {
        [XmlIgnore]
        public Dictionary<T, TL> Dictionary = new Dictionary<T, TL>();

        public SerializeableKeyValue<T, TL>[] DictionarySerializable
        {
            get
            {
                var list = new List<SerializeableKeyValue<T, TL>>();
                if (Dictionary != null)
                {
                    list.AddRange(Dictionary.Keys.Select(key => new SerializeableKeyValue<T, TL>() { Key = key, Value = Dictionary[key] }));
                }
                return list.ToArray();
            }
            set
            {
                Dictionary = new Dictionary<T, TL>();
                foreach (var item in value)
                {
                    Dictionary.Add(item.Key, item.Value);
                }
            }
        }
    }

    public class SerializeableKeyValue<T1, T2>
    {
        public SerializeableKeyValue()
        {
        }

        public SerializeableKeyValue(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }

        public T1 Key { get; set; }
        public T2 Value { get; set; }
    }
}
