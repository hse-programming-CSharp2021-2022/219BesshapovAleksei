using System;

namespace TaskSnakeFulfill
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);
            int[,] mas = new int[n, n];
            int current = 1;
            bool isStraight = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (isStraight)
                    {
                        mas[i, j] = current;
                    }
                    else
                    {
                        mas[i, n - j - 1] = current;
                    }
                    current++;

                }
                isStraight = !isStraight;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine(mas[i, j] + "");
                }
                Console.WriteLine();
            }
        }
    }
}
