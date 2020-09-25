﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of int values, return a Dictionary<int, int> with a key for each int, with the value the
         * number of times that int appears in the array.
         *
         * ** The lesser known cousin of the the classic WordCount **
         *
         * IntCount([1, 99, 63, 1, 55, 77, 63, 99, 63, 44]) → {1: 2, 44: 1, 55: 1, 63: 3, 77: 1, 99:2}
         * IntCount([107, 33, 107, 33, 33, 33, 106, 107]) → {33: 4, 106: 1, 107: 3}
         * IntCount([]) → {}
         *
         */
        public Dictionary<int, int> IntCount(int[] ints)
        {
            Dictionary<int, int> intDict = new Dictionary<int, int>();

            for (int i = 0; i < ints.Length; i++)
            {
                int counter = 1;

                if (!intDict.ContainsKey(ints[i]))
                {
                    for (int j = i + 1; j < ints.Length; j++)
                    {
                        if (ints[i] == ints[j])
                        {
                            counter++;
                        }
                    }

                    intDict.Add(ints[i], counter);
                }
            }

            return intDict;
        }
    }
}
