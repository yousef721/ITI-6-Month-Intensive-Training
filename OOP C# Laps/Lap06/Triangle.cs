using System;

namespace Lap06;

public class Triangle : GeoShape
{
    double dim2;
    public Triangle() {}
    public Triangle(double _base, double _height) : base(_base)
    {
        dim2 = _height;
    }
    public void SetDim2(double _dim2) { dim2 = _dim2; }

    public override double GetArea()
    {
        return 0.5 * dim1 * dim2; // 0.5 * base * height
    }
}
