using System;
using System.Collections.Generic;

namespace TaskBinaryTree
{
    class Node<T>
        where T : IComparable
    {
        public Node<T> Left;
        public Node<T> Right;
        public T Value;
        public int ValueCount;

        public Node(T value, Node<T> left=null, Node<T> right=null)
        {
            Value = value;
            ValueCount = 1;
            Left = left;
            Right = right;
        }

        public void InsertValue(T newValue)
        {
            int comparison = newValue.CompareTo(this.Value);
            if (comparison > 0)
            {
                if (Right == null)
                {
                    Right = new Node<T>(newValue);
                    return;
                }
                Right.InsertValue(newValue);
            }
            else if (comparison < 0)
            {
                if (Left == null)
                {
                    Left = new Node<T>(newValue);
                    return;
                }
                Left.InsertValue(newValue);
            }
            ValueCount++;
        }

        public override string ToString()
        {
            return $"{Value}-->{ValueCount}";
        }
    }

    class SortedBinaryTree<T>
        where T : IComparable
    {
        public Node<T> root;
        public bool IsEmpty
        { 
            get
            {
                return root == null;
            }
        }
        public void Insert(T value)
        {
            if (this.IsEmpty)
            {
                root = new Node<T>(value);
                return;
            }
            root.InsertValue(value);
        }
        public void Preorder(Node<T> root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root + " ");
            Preorder(root.Left);
            Preorder(root.Right);
        }

        public void Inorder(Node<T> root)
        {
            if (root == null)
            {
                return;
            }
            Inorder(root.Left);
            Console.WriteLine(root + " ");
            Inorder(root.Right);
        }

        public void Postorder(Node<T> root)
        {
            if (root == null)
            {
                return;
            }
            Postorder(root.Left);
            Postorder(root.Right);
            Console.WriteLine(root + " ");
        }

        public void Cascade(Node<T> root)
        {
            Queue<Node<T>> nodes = new Queue<Node<T>>();
            nodes.Enqueue(root);
            while (nodes.Count > 0)
            {
                Node<T> node = nodes.Dequeue();
                if (node.Left != null)
                {
                    nodes.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    nodes.Enqueue(node.Right);
                }
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
        public void Print()
        {
            if (this.IsEmpty)
            {
                Console.WriteLine("Tree is dead");
                return;
            }
            Inorder(root);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SortedBinaryTree<int> binaryTree = new();
            binaryTree.Insert(100);
            binaryTree.Insert(200);
            binaryTree.Cascade(binaryTree.root);
            binaryTree.Inorder(binaryTree.root);
            binaryTree.Preorder(binaryTree.root);
            binaryTree.Postorder(binaryTree.root);
        }
    }
}
