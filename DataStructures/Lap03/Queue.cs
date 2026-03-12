using System;

namespace Lap03;

public class Queue : DataStructure
{
    int front;
    int end;
    public int count;

    public Queue() : base()
    {
        front = 0;
        end = 0;
        count = 0;
    }

    public Queue(int _size) : base(_size)
    {
        front = 0;
        end = 0;
        count = 0;
    }

    public virtual bool Enqueue(int number)
    {
        if (!IsFull())
        {
            arr[end] = number;
            end = (end + 1) % size;
            count++;
            return true;
        }
        return false;
    }


    public virtual int Dequeue()
    {
        if (!IsEmpty())
        {
            int value = arr[front];
            front = (front + 1) % size;
            count--;
            return value;
        }
        return -1;
    }

    public virtual int Front()
    {
        if (!IsEmpty())
        {
            return arr[front];
        }
        return -1;
    }

    public override bool IsEmpty()
    {
        return count == 0;
    }

    public override bool IsFull()
    {
        return count == size;
    }
}