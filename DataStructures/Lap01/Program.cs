using System;

namespace Lap01;

class Program
{
    static void Main(string[] args)
    {
        // DoubleLinkedList list = new DoubleLinkedList();

        // Employee e1 = new Employee(1, 25, 5000, "HR");
        // Employee e2 = new Employee(2, 30, 7000, "IT");
        // Employee e3 = new Employee(3, 28, 6000, "IT");
        // Employee e4 = new Employee(4, 35, 9000, "IT");

        // // AddFirst
        // list.AddFirst(e1);
        // list.AddFirst(e2);

        // // AddLast
        // list.AddLast(e3);
        // list.AddLast(e4);

        // Console.WriteLine("Employees in list:");
        // list.Display();

        // Console.WriteLine("\nCount = " + list.Count());

        // // Search
        // Console.WriteLine("\nSearch for ID = 3");
        // Node result = list.Search(3);

        // if (result != null)
        //     Console.WriteLine("Found: " + result.data.ToString());
        // else
        //     Console.WriteLine("Employee not found");

        // // Get by index
        // Console.WriteLine("\nEmployee at index 2:");
        // Employee emp = list.getDataByIndex(2);

        // if (emp != null)
        //     Console.WriteLine(emp.ToString());

        // // Delete
        // Console.WriteLine("\nDeleting employee with ID = 2");
        // list.Delete(2);

        // Console.WriteLine("\nEmployees after delete:");
        // list.Display();

        // // RemoveFirst
        // Console.WriteLine("\nRemove First:");
        // list.RemoveFirst();
        // list.Display();

        // // RemoveLast
        // Console.WriteLine("\nRemove Last:");
        // list.RemoveLast();
        // list.Display();

        // Console.WriteLine("\nFinal Count = " + list.Count());

        // ===================== Built in LinkedList ====================
        
        LinkedList<Employee> employees = new LinkedList<Employee>();

        // AddFirst
        employees.AddFirst(new Employee(1, 25, 5000, "HR"));

        // AddLast
        employees.AddLast(new Employee(2, 30, 7000, "IT"));
        employees.AddLast(new Employee(3, 28, 6000, "Finance"));

        // Display
        Console.WriteLine("Employees List:");
        foreach (Employee e in employees)
        {
            Console.WriteLine(e);
        }

        // Count
        Console.WriteLine("\nCount: " + employees.Count);

        // First and Last
        Console.WriteLine("\nFirst Employee: " + employees.First.Value);
        Console.WriteLine("Last Employee: " + employees.Last.Value);

        // RemoveFirst
        employees.RemoveFirst();

        // RemoveLast
        employees.RemoveLast();

        Console.WriteLine("\nAfter Removing First and Last:");
        foreach (Employee e in employees)
        {
            Console.WriteLine(e);
        }

        // Search by ID
        Employee found = null;
        foreach (Employee e in employees)
        {
            if (e.id == 1)
            {
                found = e;
                break;
            }
        }

        if (found != null)
            Console.WriteLine("\nFound Employee: " + found);
        else
            Console.WriteLine("\nEmployee not found");
    }
}