using System;

namespace Lap03;

public class Employee
{
    public string Name { get; set; }
    public float Salary { get; private set; }

    // Event
    public event Action<float>? OnSalaryIncreased;

    public Employee(string name, float salary)
    {
        Name = name;
        Salary = salary;
    }

    public void IncreaseSalary(float amount)
    {
        Salary += amount;
        Console.WriteLine($"{Name} salary increased by {amount}");

        // Notify
        OnSalaryIncreased?.Invoke(amount);
    }
}
