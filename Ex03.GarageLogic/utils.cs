
using System;

namespace Ex03.GarageLogic
{
    internal class utils
    {
        public class ValueOutOfRangeException : Exception
        {
            public float MaxValue { get; }
            public float MinValue { get; }

            public ValueOutOfRangeException(float i_maxValue, float i_minValue)
            {
                MaxValue = i_maxValue;
                MinValue = i_minValue;
            }
        }

    }
}
