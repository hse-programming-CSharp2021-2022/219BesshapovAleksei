using System;

namespace Task03
{
    class Program
    {
        static double Zero(int x)
        {
            double res = 0;
            bool minus = true;
            int n = 3;
            int factorial = 6;
            double prev = x;
            double current = x;
            bool areSame = false;
            while (!areSame)
            {
                if (minus)
                {
                    current -= Math.Pow(x, n) / factorial;
                    if (current == prev)
                    {
                        res = current;
                        areSame = true;
                    }
                    prev -= Math.Pow(x, n) / factorial;
                    minus = false;
                    factorial *= n + 1;
                    factorial *= n + 2;
                    n += 2;
                }
                else
                {
                    current += Math.Pow(x, n) / factorial;
                    if (current == prev)
                    {
                        res = current;
                        areSame = true;
                    }
                    prev += Math.Pow(x, n) / factorial;
                    minus = true;
                    factorial *= n + 1;
                    factorial *= n + 2;
                    n += 2;
                }
            }
            return res;
        }
        static void ArrayFormation(int n)
        {
            double[] res = new double[n];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = Zero(i + 1);
            }
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
