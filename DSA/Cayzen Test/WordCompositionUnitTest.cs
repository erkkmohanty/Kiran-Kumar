using System;
using System.Diagnostics;
using System.IO;
using Cayzen_Program;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace Cayzen_Test
{
    [TestClass]
    public class WordCompositionUnitTest
    {
        private string fileName =
            @"C:\Users\kiran\Downloads\Problem Coding Test - Word Composition\Problem Coding Test - Word Composition\words.txt";
        string[]  wordFileData1=new string[]{"cat","cats","catsdogcats","catxdogcatsrat","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"};
        [TestMethod]
        public void ReadFile()
        {
            string[] fileContent=FileManager.ReadFile(fileName);
            bool isEqual=fileContent.SequenceEqual(wordFileData1);
            Assert.AreEqual(true, isEqual);
        }
        [TestMethod]
        [ExpectedExceptionAttribute(typeof(FileNotFoundException))]
        public void ReadFileNegativeScenarioFileNotFound()
        {
            FileManager.ReadFile(string.Empty);
        }
        [TestMethod]
        public void ReadFileNegativeScenarioWrongDataReadFromFile()
        {
            string[] fileContent = FileManager.ReadFile(fileName);
            bool isEqual = Enumerable.SequenceEqual(fileContent, new string[] {});
            Assert.AreEqual(false, isEqual);
        }

        [TestMethod]
        public void FindTheLongestWordPositiveScenario()
        {
            List<string> longestWordList = WordComposition.FindTheLongest(wordFileData1);
            List<string> desiredOutput = new List<string> {"ratcatdogcat", "catsdogcats"};
            bool isEqual = Enumerable.SequenceEqual(longestWordList, desiredOutput);
            Assert.AreEqual(true, isEqual);
        }
        [TestMethod]
        public void FindTheLongestWordNegativeScenario()
        {
            List<string> longestWordList = WordComposition.FindTheLongest(wordFileData1);
            List<string> desiredOutput = new List<string> { "ratcatdogca", "catsdogcats" };
            bool isEqual = Enumerable.SequenceEqual(longestWordList, desiredOutput);
            Assert.AreEqual(false, isEqual);
        }
    }
}
