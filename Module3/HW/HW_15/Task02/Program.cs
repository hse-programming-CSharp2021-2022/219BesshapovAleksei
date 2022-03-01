using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Task02
{
    class Program
    {
        private static readonly Random Random = new Random();

        private static async Task<double> Integral(Func<double, double> func, int left, int right, int n)
        {
            int correct = 0, min = left, max = right, maxY = (int)Math.Max(func(left), func(right)) + 1;
            for (int i = 0; i < n; i++)
            {
                await Task.Run(() =>
                {
                    double x = Random.Next(min, max) + Random.NextDouble();
                    double y = Random.Next(0, maxY) + Random.NextDouble();
                    if (y <= func(x))
                    {
                        correct++;
                    }
                });
            }

            return (double)correct / n * (max - min) * maxY;
        }

        static async Task Main()
        {
            int left = int.Parse(Console.ReadLine());
            int right = int.Parse(Console.ReadLine());
            List<double> results = new List<double>();
            for (int i = left; i <= right; i += 2)
            {
                await Task.Run(async () =>
                {
                    double res = await Integral(x => x * x, i, i + 2, Random.Next(0, 1000));
                    results.Add(res);
                });
            }
            Array.ForEach(results.ToArray(), el => Console.Write(el + " "));
        }
    }
}
