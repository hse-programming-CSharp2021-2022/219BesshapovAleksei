using System;
using System.Text;

namespace Task05
{
    class VideoFile
    {
        string string_name;
        int int_duration, int_quality;
        public VideoFile(string name, int duration, int quality)
        {
            this.string_name = name;
            this.int_duration = duration;
            this.int_quality = quality;
        }
        public int Int_duration
        {
            get
            {
                return int_duration;
            }
        }
        public int Int_quality
        {
            get
            {
                return int_quality;
            }
        }
        public string String_name
        {
            get
            {
                return string_name;
            }
        }
        public int Size
        {
            get
            {
                return Int_quality * Int_duration;
            }
        }
        public override string ToString()
        {
            return $"Название файла: {this.String_name}, размер: {this.Size}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();
            Console.Write("Хотите воспользоваться программой? Если нет, то введите no, в ином случае введите что угодно:");
            string answer = Console.ReadLine();
            while (answer != "no")
            {
                VideoFile singleFile = new VideoFile("singleFile.txt", 100, 480);
                Console.WriteLine($"Одиночный файл, {singleFile.ToString()}.");
                int N = randomizer.Next(5, 16);
                VideoFile[] videoFiles = new VideoFile[N];
                for (int i = 0; i < N; i++)
                {
                    videoFiles[i] = new VideoFile(RandomString(randomizer.Next(2, 10)), randomizer.Next(60, 361), randomizer.Next(100, 1001));
                    Console.WriteLine($"Файл {i + 1}, {videoFiles[i].ToString()}. {CompareSizes(singleFile, videoFiles[i])}");
                }
                Console.Write("Хотите воспользоваться программой еще раз? Если нет, то введите no, в ином случае введите что угодно:");
                answer = Console.ReadLine();
            }
            Console.WriteLine("Программа завершена.");
        }
        public static string RandomString(int size)
        {
            StringBuilder sb = new StringBuilder();
            Random randomizer = new Random();
            for (int i = 0; i < size; i++)
            {
                sb.Append(((char)randomizer.Next(97, 123)).ToString());
            }
            return sb.ToString();
        }
        public static string CompareSizes(VideoFile file1, VideoFile file2)
        {
            return file1.Size > file2.Size ? "Его размер меньше размера одиночного фалйа" :
                "Его размер не меньше размера одиночного файла.";
        }
    }
}
