using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Circular
{
    public  class CircularLinkedList<T>
    {

    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            this.Data = data;
        }
        public Node(T data,Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}
