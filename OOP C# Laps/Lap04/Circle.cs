using System;

namespace Lap04;

public class Circle
{
    Point point;
    int radius;

    public Circle(Point _point, int _radius)
    {
        point = _point;
        radius = _radius;

        Console.WriteLine("Circle 3 Param ctor");
    }

    public void SetCenterPoint(Point _point) { point = _point; }
    public Point GetCenterPoint() { return point; }
    public void SetRadius(int _radius) { radius = _radius; }
    public int GetRadius() { return radius; }
    

    public string Print()
    {
        return $"Circle Center Point {point.Print()}, radius is {radius}";
    }
}
