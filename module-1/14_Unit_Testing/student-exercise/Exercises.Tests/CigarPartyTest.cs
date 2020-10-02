using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
   [TestClass]
    public class CigarPartyTest
    {
        [TestMethod]
        public void CigarParty()
        {
            CigarParty testCigarParty = new CigarParty();

            Assert.AreEqual(false, testCigarParty.HaveParty(30, false));
            Assert.AreEqual(true, testCigarParty.HaveParty(50, false));
            Assert.AreEqual(true, testCigarParty.HaveParty(70, true));
        }
    }
}
/*
       When squirrels get together for a party, they like to have cigars. A squirrel party is successful
       when the number of cigars is between 40 and 60, inclusive. Unless it is the weekend, in which case 
       there is no upper bound on the number of cigars. Return true if the party with the given values is 
       successful, or false otherwise.
       haveParty(30, false) → false
       haveParty(50, false) → true
       haveParty(70, true) → true
       */