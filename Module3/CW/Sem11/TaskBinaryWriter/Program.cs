using System;
using System.IO;
namespace TaskBinaryWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            using (BinaryWriter writer = new BinaryWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                    writer.Write(random.Next(1, 101));
            }
            int[] array = new int[10];
            using (BinaryReader reader = new BinaryReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                {
                    array[i] = reader.ReadInt32();
                    Console.WriteLine(array[i]);
                }
                int n = int.Parse(Console.ReadLine());
                int min = -1, res = -1;
                for (int i = 0; i < 10;i++)
                {
                    if (i == 0)
                    {
                        res = 0;
                        min = Math.Abs(n - array[i]);
                    }
                    else
                    {
                        min = Math.Min(Math.Abs(n - array[i]), min);
                        res = i;
                    }
                }
                array[res] = n;
            }
            using (BinaryWriter writer = new BinaryWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10;i++)
                    writer.Write(array[i]);
            }
            using (BinaryReader reader = new BinaryReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10;i++)
                {
                    array[i] = reader.ReadInt32();
                    Console.Write(array[i] + " ");
                }
            }
        }
    }
}