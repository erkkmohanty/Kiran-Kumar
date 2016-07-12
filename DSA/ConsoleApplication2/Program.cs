using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
    class Program
    {
        static void Main()
        {
            var items = new List<string> { "ratcatdogcat", "cat", "jazz", "jaws" };
            var stream = new StreamReader(@"C:\Users\kiran\Downloads\Problem Coding Test - Word Composition\Problem Coding Test - Word Composition\words.txt");

            while (!stream.EndOfStream)
                items.Add(stream.ReadLine());

            var stopwatch = new Stopwatch();

            var trie = new Trie();
            var hashset = new HashSet<string>();
            const string s = "gau";

            stopwatch.Start();
            trie.InsertRange(items);
            stopwatch.Stop();
            Console.WriteLine("Trie insertion in {0} ticks", stopwatch.ElapsedTicks);
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < items.Count; i++)
                hashset.Add(items[i]);
            stopwatch.Stop();
            Console.WriteLine("HashSet in {0} ticks", stopwatch.ElapsedTicks);
            stopwatch.Reset();

            Console.WriteLine("-------------------------------");

            stopwatch.Start();
            var prefix = trie.Prefix(s);
            var foundT = prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
            stopwatch.Stop();
            Console.WriteLine("Trie search in {0} ticks found:{1}", stopwatch.ElapsedTicks, foundT);
            stopwatch.Reset();

            stopwatch.Start();

            var foundL = hashset.FirstOrDefault(str => str.StartsWith(s));

            stopwatch.Stop();
            Console.WriteLine("HashSet search in {0} ticks found:{1}", stopwatch.ElapsedTicks, foundL);

            trie.Delete("jazz");
            Console.Read();
        }
    }

    public class Node
    {
        public char Value { get; set; }
        public List<Node> Children { get; set; }
        public Node Parent { get; set; }
        public int Depth { get; set; }

        public Node(char value, int depth, Node parent)
        {
            Value = value;
            Children = new List<Node>();
            Depth = depth;
            Parent = parent;
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        public Node FindChildNode(char c)
        {
            foreach (var child in Children)
                if (child.Value == c)
                    return child;

            return null;
        }

        public void DeleteChildNode(char c)
        {
            for (var i = 0; i < Children.Count; i++)
                if (Children[i].Value == c)
                    Children.RemoveAt(i);
        }
    }

    public class Trie
    {
        private readonly Node _root;

        public Trie()
        {
            _root = new Node('^', 0, null);
        }

        public Node Prefix(string s)
        {
            var currentNode = _root;
            var result = currentNode;

            foreach (var c in s)
            {
                currentNode = currentNode.FindChildNode(c);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }

        public bool Search(string s)
        {
            var prefix = Prefix(s);
            return prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
        }

        public void InsertRange(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
                Insert(items[i]);
        }

        public void Insert(string s)
        {
            var commonPrefix = Prefix(s);
            var current = commonPrefix;

            for (var i = current.Depth; i < s.Length; i++)
            {
                var newNode = new Node(s[i], current.Depth + 1, current);
                current.Children.Add(newNode);
                current = newNode;
            }

            current.Children.Add(new Node('$', current.Depth + 1, current));
        }

        public void Delete(string s)
        {
            if (Search(s))
            {
                var node = Prefix(s).FindChildNode('$');

                while (node.IsLeaf())
                {
                    var parent = node.Parent;
                    parent.DeleteChildNode(node.Value);
                    node = parent;
                }
            }
        }

    }


}
