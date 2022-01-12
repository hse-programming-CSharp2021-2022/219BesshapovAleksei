using System;
using System.Text;

public class Field
{
    private int[,] matrix;

    public Field(int[,] matrix)
    {
        this.matrix = matrix;
    }

    public void FillIn(string fillType)
    {
        if (fillType != "top to bottom" && fillType != "bottom to top")
        {
            throw new ArgumentException("Incorrect input");
        }
        if (fillType == "top to bottom")
        {
            int start = 1;
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = start + j;
                }
                start++;
            }
        }
        else
        {
            int start = 1;
            for (int i = this.matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = start + j;
                }
                start++;
            }
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < this.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < this.matrix.GetLength(1); j++)
            {
                if (j != this.matrix.GetLength(1) - 1)
                {
                    sb.Append(this.matrix[i, j] + " ");
                }
                else
                {
                    sb.Append(this.matrix[i, j]);
                }
            }
            if (i != this.matrix.GetLength(0) - 1)
            {
                sb.Append(Environment.NewLine);
            }
        }
        return sb.ToString();
    }
}