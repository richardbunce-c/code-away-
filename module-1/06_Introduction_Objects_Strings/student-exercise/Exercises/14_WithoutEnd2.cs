using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string, return a version without both the first and last char of the string. The string
         may be any length, including 0.
         WithoutEnd2("Hello") → "ell"
         WithoutEnd2("abc") → "b"
         WithoutEnd2("ab") → ""
         */
        public string WithoutEnd2(string str)
        {
            //If the string is two chars or less, return ""
            if (str.Length<=2)
                {
                return "";
            }
            //Now I know it's at least 3 characters.
            //Find the substring starting at the second character and ending at the second-last.
            //Said another way, the length
            return str.Substring(1, str.Length-2);
        }
    }
}
