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
         * Given an array of strings, return a Dictionary<string, int> with a key for each different string, with the value the
         * number of times that string appears in the array.
         *
         * ** A CLASSIC **
         *
         * WordCount(["ba", "ba", "black", "sheep"]) → {"ba" : 2, "black": 1, "sheep": 1 }
         * WordCount(["a", "b", "a", "c", "b"]) → {"b": 2, "c": 1, "a": 2}
         * WordCount([]) → {}
         * WordCount(["c", "b", "a"]) → {"b": 1, "c": 1, "a": 1}
         *
         */
        public Dictionary<string, int> WordCount(string[] words)
        {
            //Create a dictionary for our result
            Dictionary<string, int> resultDict = new Dictionary<string, int>();
            //Loop through the input array
            foreach (string s in words)
            {
                //Determine if the string is already in the dict
                if (resultDict.ContainsKey(s))
                {
                    //If it is already there, increment the count(value)
                    //resultDict[s]++;
                    resultDict[s] = resultDict[s] + 1;
                }
                else
                {
                    //Else (it is not yet in the dict), add it with a count (value) of 1.
                    
                    resultDict.Add(s, 1);
                }



                
            }
            //return the result dict
            
            
            return resultDict;
        }
    }
}
