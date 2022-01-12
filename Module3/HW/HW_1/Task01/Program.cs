using System;

delegate int Cast(double x);
namespace Task01
{
    class Program
    {
        static int ClosestEven(double x)
        {
            return (int)x % 2 == 0 ? (int)x : (int)x + 1;
        }
        static int GetLength(double x)
        {
            return x.ToString().Length - 1;
        }
        static void Main(string[] args)
        {
            Cast cast1 = delegate (double x)
            {
                return (int)x % 2 == 0 ? (int)x : (int)x + 1;
            };
            Cast cast2 = delegate (double x)
            {
                return x.ToString().Length - 1;
            };
            Console.WriteLine(cast1(1.5));
            Console.WriteLine(cast2(3));
            Console.WriteLine(cast2(99));
            Cast summedCast = cast1;
            summedCast += cast2;
            Console.WriteLine(summedCast(5));
            cast1 = (double x) => (int)x % 2 == 0 ? (int)x : (int)x + 1;
            cast2 = (double x) => x.ToString().Length - 1;
            summedCast.Invoke(4.5);
            summedCast = cast1;
            summedCast += cast2;
            /* summedCast -= ???; удалить данное lambda-выражение невозможно, так
             * как мы не знаем на него "ссылку". */
            Cast secondAttempt = new Cast(ClosestEven);
            secondAttempt += GetLength;
            secondAttempt += GetLength;
            secondAttempt += ClosestEven;
            secondAttempt -= GetLength;
            secondAttempt -= ClosestEven; // удалится последнее вхождение
            // удаляемого метода. Проверка:
            Array.ForEach(secondAttempt.GetInvocationList(), el => Console.WriteLine(el.Method));
        }
    }
}