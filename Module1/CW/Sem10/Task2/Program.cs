using System;

namespace Task2
{
    class Program
    {
        static string Line(int[] series)
        {
            string res = "";
            string[] letters = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            foreach (var item in series)
            {
                if (item >= 0 && item <= 9)
                {
                    int index = int.Parse(item.ToString());
                    res += letters[index];
                }
                else
                {
                    res += item.ToString();
                }
                res += " ";
            }
            return res;
        }
        static void Main(string[] args)
        {
            int[] mas = new int[10];
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                mas[i] = random.Next(0, 10);
            }
            Console.WriteLine(Line(mas));
        }
    }
}
