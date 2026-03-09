using System;

namespace Lap01;

public class Node
{
    public Employee data;
    public Node next;
    public Node prev;

    public Node(Employee _data) : base()
    {
        data = _data;
        next = null;
        prev = null;
    }
}
