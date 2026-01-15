using System;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    public abstract class MornEnumBase
    {
        [SerializeField] private string _key;
        public string Key
        {
            get => _key;
            set => _key = value;
        }
        public int Index
        {
            get => Array.IndexOf(Values, _key);
            set => _key = Values[value];
        }
        protected abstract string[] Values { get; }

        public static bool operator ==(MornEnumBase a, MornEnumBase b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            return a._key == b._key;
        }

        public static bool operator !=(MornEnumBase a, MornEnumBase b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is MornEnumBase other)
            {
                return this == other;
            }
            
            return false;
        }
        
        public override int GetHashCode()
        {
            return _key != null ? _key.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return _key;
        }

        public static implicit operator string(MornEnumBase enumBase)
        {
            return enumBase._key;
        }
    }
}