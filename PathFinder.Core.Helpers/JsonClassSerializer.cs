using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace PathFinder.Core.Helpers
{
    public class JsonClassSerializer<T> where T: new()
    {
        private readonly JsonDictionarySerializer<string, object> m_serializer;

        public JsonClassSerializer(string fileName)
        {
            m_serializer = new JsonDictionarySerializer<string, object>(fileName);
        }

        public void Load(T instance)
        {
            m_serializer.Load();

            foreach (var targetProp in GetSerializableProps(instance))
            {
                var sourceVal = GetDefault(typeof(T));

                if (m_serializer.Exists(targetProp.Name))
                {
                    sourceVal = m_serializer.Get(targetProp.Name);
                }
                else
                {
                    var defAttr = GetDefaultValue(instance, targetProp.Name);

                    if (defAttr != null)
                    {
                        sourceVal = defAttr.Value;
                    }
                }

                targetProp.SetValue(instance, sourceVal, null);
            }
        }

        public void Save(T instance)
        {
            foreach (var sourceProp in GetSerializableProps(instance))
            {
                var sourceVal = sourceProp.GetValue(instance, null);
                m_serializer.SetValue(sourceProp.Name, sourceVal);
            }
            m_serializer.Save();
        }

        private DefaultValueAttribute GetDefaultValue(T instance, string propName)
        {
            var attributes = TypeDescriptor.GetProperties(instance)[propName].Attributes;
            var myAttribute = (DefaultValueAttribute)attributes[typeof(DefaultValueAttribute)];
            return myAttribute;
        }

        private IEnumerable<PropertyInfo> GetSerializableProps(T instance)
        {
            return typeof (T).GetProperties()
                .Where(prop =>(Attribute.GetCustomAttribute(prop, typeof (ScriptIgnoreAttribute)) as ScriptIgnoreAttribute) == null);
        }

        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
