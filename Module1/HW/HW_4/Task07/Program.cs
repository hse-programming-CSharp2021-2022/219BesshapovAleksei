using System;

namespace Task07
{
    class Program
    {
        static void NOD(int a, int b, out int nod)
        {
            nod = 0;
            if (a == 0)
            {
                nod = b;
            }
            else
            {
                while (b != 0)
                {
                    if (a > b)
                    {
                        a -= b;
                    }
                    else
                    {
                        b -= a;
                    }
                }
                nod = a;
            }
        }
        static void NOK(int a, int b, out int nok)
        {
            nok = 0;
            int proizv = a * b;
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                } else
                {
                    b %= a;
                }
            }
            nok = proizv / (a + b);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
