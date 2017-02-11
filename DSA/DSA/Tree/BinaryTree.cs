using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Tree
{
    public class BinaryTree<T> where T : struct, IComparable
    {
        public BNode<T> Head { get; set; }
        public static bool IsGreaterThan(T value, T other)
        {
            return value.CompareTo(other) > 0;
        }
        public static bool IsGreaterThanEqual(T value, T other)
        {
            return value.CompareTo(other) >= 0;
        }

        public static bool IsLessThan(T value, T other)
        {
            return value.CompareTo(other) < 0;
        }
        public static bool IsLessThanEqual(T value, T other)
        {
            return value.CompareTo(other) <= 0;
        }

        public BinaryTree(T data)
        {
            Head = new BNode<T>(data);
        }
        /*We can traverse the BinaryTree in three ways
         * 1.PreOrder-VLR(Visit,Left,Right)
         * 2.InOrder-LVR(Left,Visit,Right)
         * 3.PostOrder-LRV(Left,Right,Visit)
         */
        public void PreOrderTraverse(BNode<T> bNode)
        {
            if (bNode == null)
                return;
            Console.WriteLine(bNode.Data);
            PreOrderTraverse(bNode.Left);
            PreOrderTraverse(bNode.Right);
        }
        public void InOrderTraverse(BNode<T> bNode)
        {
            if (bNode == null)
                return;
            InOrderTraverse(bNode.Left);
            Console.WriteLine(bNode.Data);
            InOrderTraverse(bNode.Right);
        }
        public void PostOrderTraverse(BNode<T> bNode)
        {
            if (bNode == null)
                return;
            PostOrderTraverse(bNode.Left);
            PostOrderTraverse(bNode.Right);
            Console.WriteLine(bNode.Data);
        }

        public BNode<T> InsertData(T data)
        {
            BNode<T> node = new BNode<T>(data);
            if (Head == null)
                return Head = node;
            BNode<T> parentNode = null, currentNode = Head;
            while (currentNode != null)
            {
                parentNode = currentNode;
                if (IsLessThanEqual(currentNode.Data,data))
                    currentNode = currentNode.Right;
                else
                    currentNode = currentNode.Left;
            }
            if ((IsLessThanEqual(parentNode.Data,data)))
                parentNode.Right = node;
            else
                parentNode.Left = node;
            return parentNode;

        }
    }
}
