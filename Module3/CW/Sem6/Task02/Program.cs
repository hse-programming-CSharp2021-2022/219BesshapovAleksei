using System;

namespace Task02
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
        public static double GetDistance(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }
    }
    class TriangleComp
    {
        Point[] points;
        double[] lengths;
        public double S
        {
            get
            {
                double p = (lengths[0] + lengths[1] + lengths[2]) / 2;
                return Math.Sqrt(p * (p - lengths[0]) * (p - lengths[1]) * (p - lengths[2]));
            }
        }
        public double P
        {
            get
            {
                return lengths[0] + lengths[1] + lengths[2];
            }
        }
        public TriangleComp(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            points = new Point[] { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3)};
            lengths = new double[] { Point.GetDistance(points[0], points[1]), Point.GetDistance(points[0], points[2]), Point.GetDistance(points[1], points[2]) };
        }
        public TriangleComp(Point A, Point B, Point C)
        {
            points = new Point[] { A, B, C };
            lengths = new double[] { Point.GetDistance(points[0], points[1]), Point.GetDistance(points[0], points[2]), Point.GetDistance(points[1], points[2]) };
        }
        public bool IsInTriangle(Point A)
        {
            TriangleComp newTriangle = new TriangleComp(points[0].X, points[0].Y, points[1].X, points[1].Y, A.X, A.Y);
            return S > newTriangle.S; 
        }
        public override string ToString()
        {
            return $"Периметр: {this.P}, Площадь: {this.S}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();
            TriangleComp[] triangles = new TriangleComp[5];
            for (int i = 0; i < 5; i++)
            {
                double x1 = 10 * randomizer.NextDouble();
                double x2 = 10 * randomizer.NextDouble();
                double y1 = 10 * randomizer.NextDouble();
                double y2 = 10 * randomizer.NextDouble();
                double x3 = 10 * randomizer.NextDouble();
                double y3 = 10 * randomizer.NextDouble();
                triangles[i] = new TriangleComp(x1, y1, x2, y2, x3, y3);
            }
            Array.ForEach(triangles, el => Console.WriteLine(el));
            Array.Sort(triangles, (a, b) => -a.S.CompareTo(b.S));
            Array.ForEach(triangles, el => Console.WriteLine(el));
            Array.Sort(triangles, (a, b) => a.P.CompareTo(b.P));
            Array.ForEach(triangles, el => Console.WriteLine(el));
        }
    }
}
