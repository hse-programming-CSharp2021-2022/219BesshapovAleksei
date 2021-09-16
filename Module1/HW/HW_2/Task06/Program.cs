using System;

namespace Task06
{
    class Program
    {
        static void GameCalc(decimal b, int p, string c)
        {
            if (p >= 0 && p <= 100)
            {
                Console.WriteLine("Выделенный бюджет: " + b / 100 * p);
                if ( c == "r" )
                {
                    Console.WriteLine("Валюта: ₽");
                } else if ( c == "d" ) {
                    Console.WriteLine("Валюта: $");
                } else if ( c == "e") {
                    Console.WriteLine("Валюта: €");
                } else {
                    Console.WriteLine("Валюта не найдена");
                }
            } else
            {
                Console.WriteLine("Incorrect percent");
            }
        }
        static void Main(string[] args)
        {
            decimal budget;
            int percent;
            Console.WriteLine("Введите бюджет: ");
            bool flag1 = decimal.TryParse(Console.ReadLine(), out budget);
            Console.WriteLine("Введите процент на игрульки: ");
            bool flag2 = int.TryParse(Console.ReadLine(), out percent);
            Console.WriteLine("Введите название валюты: ");
            string currency = Console.ReadLine();
            if ( flag1 && flag2) {
                GameCalc(budget, percent, currency);
            } else {
                Console.WriteLine("Incorrect input");        
            }
        }
    }
}
