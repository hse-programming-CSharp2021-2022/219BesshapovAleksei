using System;
using System.Linq;

namespace TaskHW
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            Random randomizer = new Random();
            for (int i = 0; i < n; i++)
            {
                numbers[i] = randomizer.Next(-1000, 1001);
            }
            Array.ForEach(numbers, el => Console.Write(el + " "));
            Console.WriteLine();
            var task1 = from number in numbers
                        select number * number;
            Array.ForEach(task1.ToArray(), el => Console.Write(el + " "));
            Console.WriteLine();
            var task2 = from number in numbers
                        where number > 0 && number % 100 == number
                        select number;
            Array.ForEach(task2.ToArray(), el => Console.Write(el + " "));
            Console.WriteLine();
            var task3 = from number in numbers
                        where Math.Abs(number) % 2 == 0
                        orderby number descending
                        select number;
            Array.ForEach(task3.ToArray(), el => Console.Write(el + " "));
            Console.WriteLine();
            var task4 = from number in numbers
                        group number by Math.Abs(number).ToString().Length into groupByLength
                        select groupByLength;
            foreach (var key in task4)
            {
                foreach (var item in key)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
