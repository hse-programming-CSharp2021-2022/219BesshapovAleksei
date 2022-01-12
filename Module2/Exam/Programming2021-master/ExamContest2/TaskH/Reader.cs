using System;
using System.IO;
internal static class Reader
{
    public static string[] ReadFile(string fileName)
    {
        string text = File.ReadAllText(fileName);
        string[] data = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] res = new string[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            char[] elements = data[i].ToCharArray();
            char current = ' ';
            for (int j = 0; j < elements.Length; j++)
            {
                if (j == 0)
                {
                    current = elements[j];
                    res[i] = current.ToString();
                }
                else
                {
                    if (current != elements[j])
                    {
                        res[i] += elements[j].ToString();
                        current = elements[j];
                    }
                }
            }
        }
        return res;
    }
}