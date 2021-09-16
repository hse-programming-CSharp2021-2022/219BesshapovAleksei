using System;

namespace Task03
{
    class Program
    {
        static string Shkala(int a)
        {
            switch(a)
            {
                case < 4:
                    return "неудовлитворительно";
                    break;
                case < 6:
                    return "удовлитворительно";
                    break;
                case < 8:
                    return "хорошо";
                    break;
                case <= 10:
                    return "отлично";
                    break;
            }
        }
        static void Main(string[] args)
        {
            int a;
            int.TryParse(Console.ReadLine(), out a);
            Console.WriteLine(Shkala(a));
        }
    }
}
