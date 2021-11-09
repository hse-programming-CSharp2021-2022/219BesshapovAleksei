using System;

namespace Task04
{
    class Shape
    {
        public const double PI = Math.PI;
        protected double _x, _y;
        public Shape()
        {
        }
        public Shape(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public virtual double Area()
        {
            return _x * _y;
        }
    }
    class Circle : Shape
    {
        public Circle(double r)
        {
            _x = r;
        }
        public override double Area()
        {
            return PI * this._x * this._x;
        }
        public override string ToString()
        {
            return $"Тип фигуры: круг, площадь: {this.Area()}";
        }
    }
    class Cylinder : Shape
    {
        public Cylinder(double r, double h)
        {
            _x = r;
            _y = h;
        }
        public override double Area()
        {
            return 2 * PI * this._x * this._x + 2 * PI * this._x * this._y;
        }
        public override string ToString()
        {
            return $"Тип фигуры: цилиндр, площадь: {this.Area()}";
        }
    }
    class Sphere : Shape
    {
        public Sphere(double r)
        {
            _x = r;
        }
        public override double Area()
        {
            return 4 * PI * this._x * this._x;
        }
        public override string ToString()
        {
            return $"Тип фигуры: сфера, площадь: {this.Area()}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int n1 = random.Next(3, 6);
            int n2 = random.Next(3, 6);
            int n3 = random.Next(3, 6);
            Shape[] shapes = new Shape[n1 + n2 + n3];
            for (int i = 0; i < n1; i++)
            {
                shapes[i] = new Circle(random.Next(5, 15));
            }
            for (int i = n1; i < n1 + n2; i++)
            {
                shapes[i] = new Cylinder(random.Next(5, 15), random.Next(5, 15));
            }
            for (int i = n1 + n2; i < shapes.Length; i++)
            {
                shapes[i] = new Sphere(random.Next(5, 15));
            }
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine($"Фигура {i + 1}, площадь: {shapes[i].Area()}.");
            }
            for (int i = 0; i < shapes.Length; i++)
            {
                if (shapes[i] is Shape a)
                {
                    Console.WriteLine(a);
                }
            }
        }
    }
}
