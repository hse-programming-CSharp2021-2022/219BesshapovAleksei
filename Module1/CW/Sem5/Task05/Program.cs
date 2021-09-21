using System;

namespace Task05
{
    class Program
    {
        static double S(uint k)
        {
            double sum = 0;
            for (int i = 1; i < k+1; i++)
            {
                sum += ((double)i + 0.3) / ((double)(3*i*i) + 5.0);
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
