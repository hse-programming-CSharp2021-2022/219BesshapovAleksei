using System;

namespace Task03
{
    class Program
    {
        static string NeKv(decimal b, decimal c)
        {
            string res = (c == 0 ? (b == 0 ? "x - любое число" : "x = 0") : (b == 0 ? "не имеет решений" : "x = " + -c / b));
            return res;
        }
        static string Kv(decimal a, decimal b, decimal c)
        {
            decimal d = b * b - 4 * a * c;
            double D = (double)d;
            string res = (D > 0? "x1 = " + (-(double)b + Math.Sqrt(D)) / (double)(2*a) + ", x2 = " + (-(double)b - Math.Sqrt(D)) / (double)(2 * a): (D == 0? "x = " + (-b / (2*a)): "не имеет решений"));
            return res;
        }
        static void Main(string[] args)
        {
            decimal a, b, c;
            bool flag1 = decimal.TryParse(Console.ReadLine(), out a);
            bool flag2 = decimal.TryParse(Console.ReadLine(), out b);
            bool flag3 = decimal.TryParse(Console.ReadLine(), out c);
            string result = (flag1 && flag2 && flag3) ? (a == 0 ? NeKv(b, c) : Kv(a, b, c)) : "Incorrect input";
            Console.WriteLine(result);
        }
    }
}
