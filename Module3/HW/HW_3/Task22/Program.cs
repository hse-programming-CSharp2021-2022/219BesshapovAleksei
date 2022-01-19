using System;

namespace Task22
{
    delegate void CoordChanged(Dot dot);
    class Dot
    {
        public double X
        {
            get;
            set;
        }
        public double Y
        {
            get;
            set;
        }
        public event CoordChanged OnCoordChanged;
        public Dot(double x, double y)
        {
            X = x;
            Y = y;
        }
        public void DotFlow()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                double newX = -10 + 20 * random.NextDouble();
                double newY = -10 + 20 * random.NextDouble();
                this.X = newX;
                this.Y = newY;
                if (newX < 0 && newY < 0)
                {
                    this.OnCoordChanged(this);
                }
            }
        }
    }
    class Program
    {
        static void PrintInfo(Dot A)
        {
            Console.WriteLine($"X: {A.X}, Y: {A.Y}");
        }
        static void Main(string[] args)
        {
            Console.Write("X: ");
            double X = double.Parse(Console.ReadLine());
            Console.Write("Y: ");
            double Y = double.Parse(Console.ReadLine());
            Dot D = new Dot(X, Y);
            D.OnCoordChanged += PrintInfo;
            D.DotFlow();
        }
    }
}
