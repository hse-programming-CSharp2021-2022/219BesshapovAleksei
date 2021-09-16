using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < 21; i+=2)
            {
                Console.WriteLine(i * i);
            }
            int a = 2;
            while (a <= 20)
            {
                Console.WriteLine(a * a);
                a += 2;
            }
            a = 2;
            do
            {
                Console.WriteLine(a * a);
                a += 2;
            } while (a < 21);
        }
    }
}
