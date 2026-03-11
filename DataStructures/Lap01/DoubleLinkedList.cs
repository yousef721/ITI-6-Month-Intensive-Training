using System;

namespace Lap01;

public class DoubleLinkedList
{
    Node head;
    Node tail;
    int count;

    public DoubleLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void AddFirst(Employee employee) // O(1)
    {
        Node newNode = new Node(employee);
        if(head == null)
        {
            head = newNode;
            tail = newNode;
        } else
        {
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
        }
        count++;
    }
    public void AddLast(Employee employee) // O(1)
    {
        Node newNode = new Node(employee);
        if(head == null)
        {
            head = newNode;
            tail = newNode;
        } else
        {
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }
        count++;
    }
    
    public void RemoveFirst() // O(1)
    {
        if (head == null) return;

        head = head.next;

        if (head != null)
            head.prev = null;
        else
            tail = null;

        count--;
    }
        
    public void RemoveLast() // O(1)
    {
        if (tail == null) return;

        tail = tail.prev;

        if (tail != null)
            tail.next = null;
        else
            head = null;

        count--;
    }

    public Node Search(int id) // O(n)
    {
        Node current = head;

        while (current != null)
        {
            if (current.data.id == id)
                return current;

            current = current.next;
        }

        return null;
    }

    public void Delete(int id) // O(n)
    {
        Node node = Search(id);

        if (node == null)
            return;

        if (node == head)
            RemoveFirst();
        else if (node == tail)
            RemoveLast();
        else
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
            count--;
        }
    }

    public Employee GetDataByIndex(int index) // O(n)
    {
        if (index < 0 || index >= count)
            return null;

        Node current = head;

        for (int i = 0; i < index; i++)
        {
            current = current.next;
        }

        return current.data;
    }

    public void Display() // O(n)
    {
        Node current = head;

        while (current != null)
        {
            Console.WriteLine(current.data.ToString());
            current = current.next;
        }
    }

    public Employee Peek() // O(1)
    {
        if (head != null)
        {
            return head.data;
        }
        return null;
    }

    public int Count() // O(1)
    {
        return count;
    }

    public bool IsEmpty() // O(1)
    {
        return Count() == 0;
    }
}
