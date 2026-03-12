using System;

namespace Lap03;

public class Stack : DataStructure
{  
    int top;

    public Stack() : base()
    {
        top = 0;
    }

    public Stack(int _size) : base(_size)
    {
        top = 0;
    }
    public Stack(int _size, int[] _arr) : base(_size, _arr)
    {
        top = _size;
    }

    public bool Push(int number)
    {
        if (!IsFull())
        {
            arr[top] = number;
            top++;
            return true;
        }
        return false;
    }
    

    public int Pop()
    {
        if (!IsEmpty())
        {
            top--;
            return arr[top];  
        }
        return -1;
    }


    public int Peek()
    {
        if (!IsEmpty())
        {
            return arr[top - 1];  
        }
        return -1;
    }

    public override bool IsEmpty()
    {
        return top == 0;
    }

    public override bool IsFull()
    {
        return top == size;
    }
}
