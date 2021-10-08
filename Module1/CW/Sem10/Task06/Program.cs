using System;

namespace Task06
{
    class Program
    {
        static void Filling(int n, double percent)
        {
            char[] mas = new char[n];
            int letterAmount = (int)(n * percent / 100.0);
            Random random = new Random();
            for (int i = 0; i < letterAmount; i++)
            {
                mas[i] = (char)random.Next((int)('a'), (int)('z') + 1);
            }
            for (int i = letterAmount; i < n; i++)
            {
                mas[i] = (char)random.Next('0', '9' + 1);
            }
            Array.ForEach(mas, el => Console.Write(el + " "));
        }
        static void Main(string[] args)
        {
            int n = 10;
            double percent = 30;
            Filling(n, percent);   
        }
    }
}
