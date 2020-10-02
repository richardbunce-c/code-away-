using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTest
    {


        [TestMethod]
        public void SameFirstLastFalse()
        {
            SameFirstLast boolSameFirstLast = new SameFirstLast();

            int[] numbers = { 1, 2, 3 };
            bool result = boolSameFirstLast.IsItTheSame(numbers);
            Assert.AreEqual(false, result);

        }
        [TestMethod]
        public void SameFirstLastTrue()
        {
            SameFirstLast boolSameFirstLast = new SameFirstLast();

            int[] numbers = { 3, 2, 3 };
            bool result = boolSameFirstLast.IsItTheSame(numbers);
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void SameFirstLastTrue2()
        {
            SameFirstLast boolSameFirstLast = new SameFirstLast();

            int[] numbers = { 1, 2, 1 };
            bool result = boolSameFirstLast.IsItTheSame(numbers);
            Assert.AreEqual(true, result);
        }
    }
}
/*
     Given an array of ints, return true if the array is length 1 or more, and the first element and
     the last element are equal.
     IsItTheSame([1, 2, 3]) → false
     IsItTheSame([1, 2, 3, 1]) → true
     IsItTheSame([1, 2, 1]) → true
     */