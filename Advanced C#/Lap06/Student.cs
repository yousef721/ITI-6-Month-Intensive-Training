using System;

namespace Lap06;

public class Student
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public Grade Grade { get; set; }
    public string? Address { get; set; }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Grade: {Grade}");
        Console.WriteLine($"Address: {Address}");
    }
}