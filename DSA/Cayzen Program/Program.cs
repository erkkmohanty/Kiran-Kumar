using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cayzen_Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> longestWordList=WordComposition.FindTheLongest(FileManager.TakeInputFromUser());
            PrintLongestWord(longestWordList);
            CheckForContinuation();
        }

        private static void PrintLongestWord(List<string> longestWordList)
        {
            foreach (string item in longestWordList)
            {
                Console.WriteLine("Compound Word: " + item);
            }
        }

        private static void CheckForContinuation()
        {
            Console.WriteLine("Do you want to continue?y/n");
            string input = Console.ReadLine();
            if (!String.Equals(input, "Y", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }

            WordComposition.FindTheLongest(FileManager.TakeInputFromUser());
        }
    }
}
