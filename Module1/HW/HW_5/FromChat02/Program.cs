using System;
using System.Linq;

namespace FromChat02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] allHundred = new int[100];
            for (int i = 0; i < 100; i++)
            {
                allHundred[i] = i + 1;
            }
            Random rand = new Random();
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
            Array.Resize(ref allHundred, 100);
            allHundred[99] = allHundred[rand.Next(0, 99)];
            int[] all = new int[100];
            for (int i = 0; i < 100; i++)
            {
                all[i] = i + 1;
            }
            var diff = all.Except(allHundred);
            int missingNum = 0;
            foreach (var item in diff)
            {
                missingNum = (int)item;
            }
            Console.WriteLine(missingNum - (5050 - allHundred.Sum()));
        }
    }
}
