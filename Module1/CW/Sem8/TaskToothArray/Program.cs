using System;

namespace TaskToothArray
{
    class Program
    {
        static int PoUbiv(int a, int b)
        {
            if (a > b)
            {
                return -1;
            }
            else if (a < b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static int SortByLength(Array a, Array b)
        {
            if (a.Length < b.Length)
            {
                return 1;
            }
            else if (a.Length > b.Length)
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
            int[][] mas = new int[n][];
            for (int i = 0; i < n; i++)
            {
                mas[i] = new int[rand.Next(5, 16)];
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    mas[i][j] = rand.Next(-10, 11);
                }
            }
            foreach (var item in mas)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                }
                Console.WriteLine();
            }
            foreach (var item in mas)
            {
                Array.Sort(item, PoUbiv);
            }
            foreach (var item in mas)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                }
                Console.WriteLine();
            }
            Array.Sort(mas, SortByLength);
            foreach (var item in mas)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                }
                Console.WriteLine();
            }
        }
    }
}
