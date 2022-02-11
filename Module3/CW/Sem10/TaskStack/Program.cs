using System;
using System.Collections.Generic;

namespace TaskStack
{
    class Stack<T>
    {
        public List<T> stack = new List<T>();
        public int Size
        {
            get
            {
                return stack.Count;
            }
        }
        public void Push(T newObject)
        {
            this.stack.Add(newObject);
        }
        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new IndexOutOfRangeException("No elements");
            }
            T topElement = this.stack[this.Size - 1];
            this.stack.RemoveAt(this.Size - 1);
            return topElement;
        }
        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new IndexOutOfRangeException("No elements");
            }
            T topElement = this.stack[this.Size - 1];
            return topElement;
        }
        public bool IsEmpty()
        {
            return this.Size == 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
