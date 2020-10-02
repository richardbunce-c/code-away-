using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTest
    {
        [TestMethod]
        public void NonStartHelloThereTest()
        {
            NonStart stringpart = new NonStart();
            NonStart stringpart2 = new NonStart();
            NonStart stringpart3 = new NonStart();

            string partialstring = stringpart.GetPartialString("Hello", "There");
            string partialstring2 = stringpart2.GetPartialString("", "There");
            string partialstring3 = stringpart3.GetPartialString("Hello", "");


            Assert.AreEqual("ellohere", partialstring);
            Assert.AreEqual("here", partialstring2);
            Assert.AreEqual("ello", partialstring3);

        }

        [TestMethod]
        public void NonStartJavaCodeTest()
        {
            NonStart stringpart = new NonStart();
            NonStart stringpart2 = new NonStart();
            NonStart stringpart3 = new NonStart();

            string partialstring = stringpart.GetPartialString("java", "code");
            string partialstring2 = stringpart2.GetPartialString("", "code");
            string partialstring3 = stringpart3.GetPartialString("java", "");


            Assert.AreEqual("avaode", partialstring);
            Assert.AreEqual("ode", partialstring2);
            Assert.AreEqual("ava", partialstring3);

        }
        [TestMethod]
        public void NonStartShotlJavaTest()
        {
            NonStart stringpart = new NonStart();
            NonStart stringpart2 = new NonStart();
            NonStart stringpart3 = new NonStart();

            string partialstring = stringpart.GetPartialString("shotl", "java");
            string partialstring2 = stringpart2.GetPartialString("", "java");
            string partialstring3 = stringpart3.GetPartialString("shotl", "");


            Assert.AreEqual("hotlava", partialstring);
            Assert.AreEqual("ava", partialstring2);
            Assert.AreEqual("hotl", partialstring3);


        }
    }
}
/*
   Given 2 strings, return their concatenation, except omit the first char of each. The strings will 
   be at least length 1.
   GetPartialString("Hello", "There") → "ellohere"
   GetPartialString("java", "code") → "avaode"	
   GetPartialString("shotl", "java") → "hotlava"	
   */