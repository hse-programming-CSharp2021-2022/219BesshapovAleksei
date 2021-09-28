using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            int.TryParse(Console.ReadLine(), out k);
            int[] mas = new int[k];
            Random rand = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(97, 123);
            }
            foreach (var item in mas)
            {
                Console.WriteLine((char)item + " ");
            }
            Console.WriteLine();
            int[] mas2 = new int[k];
            Array.Copy(mas, mas2, k);
            Array.Sort(mas2);
            foreach (var item in mas2)
            {
                Console.WriteLine((char)item + " ");
            }
            Console.WriteLine();
            Array.Reverse(mas2);
            foreach (var item in mas2)
            {
                Console.WriteLine((char)item + " ");
            }
            Console.WriteLine();
        }
    }
}
