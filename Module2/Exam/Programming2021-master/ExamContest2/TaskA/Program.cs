using System;
using System.Collections.Generic;
internal class Program
{
    public static int SortArray(int x, int y)
    {
        if (x < y)
        {
            return -1;
        }
        else if (x > y)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    private static void Main(string[] args)
    {
        List<int> heights = new List<int>();
        int height = int.Parse(Console.ReadLine());
        while (height != 0)
        {
            if (height < 190 || height > 250)
            {
                Console.WriteLine("Incorrect number");
            }
            else
            {
                heights.Add(height);
            }
            height = int.Parse(Console.ReadLine());
        }
        int[] arrayOfHeights = heights.ToArray();
        Array.Sort(arrayOfHeights, SortArray);
        Console.WriteLine(arrayOfHeights[0]);
        Console.WriteLine(arrayOfHeights[1]);
    }
}