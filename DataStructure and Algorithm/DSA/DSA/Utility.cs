using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class Utility
    {
        public static void CreateLinkedList()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.head = new Node(1);
            Node second = new Node(2);
            Node third = new Node(3);
            Node fourth = new Node(4);
            linkedList.head.next = second;
            second.next = third;
            third.next = fourth;
            PrintLinkedList(linkedList);
            linkedList.PushAtTheFront(100);
            linkedList.PushAtTheFront(200);
            linkedList.PushAtTheFront(300);
            linkedList.PushAtTheFront(400);
            PrintLinkedList(linkedList);
            linkedList.PushAfterAnElement(new Node(400), 900);
            linkedList.PushAfterAnElement(new Node(300), 800);
            linkedList.PushAfterAnElement(new Node(200), 700);
            PrintLinkedList(linkedList);
            linkedList.PushAtTheEnd(1000);
            linkedList.PushAtTheEnd(2000);
            linkedList.PushAtTheEnd(3000);
            linkedList.PushAtTheEnd(4000);
            PrintLinkedList(linkedList);
            linkedList.SwapNodes(1000, 4000);
            PrintLinkedList(linkedList);
            linkedList.SwapNodes(3000, 2000);
            PrintLinkedList(linkedList);
        }
        public static void PrintLinkedList(LinkedList linkedList)
        {

            Node head = linkedList.head;
            while(head!=null)
            {
                Console.WriteLine("Data is::" + head.data);
                head = head.next;
            }
            Console.WriteLine("Length is::" + linkedList.Length);
            //Console.ReadLine();
        }
    }
}
