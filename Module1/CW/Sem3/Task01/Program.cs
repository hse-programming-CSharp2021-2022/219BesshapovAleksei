using System;

namespace Task01
{
    class Program
    {
        static bool F(bool p, bool q)
        {
            return !(p & q) & !(p | !q);
        }
        static void F(bool p, bool q, out bool res)
        {
            res = !(p & q) & !(p | !q);
        }
        static void Main(string[] args)
        {
            bool res;
            Console.WriteLine(F(false, true));
            Console.WriteLine(F(true, true));
            Console.WriteLine(F(false, false));
            Console.WriteLine(F(true, false));
            Console.WriteLine("------");
            F(false, true, out res);
            Console.WriteLine(res);
            F(true, true, out res);
            Console.WriteLine(res);
            F(false, false, out res);
            Console.WriteLine(res);
            F(true, false, out res);
            Console.WriteLine(res);
        }
    }
}
