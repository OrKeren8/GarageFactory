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

        public static void PrintingStringList(List<string> StringsList, bool withIndex=false)
        {
            int i = 1;
            string indexStr = "";
            if(StringsList.Count == 0)
            {
                Console.WriteLine("No details to show");
            }
            else
            {
                foreach (string currentString in StringsList)
                {
                    indexStr = withIndex ? $"{i}. " : "";
                    Console.WriteLine($"{indexStr}{currentString}");
                    i++;
                }
            }
            
        }

        public static List<string> GetStringListOfENum<T>() where T : Enum
        {
            List<string> stringOfEnumList = new List<string>();
            foreach (T enumToString in Enum.GetValues(typeof(T)))
            {
                stringOfEnumList.Add($"{enumToString.GetHashCode()}. {enumToString}");
            }

            return stringOfEnumList;
        }
    }
}
