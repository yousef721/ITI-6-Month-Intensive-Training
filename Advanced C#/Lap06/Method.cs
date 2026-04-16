using System;

namespace Lap06;

public class Method
{
    [Obsolete("Don't Use This Method", false)]
    public static int Add(int x, int y)
    {
        return x + y;
    }
    [Obsolete("This Method Is deprecated", true)]
    public static int Add(int x, int y, int z)
    {
        return x + y + z;
    }
}
