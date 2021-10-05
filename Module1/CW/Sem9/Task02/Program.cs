using System;
using System.Text;

namespace Task02
{
    class Program
    {
        static void CompressString(string input)
        {
            string[] letters = { "e", "y", "u", "i", "o", "a", "E", "Y", "U", "I", "O", "A" };
            string[] inputString = input.Split(';');
            for (int i = 0; i < inputString.Length; i++)
            {
                string[] currentString = inputString[i].Split(' ');
                StringBuilder res = new StringBuilder("", 50);
                for (int j = 0; j < currentString.Length; j++)
                {
                    for (int z = 0; z < currentString[j].Length; z++)
                    {
                        res.Append(currentString[j][z]);
                        if (string.Join(' ', letters).Contains(currentString[j][z]))
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine(res.ToString());
            }
        }
        static void Main(string[] args)
        {
            CompressString("Let It be; All you need is love");
        }
    }
}
