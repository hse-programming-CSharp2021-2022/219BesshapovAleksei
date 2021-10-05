using System;
using System.Text;

namespace FromChat02
{
    class Program
    {
        static string ConvertHex2Bin(string HexNumber)
        {
            char[] hexNumberCharArray = HexNumber.ToCharArray();
            string[] hexNumberStringArray = new string[hexNumberCharArray.Length];
            for (int i = 0; i < hexNumberCharArray.Length; i++)
            {
                int n = 0;
                if (int.TryParse(hexNumberCharArray[i].ToString(), out n))
                {
                    hexNumberStringArray[i] = n.ToString();
                }
                else
                {
                    if (hexNumberCharArray[i].ToString() == "A")
                    {
                        hexNumberStringArray[i] = 10.ToString();
                    }
                    else if (hexNumberCharArray[i].ToString() == "B")
                    {
                        hexNumberStringArray[i] = 11.ToString();
                    }
                    else if (hexNumberCharArray[i].ToString() == "C")
                    {
                        hexNumberStringArray[i] = 12.ToString();
                    }
                    else if (hexNumberCharArray[i].ToString() == "D")
                    {
                        hexNumberStringArray[i] = 13.ToString();
                    }
                    else if (hexNumberCharArray[i].ToString() == "E")
                    {
                        hexNumberStringArray[i] = 14.ToString();
                    }
                    else if (hexNumberCharArray[i].ToString() == "F")
                    {
                        hexNumberStringArray[i] = 15.ToString();
                    }
                }
            }
            int number = 0;
            Array.Reverse(hexNumberStringArray);
            for (int i = 0; i < hexNumberStringArray.Length; i++)
            {
                number += int.Parse(hexNumberStringArray[i]) * (int)Math.Pow(16, i);
            }
            StringBuilder res = new StringBuilder("", 100);
            while (number != 0)
            {
                res.Append((number % 2).ToString());
                number /= 2;
            }
            return res.ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
