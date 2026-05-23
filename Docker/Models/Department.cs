namespace Lap02.Models;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Student> Students { get; set; } = null!;
}