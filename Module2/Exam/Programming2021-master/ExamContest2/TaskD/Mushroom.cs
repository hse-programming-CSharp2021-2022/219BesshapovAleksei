using System;
using System.Collections.Generic;

public class Mushroom
{
    private string Name { get; }
    private double Weight { get; }
    private double Diameter { get; }

    private Mushroom(string name, double weight, double diameter)
    {
        Name = name;
        Weight = weight;
        Diameter = diameter;
    }

    public static Mushroom Parse(string line)
    {
        try
        {
            string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool isWeightCorrect = double.TryParse(data[1], out double weight);
            bool isDiCorrect = double.TryParse(data[2], out double d);
            if (isWeightCorrect && isDiCorrect && weight > 0 && d > 0)
            {
                return new Mushroom(data[0], weight, d);
            }
            throw new ArgumentException("Incorrect input");
        }
        catch
        {
            throw new ArgumentException("Incorrect input");
        }
    }

    public static double GetMinimalDiameter(List<Mushroom> mushrooms, double m)
    {
        Mushroom[] suitableDs = Array.FindAll(mushrooms.ToArray(), el => el.Weight < m);
        double minD = suitableDs.Length == 0 ? 0 : suitableDs[0].Diameter;
        foreach (Mushroom mushroom in suitableDs)
        {
            minD = Math.Min(minD, mushroom.Diameter);
        }
        return minD;
    }
}