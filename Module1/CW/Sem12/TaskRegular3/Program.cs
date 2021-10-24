using System;
using System.Text.RegularExpressions;

namespace TaskRegular3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex(@"\b\w*a\b");
            var res = regex.Matches(text);
            foreach (var item in res)
            {
                Console.Write(item + " ");
            }
        }
    }
}
