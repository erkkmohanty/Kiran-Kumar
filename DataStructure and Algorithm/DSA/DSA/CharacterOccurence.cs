using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class CharacterOccurence
    {
        static Dictionary<char, int> charDictionary = new Dictionary<char, int>();

        public static Dictionary<char, int> countOccurence(string data)
        {
            char[] array = data.ToCharArray();
            foreach(char ch in array)
            {
                if(charDictionary.ContainsKey(ch))
                {
                    charDictionary[ch] = charDictionary[ch] + 1;
                }
                else
                {
                    charDictionary.Add(ch, 1);
                }
            }
            return charDictionary;
        }
    }
}
