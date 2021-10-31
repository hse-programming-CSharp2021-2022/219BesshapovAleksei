using System;

namespace Task05
{
    class ConsolePlate
    {
        char _plateChar;
        ConsoleColor _plateColor = ConsoleColor.White;
        ConsoleColor _fontColor = ConsoleColor.Black;
        public ConsolePlate()
        {
            _plateChar = 'A';
        }
        public ConsolePlate(char plateChar, ConsoleColor plateColor, ConsoleColor fontColor)
        {
            if ("QWERTYUIOPASDFGHJKLZXCVBNM".Contains(plateChar.ToString()))
            {
                _plateChar = plateChar;
            }
            else
            {
                _plateChar = 'A';
            }
            _plateColor = plateColor;
            if (plateColor == fontColor)
            {
                _plateColor = ConsoleColor.Black;
                _fontColor = ConsoleColor.White;
            }
            else
            {
                _fontColor = fontColor;
            }
        }
        public char PlateChar
        {
            get
            {
                return _plateChar;
            }
            set
            {
                if ("QWERTYUIOPASDFGHJKLZXCVBNM".Contains(value.ToString()))
                {
                    _plateChar = value;
                } else
                {
                    _plateChar = 'A';
                }
            }
        }
        public ConsoleColor PlateColor
        {
            get
            {
                return _plateColor;
            }
        }
        public ConsoleColor FontColor
        {
            get
            {
                return _fontColor;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePlate a = new ConsolePlate('X', ConsoleColor.White, ConsoleColor.Red);
            ConsolePlate b = new ConsolePlate('O', ConsoleColor.White, ConsoleColor.Magenta);
            int n = int.Parse(Console.ReadLine());
            if (n >= 2 && n < 35)
            {
                ConsolePlate[,] plates = new ConsolePlate[n, n];
                bool isO = true;
                for (int i = 0; i < plates.GetLength(0); i++)
                {
                    for (int j = 0; j < plates.GetLength(1); j++)
                    {
                        if (j == 0 && i > 0)
                        {
                            if (plates[i-1,j].PlateChar.ToString() == "O")
                            {
                                isO = false;
                            }
                            else
                            {
                                isO = true;
                            }
                        }
                        if (isO)
                        {
                            plates[i, j] = b;
                            isO = false;
                        }
                        else
                        {
                            plates[i, j] = a;
                            isO = true;
                        }
                    }
                }
                for (int i = 0; i < plates.GetLength(0); i++)
                {
                    for (int j = 0; j < plates.GetLength(1); j++)
                    {
                        Console.ForegroundColor = plates[i, j].PlateColor;
                        Console.BackgroundColor = plates[i, j].FontColor;
                        Console.Write(plates[i, j].PlateChar + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
