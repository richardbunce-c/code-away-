using BankTellerExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTellerExercisesTests
{
    [TestClass]
    public class SavingsAccountTests
    {
        [TestMethod]
        public void ValidWithdrawalTest()
        {
            // Arrange
            SavingsAccount savings = new SavingsAccount("Name", "12345", 500);

            // Act
            int actual = savings.Withdraw(150);

            // Assert

            // Make sure the right balance was returned
            Assert.AreEqual(350, actual);

            // Query the account and make sure the Balance is correct
            Assert.AreEqual(350, savings.Balance);
        }

        [TestMethod]
        public void MinBalanceWithFee()
        {
            // Arrange
            SavingsAccount savings = new SavingsAccount("Name", "12345", 500);

            // Act
            int actual = savings.Withdraw(400);

            // Assert

            // Make sure the right balance was returned
            Assert.AreEqual(98, actual);

            // Query the account and make sure the Balance is correct
            Assert.AreEqual(98, savings.Balance);
        }
        [TestMethod]
        public void MinBalanceWithFeeCannotDo()
        {
            // Arrange
            SavingsAccount savings = new SavingsAccount("Name", "12345", 500);

            // Act
            int actual = savings.Withdraw(500);

            // Assert

            // Make sure the right balance was returned
            Assert.AreEqual(500, actual);

            // Query the account and make sure the Balance is correct
            Assert.AreEqual(500, savings.Balance);
        }
    }
}
