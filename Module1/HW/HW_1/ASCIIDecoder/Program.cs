using System;

namespace ASCIIDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            Console.WriteLine("Введите число от 32 до 127:");
            int.TryParse(Console.ReadLine(), out a);
            Console.WriteLine((char)a);
        }
    }
}
