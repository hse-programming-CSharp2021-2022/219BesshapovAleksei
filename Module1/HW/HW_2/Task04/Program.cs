using System;

namespace Task04
{
    class Program
    {
        static void Nums(int x)
        {
            if (x >= 1000 && x <= 9999)
            {
                Console.WriteLine(x % 10);
                x /= 10;
                Console.WriteLine(x % 10);
                x /= 10;
                Console.WriteLine(x % 10);
                x /= 10;
                Console.WriteLine(x % 10);
            } else
            {
                Console.WriteLine("Incorrect length");
            }
        }
        static void Main(string[] args)
        {
            int a;
            bool flag = int.TryParse(Console.ReadLine(), out a);
            if (flag)
            {
                Nums(a);
            } else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
