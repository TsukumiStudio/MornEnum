using System;
using System.Collections.Generic;

namespace MornLib
{
    public static class MornEnumUtil<T> where T : Enum
    {
        private static List<T> _sEnumList;
        private static readonly Dictionary<T, string> _sToStringDictionary = new();
        public static int Count => Values.Count;

        public static IReadOnlyList<T> Values
        {
            get
            {
                if (_sEnumList != null) return _sEnumList;

                _sEnumList = new List<T>();
                foreach (var value in Enum.GetValues(typeof(T))) _sEnumList.Add((T)value);

                return _sEnumList;
            }
        }

        public static string CachedToString(T value)
        {
            if (_sToStringDictionary.TryGetValue(value, out var st)) return st;

            _sToStringDictionary.Add(value, value.ToString());
            return _sToStringDictionary[value];
        }
    }
}