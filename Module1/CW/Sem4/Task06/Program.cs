using System;

namespace Task06
{
    class Program
    {
        static double Total(double k, double r, uint n)
        {
            for (int i = 0; i < n; i++)
            {
                k += k / 100 * (100 + r);
            }
            return k;
        }
        static double TotalR(double k, double r, uint n)
        {
            for (uint i = 0; i < n; i++)
            {
                k += Total(k, r, 1);
            }
            return k;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
