using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            double i = 1;
            double a = 0;
            double a2 = 0;
            float i2 = 1;
            float b = 0;
            float b2 = 0;
            bool flagForDouble = false;
            bool flagForFloat = false;
            while (!flagForDouble)
            {
                a2 += 1 / (3 * i + 3);
                if (a == a2)
                {
                    flagForDouble = true;
                    Console.WriteLine(a2);
                }
                a += 1 / (3 * i + 3);
                i += 1;
            }
            while (!flagForFloat)
            {
                b2 += 1 / (3 * i2 + 3);
                if (b == b2)
                {
                    flagForFloat = true;
                    Console.WriteLine(b2);
                }
                b += 1 / (3 * i2 + 3);
                i2 += 1;
            }
        }
    }
}
