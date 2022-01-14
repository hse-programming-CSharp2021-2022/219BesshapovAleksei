using System;

delegate int[] Row(int x);
delegate void Print(int[] x);
namespace Task02
{
    class Program
    {
        static int[] ConvertToArray(int x)
        {
            char[] charArray = x.ToString().ToCharArray();
            int[] result = new int[charArray.Length];
            for (int i = 0; i < charArray.Length; i++)
            {
                result[i] = int.Parse(charArray[i].ToString());
            }
            return result;
        }
        static void PrintElements(int[] x)
        {
            foreach (var item in x)
            {
                Console.Write(item.ToString() + " ");
            }
        }
        static void Main(string[] args)
        {
            Row row = new Row(ConvertToArray);
            Print print = new Print(PrintElements);
            Console.WriteLine(row.Method);
            Console.WriteLine(row.Target);
            Console.WriteLine(print.Method);
            Console.WriteLine(print.Target);
            print(new int[] { 1, 2, 3, 4 });
            print(row(1243245435));
        }
    }
}
