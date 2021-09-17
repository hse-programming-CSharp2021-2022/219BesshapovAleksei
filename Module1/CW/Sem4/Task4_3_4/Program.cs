using System;

namespace Task4_3_4
{
    class Program
    {
        static decimal A(decimal m, decimal n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            else if (m > 0 && n == 0)
            {
                return A(m - 1, 1);
            }
            else if (m > 0 && n > 0)
            {
                return A(m - 1, A(m, n - 1));
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(A(10, 10));
        }
    }
}
