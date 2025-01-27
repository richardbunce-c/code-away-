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
         Given an array of ints length 3, figure out which is larger between the first and last elements
         in the array, and set all the other elements to be that value. Return the changed array.
         MaxEnd3([1, 2, 3]) → [3, 3, 3]
         MaxEnd3([11, 5, 9]) → [11, 11, 11]
         MaxEnd3([2, 11, 3]) → [3, 3, 3]
         */
        public int[] MaxEnd3(int[] nums)
        {
            int[] maxVal = new int[3];
            maxVal[0] = nums[0];
            if (nums[2] >= maxVal[0]) maxVal[0] = nums[2];
            maxVal[1] = maxVal[0];
            maxVal[2] = maxVal[0];
            return maxVal;
        }

    }
}
