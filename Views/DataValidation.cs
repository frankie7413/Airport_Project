using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Airline_Semester_Project_attempt4
{
    // This class will contains all the functions to
    // validate data, and it is static class
    public static class DataValidation
    {
        public static bool IsBlank(string data)
        {
            bool valid = false;

            if (string.IsNullOrWhiteSpace(data))
                valid = true;

            return valid;
        }       
               

        public static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static bool IsLength(string data, int length)
        {
            bool valid = false;

            if (data.Length == length)
                valid = true;

            return valid;
        }

        public static bool IsEmail(string strEmail)
        {
            Regex rgxEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                       @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                       @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            return rgxEmail.IsMatch(strEmail);
        }

        // http://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp
        public static bool IsAllLetters(string data)
        {
            foreach (char c in data)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}
