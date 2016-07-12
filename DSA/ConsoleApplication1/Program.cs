using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cayzen_Program;

namespace ConsoleApplication1
{
    class Program
    {
        private static Trie trie = new Trie();
        static void Main(string[] args)
        {
            string[] fileContent = TakeInputFromUser();
            if (fileContent.Length <= 100)
                BubbleSort(fileContent);
            else
            {
                QuickSort(fileContent, 0, fileContent.Length - 1);
            }
        }
        static string[] TakeInputFromUser()
        {
            string[] fileContent = null;
            try
            {
                Console.WriteLine("Please enter a valid file name with path");
                string fileName = Console.ReadLine();
                if (!FileManager.IsExists(fileName))
                    throw new FileNotFoundException("The file is not there in the given location" + fileName);
                fileContent = FileManager.ReadFile(fileName);
                trie.InsertRange(fileContent.ToList());
                FindTheLongest(fileContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TakeInputFromUser();
            }
            return fileContent;
        }
        private static void FindTheLongest(string[] fileContent)
        {
            List<string> longestWordList = new List<string>();

            for (int index = fileContent.Length - 1; index >= 0; index--)
            {
                if (IsRequiredWord(fileContent[index],true))
                {
                    longestWordList.Add(fileContent[index]);
                }
            }
            
            foreach (string item in longestWordList.OrderByDescending(w => w.Length))
            {
                Console.WriteLine(item);

            }
            Console.ReadKey();
        }
        public static bool IsRequiredWord(String word, bool fullword)
        {
            // Remove the word so that the word is not matched to itself to find the longest word
            if (fullword)
            {
                trie.Delete(word);
            }
            // Loop over the length of the word
            for (int i = 0; i < word.Length; i++)
            {
                if (trie.Search(word.Substring(0, i + 1)))
                {
                    if (i + 1 == word.Length || IsRequiredWord(JavaStyleSubstring(word,i + 1, word.Length), false))
                    {
                        return true;
                    }
                }
            }
            if (fullword)
            {
                trie.Insert(word);
            }
            return false;
        }
        /// <summary>
        /// Quick Sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lowerIndex"></param>
        /// <param name="higherIndex"></param>
        private static void QuickSort(string[] array, int lowerIndex, int higherIndex)
        {
            string pivotElement = array[lowerIndex + (higherIndex - lowerIndex) / 2];

            int tempLowerIndex = lowerIndex;
            int tempHigherIndex = higherIndex;
            while (tempLowerIndex <= tempHigherIndex)
            {
                while (array[tempLowerIndex].Length < pivotElement.Length)
                {
                    tempLowerIndex++;
                }
                while (array[tempHigherIndex].Length > pivotElement.Length)
                {
                    tempHigherIndex--;
                }
                if (tempLowerIndex <= tempHigherIndex)
                {
                    SwapText(tempLowerIndex, tempHigherIndex, array);
                    tempLowerIndex++;
                    tempHigherIndex--;
                }
            }
            if (lowerIndex < tempHigherIndex)
                QuickSort(array, lowerIndex, tempHigherIndex);
            if (tempLowerIndex < higherIndex)
                QuickSort(array, tempLowerIndex, higherIndex);

        }
        /// <summary>
        /// Bubble Sort
        /// </summary>
        /// <param name="array"></param>
        public static void BubbleSort(string[] array)
        {

            for (int iIndex = 0; iIndex < array.Length; iIndex++)
            {
                for (int jIndex = 1; jIndex < (array.Length - iIndex); jIndex++)
                {
                    if (array[jIndex - 1].Length > array[jIndex].Length)
                    {
                        SwapText(jIndex - 1, jIndex, array);
                    }
                }
            }
        }
        private static void SwapText(int lowerIndex, int higherIndex, string[] array)
        {
            string temp = array[lowerIndex];
            array[lowerIndex] = array[higherIndex];
            array[higherIndex] = temp;
        }

        static string JavaStyleSubstring(string s, int beginIndex,
   int endIndex)
        {
            // simulates Java substring function
            int len = endIndex - beginIndex;
            return s.Substring(beginIndex, len);
        }
    }

    
}
