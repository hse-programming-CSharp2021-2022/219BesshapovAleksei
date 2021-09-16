using System;

namespace Task04
{
    class Program
    {
        static int MinNum(int a, int b, int c)
        {
            int a1 = a % 100;
            int b1 = b % 100;
            int c1 = c % 100;
            int minNum = Math.Min(a1, Math.Min(b1, c1));
            return (minNum == a1) ? a : (minNum == b1 ? b : c);
        }
        static void Main(string[] args)
        {
            int cab1, cab2, cab3;
            Console.WriteLine("Введите 3 номера кабинетов: ");
            bool flag1 = int.TryParse(Console.ReadLine(), out cab1);
            bool flag2 = int.TryParse(Console.ReadLine(), out cab2);
            bool flag3 = int.TryParse(Console.ReadLine(), out cab3);
            Console.WriteLine((flag1 && flag2 && flag3 && cab1 >= 100 && cab1 <= 999 && cab2 >= 100 && cab2 <= 999 && cab3 >= 100 && cab3 <= 999)? "Минимальный номер аудитории вне зависимости от этажа: " + MinNum(cab1, cab2, cab3): "Incorrect input");
        }
    }
}
