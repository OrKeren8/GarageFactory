﻿using Ex03.GarageLogic;
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

            (isValid, digit) = isDigitInRange(i_UserSelection, 0, maxEnumVal);

            if (isValid)
            {
                userSelect = (T)Enum.ToObject(typeof(T), digit);
            }

            return (isValid, userSelect);
        }

        public static (bool, int) isDigitInRange(string i_Digit, int i_Min, int i_Max)
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

        static public (bool, string) IsValidLicenseNumber(string i_LicenseNumber)
        {
            bool isValid = true;

            if (i_LicenseNumber.Length != 8)
            {
                isValid = false;
            }
            else
            {
                for (int i = 0; i < i_LicenseNumber.Length; i++)
                {
                    if (i_LicenseNumber[i] <= '0' || i_LicenseNumber[i] >= '9')
                    {
                        isValid = false;
                        break;
                    }
                }
            }

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
