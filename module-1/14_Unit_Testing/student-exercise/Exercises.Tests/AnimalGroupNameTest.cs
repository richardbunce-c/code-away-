
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class AnimalGroupNameTest
    {
        [TestMethod]
        public void AnimalGroupName()
        {
            AnimalGroupName myAnimalGroupName = new AnimalGroupName();

            Assert.AreEqual("Tower", myAnimalGroupName.GetHerd("giraffe"));
            Assert.AreEqual("Herd", myAnimalGroupName.GetHerd("elephant"));
            Assert.AreEqual("Pride", myAnimalGroupName.GetHerd("lion"));
            Assert.AreEqual("Murder", myAnimalGroupName.GetHerd("crow"));
            Assert.AreEqual("Kit", myAnimalGroupName.GetHerd("pigeon"));
            Assert.AreEqual("Pat", myAnimalGroupName.GetHerd("flamingo"));
            Assert.AreEqual("Herd", myAnimalGroupName.GetHerd("deer"));
            Assert.AreEqual("Pack", myAnimalGroupName.GetHerd("dog"));
            Assert.AreEqual("Float", myAnimalGroupName.GetHerd("crocodile"));
            Assert.AreEqual("Crash", myAnimalGroupName.GetHerd("rhino"));
        }
    }
}
/*
  * Given the name of an animal, return the name of a group of that animal
  * (e.g. "Elephant" -> "Herd", "Rhino" - "Crash").  
  * 
  * The animal name should be case insensitive so "elephant", "Elephant", and 
  * "ELEPHANT" should all return "herd". 
  * 
  * If the name of the animal is not found, null, or empty, return "unknown". 
  * 
  * Rhino -> Crash
  * Giraffe -> Tower
  * Elephant -> Herd
  * Lion -> Pride
  * Crow -> Murder
  * Pigeon -> Kit
  * Flamingo -> Pat
  * Deer -> Herd
  * Dog -> Pack
  * Crocodile -> Float
  *
  * GetHerd("giraffe") → "Tower"
  * GetHerd("") -> "unknown"         
  * GetHerd("walrus") -> "unknown"
  * GetHerd("Rhino") -> "Crash"
  * GetHerd("rhino") -> "Crash"
  * GetHerd("elephants") -> "unknown"
  * 
  */