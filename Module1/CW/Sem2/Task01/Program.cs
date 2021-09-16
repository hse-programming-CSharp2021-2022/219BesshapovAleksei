using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            double r;
            bool flag = double.TryParse(Console.ReadLine(), out r);
            if ( flag )
            {
                Console.WriteLine("Длина: " + (2 * Math.PI * r).ToString("F3") + ", площадь: " + (Math.PI * r * r).ToString("F3"));
            }
        }
    }
}
