using System;

namespace Lap04;

public class MathDefaultArgument
{
    // Default Argument
    public static int Add(int x = 0, int y = 0, int z = 0)
    {
        return x + y + z;
    }
    public static float Add(float x = 0, float y = 0, float z = 0)
    {
        return x + y + z;
    }


    public static int Subtract(int x = 0, int y = 0, int z = 0)
    {
        return x - y - z;
    }
    public static float Subtract(float x = 0, float y = 0, float z = 0)
    {
        return x - y - z;
    }
}
