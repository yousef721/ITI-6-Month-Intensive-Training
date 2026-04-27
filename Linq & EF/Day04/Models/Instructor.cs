using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day04;

public class Instructor
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    [ForeignKey("Department")]
    public int? DepartmentId { get; set; }

    public virtual Department Department { get; set; }

    public virtual ICollection<Course> Courses { get; set; }
}