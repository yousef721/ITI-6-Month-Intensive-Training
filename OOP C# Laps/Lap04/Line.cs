using System;

namespace Lap04;

public class Line
{
    Point start = new Point();
    Point end = new Point();

    public Line()
    {
        Console.WriteLine("Line default ctor");
    }

    public Line(int x1,int y1,int x2,int y2)
    {
        start.SetX(x1);
        start.SetY(y1);
        end.SetX(x2);
        end.SetY(y2);
        Console.WriteLine("Line 4 param ctor");
    }

    public void SetStart(Point _start) 
    {  
        start = _start; 
    }
    public void SetEnd(Point _end) 
    {
         end = _end; 
    }
    public Point GetStart() 
    {
         return start; 
    }
    public Point GetEnd() 
    { 
        return end; 
    }

    public string Print()
    {
        return $"Line Start({start.GetX()},{start.GetY()}), End {end.Print()}";
    }
}
