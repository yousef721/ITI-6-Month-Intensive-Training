namespace Lap02.Models;

public class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int DepartmentId { get; set; }

    public int? SupervisorId { get; set; }

    public Department Department { get; set; } = null!;

    public Student? Supervisor { get; set; }
}