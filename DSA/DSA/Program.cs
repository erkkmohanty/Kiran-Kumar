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
            UtilityManager.CreateLinkedList();
            //UtilityManager.Count();

            //WordCounter.CountWord("Kiran Kumar Kira Mohanty Kiran K iran KKiran","Kiran");
            //UtilityManager.CreateBinaryTree();

            //MaximumSubArray.FindMaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            //MaximumSubArray.FindMaxSubArrayWithIndices(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            //Test();
        }

        static void Test()
        {
            int a = 17;
            a--;
            a =a- ++a+a--+a++;
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
