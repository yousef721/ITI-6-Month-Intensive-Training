using System;

namespace Lap06;

public class Circle : GeoShape
{
    public Circle(){}
    public Circle(double _radius): base(_radius) {}
    public override double GetArea()
    {
        return Math.PI * dim1 * dim1; // PI * s-2
    }
}
