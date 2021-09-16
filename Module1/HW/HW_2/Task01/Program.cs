using System;

namespace Task01
{
    class Program
    {
        static void F(decimal x)
        {
            if (x == 0)
            {
                Console.WriteLine(-4);
            }
            else
            {
                Console.WriteLine(x * x * x * x * (12 + 9 / x - 3 / x / x + 2 / x / x / x) - 4);
            }
        }
        static void Main(string[] args)
        {
            decimal a;
            bool flag = decimal.TryParse(Console.ReadLine(), out a);
            if ( flag ) { F(a); } 
        }
    }
}
