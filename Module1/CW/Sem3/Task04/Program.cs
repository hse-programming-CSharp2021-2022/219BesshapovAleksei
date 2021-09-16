using System;

namespace Task04
{
    class Program
    {
        static int Rev(int a)
        {
            string b = a.ToString();
            int len = b.Length;
            double res = 0;
            for (int i = 0; i < len; i++)
            {
                res += Math.Pow(10, len - i - 1) * (a % 10);
                a /= 10;
            }
            return (int)res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
