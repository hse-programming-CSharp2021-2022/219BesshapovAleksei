using System;

delegate void SquareSizeChanged(double x);
namespace Task01
{
    class Square
    {
        double xtopLeft, xdownRight, ytopLeft, ydownRight;
        public double XtopLeft
        {
            get
            {
                return xtopLeft;
            }
            set
            {
                OnSizeChanged(XdownRight - value);
                XtopLeft = value;
            }
        }
        public double YtopLeft
        {
            get
            {
                return ytopLeft;
            }
            set
            {
                OnSizeChanged(ydownRight - value);
                ytopLeft = value;
            }
        }
        public double XdownRight
        {
            get
            {
                return xdownRight;
            }
            set
            {
                OnSizeChanged(XtopLeft - value);
                xdownRight = value;
            }
        }
        public double YdownRight
        {
            get
            {
                return ydownRight;
            }
            set
            {
                OnSizeChanged(YtopLeft - value);
                ydownRight = value;
            }
        }
        public event SquareSizeChanged OnSizeChanged;
        public Square(double x1, double y1, double x2, double y2)
        {
            XtopLeft = x1;
            YtopLeft = y1;
            XdownRight = x2;
            YdownRight = y2;
        }
    }
    class Program
    {
        static void SquareConsoleInfo(double a)
        {
            Console.WriteLine(a.ToString("f2"));
        }
        static void Main(string[] args)
        {
            Square S = new Square(1, 2, 3, 4);
            S.OnSizeChanged += SquareConsoleInfo;
            Console.WriteLine("Введите -123321, чтобы прекратить");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            while (x != -123321 && y != -123321)
            {
                S.XdownRight = x;
                S.YdownRight = y;
                Console.WriteLine("Введите -123321, чтобы прекратить");
                x = double.Parse(Console.ReadLine());
                y = double.Parse(Console.ReadLine());
            }
        }
    }
}
