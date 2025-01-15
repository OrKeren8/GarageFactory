
using System;

namespace Utils
{
    public class Exceptions
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
        public enum ErrorCode
        {
            VehicleTypeNotExist = 1001,
            VehiceNotExist = 1002,
            VehicleAlreadyExist = 1003,
            TooManyInvalidInputs = 2000
        }

        public class AppException : Exception
        {
            public ErrorCode ErrorCode { get; }

            public AppException(string message, ErrorCode errorCode)
                : base($"{message} (Error Code: {(int)errorCode})")
            {
                ErrorCode = errorCode;
            }
        }
    }
}
