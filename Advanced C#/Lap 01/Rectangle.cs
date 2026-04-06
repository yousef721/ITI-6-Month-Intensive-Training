using System;

namespace Lap01;

public class Rectangle: IShape, IColor
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public double CalculateArea()
    {
        return Width * Height;
    }

    public double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }

    public string GetColor()
    {
        return "Red";
    }
}
