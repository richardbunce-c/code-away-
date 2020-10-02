using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
   [TestClass]
    public class MaxEnd3Test
    {
   [TestMethod]
   public void MakeArrayTest()
        {
            MaxEnd3 maxarray = new MaxEnd3();

            int[] endLarger = maxarray.MakeArray(new int[] { 1, 0, 3 });
            int[] endLarger2 = maxarray.MakeArray(new int[] { 1, 10, 3 });

            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, endLarger);
            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, endLarger2);
        }
    [TestMethod]
    public void MakeArrayTest2()
        {
            MaxEnd3 maxArray2 = new MaxEnd3();

            int[] startLarger = maxArray2.MakeArray(new int[] { 13, 0, 3 });
            int[] startLarger2 = maxArray2.MakeArray(new int[] { 13,20, 3 });

            CollectionAssert.AreEqual(new int[] { 13, 13, 13 }, startLarger);
            CollectionAssert.AreEqual(new int[] { 13, 13, 13 }, startLarger2);
        }
    [TestMethod]
    public void MakeArrayTest3()
        {
            MaxEnd3 maxArray3 = new MaxEnd3();

            int[] startLarger = maxArray3.MakeArray(new int[] { 10, 0, 10 });
            int[] startLarger2 = maxArray3.MakeArray(new int[] { 10, 20, 10 });

            CollectionAssert.AreEqual(new int[] { 10, 10, 10 }, startLarger);
            CollectionAssert.AreEqual(new int[] { 10, 10, 10 }, startLarger2);
        }
    
    }
}
/*
         Given an array of ints length 3, figure out which is larger between the first and last elements 
         in the array, and set all the other elements to be that value. Return the changed array.
         MakeArray([1, 2, 3]) → [3, 3, 3]
         MakeArray([11, 5, 9]) → [11, 11, 11]
         MakeArray([2, 11, 3]) → [3, 3, 3]
         */