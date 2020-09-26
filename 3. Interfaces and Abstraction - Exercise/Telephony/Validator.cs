using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public static class Validator
    {
        public static bool IsValidNumber(string number)
        {
            return !number.Any(char.IsLetter);
            //for (int i = 0; i < number.Length; i++)
            //{
            //    if (!char.IsDigit(number[i]))
            //    {
            //        return false;
            //    }
            //}
            //return true;
        }
        public static bool IsValidWebSite(string site)
        {
            return !site.Any(char.IsDigit);

            //for (int i = 0; i < site.Length; i++)
            //{
            //    if (char.IsDigit(site[i]))
            //    {
            //        return false;
            //    }
            //}
            //return true;
        }
    }
}
