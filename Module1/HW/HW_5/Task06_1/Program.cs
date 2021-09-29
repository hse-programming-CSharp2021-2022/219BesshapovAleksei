using System;

namespace Task06_1
{
    class Program
    {
        static void Compress(int[] a)
        {
            bool[] needed = new bool[a.Length];
            for (int i = 0; i < a.Length - 1; i++)
            {
                if ((a[i] + a[i + 1]) % 3 == 0)
                {
                    a[i] *= a[i + 1];
                    needed[i] = true;
                    needed[i + 1] = false;
                    i++;
                }
                else
                {
                    needed[i] = true;
                }
            }
            for (int i = 0; i < needed.Length; i++)
            {
                if (needed[i])
                {
                    Console.WriteLine(a[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6 };
            Compress(a);
        }
    }
}
