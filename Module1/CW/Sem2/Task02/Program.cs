using System;

namespace Task02
{
    class Program
    {
        static void Chisla(string a)
        {
            int len = a.Length;
            int b;
            int.TryParse(a, out b);
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine((int)(b / Math.Pow(10, len - i - 1)) % 10);
            }
        }
        static void Main(string[] args)
        {
            string c = Console.ReadLine();
            Chisla(c);
        }
    }
}
