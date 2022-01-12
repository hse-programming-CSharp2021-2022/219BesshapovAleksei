using System;

internal static class CircleInSquare
{
    public static double CircumFerence(double side)
    {
        return Math.PI * side;
    }

    public static double Square(double side)
    {
        return Math.PI * side * side / 4;
    }

    public static double FreeSpace(double side)
    {
        return side * side - Square(side);
    }
}