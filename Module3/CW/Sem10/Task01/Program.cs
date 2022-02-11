using System;
using System.Collections.Generic;

namespace Task01
{
    class Queue<T> where T : struct
    {
        public List<T> queue = new List<T>();
        public int Size
        {
            get
            {
                return this.queue.Count;
            }
        }
        public bool IsEmpty()
        {
            return this.Size == 0;
        }
        public T Dequeue()
        {
            if (this.IsEmpty())
            {
                throw new IndexOutOfRangeException("No elements");
            }
            T firstOut = this.queue[0];
            this.queue.RemoveAt(0);
            return firstOut;
        }
        public void Enqueue(T newElement)
        {
            this.queue.Add(newElement);
        }
        public T Top()
        {
            if (this.IsEmpty())
            {
                throw new IndexOutOfRangeException("No elements");
            }
            return this.queue[0];
        }
    }
    struct Person
    {
        public string Name
        {
            get;
            set;
        }
        public string Surname
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Surname}, {this.Age}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Person> electronicQueue = new Queue<Person>();
            electronicQueue.Enqueue(new Person("Петр", "Первый", 55));
            Console.WriteLine(electronicQueue.Dequeue());
        }
    }
}
