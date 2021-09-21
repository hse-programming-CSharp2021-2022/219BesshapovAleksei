using System;

namespace Task01
{
    class Program
    {
        static void Sums(uint number, out uint sumEven, out uint sumOdd)
        {
            sumEven = 0;
            sumOdd = 0;
            bool chet = true;
            while (number != 0)
            {
                if (chet)
                {
                    sumEven += number % 10;
                    chet = false;
                }
                else
                {
                    sumOdd += number % 10;
                    chet = true;
                }
                number /= 10;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
