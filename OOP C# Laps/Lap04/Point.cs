using System;

namespace Lap04;

public class Point
{
    int x;
    int y;

    public Point()
    {
        x = 0;
        y = 0;
        Console.WriteLine("Point default ctor");
    }
    public Point(int _x, int _y)
    {
        x = _x;
        y = _y;
        Console.WriteLine("Point 2 param ctor");
    }

    public void SetX(int _x)
    {
        x = _x;
    }

    public void SetY(int _y)
    {
        y = _y;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public string Print()
    {
        return $"({x},{y})";
    }
}
