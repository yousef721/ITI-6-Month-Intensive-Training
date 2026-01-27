using System;

namespace Lap06;

public class Square : GeoShape
{
    public Square() {}

    public Square(double _Side) : base(_Side) {}

    public override double GetArea()
    {
        return dim1 * dim1; // s-2
    }
}
