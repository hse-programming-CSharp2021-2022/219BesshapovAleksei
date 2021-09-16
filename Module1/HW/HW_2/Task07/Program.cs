using System;

namespace Task07
{
    class Program
    {
        static void Parts(decimal a)
        {
            Console.WriteLine("Целая часть: " + (int)a + ", дробная часть: " + Math.Abs((a - (int)a)));
        }
        
        static void SqSqrt(decimal a)
        {
            double a1 = (double)a;
            Console.WriteLine("Квадрат: " + a * a);
            if (a1 >= 0)
            {
                Console.WriteLine("Корень: " + Math.Sqrt(a1));
            } else
            {
                Console.WriteLine("Невозможно извлечь корень");
            }
        }
        static void Main(string[] args)
        {
            decimal a;
            bool flag = decimal.TryParse(Console.ReadLine(), out a);
            if (flag)
            {
                SqSqrt(a);
                Parts(a);
            } else
            {
                Console.WriteLine("Incorrect input");
            } 
        }
    }
}
