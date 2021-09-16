using System;

namespace Task02
{
    class Program
    {
        static double G(double x, double y)
        {
            if ( x < y && x > 0)
            {
                return x + Math.Sin(y);
            }
            else if ( x > y && x < 0 )
            {
                return y - Math.Cos(x);
            }
            else
            {
                return 0.5 * x * y;
            }
        }
        static void Main(string[] args)
        {
            double x;
            double y;
            bool flag1 = double.TryParse(Console.ReadLine(), out x);
            bool flag2 = double.TryParse(Console.ReadLine(), out y);
            Console.WriteLine((flag1 && flag2)? G(x, y):"Incorrect input");
        }
    }
}
