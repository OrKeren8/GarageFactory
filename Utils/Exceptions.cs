
using System;
using static Utils.Exceptions;

namespace Utils
{
    public class Exceptions
    {
        public class ValueOutOfRangeException : AppException
        {
            public float MaxValue { get; }
            public float MinValue { get; }

            public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string msg): base($"out of range error: {msg}", eErrorCode.InvalidInput)
            {
                MaxValue = i_MaxValue;
                MinValue = i_MinValue;
            }
        }
        public enum eErrorCode
        {
            VehicleTypeNotExist = 1001,
            VehiceNotExist = 1002,
            VehicleAlreadyExist = 1003,
            VehicleFuelError = 1004,
            VehicleChargeError = 1005,

            CarDoorsOutOfRange = 1100,
            CarColorError = 1101,

            MototrCyclePrepertyError = 1200,
            
            TrackPrepertyError = 1300,

            TooManyInvalidInputs = 2000,
            InvalidInput = 2001
        }

        public class AppException : Exception
        {
            public eErrorCode ErrorCode { get; }

            public AppException(string message, eErrorCode errorCode)
                : base($"{message} (Error Code: {(int)errorCode})")
            {
                ErrorCode = errorCode;
            }
        }
    }
}
