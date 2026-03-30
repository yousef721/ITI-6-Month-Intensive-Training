namespace Lap05;

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
        Employee[] employees1 = { e1, e2, e3, e4 };

        // Display before sorting
        Console.WriteLine("Before Sorting:");
        foreach (Employee e in employees1)
        {
            Console.WriteLine(e);
        }

        // Selection Sort
        Algorithms.SelectionSort(employees1);

        Console.WriteLine("\nAfter Selection Sort:");
        foreach (Employee e in employees1)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine("===================================");

        // Create Employees
        Employee e5 = new Employee(25, 5000, "HR", new DateTime(2020, 5, 1));
        Employee e6 = new Employee(30, 7000, "IT", new DateTime(2018, 3, 10));
        Employee e7 = new Employee(28, 6000, "Finance", new DateTime(2022, 7, 15));
        Employee e8 = new Employee(35, 8000, "IT", new DateTime(2019, 1, 20));

        // Put employees in array
        Employee[] employees2 = { e5, e6, e7, e8 };

        // Display before sorting
        Console.WriteLine("Before Sorting:");
        foreach (Employee e in employees2)
        {
            Console.WriteLine(e);
        }

        // Merge Sort
        Algorithms.MergeSort(employees2, 0, employees2.Length - 1);

        Console.WriteLine("\nAfter Merge Sort:");
        foreach (Employee e in employees2)
        {
            Console.WriteLine(e);
        }
    }
}
