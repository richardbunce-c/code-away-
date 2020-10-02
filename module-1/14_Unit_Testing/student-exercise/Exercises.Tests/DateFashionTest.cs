using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTest
    {
        DateFashion thisDateFashion = new DateFashion();
        [TestMethod]
        public void GetATableTest()
        {

            int result = thisDateFashion.GetATable(5, 10);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void GetATableTest2()
        {
            int result = thisDateFashion.GetATable(5, 2);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetATableTest3()
        {
            int result = thisDateFashion.GetATable(5,5 );
            Assert.AreEqual(1, result);
        }
    }
}


/*
      You and your date are trying to get a table at a restaurant. The parameter "you" is the stylishness
      of your clothes, in the range 0..10, and "date" is the stylishness of your date's clothes. The result
      getting the table is encoded as an int value with 0=no, 1=maybe, 2=yes. If either of you is very 
      stylish, 8 or more, then the result is 2 (yes). With the exception that if either of you has style of 
      2 or less, then the result is 0 (no). Otherwise the result is 1 (maybe).
      dateFashion(5, 10) → 2
      dateFashion(5, 2) → 0
      dateFashion(5, 5) → 1
      */