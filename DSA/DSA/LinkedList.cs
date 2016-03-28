using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    /// <summary>
    /// LinkedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>
    {
        public Node<T> head { get; set; }
        /// <summary>
        /// Length by normal iteration
        /// </summary>
        public int Length
        {
            get
            {
                int counter = 0;
                if (head == null)
                    return counter;
                Node<T> node = head;
                while (node != null)
                {
                    counter++;
                    node = node.next;
                }
                return counter;
            }
        }

        private int Length_Recusrive(Node<T> node)
        {
            if (node == null)
                return 0;
            return 1 + Length_Recusrive(node.next);
        }
        /// <summary>
        /// Get Length Using Recursive Method
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return Length_Recusrive(head);
        }
        /// <summary>
        /// Push element at the starting of LinkedList
        /// </summary>
        /// <param name="data"></param>
        public void PushAtFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.next = head;
            head = node;
            //Here Time complexity is O(1)
        }
        /// <summary>
        /// Push element after a specific node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        public void PushAfterSpecificNode(Node<T> node, T data)
        {
            if (node == null)
            {
                Console.WriteLine("Node can't be null");
                return;
            }
            Node<T> newNode = new Node<T>(data);
            newNode.next = node.next;
            node.next = newNode;
            //Here Time complexity is O(1)
        }
        /// <summary>
        /// Push Element at Last
        /// </summary>
        /// <param name="data"></param>
        public void PushAtLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
                return;
            }
            Node<T> lastNode = head;
            while (lastNode.next != null)
                lastNode = lastNode.next;
            lastNode.next = newNode;
            //Here the time complexity is O(n) because 
            //it will traverse through each element till it finds the last element
        }
        /// <summary>
        /// Delete the node from the linkedlist when find the first occurence of the key
        /// </summary>
        /// <param name="key"></param>
        public void DeleteNode(T key)
        {
            Node<T> currentNode = head;
            if (currentNode != null && currentNode.data.Equals(key))
            {
                head = currentNode.next;
                return;
            }
            while (currentNode != null && currentNode.next != null)
            {
                if (currentNode.next.data.Equals(key))
                {
                    currentNode.next = currentNode.next.next;
                    break;
                }
                currentNode = currentNode.next;
            }
        }
        /// <summary>
        /// Delete data from Linkedlist by agiven index
        /// </summary>
        /// <param name="index"></param>
        public void DeleteByIndex(int index)
        {
            int counter = 1;
            Node<T> node = head;
            Node<T> previousNode = null, nextNode = null;
            if (index == 0 && head != null)
            {
                head = head.next;
                return;
            }
            previousNode = head;
            while (previousNode.next != null)
            {
                if (counter == index)
                {
                    nextNode = previousNode.next.next;
                    previousNode.next = nextNode;
                    break;
                }
                previousNode = previousNode.next;
                counter++;
            }
        }
        /// <summary>
        /// Search by iteration
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>

        public bool SearchByIteration(T key)
        {
            bool isPresent = false;
            Node<T> node = head;
            while (node != null)
            {
                if (node.data.Equals(key))
                    isPresent = true;
                node = node.next;
            }
            return isPresent;
        }

        private bool SearchByRecursion(Node<T> node, T data)
        {
            if (node == null)
                return false;
            if (node.data.Equals(data))
                return true;
            return SearchByRecursion(node.next, data);
        }
        /// <summary>
        /// Search by recursion
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SearchByRecursion(T data)
        {
            return SearchByRecursion(head, data);
        }

        public string SwapNodes(T data1, T data2)
        {
            if (!SearchByIteration(data1) || !SearchByIteration(data2))
                return "Data not present in LinkedList";
            var pn1 = GetPrevAndNextNodes(data1);
            var pn2 = GetPrevAndNextNodes(data2);
            Node<T> prevNode1 = pn1.Previous, prevNode2 = pn2.Previous;
            Node<T> nextNode1 = pn1.Next, nextNode2 = pn2.Next;
            Node<T> tempPrev = null, tempNext = null;
            if (prevNode1 == null || nextNode2 == null)
                return "Failure";
            return "Failure";

        }
        /// <summary>
        /// Get Previous and next nodes based on specific data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public dynamic GetPrevAndNextNodes(T data)
        {
            Node<T> prevNode=null;
            Node<T> nextNode = null;
            if (head == null)
                return new { Previous = prevNode, Next = nextNode };
            if(head.data.Equals(data))
            {
                nextNode = head.next;
                return new { Previous = prevNode, Next = nextNode };
            }
            prevNode = head;
            Node<T> currentNode = head.next;
            while (currentNode != null)
            {
                if(currentNode.data.Equals(data))
                {
                    nextNode = currentNode.next;
                    break;
                }
                prevNode = currentNode;
                currentNode = currentNode.next;
            }
            return new { Previous = prevNode, Next = nextNode };
        }
    }
    /// <summary>
    /// Node class represents node of a List
    /// </summary>
    /// <typeparam name="T">Where T is any type</typeparam>
    public class Node<T>
    {
        public Node<T> next { get; set; }
        /// <summary>
        /// data is of Type T
        /// </summary>
        public T data { get; set; }
        public Node(T data)
        {
            this.data = data;
        }

    }

}
