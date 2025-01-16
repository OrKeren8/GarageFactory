using Ex03.GarageLogic;
using System;
using Utils;

namespace UI
{
    public class StringValidator
    {
        public static (bool, T) CheckStringOfEnum<T>(string i_UserSelection) where T : Enum
        {
            bool isValid = false;
            int digit, maxEnumVal;
            T userSelect = default;

            maxEnumVal = Utils.General.GetMaxEnumValue<T>();

            (isValid, digit) = IsDigitInRange(i_UserSelection, 0, maxEnumVal);

            if (isValid)
            {
                userSelect = (T)Enum.ToObject(typeof(T), digit);
            }

            return (isValid, userSelect);
        }

        public static (bool, int) IsDigitInRange(string i_Digit, int i_Min, int i_Max)
        {
            bool isDigit;
            int digit = 0;

            isDigit = int.TryParse(i_Digit, out digit);
            if (!isDigit)
            {
                digit = 0;
            }
            else if((digit >= i_Min) && (digit <= i_Max))
            {
                isDigit = true;
                digit = int.Parse(i_Digit);
            }
            else
            {
                isDigit = false;
            }

            return (isDigit, digit);
        }

        public static (bool, float) IsInt(string i_Num)
        {
            bool isInt;
            float num = 0;

            isInt = float.TryParse(i_Num, out num);
            

            return (isInt, num);
        }

        static public (bool, string) IsValidLicenseNumber(string i_LicenseNumber)
        {
            bool isValid = true;

            return (isValid, i_LicenseNumber);
        }

        static public (bool, object) tryCastToType(string i_DataToCast, Type i_TargetType)
        {

            object targetData = null;
            bool isValid = true;

            try
            {
                if (i_TargetType == typeof(string))
                {
                    targetData = i_DataToCast;
                }
                else if (i_TargetType.IsEnum)
                {
                    targetData = Enum.Parse(i_TargetType, i_DataToCast, ignoreCase: true);
                }
                else
                {
                    targetData = Convert.ChangeType(i_DataToCast, i_TargetType);
                }
            }
            catch
            {
                isValid = false;
            }

            return (isValid, targetData);
        }
    }
}
