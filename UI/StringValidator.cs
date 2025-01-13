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
        public static bool IsValidLicenseNumber(string i_LicenseInput)//todo
        {

        }
        public static bool IsValidStatus(string i_StatusInput)//todo
        {

        }
    }

}
