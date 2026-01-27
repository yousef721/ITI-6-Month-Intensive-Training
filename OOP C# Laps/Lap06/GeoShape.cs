namespace Lap06;

public abstract class GeoShape
{
    protected double dim1;

    public void SetDim(double _dim) { dim1 = _dim; }
    
    public GeoShape()
    {
        dim1 = 0;
    }
    public GeoShape(double _dim)
    {
        dim1 = _dim;
    }
    
    public abstract double GetArea();
}
