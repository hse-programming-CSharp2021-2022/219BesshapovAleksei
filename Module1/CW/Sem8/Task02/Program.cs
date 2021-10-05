using System;

namespace Task02
{
    class Program
    {
        static int PoUbiv(int a, int b)
        {
            if (a > b)
            {
                return -1;
            }
            else if (a < b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static int PoUbiv(float a, float b)
        {
            if (a > b)
            {
                return -1;
            }
            else if (a < b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);
            float[] mas = new float[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                mas[i] = (float)rand.NextDouble() * 1000;
            }
            Array.ForEach(mas, el => Console.WriteLine(el));
            int[] z = new int[n];
            for (int i = 0; i < n; i++)
            {
                z[i] = (int)mas[i];
            }
            float[] r = new float[n];
            for (int i = 0; i < n; i++)
            {
                r[i] = mas[i] - (int)mas[i];
            }
            Array.Sort(z, PoUbiv);
            Array.Sort(r, PoUbiv);
            Array.ForEach(z, el => Console.WriteLine(el));
            Array.ForEach(r, el => Console.WriteLine(el));
        }
    }
}
