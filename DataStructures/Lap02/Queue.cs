using System;
using Lap01;

namespace Lap02;

public class Queue : DoubleLinkedList
{
    public void Enqueue(Employee employee)
    {
        AddLast(employee);
    }

    public void Dequeue()
    {
        RemoveFirst();
    }
}
