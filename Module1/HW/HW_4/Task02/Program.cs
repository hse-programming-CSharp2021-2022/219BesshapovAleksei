using System;

namespace Task02
{
    class Program
    {
        static bool Shift(ref char ch)
        {
            if ( (int)ch >= 97 && (int)ch <= 122 )
            {
                ch >>= 4;
                return true;
            } else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
