using System;

namespace TaskAdditional1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[10];
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = random.Next(-15, 16);
            }
            Array.ForEach(numbers, el => Console.Write(el + " "));
            Console.WriteLine();
            Array.Sort(numbers, (x, y) => Math.Abs(x).CompareTo(Math.Abs(y)));
            Array.ForEach(numbers, el => Console.Write(el + " "));
        }
    }
}
