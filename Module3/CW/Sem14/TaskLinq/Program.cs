using System;
using System.Linq;

namespace TaskLinq
{
    class Program
    {
        static int[] GetLastDigits(int[] numbers)
        {
            int[] lastDigits = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                lastDigits[i] = Math.Abs(numbers[i]) % 10;
            }
            return lastDigits;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Random randomizer = new Random();
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = randomizer.Next(-10000, 10001);
            }
            var task1 = from number in numbers
                        select Math.Abs(number) % 10;
            Array.ForEach(task1.ToArray(), el => Console.Write(el + " "));
            Console.WriteLine();
            var task2 = from number in numbers
                        group number by Math.Abs(number) % 10 into sameLastDigit
                        select sameLastDigit;
            foreach (var key in task2)
            {
                foreach (var item in key)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
            var task2_2 = numbers.GroupBy(el => Math.Abs(el) % 10);
            var task3 = from number in numbers
                        where number > 0 && Math.Abs(number) % 2 == 0
                        select number;
            Console.WriteLine(numbers.Count(el => el > 0 && Math.Abs(el) % 2 == 0));
            var task4 = (from number in numbers
                         where Math.Abs(number) % 2 == 0
                         select number).Sum();
            var task5 = numbers.OrderBy(el => (int)Math.Abs(el).ToString()[0])
                .ThenBy(el => el % 10);
            Array.ForEach(task5.ToArray(), el => Console.Write(el + " "));
        }
    }
}
