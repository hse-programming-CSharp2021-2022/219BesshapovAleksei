using System;

namespace Task01
{
    class Program
    {
        static bool IsInG(decimal x, decimal y)
        {
            if ( (x >= 0 && y <= 0 && x * x + y * y <= 4) || (x >= 0 && y >= 0 && x * x + y * y <= 4 && x <= 2 && y / x <= 1) ) // последнее условие - проверка тангенса: он не должен превосходить тангенс 45 градусов
            {
                return true;
            } else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            decimal x, y;
            bool flag1 = decimal.TryParse(Console.ReadLine(), out x);
            bool flag2 = decimal.TryParse(Console.ReadLine(), out y);
            Console.WriteLine((flag1 && flag2) ? IsInG(x, y) : "Incorrect input");
        }
    }
}
