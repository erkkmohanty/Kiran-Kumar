using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 3, 4, 6, 7, 9, 10, 12, 13, 15 };
            //Utility.CreateLinkedList();
            var data = CharacterOccurence.countOccurence("kkggffssaakkggffssaartyuiop");
            foreach(var s in data)
            {
                Console.WriteLine("Key  :" + s.Key + "  Value  :" + s.Value);
            }
            //Console.WriteLine(BinarySearch.NormalBinarySearch(list,12));
            //Console.WriteLine(BinarySearch.NormalBinarySearch(list,7));
            //Console.WriteLine(BinarySearch.NormalBinarySearch(list,2));
            //Console.WriteLine(BinarySearch.NormalBinarySearch(list,11));

            //Console.WriteLine(BinarySearch.RecursiveBinarySearch(list, 12,0,list.Length-1));
            //Console.WriteLine(BinarySearch.RecursiveBinarySearch(list, 7, 0, list.Length - 1));
            //Console.WriteLine(BinarySearch.RecursiveBinarySearch(list, 2, 0, list.Length - 1));
            //Console.WriteLine(BinarySearch.RecursiveBinarySearch(list, 11, 0, list.Length - 1));
            Console.ReadLine();
        }
    }
}
