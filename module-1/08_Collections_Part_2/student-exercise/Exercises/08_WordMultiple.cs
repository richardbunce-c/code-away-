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
         * Given an array of strings, return a Dictionary<string, Boolean> where each different string is a key and value
         * is true only if that string appears 2 or more times in the array.
         *
         * WordMultiple(["a", "b", "a", "c", "b"]) → {"b": true, "c": false, "a": true}
         * WordMultiple(["c", "b", "a"]) → {"b": false, "c": false, "a": false}
         * WordMultiple(["c", "c", "c", "c"]) → {"c": true}
         *
         */
        public Dictionary<string, bool> WordMultiple(string[] words)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();

            for (int i = 0; i < words.Length; i++)
            {
                int counter = 1;
                if (!result.ContainsKey(words[i]))
                {
                    for (int j = i + 1; j < words.Length; j++)
                    {
                        if (words[i].Equals(words[j]))
                        {
                            counter++;
                        }
                    }

                    if (counter >= 2)
                    {
                        result.Add(words[i], true);
                    }
                    else
                    {
                        result.Add(words[i], false);
                    }
                }
            }
            return result;
        }
    }
}
