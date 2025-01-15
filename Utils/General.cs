using System;
using System.Linq;

namespace Utils
{
    public class General
    {
        public static int GetMaxEnumValue<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Max();
        }
    }
}
