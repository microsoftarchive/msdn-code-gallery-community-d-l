using System;

namespace MasaSam.Data.Mapping
{
    internal static class EnumUtility
    {
        public static bool IsEnumType(Type type)
        {
            return type.Equals(typeof(SByte)) ||
                   type.Equals(typeof(Int16)) ||
                   type.Equals(typeof(Int32)) ||
                   type.Equals(typeof(Int64)) ||
                   type.Equals(typeof(Byte)) ||
                   type.Equals(typeof(UInt16)) ||
                   type.Equals(typeof(UInt32)) ||
                   type.Equals(typeof(UInt64));
        }
    }
}
