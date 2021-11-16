using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExceptionCatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] testIndexOutOfRangeException = new int[5];
                Console.WriteLine(testIndexOutOfRangeException[6]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                (int a, int b) = (1, 0);
                Console.WriteLine(a / b);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                object testNullReferenceException = null;
                Console.WriteLine(testNullReferenceException.ToString());
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                File.OpenRead("testFileException.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                Console.WriteLine(drives[1].AvailableFreeSpace);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Console.WriteLine("testException".Substring(15));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                int[] testException = new int[2];
                testException[0] = int.Parse("test");
            }
            catch (FormatException ex)
            {
                Console.Write(ex.Message);
            }
            try
            {
                String testException = null;
                Console.WriteLine("TestException".IndexOf(testException));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                object testException = "test";
                int a = (int)testException;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                StringBuilder sb = new StringBuilder(15, 15);
                sb.Append("Substring #1 ");
                sb.Insert(0, "Substring #2 ", 1);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine("Out of Memory: {0}", e.Message);
            }
            try
            {
                throw new ExecutionEngineException("Ошибка системы, программа закрывается");
            }
            catch (ExecutionEngineException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
