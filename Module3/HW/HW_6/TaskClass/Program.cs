using System;

namespace TaskClass
{
    class Point
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
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double Distance(Point a)
        {
            return Math.Sqrt(Math.Pow(this.X - a.X, 2) + Math.Pow(this.Y - a.Y, 2));
        }
        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }
    }
    class Circle : IComparable<Circle>
    {
        public double Rad
        {
            get;
            set;
        }
        public Point center;
        public Circle(double x, double y, double rad)
        {
            Rad = rad;
            center = new Point(x, y);
        }
        public override string ToString()
        {
            return $"Окружность: радиус - {this.Rad}, центр - {this.center}";
        }
        public int CompareTo(Circle circle2)
        {
            if (this.Rad * this.center.Distance(new Point(0, 0)) < circle2.Rad * circle2.center.Distance(new Point(0, 0)))
            {
                return -1;
            }
            else if (this.Rad * this.center.Distance(new Point(0, 0)) > circle2.Rad * circle2.center.Distance(new Point(0, 0)))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    struct PointStruct
    {
        public int X;
        public int Y;
        public PointStruct(int x, int y)
        {
            X = x;
            Y = y;
        }
        public double Distance(PointStruct a)
        {
            return Math.Sqrt(Math.Pow(this.X - a.X, 2) + Math.Pow(this.Y - a.Y, 2));
        }
    }
    struct CircleStruct
    {
        public int Rad;
        public PointStruct center;
        public CircleStruct(int x, int y, int rad)
        {
            center = new PointStruct(x, y);
            Rad = rad;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();
            Circle[] circles = new Circle[5];
            for (int i = 0; i < 5; i++)
            {
                circles[i] = new Circle(10 * randomizer.NextDouble(), 10 * randomizer.NextDouble(), 10 * randomizer.NextDouble());
            }
            Array.ForEach(circles, el => Console.WriteLine(el));
            Console.WriteLine("***");
            Array.Sort(circles, (circle1, circle2) => (circle1.Rad * circle1.center.Distance(new Point(0, 0))).CompareTo(circle2.Rad * circle2.center.Distance(new Point(0, 0))));
            Array.ForEach(circles, el => Console.WriteLine(el));
            Console.WriteLine("***");
            Array.Sort(circles, delegate (Circle circle1, Circle circle2) {
                if (circle1.Rad * circle1.center.Distance(new Point(0, 0)) < circle2.Rad * circle2.center.Distance(new Point(0, 0)))
                {
                    return -1;
                }
                else if (circle1.Rad * circle1.center.Distance(new Point(0, 0)) > circle2.Rad * circle2.center.Distance(new Point(0, 0)))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });
            Array.ForEach(circles, el => Console.WriteLine(el));
            Console.WriteLine("***");
            Array.Sort(circles);
            Array.ForEach(circles, el => Console.WriteLine(el));
            Console.WriteLine("***");
            // заметно, что все три метода сортировки делают одно и то же, как и должно быть
        }
    }
}
