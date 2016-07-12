using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cayzen_Program
{
    public static class  WordComposition
    {
        private static Dictionary<string, int> _fileContentDictionary = new Dictionary<string, int>();
        public static List<string> FindTheLongest(string[] fileContent)
        {
            Sort(fileContent);
            List<string> longestWordList = new List<string>();
            _fileContentDictionary = fileContent.Select((value, index) => new { value, index })
                      .ToDictionary(pair => pair.value, pair => pair.index);
            for (int wordIndex = fileContent.Length - 1; wordIndex >= 0; wordIndex--)
            {
                if (!IsLongest(fileContent[wordIndex], wordIndex)) continue;
                longestWordList.Add(fileContent[wordIndex]);
                if (longestWordList.Count == 2)
                    break;
            }
            return longestWordList;
        }

       

       

        private static void Sort(string[] fileContent)
        {
            if (fileContent.Length <= 100)
                Utility.BubbleSort(fileContent);
            else
                Utility.QuickSort(fileContent, 0, fileContent.Length - 1);
        }


        public static bool IsLongest(string longestWord, int wordIndexInFile)
        {
            int length = longestWord.Length - 1;
            string stringToBeMatched = string.Empty;
            string remainingString = string.Empty;
            while (true)
            {
                if (_fileContentDictionary.ContainsKey(stringToBeMatched) && _fileContentDictionary[stringToBeMatched] != wordIndexInFile)
                {
                    if (stringToBeMatched.Equals(longestWord))
                    {
                        longestWord = string.Empty;
                        break;
                    }
                    stringToBeMatched = longestWord = remainingString;
                    length = longestWord.Length - 1;
                }
                else
                {
                    stringToBeMatched = longestWord.Substring(0, length);
                    remainingString = longestWord.Substring(length);
                    length--;
                }
                if (length < 0 || string.IsNullOrWhiteSpace(longestWord))
                    break;

            }
            return string.IsNullOrWhiteSpace(longestWord);
        }
    }
}
