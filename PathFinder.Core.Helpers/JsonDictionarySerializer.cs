namespace PathFinder.Core.Helpers
{
    public class JsonDictionarySerializer<TKey,TVal> : JsonFileSerializer<SerializableDictionary<TKey, TVal>>
    {
        public JsonDictionarySerializer(string fileName) : base(fileName)
        {
        }

        public object Get(TKey key)
        {
            TVal obj;
            Item.Dictionary.TryGetValue(key, out obj);
            return obj;
        }

        public void SetValue(TKey key, TVal value)
        {
            Item.Dictionary[key] = value;
        }

        public bool Exists(TKey key)
        {
            return Item.Dictionary.ContainsKey(key);
        }

        public bool GetBool(TKey key)
        {
            return (bool)Get(key);
        }

        public int GetInt(TKey key)
        {
            return (int)Get(key);
        }

        public string GetString(TKey key)
        {
            return (string)Get(key);
        }
    }
}