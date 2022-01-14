using System;

namespace TaskAdditional2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[10];
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = random.Next(1, 20);
            }
            Array.ForEach(numbers, el => Console.Write(el + " "));
            Console.WriteLine();
            double[] numbers2 = Array.ConvertAll(numbers, x => 1.0 / x);
            Array.ForEach(numbers2, el => Console.Write(el.ToString("F2") + " "));
        }
    }
}
