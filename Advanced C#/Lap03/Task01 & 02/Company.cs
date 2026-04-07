using System;

namespace Lap03;
public class Company
{
    public string Name { get; set; }
    public float Budget { get; set; }
    private List<Employee> employees = new List<Employee>();

    public Company()
    {
        Name = "";
        Budget = 0;
    }
    public Company(string name, float budget)
    {
        Name = name;
        Budget = budget;
    }

    public void AddEmployee(Employee emp)
    {
        employees.Add(emp);

        // Subscribe to event
        emp.OnSalaryIncreased += HandleSalaryIncrease;
    }

    private void HandleSalaryIncrease(float amount)
    {
        Budget -= amount;
        Console.WriteLine($"Company budget decreased by {amount}. New Budget: {Budget}");
    }
    public List<Employee> FilterEmployees(Predicate<Employee> filter) // bool, employee
    {
        List<Employee> result = new List<Employee>();

        foreach (var emp in employees)
        {
            if (filter(emp))
            {
                result.Add(emp);
            }
        }

        return result;
    }
}