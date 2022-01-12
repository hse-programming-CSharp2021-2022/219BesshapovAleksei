using System;
using System.Collections.Generic;

internal class Parallelogram : GeometryRef
{
    public Parallelogram(List<Point> points)
    {
        Points = points;
    }

    public override double GetSquare()
    {
        double AB = Math.Sqrt(Math.Pow(this.Points[0].X - this.Points[1].X, 2) + Math.Pow(this.Points[0].Y - this.Points[1].Y, 2));
        double AD = Math.Sqrt(Math.Pow(this.Points[0].X - this.Points[3].X, 2) + Math.Pow(this.Points[0].Y - this.Points[3].Y, 2));
        double scalar = (this.Points[1].X - this.Points[0].X) * (this.Points[3].X - this.Points[0].X) +
            (this.Points[1].Y - this.Points[0].Y) * (this.Points[3].Y - this.Points[0].Y);
        double sin = Math.Sqrt(1 - Math.Pow(scalar / (AB * AD), 2));
        return AB * AD * sin;
    }

    protected override double GetPerimeter()
    {
        double AB = Math.Sqrt(Math.Pow(this.Points[0].X - this.Points[1].X, 2));
        double CD = Math.Sqrt(Math.Pow(this.Points[2].X - this.Points[3].X, 2));
        double BC = Math.Sqrt(Math.Pow(this.Points[2].X - this.Points[1].X, 2) + Math.Pow(this.Points[2].Y - this.Points[1].Y, 2));
        double AD = Math.Sqrt(Math.Pow(this.Points[0].X - this.Points[3].X, 2) + Math.Pow(this.Points[0].Y - this.Points[3].Y, 2));
        return AB + CD + BC + AD;
    }
}