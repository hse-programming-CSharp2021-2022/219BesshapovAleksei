using System;
internal class Program
{
    private static void Main(string[] args)
    {
        string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double[] profit = new double[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            profit[i] = double.Parse(data[i]);
        }
        double sum = 0;
        foreach (double item in profit)
        {
            sum += item;
        }
        Console.WriteLine((sum * 10).ToString("F3"));
    }
}