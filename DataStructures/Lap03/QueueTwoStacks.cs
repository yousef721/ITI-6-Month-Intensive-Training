using System;

namespace Lap03;

public class QueueTwoStacks : Queue
{
    Stack stack1;
    Stack stack2;


    public QueueTwoStacks(int _size) : base(_size)
    {
        stack1 = new Stack(_size);
        stack2 = new Stack(_size);
        count = 0;
    }

    public override bool Enqueue(int number)
    {
        if (!IsFull())
        {
            stack1.Push(number);
            count++;

            return true;
        }
        return false;
    }

    public override int Dequeue()
    {
        if (!IsEmpty())
        {
            if (stack2.IsEmpty())
            {
                while (!stack1.IsEmpty())
                {
                    stack2.Push(stack1.Pop());
                }
            }

            count--;
            return stack2.Pop();
        }
        return -1;
    }

    public override int Front()
    {
        if(!IsEmpty())
        {
            if (stack2.IsEmpty())
            {
                while (!stack1.IsEmpty())
                {
                    stack2.Push(stack1.Pop());
                }
            }

            return stack2.Peek();
        }
        return -1;
    }
}
