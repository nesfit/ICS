using System.Collections.Generic;

namespace PassingParameters
{
    public static class Helper
    {
        public static List<byte> SomeMagicMethod(List<byte> list)
        {
            return new List<byte>(list);
        }
    }
}