using System;
using System.Text.RegularExpressions;

namespace TaskRegular4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex(@"[0-9]+");
            var res = regex.Matches(text);
            int maxLength = 0;
            foreach (var item in res)
            {
                maxLength = Math.Max(maxLength, item.ToString().Length);
            }
            Console.WriteLine(maxLength);
            foreach (var item in res)
            {
                Console.Write(item + " ");
            }
        }
    }
}
