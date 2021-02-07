using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PayTureTest.Extensions
{
    /// <summary>
    /// Класс расширения для словарей
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// Преобразовать словарь в класс
        /// Источник <see href="http://www.herlitz.nu/2012/12/31/mapping-dictionary-to-typed-object-using-c/">www.herlitz.nu</see>
        /// </summary>
        /// <typeparam name="T">Класс который хотим получить</typeparam>
        /// <param name="dict">Словарь который преобразуем</param>
        public static T ToObject<T>(this IDictionary<string, string> dict) where T : new()
        {
            var t = new T();
            if (dict == null)
                return t;

            var properties = t.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!dict.Any(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                var item = dict.First(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));

                var tPropertyType = t.GetType().GetProperty(property.Name).PropertyType;
                var newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;

                var newA = Convert.ChangeType(item.Value, newT);
                t.GetType().GetProperty(property.Name).SetValue(t, newA, null);
            }
            return t;
        }
    }
}