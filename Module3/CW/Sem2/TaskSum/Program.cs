using System;

delegate double Sum(int n);
namespace TaskSum
{
    class Program
    {
        static double SumGip(int n)
        {
            double res = 0;
            for (int i = 1; i < n + 1; i++)
            {
                res += Math.Pow(i, -1);
            }
            return res;
        }
        static double SumStepen(int n)
        {
            double res = 0;
            for (int i = 1; i < n + 1; i++)
            {
                res += Math.Pow(2, -1 * i);
            }
            return res;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[] sums = new double[n];
            Sum sum1 = new Sum(SumGip);
            Sum sum2 = new Sum(SumStepen);
            for (int i = 0; i < n; i++)
            {
                sums[i] = sum1(i + 1);
            }
            double[] sums2 = new double[n];
            for (int i = 0; i < n; i++)
            {
                sums2[i] = sum2(i + 1);
            }
            double res1 = 0, res2 = 0;
            for (int i = 0; i < n; i++)
            {
                res1 += sums[i];
                res2 += sums2[i];
            }
            Console.WriteLine(res1);
            Console.WriteLine(res2);
        }
    }
}
