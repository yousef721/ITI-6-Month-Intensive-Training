using System;

namespace Lap06;

public class Rectangle : GeoShape
{
    double dim2;
    public Rectangle() {}
    public Rectangle(double _length, double _width) : base(_length)
    {
        dim2 = _width;
    }
    public void SetDim2(double _dim2) { dim2 = _dim2; }
    
    public override double GetArea()
    {
        return dim1 * dim2; // w * h
    }
}
