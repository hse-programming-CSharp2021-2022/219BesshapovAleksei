using System;
using System.IO;
using System.Text;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            StringBuilder sb;
            string[] lines = new string[6];
            for (int i = 0; i < 6; i++)
            {
                sb = new StringBuilder();
                int length = random.Next(20, 51);
                for (int j = 0; j < length; j++)
                {
                    sb.Append((char)random.Next('a', 'z' + 1));
                }
                sb.Append(".");
                lines[i] = sb.ToString();
            }
            File.WriteAllLines("data2.txt", lines);
            string[] allLines = File.ReadAllLines("data2.txt");
            foreach (var item in allLines)
            {
                Console.WriteLine(item.Substring(0, item.Length - 1));
            }
        }
    }
}
