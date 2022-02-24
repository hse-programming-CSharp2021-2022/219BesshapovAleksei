using System;
using System.Collections;

namespace Task03
{
    class Fibbonacci : IEnumerable
    {
        int current = 0, next = 1;
        public IEnumerable Enumerator(int n)
        {
            for (int i = 0; i < n; ++i)
            {
                (current, next) = (next, current + next);
                yield return current;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 10; ++i)
            {
                yield return next;
                (current, next) = (next, current + next);
            }
        }
    }
    class TriangleNums
    {
        int amount = 0;
        public IEnumerable Enumerator(int n)
        {
            for (int i = 0; i < n; ++i)
            {
                yield return 0.5 * amount * (amount + 1);
                amount++;
            }
        }
    }
    class SummedRows
    {
        Fibbonacci fibo = new Fibbonacci();
        TriangleNums trian = new TriangleNums();
        public IEnumerable Enumerator(int n)
        {
            for (int i = 0; i < n; i++)
            {
                foreach (var item in fibo.Enumerator(1))
                {
                    yield return item;
                }
                foreach (var item in trian.Enumerator(1))
                {
                    yield return item; 
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fibbonacci fibo = new Fibbonacci();
            TriangleNums trian = new TriangleNums();
            SummedRows sr = new SummedRows();
            foreach (var item in fibo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---");
            /*
            foreach (var item in fibo.Enumerator(10))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---");
            foreach (var item in trian.Enumerator(10))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---");
            */
            foreach (var item in sr.Enumerator(10))
            {
                Console.WriteLine(item);
            }
        }
    }
}
