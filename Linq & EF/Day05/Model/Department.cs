using System;

namespace Day05.Model;

public class Department
{
    public int Id { get; set; }
    public string Dname  { get; set; }

    public ICollection<Employee> Employees { get; set; }
}
