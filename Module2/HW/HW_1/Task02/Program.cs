using System;

namespace Task02
{
    class Point
    {
        decimal x, y;
        public Point(decimal absc=0, decimal ord=0)
        {
            x = absc;
            y = ord;
        }
        public decimal X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public decimal Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public decimal R
        {
            get
            {
                return x * x + y * y;
            }
        }
        public double Fi
        {
            get
            {
                if (x > 0 && y >= 0)
                {
                    return Math.Atan((double)(y / x));
                }
                else if (x > 0 && y < 0)
                {
                    return Math.Atan((double)(y / x)) + 2 * Math.PI;
                }
                else if (x < 0)
                {
                    return Math.Atan((double)(y / x)) + Math.PI;
                }
                else if (x == 0 && y > 0)
                {
                    return Math.PI / 2.0;
                }
                else if (x == 0 && y < 0)
                {
                    return 3 * Math.PI / 2.0;
                }
                else
                {
                    return 0;
                }
            }
        }
        public string Data()
        {
            return "X: " + this.X + ", Y: " + this.Y + ", r: " + Math.Sqrt((double)this.R) + ", fi: " + this.Fi; 
        }
    }
    class Program
    {
        static int SortByDistance(Point a, Point b)
        {
            if (a.R < b.R)
            {
                return -1;
            }
            else if (a.R > b.R)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            Point[] points = new Point[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write("x: ");
                decimal x = decimal.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("y: ");
                decimal y = decimal.Parse(Console.ReadLine());
                Console.WriteLine();
                points[i] = new Point(x, y);
            }
            Array.Sort(points, SortByDistance);
            foreach (var item in points)
            {
                Console.WriteLine(item.Data());
            }
        }
    }
}
