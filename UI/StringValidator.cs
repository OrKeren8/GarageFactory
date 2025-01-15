using System;
using Utils;

namespace UI
{
    public class StringValidator
    {
        public static (bool, Menu.eMenuSelect) CheckUserMainMenuSelection(string i_UserSelection)
        {
            bool isValid = false;
            int digit, maxEnumVal;
            Menu.eMenuSelect userSelect = 0;

            maxEnumVal = Utils.General.GetMaxEnumValue<Menu.eMenuSelect>();

            (isValid, digit) = isDigitInRange(i_UserSelection, 0, maxEnumVal);

            if (isValid)
            {
                userSelect = (Menu.eMenuSelect)digit;
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


        /// <summary>
        /// check if the string of the status is correct
        /// </summary>
        /// <param name="i_StatusInput"></param>
        /// <returns></returns>
        public static bool IsValidStatus(string i_StatusInput)//todo
        {
            bool isValid = true;
            if((i_StatusInput.ToLower()!= "in progress") || (i_StatusInput.ToLower() != "fixed") || (i_StatusInput.ToLower() != "paid") || (i_StatusInput.ToLower() != ""))
            {
                isValid=false;
            }
            return isValid;

        }
    }

}
