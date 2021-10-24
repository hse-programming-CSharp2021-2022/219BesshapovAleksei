using System;
using System.Linq;

namespace TaskRequests
{
    class Program
    {
        static int SortByLen(int a, int b)
        {
            int res = 0;
            if (a.ToString().Length > b.ToString().Length)
            {
                res = -1;
            }
            else if (a.ToString().Length < b.ToString().Length)
            {
                res = 1;
            }
            else
            {
                res = 0;
            }
            return res;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = random.Next(1, 10001);
            }
            // 1
            var res1 = (from number in numbers
                        where number < 100 && number > 9 && number % 3 == 0
                        select number).ToArray();
            foreach (var item in res1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            // 2
            var res2 = (from number in numbers
                        where number / 1000 == number % 10 && number % 1000 / 100 == number % 100 / 10
                        select number).ToArray();
            foreach (var item in res2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            // 3
            var res3 = numbers.OrderBy(el => -el.ToString().Length).ThenBy(el => -el).ToArray();
            foreach (var item in res3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            // 4
            var res4 = (from number in numbers
                        where number.ToString().Length == 4
                        select number / 1000 + number % 10 + number % 1000 / 100 + number % 100 / 10).ToArray();
            foreach (var item in res4)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            // 5
            var res5 = (from number in numbers
                        where number.ToString().Length == 2
                        select number).ToArray();
            int minimum = 100;
            foreach (var item in res5)
            {
                minimum = Math.Min(minimum, item);
            }
            Console.WriteLine(minimum != 100? minimum.ToString(): "Двузначных нет");
            // 6
            int[] maxNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                int maxNumber = -1;
                while (numbers[i] != 0)
                {
                    maxNumber = Math.Max(maxNumber, numbers[i] % 10);
                    numbers[i] /= 10;
                }
                maxNumbers[i] = maxNumber;
            }
            Array.ForEach(maxNumbers, el => Console.Write(el + " "));
            Console.WriteLine();
        }
    }
}
