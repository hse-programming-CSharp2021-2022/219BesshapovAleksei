using System;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            float U;
            float R;
            float.TryParse(Console.ReadLine(), out U);
            float.TryParse(Console.ReadLine(), out R);
            Console.WriteLine("Сила тока: " + U / R + ", потребляемая мощность: " + U * U / R);
        }
    }
}
