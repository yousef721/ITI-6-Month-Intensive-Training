using System;
using Lap01;

namespace Lap02;

public class Stack : DoubleLinkedList
{
    public void Push(Employee employee)
    {
        AddFirst(employee);
    }

    public void Pop()
    {
        RemoveFirst();
    }
}
