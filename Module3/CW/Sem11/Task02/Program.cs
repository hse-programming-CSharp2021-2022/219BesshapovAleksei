using System;
using System.IO;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("Task02.txt", FileMode.OpenOrCreate))
            {
                if (fs.Length < 3)
                {
                    byte[] bytes = { (byte)((byte)'A' + fs.Length) };
                    fs.Position = fs.Length;
                    fs.Write(bytes);
                }
            }
            using (FileStream fs = new FileStream("Task02.txt", FileMode.Open))
            {
                int next = 0;
                while (next != -1)
                {
                    next = fs.ReadByte();
                    byte[] read = { (byte)next };
                    if (next == -1)
                    {
                        break;
                    }
                    Console.Write(System.Text.Encoding.Default.GetString(read) + " ");
                }
            }
        }
    }
}