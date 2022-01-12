using System;
internal class Program
{
    private static void Main(string[] args)
    {
        int[][] sudoku = new int[9][];
        for (int i = 0; i < 9; i++)
        {
            sudoku[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        }
        bool isRight = true;
        for (int i = 0; i < 9; i++)
        {
            bool[] contains = new bool[9];
            for (int j = 0; j < 9; j++)
            {
                contains[sudoku[i][j] - 1] = true;
            }
            for (int j = 0; j < 9; j++)
            {
                if (!contains[j])
                {
                    isRight = false;
                }
            }
        }
        for (int i = 0; i < 9; i++)
        {
            bool[] contains = new bool[9];
            for (int j = 0; j < 9; j++)
            {
                contains[sudoku[j][i] - 1] = true;
            }
            for (int j = 0; j < 9; j++)
            {
                if (!contains[j])
                {
                    isRight = false;
                }
            }
        }
        for (int i = 0; i <= 6; i+=3)
        {
            for (int j = 0; j <= 6; j+=3)
            {
                int[] nums = { sudoku[i][j], sudoku[i][j + 1], sudoku[i][j + 2],
                sudoku[i + 1][j], sudoku[i + 1][j + 1], sudoku[i + 1][j + 2],
                sudoku[i + 2][j], sudoku[i + 2][j + 1], sudoku[i + 2][j + 2]};
                bool[] contains = new bool[9];
                for (int z = 0; z < 9; z++)
                {
                    contains[nums[z] - 1]  = true;
                }
                for (int z = 0; z < 9; z++)
                {
                    if (!contains[z])
                    {
                        isRight = false;
                        Console.Write(1);
                    }
                }
            }
        }
        Console.WriteLine(isRight ? "correct" : "incorrect");
    }
}