
using System;

namespace Ex03.GarageLogic
{
    internal class Utils
    {
        public class ValueOutOfRangeException : Exception
        {
            public float MaxValue { get; }
            public float MinValue { get; }

            public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            {
                MaxValue = i_MaxValue;
                MinValue = i_MinValue;
            }
        }

    }
}
