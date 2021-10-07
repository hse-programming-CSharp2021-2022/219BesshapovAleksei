using System;

namespace HW_Spiral
{
    class Program
    {
        static void MatrixPrettyOutput(int[][] matrix)
        {
            Int32[] matrixColumnBiggestLengths = new Int32[matrix[0].Length];
            for (int j = 0; j < matrix[0].Length; j++)
            {
                Int32 matrixColumnBiggestLegth = 0;
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrixColumnBiggestLegth = Math.Max(matrixColumnBiggestLegth, matrix[i][j].ToString().Length);
                }
                matrixColumnBiggestLengths[j] = matrixColumnBiggestLegth;
            }
            string[] outputMatrixWithSeparators = new string[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    outputMatrixWithSeparators[i] += "|" + new string(' ', (matrixColumnBiggestLengths[j] - matrix[i][j].ToString().Length)) + matrix[i][j].ToString();// + new string(' ', matrixColumnBiggestLengths[i] - (matrixColumnBiggestLengths[j] - matrix[i][j].ToString().Length) / 2);
                }
                outputMatrixWithSeparators[i] += "|";
            }
            foreach (var item in outputMatrixWithSeparators)
            {
                Console.WriteLine(new string('-', item.Length));
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', outputMatrixWithSeparators[0].Length));
        }
        static void Main(string[] args)
        {
            int n = 0;
            bool isInputCorrect = true;
            do
            {
                Console.WriteLine("Введите порядок матрицы:");
                isInputCorrect = int.TryParse(Console.ReadLine(), out n);
            } while (!isInputCorrect || n < 1);
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }
            int direction = 0, currentRow = 0, currentCol = 0, leftUnfilledInLine = n;
            int colChange = 1, rowChange = 0;
            for (int i = 1; i <= n * n; i++)
            {
                matrix[currentRow][currentCol] = i;
                if (--leftUnfilledInLine == 0)
                {
                    leftUnfilledInLine = n - (direction / 2 - 1) - 2;
                    direction += 1;
                    (colChange, rowChange) = (rowChange != 0? -rowChange : 0, colChange != 0? colChange : 0);
                }
                currentCol += colChange;
                currentRow += rowChange;
            }
            MatrixPrettyOutput(matrix);
        }
    }
}
