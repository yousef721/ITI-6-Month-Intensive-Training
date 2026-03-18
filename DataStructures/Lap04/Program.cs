using System;

namespace Lap04;

class Program
{
    static void Main(string[] args)
    {
        // Create Employees
        Employee e1 = new Employee(25, 5000, "HR", new DateTime(2020, 5, 1));
        Employee e2 = new Employee(30, 7000, "IT", new DateTime(2018, 3, 10));
        Employee e3 = new Employee(28, 6000, "Finance", new DateTime(2022, 7, 15));
        Employee e4 = new Employee(35, 8000, "IT", new DateTime(2019, 1, 20));

        // Put employees in array
        Employee[] employees = { e1, e2, e3, e4 };

        // Display before sorting
        Console.WriteLine("Before Sorting:");
        foreach (Employee e in employees)
        {
            Console.WriteLine(e);
        }

        // Bubble Sort
        Algorithms.BubbleSort(employees);

        Console.WriteLine("\nAfter Bubble Sort:");
        foreach (Employee e in employees)
        {
            Console.WriteLine(e);
        }

        // Binary Search (Iterative)
        DateTime target = new DateTime(2019, 1, 20);
        int index = Algorithms.BinarySearch(employees, target);

        if (index != -1)
            Console.WriteLine($"\nBinary Search Iterative: Found at index {index}");
        else
            Console.WriteLine("\nBinary Search Iterative: Not Found");

        // Binary Search (Recursive)
        int indexRec = Algorithms.BinarySearchRec(employees, 0, employees.Length - 1, target);

        if (indexRec != -1)
            Console.WriteLine($"Binary Search Recursive: Found at index {indexRec}");
        else
            Console.WriteLine("Binary Search Recursive: Not Found");


        // Sorted LinkedList Example
        Console.WriteLine("\nSorted LinkedList:");

        LinkedList list = new LinkedList();

        list.InsertSorted(e1);
        list.InsertSorted(e2);
        list.InsertSorted(e3);
        list.InsertSorted(e4);

        list.Display();
    }
}