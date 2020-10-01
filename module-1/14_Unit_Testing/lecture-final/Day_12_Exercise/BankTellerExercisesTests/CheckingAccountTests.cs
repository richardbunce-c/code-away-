using BankTellerExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercisesTests
{
    [TestClass]
    public class CheckingAccountTests
    {
        [TestMethod]
        public void OverdrawTestWithin100()
        {
            // Arrange
            CheckingAccount checking = new CheckingAccount("Name", "12345", 100);

            // Act
            int actual = checking.Withdraw(150);

            // Assert

            // Return value is correct
            Assert.AreEqual(-60, actual, "Return value was incorrect");

            // Balance has been update

            Assert.AreEqual(-60, checking.Balance);

        }
    }
}
