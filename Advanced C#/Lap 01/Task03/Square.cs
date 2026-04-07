using System;

namespace Lap01;

public class Square: IShape, IColor
{
    public int SideLength { get; set; }

    public Square(int sideLength)
    {
        SideLength = sideLength;
    }

    public double CalculateArea()
    {
        return SideLength * SideLength;
    }

    public double CalculatePerimeter()
    {
        return 4 * SideLength;
    }

    public string GetColor()
    {
        return "Green";
    }
}
