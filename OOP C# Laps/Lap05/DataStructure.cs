using System;

namespace Lap05;

public class DataStructure
{
    protected int[] arr;
    protected int size;

    public DataStructure()
    {
        size = 5;
        arr = new int[size];
    }

    public DataStructure(int _size)
    {
        size = _size;
        arr = new int[size];
    }

    public bool IsFull()
    {
        return true;
    }
    public bool IsEmpty()
    {
        return true;
    }

}
