using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class LinkedList
    {
        public Node head;
        public int Length
        {
            get
            {
                int counter = 0;
                Node node = head;
                while (node != null)
                {
                    counter++;
                    node = node.next;
                }
                return counter;
            }
        }
        public void PushAtTheFront(int data)
        {
            Node node = new Node(data);
            node.next = head;
            head = node;
            //Here the time comlexity is O(1) as it does the constant amount of work
        }
        public void PushAfterAnElement(Node previousNode, int data)
        {
            if (previousNode == null)
            {
                Console.WriteLine("Previous node can't be null");
                return;
            }
            Node newNode = new Node(data);
            newNode.next = previousNode.next;
            previousNode.next = newNode;
            //Here the time complexity is O(1) as it is doing the constant amount of work
        }
        public void PushAtTheEnd(int data)
        {
            Node newNode = new Node(data);
            Node start = head;
            if (head == null)
            {
                head = newNode;
                return;
            }
            while (start.next != null)
            {
                start = start.next;
            }
            start.next = newNode;
            //Here the time complexity is O(n).Because we have to traverse till the last element present in the list
        }

        public void SwapNodes(int data1, int data2)
        {
            if (data1 == data2)
                return;
            Node prevNode1 = null, currNode1 = head;
            Node prevNode2 = null, currNode2 = head;
            while (currNode1 != null && currNode1.data != data1)
            {
                prevNode1 = currNode1;
                currNode1 = currNode1.next;
            }

            while (currNode2 != null && currNode2.data != data2)
            {
                prevNode2 = currNode2;
                currNode2 = currNode2.next;
            }
            if (currNode1 == null || currNode2 == null)
            {
                return;
            }
            if (prevNode1 != null)
                prevNode1.next = currNode2;
            else
                head = currNode2;
            if (prevNode2 != null)
                prevNode2.next = currNode1;
            else
                head = currNode1;
            Node temp = currNode1.next;
            currNode1.next = currNode2.next;
            currNode2.next = temp;
        }
    }
    class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
}
