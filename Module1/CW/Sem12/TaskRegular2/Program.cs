using System;
using System.Text.RegularExpressions;

namespace TaskRegular2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex(@"\b\w{4}\b");
            var matches = regex.Matches(text);
            foreach (var item in matches)
            {
                Console.Write(item + " ");
            }
        }
    }
}
