namespace Lap02.DTOs.Student;
public class StudentReadDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? SupervisorName { get; set; }
}