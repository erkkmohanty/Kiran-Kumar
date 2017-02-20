using System;
using System.Text;

class MyClass
{
    static void Main(string[] args)
    {
        /*
         * Read input from stdin and provide input before running
         */
        string input = Console.ReadLine();
        Console.WriteLine(RemoveDuplicateChar(input));
        Console.ReadLine();
    }

    private static string RemoveDuplicateChar(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return string.Empty;
        char[] wordArray = word.ToCharArray();
        StringBuilder newWord = new StringBuilder();
        foreach (char ch in wordArray)
        {
            if (!newWord.ToString().Contains(ch.ToString()))
                newWord.Append(ch);
        }
        return newWord.ToString();
    }
}
