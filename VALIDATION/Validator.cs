using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Lab1_ConnectedMode.VALIDATION
{
   public static class Validator //Tool class
    {
        /// <summary>
        /// This method validates the input string
        /// Version 1: Working but not reusable
        /// </summary>
        /// <param name="input"></param>
        /// <returns>true if valid otherwise false</returns>
        public static bool IsValidId(string input)
        {
            if (!(Regex.IsMatch(input,@"^\d{4}$")))
            {
                return false;
            }
            return true;
        }

        //Overloaded methods : Two methods have the same name but
        //different signatures 
        public static bool IsValidId(string input,int size)
        {
            if (!(Regex.IsMatch(input,@"^\d{"+size+"}$")))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidName(string input)
        {
            if (input=="")
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!(Char.IsLetter(input[i])) && !(Char.IsWhiteSpace(input[i])))
                {
                    return false;
                }

            }

            return true;

        }

        public static bool IsEmpty(string input)
        {
            if (input=="")
            {
                return true;
            }

            return false;


        }


    }
}
