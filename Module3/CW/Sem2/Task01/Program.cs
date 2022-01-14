using System;
using System.Text;

delegate string ConvertRule(string x);
namespace Task01
{
    class Converter
    {
        static public string Convert(string str, ConvertRule cr)
        {
            return cr(str);
        }
    }
    class Program
    {
        public static string RemoveDigits(string str)
        {
            StringBuilder sb = new StringBuilder();
            string numbers = "1234567890";
            foreach (var item in str)
            {
                if (!numbers.Contains(item))
                {
                    sb.Append(item);
                }
            }
            return sb.ToString();
        }
        public static string RemoveSpaces(string str)
        {
            return string.Join("", str.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
        static void Main(string[] args)
        {
            string[] testStrings = { "a s d fdsad", "a123b456c", "a1 b2 c3 d4" };
            ConvertRule rule1 = new ConvertRule(RemoveDigits);
            ConvertRule rule2 = new ConvertRule(RemoveSpaces);
            foreach (var item in testStrings)
            {
                Console.WriteLine(rule1(item));
                Console.WriteLine(rule2(item));
            }
            ConvertRule rule3 = rule1 + rule2;
            Delegate[] invocationList = rule3.GetInvocationList();
            foreach (var item in testStrings)
            {
                Console.WriteLine(rule3(item));
            }
            foreach (var item in testStrings)
            {
                Console.WriteLine(RemoveDigits(RemoveSpaces(item)));
            }
        }
    }
}
