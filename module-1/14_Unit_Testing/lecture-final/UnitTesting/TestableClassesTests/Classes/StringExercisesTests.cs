using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class StringExercisesTests
    {
        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()

        [DataTestMethod]
        [DataRow("<<>>", "Yay", "<<Yay>>")]
        [DataRow("", "Yay", "Yay", DisplayName = "Outside word is empty")]
        [DataRow("!!", "", "!!", DisplayName = "Inside word is empty")]
        [DataRow("|||", "Hey", "|Hey||", DisplayName = "Outside word has an odd number of characters")]
        [DataRow("|", "Hey", "|Hey", DisplayName = "Outside word has 1 character")]

        public void MakeOutWordTests(string word1, string word2, string expected)
        {
            // Arrange
            StringExercises ex = new StringExercises();

            // Act
            string actual = ex.MakeOutWord(word1, word2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        
    }
}