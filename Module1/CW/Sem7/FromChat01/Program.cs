using System;
using System.Linq;

namespace FromChat01
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] allHundred = new int[100];
            for (int i = 0; i < 100; i++)
            {
                allHundred[i] = i + 1;
            }
            allHundred[rand.Next(0, 100)] = -1;
            for (int i = 0; i < allHundred.Length; i++)
            {
                if (allHundred[i] == -1)
                {
                    allHundred[i] = allHundred[99];
                    allHundred[99] = -1;
                    break;
                }
            }
            Array.Resize(ref allHundred, 99);
            Console.WriteLine((1 + 100) * 50 - allHundred.Sum());
        }
    }
}
