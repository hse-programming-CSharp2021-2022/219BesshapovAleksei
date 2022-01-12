using System;
using System.Collections.Generic;

internal class Trapezoid : GeometryRef
{
    public Trapezoid(List<Point> list) : base()
    {
        Points = list;
    }

    protected override double GetPerimeter()
    {
        double AB = Math.Sqrt(Math.Pow(this.Points[0].X - this.Points[1].X, 2));
        double CD = Math.Sqrt(Math.Pow(this.Points[2].X - this.Points[3].X, 2));
        double BC = Math.Sqrt(Math.Pow(this.Points[2].X - this.Points[1].X, 2) + Math.Pow(this.Points[2].Y - this.Points[1].Y, 2));
        double AD = Math.Sqrt(Math.Pow(this.Points[0].X - this.Points[3].X, 2) + Math.Pow(this.Points[0].Y - this.Points[3].Y, 2));
        return AB + CD + BC + AD;
    }

    public override double GetSquare()
    {
        double AB = Math.Sqrt(Math.Pow(this.Points[0].X - this.Points[1].X, 2) + Math.Pow(this.Points[0].Y - this.Points[1].Y, 2));
        double CD = Math.Sqrt(Math.Pow(this.Points[2].X - this.Points[3].X, 2) + Math.Pow(this.Points[2].Y - this.Points[3].Y, 2));
        double h = Math.Abs(this.Points[0].Y - this.Points[3].Y);
        return (AB + CD) / 2 * h;
    }
}