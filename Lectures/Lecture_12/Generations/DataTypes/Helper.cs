using System.Collections.Generic;

namespace DataTypes
{
    public static class Helper
    {
        public static List<T>   SomeMagicMethod<T>(this List<T> list)
        {
            return new List<T>(list);
        }
    }
}