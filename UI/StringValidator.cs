using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class StringValidator
    {
        public static bool CheckUserMainMenuSelection(string i_UserSelection)
        {
            bool isValid = false;
            if (int.Parse(i_UserSelection) >= 1 || int.Parse(i_UserSelection) <= 7)
            {
                isValid = true;
            }
            return isValid;
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
