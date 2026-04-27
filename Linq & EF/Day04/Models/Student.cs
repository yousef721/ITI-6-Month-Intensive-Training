using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day04;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    [ForeignKey("Department")]

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; }
}
