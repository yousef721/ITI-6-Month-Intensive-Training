using System;

namespace Lap03;

public abstract class DataStructure
{
    protected int[] arr;
    protected int size;


    public DataStructure()
    {
        size = 0;
        arr = new int[size];
    }

    public DataStructure(int _size)
    {
        size = _size;
        arr = new int[size];
    }

    public DataStructure(int _size, int[] _arr)
    {
        size = _size;
        arr = new int[_size];
        arr = _arr;
    }

    public abstract bool IsFull();
    public abstract bool IsEmpty();

}
