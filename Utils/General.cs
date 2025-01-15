using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class General
    {
        public static int GetMaxEnumValue<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Max();
        }
        public static void PrintingStringList(List<string> StringsList)
        {
            foreach (string currentString in StringsList)
            {
                Console.WriteLine($"{currentString}");
            }
        }
    }
}
