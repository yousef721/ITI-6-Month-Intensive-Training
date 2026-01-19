using System;

namespace Lap04;

public class MathOverloading
{
 // Overloading
    public static int Add(int x, int y)
    {
        return x + y;
    }

    public static int Add(int x, int y, int z)
    {
        return x + y + z;
    }

    public static float Add(float x, float y)
    {
        return x + y;
    }

    public static float Add(float x, float y, float z)
    {
        return x + y + z;
    }
    
    public static int Subtract(int x, int y)
    {
        return x - y;
    }

    public static int Subtract(int x, int y, int z)
    {
        return x - y - z;
    }

    public static float Subtract(float x, float y, float z)
    {
        return x - y - z;
    }
    public static float Subtract(float x, float y)
    {
        return x - y;
    }
}
