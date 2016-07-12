using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class WordCounter
    {
        public static void CountWord(string inputString, string searchTag)
        {
            int count = 0;
            for (int index = 0; index < inputString.Length; index++)
            {
                if (ToLower(inputString[index]) != ToLower(searchTag[0])) continue;
                int counter = 1;
                for (int tagIndex = 1; tagIndex < searchTag.Length; tagIndex++)
                {
                    if (ToLower(inputString[tagIndex + index]) == ToLower(searchTag[tagIndex]))
                        counter++;
                    else
                        break;
                }
                if (counter == searchTag.Length)
                    count++;
            }
            Console.WriteLine("The Output is::" + count);
        }

        private static char ToLower(char character)
        {
            return Char.ToLower(character);
        }
    }
}
