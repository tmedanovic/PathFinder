using System.Collections.Generic;
using System.Linq;

namespace PathFinder.WinForms.Helpers
{
    public static class DictionaryExtensions
    {
        public static void RenameKey<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey fromKey, TKey toKey)
        {
            TValue value = dic[fromKey];
            dic.Remove(fromKey);
            dic[toKey] = value;
        }

        public static void ReorderDictionary(this IDictionary<int, object> dic, int fromKey, int toKey)
        {
            if (dic.ContainsKey(toKey))
            {
                for (int i = dic.Keys.Last(); i <= toKey; i--)
                {
                    RenameKey(dic, i, i + 1);
                }
            }
          //  RenameKey(dic, fromKey);
        }
    }
}
