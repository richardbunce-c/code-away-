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
         Given a string of even length, return a string made of the middle two chars, so the string "string"
         yields "ri". The string length will be at least 2.
         MiddleTwo("string") → "ri"
         MiddleTwo("code") → "od"
         MiddleTwo("Practice") → "ct"
         */
        public string MiddleTwo(string str)
        {

            int len = str.Length;
            return str.Substring(len / 2 - 1, len / 2 + 1);


            //int mid = str.Length / 2;
            //String beforeMid = str.Substring(mid - 1, mid);
            //String afterMid = str.Substring(mid, mid + 1);
            //return beforeMid + afterMid;
            
            
            //int half = str.Length / 2;
            //return str.Substring(half -1, half +1 );
        }
    }
}