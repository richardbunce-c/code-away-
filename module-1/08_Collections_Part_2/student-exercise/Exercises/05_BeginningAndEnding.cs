using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of non-empty strings, return a Dictionary<string, string> where for every different string in the array,
         * there is a key of its first character with the value of its last character.
         *
         * BeginningAndEnding(["code", "bug"]) → {"b": "g", "c": "e"}
         * BeginningAndEnding(["man", "moon", "main"]) → {"m": "n"}
         * BeginningAndEnding(["muddy", "good", "moat", "good", "night"]) → {"g": "d", "m": "t", "n": "t"}
         */
        public Dictionary<string, string> BeginningAndEnding(string[] words)
        {
            //Create a dictionary to return
            Dictionary<string, string> resultDict = new Dictionary<string, string>();
            // Loop through the string array that was given to us
            foreach (string s in words)
            {


                //Get the first and last chars of the string
                string firstChar = s.Substring(0, 1);
                string lastChar = s.Substring(s.Length - 1);
                //Add/update the dictionary with key=first char and value=last char
                resultDict[firstChar] = lastChar;
            }
            //Return dictionary that we built
            return resultDict;
        }
    }
}
