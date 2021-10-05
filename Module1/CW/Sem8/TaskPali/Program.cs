using System;

namespace TaskPali
{
    class Program
    {
        static bool isPali(int x)
        {
            int ths = x / 1000;
            int huns = (x % 1000) / 100;
            int tens = (x % 100) / 10;
            int eds = x % 10;
            return ths == eds && huns == tens;
        }
        static void Main(string[] args)
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);
            int[] mas = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                mas[i] = rand.Next(1000, 10000);
            }
            Array.ForEach(mas, el => Console.WriteLine(el));
            foreach (var item in mas)
            {
                if (isPali(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
