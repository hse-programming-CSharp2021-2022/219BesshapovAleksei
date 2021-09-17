using System;

namespace Task4_1_8
{
    class Program
    {
        static int ColDel(int n)
        {
            int res = 2;
            for (int i = 2; i < (int)Math.Sqrt(i)+1; i++)
            {
                if (n % i == 0)
                {
                    if (i * i == n)
                    {
                        res += 1;
                    } else
                    {
                        res += 2;
                    }
                }
            }
            return res;
        }
        static void Kdelit(int k)
        {
            for (int i = 100; i < 1000; i++)
            {
                if (k == ColDel(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
