using DSA.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class Program
    {
        static int[] data = { 10, 34, 45, 23, 55, 1, 2, 3, 4, 90 };
        static void Main(string[] args)
        {
            //UtilityManager.CreateLinkedList();
            //UtilityManager.Count();

            //WordCounter.CountWord("Kiran Kumar Kira Mohanty Kiran K iran KKiran","Kiran");
            //UtilityManager.CreateBinaryTree();

            //MaximumSubArray.FindMaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            //MaximumSubArray.FindMaxSubArrayWithIndices(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            //Test();
            TestBinaryTree();
            Console.ReadLine();
        }

        static void Test()
        {
            int a = 17;
            a--;
            a = a - ++a + a-- + a++;
            Console.WriteLine(a);
            Console.ReadLine();
        }

        static void TestBinaryTree()
        {
             BinaryTree<int> bTree= new BinaryTree<int>(67);
            data.ToList().ForEach(el => bTree.InsertData(el));
            Console.WriteLine("Pre Order");
            bTree.PreOrderTraverse(bTree.Head);
            Console.WriteLine("In Order");
            bTree.InOrderTraverse(bTree.Head);
            Console.WriteLine("Post Order");
            bTree.PostOrderTraverse(bTree.Head);

        }
    }
}
