using System;

namespace Lap01;

public class Employee
{
    public int id;
    public int age;
    public int salary;
    public string departmentName;

    public Employee ()
    {
        id = 0;
        age = 0;
        salary = 0;
        departmentName = "";
    }
    public Employee (int _id, int _age, int _salary, string _departmentName)
    {
        id = _id;
        age = _age;
        salary = _salary;
        departmentName = _departmentName;
    }

    public override string ToString()
    {
        return $"ID: {id}, Age: {age}, Salary: {salary}, Department: {departmentName}";
    }
}
