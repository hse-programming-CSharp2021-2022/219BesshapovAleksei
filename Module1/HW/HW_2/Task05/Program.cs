using System;

namespace Task05
{
    class Program
    {
        static string IsTriangle(decimal a, decimal b, decimal c)
        {
            decimal a1;
            decimal b1;
            decimal c1;
            decimal.TryParse(a.ToString("F3"), out a1);
            decimal.TryParse(b.ToString("F3"), out b1);
            decimal.TryParse(c.ToString("F3"), out c1);
            return (a1 + b1 > c1 && b1 + c1 > a1 && a1 + c1 > b1) ? "Can be a triangle" : "Can not be a triangle";
        }
        static void Main(string[] args)
        {
            decimal a;
            decimal b;
            decimal c;
            bool flag1 = decimal.TryParse(Console.ReadLine(), out a);
            bool flag2 = decimal.TryParse(Console.ReadLine(), out b);
            bool flag3 = decimal.TryParse(Console.ReadLine(), out c);
            Console.WriteLine((flag1 && flag2 && flag3) ? IsTriangle(a, b, c) : "Incorrect input");
        }
    }
}
