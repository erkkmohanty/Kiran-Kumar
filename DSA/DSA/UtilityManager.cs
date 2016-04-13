using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    static class UtilityManager
    {
        public static void CreateLinkedList()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            Node<int> node1 = new Node<int>(0);
            Node<int> node2 = new Node<int>(1);
            Node<int> node3 = new Node<int>(2);
            Node<int> node4 = new Node<int>(3);
            Node<int> node5 = new Node<int>(4);
            Node<int> node6 = new Node<int>(5);
            Node<int> node7 = new Node<int>(6);
            Node<int> node8 = new Node<int>(7);
            linkedList.head = node1;
            node1.next = node2;
            linkedList.GetMiddleNode();
            linkedList.GetMiddleNodeEfficientApproach();
            node2.next = node3;
            linkedList.GetMiddleNode();
            linkedList.GetMiddleNodeEfficientApproach();
            node3.next = node4;
            linkedList.GetMiddleNode();
            linkedList.GetMiddleNodeEfficientApproach();
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = node8;
            DisplayLinkedList(linkedList);
            DisplayLinkedList(linkedList);
            bool d = linkedList.SearchByRecursion(1);
             d = linkedList.SearchByRecursion(3);
             d = linkedList.SearchByRecursion(88);
             d = linkedList.SearchByRecursion(7);
             d = linkedList.SearchByIteration(7);
             d = linkedList.SearchByIteration(447);
             d = linkedList.SearchByIteration(5);
             d = linkedList.SearchByIteration(6);
             linkedList.GetPrevAndNextNodes(3);
             linkedList.GetPrevAndNextNodes(0);
             linkedList.GetPrevAndNextNodes(7);
             linkedList.GetPrevAndNextNodes(39999);
             linkedList.Swap(1, 3);
             DisplayLinkedList(linkedList);
             linkedList.Swap(5,7);
             DisplayLinkedList(linkedList);
             Node<int> node=linkedList.GetNthNodebyIndex(10);
             Node<int> midNode = linkedList.GetMiddleNode();
             Debug.Assert(node != null);
            
        }
        public static void DisplayLinkedList<T>(LinkedList<T> linkedList)
        {
            if (linkedList == null || linkedList.head == null)
            {
                Console.WriteLine("Linkedlist does not contain any data");
                return;
            }
            Node<T> node = linkedList.head;
            while (node != null)
            {
                Console.WriteLine("Data is::" + node.data);
                node = node.next;
            }
            Console.WriteLine("The Length of the linkedlist is::" + linkedList.Length);
            Console.WriteLine("The Length of the linkedlist is::" + linkedList.GetLength());
        }
    }
}
