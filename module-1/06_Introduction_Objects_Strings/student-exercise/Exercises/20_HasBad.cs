﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string, return true if "bad" appears starting at index 0 or 1 in the string, such as with
         "badxxx" or "xbadxx" but not "xxbadxx". The string may be any length, including 0. Note: use .equals()
         to compare 2 strings.
         HasBad("badxx") → true
         HasBad("xbadxx") → true
         HasBad("xxbadxx") → false
         */
        public bool HasBad(string str)
        {

            return (str.IndexOf("bad") == 0 || str.IndexOf("bad") == 1);
            
            
            //if (str.Length <= 2)
            //    return false;
            //if (str.Length == 3)
            //    return str.Substring(0, 3) == ("bad");
            //return str.Substring(0, 3) == ("bad") || str.Substring(1, 4) == ("bad");
        }
    }
}
