using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Tree
{
    public class BNode<T> where T: struct
    {
        public BNode<T> Left { get; set; }
        public BNode<T> Right { get; set; }

        public T Data { get; set; }
        public BNode(T data,BNode<T> left,BNode<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
        public BNode(T data)
        {
            Data = data;
        }
    }
}
