using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
   [TestClass]
    public class StringBitsTest
    {
        [TestMethod]
        public void StringBitsHelloTest()
        {
            StringBits stringStringBits = new StringBits();

            string result= stringStringBits.GetBits("Hello");
            Assert.AreEqual("Hlo", result);
 }
        [TestMethod]
        public void StringBitsHiTest()
        {
            StringBits stringStringBits = new StringBits();

            string result = stringStringBits.GetBits("Hi");
            Assert.AreEqual("H", result);
        }
        [TestMethod]
        public void StringBitsHeeololeoTest()
        {
            StringBits stringStringBits = new StringBits();

            string result = stringStringBits.GetBits("Heeololeo");
            Assert.AreEqual("Hello", result);
        }



    }
}

/*
 Given a string, return a new string made of every other char starting with the first, so "Hello" yields "Hlo".
 GetBits("Hello") → "Hlo"	
 GetBits("Hi") → "H"	
 GetBits("Heeololeo") → "Hello"	
 */