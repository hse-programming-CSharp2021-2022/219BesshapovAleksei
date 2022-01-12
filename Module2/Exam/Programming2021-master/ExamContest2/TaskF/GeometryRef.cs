using System;
using System.Collections.Generic;

internal class GeometryRef
{
    public double S
    {
        get;
        set;
    }
    public double P
    {
        get;
        set;
    }
    public string Type
    {
        get;
        set;
    }

    protected List<Point> Points
    {
        get;
        set;
    }
    protected GeometryRef()
    {

    }

    protected GeometryRef(string type, double s, double p)
    {
        Type = type;
        S = s;
        P = p;
    }

    protected virtual double GetPerimeter()
    {
        return this.P;
    }

    public virtual double GetSquare()
    {
        return this.S;
    }
    public static GeometryRef Parse(string line)
    {
        string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if ((data[0] == "Parallelogram" || data[0] == "Trapezoid") && data.Length != 9)
        {
            throw new ArgumentException("Incorrect input");
        }
        if (data[0] != "GeometryRef" && data[0] != "Trapezoid" && data[0] != "Parallelogram")
        {
            throw new ArgumentException("Incorrect input");
        }
        List<Point> points = new List<Point>();
        try
        {
            for (int i = 1; i < data.Length; i += 2)
            {
                bool isXCorrect = double.TryParse(data[i], out double x);
                bool isYCorrect = double.TryParse(data[i + 1], out double y);
                if (isXCorrect && isYCorrect)
                {
                    points.Add(new Point(x, y));
                }
                else
                {
                    throw new ArgumentException("Incorrect input");
                }
            }
        }
        catch
        {
            throw new ArgumentException("Incorrect input");
        }
        if (data[0] == "GeometryRef")
        {
            return new GeometryRef(data[0], 0, 0);
        }
        else if (data[0] == "Trapezoid")
        {
            Trapezoid trapezoid = new Trapezoid(points);
            return new GeometryRef(data[0], trapezoid.GetSquare(), trapezoid.GetPerimeter());
        }
        else
        {
            Parallelogram parallelogram = new Parallelogram(points);
            return new GeometryRef(data[0], parallelogram.GetSquare(), parallelogram.GetPerimeter());
        }
    }
    public override string ToString()
    {
        return $"{Type}. P = {this.GetPerimeter().ToString("F2")}. S = {this.GetSquare().ToString("F2")}";
    }
}