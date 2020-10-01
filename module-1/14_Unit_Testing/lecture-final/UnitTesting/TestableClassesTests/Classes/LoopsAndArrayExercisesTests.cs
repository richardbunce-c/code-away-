using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableClasses.Classes.Tests
{
    [TestClass]
    public class LoopsAndArrayExercisesTests
    {
        //CollectionAssert
        //.AllItemsAreNotNull() - Looks at each item in actual collection for not null
        //.AllItemsAreUnique() - Checks for uniqueness among actual collection
        //.AreEqual() - Checks to see if two collections are equal (same order and quantity)
        //.AreEquilavent() - Checks to see if two collections have same element in same quantity, any order
        //.AreNotEqual() - Opposite of AreEqual
        //.AreNotEquilavent() - Opposite or AreEqualivent
        //.Contains() - Checks to see if collection contains a value/object


        /************************************************
         * Middleway Tests
         ************************************************
         */
        /*
        Given 2 int arrays, a and b, each length 3, return a new array length 2 containing their middle 
        elements.
        middleWay([1, 2, 3], [4, 5, 6]) → [2, 5]
        middleWay([7, 7, 7], [3, 8, 0]) → [7, 8]
        middleWay([5, 2, 9], [1, 4, 5]) → [2, 4]
         */

        [TestMethod]
        public void ThreePositiveIntegersTest()
        {
            // Arrange - create two 3-integer arrays of positive numbers and create an instance of the CUT (class under test)
            int[] a = new int[] { 1, 2, 3 };
            int[] b = new int[] { 4, 5, 6 };
            LoopsAndArrayExercises exercises = new LoopsAndArrayExercises();

            // Act
            int[] actual = exercises.MiddleWay(a, b);

            //Assert

            // Make sure the result is two elements long
            Assert.AreEqual(2, actual.Length, "The length of the result should be 2");

            // Check for correct element values
            Assert.AreEqual(2, actual[0], "The first element is incorrect");
            Assert.AreEqual(5, actual[1], "The second element is incorrect");


        }

        [TestMethod]
        public void ThreePositiveIntegersTest_2()
        {
            // Arrange - create two 3-integer arrays of positive numbers and create an instance of the CUT (class under test)
            int[] a = new int[] { 7, 7, 7 };
            int[] b = new int[] { 3, 8, 0 };
            LoopsAndArrayExercises exercises = new LoopsAndArrayExercises();

            // Act
            int[] actual = exercises.MiddleWay(a, b);

            //Assert

            // Make sure the result is two elements long
            Assert.AreEqual(2, actual.Length, "The length of the result should be 2");
//            Assert.IsTrue(actual.Length == 1, "The length of the result should be 2");

            // Check for correct element values
            Assert.AreEqual(7, actual[0], "The first element is incorrect");
            Assert.AreEqual(8, actual[1], "The second element is incorrect");


        }
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 2, 5 }, DisplayName = "1,2,3 & 4,5,6")]
        [DataRow(new int[] { 7, 7, 7 }, new int[] { 3, 8, 0 }, new int[] { 7, 8 })]
        [DataRow(new int[] { 5, 2, 9 }, new int[] { 1, 4, 5 }, new int[] { 2, 4 })]
        [DataRow(new int[] { -42, -5, -8 }, new int[] { -1, -2, -3 }, new int[] { -5, -2 }, DisplayName = "Test negative integers")]
        public void ThreeIntegers_DataTests(int[] a, int[] b, int[] expectedArray)
        {
            // Arrange - create two 3-integer arrays of positive numbers and create an instance of the CUT (class under test)
            LoopsAndArrayExercises exercises = new LoopsAndArrayExercises();

            // Act
            int[] actual = exercises.MiddleWay(a, b);

            //Assert

            // Make sure the result is two elements long
            Assert.AreEqual(2, actual.Length, "The length of the result should be 2");

            // Check for correct element values
            //Assert.AreEqual(expectedArray[0], actual[0], "The first element is incorrect");
            //Assert.AreEqual(expectedArray[1], actual[1], "The second element is incorrect");

            CollectionAssert.AreEquivalent(expectedArray, actual, "The arrays are not equal");
        }


    }
}