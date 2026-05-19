namespace Lap02.DTOs.Student;

public class StudentCreateDto
{
    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int DepartmentId { get; set; }

    public int? SupervisorId { get; set; }
}