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
         * Just when you thought it was safe to get back in the water --- Last2Revisited!!!!
         *
         * Given an array of strings, for each string, the count of the number of times that a substring length 2 appears
         * in the string and also as the last 2 chars of the string, so "hixxxhi" yields 1.
         *
         * We don't count the end substring, but the substring may overlap a prior position by one.  For instance, "xxxx"
         * has a count of 2, one pair at position 0, and the second at position 1. The third pair at position 2 is the
         * end substring, which we don't count.
         *
         * Return Dictionary<string, int>, where the key is string from the array, and its last2 count.
         *
         * Last2Revisited(["hixxhi", "xaxxaxaxx", "axxxaaxx"]) → {"hixxhi": 1, "xaxxaxaxx": 1, "axxxaaxx": 2}
         *
         */
        public Dictionary<string, int> Last2Revisited(string[] words)
        {

            //Create an empty dictionary
            Dictionary<string, int> last2Count = new Dictionary<string, int>();

            //Loop through each string in words
            foreach (string word in words)
            {
                //Add word, with count  ==0
                last2Count[word] = 0;

                //if length <3, count will be zero.
                if (word.Length<3)
                {
                    continue;
                }
                //create a substring for the last 2 char
                string last2 = word.Substring(word.Length - 2);


                //loop through chars of the string, starting at 0, while i<s.length-2
                for (int i=0; i <word.Length-2; i++)
                {
                    //if substr(i,2)=last2, increment count / update dict entry
                    if(word.Substring(i, 2)== last2)
                            {
                    last2Count[word]++;
                }
                }

            }
            //return dict
            return last2Count;
        }
    }
}
