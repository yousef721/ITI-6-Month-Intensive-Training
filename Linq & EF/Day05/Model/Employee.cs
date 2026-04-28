using System;

namespace Day05.Model;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Salary { get; set; }
    public int Dno { get; set; }
    public Department Department { get; set; }
}
