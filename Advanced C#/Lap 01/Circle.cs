using System;

namespace Lap01;

public class Circle: IShape, IColor
{
    public int Radius { get; set; }

    public Circle(int radius)
    {
        Radius = radius;
    }

    public double CalculateArea()
    {
        return 3.14 * Radius * Radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * 3.14 * Radius;
    }

    public string GetColor()
    {
        return "Yellow";
    }
}
