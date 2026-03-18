using System;

namespace Lap04;

public class LinkedList
{
    Node head;
    Node tail;
    int count;

    public LinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void InsertSorted(Employee employee)
    {
        Node newNode = new Node(employee);

        if (head == null)
        {
            head = tail = newNode;
            count++;
            return;
        }

        Node current = head;

        while (current != null && current.data.CompareTo(employee) < 0)
        {
            current = current.next;
        }

        if (current == head)
        {
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
        }

        else if (current == null)
        {
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }

        else
        {
            Node prevNode = current.prev;

            prevNode.next = newNode;
            newNode.prev = prevNode;

            newNode.next = current;
            current.prev = newNode;
        }

        count++;
    }

    public void RemoveFirst()
    {
        if (head == null) return;

        head = head.next;

        if (head != null)
            head.prev = null;
        else
            tail = null;

        count--;
    }

    public void RemoveLast()
    {
        if (tail == null) return;

        tail = tail.prev;

        if (tail != null)
            tail.next = null;
        else
            head = null;

        count--;
    }

    public void Display()
    {
        Node current = head;

        while (current != null)
        {
            Console.WriteLine(current.data.ToString());
            current = current.next;
        }
    }

    public int Count()
    {
        return count;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }
}
