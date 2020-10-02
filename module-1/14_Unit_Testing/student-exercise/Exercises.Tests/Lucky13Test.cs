using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Exercises;

namespace Exercises.Tests
{
    [TestClass]
    public class Lucky13Tests
    {
        [TestMethod]
        public void GotLuckyTest()
        {
         
            Lucky13 gotLucky = new Lucky13();

            bool expectedResult = gotLucky.GetLucky(new int[] { 0, 2, 4 });
            bool expected2Result = gotLucky.GetLucky(new int[] { 2, 5, 6, 4 });
            bool expected3Result = gotLucky.GetLucky(new int[] { 400, 5, 6, 7, 8, 9 });
            bool expected4Result = gotLucky.GetLucky(new int[] { 32, 13, 30 });


            Assert.AreEqual(true, expectedResult);
            Assert.AreEqual(true, expected2Result);
            Assert.AreEqual(true, expected3Result);
            Assert.AreEqual(true, expected4Result);



        }
        [TestMethod]
        public void GotLucky2Test()
   {
            Lucky13 notLucky = new Lucky13();

            Assert.AreEqual(false, notLucky.GetLucky(new int[] { 10, 2, 4, 1 }));
            Assert.AreEqual(false, notLucky.GetLucky(new int[] { 1, 3 }));
        }
    }
}
/*
    Given an array of ints, return true if the array contains no 1's and no 3's.
    GetLucky([0, 2, 4]) → true
    GetLucky([1, 2, 3]) → false
    GetLucky([1, 2, 4]) → false
    */