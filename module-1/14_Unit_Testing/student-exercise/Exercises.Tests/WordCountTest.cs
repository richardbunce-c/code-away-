using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class WordCountTest
    {
        [TestMethod]
        public void WordCountSheepTest()
        {
            WordCount dictionaryWordCount = new WordCount();

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"ba", 2 },
                {"black", 1 },
                {"sheep", 1 }

            };
            Dictionary<string, int> actual = dictionaryWordCount.GetCount(new string[] { "ba", "ba", "black", "sheep" });
            CollectionAssert.AreEqual(expected, actual);

        }
    
        [TestMethod]
        public void WordCountLetterTest()
        {
            WordCount dictionaryWordCount = new WordCount();

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"a", 2 },
                {"b", 2 },
                {"c", 1 }

            };
            Dictionary<string, int> actual = dictionaryWordCount.GetCount(new string[] { "a", "b", "a", "c", "b" });
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void WordCountNothingTest()
        {
            WordCount dictionaryWordCount = new WordCount();

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
               

            };
            Dictionary<string, int> actual = dictionaryWordCount.GetCount(new string[] { } );
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void WordCountLetterTest2()
        {
            WordCount dictionaryWordCount = new WordCount();

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"c", 1 },
                {"b", 1 },
                {"a", 1 }

            };
            Dictionary<string, int> actual = dictionaryWordCount.GetCount(new string[] { "c", "b", "a" });
            CollectionAssert.AreEqual(expected, actual);

        }



    } }
/*
     * Given an array of strings, return a Dictionary<string, int> with a key for each different string, with the value the 
     * number of times that string appears in the array.
     * 
     * ** A CLASSIC **
     * 
     * GetCount(["ba", "ba", "black", "sheep"]) → {"ba" : 2, "black": 1, "sheep": 1 }
     * GetCount(["a", "b", "a", "c", "b"]) → {"a": 2, "b": 2, "c": 1}
     * GetCount([]) → {}
     * GetCount(["c", "b", "a"]) → {"c": 1, "b": 1, "a": 1}
     * 
     */