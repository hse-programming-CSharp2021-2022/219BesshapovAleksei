using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            double.TryParse(Console.ReadLine(), out a);
            double.TryParse(Console.ReadLine(), out b);
            Console.WriteLine("Длина гипотенузы: " + Math.Sqrt(a * a + b * b));
        }
    }
}
