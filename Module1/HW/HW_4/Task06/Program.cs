using System;

namespace Task06
{
    class Program
    {
        static double S1(double x)
        {
            double before = 1;
            double after = 1;
            int n = 1;
            int factorial = 1;
            bool changes = true;
            while (changes)
            {
                after += Math.Pow(x, n) / factorial;
                if (after == before)
                {
                    changes = false;
                }
                before += Math.Pow(x, n) / factorial;
                n += 1;
                factorial *= n;
            }
            return after;
        }
        static double S2(double x)
        {
            double before = x*x;
            double after = x*x;
            int xStepen = 4;
            int twoStepen = 3;
            int factorial = 24;
            bool minus = true;
            bool changes = true;
            while (changes)
            {
                if (minus)
                {
                    after -= Math.Pow(2, twoStepen) * Math.Pow(x, xStepen) / factorial;
                }
                else
                {
                    after += Math.Pow(2, twoStepen) * Math.Pow(x, xStepen) / factorial;
                }
                if (after == before)
                {
                    changes = false;
                }
                if (minus)
                {
                    before -= Math.Pow(2, twoStepen) * Math.Pow(x, xStepen) / factorial;
                    minus = false;
                }
                else
                {
                    before += Math.Pow(2, twoStepen) * Math.Pow(x, xStepen) / factorial;
                    minus = true;
                }
                twoStepen += 2;
                xStepen += 2;
                factorial *= twoStepen;
                factorial *= xStepen;
            }
            return after;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
