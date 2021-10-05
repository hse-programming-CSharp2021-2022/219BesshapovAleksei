using System;

namespace Task01
{
    class Program
    {
        static int LettersSum(int x)
        {
            int res = 0;
            while (x != 0)
            {
                res += x % 10;
                x /= 10;
            }
            return res;
        }
        static int SortBySum(int a, int b)
        {
            if (LettersSum(a) < LettersSum(b))
            {
                return 1;
            }
            else if (LettersSum(a) > LettersSum(b))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        static int SortByChet(int a, int b)
        {
            if (a % 2 == 1 && b % 2 == 0)
            {
                return 1;
            }
            else if (a % 2 == 0 && b % 2 == 1)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        static int SortByLen(int a, int b)
        {
            if (a.ToString().Length < b.ToString().Length)
            {
                return 1;
            }
            else if (a.ToString().Length > b.ToString().Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);
            Random rand = new Random();
            int[] mas = new int[n];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(0, 1001);
            }
            Array.ForEach(mas, el => Console.WriteLine(el));
            Console.WriteLine();
            Array.Sort(mas, SortByChet);
            Array.ForEach(mas, el => Console.WriteLine(el));
            Console.WriteLine();
            Array.Sort(mas, SortByLen);
            Array.ForEach(mas, el => Console.WriteLine(el));
            Console.WriteLine();
            Array.Sort(mas, SortBySum);
            Array.ForEach(mas, el => Console.WriteLine(el));
            Console.WriteLine();
        }
    }
}
