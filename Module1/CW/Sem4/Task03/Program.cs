using System;

namespace Task03
{
    class Program
    {
        static decimal S(decimal A, decimal B, decimal Delta)
        {
            decimal result = 0;
            decimal spaceLeft = 0;
            for (decimal i = A; i + Delta < B; i+=Delta)
            {
                result += Delta * ((i * i + (i + Delta) * (i + Delta)) / 2);
                if ((i + 2 * Delta) > B)
                {
                    spaceLeft = i + Delta;
                }
            }
            if (spaceLeft != B)
            {
                result += (B - spaceLeft) * (spaceLeft * spaceLeft + B * B) / 2;
            }
            return result;
        }
        static void Main(string[] args)
        {
            decimal a;
            decimal b;
            decimal delta;
            bool flag1 = decimal.TryParse(Console.ReadLine(), out a);
            bool flag2 = decimal.TryParse(Console.ReadLine(), out b);
            bool flag3 = decimal.TryParse(Console.ReadLine(), out delta);
            Console.WriteLine((flag1 && flag2 && flag3) ? S(a, b, delta) : "Incorrect input");
        }
    }
}
