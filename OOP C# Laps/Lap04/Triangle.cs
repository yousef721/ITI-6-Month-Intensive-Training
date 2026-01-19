using System;

namespace Lap04;

public class Triangle
{
    Point P1;
    Point P2;
    Point P3;

    public Triangle(Point _P1, Point _P2, Point _P3)
    {
        P1 = _P1;
        P2 = _P2;
        P3 = _P3;
        Console.WriteLine("Triangle 3 Param ctor");
    }

    
    public void SetP1(Point _P1) {  P1 = _P1; }
    public void SetP2(Point _P2) { P2 = _P2; }
    public void SetP3(Point _P3) { P3 = _P3; }
    public Point GetP1() { return P1; }
    public Point GetP2() { return P2; }
    public Point GetP3() { return P3; }

    public string Print()
    {
        return $"Triangle P1{P1.Print()}, P2{P2.Print()}, P3{P3.Print()}";
    }
}
