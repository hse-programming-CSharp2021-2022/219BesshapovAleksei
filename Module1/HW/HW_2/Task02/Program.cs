using System;

namespace Task02
{
    class Program
    {
        static int MaxPossible(int x)
        {
            if ( x >= 100 && x <= 999)
            {
                int h = x / 100;
                int e = x % 10;
                x /= 10;
                int d = x % 10;
                int max = Math.Max(h, Math.Max(e, d));
                int min = Math.Min(h, Math.Min(e, d));
                int sr = h + e + d - max - min;
                return max * 100 + 10 * sr + min;
            } else
            {
                Console.WriteLine("Incorrect input");
                return -1;
            }
        }
        static void Main(string[] args)
        {
            int a;
            bool flag = int.TryParse(Console.ReadLine(), out a);
            if ( flag )
            {
                int res = MaxPossible(a);
                Console.WriteLine(res);
            } else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
