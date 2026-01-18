using System;

namespace Lap03;

public class Employee
{
    private int id;
    private string name;
    private int age;
    private float salary;

    // Id
    public void setId(int _id)
    {
        id = _id;
    }
    public int GetId()
    {
        return id;
    }

    // Name
    public void setName(string _name)
    {
        name = _name;
    }
    public string GetName()
    {
        return name;
    }

    // Age
    public void setAge(int _age)
    {
        age = _age;
    }
    public int GetAge()
    {
        return age;
    }

    // salary
    public void setSalary(float _salary)
    {
        salary = _salary;
    }
    public float GetSalary()
    {
        return salary;
    }

    public string Print()
    {
        return $"Employee (Id is {id}) - (Name is {name}) - (Age is {age}) - (Salary is {salary})";
    }

}
