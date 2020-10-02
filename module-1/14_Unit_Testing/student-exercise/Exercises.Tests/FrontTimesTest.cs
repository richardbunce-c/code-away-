using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    class FrontTimesTest
    {
        [TestClass]
        public class FrontTimesStringTest
        {
            FrontTimes stringTest = new FrontTimes();
            [TestMethod]
            public void GenerateStringTest()
            {
                string result = stringTest.GenerateString("Chocolate", 2);
                Assert.AreEqual("ChoCho", result);

            }
            [TestMethod]
            public void GenerateStringTest2()
            {
                string result = stringTest.GenerateString("Chocolate", 3);
                Assert.AreEqual("ChoChoCho", result);

            }



            [TestMethod]
        public void GenerateStringTest3()
            {
                string result = stringTest.GenerateString("Abc", 3);
                Assert.AreEqual("AbcAbcAbc", result);
            }
        
        }
    }
}
/*
        Given a string and a non-negative int n, we'll say that the front of the string is the first 3 chars, or 
        whatever is there if the string is less than length 3. Return n copies of the front;
        frontTimes("Chocolate", 2) → "ChoCho"	
        frontTimes("Chocolate", 3) → "ChoChoCho"	
        frontTimes("Abc", 3) → "AbcAbcAbc"	
        */