using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class BinarySearchTree
    {
         BNode Root;

        public BinarySearchTree(int item)
        {
            Root = new BNode(item);
        }
        public BinarySearchTree()
        {
        }

        public void Insert(int key)
        {
            Root = InsertRecord(Root, key);
        }

        private BNode InsertRecord(BNode bRoot, int item)
        {
            if (bRoot == null)
                bRoot = new BNode(item);
            else if (item >= bRoot.Key)
            {
                bRoot.rightNode = InsertRecord(bRoot.rightNode, item);
            }
            else
            {
                bRoot.leftNode = InsertRecord(bRoot.leftNode, item);
            }
            return bRoot;
        }

        public void Print()
        {
            PrintInOrder(Root);
        }

        private void PrintInOrder(BNode bRoot)
        {
            if (bRoot != null)
            {
                PrintInOrder(bRoot.leftNode);
                Console.WriteLine(bRoot.Key);
                PrintInOrder(bRoot.rightNode);
            }
        }

        public void Search(int item)
        {
            
        }

        private int SearchItem(BNode bRoot, int item)
        {
                return 0;
        }

    }

    class BNode
    {
        public BNode leftNode, rightNode;
        public int Key;

        public BNode(int item)
        {
            Key = item;
            leftNode = rightNode = null;
        }
    }

}
