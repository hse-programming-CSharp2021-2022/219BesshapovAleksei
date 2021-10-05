using System;

namespace FromChat03
{
    class Program
    {
        static int AmmountOfWords(string input)
        {
            string[] words = input.Split();
            string glass = "ёЁуЁеЕыЫаАоОэЭяЯиИюЮ";
            int res = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (j == 0 && glass.Contains(words[i][j]))
                    {
                        res++;
                    }
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(AmmountOfWords("авы выф    еку"));
        }
    }
}
